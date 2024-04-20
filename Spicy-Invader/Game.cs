///Auteur: Joël Pittet
///Date: 19.04.2024
///Lieu: Lausanne - ETML
///Description: Classe qui contient les méthodes concernant la partie "jeu" du programme

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invader
{
    internal class Game
    {

        //Crée le vaisseau du joueur
        SpaceShip playerSpaceShip = new SpaceShip(positionOnX: Console.WindowWidth / 2, positionOnY: Console.WindowHeight / 1.1, nbLives: 3 ,spaceShipShape: "---|---");
         
        /// <summary>
        /// Affiche tous les objets du jeu sur la console
        /// </summary>
        public void DrawGame()
        {
            //Affiche le vaisseau du joueur
            playerSpaceShip.Draw();

            //Pour que le jeu s'arrete seulement si le vaisseau du joueur est mort
            do
            {
                //Met à jour la position du vaisseau et le réaffiche
                playerSpaceShip.Update();


            } while (playerSpaceShip.IsAlive() == true);
            

           //Console.ReadLine();
        }

        /// <summary>
        /// Permet de jouer
        /// </summary>
        public void PlayGame()
        {
           
        }
    }
}
