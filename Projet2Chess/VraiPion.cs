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
            /*   int mouvement = -1
             *   int range = 7
             *   SI la couleur est blanche
             *   mouvement = 1
             *   range 2
             *   SI la rangée est plus petite que 8 et plus grande que 1
             *      SI la position en Y + mouvement est vide
             *              ajouter cette position a la liste
             *              SI premier mouvement( position == range) 
             *                  SI les positions en Y + mouvement et (Y + mouvement) + couleur sont vide
             *                      ajouter la deuxieme position à la liste
             *      SI la colone est plus grande que 1
             *          SI la position en Y+mouvement X+1 est occupée par un ennemi
             *              ajouter cette position a la liste
             *      SI la colone est plus petite que 7
             *          SI la position en Y+ mouvement X-1 est occupée par un ennemi
             *               ajouter cette position a la liste
             *          
            */
            List<Coordonnee> coordonneesValides = new List<Coordonnee>();
            int mouvement = -1, range = 7;
            ConsoleColor couleur = ConsoleColor.Black;
            if (this.couleurPiece == ConsoleColor.White)
            {
                couleur = ConsoleColor.White;
                mouvement = 1;
                range = 2;
            }

            if (maPosition.Y < 8 && maPosition.Y > 1)
            {
                if (VerifCaseVide(maPosition.X, maPosition.Y + mouvement))
                {
                    if (maPosition.Y == range) VerifCaseVide(maPosition.X, (maPosition.Y + mouvement) + mouvement);
                }

                if (maPosition.X < 1)
                {
                    VerifCaseEnnemie(maPosition.X + 1, maPosition.Y + mouvement);
                }
                if (maPosition.X > 7)
                {
                    VerifCaseEnnemie(maPosition.X - 1, maPosition.Y + mouvement);
                }
            }

            bool VerifCaseVide(int x, int y)
            {
                if (typeof(PieceVide) == lePlateau[x, y].GetType())
                {
                    coordonneesValides.Add(new Coordonnee(x, y));
                    return true;
                }
                return false;
            }

            void VerifCaseEnnemie(int x, int y)
            {
                if ((couleur == ConsoleColor.White && lePlateau[x,y].couleurPiece == ConsoleColor.Black) || (couleur == ConsoleColor.Black && lePlateau[x,y].couleurPiece == ConsoleColor.White))
                {
                    coordonneesValides.Add(new Coordonnee(x, y));
                }
            }

            return coordonneesValides;
            //throw new NotImplementedException();
            //Vous pouvez utiliser la ligne qui suit pour vérifier le comportement attendu
            //return base.DeterminerPositionsValides(lePlateau, maPosition);
        }

    }
}
