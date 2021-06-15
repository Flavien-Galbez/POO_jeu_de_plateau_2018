using System;
using System.Collections.Generic;
using System.Text;

namespace TD2_AlexandreGHAHARIAN_FlavienGALBEZ
{
    class Joueur
    {
        private string nom;
        private int score = 0;
        private List<string> motsTrouves;

        public Joueur(string nom)
        {
            this.nom = nom;
            this.score = 0;
            this.motsTrouves = new List<string>();
        }

        public string Nom
        {
            get { return nom; }
        }

        public int Score
        {
            get { return score; }
        }

        public List<string> MotsTrouves
        {
            get { return motsTrouves; }
            set { motsTrouves = value; }
        }

        public void AjouterPoints(string mot) //Permet d'ajouter des points au joueur selon la taille du mot
        {
            switch (mot.Length)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    this.score += 2;
                    break;
                case 4:
                    this.score += 3;
                    break;
                case 5:
                    this.score += 4;
                    break;
                case 6:
                    this.score += 5;
                    break;
                default:
                    this.score += 11;
                    break;
            }
        }

        public bool Contain(string mot)
        {
            bool resultat = false;
            for (int i = 0; i < this.motsTrouves.Count; i++)
            {
                if (this.motsTrouves[i] == mot) resultat = true;
            }
            return resultat;
        }


        public void AddMot(string mot)
        {
            this.motsTrouves.Add(mot);
        }

        public void RemiseListeMotAZero() //Remet à zero la liste des mots
        {
            this.motsTrouves.Clear();
        }

        public override string ToString()
        {
            string resultat = "Le score de " + nom + " est de " + score + "grace aux mots cités suivants :\n";
            for (int i = 0; i < motsTrouves.Count; i++)
            {
                resultat+=motsTrouves[i]+" ";
            }
            return resultat;
        }

        public string SaisieMot()
        {
            string mot = "";
            Console.Write("Donner un mot : ");
            mot = Console.ReadLine();
            return mot;
        }
    }
}
