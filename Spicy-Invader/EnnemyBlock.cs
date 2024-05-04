///Auteur: Joël Pittet
///Date: 29.04.2024
///Lieu: Lausanne - ETML
///Description: Classe qui contient les méthodes et attributs concernant les blocs d'ennemis

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Spicy_Invader
{
    internal class EnnemyBlock : GameObject
    {
        /// <summary>
        /// //Instanciation de la liste de vaisseau d'ennemi
        /// </summary>
        private List<SpaceShip> _enemyShips = new List<SpaceShip>();

        /// <summary>
        /// Largeur initial du bloc d'ennemi 
        /// </summary>
        private double _baseWidth;

        /// <summary>
        /// Taille du bloc
        /// </summary>
        private Size _size;

        /// <summary>
        /// GETTER / SETTER
        /// Taille du bloc
        /// </summary>
        public Size Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
            }
        }

        /// <summary>
        /// Position du bloc sur l'axe X
        /// </summary>
        private int _positionOnX;

        /// <summary>
        /// GETTER / SETTER
        /// Position du bloc sur l'axe X
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
        /// Position du bloc sur l'axe Y
        /// </summary>
        private int _positionOnY;

        /// <summary>
        /// Position du bloc sur l'axe Y
        /// </summary>
        public int PositionOnY
        {
            get
            {
                return _positionOnY;
            }
            set
            {
                _positionOnY = value;
            }
        }

        /// <summary>
        /// Nombre de ligne du bloc
        /// </summary>
        private int _numberOfLines = 0;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="positionOnX">Position du bloc sur l'axe X</param>
        /// <param name="positionOnY">Position du bloc sur l'axe Y</param>
        /// <param name="size">Taille du bloc</param>
        public EnnemyBlock(int positionOnX, int positionOnY, Size size)
        {
            _positionOnX = positionOnX;
            _positionOnY = positionOnY;
            _size = size;
            _baseWidth = _size.Width;
        }

        /// <summary>
        /// Ajoute une nouvelle ligne de vaisseau ennemi
        /// </summary>
        /// <param name="nbShips">Nombre de vaisseau ennemi</param>
        /// <param name="nbLives">Nombre de vie</param>
        /// <param name="shipShape">Forme des ennemis</param>
        public void AddLine(int nbShips, int nbLives, string shipShape)
        {
            //Nombre de vaisseau maximum de la taille donnée que le bloc peut accepter
            double nbMaxShips = _baseWidth / shipShape.Length;

            //Converti en int pour faciliter l'usage
            int nbMaxShipsInInt = Convert.ToInt32(nbMaxShips);

            //Espace entre les ennemis en double
            double spaceBetweenShipsInDouble;

            //Espace entre les ennemis en int
            int spaceBetweenShipsInInt = 0;

            //Si le nombre d'ennemi est accepter, calcule l'espace entre les vaisseau
            if (nbMaxShipsInInt < nbShips)
            {
                //Calcule l'espace entre les vaisseau
                 spaceBetweenShipsInDouble = _baseWidth / (nbShips + 1);

                //Converti en int pour simplifier l'utilisation
                 spaceBetweenShipsInInt = Convert.ToInt32(spaceBetweenShipsInDouble);
                
            }

            //Si les vaisseau peuvent s'afficher dans le bloc avec l'espace entre chaque vaisseau
            if (_baseWidth >= nbShips * shipShape.Length + nbShips * spaceBetweenShipsInInt)
            {
                //Sépare la largeur du bloc pour voir à quelle distance placer les ennemi de façon homogène
                double positionSpaceShip = _baseWidth / (nbShips + 1);

                //Converti l'espace entre les vaisseaux pour qu'il reste équivalent indépendament du nombre de fois utilisé
                int positionSpaceShipInInt = Convert.ToInt32(positionSpaceShip);

                // Ajout des nouveaux vaisseaux ennemis
                for (int i = 0; i < nbShips; i++)
                {
                    //Positionne chaque ennemi à sa place sur la ligne
                    int shipPositionOnXJustify = _positionOnX + (positionSpaceShipInInt * (i + 1) - shipShape.Length / 2);

                    //Crée et ajoute le vaisseau à l'ensemble
                    SpaceShip enemy = new SpaceShip(shipPositionOnXJustify, _positionOnY + _numberOfLines, nbLives, shipShape);
                    _enemyShips.Add(enemy);
                }

                //Incremente le nombre de ligne du bloc
                _numberOfLines = _numberOfLines + 2;
            }
            

            /*//Sépare la largeur du bloc pour voir à quelle distance placer les ennemi de façon homogène
            double positionSpaceShip = _baseWidth / (nbShips + 1);

            //Converti l'espace entre les vaisseaux pour qu'il reste équivalent indépendament du nombre de fois utilisé
            int positionSpaceShipInInt = Convert.ToInt32(positionSpaceShip);

            if (_baseWidth >= positionSpaceShipInInt * nbShips + nbShips * shipShape.Length)
            {
                // Ajout des nouveaux vaisseaux ennemis
                for (int i = 0; i < nbShips; i++)
                {
                    //Positionne chaque ennemi à sa place sur la ligne
                    int shipPositionOnXJustify = _positionOnX + (positionSpaceShipInInt * (i + 1) - shipShape.Length / 2);

                    //Crée et ajoute le vaisseau à l'ensemble
                    SpaceShip enemy = new SpaceShip(shipPositionOnXJustify, _positionOnY + _numberOfLines, nbLives, shipShape);
                    _enemyShips.Add(enemy);
                }

                //Incremente le nombre de ligne du bloc
                _numberOfLines = _numberOfLines + 2;
            }*/
        }
    

        /// <summary>
        /// Recalcule la taille et la position du bloc d'ennemi
        /// </summary>
        public void UpdateSize()
        {
            
        }


        /// <summary>
        /// Dessine le bloc d'ennemi
        /// </summary>
        public override void Draw()
        {
            // Parcours tous les vaisseaux ennemis et dessine chaque vaisseau
            foreach (SpaceShip enemyShip in _enemyShips)
            {
                enemyShip.DrawAndStockPositions();
            }
        }

        /// <summary>
        /// Met à jour la position du bloc d'ennemi
        /// </summary>
        public override void Update()
        {
           
        }

        /// <summary>
        /// Retourne vrai si le vaisseau est en vie
        /// </summary>
        /// <returns>Retourne vrai si le vaisseau est en vie</returns>
        public override bool IsAlive()
        {
           return true;
        }
        

    }
}
