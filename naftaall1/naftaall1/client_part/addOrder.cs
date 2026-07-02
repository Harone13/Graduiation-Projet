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

namespace naftaall1.client_part
{
    public partial class addUpOrder : Form
    {
        Local_DB.naftall1Entities1 db = new Local_DB.naftall1Entities1();
        Local_DB.produit Produit = new Local_DB.produit();
        int prod_id = 1;
        int up_row_DtGridv2 = -1;
        int client_id;
        public addUpOrder(int _client_id, int add_up)
        {
            InitializeComponent();
            load_prods();

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            dataGridView2.CellPainting += new DataGridViewCellPaintingEventHandler(myDataGridView_CellPainting);
            client_id = _client_id;
            var person_id = db.client.Where(x => x.id == client_id).Select(p => p.person_id).FirstOrDefault().Value;
            personInfos1.get_person(person_id);
            if (add_up != -1)
            {
                load_comm(add_up);
                lb_title.Text = "Modifier la commande N°" + add_up.ToString();
            }
        }
        public void load_prods()
        {
            db.produit.LoadAsync().Wait();
            var tb = db.produit.Select(x => new { x.code, x.designation, x.prixu_unit }).ToList();
            dataGridView1.DataSource = tb;
            lb_count.Text = db.produit.Count().ToString();
        }
        public  async void load_comm(int num_bon)
        {
            var commds = await db.commandes.Where(x => x.bon_liv == num_bon).ToListAsync();
            foreach (var comm in commds)
            {
                Produit = db.produit.Where(x => x.code == comm.produit).FirstOrDefault();
                dataGridView2.Rows.Add(Produit.code.ToString(), Produit.designation, comm.prod_qnt.ToString());
                lb_count2.Text = (dataGridView2.RowCount - 1).ToString();
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                prod_id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                prodInfos1.get_prod(prod_id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Produit = db.produit.Where(x => x.code == prod_id).FirstOrDefault();
            bool prod_exist = false;
            bool Qnt_minP = false; bool Qnt_maxP = true;// now is existe and Qnt test
            int baki = Convert.ToInt32(numericUpDown1.Value) % 70;
            int CMP = 5 - dataGridView2.Rows.Count;
            int devide = Convert.ToInt32(numericUpDown1.Value) / 70;
            int d = Convert.ToInt32(numericUpDown1.Value);

            foreach (DataGridViewRow prod in dataGridView2.Rows)
            {
                if (Produit.code == Convert.ToInt32(prod.Cells[0].Value))
                {
                    prod_exist = true;
                }

                 d += Convert.ToInt32(prod.Cells[2].Value);
            }
            
            if (d > 280)
            { Qnt_maxP = true;
                MessageBox.Show("Problem Qnt > max !!!");
            }
            else
            if (baki < 50 && baki != 0) { Qnt_minP = true; MessageBox.Show("Problem Qnt CMP peut a 70 hL!"); ; }
            else
            if (!prod_exist)
            {
                dataGridView2.Rows.Add(Produit.code.ToString(), Produit.designation, numericUpDown1.Value.ToString());
                lb_count2.Text = (dataGridView2.RowCount - 1).ToString();
            }
            else
            {
                MessageBox.Show("Ce produit est dejat ajoute");
            }
        }


        private void myDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.ColumnIndex == dataGridView2.Columns["update"].Index && e.RowIndex >= 0)
            {
                // Get the row
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                // Check if the row is empty
                bool isEmptyRow = true;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value != DBNull.Value && !string.IsNullOrEmpty(cell.Value.ToString()))
                    {
                        isEmptyRow = false;
                        break;
                    }
                }

                // Hide the button if the row is empty
                if (isEmptyRow)
                {
                    row.Cells["update"].Style.ForeColor = Color.Transparent;
                    row.Cells["update"].Style.SelectionForeColor = Color.Transparent;
                }
                else
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    // Customize the button style
                    DataGridViewButtonCell buttonCell = (DataGridViewButtonCell)dataGridView2.Rows[e.RowIndex].Cells["update"];
                    buttonCell.FlatStyle = FlatStyle.Popup;

                    Rectangle buttonRect = e.CellBounds;
                    buttonRect.Inflate(-2, -2);

                    using (Brush brush = new SolidBrush(Color.Blue))
                    {
                        e.Graphics.FillRectangle(brush, buttonRect);
                    }

                    TextRenderer.DrawText(e.Graphics, "Modifier", dataGridView2.Font, buttonRect, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                    e.Handled = true;

                }
            }
            if (e.ColumnIndex == dataGridView2.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                // Get the row
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                // Check if the row is empty
                bool isEmptyRow = true;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value != DBNull.Value && !string.IsNullOrEmpty(cell.Value.ToString()))
                    {
                        isEmptyRow = false;
                        break;
                    }
                }

                // Hide the button if the row is empty
                if (isEmptyRow)
                {
                    row.Cells["Delete"].Style.ForeColor = Color.Transparent;
                    row.Cells["Delete"].Style.SelectionForeColor = Color.Transparent;
                }
                else
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    // Customize the button style
                    DataGridViewButtonCell buttonCell = (DataGridViewButtonCell)dataGridView2.Rows[e.RowIndex].Cells["Delete"];
                    buttonCell.FlatStyle = FlatStyle.Popup;

                    Rectangle buttonRect = e.CellBounds;
                    buttonRect.Inflate(-2, -2);

                    using (Brush brush = new SolidBrush(Color.Red))
                    {
                        e.Graphics.FillRectangle(brush, buttonRect);
                    }

                    TextRenderer.DrawText(e.Graphics, "Delete", dataGridView2.Font, buttonRect, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                    e.Handled = true;

                }
            }

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.RowCount > 1)
            {
                if (e.ColumnIndex == dataGridView2.Columns["Delete"].Index && e.RowIndex >= 0)
                {
                    // Get the clicked row
                    DataGridViewRow clickedRow = dataGridView2.Rows[e.RowIndex];

                    // Perform your desired actions
                    int rowId = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value);//(int)clickedRow.Cells["code"].Value; // Example: Get the ID of the row
                    //MessageBox.Show("le produit commande : " + dataGridView2.Rows[rowId].Cells[1].Value + "est suprime");

                    // Example: Delete the row
                    dataGridView2.Rows.RemoveAt(e.RowIndex);

                }
                else
                if (e.ColumnIndex == dataGridView2.Columns["update"].Index && e.RowIndex >= 0)
                {
                    // Get the clicked row
                    DataGridViewRow clickedRow = dataGridView2.Rows[e.RowIndex];

                    // Perform your desired actions
                    int prodId = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value);//(int)clickedRow.Cells["code"].Value; // Example: Get the ID of the row
                    

                    prod_id = prodId;
                    prodInfos1.get_prod(prod_id);

                    up_row_DtGridv2 = clickedRow.Index;
                    button3.Enabled = true;
                    button1.Enabled = false;
                    //MessageBox.Show("Update button clicked for row with ID: " + up_row_DtGridv2);
                    // Example: Delete the row
                    //dataGridView2.Rows.RemoveAt(e.RowIndex);

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (up_row_DtGridv2 != -1)
            {
                dataGridView2.Rows[up_row_DtGridv2].Cells[2].Value = numericUpDown1.Value.ToString();
                MessageBox.Show("le produit commande : " + dataGridView2.Rows[up_row_DtGridv2].Cells[1].Value + "est modfie");
                button3.Enabled = false;
                button1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Local_DB.commandes commandes = new Local_DB.commandes();
            Local_DB.bon_liv bon_Liv_tb = new Local_DB.bon_liv();
            bon_Liv_tb.date_ajout = DateTime.Now;
            db.bon_liv.Add(bon_Liv_tb);
            db.SaveChanges();
            decimal? p = 0;
            foreach (DataGridViewRow prod in dataGridView2.Rows)
            {
                int cnteur = dataGridView2.RowCount;
                cnteur--;

                if (prod.Index != cnteur && dataGridView2.RowCount != 1)
                {         
                   
                    commandes.client = client_id;
                    commandes.produit = Convert.ToInt32(prod.Cells[0].Value);

                    var pr = db.produit.Where(x => x.code == commandes.produit).FirstOrDefault();
                    commandes.bon_liv = bon_Liv_tb.num_BonLiv;
                    commandes.prod_qnt = Convert.ToInt32(prod.Cells[2].Value);
                    commandes.montant_ligne = commandes.prod_qnt * pr.prixu_unit;
                    p += commandes.montant_ligne;
                    db.commandes.Add(commandes);
                    db.SaveChanges();
                    MessageBox.Show("La commande est enregistre" + commandes.bon_liv.ToString() + commandes.produit);
                }


            }

            bon_Liv_tb.montant_total = p;
            db.Entry(bon_Liv_tb).State = EntityState.Modified;
            db.SaveChanges();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }    
}
