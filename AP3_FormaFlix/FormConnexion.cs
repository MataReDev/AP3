﻿using System;
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
    public partial class FormConnexion : Corner
    {
        

        public FormConnexion()
        {
            InitializeComponent();
            this.roundedCorner();
        }        

        private void FormConnexion_Load(object sender, EventArgs e)
        {
            Controleur.initConnexion();
            Controleur.VmodeleC.seconnecter();
            if (Controleur.VmodeleC.Connopen == false)
            {
                 MessageBox.Show("Erreur dans la connexion");
               // throw new System.ArgumentException("Erreur dans la connexion", "connexion");
                Application.Exit();
            }
            else
            {
                // MessageBox.Show("BD connectée");
            }
        }
               
        private void FormConnexion_FormClosed(object sender, FormClosedEventArgs e)
        {
            Controleur.VmodeleC.sedeconnecter();
            Application.Exit();
        }

        private void BtnConnecter_Click(object sender, EventArgs e)
        {
           // si la BD est connectée et si les champs login et mdp sont saisis
           if (Controleur.VmodeleC.Connopen && tbLogin.Text != "" && tbmdp.Text != "")
           {
               // on recherche l'utilisateur connecté avec le login
               Controleur.VmodeleC.charger_Utilisateur(tbLogin.Text);
        
               // s'il existe bien un utilisateur avec ce login
               if (Controleur.VmodeleC.Chargement)
               {
                   if (Controleur.VmodeleC.DT[0].Rows.Count !=0)
                   {
                        // on compare le mot de passe saisi avec le mot de passe crypté de la BD lié à ce login
                        if (BCrypt.Net.BCrypt.Verify(tbmdp.Text, Controleur.VmodeleC.DT[0].Rows[0]["MOTPASSE"].ToString()))
                        {
                            // on ouvre la vue principale de l'application en passant en paramètre le nom de l'utilisateur
                            FormPrincipale FC = new FormPrincipale(Controleur.VmodeleC.DT[0].Rows[0]["NOM"].ToString());
                            FC.Show();
                            this.Hide();
                        }
                        else
                            MessageBox.Show("ERREUR : Mot de passe incorrects");
                   }
                   else
                   {
                       MessageBox.Show("ERREUR : Nom incorrect");
                       tbmdp.Clear();
                       tbLogin.Focus();
                   }
               }
           }
           else
               MessageBox.Show("ERREUR : Saisir un nom et un mot de passe");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbmdp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                BtnConnecter_Click(sender, e);
        }
    }
}