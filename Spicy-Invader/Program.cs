///Auteur: Joël Pittet
///Date: 19.04.2024
///Lieu: Lausanne - ETML
///Description: Programme qui permet de joueur au jeu Space Invader, le programme contient le jeu, et une option pour quitter le prgramme
///        

using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleToAttribute("UnitTests")]

namespace Spicy_Invader
{

    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //Bloque le scroll de la fenetre
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);

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
                    mainMenu.DrawMenu();
                    break;
                //Affiche le tableau des scores
                case 2:
                    ShowHighScore();
                    mainMenu.DrawMenu();
                    break;
                //Affiche l'à propos
                case 3:
                    ShowAbout();
                    mainMenu.DrawMenu();
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
                //Efface la console
                Console.Clear();

                //Message de prévention
                Console.WriteLine("Fonctionalité non-implémentée");

                Console.WriteLine("\nAppuyer sur une touche pour fermer le programme");
                Console.ReadLine();

                //Efface la console
                Console.Clear();
            }


            //Affiche le meilleur score
            void ShowHighScore()
            {
                //Efface la console
                Console.Clear();

                //Message de prévention
                Console.WriteLine("Fonctionalité non-implémentée");

                Console.WriteLine("\nAppuyer sur une touche pour fermer le programme");
                Console.ReadLine();

                //Efface la console
                Console.Clear();

            }


            //Affiche "A propos"
            void ShowAbout()
            {
                //Evite que la console soit en rouge
                Console.ResetColor();

                //Efface la console
                Console.Clear();

                //Affiche l'explication
                Console.WriteLine("Ce jeu est une imitation du jeu Space Invader réalisé lors du module de POO I226A et I226B.");
                Console.WriteLine("Le but est de tuer les ennemis grâce aux missiles qui peuvent être tirés par le vaisseau du joueur.");

                Console.WriteLine("\nAppuyer sur une touche pour fermer le programme");
                Console.ReadLine();

                Console.Clear();
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
