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
    public partial class FormListeUser : Form
    {

        private BindingSource bS1;
        string user;

        public FormListeUser(string user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void FormListeUser_Load(object sender, EventArgs e)
        {
            // instanciation du ModeleFormation VmodeleU
            Controleur.initFormation();
            Controleur.initUtilisateur();
            if (Controleur.VmodeleC.Connopen == false)
            {
                MessageBox.Show("Erreur dans la connexion");
            }
            else
            {
                // chargement des données de la table UTILISATEUR via DT[9] et affichage dans un dataGridView
                Controleur.VmodeleU.lister_utilisateur();
                if (Controleur.VmodeleC.Chargement)
                {
                    bS1 = new BindingSource();

                    bS1.DataSource = Controleur.VmodeleC.DT[9];
                    dgvUtilisateurs.DataSource = bS1;
                    dgvUtilisateurs.Columns[0].HeaderText = "NOM / ID";
                    dgvUtilisateurs.Columns[1].HeaderText = "PRENOM";
                    dgvUtilisateurs.Columns[2].HeaderText = "Email";
                    dgvUtilisateurs.Columns[3].HeaderText = "Admin";

                    // mise à jour du dataGridView via le bindingSource rempli par le DataTable
                    dgvUtilisateurs.Refresh();
                    dgvUtilisateurs.Visible = true;
                }
            }
        }

        private void btn_modif_liste_Click(object sender, EventArgs e)
        {

        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormPrincipale FF = new FormPrincipale(user);
            FF.Closed += (s, args) => this.Close();
            FF.Show();

        }
    }
}
