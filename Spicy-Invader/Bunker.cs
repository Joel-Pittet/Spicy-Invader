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

                    //Parcourt l'étage supérieur du bunker et affiche chaque caractère les un apres les autres
                    //Ajoute leurs position dans un tuple cela sert à gérer les colisions
                    for (int j = 0; j < bunkerTop.Length; j++)
                    {
                        
                        //Position du caractère à ecrire
                        Console.SetCursorPosition(PositionOnX, Convert.ToInt32(PositionOnY));

                        //Ajoute la position du caractère dans le tuple
                        ObjectToTouchPositions.Add(new Tuple<int, int>(PositionOnX, Convert.ToInt32(PositionOnY)));

                        //Ecrit un "X" du bunker
                        Console.Write(bunkerTop[j]);

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
                    PositionOnX = PositionOnX - bunkerTop.Length;

                    // Ajouter les positions des "X" dans bunkerMiddle à la liste
                    for (int j = 0; j < bunkerMiddle.Length; j++)
                    {

                        //Position du caractère
                        Console.SetCursorPosition(PositionOnX, Convert.ToInt32(PositionOnY));

                        //Ajoute la position du caractère dans le tuple
                        ObjectToTouchPositions.Add(new Tuple<int, int>(PositionOnX, Convert.ToInt32(PositionOnY)));

                        //Ecrit un "X" du bunker
                        Console.Write(bunkerMiddle[j]);

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
                    PositionOnX = PositionOnX - bunkerMiddle.Length;

                    // Ajouter les positions des "X" dans bunkerBottom à la liste
                    for (int j = 0; j < bunkerBottom.Length; j++)
                    {
                        //Place le curseur pour afficher le carctère
                        Console.SetCursorPosition(PositionOnX, Convert.ToInt32(PositionOnY));

                        //Ajoute la position du caractère dans le tuple
                        ObjectToTouchPositions.Add(new Tuple<int, int>(PositionOnX, Convert.ToInt32(PositionOnY)));

                        //Dessine le bas des bunkers
                        Console.Write(bunkerBottom[j]);

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
