/*
 * Jeu de la vie, inspiré du jeu de John Conway, simulateur de cellulaire rudimentaire qui occasionne des formes de vies artificiel, des colonies et des vaisseaux
 * graçe à une algorithme simple de population.
 * 
 * Création : Bastien Roy-Mazoyer, le 01 Février 2017
 * M-a-J : 04 Février 2017
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Convert;
using static System.Math;
using static Tools.Utilities;


namespace E23Exercice1
{
    // Projet intérréssant à rajouter sur une plus grand grille.
    public class JeuDeLaVie
    {

        // Constante à augmenter pour ralentir la vitesse du jeu : 
        const int VitesseJeu = 1;

        // Matrice en 2D qui contiennent les cellules vivantes :
        static Cellule[,] MatriceDeJeux = new Cellule[Program.NbLignes + 1, Program.NbColonnes + 1];

        // Duplication de la Matrice pour mettre à jours en même temps tout les points sur la Matrice De Jeu :
        static Cellule[,] MatriceDeJeuxTemporaire = new Cellule[Program.NbLignes + 1, Program.NbColonnes + 1];

        /// <summary>
        /// Cellule qui seront utilisé dans la grille de jeu
        /// </summary>
        class Cellule
        {
            public Cellule(bool p_estVivante)
            {
                EstVivante = p_estVivante;
            }
            public bool EstVivante { get; set; } // Si la cellule est vivante ou non    
        }

        /// <summary>
        /// Jeu de la vie, inspiré du jeu de John Conway, simulateur de cellulaire rudimentaire qui occasionne des formes de vies artificiel, des colonies et des vaisseaux
        /// graçe à une algorithme simple de population.
        /// 
        /// Adapté par Bastien Roy-Mazoyer, le 01 Février 2017
        /// </summary>
        /// <param name="Matrice">La Matrice en 2D importée du Main, sera utilisé pour générer la matrice de jeu</param>
        public static void Principale(char[,] Matrice)
        {
            InitialisationMatrice(Matrice);
            Intro();

            for (;;)
            {
                Console.ForegroundColor = ConsoleColor.White;
                WriteLine("\n--- Menu Principale ---\n");
                /**/
                if (!Menu(ChoixUtilisateur()))
                {
                    WriteLine("\n\n Retour au Programme principale... \n");
                    break;
                }

                /**/
            }
        }

        /// <summary>
        /// Petite intro du programme
        /// </summary>
        static void Intro()
        {
            Write("\n Importation de la Matrice actuel vers la Matrice du Jeu en cours ");
            System.Threading.Thread.Sleep(750);
            Write(".");
            System.Threading.Thread.Sleep(750);
            Write(".");
            System.Threading.Thread.Sleep(750);
            Write(".\n");
            System.Threading.Thread.Sleep(750);
            WriteLine("\n Importation réussi !\n");
            System.Threading.Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Cyan;
            WriteLine("\n{0}**** Bienvenue dans le Jeu de la Vie, inspiré de John Conway ****\n", "".PadRight(26, ' '));
            System.Threading.Thread.Sleep(2000);
            WriteLine("\n{0}!!!!! Avertissement, si vous avez importé un Matrice vide, la grille sera vide !!!!\n", "".PadRight(17, ' '));
            System.Threading.Thread.Sleep(2000);
            WriteLine("\n!!!!! Dans le cas occurant, il est recommandé de choisir une option de création de cellule dans le menu... Merci !!!!\n");
            System.Threading.Thread.Sleep(3000);
        }

        /// <summary>
        /// Transforme la matrice du Program().Main() en grille pour le jeu
        /// </summary>
        /// <param name="Matrice">Matrice en 2d du Program().Main()</param>
        static void InitialisationMatrice(char[,] Matrice)
        {

            for (int i = 0; i != Matrice.GetLength(0); ++i)
            {
                for (int j = 0; j != Matrice.GetLength(1); ++j)
                {

                    if (Matrice[i, j] == '*')
                    {
                        MatriceDeJeux[i, j] = new Cellule(true);
                        MatriceDeJeuxTemporaire[i, j] = new Cellule(true);
                    }
                    else
                    {
                        MatriceDeJeux[i, j] = new Cellule(false);
                        MatriceDeJeuxTemporaire[i, j] = new Cellule(false);
                    }
                }
            }

        }

        /// <summary>
        /// Permet à l'utilisateur de voir les choix du menu
        /// </summary>
        /// <returns>Le choix de l'utilisateur</returns>
        static int ChoixUtilisateur()
        {
            return LireInt32DansIntervalleOuSentinelle(
                 "\n 1- Lancer le jeu avec une durée de cycle déterminer\n" +
                 " 2- Remplir la grille aléatoirement entre 100 et 1000 cellules groupés\n" +
                 " 3- Faire afficher la grille et les cellules vivantes actuelles\n" +
                 " 4- Générer un figure Acorn standard dans la grille (schéma qui permet une longue durée de vie) \n" +
                 " 5- Effacement la grille actuel de toute forme de vie\n "
                 , 1, 5, 0);
        }

        /// <summary>
        /// Menu principale qui amène le programe vers le choix de l'utilisateur
        /// </summary>
        /// <param name="p_choixUtilisateur">Le choix de l'utilisateur</param>
        /// <returns>Retourne faux si l'utilisateur veut revenir au menu principal, sinon continue</returns>
        static bool Menu(int p_choixUtilisateur)
        {
            int compensateur = 1; // Permet de satisfaire le compilateur pour la méthode DessinerMatrice(int) qui nécessite un paramêtre

            switch (p_choixUtilisateur)
            {
                case 1: LancerLeJeux(); break;
                case 2: RemplissageAléatoire(); break;
                case 3: DessinerMatrice(compensateur); break;
                case 4: RemplissageAcorn(); break;
                case 5: EffacementMatrice(); break;
                default:
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        if (ConfirmerOuiNon(" \n\nÊtes-vous certain de vouloir retourner au programme principale, la grille de jeu sera perdu..."))
                            return false;
                        break;
                    }

            }
            return true;

        }

        /// <summary>
        /// Permet d'activer la séquence d'animation et de création de la grille du jeu de la vie.
        /// </summary>
        static void LancerLeJeux()
        {
            Clear();
            // Temps cyclique des cellules, correspond au nombre de fois où la grille sera mise à jour, 
            // le + 1 est pour corriger le cadran afficher lorsqu'on dessine la grille :
            Console.ForegroundColor = ConsoleColor.Cyan;
            int temps = LireInt32AvecMinimumOuSentinelle("\n Temps de Cycles Cellulaires (une valeure de 100 équivaut à (+/-) 30 secondes) : ", 1, -1) + 1;

            /***/
            if (temps == -1)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("\n !!! Annulation en cours !!!\n");
                return;
            }
            /***/

            CursorVisible = false;
            Clear();

            for (int i = 1; i != temps; ++i)
            {
                MiseAJourMatrice();
                DessinerMatrice(i);
                System.Threading.Thread.Sleep(VitesseJeu);
                SetCursorPosition(0, 0);
            }
            Clear();
            CursorVisible = true;
        }

        /// <summary>
        /// Permet de faire afficher la matrice
        /// </summary>
        /// <param name="p_cptCycles"> le nombre de cycles</param>
        static void DessinerMatrice(int p_cptCycles)
        {
            int cptCelluleVivante = 0;

            Console.ForegroundColor = ConsoleColor.Green;
            Write("   ");
            for (int i = 0; i != Program.NbColonnes / 10; ++i)
            {
                Write("1234567890");
            }
            WriteLine("\n   {0} ", "".PadRight(Program.NbColonnes, '_'));

            for (int i = 1; i != MatriceDeJeux.GetLength(0) - 1; ++i)
            {
                Write((i).ToString("00") + "|");
                for (int j = 1; j != MatriceDeJeux.GetLength(1) - 1; ++j)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    if (MatriceDeJeux[i, j].EstVivante)
                    {
                        Write('*');
                        ++cptCelluleVivante;
                    }
                    else
                        Write(' ');
                }
                Console.ForegroundColor = ConsoleColor.Green;
                WriteLine("|");
            }
            WriteLine("   {0} ", "".PadRight(Program.NbColonnes, '¨'));
            Console.ForegroundColor = ConsoleColor.Cyan;
            WriteLine("   {0} Cellules vivantes : {1}   Cycles Cellulaires : {2}", "".PadRight(Program.NbColonnes - 50, ' '), cptCelluleVivante, p_cptCycles);
        }

        /// <summary>
        /// Met à jour les positions des cellules vivantes
        /// </summary>
        static void MiseAJourMatrice()
        {
            for (int i = 1; i != MatriceDeJeux.GetLength(0); ++i)
            {
                for (int j = 1; j != MatriceDeJeux.GetLength(1); ++j)
                {
                    bool enVie = MatriceDeJeux[i, j].EstVivante;
                    int cptVoisin = LiensDeVoisin(i, j);
                    bool résultat = false;

                    if (enVie && cptVoisin < 2)
                        résultat = false;
                    if (enVie && cptVoisin == 2 || cptVoisin == 3)
                        résultat = true;
                    if (enVie && cptVoisin > 3)
                        résultat = false;
                    if (!enVie && cptVoisin == 3)
                        résultat = true;

                    MatriceDeJeuxTemporaire[i, j].EstVivante = résultat;
                }
            }
            MatriceTemporaire();
        }

        /// <summary>
        /// Permet de transferer la MatriceTemporaire vers la MatriceDeJeu pour completer la mise à jour de la grille
        /// </summary>
        static void MatriceTemporaire()
        {
            for (int i = 0; i != MatriceDeJeux.GetLength(0); ++i)
            {
                for (int j = 0; j != MatriceDeJeux.GetLength(1); ++j)
                {
                    MatriceDeJeux[i, j].EstVivante = MatriceDeJeuxTemporaire[i, j].EstVivante;
                }
            }
        }

        /// <summary>
        /// Permet de vérifier si la cellule à une certaine position à des cellules vivantes voisines 
        /// </summary>
        /// <param name="y">position en X de la cellule</param>
        /// <param name="x">position en X de la cellule</param>
        /// <returns>Le nombre de Voisin vivant de la cellule actuelle</returns>
        static int LiensDeVoisin(int y, int x)
        {
            int cptDeVoisin = 0;

            // Vérification à droite :
            if (x != Program.NbColonnes)
            {
                if (MatriceDeJeux[y, x + 1].EstVivante)
                    ++cptDeVoisin;
            }

            // Vérification à droite en bas :
            if (x != Program.NbColonnes && y != Program.NbLignes)
            {
                if (MatriceDeJeux[y + 1, x + 1].EstVivante)
                    ++cptDeVoisin;
            }

            // Vérification en bas :
            if (y != Program.NbLignes)
            {
                if (MatriceDeJeux[y + 1, x].EstVivante)
                    ++cptDeVoisin;
            }

            // Vérification en bas à gauche :
            if (x != 0 && y != Program.NbLignes)
            {
                if (MatriceDeJeux[y + 1, x - 1].EstVivante)
                    ++cptDeVoisin;
            }

            // Vérification à gauche :
            if (x != 0)
            {
                if (MatriceDeJeux[y, x - 1].EstVivante)
                    ++cptDeVoisin;
            }

            // Vérification en haut à hauche :
            if (x != 0 && y != 0)
            {
                if (MatriceDeJeux[y - 1, x - 1].EstVivante)
                    ++cptDeVoisin;
            }

            // Vérification en haut :
            if (y != 0)
            {
                if (MatriceDeJeux[y - 1, x].EstVivante)
                    ++cptDeVoisin;
            }

            // Vérification en haut à droite :
            if (x != Program.NbColonnes && y != 0)
            {
                if (MatriceDeJeux[y - 1, x + 1].EstVivante)
                    ++cptDeVoisin;
            }

            return cptDeVoisin;

        }

        /// <summary>
        /// Permet de générer une figure Acorn qui est susceptible de créer une longue chaine de vie
        /// </summary>
        static void RemplissageAcorn()
        {
            Random r = new Random();
            int positionX = r.Next(10, Program.NbColonnes - 10);
            int positionY = r.Next(10, Program.NbLignes - 10);

            MatriceDeJeux[positionY, positionX] = new Cellule(true);
            MatriceDeJeux[positionY + 1, positionX + 2] = new Cellule(true);
            MatriceDeJeux[positionY + 2, positionX - 1] = new Cellule(true);
            MatriceDeJeux[positionY + 2, positionX] = new Cellule(true);
            MatriceDeJeux[positionY + 2, positionX + 3] = new Cellule(true);
            MatriceDeJeux[positionY + 2, positionX + 4] = new Cellule(true);
            MatriceDeJeux[positionY + 2, positionX + 5] = new Cellule(true);

            Console.ForegroundColor = ConsoleColor.Cyan;
            WriteLine("\n\n Une Forme Acorn à été généré à la position {0} , {1}\n", positionX, positionY);

        }

        /// <summary>
        /// Génére aléatoirement un certain nombre de cellules groupé selon un facteur semi-aléatoire
        /// </summary>
        static void RemplissageAléatoire()
        {
            Random r = new Random();
            int nbCellule = r.Next(100, 1000);
            int cptCellule = 0;
            for (int i = 0; i != nbCellule / 4; i++)
            {
                int positionX = r.Next(5, Program.NbColonnes - 5);
                int positionY = r.Next(5, Program.NbLignes - 5);
                if (i % 2 == 1 && i % 3 != 0)
                {
                    MatriceDeJeux[positionY, positionX] = new Cellule(true);
                    MatriceDeJeux[positionY + 1, positionX] = new Cellule(true);
                    MatriceDeJeux[positionY + 1, positionX + 1] = new Cellule(true);
                    MatriceDeJeux[positionY, positionX + 1] = new Cellule(true);

                }
                if (i % 3 == 0)
                {
                    MatriceDeJeux[positionY, positionX] = new Cellule(true);
                    MatriceDeJeux[positionY - r.Next(4), positionX + r.Next(4)] = new Cellule(true);
                    MatriceDeJeux[positionY + r.Next(4), positionX - r.Next(4)] = new Cellule(true);
                    MatriceDeJeux[positionY - r.Next(4), positionX + r.Next(4)] = new Cellule(true);

                }
                if (i % 2 == 0)
                {
                    MatriceDeJeux[positionY, positionX] = new Cellule(true);
                    MatriceDeJeux[positionY + r.Next(4), positionX + r.Next(4)] = new Cellule(true);
                    MatriceDeJeux[positionY + r.Next(4), positionX + r.Next(4)] = new Cellule(true);
                    MatriceDeJeux[positionY + r.Next(4), positionX + r.Next(4)] = new Cellule(true);
                }
            }
            foreach (Cellule cellule in MatriceDeJeux)
            {
                if (cellule.EstVivante)
                    ++cptCellule;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            WriteLine("\n\n {0} cellules générées !!!", cptCellule);
        }

        /// <summary>
        /// Permet d'effacer complètement la Matrice pour mettre la grille vide
        /// </summary>
        static void EffacementMatrice()
        {
            ForegroundColor = ConsoleColor.Red;
            if (ConfirmerOuiNon("\n\n !!! ATTENTION !!! \n\n Voulez-vous vraiment supprimer toute forme de vie sur la grille ? "))
            {
                for (int i = 0; i != MatriceDeJeux.GetLength(0); ++i)
                {
                    for (int j = 0; j != MatriceDeJeux.GetLength(1); ++j)
                    {
                        MatriceDeJeux[i, j].EstVivante = false;
                    }
                }
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("\n!!! Annulation en cours, rien n'a été modifier !!!\n");
            }
        }





    }


}
