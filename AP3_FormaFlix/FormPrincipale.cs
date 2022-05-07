using System;
using System.Drawing;
using System.Windows.Forms;

namespace AP3_FormaFlix
{
    /// <summary>
    /// AP3 FORMA'FLIX : Vue permettant de lister toutes les formations de la BD (avec leurs compétences associées)
    /// Auteur : M.GOUDAL
    /// date : MAI 2022
    /// </summary>
    public partial class FormPrincipale : Corner
    {
        string admin;
        public FormPrincipale(string admin)
        {
            InitializeComponent();
            this.roundedCorner();
            this.admin = admin;
            menuStrip1.Renderer = new MiRenderizador();
        }
        private class MiRenderizador : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (!e.Item.Selected) base.OnRenderMenuItemBackground(e);
                else
                {
                    Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                    e.Graphics.FillRectangle(Brushes.Red, rc); // Choix couleur
                }
            }
        }

        private void QuitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void ReconnecterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConnexion FC = new FormConnexion();
            FC.Show();
            this.Close();
        }

        private void FormPrincipale_Load(object sender, EventArgs e)
        {
            user.Text = admin;
            if (Convert.ToInt32(Controleur.VmodeleC.DT[0].Rows[0][5]) == 1)
            {
                ajouterUtilisateurToolStripMenuItem.Visible = true;
                connexionToolStripMenuItem.Visible = true;
                listerUtilisateurToolStripMenuItem.Visible = true;
            }
        }

        private void ListerToutesLesFormationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormListeFormations FF = new FormListeFormations(admin);
            FF.Closed += (s, args) => this.Close();
            FF.Show();
        }

        private void FormPrincipale_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void AjouterUneFormationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Hide();
            FormAjoutFormation FA = new FormAjoutFormation(admin);
            FA.Closed += (s, args) => this.Close();
            FA.Show();
        }

        private void gestionDesCommentairesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormGestionCommentaire FGC = new FormGestionCommentaire(admin);
            FGC.Closed += (s, args) => this.Close();
            FGC.Show();
        }

        private void modiferUneFormationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormListeFormations FF = new FormListeFormations(admin,"modifier");
            FF.Closed += (s, args) => this.Close();
            FF.Show();
        }

        private void supprimerUneFormationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormListeFormations FF = new FormListeFormations(admin,"supprimer");
            FF.Closed += (s, args) => this.Close();
            FF.Show();
        }

        private void ajouterUtilisateurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAjoutUser FASU = new FormAjoutUser(admin);
            FASU.Closed += (s, args) => this.Close();
            FASU.Show();
        }

        private void deconnexionToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void listerUtilisateurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormListeUser FLU = new FormListeUser(admin);
            FLU.Closed += (s, args) => this.Close();
            FLU.Show();
        }

        private void deconnexionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controleur.VmodeleC.sedeconnecter();
            MessageBox.Show("Vous êtes déconnecté de la base de données");
            gestionDesFormationsToolStripMenuItem.Enabled = false;
            gestionDesCommentairesToolStripMenuItem.Enabled = false;
            ajouterUtilisateurToolStripMenuItem.Enabled = false;
        }

        private void reconnecterToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FormConnexion FC = new FormConnexion();
            FC.Show();
            this.Close();
        }

        private void deconnexionToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FormConnexion FC = new FormConnexion();
            FC.Closed += (s, args) => this.Close();
            FC.Show();
        }

        private void connexionToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
        }
    }
}
