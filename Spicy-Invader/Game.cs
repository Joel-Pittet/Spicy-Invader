///Auteur: Joël Pittet
///Date: 19.04.2024
///Lieu: Lausanne - ETML
///Description: Classe qui contient les méthodes concernant la partie "jeu" du programme

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Spicy_Invader
{
    internal class Game
    {

        /// <summary>
        /// Vitesse du jeu
        /// </summary>
        private const int _GAME_SPEED = 35;

        /// <summary>
        /// Nombre de bunker dans le jeu
        /// </summary>
        private const int _NB_BUNKER = 4;

        /// <summary>
        /// Position du bunker de gauche sur la console
        /// </summary>
        private int _positionBunkerLeft = 0;

        /// <summary>
        /// Position du bunker du milieu à gauche sur la console
        /// </summary>
        private int _positionBunkerMiddleLeft = 0;


        /// <summary>
        /// Position du bunker du milieu à droite sur la console
        /// </summary>
        private int _positionBunkerMiddleRight = 0;


        /// <summary>
        /// Position du bunker de droite sur la console
        /// </summary>
        private int _positionBunkerRight = 0;

        /// <summary>
        /// Position des bunkers sur l'axe Y
        /// </summary>
        private int positionOnYBunkers = Console.WindowHeight - 10;

        /// <summary>
        /// Crée le vaisseau du joueur
        /// </summary>
        PlayerSpaceShip playerSpaceShip = new PlayerSpaceShip(positionOnX: Console.WindowWidth / 2, positionOnY: Console.WindowHeight - 4, nbLives: 3 ,SpaceShipShape: "---|---");

        /// <summary>
        /// Bunker de gauche
        /// </summary>
        Bunker bunkerLeft = new Bunker(positionOnX: 0, positionOnY: 0);

        /// <summary>
        /// Bunker du centre à gauche
        /// </summary>
        Bunker bunkerMiddleLeft = new Bunker(positionOnX: 0, positionOnY: 0);

        /// <summary>
        /// Bunker du centre à droite
        /// </summary>
        Bunker bunkerMiddleRight = new Bunker(positionOnX: 0, positionOnY: 0);

        /// <summary>
        /// Bunker de droite
        /// </summary>
        Bunker bunkerRight = new Bunker(positionOnX: 0, positionOnY: 0);

        /// <summary>
        /// Ligne d'ennemi
        /// </summary>
        static EnemyLine firstLine = new EnemyLine(nbEnemies: 4, enemyShape: ".-=o=-.", levelLine: 0);
        static EnemyLine secondLine = new EnemyLine(nbEnemies: 4, enemyShape: ".-=o=-.", levelLine: 1);
        static EnemyLine thirdLine = new EnemyLine(nbEnemies: 4, enemyShape: ".-=o=-.", levelLine: 2);
        static EnemyLine fourthLine = new EnemyLine(nbEnemies: 4, enemyShape: ".-=o=-.", levelLine: 3);


        EnemyBlock block = new EnemyBlock(first: firstLine, second: secondLine, third: thirdLine, fourth: fourthLine);

        /// <summary>
        /// Calcule la position des bunker par rapport à la fenetre
        /// </summary>
        public void CalculatePositionBunker(int nbBunkers)
        {
            //Calcule l'espace à laisser entre les bunkers
            int gapBetweenBunkers = (Console.WindowWidth - (_NB_BUNKER * bunkerLeft.BottomFloor.Length)) / (_NB_BUNKER + 1);

            for (int i = 1; i <= nbBunkers; i++)
            {

                if (i == 1)
                {
                    _positionBunkerRight = (Console.WindowWidth - gapBetweenBunkers * i) - (bunkerLeft.BottomFloor.Length * i);

                }
                else if (i == 2)
                {

                    _positionBunkerMiddleLeft = (Console.WindowWidth - gapBetweenBunkers * i) - (bunkerLeft.BottomFloor.Length * i);

                }
                else if(i == 3)
                {
                    _positionBunkerMiddleRight = (Console.WindowWidth - gapBetweenBunkers * i) - (bunkerLeft.BottomFloor.Length * i);
                }
                else
                {
                    _positionBunkerLeft = (Console.WindowWidth - gapBetweenBunkers * i) - (bunkerLeft.BottomFloor.Length * i);
                }

            }
        }

        /// <summary>
        /// Affiche tous les objets du jeu sur la console
        /// </summary>
        public void DrawGame()
        {

            //Calcule la position de chaque bunker
            CalculatePositionBunker(_NB_BUNKER);

            //Donne la position pour chaque bunker
            bunkerLeft = new Bunker(positionOnX: _positionBunkerLeft, positionOnY: positionOnYBunkers);
            bunkerMiddleLeft = new Bunker(positionOnX: _positionBunkerMiddleLeft, positionOnY: positionOnYBunkers);
            bunkerMiddleRight = new Bunker(positionOnX: _positionBunkerMiddleRight, positionOnY: positionOnYBunkers);
            bunkerRight = new Bunker(positionOnX: _positionBunkerRight, positionOnY: positionOnYBunkers);

            
            //Affiche le vaisseau du joueur
            playerSpaceShip.Draw();

            //Affiche les bunkers
            bunkerRight.DrawBunker();
            bunkerMiddleRight.DrawBunker();
            bunkerMiddleLeft.DrawBunker();
            bunkerLeft.DrawBunker();

            //Ajoute les bunkers à la liste des objet du jeu
            GameObject.gameObjects.Add(bunkerLeft);
            GameObject.gameObjects.Add(bunkerMiddleLeft);
            GameObject.gameObjects.Add(bunkerMiddleRight);
            GameObject.gameObjects.Add(bunkerRight);

            //Ajoute les vaisseau ennemis à la ligne
            firstLine.AddEnemies();
            secondLine.AddEnemies();
            thirdLine.AddEnemies();

            //Affiche la ligne d'ennemi
            firstLine.DrawLine();
            secondLine.DrawLine();
            thirdLine.DrawLine();
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
