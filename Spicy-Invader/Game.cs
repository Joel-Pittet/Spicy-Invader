///Auteur: Joël Pittet
///Date: 19.04.2024
///Lieu: Lausanne - ETML
///Description: Classe qui contient les méthodes concernant la partie "jeu" du programme

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

[assembly: InternalsVisibleToAttribute("UnitTests")]

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
        /// Score de la partie
        /// </summary>
        private int _score = 0;

        /// <summary>
        /// GETTER / SETTER
        /// Score de la partie
        /// </summary>
        public int Score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
            }
        }

        /// <summary>
        /// Meilleur score du jeu
        /// </summary>
        private int _highscore = 0;

        /// <summary>
        /// GETTER / SETTER
        /// Meilleur score du jeu
        /// </summary>
        public int Highscore
        {
            get
            {
                return _highscore;
            }
            set
            {
                _highscore = value;
            }
        }

        /// <summary>
        /// Ligne d'ennemis
        /// </summary>
        static EnemyLine firstLine = new EnemyLine(nbEnemies: 4, enemyShape: ".-=o=-.", levelLine: 2);
        static EnemyLine secondLine = new EnemyLine(nbEnemies: 4, enemyShape: ".-=o=-.", levelLine: 3);
        static EnemyLine thirdLine = new EnemyLine(nbEnemies: 4, enemyShape: ".-=o=-.", levelLine: 4);
        static EnemyLine fourthLine = new EnemyLine(nbEnemies: 4, enemyShape: ".-=o=-.", levelLine: 5);

        /// <summary>
        /// Block d'ennemis
        /// </summary>
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
            //Place le curseur pour afficher le highscore
            Console.SetCursorPosition(3, 0);

            //Affiche le highscore
            Console.WriteLine("HighScore: " + _score);

            //Place le curseur pour afficher le score
            Console.SetCursorPosition(Console.WindowWidth / 2 - 6, 0);

            //Affiche le score
            Console.WriteLine("Score: " + _score);

            //Place le curseur pour afficher la vie du vaissea
            Console.SetCursorPosition(Console.WindowWidth - 10, 0);

            //Affiche la vie du vaisseau
            Console.WriteLine("Vie(s): " + playerSpaceShip.NumberOfLives);

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
            fourthLine.AddEnemies();

            //Affiche la ligne d'ennemi
            firstLine.DrawLine();
            secondLine.DrawLine();
            thirdLine.DrawLine();
            fourthLine.DrawLine();
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
