///Auteur: Joël Pittet
///Date: 19.04.2024
///Lieu: Lausanne - ETML
///Description: Classe qui contient les méthodes et attributs concernant les vaisseaux du jeu

using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Spicy_Invader
{
    
    internal class SpaceShip : SimpleObject
    {

        /// <summary>
        /// Enplacement maximum du vaisseau sur la droite de la fenêtre
        /// </summary>
        private int _maxPosRight;

        /// <summary>
        /// Enplacement maximum du vaisseau sur la gauche de la fenêtre
        /// </summary>
        //private int _maxPosLeft = 0;

        //Missile pour que le joueur puisse tirer avec le vaisseau
        Missile missile = new Missile(positionOnX: 0, positionOnY: 0, numberOfLives:0, shape:"");

        /// <summary>
        /// Constructeur avec position sur l'axe X et Y, nombre de vies et forme du vaisseau
        /// </summary>
        /// <param name="positionOnX">Position sur l'axe X</param>
        /// <param name="positionOnY">Position sur l'axe </param>
        /// <param name="nbLives">Nombre de vies</param>
        /// <param name="spaceShipShape">Forme du vaisseau</param>
        public SpaceShip(int positionOnX, int positionOnY, int nbLives, string spaceShipShape)
        {
            PositionOnX = positionOnX;
            PositionOnY = positionOnY;
            NumberOfLives = nbLives;
            ObjectShape = spaceShipShape;
            _maxPosRight = Console.WindowWidth - spaceShipShape.Length + 1;

            //Ajoute le vaisseau à la liste des objets du jeu
            gameObjects.Add(this);
        }

        /// <summary>
        /// Mise à jour de la position des vaisseaux ennemis
        /// </summary>
        public override void Update()
        {

        }

        /// <summary>
        /// Tir du missile ennemi
        /// </summary>
        public void Shoot()
        {
            //Nouveau missile chaque fois que le nombre de vie est à zéro
            if (missile.NumberOfLives == 0)
            {
                //Donne les propriétés au missile
                missile = new Missile(positionOnX: PositionOnX + ObjectShape.Length / 2, positionOnY: PositionOnY - 1, numberOfLives: 1, shape: "|");

                //Ajoute le missile aux objets du jeu
                gameObjects.Add(missile);

            }

        }

        /// <summary>
        /// Efface l'ancienne position du missile
        /// </summary>
        public void ClearSpaceShip()
        {
            //Place le curseur à la position du vaisseau pour l'effacer
            Console.SetCursorPosition(PositionOnX, PositionOnY);

            //Affiche des espaces pour cacher l'ancienne position du vaisseau
            Console.WriteLine("       ");

        }

    }
}
