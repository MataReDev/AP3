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
    /// <summary>
    /// AP3 FORMA'FLIX : Vue permettant de lister toutes les formations de la BD (avec leurs compétences associées)
    /// Auteur : M.GOUDAL
    /// date : MAI 2022
    /// </summary>
    public partial class FormListeCommentaire : Corner
    {
        string user;
        public FormListeCommentaire(string user)
        {
            InitializeComponent();
            this.roundedCorner();
            this.user = user;
        }

        private void FormListeCommentaire_Load(object sender, EventArgs e)
        {
            Controleur.initFormation();
            Controleur.VmodeleF.charger_CommentaireValide();
            Controleur.VmodeleF.charger_CommentaireNonValide();
            Controleur.VmodeleF.charger_CommentaireATraiter();

            dgvListeCommValide.DataSource = Controleur.VmodeleC.DT[6];
            dgvListeCommNonValide.DataSource = Controleur.VmodeleC.DT[7];
            dgvCommATraiter.DataSource = Controleur.VmodeleC.DT[8];
        }

        private void btnListeComm_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormGestionCommentaire FGC = new FormGestionCommentaire(user);
            FGC.Closed += (s, args) => this.Close();
            FGC.Show();
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormPrincipale FP = new FormPrincipale(user);
            FP.Closed += (s, args) => this.Close();
            FP.Show();
        }

        private void btn_valide_comm_Click(object sender, EventArgs e)
        {
            if (dgvListeCommValide.SelectedRows.Count == 1)
            {
                this.Hide();
                FormChangeStatusCommentaire FCSP = new FormChangeStatusCommentaire(user, Convert.ToInt32(dgvListeCommValide.SelectedRows[0].Cells[0].Value));
                FCSP.Closed += (s, args) => this.Close();
                FCSP.Show();
            }
            else
                MessageBox.Show("Veuillez séléctionner un commentaire dans la liste des commentaires validé", "Erreur séléction");
        }

        private void btn_non_valide_comm_Click(object sender, EventArgs e)
        {
            if (dgvListeCommNonValide.SelectedRows.Count == 1)
            {
                this.Hide();
                FormChangeStatusCommentaire FCSP = new FormChangeStatusCommentaire(user, Convert.ToInt32(dgvListeCommNonValide.SelectedRows[0].Cells[0].Value));
                FCSP.Closed += (s, args) => this.Close();
                FCSP.Show();
            }
            else
                MessageBox.Show("Veuillez séléctionner un commentaire dans la liste des commentaires non validé", "Erreur séléction");
        }
    }
}
