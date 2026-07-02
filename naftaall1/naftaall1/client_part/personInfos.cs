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
    public partial class personInfos : UserControl
    {
        Local_DB.naftall1Entities1 db = new Local_DB.naftall1Entities1();
        Local_DB.person produit = new Local_DB.person();
        public personInfos()
        {
            InitializeComponent();
        }
        public void get_person(int _prod_id)
        {
            produit = db.person.Where(x => x.id == _prod_id).FirstOrDefault();
            lb_code.Text = _prod_id.ToString();
            if (produit.nom != null)
            {
                lb_design.Text = produit.nom;
            }
            if (produit.adresse != null)
            {
                lb_price.Text = produit.adresse.ToString();
            }
            if (produit.Tel != null)
            {
                lb_emp.Text = produit.Tel.ToString();
            }
        }
    }
}
