/*
 * Ce Programme permet de dessiner dans une matrice définit en pointant des positions. 
 * Une adaption du jeu de la vie de John Conway à été conçus par l'auteur et à été implanter à ce programme
 * 
 * Bonne découverte
 * 
 * Auteur : Bastien Roy-Mazoyer
 * Date de création : 26 Janvier 2017
 * Date de mise à jours : 04 Février 2017 
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Convert;
using static System.Console;
using static Tools.Utilities;
using static System.Math;


namespace E23Exercice1
{
    class Program
    {
        // C'est constante sont utilisé dans le programme JeuDeLaVie.cs, donc si vous les modifiers ,ils seront changé aussi dans JeuDeLaVie.cs
        public const int NbColonnes = 100;      // Nb de colonnes dans la matrice
        public const int NbLignes = 50;        // Nb de lignes dans la matrice

        const char CharRemplissage = '*';   // Le caractère qui servira à dessiner dans la matrice

        const int Sentinelle = -1;      // Sentinelle pour sortie rapide à travers le programme

        // Création de la matrice au niveau de la class Program pour la rendre accessible par toutes les méthodes :
        char[,] Matrice = new char[NbLignes + 1, NbColonnes + 1];

        static void Main()
        {
            new Program().Principale();
        }

        /// <summary>
        /// Ce Programme permet de dessiner dans une matrice définit en pointant des positions. 
        /// </summary>
        void Principale()
        {
            for (;;)
            {
                Console.ForegroundColor = ConsoleColor.White;
                /**/
                if (!Menu(ChoixUtilisateur()))
                    break;
                /**/
            }
        }

        /// <summary>
        /// Permet d'envoyer le choix de l'utilisateur vers la bonne méthode
        /// </summary>
        /// <param name="p_choixUtilisateur">Le choix de l'utilisateur</param>
        bool Menu(int p_choixUtilisateur)
        {
            switch (p_choixUtilisateur)
            {
                case 1: DessinerMatrice(); break;
                case 2: Menu(AjoutDessin()); break;
                case 3: AnimationMatrice(); break;
                case 4: JeuDeLaVie.Principale(Matrice); break;
                default:
                    {
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine("\n!!! Fermeture du Programme en cours... !!!\n");
                        return false;
                    }
            }
            return true;

        }

        /// <summary>
        /// Permet à l'utilisateur de choisir dans le menu
        /// </summary>
        /// <returns>Le choix de l'utilisateur</returns>
        int ChoixUtilisateur()
        {
            return LireInt32DansIntervalleOuSentinelle(
                 "\n 1- Faire afficher la matrice\n" +
                 " 2- Dessiner dans la matrice\n" +
                 " 3- Animation - Point Aléatoire dans la Matrice\n" +
                 " 4- Jeu de la Vie de Conway (IL MARCHE!!!!)\n", 1, 4, 0);
        }

        /// <summary>
        /// Permet d'envoyer le choix de l'utilisateur vers la bonne méthode de dessin
        /// </summary>
        /// <param name="p_choixUtilisateur">Le caractère correspodant au choix de l'utilisateur</param>
        void Menu(char p_choixUtilisateur)
        {
            switch (p_choixUtilisateur)
            {
                case 'p': DessinerPoint(); break;
                case 'l':
                case 'c': AcquérirPosition(p_choixUtilisateur); break;
                default:
                    {
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine("\nOpération Annulée\n");
                        return;
                    }
            }
        }

        /// <summary>
        /// Permet de dessiner le contour carré dans la matrice
        /// </summary>
        /// <param name="p_carré">Les coordonnées des deux coins opposés du carré</param>
        void DessinerCarré(Coordonnées p_carré)
        {
            double deltaX = p_carré.PosX2 - p_carré.PosX1;
            double deltaY = p_carré.PosY2 - p_carré.PosY1;

            for (int i = 0; i != deltaX;)
            {
                Matrice[p_carré.PosY1, p_carré.PosX1 + i] = CharRemplissage;
                Matrice[p_carré.PosY2, p_carré.PosX2 - i] = CharRemplissage;
                if (deltaX > 0)
                    ++i;
                else
                    --i;
            }

            for (int i = 0; i != deltaY;)
            {
                Matrice[p_carré.PosY1 + i, p_carré.PosX1] = CharRemplissage;
                Matrice[p_carré.PosY2 - i, p_carré.PosX2] = CharRemplissage;
                if (deltaY > 0)
                    ++i;
                else
                    --i;
            }
            Matrice[p_carré.PosY1, p_carré.PosX2] = CharRemplissage;
            Matrice[p_carré.PosY2, p_carré.PosX1] = CharRemplissage;
        }

        /// <summary>
        /// Permet d'avoir les positions pour dessiner dans la matrices
        /// </summary>
        void AcquérirPosition(char p_choixUtilisateur)
        {
            if (p_choixUtilisateur == 'l')
            {
                Coordonnées ligne = new Coordonnées(
                    LireInt32DansIntervalle("\nPosition en X du premier point : ", 1, NbColonnes),
                    LireInt32DansIntervalle("Position en Y du premier point : ", 1, NbLignes),
                    LireInt32DansIntervalle("Position en X du deuxième point : ", 1, NbColonnes),
                    LireInt32DansIntervalle("Position en Y du deuxième point : ", 1, NbLignes));
                DessinerLigne(ligne);
            }
            else
            {
                Coordonnées carré = new Coordonnées(
                    LireInt32DansIntervalle("\nPosition en X du premier coin : ", 1, NbColonnes),
                LireInt32DansIntervalle("Position en Y du premier coin : ", 1, NbLignes),
                LireInt32DansIntervalle("Position en X du coin opposé au premier : ", 1, NbColonnes),
                LireInt32DansIntervalle("Position en Y du coin opposé au premier : ", 1, NbLignes));
                DessinerCarré(carré);
            }
        }

        /// <summary>
        /// Permet de dessiner une ligne dans la matrice
        /// </summary>
        /// <param name="p_ligne">Les coordonnées de la ligne dans la matrice</param>
        void DessinerLigne(Coordonnées p_ligne)
        {
            double deltaX = (p_ligne.PosX2 - p_ligne.PosX1);
            double deltaY = (p_ligne.PosY2 - p_ligne.PosY1);
            double m = 0;

            if (Abs(deltaX) == 0)
            {
                DessinerLigneVertical(deltaY, p_ligne.PosY1, p_ligne.PosX1);
                return;
            }

            m = deltaY / deltaX;

            double b = p_ligne.PosY1 - m * p_ligne.PosX1;
            double deltaUtilisé = (Abs(deltaX) >= Abs(deltaY) ? deltaX : deltaY);

            for (int i = 0; i != deltaUtilisé;)
            {
                if (deltaUtilisé == deltaX)
                    Matrice[ToInt32(Round(m * (p_ligne.PosX1 + i) + b)), p_ligne.PosX1 + i] = CharRemplissage;
                else
                    Matrice[(p_ligne.PosY1 + i), ToInt32(Round((p_ligne.PosY1 + i - b) / m))] = CharRemplissage;

                if (deltaUtilisé > 0)
                    ++i;
                else
                    --i;

                Matrice[p_ligne.PosY2, p_ligne.PosX2] = CharRemplissage;
            }
        }

        /// <summary>
        /// Permet de dessiner une ligne vertical en occurence à un delta X nulle
        /// </summary>
        /// <param name="p_deltaY">Le delta des deux positions sur l'axe Y</param>
        /// <param name="p_posY1">La position initiale de la ligne sur l'axe des Y</param>
        /// <param name="p_posX1">La position initiale de la ligne sur l'axe des X</param>
        void DessinerLigneVertical(double p_deltaY, int p_posY1, int p_posX1)
        {
            for (int i = 0; i != p_deltaY;)
            {
                Matrice[p_posY1 + i, p_posX1] = CharRemplissage;
                if (p_deltaY > 0)
                    ++i;
                else
                    --i;
            }
            Matrice[p_posY1 + ToInt32(p_deltaY), p_posX1] = CharRemplissage;
        }

        /// <summary>
        /// Permet de dessiner un point simple en pointant une coordonée en X et Y
        /// </summary>
        void DessinerPoint()
        {
            int posX = LireInt32DansIntervalleOuSentinelle("Position en X du centre de la ligne", 1, NbColonnes, Sentinelle);

            /***/
            if (posX == Sentinelle)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("\nOpération Annulée\n");
                return;
            }
            /***/

            int posY = LireInt32DansIntervalleOuSentinelle("Position en Y du centre de la ligne", 1, NbLignes, Sentinelle);

            /***/
            if (posY == Sentinelle)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("\nOpération Annulée\n");
                return;
            }
            /***/

            Matrice[posY, posX] = CharRemplissage;
        }

        /// <summary>
        /// Permet à l'utilisateur de choisir le type de dessin à faire dans la matrice
        /// </summary>
        /// <returns>Le caractère de sélection de l'utilisateur</returns>
        char AjoutDessin()
        {
            return Char.ToLower(LireCharAvecVérification(
                "\n Appuyer sur\n" +
                " [P] pour dessiner un Point\n" +
                " [L] pour dessiner une ligne\n" +
                " [C] pour dessiner un carré\n" +
                " [Q] pour quitter\n" +
                " Votre choix : ", "P L C Q"));
        }

        /// <summary>
        /// Permet de faire afficher la matrice actuel à l'écran
        /// </summary>
        void DessinerMatrice()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Write("   ");
            for (int i = 0; i != NbColonnes / 10; ++i)
            {
                Write("1234567890");
            }
            WriteLine("\n   {0} ", "".PadRight(NbColonnes, '_'));

            for (int i = 1; i != Matrice.GetLength(0); ++i)
            {
                Write((i).ToString("00") + "|");
                for (int j = 1; j != Matrice.GetLength(1); ++j)
                {
                    Write(Matrice[i, j]);

                }
                WriteLine("|");

            }
            WriteLine("   {0} ", "".PadRight(NbColonnes, '¨'));
        }

        /// <summary>
        /// 
        /// </summary>
        void AnimationMatrice()
        {
            Random r = new Random();
            Console.CursorVisible = false;
            Console.Clear();
            for (int i = 0; i < r.Next(10, 1400); i++)
            {
                Matrice[r.Next(1, NbLignes), r.Next(1, NbColonnes)] = CharRemplissage;
                DessinerMatrice();
                System.Threading.Thread.Sleep(150);
                Console.SetCursorPosition(0, 0);
            }
            Console.Clear();
            Console.CursorVisible = true;
        }
    }
}
