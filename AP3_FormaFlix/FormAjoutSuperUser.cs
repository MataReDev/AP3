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
    public partial class FormAjoutUser : Corner
    {
        string user;
        public FormAjoutUser(string user)
        {
            InitializeComponent();
            this.user = user;
            roundedCorner();
        }

        private void FormAjoutSuperUser_Load(object sender, EventArgs e)
        {

        }

        private void help_MouseHover(object sender, EventArgs e)
        {
            lblHelpMessage.Visible = true;
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            Hide();
            FormPrincipale FF = new FormPrincipale(user);
            FF.Closed += (s, args) => Close();
            FF.Show();
        }
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Controleur.initUtilisateur();
            // vérifier que le libellé et le lien video sont renseignés au minimum
            if (tbNom.Text != "" && tbPrenom.Text != "" && tbMdp.Text != "" && tbConfirmMdp.Text != "" && tbEmail.Text != "")
            {
                string password;
                if (tbMdp.Text == tbConfirmMdp.Text)
                {
                    password = tbMdp.Text;
                    string mySalt = BCrypt.Net.BCrypt.GenerateSalt();
                    password = BCrypt.Net.BCrypt.HashPassword(password, mySalt);

                    if (IsValidEmail(tbEmail.Text))
                    {
                        // enregistrement de la question en lien avec le thème et niveau
                        if (Controleur.VmodeleU.ajouterUtilisateur(tbNom.Text, tbPrenom.Text, password, tbEmail.Text, cbAdministrateur.Checked))
                        {
                            btnAnnuler_Click(sender, e);
                        }
                    }
                    else
                        tbEmail.BackColor = Color.Red;
                }
                else
                {
                    MessageBox.Show("Les deux mots de passe ne sont pas identiques");
                    tbMdp.Text = "";
                    tbConfirmMdp.Text = "";
                }
            }
            else
                MessageBox.Show("Veillez à bien remplir toutes les zones de textes");
        }


        private void help_MouseLeave(object sender, EventArgs e)
        {
            lblHelpMessage.Visible = false;
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            tbEmail.Text = "";
            tbConfirmMdp.Text = "";
            tbNom.Text = "";
            tbPrenom.Text = "";
            tbMdp.Text = "";
            cbAdministrateur.Checked = false;
        }

        private void tbEmail_Enter(object sender, EventArgs e)
        {
            tbEmail.BackColor = Color.White;
        }
    }
}
