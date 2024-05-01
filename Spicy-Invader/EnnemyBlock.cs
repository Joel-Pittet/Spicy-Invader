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
        private int _baseWidth;

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
            _size.Width = _baseWidth;
        }

        /// <summary>
        /// Ajoute une nouvelle ligne de vaisseau ennemi
        /// </summary>
        /// <param name="nbShips">Nombre de vaisseau ennemi</param>
        /// <param name="nbLives">Nombre de vie</param>
        /// <param name="shipShape">Forme des ennemis</param>
        public void AddLine(int nbShips, int nbLives, string shipShape)
        {
            // Ajout des nouveaux vaisseaux ennemis
            for (int i = 0; i < nbShips; i++)
            {
                // Calcule la position sur l'axe X pour le nouveau vaisseau
                int positionEnemyOnX = _positionOnX + (i * (shipShape.Length + 1));

                // Crée et ajoute le vaisseau à l'ensemble
                SpaceShip enemy = new SpaceShip(positionEnemyOnX, _positionOnY + _numberOfLines, nbLives, shipShape);
                _enemyShips.Add(enemy);
            }

            //Incremente le nombre de ligne du bloc
            _numberOfLines++;
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
                enemyShip.Draw();
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
