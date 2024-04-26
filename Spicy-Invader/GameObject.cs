﻿///Auteur: Joël Pittet
///Date: 19.04.2024
///Lieu: Lausanne - ETML
///Description: Classe abstraite qui contient les méthodes "Obligatoire" pour chaque objet du jeu 
///             et une liste des objets du jeu pour les faire intéragir entre eux
///
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invader
{
    abstract class GameObject
    {

        /// <summary>
        /// Affichage des objets du jeu
        /// </summary>
        public abstract void Draw();

        /// <summary>
        /// Verification de l'état - vivant / mort - des objets du jeu
        /// </summary>
        public abstract bool IsAlive();

        /// <summary>
        /// Mise à jour de la position des objet du jeu
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// Gère la colision entre le missile et les objets du jeu
        /// </summary>
        /// <param name="missile">Missile</param>
        public abstract void Collision(Missile missile);

    }
}
