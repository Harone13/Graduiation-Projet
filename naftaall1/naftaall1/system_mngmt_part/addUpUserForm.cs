using naftaall1.client_part;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace naftaall1.system_mngmt_part
{
    public partial class addUpUserForm : Form
    {
        Local_DB.naftall1Entities1 db = new Local_DB.naftall1Entities1 ();
        Local_DB.utilisateur user = new Local_DB.utilisateur ();    
        Local_DB.person person = new Local_DB.person ();
        int add_up;
        public addUpUserForm(int _add_up)
        {
            InitializeComponent();
            add_up = _add_up;
            if (add_up == 1)
            {
                lb_title.Text = "Ajouter un nouvoux utilisateur";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (add_up == -1)
            {
                var bol = db.utilisateur.Where(x => x.user_name == textBox1.Text).Any();
                if (bol)
                {
                    MessageBox.Show("ce nom utilisateur dejat utilise");
                }
                else 
                {  
                    int person_id = addUpPersControl1.add_person();
                    user.person = person_id;
                    user.user_name = textBox1.Text;
                    user.mot_pass = textBox2.Text;
                    user.role = comboBox1.SelectedIndex + 2;
                    db.utilisateur.Add(user);
                    db.SaveChanges();
                    MessageBox.Show("un nouvau utilisateur a ete ajouter");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '\0') textBox2.PasswordChar = '*';
            else textBox2.PasswordChar = '\0';
        }
    }
}
