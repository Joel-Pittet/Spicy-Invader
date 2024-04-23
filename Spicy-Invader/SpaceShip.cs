///Auteur: Joël Pittet
///Date: 19.04.2024
///Lieu: Lausanne - ETML
///Description: Classe qui contient les méthodes concernant la partie "jeu" du programme

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
        /// Vitesse de déplacement du vaisseau
        /// </summary>
        //private int _spaceShipSpeed = 20;

        /// <summary>
        /// Enplacement maximum du vaisseau sur la droite de la fenêtre
        /// </summary>
        private int _maxPosRight;

        /// <summary>
        /// Enplacement maximum du vaisseau sur la gauche de la fenêtre
        /// </summary>
        private int _maxPosLeft;

        //Missile pour que le joueur puisse tirer avec le vaisseau
        Missile missile;

        /// <summary>
        /// Constructeur avec position sur l'axe X, nombre de vies et forme du vaisseau
        /// </summary>
        /// <param name="positionOnX">Position sur l'axe X</param>
        /// <param name="nbLives">Nombre de vies</param>
        /// <param name="spaceShipShape">Forme du vaisseau</param>
        public SpaceShip(int positionOnX, double positionOnY, int nbLives, string spaceShipShape)
        {
            PositionOnX = positionOnX;
            PositionOnY = positionOnY;
            NumberOfLives = nbLives;
            ObjectShape = spaceShipShape;
            _maxPosLeft = spaceShipShape.Length - spaceShipShape.Length - 1;
            _maxPosRight = Console.WindowWidth - spaceShipShape.Length + 2;

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
                //Change la position du vaisseau de 1 à gauche
                PositionOnX--;

                //Dessine le vaisseau
                Draw();

            }

            // Lorsque la flèche de droite est appuyée
            if (Keyboard.IsKeyDown(Key.Right) && (PositionOnX + 1) != _maxPosRight)
            {
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

        /// <summary>
        /// Tir du missile
        /// </summary>
        public void Shoot()
        {
            //Crée un missile pour la première fois
            if (missile == null)
            {
                //Donne les propriétés au missile
                missile = new Missile(positionOnX: PositionOnX + ObjectShape.Length / 2, positionOnY: PositionOnY - 1, numberOfLives: 1, shape: "|");

                //Ajoute le missile aux objets du jeu
                gameObjects.Add(missile);
            }
            //Lorsque le missile est mort
            //On le retire de la liste et on crée un nouveau missile qu'on ajoute dans la liste
            else if (missile.IsAlive() == false)
            {
                //Retire le missile de la liste des objets du jeu
                gameObjects.Remove(missile);

                //Donne les propriétés au missile
                missile = new Missile(positionOnX: PositionOnX + ObjectShape.Length / 2, positionOnY: PositionOnY - 1, numberOfLives: 1, shape: "|");

                //Ajoute le missile aux objets du jeu
                gameObjects.Add(missile);

            }

        }

    }
}
