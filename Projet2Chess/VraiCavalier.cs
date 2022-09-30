using System;
using System.Collections.Generic;

namespace Projet2Chess
{
    class VraiCavalier : Cavalier
    {
        public VraiCavalier(ConsoleColor laCouleur) : base(laCouleur)
        { }

        public override List<Coordonnee> DeterminerPositionsValides(Piece[,] lePlateau, Coordonnee maPosition)
        {
            /*  Définir les positions autour du cavalier dans une liste
             *  ConsoleColor couleur = la couleur du cavalier
             *  POUR chaque position autour
             *      SI la position n'est pas de la meme couleur
             *         Ajouter cette position a la liste
             */


            //throw new NotImplementedException();
            //Vous pouvez utiliser la ligne qui suit pour vérifier le comportement attendu
            return base.DeterminerPositionsValides(lePlateau, maPosition);
        }
    }
}
