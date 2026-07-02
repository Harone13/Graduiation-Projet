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
    public partial class listOfTransporters : Form
    {
        Local_DB.naftall1Entities1 db = new Local_DB.naftall1Entities1();
        Local_DB.chaufeur chauf_tb = new Local_DB.chaufeur();
        Local_DB.transporteur transporteur = new Local_DB.transporteur();
        public listOfTransporters()
        {
            InitializeComponent();
            load_transt();
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
            dataGridView1.DataSource = tb.ToList();
            lb_count2.Text = tb.Count.ToString();
        }

    }
}
