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
    public partial class prodInfos : UserControl
    {
        Local_DB.naftall1Entities1 db = new Local_DB.naftall1Entities1();
        Local_DB.produit produit = new Local_DB.produit();
        public int Prod_id;
        public prodInfos()
        {
            InitializeComponent();
        }
        public void get_prod(int _prod_id)
        {
            produit = db.produit.Where(x => x.code == _prod_id).FirstOrDefault();
            lb_code.Text = _prod_id.ToString();
            if (produit.designation != null)
            {
                lb_design.Text = produit.designation;
            }
            if (produit.prixu_unit != 0)
            {
                lb_price.Text = produit.prixu_unit.ToString();
            }
            if (produit.qnt != null)
            {
                lb_qnt.Text = produit.qnt.ToString();
            }
        }
        public void clear_prod()
        {
            
            lb_code.Text = "------";
            lb_design.Text = "------";
            lb_price.Text = "------";
        }
    }
}
