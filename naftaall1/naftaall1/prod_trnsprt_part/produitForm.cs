using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace naftaall1.prod_trnsprt_part
{
    public partial class produitForm : Form
    {
        Local_DB.naftall1Entities1 db = new Local_DB.naftall1Entities1 ();
        Local_DB.produit produit = new Local_DB.produit ();
        public produitForm()
        {
            InitializeComponent();
            load_prods ();
        }

        public  void load_prods()
        {
            db.produit.LoadAsync().Wait();
            var tb = db.produit.ToList();
            dataGridView1.DataSource = tb;
            lb_count.Text = db.produit.Count().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var addFrm = new addUpProd(0))
            {
                addFrm.FormClosed += closeFrm;
                addFrm.ShowDialog();
            }
        }

        private void closeFrm(object sender, FormClosedEventArgs e)
        {
            load_prods();
        }
    }
}
