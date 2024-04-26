///Auteur: Joël Pittet
///Date: 22.04.2024
///Lieu: Lausanne - ETML
///Description: Classe qui contient les attributs et les méthodes concernant les bunkers
///
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invader
{
    internal class Bunker : SimpleObject
    {

        /// <summary>
        /// Etage supérieur du bunker
        /// </summary>
        private string _bunkerTop = ("XXXXX");

        /// <summary>
        /// GETTER / SETTER
        /// Etage supérieur du bunker
        /// </summary>
        public string BunkerTop
        {
            get
            {
                return _bunkerTop;
            }
            set
            {
                _bunkerTop = value;
            }
        }

        /// <summary>
        /// Etage du milieu du bunker
        /// </summary>
        private string _bunkerMiddle = ("XXXXXXX");

        /// <summary>
        /// GETTER / SETTER
        /// Etage du milieu du bunker
        /// </summary>
        public string BunkerMiddle
        {
            get
            {
                return _bunkerMiddle;
            }
            set
            {
                _bunkerMiddle = value;
            }
        }

        /// <summary>
        /// Etage inférieur du bunker
        /// </summary>
        private string _bunkerBottom = ("XXXXXXXXX");

        /// <summary>
        /// GETTER / SETTER
        /// Etage inférieur du bunker
        /// </summary>
        public string BunkerBottom
        {
            get
            {
                return _bunkerBottom;
            }
            set
            {
                _bunkerBottom = value;
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
        /// Dessine le bunker
        /// </summary>
        public void DrawBunker()
        {

            //Étages du bunker
            const int NB_BUNKER_FLOOR = 3;

            for (int i = 0; i < NB_BUNKER_FLOOR; i++)
            {
                if (i == 0)
                {

                    //Parcourt l'étage supérieur du bunker et affiche chaque caractère les un apres les autres
                    //Ajoute leurs position dans un tuple cela sert à gérer les colisions
                    for (int j = 0; j < _bunkerTop.Length; j++)
                    {
                        
                        //Position du caractère à ecrire
                        Console.SetCursorPosition(PositionOnX, PositionOnY);

                        //Ajoute la position du caractère dans le tuple
                        ObjectToTouchPositions.Add(new Tuple<int, int>(PositionOnX, PositionOnY));

                        //Ecrit un "X" du bunker
                        Console.Write(_bunkerTop[j]);

                        //Place le prochain caractère à coté de celui écrit
                        PositionOnX++;

                    }

                    //Remet la position au dernier caractère de l'étage
                    PositionOnX--;
                }
                
                else if (i == 1)
                {
                    //Descend le curseur de 1 pour afficher le niveau suivant en dessous du précédent
                    PositionOnY++;

                    //Remet la position sur X un cran avant le dernier etage (effet pyramide)
                    PositionOnX = PositionOnX - _bunkerTop.Length;

                    // Ajouter les positions des "X" dans bunkerMiddle à la liste
                    for (int j = 0; j < _bunkerMiddle.Length; j++)
                    {

                        //Position du caractère
                        Console.SetCursorPosition(PositionOnX, PositionOnY);

                        //Ajoute la position du caractère dans le tuple
                        ObjectToTouchPositions.Add(new Tuple<int, int>(PositionOnX, PositionOnY));

                        //Ecrit un "X" du bunker
                        Console.Write(_bunkerMiddle[j]);

                        //Place le prochain caractère à coté de celui écrit
                        PositionOnX++;

                    }

                    //Remet la position au dernier caractère de l'étage
                    PositionOnX--;
                }
                else if (i == 2)
                {
                    //Descend le curseur de 1 pour afficher le niveau suivant en dessous du précédent
                    PositionOnY++;

                    //Décale de 1 l'apparition de l'étage suivant pour un effet pyramide
                    PositionOnX = PositionOnX - _bunkerMiddle.Length;

                    // Ajouter les positions des "X" dans bunkerBottom à la liste
                    for (int j = 0; j < _bunkerBottom.Length; j++)
                    {
                        //Place le curseur pour afficher le carctère
                        Console.SetCursorPosition(PositionOnX, PositionOnY);

                        //Ajoute la position du caractère dans le tuple
                        ObjectToTouchPositions.Add(new Tuple<int, int>(PositionOnX, PositionOnY));

                        //Dessine le bas des bunkers
                        Console.Write(_bunkerBottom[j]);

                        //Place le prochain caractère à coté de celui écrit
                        PositionOnX++;
                    }
                }
            }

        }

        public override void Update()
        {
               
        }
    }
}
