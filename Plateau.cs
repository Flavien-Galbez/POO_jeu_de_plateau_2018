using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace TD2_AlexandreGHAHARIAN_FlavienGALBEZ
{
    class Plateau
    {
        private De[,] echiquier; // tableau 2D
        private char[,] valSup; // tableau 2D
        private List<De> mesDes;
        private int dimension;
        private Random r;

        public De[,] Echiquier
        {
            get{return echiquier;}
        }

        public char[,] ValSup
        {
            get { return valSup; }
        }

        public Plateau(string filename)
        {
            this.mesDes = LectureFichier(filename);
            this.r = new Random();
            double largeur = Math.Sqrt(mesDes.Count);
            if (largeur % 1 == 0)
            {
                this.dimension = (int)largeur;
                echiquier = new De[dimension, dimension];
                valSup = new char[dimension, dimension];
                New_Plateau();
            }
        }

        public void New_Plateau()
        {
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    int indice = r.Next(0, mesDes.Count);
                    echiquier[i, j] = mesDes[indice];
                    echiquier[i, j].Lance(r);
                    valSup[i,j]=echiquier[i,j].ValSup;
                    mesDes.RemoveAt(indice);
                }
            }
        }

        public override string ToString()
        {
            string resultat = "Le plateau est :\n";
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    resultat += this.valSup[i,j] + " ";
                }
                resultat += "\n";
            }
            return resultat;
        }

        public static List<De> LectureFichier(string fichier)
        {
            try
            {
                
                StreamReader sr = new StreamReader(fichier);
                List<De> listeDeDes= new List<De>();
                char c;
                int index = 0;
                char[] faces = new char[6];
                
                do
                {
                    c = (char)sr.Read();
                    if (c!=';'&&c!='\n')
                    {
                        faces[index] = c;
                        index++;
                    }
                    if (c=='\n')
                    {
                        De nouveauDe = new De(faces);
                        listeDeDes.Add(nouveauDe);
                        index = 0;
                    }
                } while (c != -1);
                sr.Close();
                return listeDeDes;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return null;
            }

        }

        public bool Test_Plateau(string mot)
        {
            bool resultat = false;
            if (mot.Length >= 2)
            {
                for (int i = 0; i < dimension; i++)
                {
                    for (int j = 0; j < dimension; j++)
                    {
                        if (mot[0] == this.valSup[i,j])
                        {
                            if (recherche_rec(mot, i, j, 1))
                            {
                                resultat = true;
                                return resultat;
                            }
                        }
                    }
                }
            }
            return resultat;
        }
        private bool recherche_rec(string mot, int indiceLigne, int indiceColonne, int indice)
        {
            if (indice < mot.Length)
            {
                for (int i = Math.Max(0, indiceLigne - 1); i <= Math.Min(3, indiceLigne + 1); i++)
                {
                    for (int j = Math.Max(0, indiceColonne - 1); j <= Math.Min(3, indiceColonne + 1); j++)
                    {
                        if (!(i == indiceLigne && j == indiceColonne))
                        {
                            if (this.valSup[i, j] == mot[indice])
                            {
                                return recherche_rec(mot, i, j, indice++);
                            }
                        }
                    }
                }
            }
            if (indice == mot.Length) return true;
            return false;
        }
    }
}
