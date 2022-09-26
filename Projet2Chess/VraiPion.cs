using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet2Chess
{
    class VraiPion : Pion
    {
        public VraiPion(ConsoleColor laCouleur) : base(laCouleur)
        { }

        public override List<Coordonnee> DeterminerPositionsValides(Piece[,] lePlateau, Coordonnee maPosition)
        {
            /* int couleur = -1
             * SI la couleur est blanche
             *   couleur = 1
             *      SI premier mouvement
             *          SI la position en Y + couleur est vide et plus petite que les limites du tableau
             *              ajouter cette position a la liste
             *          SI les positions en Y + couleur et (Y + couleur) + couleur sont vide et plus petites que les limites du tableau
             *              ajouter la deuxieme position à la liste
             *      SINON
             *          SI la position en Y + couleur est vide et plus petite que les limites du tableau
             *              ajouter cette position a la liste
             *      SI la position en Y+couleur X+1 est occupée par un ennemi
             *          ajouter cette position a la liste
             *      SI la position en Y+ couleur X-1 est occupée par un ennemi
             *          ajouter cette position a la liste
            */


            //throw new NotImplementedException();
            //Vous pouvez utiliser la ligne qui suit pour vérifier le comportement attendu
            return base.DeterminerPositionsValides(lePlateau, maPosition);
        }

    }
}
