using System;
using System.IO;
using System.Collections.Generic;

namespace TD2_AlexandreGHAHARIAN_FlavienGALBEZ
{
    class Dictionnaire
    {
        private List<string> Mots;
        private int nbMots=0;

        public Dictionnaire(string FileName)
        {
            try
            {
                StreamReader s = new StreamReader(FileName);
                string ligne = "";
                while (s.EndOfStream == false)
                {
                    ligne = s.ReadLine();
                    string[] motSuiv = ligne.Split(' '); //change de mot a chaque fois qu'il trouve un espace
                    for (int i = 0; i < motSuiv.Length; i++)
                    {
                        Mots.Add(motSuiv[i]);
                        nbMots++;
                    }
                }
                s.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public bool Existe(string mot)
        {
            if (mot.Length > 2 && mot.Length < 15)
            {
                return RechDichoRecursif(0, nbMots-1, mot); ;
            }
            else
            {
                return false;
            }
        }

        private bool RechDichoRecursif(int debut, int fin, string mot)
        {
            int milieu = debut + (fin - debut) / 2;
            if (fin - debut <= 0) //Cas d'arret 1 : false sauf si le mot correspond bien
            {
                if (fin - debut == 0)
                {
                    if (Mots[milieu].Length == mot.Length)
                    {
                        bool resultat = true;
                        for (int i = 0; i < mot.Length; i++)
                        {
                            if (mot[i] != Mots[milieu][i])
                            {
                                resultat = false;
                            }
                        }
                        return resultat; // en cas d'égalité avec le mot renvoit true
                    }
                    else return false;
                }
                else return false;
            }
            if (Mots[milieu].Length == mot.Length) //Si les deux mots ont la même taille, c'est l'ordre alphabétique qui compte pour l'ordre
            {

                for (int i = 0; i < mot.Length; i++)
                {
                    if (mot[i] < Mots[milieu][i])
                    {
                        return (RechDichoRecursif(debut, milieu - 1, mot));
                    }
                    if (mot[i] > Mots[milieu][i])
                    {
                        return (RechDichoRecursif(milieu + 1, fin, mot));
                    }
                }
                return true; // Cas d'arret 2 : Le mot testé est le même que le mot saisi
            }
            else //Sinon c'est la taille qui nous donne qui il faut changer entre début ou fin
            {
                if (mot.Length < Mots[milieu].Length)
                {
                    return (RechDichoRecursif(debut, milieu, mot));
                }
                else
                {
                    return (RechDichoRecursif(milieu, fin, mot));
                }
            }
        }
    }
}
