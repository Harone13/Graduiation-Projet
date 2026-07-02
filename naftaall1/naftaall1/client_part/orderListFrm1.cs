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

namespace naftaall1.client_part
{
    public partial class orderListFrm1 : Form
    {
        Local_DB.naftall1Entities1 db = new Local_DB.naftall1Entities1();
        Local_DB.produit produit = new Local_DB.produit();
        Local_DB.commandes commandes = new Local_DB.commandes();
        Local_DB.bon_liv bon_Liv_tb = new Local_DB.bon_liv();
        int load_encass;
        public orderListFrm1(int type)
        {
            InitializeComponent();
            if (type == 0)
            {
                load_bon_liv1();
                button2.Visible = false;
            }
            else if (type == 1)
            {
                dataGridView1.ContextMenuStrip = contextMenuStrip2;
                load_bon_liv2();

                button1.Visible = false;
            }

        }

        public void load_bon_liv3()
        {
            var client_tb = db.bon_liv.Where(x => x.status == 3)
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

          }

            ).Distinct().ToList();
            dataGridView1.DataSource = client_tb;
            //dataGridView1.DataSource = db.bon_liv.ToList();
            lb_count.Text = client_tb.Count().ToString();
            load_encass = 3;
        }
        public void load_bon_liv2()
        {
            // db.bon_liv.Load();
            var client_tb = db.bon_liv.Where(x => x.status == 1 || x.status == 2 || x.status == 6 || x.status == 4)
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

          }

            ).Distinct().ToList();
            dataGridView1.DataSource = client_tb;
            //dataGridView1.DataSource = db.bon_liv.ToList();
            load_encass = 2;
            lb_count.Text = client_tb.Count().ToString();
        }
        public void load_bon_liv1()
        {
            // db.bon_liv.Load();
            var client_tb = db.bon_liv.Where(x => x.status != 4)
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

          }

            ).Distinct().ToList();
            dataGridView1.DataSource = client_tb;
            //dataGridView1.DataSource = db.bon_liv.ToList();
            lb_count.Text = client_tb.Count().ToString();
        }

        private void orderListFrm1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            EncaissementFrm frm = new EncaissementFrm(id);
            frm.ShowDialog();
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            Local_DB.bon_liv bon_Liv = new Local_DB.bon_liv();
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            bon_Liv = db.bon_liv.Where(b => b.num_BonLiv == id).FirstOrDefault();

            if (bon_Liv.status == 0)
            {
                modifierToolStripMenuItem.Enabled = true;
                suprimerToolStripMenuItem.Enabled = true;
            }
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
            load_bon_liv1();
        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int client = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value);
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            addUpOrder frm = new addUpOrder(client, id);
            frm.ShowDialog();
        }

        private void VoirDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Local_DB.bon_liv bon_Liv = new Local_DB.bon_liv();
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            comDetailForm frm = new comDetailForm(id);
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client_part.client frm = new client_part.client();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (load_encass == 2)
            {
                load_bon_liv3();
                lb_title.Text = "Les nouvous commandes";
                toolStripMenuItem1.Enabled = false;
                toolStripMenuItem2.Enabled = true;
            }
            else
            {
                load_bon_liv2();
                lb_title.Text = "La liste des commandes";
                toolStripMenuItem1.Enabled = true;
                toolStripMenuItem2.Enabled = false;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                EncaissDetailForm frm = new EncaissDetailForm(id);
                frm.ShowDialog();
            }
        }
    }
}

