using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spicy_Invader
{
    internal class EnemyBlock : SimpleObject
    {
        /// <summary>
        /// Liste pour stocker les lignes d'ennemis
        /// </summary>
        private List<EnemyLine> _block = new List<EnemyLine>();

        /// <summary>
        /// GETTER / SETTER
        /// Liste pour stocker les lignes d'ennemis
        /// </summary>
        public List<EnemyLine> Block
        {
            get
            {
                return _block;
            }
            set
            {
                _block = value;
            }
        }

        /// <summary>
        /// Première ligne du bloc
        /// </summary>
        private EnemyLine _firstLine;

        /// <summary>
        /// Deuxième ligne du bloc
        /// </summary>
        private EnemyLine _secondLine;

        /// <summary>
        /// Troisième ligne du bloc
        /// </summary>
        private EnemyLine _thirdLine;

        /// <summary>
        /// Quatrième ligne du bloc
        /// </summary>
        private EnemyLine _fourthLine;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="third"></param>
        public EnemyBlock(EnemyLine first, EnemyLine second, EnemyLine third, EnemyLine fourth)
        {
            _firstLine = first;
            _secondLine = second;
            _thirdLine = third;
            _fourthLine = fourth;

            AddLinesInblock();

            gameObjects.Add(this);
        }

        /// <summary>
        /// Met à jour les positions des vaisseau dans chaque lignes
        /// </summary>
        public override void Update()
        {
            foreach (EnemyLine line in _block)
            {
                line.Update();
            }
        }

        /// <summary>
        /// Ajoute les lignes dans la liste
        /// </summary>
        public void AddLinesInblock()
        {
            _block.Add(_firstLine);
            _block.Add(_secondLine);
            _block.Add(_thirdLine);
            _block.Add(_fourthLine);
        }

    }
}
