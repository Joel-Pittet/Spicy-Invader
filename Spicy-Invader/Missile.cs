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
            bool hasTouched = CheckColisionWithBunker();

            if (hasTouched == true)
            {

                //Efface le missile
                ClearMissile();

                //Fait mourir le missile pour qu'un autre puisse être tiré
                NumberOfLives = 0;
   
            }
            else if (hasTouched == false && PositionOnY - 1 >= 0)
            {
                //Efface la position précédente du missile
                ClearMissile();

                //Change la position du missile
                PositionOnY--;

                //Dessine le missile
                Draw();

            }else if (hasTouched == false && PositionOnY - 1 < 0)
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
            foreach (var bunker in SimpleObject.gameObjects.OfType<Bunker>())
            {

                for (int i = 0; i < bunker.ObjectToTouchPositions.Count; i++)
                {

                    // Vérifie si le missile entre en collision avec une position de bunker
                    if (PositionOnX == bunker.ObjectToTouchPositions[i].Item1 && PositionOnY == bunker.ObjectToTouchPositions[i].Item2 && !hasTouched)
                    {
                        hasTouched = true;

                        bunker.ObjectToTouchPositions.Remove(bunker.ObjectToTouchPositions[i]);

                        return hasTouched;

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
