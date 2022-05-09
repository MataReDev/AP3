using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AP3_FormaFlix
{
    public partial class FormChangeStatusCommentaire : Corner
    {
        string user;
        int numeroCommentaire;

        public FormChangeStatusCommentaire(string user, int numeroCommentaire)
        {
            InitializeComponent(); 
            roundedCorner();
            this.user = user;
            this.numeroCommentaire = numeroCommentaire;
        }
        private void FormChangeStatusCommentaire_Load(object sender, EventArgs e)
        {
            Controleur.initFormation();
            Controleur.VmodeleF.charger_CommentaireParNumero(numeroCommentaire);

            lblAuteur.Text = "";
            lbl_etat_comm.Text = "Non Validé";
            tbCommentaire.Clear();
            if (Controleur.VmodeleC.DT[10].Rows.Count == 0)
            {
                MessageBox.Show("Une erreur est survenue ! \nRetour à la liste des commentaires");
                btnListeComm_Click(sender, e);
            }
            else
            {
                lblAuteur.Text = Controleur.VmodeleC.DT[10].Rows[0][2].ToString() + " " + Controleur.VmodeleC.DT[10].Rows[0][3].ToString();
                if (Convert.ToInt32(Controleur.VmodeleC.DT[10].Rows[0][4]) == 2)
                {
                    lbl_etat_comm.Text = "Validé";
                }
                tbCommentaire.Text = Controleur.VmodeleC.DT[10].Rows[0][1].ToString();
            }
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            Hide();
            FormPrincipale FP = new FormPrincipale(user);
            FP.Closed += (s, args) => Close();
            FP.Show();
        }

        private void btnNePasValider_Click(object sender, EventArgs e)
        {
            //Modifier l'étét du commentaire pour le mettre à non validé ( = 3 )
            Controleur.VmodeleF.ModifEtatCommentaire(Convert.ToInt32(Controleur.VmodeleC.DT[10].Rows[0][0]), 3);
            MessageBox.Show("Le message a été passé à l'état de non validé", "Non Validé");
            btnListeComm_Click(sender, e);
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            //Modifier l'étét du commentaire pour le mettre à  validé ( = 2 )
            Controleur.VmodeleF.ModifEtatCommentaire(Convert.ToInt32(Controleur.VmodeleC.DT[10].Rows[0][0]), 2);
            MessageBox.Show("Le message a été passé à l'état de  validé", "Validé");
            btnListeComm_Click(sender, e);
        }

        private void btnListeComm_Click(object sender, EventArgs e)
        {
            Hide();
            FormListeCommentaire FLC = new FormListeCommentaire(user);
            FLC.Closed += (s, args) => Close();
            FLC.Show();
        }
    }
}
