    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace AP3_FormaFlix
{

    /// <summary>
    /// AP3 FORMA'FLIX : classe MODELECONNECTION pour la connexion à la BD 'ap"_bd_formaflix'
    /// Utilisateur d'une collection de DataTable
    /// dT[0] : dateTable des utilisateurs
    /// dT[1] : dataTable des formations
    /// dT[2] : dataTable des competences selon une formation
    /// dT[3] : dataTable des competences
    /// dT[4] : dataTable des competences selon un libellé
    /// Auteur : M.GOUDAL
    /// date : Septembre 2021
    /// </summary>
    public class ModeleUtilisateur
    {
        #region propriétés
        private MySqlConnection myConnection;
        private bool connopen = false;
        private bool chargement = false;


        #endregion

        #region accesseurs
        public bool Connopen { get => connopen; set => connopen = value; }
        public bool Chargement { get => chargement; set => chargement = value; }
        public MySqlConnection MyConnection { get => myConnection; set => myConnection = value; }

        #endregion
        public ModeleUtilisateur()
        {}

        /// <summary>
        /// Méthode qui récupère toutes les informations sur les formations
        /// </summary>
        public void lister_utilisateur()
        {
            Controleur.VmodeleC.charger("select idutilisateur, NOM, PRENOM, EMAIL, superU from utilisateur;", Controleur.VmodeleC.DT[9]);
        }

        public void get_user_by_id(int id)
        {
            Controleur.VmodeleC.charger("select NOM, PRENOM, EMAIL, superU from utilisateur where idutilisateur = "+id+";", Controleur.VmodeleC.DT[12]);
        }
        public bool supprimerUtilisateur(int id)
        {
            try
            {
                // préparation de la requête 
                string requete = "DELETE FROM utilisateur WHERE idutilisateur = @id;";
                MySqlCommand command = Controleur.VmodeleC.MyConnection.CreateCommand();
                command.CommandText = requete;
                command.Parameters.AddWithValue("id", id);
                int i = command.ExecuteNonQuery();

                // i est positif si l'insertion a pu avoir lieu
                return (i > 0);
            }
            catch
            {
                return false;
            }
        }
        public bool ajouterUtilisateur(string nom, string prenom, string mdp, string email, bool ouiNon)
        {
            try
            {
                // préparation de la requête 
                string requete = "insert into utilisateur values (null, @nom, @prenom, @mdp, @email, @super)";
                MySqlCommand command = Controleur.VmodeleC.MyConnection.CreateCommand();
                command.CommandText = requete;
                    

                // mise à jour des paramètres de la requête préparée avec les infos passés en paramètre de la méthode
                command.Parameters.AddWithValue("nom", nom);
                command.Parameters.AddWithValue("prenom", prenom);
                command.Parameters.AddWithValue("mdp", mdp);
                command.Parameters.AddWithValue("email", email);
                if (ouiNon)
                    command.Parameters.AddWithValue("super", 1);
                else
                    command.Parameters.AddWithValue("super", 0);
                // Exécution de la requête
                int i = command.ExecuteNonQuery();

                // i est positif si l'insertion a pu avoir lieu
                return (i > 0);
            }
            catch
            {
                return false;
            }
        }
        public bool modifierUtilisateur(int id, string nom, string prenom, string email, bool ouiNon)
        {
            try
            {
                // préparation de la requête 
                string requete = "update utilisateur set nom=@nom, prenom=@prenom, email = @email, superU = @super where idutilisateur = @id";
                MySqlCommand command = Controleur.VmodeleC.MyConnection.CreateCommand();
                command.CommandText = requete;


                // mise à jour des paramètres de la requête préparée avec les infos passés en paramètre de la méthode
                command.Parameters.AddWithValue("nom", nom);
                command.Parameters.AddWithValue("prenom", prenom);
                command.Parameters.AddWithValue("email", email);
                command.Parameters.AddWithValue("id", id);
                if (ouiNon)
                    command.Parameters.AddWithValue("super", 1);
                else
                    command.Parameters.AddWithValue("super", 0);
                // Exécution de la requête
                int i = command.ExecuteNonQuery();

                // i est positif si l'insertion a pu avoir lieu
                return (i > 0);
            }
            catch
            {
                return false;
            }
        }

    }
}
