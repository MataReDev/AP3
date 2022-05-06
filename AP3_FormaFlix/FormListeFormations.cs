using System;
using System.Windows.Forms;

namespace AP3_FormaFlix
{
    /// <summary>
    /// AP3 FORMA'FLIX : Vue permettant de lister toutes les formations de la BD (avec leurs compétences associées)
    /// Auteur : M.GOUDAL
    /// date : MAI 2022
    /// </summary>
    public partial class FormListeFormations : Corner
    {
        private BindingSource bS1;
        string user;
        public FormListeFormations(string user)
        {
            InitializeComponent();
            this.user = user;
        }
        public FormListeFormations(string user, string Maj)
        {
            InitializeComponent();
            this.user = user;
            if (Maj == "modifier")
            {
                btn_modif_liste.Visible = false;
                btnModifForma.Visible = true;
                btnsuppforma.Visible = false;
            }
            else if (Maj == "supprimer")
            {
                btn_modif_liste.Visible = false;
                btnModifForma.Visible = false;
            }
        }

        private void FormListeFormations_Load(object sender, EventArgs e)
        {
            // instanciation du ModeleFormation VmodeleF
            Controleur.initUtilisateur();
            if (Controleur.VmodeleC.Connopen == false)
            {
                MessageBox.Show("Erreur dans la connexion");
            }
            else
            {
                // chargement des données de la table FORMATION via DT[1] et affichage dans un dataGridView
                Controleur.VmodeleF.charger_Formations();      
                if (Controleur.VmodeleC.Chargement)
                {
                    bS1 = new BindingSource();

                    bS1.DataSource = Controleur.VmodeleC.DT[1];
                    dgvFormations.DataSource = bS1;
                    dgvFormations.Columns[0].HeaderText = "ID FORMATION";
                    dgvFormations.Columns[1].HeaderText = "LIBELLE";

                    // mise à jour du dataGridView via le bindingSource rempli par le DataTable
                    dgvFormations.Refresh();
                    dgvFormations.Visible = true;
                }
            }

        }

        private void BtnFermer_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormPrincipale FF = new FormPrincipale(user);
            FF.Closed += (s, args) => this.Close();
            FF.Show();
        }

        /// <summary>
        /// Permet de lister les compétences de la formation sélectionnée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListeDesCompétencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // si une formation est bien sélectionnée dans le dataGridView
            if (dgvFormations.SelectedRows.Count == 1)
            {
                // on récupère l'identifiant de la formation sélectionnée
                int idF = Convert.ToInt32(dgvFormations.Rows[dgvFormations.SelectedRows[0].Index].Cells[0].Value);
            }
            else
                MessageBox.Show("Il faut sélectionner une ligne");
        }



        private void btnsuppforma_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vraiment supprimer cette formation ?", "Supprimer une formation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Controleur.initFormation();
                // enregistrement de la question en lien avec le thème et niveau
                if (Controleur.VmodeleF.SupprimerFormation(Convert.ToInt32(dgvFormations.CurrentRow.Cells[0].Value)))
                {
                    MessageBox.Show("Formation supprimée");
                    FormListeFormations_Load(sender, e);
                }
                else MessageBox.Show("Formation non supprimée");
            }
        }

        private void btnModifForma_Click(object sender, EventArgs e)
        {
            FormModifFormation FM = new FormModifFormation(Convert.ToInt32(dgvFormations.CurrentRow.Index));
            FM.Show();
        }

        private void btn_modif_liste_Click(object sender, EventArgs e)
        {
            FormModifFormation FM = new FormModifFormation(Convert.ToInt32(dgvFormations.CurrentRow.Index));
            FM.Show();
        }
    }
}

