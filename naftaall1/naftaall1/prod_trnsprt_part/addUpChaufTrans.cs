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
    public partial class addUpChauf : Form
    {
        int chauf_id = -1;
        int trans_privee;
        Local_DB.naftall1Entities1 db = new Local_DB.naftall1Entities1();
        Local_DB.chaufeur chauf_tb = new Local_DB.chaufeur();
        public addUpChauf(int _chauf_id)
        {
            InitializeComponent();
            chauf_id = _chauf_id;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void rb_oui_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_oui.Checked)
            {
                dataGridView1.Visible = true;
                label1.Visible = true;
                lb_trnsplabel.Visible = true;
                lb_trnsprt.Visible = true;
                trans_privee = 1;
                load_trans();
            }
            else
            {
                dataGridView1.Visible = false;
                label1.Visible = false;
                lb_trnsplabel.Visible = false;
                lb_trnsprt.Visible = false;
                trans_privee = 0;
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (chauf_id == -1)
            {
                chauf_tb.person = addUpPersControl1.add_person();
                chauf_tb.permis = textBox1.Text;
                chauf_tb.permis_debut = dateTimePicker1.Value;
                if (label1.Visible)
                {
                    chauf_tb.transporteur = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                }
                db.chaufeur.Add(chauf_tb);
                db.SaveChanges();
                MessageBox.Show("Un nouvoux Chaufeur est ajoutee");
            }
        }

        private void addUpChauf_Activated(object sender, EventArgs e)
        {

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
                lb_trnsprt.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "   " + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

            }
        }
    }
}
