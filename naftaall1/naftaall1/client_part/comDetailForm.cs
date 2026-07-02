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

    public partial class comDetailForm : Form
    {
        Local_DB.naftall1Entities1 db = new Local_DB.naftall1Entities1();
        Local_DB.bon_liv bon_Liv = new Local_DB.bon_liv();
        Local_DB.client cl = new Local_DB.client();
        Local_DB.commandes com = new Local_DB.commandes();

        List<commandes> Comandes = new List<commandes>();

        public comDetailForm(int _bon_liv)
        {
            InitializeComponent();
            lb_num_bon_liv.Text = _bon_liv.ToString();
            load_prod_commande(_bon_liv);

            
        }

        public async void load_prod_commande(int _num_bon)
        {
            var client_tb = await db.bon_liv.Where(x => x.num_BonLiv == _num_bon)
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
                       montant_ligniaire = C.Commande.prod_qnt * p.prixu_unit,
                   }

             ).Distinct().ToListAsync();
            var per = db.commandes.Where(x => x.bon_liv == _num_bon).FirstOrDefault();
            var cl = db.client.Where(x => x.id == per.client).FirstOrDefault();
            var person = db.person.Where(x => x.id == cl.person_id).FirstOrDefault();
            dataGridView2.DataSource = client_tb;
            personInfos1.get_person(person.id);

            var bon_tb = db.bon_liv.Where(v => v.num_BonLiv == _num_bon).FirstOrDefault();
            lb_montant.Text = bon_tb.montant_total.ToString();
            lb_tva.Text = (bon_tb.montant_total * 19 / 100).ToString();
            Comandes = await db.commandes.Where(x => x.bon_liv == _num_bon).ToListAsync();
            var qnt = Comandes.FirstOrDefault().prod_qnt;
            qnt = 0;
            foreach (var item in Comandes)
            {
                qnt += item.prod_qnt;
            }
            var ttc = 0;
            if (qnt / 4 > 3)
            {
                lb_ttc.Text = "1000";
                ttc = 1000;
            }
            lb_total.Text = ((bon_tb.montant_total * 19 / 100) + ttc + bon_tb.montant_total).ToString();

            if (bon_tb.status == 4 || bon_tb.status == 6)
            {
                bon_Liv = bon_tb;
                load_bon_enlev();
            }
        }
       public async void load_bon_enlev()
        {


            var bon_Enlev = db.bon_enlev.Where(x => x.id == bon_Liv.bon_enlev).FirstOrDefault();
            lb_date.Text = (bon_Enlev.programme.ToShortDateString()).ToString() ?? "------";
            lb_mode_liv.Text = $"mode{bon_Enlev.mode.ToString()}" ?? "------";

            var tr = db.vehicule.Where(x => x.veh_num == bon_Enlev.tracteur).FirstOrDefault();
            lb_tract.Text = tr.veh_num.ToString() + "  " + tr.matricule.ToString() ?? "------";

            var v = db.vehicule.Where(x => x.veh_num == bon_Enlev.citerne).FirstOrDefault();
            lb_veh.Text = v.veh_num.ToString() + "  " + v.matricule.ToString() ?? "------";

            var chauff = db.chaufeur.Where(x => x.chauf_num == bon_Enlev.chaufeur).FirstOrDefault();
            var conteur = db.chaufeur.Where(x => x.transporteur == chauff.transporteur).Count();
            if (conteur >= 1)
            {
                var trans = db.transporteur.Where(x => x.id == chauff.transporteur).FirstOrDefault();
                var person = db.person.Where(x => x.id == trans.person).FirstOrDefault();
                lb_trans.Text =  (trans.id.ToString() + person.nom.ToString ()) ?? "------";
                lb_transp.Text = (trans.id.ToString() + person.nom.ToString()) ?? "------";
            }
            else
            {
                var person = db.person.Where(x => x.id == chauff.person).FirstOrDefault();
                lb_trans.Text = (chauff.chauf_num.ToString() + person.nom.ToString()) ?? "------";
                lb_transp.Text = (chauff.chauf_num.ToString() + person.nom.ToString()) ?? "------";
            }
        }
    }
}
