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
    public partial class listOfTansprtFrm : Form
    {
        int tb; // 1 => transporter, 2 => chaufeur, 3 =>  vehicule
        Local_DB.naftall1Entities1 db = new Local_DB.naftall1Entities1();
        Local_DB.chaufeur chauf_tb = new Local_DB.chaufeur();
        Local_DB.transporteur transporteur = new Local_DB.transporteur();
        Local_DB.vehicule vehicule = new Local_DB.vehicule();
        public listOfTansprtFrm(int _tb)
        {
            InitializeComponent();
            tb = _tb;
            load_data(_tb);
            load_transt();
        }
        private void load_data(int _tb)
        {
            if (_tb == 1)
            {
                load_chauf(0);
                rb_cit.Visible = false;
                rb_trac.Visible = false;
                pictureBox_cit.Visible = false;
                lb_title.Text = "La liste des chauffeurs ";
            } else
            if (_tb == 2)
            {
                load_veh(0);
                
                pictureBox_ch.Visible = false;
                lb_title.Text = "La liste des vehicules ";
            }
        }

        private void load_chauf_by_trans(int transp_id)
        {
            var tb_ch = db.chaufeur.Where(x => x.transporteur == transp_id).Join(db.person,
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
            if (tb_ch.Count > 0)
            {
                dataGridView1.DataSource = tb_ch;
            }else
            {
                dataGridView1.DataSource = tb_ch;
            }
        }
        private void load_vih_by_trans(int transp_id)
        {
            var tb_v = db.vehicule.Where(x => x.transporteur == transp_id).Join(db.transporteur,
                ch => ch.transporteur,
                p => p.id,
                (ch, p) => new
                {
                    ch.veh_num,
                    ch.matricule,
                    ch.disponible,
                    ch.type_vih,
                }

                ).ToList();

                dataGridView1.DataSource = tb_v;
            
        }
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
            dataGridViewTransp.DataSource = tb.ToList();
        }

        private void load_chauf(int privee)
        {
            var tb_transp = db.transporteur.Join(db.person,
                   t => t.person,
                   p => p.id,
                   (t, p) => new
                   {
                       tranpter = t,
                       person_tr = p,
                   }
                ).ToList();

            var tb2 = db.chaufeur.Join(db.person,
                v => v.person,
                p => p.id,
                (v, p) => new
                {

                    chauf = v, person_ch = p
                }

                ).ToList();

            if (privee == 1)
            {
                var tb_ch = tb2.Join(tb_transp,
                    ch => ch.chauf.transporteur,
                    tr => tr.tranpter.id,
                    (ch, tr) => new
                    {
                        ch.chauf.chauf_num,
                        ch.person_ch.nom,
                        ch.person_ch.adresse,
                        ch.person_ch.Tel,
                        ch.chauf.permis,
                        ch.chauf.permis_debut,
                        ch.chauf.disponible,
                        tr.tranpter.id,
                        trnsprtr_nom = tr.person_tr.nom,
                        trnsprtr_tel = tr.person_tr.Tel,

                    }
                    ).ToList();
                dataGridView1.DataSource = tb_ch;
            } else if (privee == 0)
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

                    dataGridView1.DataSource = tb_ch;

                lb_count.Text = tb_ch.Count.ToString();

            }

            
        }

        private void load_veh(int privee)
        {
            var tb = db.transporteur.Join(db.person,
                   t => t.person,
                   p => p.id,
                   (t, p) => new
                   {
                       tranpter = t,
                       p = p,
                   }
                ).ToList();


            if (privee == 1)
            {
                //dataGridView1.DataSource = tb2.ToList();
            }else if (privee == 0)
            {
                var veh_tb = db.vehicule.Where(x => x.disponible == 1).
                    Select(x => new { x.veh_num, x.matricule, x.disponible, x.type_vih }).ToList();
                dataGridView1.DataSource = veh_tb;

                lb_count.Text = veh_tb.Count.ToString();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;
            if (radioButton3.Checked)
            {
                dataGridViewTransp.Visible = false;
                load_data(tb);
            }
            else
            if (radioButton4.Checked)
            {
                dataGridViewTransp.Visible = true;
                dataGridView1.Enabled = true;
                
            }
        }

        private void dataGridViewTransp_SelectionChanged(object sender, EventArgs e)
        {
            int trans_id = -1;
            if (dataGridViewTransp.SelectedRows.Count >= 1)
            {
                 trans_id = Convert.ToInt32(dataGridViewTransp.SelectedRows[0].Cells[0].Value);
            }
            
            if (tb == 1)
            {
                load_chauf_by_trans(trans_id);
            }else if (tb == 2)
            {
                load_vih_by_trans(trans_id);
            }
        }

        private void listOfTansprtFrm_Load(object sender, EventArgs e)
        {

        }
    }


}
