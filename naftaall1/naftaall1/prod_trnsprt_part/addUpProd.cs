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
    public partial class addUpProd : Form
    {
        Local_DB.naftall1Entities1 db = new Local_DB.naftall1Entities1();
        Local_DB.produit produit = new Local_DB.produit();
        int UpMod;
        public addUpProd(int _UpMod)
        {
            InitializeComponent();
            if (UpMod == 0) { lb_title.Text = "Ajouter un Produit"; }
            else
            { lb_title.Text = "Modifier un Produit"; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UpMod == 0) 
            { 
                produit.designation = tb_designation.Text;
                produit.prixu_unit = nu_prix_u.Value;
                produit.qnt = Convert.ToInt32( nu_qnt.Value);
                db.produit.Add(produit);
                db.SaveChanges();
                MessageBox.Show("un nouvau Produit a ete ajouter");
            }
            else
            { lb_title.Text = "Modifier un Produit"; }
        }
    }
}
