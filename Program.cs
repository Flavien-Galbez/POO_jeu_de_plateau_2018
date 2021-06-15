using System;
using System.Collections.Generic;

namespace TD2_AlexandreGHAHARIAN_FlavienGALBEZ
{
    class Program
    {

        static void Main(string[] args)
        {
            //Initialisation du jeu : On demandes d'initialiser les différents paramètres

            Joueur joueur1;
            Joueur joueur2;
            int nombreManches;
            Plateau plateau;
            Dictionnaire dico = new Dictionnaire("C:/Users/Flavien/Desktop/MotsPossibles.txt"); //On initialise le plateau

            do
            {
                Console.WriteLine("Veuillez entrer le nom du premier joueur :");
                joueur1 = new Joueur(Console.ReadLine());
            } while (joueur1.Nom != "\n");
            do
            {
                Console.WriteLine("Veuillez entrer le nom du second joueur : ");
                joueur2 = new Joueur(Console.ReadLine());
            } while (joueur2.Nom != "\n");
            do
            {
                Console.WriteLine("Veuillez entrer le nombre de manches :");
                nombreManches = Convert.ToInt32(Console.ReadLine());
            } while (nombreManches >= 1);
            Console.Clear();


            //Jeu

            string motSaisi = "";

            for (int tour = 1; tour <= nombreManches * 2; tour++)
            {
                plateau = new Plateau("C:/Users/Flavien/Desktop/Des.txt");
                Console.WriteLine(plateau.ToString());

                DateTime debutTour = DateTime.Now;
                DateTime currentTime = DateTime.Now;
                TimeSpan interval = currentTime - debutTour;


                Console.Write("C'est au tour de ");
                if (tour % 2 == 1) Console.Write(joueur1.Nom);
                else Console.Write(joueur2.Nom);
                Console.WriteLine(" de jouer");

                while (interval.TotalSeconds < 60)
                {
                    do
                    {
                        Console.Write("Saisissez un nouveau mot trouvé : ");
                        motSaisi = Console.ReadLine();
                    } while (motSaisi.Length < 3);
                    motSaisi = motSaisi.ToUpper(); //On passe le mot saisi en majuscule
                    currentTime = DateTime.Now;
                    interval = currentTime - debutTour;
                    if (tour % 2 == 1) //permet de séparer le tour de joueur 1 et joueur 2
                    {
                        if (joueur1.Contain(motSaisi) == false && dico.Existe(motSaisi) == true && plateau.Test_Plateau(motSaisi)==true)
                        {
                            Console.WriteLine("Valide !");
                            joueur1.AddMot(motSaisi);
                            joueur1.AjouterPoints(motSaisi);
                            Console.WriteLine(joueur1.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Invalide !");
                        }

                    }
                    else
                    {
                        if (joueur2.Contain(motSaisi) == false && dico.Existe(motSaisi) == true && plateau.Test_Plateau(motSaisi) == true)
                        {
                            Console.WriteLine("Valide !");
                            joueur2.AddMot(motSaisi);
                            joueur2.AjouterPoints(motSaisi);
                            Console.WriteLine(joueur2.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Invalide !");
                        }

                    }
                }
                joueur1.RemiseListeMotAZero(); //On nettoie la liste des mots saisie pour les deux joueurs
                joueur2.RemiseListeMotAZero();
                Console.Clear();
            }


            //Résultat : On affiche le ou les gagnant(s)

            Console.Write("Le gagnant est ");
            if (joueur1.Score>joueur2.Score)
            {
                Console.Write("Le gagnant est "+ joueur1.Nom + "avec un score de"+ joueur1.Score + "points");
            }
            if (joueur1.Score < joueur2.Score)
            {
                Console.Write("Le gagnant est " + joueur2.Nom + "avec un score de" + joueur2.Score + "points");
            }
            if (joueur1.Score == joueur2.Score)
            {
                Console.Write("Les deux joueurs sont à égalité avec un score de" + joueur1.Score + "points");
            }

            Console.ReadKey();
        }
    }
}
