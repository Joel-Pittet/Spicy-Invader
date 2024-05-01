///Auteur: Joël Pittet
///Date: 19.04.2024
///Lieu: Lausanne - ETML
///Description: Classe qui contient la methode d'affichage du menu, 
///             qui affiche le menu navigable et retourne l'option selectionnée par l'utilisateur
/// 
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;

namespace Spicy_Invader
{
    internal class Menu
    {

        /// <summary>
        /// Option sélectionnée parmi le menu
        /// </summary>
        int selectedOption;

        //Affiche le menu
        public int DrawMenu()
        {
            //Remet les couleurs de base de la console ==> sert lors du réaffichage du menu
            //pour eviter que d'autre partie de la console soit en rouge
            Console.ResetColor();

            //Rend invisible le curseur
            Console.CursorVisible = false;

            //Largeur de la console
            int consoleWidth = Console.WindowWidth;

            //Hauteur de la console
            int consoleHeight = Console.WindowHeight;

            //Lignes pour le titre
            List<string> title = new List<string>()
            {
                "███████ ██████  ██  ██████ ██    ██     ██ ███    ██ ██    ██  █████  ██████  ███████ ██████ ",
                "██      ██   ██ ██ ██       ██  ██      ██ ████   ██ ██    ██ ██   ██ ██   ██ ██      ██   ██",
                "███████ ██████  ██ ██        ████       ██ ██ ██  ██ ██    ██ ███████ ██   ██ █████   ██████ ",
                "     ██ ██      ██ ██         ██        ██ ██  ██ ██  ██  ██  ██   ██ ██   ██ ██      ██   ██",
                "███████ ██      ██  ██████    ██        ██ ██   ████   ████   ██   ██ ██████  ███████ ██   ██",
                "\n\n\n"
            };

            //Décalage du titre par rapport au haut de la console
            int paddingTop = title.Count - 1;

            //Liste qui stocke les choix du menu
            List<string> listMenuEntries = new List<string>()
            {
                "Jouer",
                "Options",
                "Highscore",
                "A propos",
                "Quitter"
            };

            //Place le curseur légement plus bas pour que la première ligne affichée ne soit pas collée au top de la console
            Console.SetCursorPosition(0, consoleHeight / paddingTop);

            //Affiche le titre au centre de la console
            for (int i = 0; i < title.Count; i++)
            {
                int paddingLeft = (consoleWidth - title[i].Length) / 2;

                Console.WriteLine(title[i].PadLeft(paddingLeft + title[i].Length));

            }

            //Affiche toutes les options de la liste au centre de la console
            for (int i = 0; i < listMenuEntries.Count; i++)
            {
                //Affiche la couleur de fond en rouge pour l'option courante
                if (i == selectedOption)
                {

                    //Couleur de fond rouge pour l'option selectionnée
                    Console.BackgroundColor = ConsoleColor.Red;

                }
                else
                {
                    //Rétablit les couleurs d'origine pour les autres options
                    Console.ResetColor();
                }

                //Calcule pour connaitre le milieu de la console
                int padding = (consoleWidth - listMenuEntries[i].Length) / 2;

                //Place le curseur au centre de l'écran
                Console.SetCursorPosition(padding, Console.CursorTop);

                //Affiche l'option
                Console.WriteLine(listMenuEntries[i]);
            }

            // Stocke la touche pressée pour le choix de l'option de l'utilisateur
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            
            do
            {
                //Récupère la touche préssée
                key = Console.ReadKey();

                // Gestion de la navigation
                //Dans le cas ou la flèche du haut est pressée et que l'option selectionnée n'est pas la première
                if (key.Key == ConsoleKey.UpArrow && selectedOption != 0)
                {
                    selectedOption--;
                    DrawMenu();
                    break;
                }
                //Dans le cas ou la flèche du bas est pressée et que l'option seléctionnée n'est pas la dernière
                else if (key.Key == ConsoleKey.DownArrow && selectedOption != listMenuEntries.Count - 1)
                {
                    selectedOption++;
                    DrawMenu();
                    break;

                }
                //Dans le cas ou la flèche du bas est pressée et que l'option selectionnée est la dernière
                else if (key.Key == ConsoleKey.DownArrow && selectedOption == listMenuEntries.Count - 1)
                {
                    selectedOption = 0;
                    DrawMenu();
                    break;
                }
                //Dans le cas ou la flèche du haut est pressée et que l'option selectionnée est la première
                else if (key.Key == ConsoleKey.UpArrow && selectedOption == 0)
                {
                    selectedOption = listMenuEntries.Count - 1;
                    DrawMenu();
                    break;
                }

            } while (key.Key != ConsoleKey.Enter);
            
            
  
            //Retourne l'option choisie
            return selectedOption;
        }

    }
}
