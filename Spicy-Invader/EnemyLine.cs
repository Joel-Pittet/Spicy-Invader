using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invader
{
    internal class EnemyLine : SimpleObject
    {
        /// <summary>
        /// Nombre d'ennemi sur la ligne
        /// </summary>
        private int _nbEnemies;

        /// <summary>
        /// Forme des ennemis
        /// </summary>
        private string _enemyShape;

        /// <summary>
        /// Liste d'ennemi
        /// </summary>
        private List<SpaceShip> _enemies = new List<SpaceShip>();

        /// <summary>
        /// GETTER / SETTER
        /// Liste d'ennemi
        /// </summary>
        public List<SpaceShip> Enemies
        {
            get
            {
                return _enemies;
            }
            set
            {
                _enemies = value;
            }
        }

        /// <summary>
        /// Position des ennemi, le premier au milieu de la console
        /// </summary>
        private int _posEnemyOnXInLine = Console.WindowWidth / 2;

        /// <summary>
        /// Ecart de la ligne par rapport au haut de la console lors de l'affichage au début
        /// </summary>
        private int _levelLineInBlock = 0;

        /// <summary>
        /// Limite de la console à gauche, permet de gérer la ligne si elle touche le bord de la console
        /// </summary>
        private int _limitLeftConsole = 0;

        /// <summary>
        /// Savoir si la ligne a touché le bord de la fenêtre
        /// </summary>
        private bool _hasTouchedSide = false;

        /// <summary>
        /// Savoir si les ennemis ont changé de direction de déplacement
        /// </summary>
        private bool _hasChangedDirection = false;

        /// <summary>
        /// Savoir si le premier vaisseau a touché le bord droit 
        /// pour pouvoir garder l'espacement avec les autres de meme taille
        /// </summary>
        private bool _hasEnemyZeroChangedSide = false;

        /// <summary>
        /// Position de chaque caractère des ennemis de la ligne
        /// </summary>
        private List<List<Tuple<int,int>>> _charsOfEnemiesLine = new List<List<Tuple<int,int>>>();

        /// <summary>
        /// GETTER / SETTER
        /// Position de chaque caractère des ennemis de la ligne
        /// </summary>
        public List<List<Tuple<int, int>>> CharsOfEnemiesLine
        {
            get
            {
                return _charsOfEnemiesLine;
            }
            set
            {
                _charsOfEnemiesLine = value;
            }
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nbEnemies">nombre d'ennemi sur la ligne</param>
        /// <param name="enemyShape">forme de l'ennemi</param>
        public EnemyLine(int nbEnemies, string enemyShape, int levelLine)
        {
            _nbEnemies = nbEnemies;
            _enemyShape = enemyShape;
            _levelLineInBlock = levelLine;
        }

        /// <summary>
        /// Ajoute les ennemis de la ligne dans une liste
        /// </summary>
        public void AddEnemies()
        {
            for (int i = 0; i < _nbEnemies; i++)
            {
                SpaceShip newEnemy = new SpaceShip(positionOnX: _posEnemyOnXInLine, positionOnY: _levelLineInBlock, nbLives: 3, spaceShipShape: _enemyShape);

                _posEnemyOnXInLine = _enemyShape.Length * 2 + _posEnemyOnXInLine;

                _enemies.Add(newEnemy);
            }
        }

        /// <summary>
        /// Affiche les ennemis de la ligne sur la console au début du jeu
        /// Stocke les positions de chaque caractère de chaque ennemis
        /// </summary>
        public void DrawLine()
        {
            foreach (SpaceShip enemy in _enemies)
            {
                enemy.DrawAndStockPositions();

                //Reset la liste
                _charsOfEnemiesLine = new List<List<Tuple<int, int>>>();

                //Ajoute les positions à la liste
                _charsOfEnemiesLine.Add(enemy.EveryCharOfSpaceShip);
            }
        }

        /// <summary>
        /// Mise à jour des déplacement des ennemis et changement de direction
        /// </summary>
        public override void Update()
        {
            //Si le bord à été touché alors efface la ligne, descend la ligne et change de direction les ennemis
            if (_hasTouchedSide)
            {
                ClearLine();
                _hasTouchedSide = false;
                ChangeSide();
                _hasChangedDirection = true;
                MoveLine();

            }
            else
            {
                MoveLine();
                _hasChangedDirection = false;
            }

        }

        /// <summary>
        /// Mouvement des ennemis de la ligne
        /// </summary>
        public void MoveLine()
        {
            //Reset la liste des positions des caractère des ennemis
            _charsOfEnemiesLine = new List<List<Tuple<int, int>>>();

            //Si le bord gauche à été touché par l'ennemi tout à gauche alors lui rajoute une position,
            //sinon l'espacement grandi à chaque fois qu'il touche le bord gauche
            if (_hasEnemyZeroChangedSide)
            {
                _enemies[0].PositionOnX++;
                _hasEnemyZeroChangedSide = false;
            }

            //Met à jour la position de tous les ennemis, gère les limites déplacement pour pas qu'il sortent de l^écran
            foreach (SpaceShip enemy in _enemies)
            {
                //Limite droite
                if (_enemies[_enemies.Count - 1].PositionOnX + enemy.ObjectShape.Length >= Console.WindowWidth && !_hasChangedDirection)
                {
                    _hasTouchedSide = true;
                    break;

                }
                //Limite gauche
                else if (_enemies[0].PositionOnX <= _limitLeftConsole && !_hasChangedDirection)
                {
                    _hasTouchedSide = true;
                    _hasEnemyZeroChangedSide = true;
                    break;
                }

                enemy.Update();

                _charsOfEnemiesLine.Add(enemy.EveryCharOfSpaceShip);

            }
        }

        /// <summary>
        /// Change le coté de déplacement de la ligne
        /// </summary>
        public void ChangeSide()
        {
            foreach (SpaceShip enemy in _enemies)
            {
                enemy.PositionOnY++;

                enemy.IsRight = !enemy.IsRight;
            }
        }

        /// <summary>
        /// Efface une ligne d'ennemis
        /// </summary>
        public void ClearLine()
        {
            foreach (SpaceShip enemy in _enemies)
            {
                enemy.Clear();
            }
        }
    }
}

