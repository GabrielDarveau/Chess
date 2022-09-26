using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet2Chess
{
    class VraieTour : Tour
    {
        public VraieTour(ConsoleColor laCouleur) : base(laCouleur)
        { }

        public override List<Coordonnee> DeterminerPositionsValides(Piece[,] lePlateau, Coordonnee maPosition)
        {
            /* valide : Booléen
             * Si la couleur est blanche
             *      Faire
             *          Si la case du haut est vide et qu'elle est dans les limites du plateau
             *              Ajouter cette case à la liste des positions valides
             *              valide = vrai
             *          Sinon
             *              valide = faux
             *      Tant que valide = vrai
             *      
             *      Faire
             *          Si la case du bas est vide et qu'elle est dans les limites du plateau
             *              Ajouter cette case à la liste des positions valides
             *              valide = vrai
             *          Sinon
             *              valide = faux
             *      Tant que valide = vrai
             *      
             *      Faire
             *          Si la case de droite est vide et qu'elle est dans les limites du plateau
             *              Ajouter cette case à la liste des positions valides
             *              valide = vrai
             *          Sinon
             *              valide = faux
             *      Tant que valide = vrai
             *      
             *      Faire
             *          Si la case de gauche est vide et qu'elle est dans les limites du plateau
             *              Ajouter cette case à la liste des positions valides
             *              valide = vrai
             *          Sinon
             *              valide = faux
             *      Tant que valide = vrai
             *
             *
             */

            //throw new NotImplementedException();
            //Vous pouvez utiliser la ligne qui suit pour vérifier le comportement attendu
            return base.DeterminerPositionsValides(lePlateau, maPosition);
        }
        
    }
}
