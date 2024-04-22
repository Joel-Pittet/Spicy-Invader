///Auteur: Joël Pittet
///Date: 19.04.2024
///Lieu: Lausanne - ETML
///Description: Classe qui contient les attributs et les méthodes concernant les missiles

using System;
using System.Collections.Generic;
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
        private int _speed = 17;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="positionOnX">Position du missile sur l'axe X</param>
        /// <param name="positionOnY">Position du missile sur l'axe Y</param>
        /// <param name="numberOfLives">Nombre de vie du missile</param>
        /// <param name="shape">Forme du missile</param>
        public Missile(int positionOnX, double positionOnY, int numberOfLives, string shape)
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
            //Vérifie que le tir puisse être fait sans sortir de la console
            //si oui, le fait
            //Si non, fait mourir le missile et l'efface
            if (PositionOnY - 1 >= 0)
            {
                //Efface la position précédente du missile
                ClearMissile();

                //Change la position du missile
                PositionOnY--;

                //Dessine le missile
                Draw();

                //Vitesse d'affichage du missile
                Thread.Sleep(_speed);

            }
            else
            {
                //Efface le missile
                ClearMissile();

                //Fait mourir le missile pour qu'un autre puisse être tiré
                NumberOfLives = 0;
            }

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
