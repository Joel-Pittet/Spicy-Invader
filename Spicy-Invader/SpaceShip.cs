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

        //Missile pour que le joueur puisse tirer avec le vaisseau
        Missile missile = new Missile(positionOnX: 0, positionOnY: 0, numberOfLives:0, shape:"");

        /// <summary>
        /// Direction du vaisseau ennemi
        /// </summary>
        private bool _isRight = true;

        /// <summary>
        /// GETTER / SETTER
        /// Direction du vaisseau ennemi
        /// </summary>
        public bool IsRight
        {
            get
            {
                return _isRight;
            }
            set
            {
                _isRight = value;
            }
        }

        /// <summary>
        /// Stocke chaque positions des caractère composant de l'ennemi
        /// </summary>
        private List<Tuple<int, int>> _everyCharOfSpaceShip = new List<Tuple<int, int>>();

        /// <summary>
        /// GETTER / SETTER
        /// Stocke chaque positions des caractère composant de l'ennemi
        /// </summary>
        public List<Tuple<int, int>> EveryCharOfSpaceShip
        {
            get
            {
                return _everyCharOfSpaceShip;
            }
            set
            {
                _everyCharOfSpaceShip = value;
            }
        }

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
        }

        /// <summary>
        /// Mise à jour de la position de l'ennemi
        /// </summary>
        public override void Update()
        {
            //Efface la ligne d'ennemis
            Clear();

            //Fais bouger la ligne d'ennemis
            Move();

            //affiche la ligne d'ennemis et stocke les positions des ennemis
            DrawAndStockPositions();
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
        /// Déplacement de l'ennemi
        /// </summary>
        public void Move()
        {
            if (_isRight)
            {
                PositionOnX++;
            }
            else
            {
                PositionOnX--;
            }
        }

        /// <summary>
        /// Efface la position de l'ennemi
        /// </summary>
        public void Clear()
        {
            Console.SetCursorPosition(PositionOnX, PositionOnY);
            Console.Write(new string(' ', ObjectShape.Length));
        }

        /// <summary>
        /// Affiche l'ennemi en parcourant chaque caractère et stocke la position de chaque caractère
        /// </summary>
        public void DrawAndStockPositions()
        {
            //Instancie à chaque déplacement une nouvelle liste
            _everyCharOfSpaceShip = new List<Tuple<int, int>>();

            //Position de chaque caractère
            Tuple<int, int> characterPositions;

            //position du caractère sur l'axe X
            int charPositionX = PositionOnX;

            //Récupère la position de chaque caractère de l'ennemi et le stocke puis l'affiche
            for (int i = 0; i < ObjectShape.Length; i++)
            {
                //Position du charactère
                Console.SetCursorPosition(charPositionX, PositionOnY);

                //Position X et Y du charactère
                characterPositions = new Tuple<int, int>(charPositionX, PositionOnY);

                //Ajoute la position du charactère à la liste
                _everyCharOfSpaceShip.Add(characterPositions);

                //Affiche le caractère
                Console.WriteLine(ObjectShape[i]);

                //Incrémente la position X des caractère de 1 pour placer le prochain caractère
                charPositionX++;
            }
        }
    }
}
