using naftaall1.Local_DB;
using naftaall1.prod_trnsprt_part;
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

namespace naftaall1.client_part
{
    public partial class orderListFrm : Form
    {
        Local_DB.naftall1Entities1 db = new Local_DB.naftall1Entities1();
        Local_DB.produit produit = new Local_DB.produit();
        Local_DB.commandes commandes = new Local_DB.commandes();
        Local_DB.bon_liv bon_Liv_tb = new Local_DB.bon_liv();

        int curent_stat = 0;
        public orderListFrm()
        {
            InitializeComponent();
            load_bon_liv03();
        }
        public async void load_bon_liv1(int bon_stat)
        {
            // db.bon_liv.Load();
            var client_tb = await db.bon_liv.Where(x => x.status == bon_stat)
        .Join(db.commandes,
              b => b.num_BonLiv,
              c => c.bon_liv,
             (b, c) => new
             {
                 BonLiv = b,
                 Commande = c
             }
          )
        .Join(db.client,
          combined1 => combined1.Commande.client,
          cl => cl.id,
          (combined1, cl) => new
          {
              com = combined1,
              Client = cl
          }
          )
        .Join(db.person,
             Cl => Cl.Client.person_id,
             p => p.id,
          (Cl, p) => new
          {

              Cl.com.BonLiv.num_BonLiv,
              Cl.com.BonLiv.date_ajout,
              Cl.Client.id,
              Cl.com.BonLiv.montant_total,
              p.nom,
              Cl.com.BonLiv.status,

          }

            ).Distinct().ToListAsync();
            dataGridView1.DataSource = client_tb;
            //dataGridView1.DataSource = db.bon_liv.ToList();
            lb_count.Text = client_tb.Count().ToString();
            dataGridView1.Columns["status"].Visible = false;
        }

        public async void load_bon_liv03()
        {
            // db.bon_liv.Load();
            var client_tb = await db.bon_liv.Where(x => x.status == 0 || x.status == 3)
        .Join(db.commandes,
              b => b.num_BonLiv,
              c => c.bon_liv,
             (b, c) => new
             {
                 BonLiv = b,
                 Commande = c
             }
          )
        .Join(db.client,
          combined1 => combined1.Commande.client,
          cl => cl.id,
          (combined1, cl) => new
          {
              com = combined1,
              Client = cl
          }
          )
        .Join(db.person,
             Cl => Cl.Client.person_id,
             p => p.id,
          (Cl, p) => new
          {

              Cl.com.BonLiv.num_BonLiv,
              Cl.com.BonLiv.date_ajout,
              Cl.Client.id,
              Cl.com.BonLiv.montant_total,
              p.nom,
              Cl.com.BonLiv.status,

          }

            ).Distinct().ToListAsync();
            dataGridView1.DataSource = client_tb;
            //dataGridView1.DataSource = db.bon_liv.ToList();
            lb_count.Text = client_tb.Count().ToString();

            dataGridView1.Columns["status"].Visible = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["status"].Value != null)
                {
                    string status = row.Cells["status"].Value.ToString();
                    if (status == "3")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                    }
                    else if (status == "7")
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                    
                }
            }
        }

        public async void load_bon_enl(int bon_stat)
        {
            
            var Bon_enlev_tb = await db.bon_enlev.Where(x => x.status == bon_stat)
                .Select(x => new {x.id , x.mode, x.programme}).ToListAsync();
            dataGridView1.DataSource = Bon_enlev_tb.ToList();
        }
        public async void load_prods()
        {
            var client_tb = await db.commandes
            .Join(db.produit,
                  c => c.produit,
                  p => p.code,
                  (c, p) => new
                  {
                      p.code,
                      p.designation,
                      p.prixu_unit,
                      c.prod_qnt,

                  }

            )
            .ToListAsync();
            dataGridView1.DataSource = client_tb;
                  
                    var  rowCount =  db.client
           .Join(db.person,
                 c => c.person_id,
                 p => p.id,
                 (c, p) => new
                 {
                     c.id,
                     p.nom,
                     p.adresse,
                     p.Tel,
                     c.registre,

                 }

                 )
               .CountAsync(); 

            //db.produit.LoadAsync().Wait();
            //var tb = db.produit.ToList();
            //dataGridView1.DataSource = tb;
            //lb_count.Text = db.produit.Count().ToString();
        }



        private void lesNouvousCommandesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load_bon_liv03();
            curent_stat = 0;
            validerToolStripMenuItem.Enabled = true;
            anullerToolStripMenuItem.Enabled = true;
            modifierToolStripMenuItem.Enabled = true;
            suprimerToolStripMenuItem.Enabled = true;
        }

        private void lesCommandesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            modifierToolStripMenuItem.Enabled = false;
            suprimerToolStripMenuItem.Enabled = false; 
            validerToolStripMenuItem.Enabled = false;
            anullerToolStripMenuItem.Enabled = false;
            load_bon_liv1(6);
            curent_stat = 6;
        }

        private void lhistoriqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            validerToolStripMenuItem.Enabled = false;
            anullerToolStripMenuItem.Enabled = false;
            modifierToolStripMenuItem.Enabled = false;
            suprimerToolStripMenuItem.Enabled = false;
            load_bon_liv1(4);
            curent_stat = 4;
        }



        private void encaisseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int num_bon = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                EncaissementFrm frm = new EncaissementFrm(num_bon);
  
                if (suprimerToolStripMenuItem.Enabled == false)
                {
                    frm.radioButton2.Enabled = false;
                }
                frm.ShowDialog();
            }
        }

        private void cacheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load_bon_liv1(1);
            curent_stat = 1;
            modifierToolStripMenuItem.Enabled = false;
            suprimerToolStripMenuItem.Enabled = false;
            validerToolStripMenuItem.Enabled = false;
            anullerToolStripMenuItem.Enabled = false;
        }

        private void creditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load_bon_liv1(2);
            curent_stat = 2;
            modifierToolStripMenuItem.Enabled = false;
            suprimerToolStripMenuItem.Enabled = false;
            validerToolStripMenuItem.Enabled = false;
            anullerToolStripMenuItem.Enabled = false;
        }

        private void orderListFrm_Load(object sender, EventArgs e)
        {

        }

        private void suprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Local_DB.bon_liv bon_Liv = new Local_DB.bon_liv();
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            bon_Liv = db.bon_liv.Where(b => b.num_BonLiv == id).FirstOrDefault();

            var result = MessageBox.Show("comfirmer suprimmer cette commande", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                var do_wile = 0;
                while (do_wile == 0)
                {
                    Local_DB.commandes c = new Local_DB.commandes();
                    var bol_test = db.commandes.Where(b => b.bon_liv == id).Any();
                    if (bol_test)
                    {
                        c = db.commandes.Where(b => b.bon_liv == id).FirstOrDefault();
                        db.Entry(c).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                    }
                    else { do_wile = 1; }

                }
                db.Entry(bon_Liv).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            load_bon_liv03();
        }

        private void validerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Local_DB.bon_liv bon_Liv = new Local_DB.bon_liv();
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            bon_Liv = db.bon_liv.Where(b => b.num_BonLiv == id).FirstOrDefault();
            bon_Liv.status = 3;
            var result = MessageBox.Show("comfirmer la Validation cette commande", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                db.Entry(bon_Liv).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            load_bon_liv03();
        }

        private void bonEnlevementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load_bon_enl(0);
            modifierToolStripMenuItem.Enabled = false;
            suprimerToolStripMenuItem.Enabled = false;
            validerToolStripMenuItem.Enabled = false;
            anullerToolStripMenuItem.Enabled = false;
        }

        private void lhistoriqueBEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load_bon_enl(1);
            modifierToolStripMenuItem.Enabled = false;
            suprimerToolStripMenuItem.Enabled = false;
            validerToolStripMenuItem.Enabled = false;
            anullerToolStripMenuItem.Enabled = false;
        }

        private void VoirDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Local_DB.bon_liv bon_Liv = new Local_DB.bon_liv();
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            comDetailForm frm = new comDetailForm(id);
            frm.ShowDialog();

        }
    }
}
