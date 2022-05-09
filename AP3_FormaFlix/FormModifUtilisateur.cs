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
    public partial class FormModifUtilisateur : Corner
    {
        string user;
        int id;
        public FormModifUtilisateur(string user, int id)
        {
            InitializeComponent();
            roundedCorner();
            this.user = user;
            this.id = id;
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
            if (tbNom.Text != "" && tbPrenom.Text != ""  && tbEmail.Text != "")
            {
                if (IsValidEmail(tbEmail.Text))
                    if (Controleur.VmodeleU.modifierUtilisateur(id, tbNom.Text, tbPrenom.Text, tbEmail.Text, cbAdministrateur.Checked))
                    {
                        MessageBox.Show("Utilisateur modifié\nRetour à la liste des utilisateurs");
                        Hide();
                        FormListeUser FLU = new FormListeUser(user);
                        FLU.Closed += (s, args) => Close();
                        FLU.Show();
                    }
                    else
                        tbEmail.BackColor = Color.Red;
            }
            else
                MessageBox.Show("Veillez à bien remplir toutes les zones de textes");
        }

        private void FormModifUtilisateur_Load(object sender, EventArgs e)
        {
            Controleur.initUtilisateur();
            Controleur.VmodeleU.get_user_by_id(id);
            
            tbNom.Text = Controleur.VmodeleC.DT[12].Rows[0][0].ToString();
            tbPrenom.Text = Controleur.VmodeleC.DT[12].Rows[0][1].ToString();
            tbEmail.Text = Controleur.VmodeleC.DT[12].Rows[0][2].ToString();
            if (Convert.ToInt32(Controleur.VmodeleC.DT[12].Rows[0][3]) == 1 )
                cbAdministrateur.Checked = true;
            else
                cbAdministrateur.Checked = false;

        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Vous allez quittez la modification sans enregistrer, êtes vous sur de ce choix ?", "Quitter sans enregistrer", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Hide();
                FormListeUser FLU = new FormListeUser(user);
                FLU.Closed += (s, args) => Close();
                FLU.Show();
            }
        }
    }
}
