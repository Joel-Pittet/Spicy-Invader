///Auteur: Joël Pittet
///Date: 19.04.2024
///Lieu: Lausanne - ETML
///Description: Classe qui contient les attributs et les méthodes concernant les missiles

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Spicy_Invader
{
    internal class Missile : SimpleObject
    {

        /// <summary>
        /// Vitesse de déplacement du missile
        /// </summary>
        //private int _speed = 17;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="positionOnX">Position du missile sur l'axe X</param>
        /// <param name="positionOnY">Position du missile sur l'axe Y</param>
        /// <param name="numberOfLives">Nombre de vie du missile</param>
        /// <param name="shape">Forme du missile</param>
        public Missile(int positionOnX, int positionOnY, int numberOfLives, string shape)
        {
            PositionOnX = positionOnX;
            PositionOnY = positionOnY;
            NumberOfLives = numberOfLives;
            ObjectShape = shape;
        }

        /// <summary>
        /// Met à jour la position du missile sur la console
        /// </summary>
        public override void Update()
        {
            //Vérifie si un bunker à été touché
            bool hasTouchedBunker = CheckColisionWithBunker();

            //Vérifie si un ennemi à été touché
            bool hasTouchedEnemy = CheckColisionWithEnemies();

            if (hasTouchedBunker || hasTouchedEnemy)
            {

                //Efface le missile
                ClearMissile();

                //Fait mourir le missile pour qu'un autre puisse être tiré
                NumberOfLives = 0;
   
            }
            else if (hasTouchedBunker == false && hasTouchedEnemy == false && PositionOnY - 1 >= 0)
            {
                //Efface la position précédente du missile
                ClearMissile();

                //Change la position du missile
                PositionOnY--;

                //Dessine le missile
                Draw();

            }else if (hasTouchedBunker == false && hasTouchedEnemy == false && PositionOnY - 1 < 0)
            {
                //Efface le missile
                ClearMissile();

                //Fait mourir le missile pour qu'un autre puisse être tiré
                NumberOfLives = 0;
            }

            //Si le nombre de vie est à zéro, alors enlève le missile de la liste
            //des objetss du jeu et efface sa position
            if (NumberOfLives == 0)
            {
                gameObjects.Remove(this);
                ClearMissile();
            }

        }

        /// <summary>
        /// Verifie si le missile à touché le bunker
        /// </summary>
        /// <returns>TRUE si le bunker à été touché</returns>
        public bool CheckColisionWithBunker()
        {
            //True si une partie du bunker à été touchée
            bool hasTouched = false;

            //Colision avec les bunkers
            foreach (Bunker bunker in gameObjects.OfType<Bunker>())
            {
                for (int i = 0; i < bunker.charBunkerPositions.Count; i++)
                {

                    // Vérifie si le missile entre en collision avec une position de bunker
                    if (PositionOnX == bunker.charBunkerPositions[i].Item1 && PositionOnY == bunker.charBunkerPositions[i].Item2 && !hasTouched)
                    {
                        hasTouched = true;

                        bunker.charBunkerPositions.Remove(bunker.charBunkerPositions[i]);

                        return hasTouched;

                    }

                }
            }

            return hasTouched;
        }

        /// <summary>
        /// Controle la colision entre le missile et les ennemis
        /// </summary>
        /// <returns>True si un des caractère d'un ennemi à été touché</returns>
        public bool CheckColisionWithEnemies()
        {
            //True si une partie du bunker à été touchée
            bool hasTouched = false;

            //Colision avec les ennemis
            foreach (EnemyBlock mainBlock in gameObjects.OfType<EnemyBlock>())
            {
                //Pour chaque ligne du bloc
                foreach (EnemyLine line in mainBlock.Block)
                {
                    //Pour chaque liste de Tuple dans une ligne
                    foreach (List<Tuple<int, int>> listeLine in line.CharsOfEnemiesLine)
                    {
                        //pour chaque position de caractère d'un ennemi
                        foreach (Tuple<int, int> enemyPositions in listeLine)
                        {
                            //Si le missile rencontre l'ennemi, efface le missile
                            if (enemyPositions.Item1 == PositionOnX && enemyPositions.Item2 == PositionOnY)
                            {
                                hasTouched = true;

                                //pour chaque ennemi dans la ligne
                                foreach (SpaceShip enemy in line.Enemies.ToList())
                                {
                                    //pour chaque position de caractère de l'ennemi
                                    foreach (Tuple<int, int> positionEnemyChars in enemy.EveryCharOfSpaceShip.ToList())
                                    {
                                        if (positionEnemyChars.Item1 == enemyPositions.Item1 && positionEnemyChars.Item2 == enemyPositions.Item2)
                                        {
                                            enemy.NumberOfLives = 0;

                                            enemy.Clear();

                                            line.Enemies.Remove(enemy);
                                            break;
                                        }
                                    }
                                }

                                return hasTouched;
                            }
                        }
                    }
                }
            }

            return hasTouched;
        }





        /// <summary>
        /// Efface l'ancienne position du missile
        /// </summary>
        public void ClearMissile()
        {
            //Place le curseur à la position du missile pour l'effacer
            Console.SetCursorPosition(PositionOnX, Convert.ToInt32(PositionOnY));

            //Affiche un espace pour cacher l'ancienne position du missile
            Console.WriteLine(" ");

        }

    }
}
