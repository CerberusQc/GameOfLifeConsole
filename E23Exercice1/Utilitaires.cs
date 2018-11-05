using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Convert;
using static System.Char;

namespace Tools
{
    /// <summary>
    /// Ensemble d'outil de validateur pour diverse utilisation
    /// </summary>
    public static class Utilities
    {
        /****************************************************************************************************************/
        /**************************************  Section de validateurs Int32  ******************************************/
        /****************************************************************************************************************/
        /// <summary>
        /// Permet de valider un Entier
        /// </summary>
        /// <param name="p_question">La question a poser à l'utilisateur </param>
        /// <returns>La valeur validée</returns>
        public static int LireInt32(string p_question)
        {
            int nombre; // Contiendra le nombre provenant d'une lecture validée

            for (;;)
            {
                Write(p_question);
                /***/
                if (Int32.TryParse(ReadLine(), out nombre)) break;
                /***/
                WriteLine(" !!! Veuillez entrer un simple nombre entier. !!!");
                System.Threading.Thread.Sleep(1000);
            }
            return nombre;
        }

        /// <summary>
        /// Permet de valider un nombre entier positif
        /// </summary>
        /// <param name="p_question">La question a poser à l'utilisateur </param>
        /// <returns>La valeur validée</returns>
        public static int LireInt32Positif(string p_question)
        {
            int nombre; // Contiendra le nombre provenant d'une lecture validée

            for (;;)
            {
                nombre = LireInt32(p_question);
                /***/
                if (nombre >= 0) break;
                /**/
                WriteLine(" !!! Veuillez entrer un nombre entier positif. !!!");
                System.Threading.Thread.Sleep(1000);
            }
            return nombre;
        }

        /// <summary>
        /// Permet de valider un nombre entier avec un minimum
        /// </summary>
        /// <param name="p_question">La question a poser à l'utilisateur </param>
        /// <param name="p_minimum">La valeur minimale que l'entier peut prendre </param>
        /// <returns>La valeur validée</returns>
        public static int LireInt32AvecMinimum(string p_question, int p_minimum)
        {
            int nombre; // Contiendra le nombre provenant d'une lecture validée

            for (;;)
            {
                nombre = LireInt32(p_question);
                /***/
                if (nombre >= p_minimum) break;
                /**/
                WriteLine(" !!! Veuillez entrer un nombre entier supérieur ou égal à {0}. !!!", p_minimum);
                System.Threading.Thread.Sleep(1000);
            }
            return nombre;
        }

        /// <summary>
        /// Permet de valider un nombre entier dans un interval
        /// </summary>
        /// <param name="p_question">La question a poser à l'utilisateur </param>
        /// <param name="p_minimum">La valeur minimale que l'entier peut prendre </param>
        /// <param name="p_maximum">La valeur maximale que l'entier peut prendre </param>
        /// <returns>La valeur validée</returns>
        public static int LireInt32DansIntervalle(string p_question, int p_minimum, int p_maximum)
        {
            int nombre; // Contiendra le nombre provenant d'une lecture validée

            for (;;)
            {
                nombre = LireInt32(p_question);
                /***/
                if (p_minimum <= nombre && nombre <= p_maximum) break;
                /**/
                WriteLine(" !!! Veuillez entrer un nombre entier entre {0} et {1}. !!!", p_minimum, p_maximum);
                System.Threading.Thread.Sleep(1000);
            }
            return nombre;
        }

        /// <summary>
        /// Permet de valider un nombre entier avec un minimum avec une sentinelle
        /// </summary>
        /// <param name="p_question">La question a poser à l'utilisateur </param>
        /// <param name="p_minimum">La valeur minimale que l'entier peut prendre </param>
        /// <param name="p_sentinelle">La valeur de la sentinelle pour un arrêt</param>
        /// <returns>La valeur validée</returns>
        public static int LireInt32AvecMinimumOuSentinelle(string p_question, int p_minimum, int p_sentinelle)
        {
            int nombre; // Contiendra le nombre provenant d'une lecture validée

            for (;;)
            {
                nombre = LireInt32(p_question + " (" + p_sentinelle + " pour annuler et/ou terminer ) ");
                /***/
                if ((nombre >= p_minimum) || (nombre == p_sentinelle)) break;
                /**/
                WriteLine(" !!! Veuillez entrer un nombre entier supérieur ou égal à {0}. ( {1} pour annuler et/ou terminer ) !!!", p_minimum, p_sentinelle);
                System.Threading.Thread.Sleep(1000);
            }
            return nombre;
        }

        /// <summary>
        /// Permet de valider un nombre entier dans un interval avec une sentinelle
        /// </summary>
        /// <param name="p_question">La question a poser à l'utilisateur </param>
        /// <param name="p_minimum">La valeur minimale que l'entier peut prendre </param>
        /// <param name="p_maximum">La valeur maximale que l'entier peut prendre </param>
        /// <param name="p_sentinelle">La valeur de la sentinelle pour un arrêt</param>
        /// <returns>La valeur validée</returns>
        public static int LireInt32DansIntervalleOuSentinelle(string p_question, int p_minimum, int p_maximum, int p_sentinelle)
        {
            int nombre; // Contiendra le nombre provenant d'une lecture validée

            for (;;)
            {
                nombre = LireInt32(p_question + " (" + p_sentinelle + " pour annuler et/ou terminer ) ");
                /***/
                if ((p_minimum <= nombre && nombre <= p_maximum) || nombre == p_sentinelle) break;
                /**/
                WriteLine(" !!! Veuillez entrer un nombre entier entre {0} et {1}. ( {2} pour annuler et/ou terminer ) !!!", p_minimum, p_maximum, p_sentinelle);
                System.Threading.Thread.Sleep(1000);
            }
            return nombre;
        }

        /****************************************************************************************************************/
        /**************************************  Section de validateurs Double  *****************************************/
        /****************************************************************************************************************/
        /// <summary>
        /// Permet de valider un nombre à virgule ( un double)
        /// </summary>
        /// <param name="p_question">La question a poser à l'utilisateur </param>
        /// <returns>La valeur validée</returns>
        public static double LireDouble(string p_question)
        {
            double nombre; // Contiendra le nombre provenant d'une lecture validée

            for (;;)
            {
                Write(p_question);
                /***/
                if (Double.TryParse(ReadLine(), out nombre)) break;
                /***/
                WriteLine(" !!! Veuillez entrer un simple nombre. !!!");
                System.Threading.Thread.Sleep(1000);
            }
            return nombre;
        }

        /// <summary>
        /// Permet de valider un nombre positif
        /// </summary>
        /// <param name="p_question">La question a poser à l'utilisateur </param>
        /// <returns>La valeur validée</returns>
        public static double LireDoublePositif(string p_question)
        {
            double nombre; // Contiendra le nombre provenant d'une lecture validée

            for (;;)
            {
                nombre = LireDouble(p_question);
                /***/
                if (nombre >= 0) break;
                /**/
                WriteLine(" !!! Veuillez entrer un nombre positif. !!!");
                System.Threading.Thread.Sleep(1000);
            }
            return nombre;
        }

        /// <summary>
        /// Permet de valider un nombre avec un minimum
        /// </summary>
        /// <param name="p_question">La question a poser à l'utilisateur </param>
        /// <param name="p_minimum">La valeur minimale que le nombre peut prendre </param>
        /// <returns>La valeur validée</returns>
        public static double LireDoubleAvecMinimum(string p_question, double p_minimum)
        {
            double nombre; // Contiendra le nombre provenant d'une lecture validée

            for (;;)
            {
                nombre = LireDouble(p_question);
                /***/
                if (nombre >= p_minimum) break;
                /**/
                WriteLine(" !!! Veuillez entrer un nombre supérieur ou égal à {0}. !!!", p_minimum);
                System.Threading.Thread.Sleep(1000);
            }
            return nombre;
        }

        /// <summary>
        /// Permet de valider un nombre dans un interval
        /// </summary>
        /// <param name="p_question">La question a poser à l'utilisateur </param>
        /// <param name="p_minimum">La valeur minimale que le nombre peut prendre </param>
        /// <param name="p_maximum">La valeur maximale que le nombre peut prendre </param>
        /// <returns>La valeur validée</returns>
        public static double LireDoubleDansIntervalle(string p_question, double p_minimum, double p_maximum)
        {
            double nombre; // Contiendra le nombre provenant d'une lecture validée

            for (;;)
            {
                nombre = LireDouble(p_question);
                /***/
                if (p_minimum <= nombre && nombre <= p_maximum) break;
                /**/
                WriteLine(" !!! Veuillez entrer un nombre entre {0} et {1}. !!!", p_minimum, p_maximum);
                System.Threading.Thread.Sleep(1000);
            }
            return nombre;
        }

        /// <summary>
        /// Permet de valider un nombre avec un minimum avec une sentinelle
        /// </summary>
        /// <param name="p_question">La question a poser à l'utilisateur </param>
        /// <param name="p_minimum">La valeur minimale que le nombre peut prendre </param>
        /// <param name="p_sentinelle">La valeur de la sentinelle pour un arrêt</param>
        /// <returns>La valeur validée</returns>
        public static double LireDoubleAvecMinimumOuSentinelle(string p_question, double p_minimum, double p_sentinelle)
        {
            double nombre; // Contiendra le nombre provenant d'une lecture validée

            for (;;)
            {
                nombre = LireDouble(p_question + " (" + p_sentinelle + " pour annuler et/ou terminer ) ");
                /***/
                if (nombre >= p_minimum || nombre == p_sentinelle) break;
                /**/
                WriteLine(" !!! Veuillez entrer un nombre supérieur ou égal à {0}. ( {1} pour annuler et/ou terminer ) !!!", p_minimum, p_sentinelle);
                System.Threading.Thread.Sleep(1000);
            }
            return nombre;
        }

        /// <summary>
        /// Permet de valider un nombre dans un interval avec une sentinelle
        /// </summary>
        /// <param name="p_question">La question a poser à l'utilisateur </param>
        /// <param name="p_minimum">La valeur minimale que le nombre peut prendre </param>
        /// <param name="p_maximum">La valeur maximale que le nombre peut prendre </param>
        /// <param name="p_sentinelle">La valeur de la sentinelle pour un arrêt</param>
        /// <returns>La valeur validée</returns>
        public static double LireDoubleDansIntervalleOuSentinelle(string p_question, double p_minimum, double p_maximum, double p_sentinelle)
        {
            double nombre; // Contiendra le nombre provenant d'une lecture validée

            for (;;)
            {
                nombre = LireDouble(p_question + " (" + p_sentinelle + " pour annuler et/ou terminer ) ");
                /***/
                if ((p_minimum <= nombre && nombre <= p_maximum) || nombre == p_sentinelle) break;
                /**/
                WriteLine(" !!! Veuillez entrer un nombre entre {0} et {1}. ( {2} pour annuler et/ou terminer ) !!!", p_minimum, p_maximum, p_sentinelle);
                System.Threading.Thread.Sleep(1000);
            }
            return nombre;
        }

        /****************************************************************************************************************/
        /**************************************  Section de validateurs String  *****************************************/
        /****************************************************************************************************************/
        /// <summary>
        /// Permet de Lire un string
        /// </summary>
        /// <param name="p_question">La question a poser à l'utilisateur</param>
        /// <returns>Le string sans les espaces des extrémités</returns>
        public static string LireString(string p_question)
        {
            Write(p_question);
            return ReadLine().Trim();
        }

        /// <summary>
        /// Permet de contrôler la taille d'un texte (string)
        /// </summary>
        /// <param name="p_question">La question a poser à l'utilisateur</param>
        /// <param name="p_lgMin">Longueur minimale du texte</param>
        /// <param name="p_lgMax">Longueur maximal du texte</param>
        /// <returns>Le texte sans les espaces des extrémités</returns>
        public static string LireStringTailleContrôlée(string p_question, int p_lgMin, int p_lgMax)
        {
            string texte; // Contiendra le texte sans les espaces des extrémités

            for (;;)
            {
                Write(p_question);
                texte = ReadLine().Trim();
                /***/
                if (p_lgMin <= texte.Length && texte.Length <= p_lgMax) break;
                /***/
                WriteLine(
                "!!! Veuillez entrer un texte contenant entre {0} et {1} caractère. !!!", p_lgMin, p_lgMax);
                System.Threading.Thread.Sleep(1000);
            }
            return texte;
        }

        /// <summary>
        /// Permet de valider si le texte est non-vide
        /// </summary>
        /// <param name="p_question"></param>
        /// <returns></returns>
        public static string LireStringNonVide(string p_question)
        {
            string texte; // Contiendra le texte sans les espaces des extrémités

            for (;;)
            {
                Write(p_question);
                texte = ReadLine().Trim();
                /***/
                if (texte.Length > 0) break;
                /***/
                WriteLine(
                "!!! Veuillez entrer un texte non vide. !!!");
                System.Threading.Thread.Sleep(1000);
            }
            return texte;
        }

        /****************************************************************************************************************/
        /**************************************  Section de validateurs Char  *******************************************/
        /****************************************************************************************************************/
        /// <summary>
        /// Permet de lire un Caractère
        /// </summary>
        /// <param name="p_question">La question a poser à l'utilisateur</param>
        /// <returns>Le caractère validé</returns>
        public static char LireChar(string p_question)
        {
            char caractère; // Contiendra le caractère provenant d'une lecture validée

            for (;;)
            {
                Write(p_question);
                /***/
                if (Char.TryParse(ReadLine(), out caractère)
                &&
                !IsControl(caractère)) break;
                /**/
                WriteLine(" !!! Veuillez entrer un, et un seul, caractère (ordinaire). !!!");
                System.Threading.Thread.Sleep(1000);
            }
            return caractère;
        }

        /// <summary>
        /// Permet de lire un Caractère
        /// </summary>
        /// <param name="p_question">La question a poser à l'utilisateur</param>
        /// <param name="p_charactèresVérifier">La suite de caractère à vérifier sous une forme de string</param>
        /// <returns>Le caractère validé</returns>
        public static char LireCharAvecVérification(string p_question, string p_charactèresVérifier)
        {
            char caractère; // Contiendra le caractère provenant d'une lecture validée

            for (;;)
            {
                Write(p_question);
                /***/
                if (Char.TryParse(ReadLine(), out caractère)
                &&
                !IsControl(caractère)
                &&
                (p_charactèresVérifier.ToLower()).Contains(Char.ToLower(caractère))) break;
                /**/
                WriteLine(" !!! Veuillez entrer un, et un seul, caractère de la liste suivante : [{0}]. !!!", p_charactèresVérifier);
                System.Threading.Thread.Sleep(1000);
            }
            return caractère;
        }

        /****************************************************************************************************************/
        /**************************************  Section de validateurs Bool  *******************************************/
        /****************************************************************************************************************/
        /// <summary>
        /// Permet de valider par oui ou par non un choix
        /// </summary>
        /// <param name="p_question">La question a poser à l'utilisateur</param>
        /// <returns>Vrai si Oui, Faux si Non.</returns>
        public static bool ConfirmerOuiNon(string p_question)
        {
            for (;;)
            {
                Write("{0}\nPressez 'O' pour Oui, 'N' pour non :  ", p_question);
                char réponse = char.ToLower((ReadKey().KeyChar));
                if (réponse == 'o')
                    return true;
                else if (réponse == 'n')
                    return false;
                else
                {
                    WriteLine("\n\nCeci n'est pas une réponse valide...\n");
                    System.Threading.Thread.Sleep(1000);
                }
            }

        }

        /****************************************************************************************************************/
        /************************************  Section de validateurs List<>  *******************************************/
        /****************************************************************************************************************/
        /// <summary>
        /// Permet de créer une séquence de nombre réelle
        /// </summary>
        /// <param name="p_départ">Nombre de la valeur de départ</param>
        /// <param name="p_nbDeValeurs">Combien de valeurs dans la liste</param>
        /// <returns>La liste de la séquence des réelles</returns>
        public static List<double> SéquenceRéelle(double p_départ, int p_nbDeValeurs)
        {
            List<double> réels = new List<double>(p_nbDeValeurs);

            for (int i = 0; i != p_nbDeValeurs; ++i)
                réels.Add(p_départ + 1);

            return réels;
        }

        /****************************************************************************************************************/
        /***********************************  Section de Générateur Aléatoire *******************************************/
        /****************************************************************************************************************/

        /// <summary>
        /// Génére un nombre entier aléatoire dans un intervalle
        /// </summary>
        /// <param name="min">Nombre minimum inclus dans la liste</param>
        /// <param name="max">Nombre maximum exclus de la liste</param>
        /// <returns>Le nombre générer aléatoirement</returns>
        public static int NombreAléatoireEntier(int p_min, int p_max)
        {
            Random aléatoire = new Random();
            return aléatoire.Next(p_min, p_max);

        }

        /// <summary>
        /// Génére un nombre aléatoire dans un intervalle
        /// </summary>
        /// <param name="min">Nombre minimum inclus dans la liste</param>
        /// <param name="max">Nombre maximum exclus de la liste</param>
        /// <returns>Le nombre générer aléatoirement</returns>
        public static double NombreAléatoire(Random aléatoire, double p_min, double p_max)
        {
            return aléatoire.NextDouble() * (p_max - p_min) + p_min;
        }

        /****************************************************************************************************************/
        /***********************************  Section de Gestion de Vecteurs ********************************************/
        /****************************************************************************************************************/
        /// <summary>
        /// Permet de retirer un élément d'un vecteur en conservant l'ordre des éléments
        /// </summary>
        /// <typeparam name="T">Type des éléments du vecteur à modifier</typeparam>
        /// <param name="p_v">Le vecteur à modifier</param>
        /// <param name="p_indice">L'indice de l'élément à retirer</param>
        public static void RemoveAtEnOrdre<T>(this List<T> p_v, int p_indice)
        {
            p_v.RemoveAt(p_indice);
        }

        /// <summary>
        /// Permet de retirer un élément d'une certaine valeur d'un vecteur en conservant l'ordre des éléments
        /// </summary>
        /// <typeparam name="T">Type des éléments du vecteur à modifier</typeparam>
        /// <param name="p_v">Le vecteur à modifier</param>
        /// <param name="p_valeur">La valeur de l'élément à retirer</param>
        /// <returns>Retourne Faux si aucune valeur correspond dans le vecteur</returns>
        public static bool RemoveEnOrdre<T>(this List<T> p_v, T p_valeur)
        {
            int indiceValeur = p_v.IndexOf(p_valeur);

            if (indiceValeur == -1)
                return false;


            p_v.RemoveAt(indiceValeur);
            return true;
        }

        /// <summary>
        /// Permet de retirer toutes les éléments d'une certaine valeur d'un vecteur en conservant l'ordre des éléments
        /// </summary>
        /// <typeparam name="T">Type des éléments du vecteur à modifier</typeparam>
        /// <param name="p_v">Le vecteur à modifier</param>
        /// <param name="p_Prédicat">la valeur des éléments à retirer</param>
        /// <returns>Le nombre d'élément retirer</returns>
        public static int RemoveAllEnOrdre<T>(this List<T> p_v, Predicate<T> p_Prédicat)
        {
            return p_v.RemoveAll(p_Prédicat);
        }

        /// <summary>
        /// Permet de retirer un élément d'un vecteur sans conserver l'ordre des éléments
        /// </summary>
        /// <typeparam name="T">Type des éléments du vecteur à modifier</typeparam>
        /// <param name="p_v">Le vecteur à modifier</param>
        /// <param name="p_indice">L'indice de l'élément à retirer</param>
        public static void RemoveAtSansOrdre<T>(this List<T> p_v, int p_indice)
        {
            p_v[p_indice] = p_v[p_v.Count - 1];
            p_v.RemoveAt(p_v.Count - 1);
        }

        /// <summary>
        /// Permet de retirer un élément d'une certaine valeur d'un vecteur sans conserver l'ordre des éléments
        /// </summary>
        /// <typeparam name="T">Type des éléments du vecteur à modifier</typeparam>
        /// <param name="p_v">Le vecteur à modifier</param>
        /// <param name="p_valeur">La valeur de l'élément à retirer</param>
        /// <returns>Retourne Faux si aucune valeur correspond dans le vecteur</returns>
        public static bool RemoveSansOrdre<T>(this List<T> p_v, T p_valeur)
        {
            int indiceValeur = p_v.IndexOf(p_valeur);

            if (indiceValeur == -1)
                return false;

            p_v[indiceValeur] = p_v[p_v.Count - 1];
            p_v.RemoveAt(p_v.Count - 1);
            return true;
        }

        /// <summary>
        /// Permet de retirer toutes les éléments d'une certaine valeur d'un vecteur sans conserver l'ordre des éléments
        /// </summary>
        /// <typeparam name="T">Type des éléments du vecteur à modifier</typeparam>
        /// <param name="p_v">Le vecteur à modifier</param>
        /// <param name="p_Prédicat">la valeur des éléments à retirer</param>
        /// <returns>Le nombre d'élément retirer</returns>
        public static int RemoveAllSansOrdre<T>(this List<T> p_v, Predicate<T> p_Prédicat)
        {
            int nbRetraits = 0;

            for (int i = 0; i != p_v.Count - nbRetraits;)
            {
                if (!p_Prédicat(p_v[i]))
                    ++i;
                else
                {
                    ++nbRetraits;
                    p_v[i] = p_v[p_v.Count - nbRetraits];
                }
            }

            p_v.RemoveRange(p_v.Count - nbRetraits, nbRetraits);
            return nbRetraits;
        }
    }
}
