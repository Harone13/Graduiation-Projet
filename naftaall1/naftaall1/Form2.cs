using naftaall1.Local_DB;
using naftaall1.system_mngmt_part;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace naftaall1
{
    public partial class Form2 : Form
    {
        Local_DB.naftall1Entities1 db = new Local_DB.naftall1Entities1();
        Local_DB.utilisateur user = new Local_DB.utilisateur();
        Local_DB.person person = new Local_DB.person();
        int threetimes = 0;
        string connString = Program.ConnectionString;

        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '\0') textBox2.PasswordChar = '*';
            else textBox2.PasswordChar = '\0';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var bol = db.utilisateur.Where(x => x.user_name == textBox1.Text).Any();
            if (bol)
            {
                user = db.utilisateur.Where(x => x.user_name == textBox1.Text).FirstOrDefault();
                if (user.mot_pass == textBox2.Text)
                {
                    mainForm mainForm = new mainForm(user.id);
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("errereur de nom d'utilisateur ou de mot de pass /n Vous pous essayer " + (3 - threetimes).ToString() + " fois");
                    if (threetimes >= 3) Application.Exit();
                    else threetimes++;
                } 
            }
            else
            {
                MessageBox.Show("errereur de nom d'utilisateur ou de mot de pass /n Vous pous essayer " + (3 - threetimes).ToString() + "  fois");
                if (threetimes >= 3) Application.Exit();
                else threetimes++;
            }
        }
        private string BuildEntityConnectionString(string userSqlConnString)
        {
            // Use SqlConnectionStringBuilder to canonicalize the SQL connection string
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder(userSqlConnString);
            string canonicalSqlConnString = sqlBuilder.ConnectionString;

            // Build the full EF connection string with metadata
            var entityBuilder = new EntityConnectionStringBuilder();
            // Make sure the metadata part exactly matches the embedded resource names in your EDMX.
            entityBuilder.Metadata = "res://*/Local_DB.naftall1.csdl|res://*/Local_DB.naftall1.ssdl|res://*/Local_DB.naftall1.msl";
            entityBuilder.Provider = "System.Data.SqlClient";
            entityBuilder.ProviderConnectionString = canonicalSqlConnString;

            return entityBuilder.ToString();
        }
        private void btn_conn_Click(object sender, EventArgs e)
        {


            string userSqlConnString = tx_conn_string.Text.Trim();
            string fullEntityConnString = BuildEntityConnectionString(userSqlConnString);

            try
            {
                // Use the direct string instead of relying on config
                using (var context = new naftall1Entities1())
                {
                    bool connected = context.Database.Exists();
                    MessageBox.Show(connected ? "Connected successfully!" : "Connection failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string updatedValue = ConfigurationManager.ConnectionStrings["AppConnectionString"].ConnectionString;
            MessageBox.Show("Updated connection string: " + updatedValue);
        }
    }
}
