///Auteur: Joël Pittet
///Date: 29.04.2024
///Lieu: Lausanne - ETML
///Description: Classe qui contient les méthodes et attributs concernant le vaisseau du joueur

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
    internal class PlayerSpaceShip : SpaceShip
    {

        /// <summary>
        /// Enplacement maximum du vaisseau sur la droite de la fenêtre
        /// </summary>
        private int _maxPosRight;

        /// <summary>
        /// Enplacement maximum du vaisseau sur la gauche de la fenêtre
        /// </summary>
        private int _maxPosLeft = 0;

        //Missile pour que le joueur puisse tirer avec le vaisseau
        Missile missile = new Missile(positionOnX: 0, positionOnY: 0, numberOfLives: 0, shape: "");

        /// <summary>
        /// Constructeur avec position sur l'axe X et Y, nombre de vies et forme du vaisseau
        /// </summary>
        /// <param name="positionOnX">Position sur l'axe X</param>
        /// <param name="positionOnY">Position sur l'axe Y</param>
        /// <param name="nbLives">Nombre de vies</param>
        /// <param name="SpaceShipShape">Forme du vaisseau</param>
        public PlayerSpaceShip(int positionOnX, int positionOnY, int nbLives, string SpaceShipShape) : base(positionOnX, positionOnY, nbLives, SpaceShipShape)
        {
            PositionOnX = positionOnX;
            PositionOnY = positionOnY;
            NumberOfLives = nbLives;
            ObjectShape = SpaceShipShape;
            _maxPosRight = Console.WindowWidth - SpaceShipShape.Length + 1;

            //Ajoute le vaisseau à la liste des objets du jeu
            gameObjects.Add(this);
        }

        /// <summary>
        /// Mise à jour de la position du vaisseau et tir du missile
        /// </summary>
        public override void Update()
        {

            //Lorsque la flèche de gauche est appuyée
            if (Keyboard.IsKeyDown(Key.Left) && (PositionOnX - 1) != _maxPosLeft)
            {
                //efface l'ancienne position
                ClearSpaceShip();

                //Change la position du vaisseau de 1 à gauche
                PositionOnX--;

                //Dessine le vaisseau
                Draw();

            }

            // Lorsque la flèche de droite est appuyée
            if (Keyboard.IsKeyDown(Key.Right) && (PositionOnX + 1) != _maxPosRight)
            {
                //efface l'ancienne position
                ClearSpaceShip();

                //Change la position du vaisseau de 1 à droite
                PositionOnX++;

                //Dessine le vaisseau
                Draw();

            }

            //Tir un missile si la barre espace est enfoncée
            if (Keyboard.IsKeyDown(Key.Space))
            {
                //Tir
                Shoot();
            }

        }
    }
}
