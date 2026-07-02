using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace naftaall1.client_part
{
    public partial class addUpClient : Form
    {
        Local_DB.naftall1Entities1 db = new Local_DB.naftall1Entities1();
        Local_DB.client client_tb = new Local_DB.client();
        Local_DB.person person_tb = new Local_DB.person();
        int UpMod = 0;
        public addUpClient(int addUpMods)
        {
            InitializeComponent();
            UpMod = addUpMods;
            if (UpMod == 0) { lb_title.Text = "Ajouter Client"; }
            else 
            { 
                lb_title.Text = "Modifier Client";
                int client_id = UpMod;
                client_tb = db.client.Where(x => x.id == client_id).FirstOrDefault();
                person_tb = db.person.Where(x => x.id == client_tb.person_id).FirstOrDefault();
                addUpPersControl1.load_data_person(person_tb.id);
                textBox1.Text = client_tb.registre.ToString();
            }
        }          

        private void button1_Click(object sender, EventArgs e)
        {
            if (UpMod == 0)    
            {
                var person_id  = addUpPersControl1.add_person();
                client_tb.person_id = person_id;
                client_tb.registre = Convert.ToInt32(textBox1.Text);
                db.client.Add(client_tb);
                db.SaveChanges();

                MessageBox.Show("un nouvau client a ete ajouter");
            }
            else
            {
                addUpPersControl1.update_person();
                client_tb.registre = Convert.ToInt32(textBox1.Text);
                db.Entry(client_tb).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                MessageBox.Show("Le client avec le numero " + client_tb.id.ToString() + " est modifie");
            }
        }
    }
}
