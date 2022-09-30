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
            /*      Si la couleur de la case n'égale pas blanc
             *          La couleur ennemie est blanc
             *      Sinon
             *          La couleur ennemie est noir
             *          
             *          
             *      Fonctions:
             *          
             *      Pour la colonne vers le haut à partir de la position
             *          Si la case du haut est vide
             *              Ajouter cette case à la liste des positions valides
             *          Sinon si la case du haut n'est pas vide et que la couleur de la pièce est ennemie
             *              Ajouter cette case à la liste des positions valides
             *              Sortir
             *          Sinon si la case du haut n'est pas vide et que la couleur de la pièce est alliée
             *              Sortir
             *      
             *      Pour la colonne vers le bas à partir de la position
             *          Si la case du bas est vide
             *              Ajouter cette case à la liste des positions valides
             *          Sinon si la case du bas n'est pas vide et que la couleur de la pièce est ennemie
             *              Ajouter cette case à la liste des positions valides
             *              Sortir
             *          Sinon si la case du bas n'est pas vide et que la couleur de la pièce est alliée
             *              Sortir
             *      
             *      Pour la ligne vers la droite à partir de la position
             *          Si la case de droite est vide
             *              Ajouter cette case à la liste des positions valides
             *          Sinon si la case de droite n'est pas vide et que la couleur de la pièce est ennemie
             *              Ajouter cette case à la liste des positions valides
             *              Sortir
             *          Sinon si la case de droite n'est pas vide et que la couleur de la pièce est alliée
             *              Sortir
             *              
             *      Pour la ligne vers la gauche à partir de la position
             *          Si la case de gauche est vide
             *              Ajouter cette case à la liste des positions valides
             *          Sinon si la case de gauche n'est pas vide et que la couleur de la pièce est ennemie
             *              Ajouter cette case à la liste des positions valides
             *              Sortir
             *          Sinon si la case de gauche n'est pas vide et que la couleur de la pièce est alliée
             *              Sortir
             */

            //throw new NotImplementedException();
            //Vous pouvez utiliser la ligne qui suit pour vérifier le comportement attendu

            List<Coordonnee> maListe = new List<Coordonnee>();
            ConsoleColor coulEnnemi;

            //Obtenir la couleur ennemie
            if(lePlateau[maPosition.X, maPosition.Y].couleurPiece != ConsoleColor.White)
            {
                coulEnnemi = ConsoleColor.White;
            }
            else
            {
                coulEnnemi = ConsoleColor.Black;
            }

            //Appel des fonctions qui vérifient les déplacements
            ColHaut(lePlateau, maPosition, maListe, coulEnnemi);
            ColBas(lePlateau, maPosition, maListe, coulEnnemi);
            LigneDroite(lePlateau, maPosition, maListe, coulEnnemi);
            LigneGauche(lePlateau, maPosition, maListe, coulEnnemi);

            //Retour de la liste des déplacements
            return maListe;

            //return base.DeterminerPositionsValides(lePlateau, maPosition);
        }
        /// <summary>
        /// Vérifier les déplacements disponibles vers le haut
        /// </summary>
        /// <param name="lePlateau"></param>
        /// <param name="maPosition"></param>
        /// <param name="mesPositions"></param>
        /// <param name="coulEnnemi"></param>
        private void ColHaut(Piece[,] lePlateau, Coordonnee maPosition, List<Coordonnee> mesPositions, ConsoleColor coulEnnemi)
        {
            //Boucler sur la colonne à partir de la position de la pièce
            for (int i = maPosition.Y - 1; i >= 0; i--)
            {
                //Conditions pour obtenir les déplacements
                if (lePlateau[maPosition.X, i] is PieceVide)
                {
                    mesPositions.Add(new Coordonnee(maPosition.X, i));
                }
                else if (lePlateau[maPosition.X, i].couleurPiece == coulEnnemi)
                {
                    mesPositions.Add(new Coordonnee(maPosition.X, i));
                    break; //Sortir
                }
                else if (lePlateau[maPosition.X, i].couleurPiece == lePlateau[maPosition.X, maPosition.Y].couleurPiece)
                {
                    break; //Sortir
                }
            }
        }
        /// <summary>
        /// Vérifier les déplacements disponibles vers le bas
        /// </summary>
        /// <param name="lePlateau"></param>
        /// <param name="maPosition"></param>
        /// <param name="mesPositions"></param>
        /// <param name="coulEnnemi"></param>
        private void ColBas(Piece[,] lePlateau, Coordonnee maPosition, List<Coordonnee> mesPositions, ConsoleColor coulEnnemi)
        {
            //Boucler sur la colonne à partir de la position de la pièce
            for (int i = maPosition.Y + 1; i <= 7; i++)
            {
                //Conditions pour obtenir les déplacements
                if (lePlateau[maPosition.X, i] is PieceVide)
                {
                    mesPositions.Add(new Coordonnee(maPosition.X, i));
                }
                else if (lePlateau[maPosition.X, i].couleurPiece == coulEnnemi)
                {
                    mesPositions.Add(new Coordonnee(maPosition.X, i));
                    break; //Sortir
                }
                else if (lePlateau[maPosition.X, i].couleurPiece == lePlateau[maPosition.X, maPosition.Y].couleurPiece)
                {
                    break; //Sortir
                }
            }
        }
        /// <summary>
        /// Vérifier les déplacements disponibles vers la droite
        /// </summary>
        /// <param name="lePlateau"></param>
        /// <param name="maPosition"></param>
        /// <param name="mesPositions"></param>
        /// <param name="coulEnnemi"></param>
        private void LigneDroite(Piece[,] lePlateau, Coordonnee maPosition, List<Coordonnee> mesPositions, ConsoleColor coulEnnemi)
        {
            //Boucler sur la ligne à partir de la position de la pièce
            for (int i = maPosition.X + 1; i <= 7; i++)
            {
                //Conditions pour obtenir les déplacements
                if (lePlateau[i, maPosition.Y] is PieceVide)
                {
                    mesPositions.Add(new Coordonnee(i, maPosition.Y));
                }
                else if (lePlateau[i, maPosition.Y].couleurPiece == coulEnnemi)
                {
                    mesPositions.Add(new Coordonnee(i, maPosition.Y));
                    break; //Sortir
                }
                else if (lePlateau[i, maPosition.Y].couleurPiece == lePlateau[maPosition.X, maPosition.Y].couleurPiece)
                {
                    break; //Sortir
                }
            }
        }
        /// <summary>
        /// Vérifier déplacements vers la gauche
        /// </summary>
        /// <param name="lePlateau"></param>
        /// <param name="maPosition"></param>
        /// <param name="mesPositions"></param>
        /// <param name="coulEnnemi"></param>
        private void LigneGauche(Piece[,] lePlateau, Coordonnee maPosition, List<Coordonnee> mesPositions, ConsoleColor coulEnnemi)
        {
            //Boucler sur la ligne à partir de la position de la pièce
            for (int i = maPosition.X - 1; i >= 0; i--)
            {
                //Conditions pour obtenir les déplacements
                if (lePlateau[i, maPosition.Y] is PieceVide)
                {
                    mesPositions.Add(new Coordonnee(i, maPosition.Y));
                }
                else if (lePlateau[i, maPosition.Y].couleurPiece == coulEnnemi)
                {
                    mesPositions.Add(new Coordonnee(i, maPosition.Y));
                    break; //Sortir
                }
                else if (lePlateau[i, maPosition.Y].couleurPiece == lePlateau[maPosition.X, maPosition.Y].couleurPiece)
                {
                    break; //Sortir
                }
            }
        }
    }
}
