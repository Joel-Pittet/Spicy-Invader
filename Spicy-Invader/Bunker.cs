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
        /// Constructeur
        /// </summary>
        /// <param name="positionOnX">Position du bunker sur l'axe X</param>
        /// <param name="positionOnY">Position du bunker sur l'axe Y</param>
        public Bunker(double positionOnX, double positionOnY)
        {
            PositionOnX = Convert.ToInt32(positionOnX);
            PositionOnY = positionOnY;
        }

        /// <summary>
        /// Dessine le bunker
        /// </summary>
        public void DrawBunker()
        {
            //Forme du bunker
            string bunkerTop = ("XXXXX");
            string bunkerMiddle = ("XXXXXXX");
            string bunkerBottom = ("XXXXXXXXX");

            //Étages du bunker
            const int NB_BUNKER_FLOOR = 3;

            for (int i = 0; i < NB_BUNKER_FLOOR; i++)
            {
                if (i == 0)
                {
                    //Position initiale du bunker
                    Console.SetCursorPosition(PositionOnX, Convert.ToInt32(PositionOnY));

                    //Dessine le haut du bunker
                    Console.WriteLine(bunkerTop);

                    // Ajouter les positions des "X" dans bunkerTop à la liste
                    for (int j = 0; j < bunkerTop.Length; j++)
                    {
                        positions.Add(new Tuple<int, int>(PositionOnX + j, Convert.ToInt32(PositionOnY)));
                    }
                }
                else if (i == 1)
                {
                    //Décale de 1 l'apparition de l'étage suivant pour un effet pyramide
                    PositionOnX--;

                    //Position initiale du bunker sur l'axe X
                    Console.CursorLeft = PositionOnX;

                    //Descend le curseur de 1 pour afficher le niveau suivant en dessous du précédent
                    PositionOnY++;

                    //Position sur l'axe Y
                    Console.CursorTop = Convert.ToInt32(PositionOnY);

                    //Dessine le milieu des bunkers
                    Console.WriteLine(bunkerMiddle);

                    // Ajouter les positions des "X" dans bunkerMiddle à la liste
                    for (int j = 0; j < bunkerMiddle.Length; j++)
                    {
                        positions.Add(new Tuple<int, int>(PositionOnX + j, Convert.ToInt32(PositionOnY)));
                    }
                }
                
                else if (i == 2)
                {
                    //Décale de 1 l'apparition de l'étage suivant pour un effet pyramide
                    PositionOnX--;

                    //Position initiale du bunker
                    Console.CursorLeft = PositionOnX;

                    //Descend le curseur de 1 pour afficher le niveau suivant en dessous du précédent
                    PositionOnY++;

                    //Position sur l'axe Y
                    Console.CursorTop = Convert.ToInt32(PositionOnY);

                    //Dessine le bas des bunkers
                    Console.WriteLine(bunkerBottom);

                    // Ajouter les positions des "X" dans bunkerBottom à la liste
                    for (int j = 0; j < bunkerBottom.Length; j++)
                    {
                        positions.Add(new Tuple<int, int>(PositionOnX + j, Convert.ToInt32(PositionOnY)));
                    }
                }
            }

        }

        public override void Update()
        {
               
        }
    }
}
