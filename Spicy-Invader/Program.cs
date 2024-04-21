///Auteur: Joël Pittet
///Date: 19.04.2024
///Lieu: Lausanne - ETML
///Description: Programme qui permet de joueur au jeu Space Invader, le programme contient le jeu, 
///             ses options (difficulté et son) ainsi qu'un tableau des meilleurs score

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Spicy_Invader
{
    
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //Empeche le scroll
            //Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);

            //Instancie le menu principal
            Menu mainMenu = new Menu();

            //Affiche le menu principal et récupère l'option selectionnée
            int userOption = mainMenu.DrawMenu();

            //Lance l'option selectionnée par l'utilisateur
            switch (userOption)
            {
                //Lance le jeu
                case 0:
                    Console.Clear();
                    StartNewGame();
                    break;
                //Ouvre les options
                case 1:
                    OpenOptions();
                    break;
                //Affiche le tableau des scores
                case 2:
                    ShowHighScore();
                    break;
                //Affiche l'à propos
                case 3:
                    ShowAbout();
                    break;
                //Quitte le programme
                case 4:
                    ExitProgram();
                    break;
                //Si l'utilisateur entre une lettre pas existanrte dans le menu
                //Efface la console et affiche un message d'erreur
                default:
                    Console.Clear();
                    Console.WriteLine("Problème lors du choix de l'option");
                    ExitProgram();
                    break;
            }

            //Démarre le jeu
            void StartNewGame()
            {
                //Crée une nouvelle partie
                Game game = new Game();

                //Dessine le jeu
                game.DrawGame();

                //Lance le jeu
                game.PlayGame();
            }


            //Ouvre les options du jeu
            void OpenOptions()
            {

            }


            //Affiche le meilleur score
            void ShowHighScore()
            {

            }


            //Affiche "A propos"
            void ShowAbout()
            {

            }


            //Quitte le programme
            void ExitProgram()
            {
                //Evite que la console soit en rouge
                Console.ResetColor();

                //efface la console
                Console.Clear();

                //Message de salutation
                Console.WriteLine("Merci d'avoir joué au Spicy Invader. À bientôt !!");
                Console.WriteLine("\nAppuyer sur une touche pour fermer le programme");
                Console.ReadLine();
            }

        } 

    }
}
