using System;
using System.Collections.Generic;
using System.Text;

namespace TD2_AlexandreGHAHARIAN_FlavienGALBEZ
{
    class De
    {
        private char valSup;
        private char[] valeurs;

        public De(char[] valeurs)
        {
            if (valeurs.Length == 6)
            {
                this.valeurs = valeurs;
            }
            else
            {
                this.valeurs = null;
            }
        }

        public char ValSup
        {
            get { return valSup; }
        }

        public void Lance(Random r) //Permet de faire un lancer de dé aléatoire
        {
            valSup = valeurs[r.Next(0, 5)];
        }

        public override string ToString()
        {
            string resultat = "Le dé a pour faces: ";
            foreach (char c in this.valeurs) resultat += (c + ", ");
            resultat += "et a pour face visible : " + valSup;
            return resultat;
        }
    }
}
