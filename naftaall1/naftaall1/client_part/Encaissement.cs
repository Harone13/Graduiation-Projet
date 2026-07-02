using naftaall1.Local_DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace naftaall1.client_part
{

    public partial class EncaissementFrm : Form
    {
        Local_DB.naftall1Entities1 db = new Local_DB.naftall1Entities1();
        Local_DB.bon_liv Encaissement = new Local_DB.bon_liv();
        List<commandes> Comandes = new List<commandes>();
        int num_bon;
        DateTime Date_payment;
        int payement;

        public EncaissementFrm(int _num_bon_liv)
        {
            InitializeComponent();
            num_bon = _num_bon_liv;
            load_prod_commande();
            
            lb_num_bon_liv.Text = num_bon.ToString();

            //var client = db.client.Where(x => x.id == );
        }
        public async void load_prod_commande()
        {
            var client_tb = await db.bon_liv.Where(x => x.num_BonLiv == num_bon)
            .Join(db.commandes,
               b => b.num_BonLiv,
               c => c.bon_liv,
              (b, c) => new
              {
                  BonLiv = b,
                  Commande = c
              }
             )
                 .Join(db.produit,
                      C => C.Commande.produit,
                      p => p.code,
                   (C, p) => new
                   {
                       p.code,
                       p.designation,
                       C.Commande.prod_qnt,
                       montant_ligniaire =  C.Commande.prod_qnt * p.prixu_unit,
                   }

             ).Distinct().ToListAsync();
            var per = db.commandes.Where(x => x.bon_liv == num_bon).FirstOrDefault();
            var cl = db.client.Where(x => x.id == per.client).FirstOrDefault();
            var person = db.person.Where(x => x.id == cl.person_id).FirstOrDefault();
            dataGridView2.DataSource = client_tb;
            personInfos1.get_person(person.id);

            var bon_tb = db.bon_liv.Where(v => v.num_BonLiv == num_bon).FirstOrDefault();
            lb_montant.Text = bon_tb.montant_total.ToString();
            lb_tva.Text = (bon_tb.montant_total * 19 / 100).ToString();
            Comandes = await db.commandes.Where(x => x.bon_liv == num_bon).ToListAsync();
            var qnt = Comandes.FirstOrDefault().prod_qnt;
            qnt = 0;
            foreach ( var item in Comandes)
            {
                qnt += item.prod_qnt;
            }
            var ttc = 0;
            if (qnt /4 > 3)
            {
                lb_ttc.Text = "1000";
                ttc = 1000;
            }
            lb_total.Text = ((bon_tb.montant_total * 19 / 100) + ttc + bon_tb.montant_total).ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Date_payment = DateTime.Now;
                payement = 1;
            }
            else if (radioButton2.Checked)
            {
                Date_payment = DateTime.Now.AddDays(45);
                payement = 2;
            }
            lb_date.Text = Date_payment.ToString();

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Date_payment = DateTime.Now;
                payement = 1;
            }
            else if (radioButton2.Checked)
            {
                Date_payment = DateTime.Now.AddDays(45);
                payement = 2;
            }
            lb_date.Text = Date_payment.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

                lb_date.Text = Date_payment.ToString();
                Encaissement = db.bon_liv.Where(x => x.num_BonLiv == num_bon).FirstOrDefault();
                Encaissement.payment_mode = Convert.ToByte(payement);
                Encaissement.date_Payement = Date_payment;
            if (tb_piece.Text.Length > 0)
            {
                Encaissement.num_piece = Convert.ToInt32(tb_piece.Text);
            }
                if (radioButton1.Checked == true)
                {
                    Encaissement.status = 1;
                }else
                {
                    Encaissement.status = 2;
                }
            var result = MessageBox.Show("comfirmer la Validation cette commande", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                db.Entry(Encaissement).State = EntityState.Modified;
                db.SaveChanges();
                this.Close();
            }

            

        }
    }
}
