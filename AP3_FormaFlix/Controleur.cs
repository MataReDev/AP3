using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP3_FormaFlix
{
    /// <summary>
    /// Classe Controleur : AP3 FORMA'FLIX
    /// Auteur : M.GOUDAL
    /// date : Septembre 2021
    /// </summary>
    public static class Controleur
    {
        private static ModeleConnexion vmodeleC;
        private static ModeleFormation vmodeleF;
        private static ModeleUtilisateur vmodeleU;

        public static ModeleFormation VmodeleF { get => vmodeleF; set => vmodeleF = value; }
        public static ModeleConnexion VmodeleC { get => vmodeleC; set => vmodeleC = value; }
        public static ModeleUtilisateur VmodeleU { get => vmodeleU; set => vmodeleU = value; }

        public static void initConnexion()
        {
            VmodeleC = new ModeleConnexion();
        }
        public static void initFormation()
        {
            VmodeleF = new ModeleFormation();
        }
        public static void initUtilisateur()
        {
            VmodeleU = new ModeleUtilisateur();
        }

    }
}
