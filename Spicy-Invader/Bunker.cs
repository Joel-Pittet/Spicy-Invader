///Auteur: Joël Pittet
///Date: 22.04.2024
///Lieu: Lausanne - ETML
///Description: Classe qui contient les attributs et les méthodes concernant les bunkers
///
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleToAttribute("UnitTests")]

namespace Spicy_Invader
{
    internal class Bunker : SimpleObject
    {

        /// <summary>
        /// Etage supérieur du bunker
        /// </summary>
        private string _topFloor = ("XXXXX");

        /// <summary>
        /// GETTER / SETTER
        /// Etage supérieur du bunker
        /// </summary>
        public string TopFloor
        {
            get
            {
                return _topFloor;
            }
            set
            {
                _topFloor = value;
            }
        }

        /// <summary>
        /// Etage du milieu du bunker
        /// </summary>
        private string _middleFloor = ("XXXXXXX");

        /// <summary>
        /// GETTER / SETTER
        /// Etage du milieu du bunker
        /// </summary>
        public string MiddleFloor
        {
            get
            {
                return _middleFloor;
            }
            set
            {
                _middleFloor = value;
            }
        }

        /// <summary>
        /// Etage inférieur du bunker
        /// </summary>
        private string _bottomFloor = ("XXXXXXXXX");

        /// <summary>
        /// GETTER / SETTER
        /// Etage inférieur du bunker
        /// </summary>
        public string BottomFloor
        {
            get
            {
                return _bottomFloor;
            }
            set
            {
                _bottomFloor = value;
            }
        }

       
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="positionOnX">Position du bunker sur l'axe X</param>
        /// <param name="positionOnY">Position du bunker sur l'axe Y</param>
        public Bunker(int positionOnX, int positionOnY)
        {
            PositionOnX = positionOnX;
            PositionOnY = positionOnY;
        }

        /// <summary>
        /// Dessine un bunker sur la console
        /// </summary>
        public void DrawBunker()
        {

            //Étages du bunker
            const int NB_BUNKER_FLOOR = 3;

            for (int i = 0; i < NB_BUNKER_FLOOR; i++)
            {
                if (i == 0)
                {
                    DrawBunkerFloor(_topFloor);
                }
                else if (i == 1)
                {
                    //Descend le curseur de 1 pour afficher le niveau suivant en dessous du précédent
                    PositionOnY++;

                    //Remet la position sur X un cran avant le dernier etage (effet pyramide)
                    PositionOnX = PositionOnX - _topFloor.Length;

                    DrawBunkerFloor(_middleFloor);

                }
                else if (i == 2)
                {
                    //Descend le curseur de 1 pour afficher le niveau suivant en dessous du précédent
                    PositionOnY++;

                    //Décale de 1 l'apparition de l'étage suivant pour un effet pyramide
                    PositionOnX = PositionOnX - _middleFloor.Length;

                    DrawBunkerFloor(_bottomFloor);
                }
            }

        }

        /// <summary>
        /// Affiche un étage du bunker passé en paramètre
        /// </summary>
        /// <param name="bunkerFloor">Etage du bunker à afficher</param>
        public void DrawBunkerFloor(string bunkerFloor)
        {
            //Parcourt l'étage supérieur du bunker et affiche chaque caractère les un apres les autres
            //Ajoute leurs position dans un tuple cela sert à gérer les colisions
            for (int j = 0; j < bunkerFloor.Length; j++)
            {

                //Position du caractère à ecrire
                Console.SetCursorPosition(PositionOnX, PositionOnY);

                //Ajoute la position du caractère dans le tuple
                charBunkerPositions.Add(new Tuple<int, int>(PositionOnX, PositionOnY));

                //Ecrit un "X" du bunker
                Console.Write(bunkerFloor[j]);

                //Place le prochain caractère à coté de celui écrit
                PositionOnX++;

            }

            //Remet la position au dernier caractère de l'étage
            PositionOnX--;
        }

        

        public override void Update()
        {
               
        }
    }
}
