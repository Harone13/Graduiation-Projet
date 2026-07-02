using naftaall1.Local_DB;
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
    public partial class AddBon_EnlevFrm : Form
    {
        Local_DB.naftall1Entities1 db = new Local_DB.naftall1Entities1();
        Local_DB.produit produit = new Local_DB.produit();
        Local_DB.commandes commandes = new Local_DB.commandes();
        Local_DB.bon_liv bon_Liv_tb = new Local_DB.bon_liv();
        List<int> Bon_liv_id = new List<int>();

        public AddBon_EnlevFrm()
        {
            InitializeComponent();
            load_bon_liv(1);
        }
        public async void load_bon_liv(int bon_stat)
        {
            dataGridView1.DataSource = await db.bon_liv.Where(x => x.status == 1 || x.status == 2).
                Select(x => new {x.num_BonLiv, x.date_ajout, x.date_Payement, x.payment_mode, x.status}).ToListAsync();
            lb_count1.Text = dataGridView1.RowCount.ToString();

            dataGridView1.Columns["status"].Visible = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["status"].Value != null)
                {
                    string status = row.Cells["status"].Value.ToString();
                    if (status == "1")
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    else if (status == "2")
                    {
                        row.DefaultCellStyle.BackColor = Color.Orange;
                    }

                }
            }
        }



        public void load_prods(int _num_bonLiv)
        {
            db.produit.LoadAsync().Wait();
            var tb = db.produit.Join(db.commandes.Where(x => x.bon_liv == _num_bonLiv), 
                p => p.code, c => c.produit,
                (p, c) => new 
                {
                p.code, p.designation, c.prod_qnt,// c.emb 
                }).ToList();
            dataGridView2.DataSource = tb;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 1)
            {
                int prod_id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                load_prods(prod_id);
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 1)
            {
                int prod_id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value);
                prodInfos1.get_prod(prod_id);
                lb_qnt.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            decimal? qnt_com = Convert.ToDecimal(lb_qnt.Text);
            string cmp = "1";
/*            if (dataGridView3.Rows.Count > 1)
            {
                int cc = Convert.ToInt32(dataGridView3.Rows.GetLastRow(DataGridViewElementStates.Displayed).ToString()) + 1;
                cmp = cc.ToString();
                
                 MessageBox.Show(dataGridView3.Rows.GetLastRow(DataGridViewElementStates.Displayed).ToString());

            }else*/
            if (dataGridView3.Rows.Count == 1)
            {
                int cc = 2;
                cmp = cc.ToString();


            }
            else if (dataGridView3.Rows.Count == 2)
            {
                int cc = 3;
                cmp = cc.ToString();


            }else
            if (dataGridView3.Rows.Count == 3)
            {
                int cc = 4;
                cmp = cc.ToString();


            }

            DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
            foreach (DataGridViewRow rr in dataGridView3.Rows)
            {
                if (rr.Cells[1].Value == selectedRow.Cells[0].Value)
                {
                    qnt_com -= Convert.ToDecimal(rr.Cells[3].Value);
                }
            }
            var Seventy = qnt_com / 70;
            var Baki = qnt_com % 70;

            DataGridViewRow newRow = new DataGridViewRow();

            newRow.CreateCells(dataGridView3);

            newRow.Cells[0].Value = cmp;
            for (int i = 0; i < selectedRow.Cells.Count; i++)
            {
                if (i != (selectedRow.Cells.Count -1))
                {
                    newRow.Cells[i + 1].Value = selectedRow.Cells[i].Value;
                }else
                {
                    if (Seventy >= 1) { newRow.Cells[3].Value = "70"; }
                    else { newRow.Cells[3].Value = Baki.ToString(); }
                }
            }
            int bon_liv_id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            var bon_liv = db.bon_liv.Where(x => x.num_BonLiv == bon_liv_id).FirstOrDefault();
            
                dataGridView3.Rows.Add(newRow);
            
            Bon_liv_id.Add(bon_liv_id);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                AddBon_Enlev2Frm frm = new AddBon_Enlev2Frm(1, Bon_liv_id);
                frm.TransprtDataGrid.Visible = false;
                frm.label1.Visible = false;
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    DataGridViewRow selectedRow = dataGridView3.Rows[i];
                    DataGridViewRow newRow = new DataGridViewRow();
                    newRow.CreateCells(dataGridView3);

                    for (int j = 0; j < selectedRow.Cells.Count; j++)
                    {
                        newRow.Cells[j].Value = selectedRow.Cells[j].Value;
                    }
                    frm.CiterneDataGrid.Rows.Add(newRow);
                }


                frm.ShowDialog();
            }
            else
            {
                AddBon_Enlev2Frm frm = new AddBon_Enlev2Frm(2, Bon_liv_id);
                frm.TransprtDataGrid.Visible = true;
                frm.label1.Visible = true;
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    DataGridViewRow selectedRow = dataGridView3.Rows[i];
                    DataGridViewRow newRow = new DataGridViewRow();
                    newRow.CreateCells(dataGridView3);

                    for (int j = 0; j < selectedRow.Cells.Count; j++)
                    {
                        newRow.Cells[j].Value = selectedRow.Cells[j].Value;
                    }
                    frm.CiterneDataGrid.Rows.Add(newRow);
                }


                frm.ShowDialog();
            }


        }
    }
}
