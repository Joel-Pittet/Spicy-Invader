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
        private int _speed = 25;

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
            //Place le curseur à la position du missile pour l'effacer
            Console.SetCursorPosition(PositionOnX, Convert.ToInt32(PositionOnY));

            //Affiche un espace pour cacher l'ancienne position du missile
            Console.WriteLine(" ");

            //Change la position du missile
            PositionOnY = PositionOnY - 1;

            //Place le curseur à la nouvelle position du missile
            Console.SetCursorPosition(PositionOnX, Convert.ToInt32(PositionOnY));

            //Dessine le missile
            Draw();

            //Vitesse d'affichage du missile
            Thread.Sleep(_speed);

            //Rapelle la méthode pour continuer le déplacement du missile
            Update();
        }
    }
}
