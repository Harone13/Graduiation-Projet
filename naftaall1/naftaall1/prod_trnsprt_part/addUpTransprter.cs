using naftaall1.Local_DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace naftaall1.prod_trnsprt_part
{
    public partial class addUpTransprter : Form
    {
        int Trspt_id = -1;
        Local_DB.naftall1Entities1 db = new Local_DB.naftall1Entities1();
        Local_DB.transporteur Trans_tb = new Local_DB.transporteur();
        public addUpTransprter(int _trspt_id)
        {
            InitializeComponent();
            Trspt_id = _trspt_id;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Trspt_id == -1)  
            {
                Trans_tb.person = addUpPersControl1.add_person();
                db.transporteur.Add(Trans_tb);
                db.SaveChanges();
                MessageBox.Show("Un nouvoux Transporteur est ajoutee");
            }
        }
    }
}
