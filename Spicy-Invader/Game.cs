///Auteur: Joël Pittet
///Date: 19.04.2024
///Lieu: Lausanne - ETML
///Description: Classe qui contient les méthodes concernant la partie "jeu" du programme

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Spicy_Invader
{
    internal class Game
    {

        /// <summary>
        /// Vitesse du jeu
        /// </summary>
        private const int _GAME_SPEED = 30;

        int positionBunkerLeft;

        /// <summary>
        /// Crée le vaisseau du joueur
        /// </summary>
        SpaceShip playerSpaceShip = new SpaceShip(positionOnX: Console.WindowWidth / 2, positionOnY: Console.WindowHeight - 4, nbLives: 3 ,spaceShipShape: " ---|--- ");


        ///Crée 3 bunker
        Bunker bunkerLeft = new Bunker(Console.WindowWidth - 100, Console.WindowHeight - 10);
        Bunker bunkerCenter = new Bunker(Console.WindowWidth - 60, Console.WindowHeight - 10);
        Bunker bunkerRight = new Bunker(Console.WindowWidth - 25, Console.WindowHeight - 10);

        /// <summary>
        /// Calcule la position des bunker par rapport à la fenetre
        /// </summary>
        public void PositionBunker()
        {
            positionBunkerLeft = Console.WindowWidth - ((3 * bunkerLeft.BunkerTop.Length)  / 3);
        }


        /// <summary>
        /// Affiche tous les objets du jeu sur la console
        /// </summary>
        public void DrawGame()
        {
            
            //Affiche le vaisseau du joueur
            playerSpaceShip.Draw();

            //Affiche les bunkers
            bunkerLeft.DrawBunker();
            bunkerCenter.DrawBunker();
            bunkerRight.DrawBunker();

            //Ajoute les bunkers à la liste des objet du jeu
            SimpleObject.gameObjects.Add(bunkerLeft);
            SimpleObject.gameObjects.Add(bunkerCenter);
            SimpleObject.gameObjects.Add(bunkerRight);
        }

        /// <summary>
        /// Permet de jouer
        /// </summary>
        public void PlayGame()
        {

            //Pour que le jeu s'arrete seulement si le vaisseau du joueur est mort
            do
            {
                //Copie la liste des objets du jeu pour pouvoir la parcourir même si d'autre objets son ajouter au fur et a mesure du jeu
                List<SimpleObject> gameObjectsCopy = new List<SimpleObject>(SimpleObject.gameObjects);

               //Parcours la liste des objets du jeu et les met à jour un par un
               foreach (var obj in gameObjectsCopy)
               {
                    obj.Update();
               }

               //Vitesse générale du jeu
               Thread.Sleep(_GAME_SPEED);

            } while (playerSpaceShip.IsAlive() == true);
        }
    }
}
