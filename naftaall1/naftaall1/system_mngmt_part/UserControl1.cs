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
    public partial class AddUpPersControl : UserControl
    {
        Local_DB.naftall1Entities1 db = new Local_DB.naftall1Entities1 ();
        Local_DB.person person_tb = new Local_DB.person(); 
        public AddUpPersControl()
        {
            InitializeComponent();
        }
        public int add_person()
        {
            person_tb.nom = tb_nom.Text;
            person_tb.Tel = tb_tel.Text;
            person_tb.adresse = tb_adress.Text;
            person_tb.date_ajoute = DateTime.Now;
            db.person.Add(person_tb);
            db.SaveChanges();
            return person_tb.id;
        }
        public void update_person()
        {
            person_tb.nom = tb_nom.Text;
            person_tb.Tel = tb_tel.Text;
            person_tb.adresse = tb_adress.Text;
            db.Entry(person_tb).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void load_data_person(int person_id)
        {
            person_tb = db.person.Where(x => x.id == person_id).FirstOrDefault();
            tb_nom.Text = person_tb.nom;
            tb_tel.Text = person_tb.Tel;
            tb_adress.Text = person_tb.adresse;
        }
    }
}
