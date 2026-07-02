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
    public partial class AddUpVeh : Form
    {
        int vih_id = -1;
        int trac_cit = 1;
        Local_DB.naftall1Entities1 db = new Local_DB.naftall1Entities1();
        Local_DB.vehicule vehicule_tb = new Local_DB.vehicule();
        public AddUpVeh(int _vih_id)
        {
            InitializeComponent();
            vih_id = _vih_id;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_trac.Checked)
            {
                trac_cit = 1;
            }
            else
            {
                trac_cit = 2;
            }
        }

        private void rb_oui_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_oui.Checked)
            {
                dataGridView1.Visible = true;
                label1.Visible = true;
                lb_trnsplabel.Visible = true;
                lb_trnsprt.Visible = true;
                load_trans();
            }
            else
            {
                dataGridView1.Visible = false;
                label1.Visible = false;
                lb_trnsplabel.Visible = false;
                lb_trnsprt.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (vih_id == -1) 
            { 
                vehicule_tb.matricule = textBox1.Text;
                vehicule_tb.privee = Convert.ToByte(label1.Visible ? 1 : 0);
                vehicule_tb.type_vih = Convert.ToByte(trac_cit);
                if (label1.Visible)
                {
                    vehicule_tb.transporteur = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value); 
                }
                db.vehicule.Add(vehicule_tb);
                db.SaveChanges();
                MessageBox.Show("Une nouvou vehicule est ajoutee");
            }
        }

        private void AddUpVeh_Activated(object sender, EventArgs e)
        {
            if (lb_trnsplabel.Visible)
            {
                var tb = db.transporteur.ToList();
                dataGridView1.DataSource = tb;
            }
        }
        private void load_trans()
        {
            if (lb_trnsplabel.Visible)
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
                dataGridView1.DataSource = tb.ToList();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                lb_trnsprt.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() +"   " + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

            }
        }
    }
}
