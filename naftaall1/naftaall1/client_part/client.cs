using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace naftaall1.client_part
{
    public partial class client : Form
    {
        Local_DB.naftall1Entities1 db1 = new Local_DB.naftall1Entities1();
        int rowCount;
        public client()
        {
            InitializeComponent();
            LoadData();
            label4.Text = rowCount.ToString();
        }
        private async void LoadData()
        {
            var client_tb = await db1.client
            .Join(db1.person,
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
            .ToListAsync();
            dataGridView2.DataSource = client_tb.ToList();

            rowCount = await db1.client
 .Join(db1.person,
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

            label4.Text = rowCount.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addUpClient addFrm = new addUpClient(0);
            addFrm.ShowDialog();

        }
        private void OpenDialogFormButton_Click(object sender, EventArgs e)
        {
            using (var dialogForm = new addUpClient(0))
            {
                dialogForm.FormClosed += DialogForm_FormClosed;
                dialogForm.ShowDialog();
            }
        }

        private void DialogForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadData(); // Refresh the DataGrid
        }

        private void editerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 1)
            { 
                int client_id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value);
                using (var dialogForm = new addUpClient(client_id))
                {
                    dialogForm.FormClosed += DialogForm_FormClosed;
                    dialogForm.ShowDialog();
                }
            }
        }

        private async void client_Activated(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 1)
            {
                int client_id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value);

                Local_DB.client client_tb = new Local_DB.client();
                client_tb = db1.client.Where(x => x.id == client_id).FirstOrDefault(); 

                var result = MessageBox.Show("comfirmer suprimmer cet ctient", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    var do_wile = 0;
                    while (do_wile == 0)
                    {
                        Local_DB.commandes c = new Local_DB.commandes();
                        var bol_test = db1.commandes.Where(b => b.client == client_id).Any();
                        if (bol_test)
                        {
                            c = db1.commandes.Where(b => b.client == client_id).FirstOrDefault();
                            db1.Entry(c).State = System.Data.Entity.EntityState.Deleted;
                            db1.SaveChanges();
                        }
                        else { do_wile = 1; }

                    }
                    db1.Entry(client_tb).State = System.Data.Entity.EntityState.Deleted;
                    db1.SaveChanges();
                }
                LoadData();
                /*MessageBox.Show("Le client avec le numero " + client_tb.id.ToString() + " est suprime ! ");
                LoadData();*/
            }
        }

        private void commanderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 1)
            {
                int client_id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value);
                addUpOrder frm = new addUpOrder(client_id, -1);
                frm.ShowDialog();
            }
        }

        private void client_Load(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
