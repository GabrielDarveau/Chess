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
            /*      Pour la colonne vers le haut à partir de la position
             *          Si la case du haut est vide
             *              Ajouter cette case à la liste des positions valides
             *          Sinon si la case du haut n'est pas vide et que la couleur de la pièce est enemie
             *              Ajouter cette case à la liste des positions valides
             *              Sortir
             *          Sinon
             *              Sortir
             *      
             *      Pour la colonne à partir vers le bas de la position
             *          Si la case du bas est vide
             *              Ajouter cette case à la liste des positions valides
             *          Sinon si la case du bas n'est pas vide et que la couleur de la pièce est enemie
             *              Ajouter cette case à la liste des positions valides
             *              Sortir
             *          Sinon
             *              Sortir
             *      
             *      Pour la ligne vers la droite à partir de la position
             *          Si la case de droite est vide
             *              Ajouter cette case à la liste des positions valides
             *          Sinon si la case de droite n'est pas vide et que la couleur de la pièce est enemie
             *              Ajouter cette case à la liste des positions valides
             *              Sortir
             *          Sinon
             *              Sortir
             *              
             *      Pour la ligne vers la gauche
             *          Si la case de gauche est vide
             *              Ajouter cette case à la liste des positions valides
             *          Sinon si la case de gauche n'est pas vide et que la couleur de la pièce est enemie
             *              Ajouter cette case à la liste des positions valides
             *              Sortir
             *          Sinon
             *              Sortir
             */

            //throw new NotImplementedException();
            //Vous pouvez utiliser la ligne qui suit pour vérifier le comportement attendu

            List<Coordonnee> maListe = new List<Coordonnee>();
            ConsoleColor coulEnemi = (lePlateau[maPosition.X, maPosition.Y].couleurPiece != ConsoleColor.White) ? ConsoleColor.White : ConsoleColor.Black;

            ColHaut(lePlateau, maPosition, maListe, coulEnemi);
            ColBas(lePlateau, maPosition, maListe, coulEnemi);
            LigneDroite(lePlateau, maPosition, maListe, coulEnemi);
            LigneGauche(lePlateau, maPosition, maListe, coulEnemi);

            
            return maListe;
            //return base.DeterminerPositionsValides(lePlateau, maPosition);
        }

        private static void ColHaut(Piece[,] lePlateau, Coordonnee maPosition, List<Coordonnee> mesPositions, ConsoleColor coulEnemi)
        {
            for (int i = maPosition.Y - 1; i >= 0; i--)
            {
                if (lePlateau[maPosition.X, i] is PieceVide)
                {
                    mesPositions.Add(new Coordonnee(maPosition.X, i));
                }

                if (lePlateau[maPosition.X, i].couleurPiece == coulEnemi)
                {
                    mesPositions.Add(new Coordonnee(maPosition.X, i));
                    break;
                }

                if (lePlateau[maPosition.X, i].couleurPiece == lePlateau[maPosition.X, maPosition.Y].couleurPiece)
                {
                    break;
                }
            }
        }
        private static void ColBas(Piece[,] lePlateau, Coordonnee maPosition, List<Coordonnee> mesPositions, ConsoleColor coulEnemi)
        {
            for (int i = maPosition.Y + 1; i <= 7; i++)
            {
                if (lePlateau[maPosition.X, i] is PieceVide)
                {
                    mesPositions.Add(new Coordonnee(maPosition.X, i));
                }

                if (lePlateau[maPosition.X, i].couleurPiece == coulEnemi)
                {
                    mesPositions.Add(new Coordonnee(maPosition.X, i));
                    break;
                }

                if (lePlateau[maPosition.X, i].couleurPiece == lePlateau[maPosition.X, maPosition.Y].couleurPiece)
                {
                    break;
                }
            }
        }
        private static void LigneDroite(Piece[,] lePlateau, Coordonnee maPosition, List<Coordonnee> mesPositions, ConsoleColor coulEnemi)
        {
            for (int i = maPosition.X + 1; i <= 7; i++)
            {
                if (lePlateau[i, maPosition.Y] is PieceVide)
                {
                    mesPositions.Add(new Coordonnee(i, maPosition.Y));
                }

                if (lePlateau[i, maPosition.Y].couleurPiece == coulEnemi)
                {
                    mesPositions.Add(new Coordonnee(i, maPosition.Y));
                    break;
                }

                if (lePlateau[i, maPosition.Y].couleurPiece == lePlateau[maPosition.X, maPosition.Y].couleurPiece)
                {
                    break;
                }
            }
        }
        private static void LigneGauche(Piece[,] lePlateau, Coordonnee maPosition, List<Coordonnee> mesPositions, ConsoleColor coulEnemi)
        {
            for (int i = maPosition.X - 1; i >= 0; i--)
            {
                if (lePlateau[i, maPosition.Y] is PieceVide)
                {
                    mesPositions.Add(new Coordonnee(i, maPosition.Y));
                }

                if (lePlateau[i, maPosition.Y].couleurPiece == coulEnemi)
                {
                    mesPositions.Add(new Coordonnee(i, maPosition.Y));
                    break;
                }

                if (lePlateau[i, maPosition.Y].couleurPiece == lePlateau[maPosition.X, maPosition.Y].couleurPiece)
                {
                    break;
                }
            }
        }
    }
}
