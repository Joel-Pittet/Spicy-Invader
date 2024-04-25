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
        /// Crée le vaisseau du joueur
        /// </summary>
        SpaceShip playerSpaceShip = new SpaceShip(positionOnX: Console.WindowWidth / 2, positionOnY: Console.WindowHeight - 4, nbLives: 3 ,spaceShipShape: " ---|--- ");


        ///Crée 3 bunker
        Bunker bunkerLeft = new Bunker(Console.WindowWidth / 6, Console.WindowHeight / 1.4);
        Bunker bunkerCenter = new Bunker(Console.WindowWidth / 2, Console.WindowHeight / 1.4);
        Bunker bunkerRight = new Bunker(Console.WindowWidth / 1.2, Console.WindowHeight / 1.4);

        /// <summary>
        /// Affiche tous les objets du jeu sur la console
        /// </summary>
        public void DrawGame()
        {

            //Affiche le vaisseau du joueur
            playerSpaceShip.Draw();

            //Affiche les bunkers
            bunkerLeft.DrawBunker();
            //bunkerCenter.DrawBunker();
            //bunkerRight.DrawBunker();

            //Ajoute les bunkers à la liste des objet du jeu
            GameObject.gameObjects.Add(bunkerLeft);
            GameObject.gameObjects.Add(bunkerCenter);
            GameObject.gameObjects.Add(bunkerRight);
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
                List<GameObject> gameObjectsCopy = new List<GameObject>(GameObject.gameObjects);

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
