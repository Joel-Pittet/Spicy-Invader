///Auteur: Joël Pittet
///Date: 19.04.2024
///Lieu: Lausanne - ETML
///Description: Classe abstraite qui contient les méthodes et attributs "Obligatoires" pour les objets du jeu

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleToAttribute("UnitTests")]

namespace Spicy_Invader
{
    public abstract class SimpleObject : GameObject
    {
        /// <summary>
        /// Forme de l'objet
        /// </summary>
        private string _objectShape;

        /// <summary>
        /// GETTER / SETTER
        /// Forme de l'objet
        /// </summary>
        public string ObjectShape
        {
            get
            {
                return _objectShape;
            }
            set
            {
                _objectShape = value;
            }
        }

        /// <summary>
        /// Position de l'objet sur l'axe X
        /// </summary>
        private int _positionOnX;

        /// <summary>
        /// GETTER / SETTER
        /// Position de l'objet sur l'axe X
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
        /// Position de l'objet sur l'axe Y
        /// </summary>
        private int _positionOnY;

        /// <summary>
        /// GETTER / SETTER
        /// Position de l'objet sur l'axe Y
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
        /// Affichage des objets du jeu
        /// </summary>
        public override void Draw()
        {
            //Position de l'objet
            Console.SetCursorPosition(PositionOnX, PositionOnY);

            //Affiche l'objet
            Console.WriteLine(ObjectShape);
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
        /// Crée une liste pour stocker les positions des "X" des bunkers
        /// </summary>
        public List<Tuple<int, int>> charBunkerPositions = new List<Tuple<int, int>>();


    }
}
