using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace naftaall1.prod_trnsprt_part
{
    public partial class AddBon_Enlev2Frm : Form
    {
        Local_DB.naftall1Entities1 db = new Local_DB.naftall1Entities1();
        Local_DB.chaufeur chauf_tb = new Local_DB.chaufeur();
        Local_DB.transporteur transporteur = new Local_DB.transporteur();

        Local_DB.vehicule vih = new Local_DB.vehicule();

        int chuf_id;
        int trans_id;
        int tract_id;
        int citern_id;
        int typ_vih = 1;
      
        private List<int> Bon_livs;


        private void load_transt()
        {
            var tb = db.transporteur.Join(db.person,
                     t => t.person,
                     p => p.id,
                     (t, p) => new
                     {
                         t.id,
                         p.nom,
                         p.adresse,
                         p.Tel,
                     }
            ).ToList();
            TransprtDataGrid.DataSource = tb.ToList();
        }
        private void load_chauf()
        {
            var tb_ch = db.chaufeur.Join(db.person,
                ch => ch.person,
                p => p.id,
                (ch, p) => new
                {
                    ch.chauf_num,
                    p.nom,
                    p.adresse,
                    p.Tel,
                    ch.permis,
                    ch.permis_debut,
                    ch.disponible,
                }

                ).ToList();

            ChaufeurDataGrid.DataSource = tb_ch;

        }

        private void load_veh()
        {
             var veh_tb = db.vehicule.Where(x => x.type_vih == 1).
                Select(x => new { x.veh_num, x.matricule, x.disponible, x.type_vih }).ToList();
             VihDataGrid.DataSource = veh_tb;
            
        }
        public AddBon_Enlev2Frm(int trans_mod, List<int> bon_livs)
        {
            InitializeComponent();
            load_transt();
            if (trans_mod == 1)
            {
                load_chauf();
                load_veh();
                pictureBox3.Visible = false;
                lb_transprt.Visible = false;
                lb_trans.Visible = false;
                textBox2.Visible = false;
                label13.Visible = false;
            }

            Bon_livs = bon_livs;

        }

        private void TransprtDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (TransprtDataGrid.SelectedRows.Count > 0) 
            {
                int trans_id = Convert.ToInt32(TransprtDataGrid.Rows[0].Cells[0].Value);
                load_chauf_by(trans_id);
                load_veh_by(trans_id);
            }  
        }

        private void load_chauf_by(int trans_id)
        {
            var tb_ch = db.chaufeur.Where(x => x.transporteur == trans_id).Join(db.person,
                ch => ch.person,
                p => p.id,
                (ch, p) => new
                {
                    ch.chauf_num,
                    p.nom,
                    p.adresse,
                    p.Tel,
                    ch.permis,
                    ch.permis_debut,
                    ch.disponible,
                }

                ).ToList();

            ChaufeurDataGrid.DataSource = tb_ch;

        }

        private void load_veh_by(int trans_id)
        {

            var veh_tb = db.vehicule.Where(x => x.transporteur == trans_id && x.type_vih == typ_vih).
               Select(x => new { x.veh_num, x.matricule, x.disponible, x.type_vih }).ToList();
            VihDataGrid.DataSource = veh_tb;

        }

        private void ChaufeurDataGrid_SelectionChanged(object sender, EventArgs e)
        {


            if (ChaufeurDataGrid.SelectedRows.Count == 1)
            {
              lb_chaufeur.Text = ChaufeurDataGrid.SelectedRows[0].Cells[0].Value + " | " + ChaufeurDataGrid.SelectedRows[0].Cells[1].Value;
                chuf_id = Convert.ToInt32(ChaufeurDataGrid.SelectedRows[0].Cells[0].Value);
             }
        }

        private void VihDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (VihDataGrid.SelectedRows.Count == 1)
            {
       
                if (typ_vih == 1)
                {
                    tract_id = Convert.ToInt32(VihDataGrid.SelectedRows[0].Cells[0].Value);
                    lb_tracteur.Text = VihDataGrid.SelectedRows[0].Cells[0].Value + " | " + VihDataGrid.SelectedRows[0].Cells[1].Value;
                }
                else
                {
                    citern_id = Convert.ToInt32(VihDataGrid.SelectedRows[0].Cells[0].Value);
                    lb_citerne.Text = VihDataGrid.SelectedRows[0].Cells[0].Value + " | " + VihDataGrid.SelectedRows[0].Cells[1].Value;
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            lb_programme.Text = dateTimePicker1.Value.ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lb_chaufeur.Text.Length > 0 && lb_citerne.Text.Length > 0 && lb_programme.Text.Length > 0 
                && lb_tracteur.Text.Length > 0)
            {

                Local_DB.bon_enlev bon_enlev_tb = new Local_DB.bon_enlev();

                bon_enlev_tb.programme = dateTimePicker1.Value;
                bon_enlev_tb.chaufeur = chuf_id;
                bon_enlev_tb.tracteur = tract_id;
                bon_enlev_tb.citerne = citern_id;

                if (TransprtDataGrid.Visible == false) 
                {
                    bon_enlev_tb.mode = 1;
                }
                else
                {
                    bon_enlev_tb.mode = 2;
                }
                db.bon_enlev.Add(bon_enlev_tb);
                db.SaveChanges();
                int p = bon_enlev_tb.id;
                int cnteur = CiterneDataGrid.RowCount;

                foreach (DataGridViewRow prod in CiterneDataGrid.Rows)
                {
                    Local_DB.la_charge charge = new Local_DB.la_charge();
                    cnteur--;

                    //if (prod.Index != cnteur && CiterneDataGrid.RowCount != 1)
                    //{

                        charge.rotation = p;
                        charge.produit = Convert.ToInt32(prod.Cells[1].Value);
                        charge.cmp = Convert.ToByte(cnteur);

                        charge.qnt = Convert.ToInt32(prod.Cells[3].Value);
                        db.la_charge.Add(charge);
                        db.SaveChanges();
;
                    //}

                    foreach (int id in Bon_livs)
                    {
                        Local_DB.bon_liv bon_liv = new Local_DB.bon_liv();
                        bon_liv = db.bon_liv.Where(x => x.num_BonLiv == id).FirstOrDefault();
                        bon_liv.bon_enlev = p;
                        bon_liv.status = 6;
                        bon_liv.date_liv = DateTime.Now;
                        db.Entry(bon_liv);
                        db.SaveChanges();
                    }
                    MessageBox.Show("La Bon d' enlevement est etablir");

                }

            }
            else
            {
                MessageBox.Show("La commande est error");
            }

        }

        private void rb_trac_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_trac.Checked)
            {
                typ_vih = 1;
            }else
            {
                typ_vih = 2;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Bon_livs.Count == 1)
            {
                int id = Bon_livs.First();
                Local_DB.bon_liv bon_liv = new Local_DB.bon_liv();
                bon_liv = db.bon_liv.Where(x => x.num_BonLiv == id).FirstOrDefault();

                MessageBox.Show("La commande est enregistre" + id.ToString());
            }
            foreach (int id in Bon_livs)
            {
                Local_DB.bon_liv bon_liv = new Local_DB.bon_liv();
                bon_liv = db.bon_liv.Where(x => x.num_BonLiv == id).FirstOrDefault();

                MessageBox.Show("La commande est enregistre" + id.ToString());
            }
        }
    }
}
