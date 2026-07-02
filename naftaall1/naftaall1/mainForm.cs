using naftaall1.client_part;
using naftaall1.prod_trnsprt_part;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace naftaall1
{
    public partial class mainForm : Form
    {
        int user_id;
        Local_DB.naftall1Entities1 db = new Local_DB.naftall1Entities1();
        Local_DB.utilisateur user = new Local_DB.utilisateur();
        Local_DB.person person = new Local_DB.person();
        public mainForm(int _user_id)
        {
            InitializeComponent();
            user_id = _user_id;
            user = db.utilisateur.Where(u => u.id == user_id).FirstOrDefault();
            if (user.role == 2)
            {
                facturationToolStripMenuItem.Enabled = false;
                laCaisseToolStripMenuItem.Enabled = false;
                dispacherToolStripMenuItem.Enabled = false;
                transportToolStripMenuItem.Enabled = false;
                utilisateursToolStripMenuItem.Enabled = false;
            }
            else if (user.role == 3)
            {
                receptionToolStripMenuItem.Enabled = false;
                laCaisseToolStripMenuItem.Enabled = false;
                dispacherToolStripMenuItem.Enabled = false;
                transportToolStripMenuItem.Enabled = false;
                utilisateursToolStripMenuItem.Enabled = false;
            }else if (user.role == 5)
            {
                facturationToolStripMenuItem.Enabled = false;
                laCaisseToolStripMenuItem.Enabled = false;
                receptionToolStripMenuItem.Enabled = false;
                utilisateursToolStripMenuItem.Enabled = false;
            }else if(user.role == 4)
            {
                facturationToolStripMenuItem.Enabled = false;
                receptionToolStripMenuItem.Enabled = false;
                dispacherToolStripMenuItem.Enabled = false;
                transportToolStripMenuItem.Enabled = false;
                utilisateursToolStripMenuItem.Enabled = false;
            }
        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            client_part.client frm = new client_part.client();
            frm.ShowDialog();
        }

        private void toutsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void produitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prod_trnsprt_part.produitForm frm = new prod_trnsprt_part.produitForm();
            frm.ShowDialog();
        }

        private void commandeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orderListFrm1 frm = new orderListFrm1(0);
            frm.ShowDialog();
        }

        private void livraisonToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void creerNouvousBonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prod_trnsprt_part.AddBon_EnlevFrm frm = new prod_trnsprt_part.AddBon_EnlevFrm();
            frm.ShowDialog();
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addUpChauf frm = new addUpChauf(-1);
            frm.ShowDialog();
        }

        private void ajouterToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            addUpTransprter frm = new addUpTransprter(-1);
            frm.ShowDialog();
        }

        private void ajouterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddUpVeh frm = new AddUpVeh(-1);
            frm.ShowDialog();
        }

        private void toutsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            listOfTansprtFrm frm = new listOfTansprtFrm(1);
            frm.label1.Text = "La liste des Chaufeurs";
            frm.ShowDialog();
        }

        private void toutsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            listOfTransporters frm = new listOfTransporters();
            frm.ShowDialog();
        }

        private void toutsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listOfTansprtFrm frm = new listOfTansprtFrm(2);
            frm.label1.Text = "La liste des Vehicules";
            frm.ShowDialog();
        }

        private void tToolStripMenuItem_Click(object sender, EventArgs e)
        {
            system_mngmt_part.addUpUserForm frm = new system_mngmt_part.addUpUserForm(-1);
            frm.ShowDialog();
        }

        private void facturationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orderListFrm frm = new orderListFrm();
            frm.ShowDialog();
        }

        private void laCaisseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orderListFrm1 frm = new orderListFrm1(1);
            frm.ShowDialog();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
