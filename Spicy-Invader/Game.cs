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

        /// <summary>
        /// Position du bunker de gauche sur la console
        /// </summary>
        int positionBunkerLeft;

        /// <summary>
        /// Position du bunker du milieu sur la console
        /// </summary>
        int positionBunkerMiddle;

        /// <summary>
        /// Position du bunker de droite sur la console
        /// </summary>
        int positionBunkerRight;

       

        /// <summary>
        /// Crée le vaisseau du joueur
        /// </summary>
        SpaceShip playerSpaceShip = new SpaceShip(positionOnX: Console.WindowWidth / 2, positionOnY: Console.WindowHeight - 4, nbLives: 3 ,spaceShipShape: " ---|--- ");


        ///Crée 3 bunker
        Bunker bunkerLeft = new Bunker(positionOnX: 0, positionOnY: 0);
        Bunker bunkerMiddle = new Bunker(positionOnX: 0, positionOnY: 0);
        Bunker bunkerRight = new Bunker(positionOnX: 0, positionOnY: 0);

        /// <summary>
        /// Calcule la position des bunker par rapport à la fenetre
        /// </summary>
        public void CalculatePositionBunker()
        {
            positionBunkerLeft = Console.WindowWidth - bunkerLeft.BunkerBottom.Length * 12;
            positionBunkerMiddle = Console.WindowWidth - bunkerMiddle.BunkerBottom.Length * 7;
            positionBunkerRight = Console.WindowWidth - bunkerRight.BunkerBottom.Length * 2;

        }


        /// <summary>
        /// Affiche tous les objets du jeu sur la console
        /// </summary>
        public void DrawGame()
        {
            CalculatePositionBunker();
            
            bunkerLeft = new Bunker(positionOnX: positionBunkerLeft, positionOnY: Console.WindowHeight - 10);
            bunkerMiddle = new Bunker(positionOnX: positionBunkerMiddle, positionOnY: Console.WindowHeight - 10);
            bunkerRight = new Bunker(positionOnX: positionBunkerRight, positionOnY: Console.WindowHeight - 10);

            //Affiche le vaisseau du joueur
            playerSpaceShip.Draw();

            //Affiche les bunkers
            bunkerLeft.DrawBunker();
            bunkerMiddle.DrawBunker();
            bunkerRight.DrawBunker();

            //Ajoute les bunkers à la liste des objet du jeu
            SimpleObject.gameObjects.Add(bunkerLeft);
            SimpleObject.gameObjects.Add(bunkerMiddle);
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
