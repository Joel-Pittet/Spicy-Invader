///Auteur: Joël Pittet
///Date: 19.04.2024
///Lieu: Lausanne - ETML
///Description: Classe qui contient les méthodes concernant la partie "jeu" du programme

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Spicy_Invader
{
    
    internal class SpaceShip : GameObject
    {

        /// <summary>
        /// Position initiale du vaisseau sur l'axe Y
        /// </summary>
        private double _STARTING_POSITION_ON_Y = Console.WindowHeight / 1.1;

        /// <summary>
        /// Forme du vaisseau
        /// </summary>
        private string _spaceShipShape;

        /// <summary>
        /// GETTER / SETTER
        /// Forme du vaisseau
        /// </summary>
        public string SpaceShipShape
        {
            get
            {
                return _spaceShipShape;
            }
            set
            {
                _spaceShipShape = value;
            }
        }

        /// <summary>
        /// Position du vaisseau sur l'axe X
        /// </summary>
        private int _positionOnX;
          
        /// <summary>
        /// GETTER / SETTER
        /// Position du vaisseau sur l'axe X
        /// </summary>
        public int PositionOnX
        {
            get
            {
                return _positionOnX;
            }
            set
            {
                _positionOnX = value;
            }
        }

        /// <summary>
        /// Nombre de vie du vaisseau
        /// </summary>
        private int _numberOfLives;

        /// <summary>
        /// GETTER / SETTER
        /// Nombre de vie du vaisseau
        /// </summary>
        public int NumberOfLives
        {
            get
            {
                return _numberOfLives;
            }
            set
            {
                _numberOfLives = value;
            }
        }

        /// <summary>
        /// Vitesse de déplacement du vaisseau
        /// </summary>
        private double _spaceShipSpeed = 1;

        /// <summary>
        /// Enplacement maximum du vaisseau sur la droite de la fenêtre
        /// </summary>
        private int _maxPosRight;

        /// <summary>
        /// Enplacement maximum du vaisseau sur la gauche de la fenêtre
        /// </summary>
        private int _maxPosLeft;


        /// <summary>
        /// Constructeur avec position sur l'axe X, nombre de vies et forme du vaisseau
        /// </summary>
        /// <param name="posX">Position sur l'axe X</param>
        /// <param name="nbLives">Nombre de vies</param>
        /// <param name="spaceShipShape">Forme du vaisseau</param>
        public SpaceShip(int posX, int nbLives, string spaceShipShape)
        {
            _positionOnX = posX;
            _numberOfLives = nbLives;
            _spaceShipShape = spaceShipShape;
            _maxPosLeft = spaceShipShape.Length - spaceShipShape.Length - 1;
            _maxPosRight = Console.WindowWidth - spaceShipShape.Length - 1;

            gameObjects.Add(this);
        }

        /// <summary>
        /// Affichage des objets du jeu
        /// </summary>
        public override void Draw()
        {
            //Position du vaisseau
            Console.SetCursorPosition(_positionOnX, Convert.ToInt32(_STARTING_POSITION_ON_Y));

            //Affiche le vaisseau et des espaces de chaque côtés pour que le vaisseau ne laisse pas de "trace"
            Console.WriteLine(" " + SpaceShipShape + " ");
        }

        /// <summary>
        /// Verification de l'état - vivant / mort - des objets du jeu
        /// </summary>
        public override bool IsAlive()
        {
            bool isAlive = false;

            if (NumberOfLives > 0)
            {
                isAlive = true;
            }

            return isAlive;
        }

        /// <summary>
        /// Mise à jour de la position des objet du jeu
        /// </summary>
        public override void Update()
        {

            //Lorsque la flèche de gauche est appuyée
            if (Keyboard.IsKeyDown(Key.Left) && (PositionOnX - 1) != _maxPosLeft)
            {
                //Change la position du vaisseau de 1 à gauche
                PositionOnX = PositionOnX - 1;

                //Patiente avant d'afficher le vaisseau, correspond à la vitesse du vaisseau
                Thread.Sleep(Convert.ToInt32(_spaceShipSpeed));

                //Dessine le vaisseau
                Draw();

            }// Lorsque la flèche de droite est appuyée
            else if (Keyboard.IsKeyDown(Key.Right) && (PositionOnX + 1) != _maxPosRight)
            {
                //Change la position du vaisseau de 1 à droite
                PositionOnX = PositionOnX + 1;

                // Patiente avant d'afficher le vaisseau, correspond à la vitesse du vaisseau
                Thread.Sleep(Convert.ToInt32(_spaceShipSpeed));

                //Dessine le vaisseau
                Draw();
            }
        }

    }
}
