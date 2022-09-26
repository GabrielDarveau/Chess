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
             * Si la couleur est blanc
             *      Faire
             *          Si la case du haut est vide et qu'elle est dans les limites du plateau
             *              Ajouter cette case à la liste des positions valides
             *              valide = vrai
             *          Sinon si la case du haut n'est pas vide et que la couleur est noir
             *              Ajouter cette case à la liste des positions valides
             *              valide = faux
             *          Sinon
             *              valide = faux
             *      Tant que valide = vrai
             *      
             *      Faire
             *          Si la case du bas est vide et qu'elle est dans les limites du plateau
             *              Ajouter cette case à la liste des positions valides
             *              valide = vrai
             *          Sinon si la case du bas n'est pas vide et que la couleur est noir
             *              Ajouter cette case à la liste des positions valides
             *              valide = faux
             *          Sinon
             *              valide = faux
             *      Tant que valide = vrai
             *      
             *      Faire
             *          Si la case de droite est vide et qu'elle est dans les limites du plateau
             *              Ajouter cette case à la liste des positions valides
             *              valide = vrai
             *          Sinon si la case de droite n'est pas vide et que la couleur est noir
             *              Ajouter cette case à la liste des positions valides
             *              valide = faux
             *          Sinon
             *              valide = faux
             *      Tant que valide = vrai
             *      
             *      Faire
             *          Si la case de gauche est vide et qu'elle est dans les limites du plateau
             *              Ajouter cette case à la liste des positions valides
             *              valide = vrai
             *          Sinon si la case de gauche n'est pas vide et que la couleur est noir
             *              Ajouter cette case à la liste des positions valides
             *              valide = faux
             *          Sinon
             *              valide = faux
             *      Tant que valide = vrai
             *
             *  
             *  
             *  
             *  Sinon
             *      Faire
             *          Si la case du haut est vide et qu'elle est dans les limites du plateau
             *              Ajouter cette case à la liste des positions valides
             *              valide = vrai
             *          Sinon si la case du haut n'est pas vide et que la couleur est blanc
             *              Ajouter cette case à la liste des positions valides
             *              valide = faux
             *          Sinon
             *              valide = faux
             *      Tant que valide = vrai
             *      
             *      Faire
             *          Si la case du bas est vide et qu'elle est dans les limites du plateau
             *              Ajouter cette case à la liste des positions valides
             *              valide = vrai
             *          Sinon si la case du bas n'est pas vide et que la couleur est blanc
             *              Ajouter cette case à la liste des positions valides
             *              valide = faux
             *          Sinon
             *              valide = faux
             *      Tant que valide = vrai
             *      
             *      Faire
             *          Si la case de droite est vide et qu'elle est dans les limites du plateau
             *              Ajouter cette case à la liste des positions valides
             *              valide = vrai
             *          Sinon si la case de droite n'est pas vide et que la couleur est blanc
             *              Ajouter cette case à la liste des positions valides
             *              valide = faux
             *          Sinon
             *              valide = faux
             *      Tant que valide = vrai
             *      
             *      Faire
             *          Si la case de gauche est vide et qu'elle est dans les limites du plateau
             *              Ajouter cette case à la liste des positions valides
             *              valide = vrai
             *          Sinon si la case de gauche n'est pas vide et que la couleur est blanc
             *              Ajouter cette case à la liste des positions valides
             *              valide = faux
             *          Sinon
             *              valide = faux
             *      Tant que valide = vrai
             */

            //throw new NotImplementedException();
            //Vous pouvez utiliser la ligne qui suit pour vérifier le comportement attendu

            bool valide = false;
            int x, y;
            x = maPosition.X;
            y = maPosition.Y;
            List<Coordonnee> maListe = new List<Coordonnee>();

            ColHaut(valide, x, y, lePlateau, maListe);
            ColBas(valide, x, y, lePlateau, maListe);
            LigneDroite(valide, x, y, lePlateau, maListe);
            LigneGauche(valide, x, y, lePlateau, maListe);


            return maListe;
            //return base.DeterminerPositionsValides(lePlateau, maPosition);
        }
        void ColHaut(bool valide, int x, int y, Piece[,] lePlateau, List<Coordonnee> maListe)
        {
            do
            {
                if (y - 1 > 0 && couleurPiece == ConsoleColor.White)
                {
                    if (lePlateau[x, y - 1].GetType() == typeof(PieceVide))
                    {
                        maListe.Add(new Coordonnee(x, y - 1));
                        valide = true;
                        y--;
                    }
                    else if (lePlateau[x, y--].GetType() != typeof(PieceVide) && lePlateau[x, y - 1].couleurPiece == ConsoleColor.Black)
                    {
                        maListe.Add(new Coordonnee(x, y - 1));
                        valide = false;
                    }
                    else
                        valide = false;
                }
                else if (y - 1 > 0 && couleurPiece == ConsoleColor.Black)
                {
                    if (lePlateau[x, y - 1].GetType() == typeof(PieceVide))
                    {
                        maListe.Add(new Coordonnee(x, y - 1));
                        valide = true;
                        y--;
                    }
                    else if (lePlateau[x, y - 1].GetType() != typeof(PieceVide) && lePlateau[x, y - 1].couleurPiece == ConsoleColor.White)
                    {
                        maListe.Add(new Coordonnee(x, y - 1));
                        valide = false;
                    }
                    else
                        valide = false;
                }
            } while (valide);
        }
        void ColBas(bool valide, int x, int y, Piece[,] lePlateau, List<Coordonnee> maListe)
        {
            do
            {
                if (y + 1 < 8 && couleurPiece == ConsoleColor.White)
                {
                    if (lePlateau[x, y + 1].GetType() == typeof(PieceVide))
                    {
                        maListe.Add(new Coordonnee(x, y + 1));
                        valide = true;
                        y++;
                    }
                    else if (lePlateau[x, y + 1].GetType() != typeof(PieceVide) && lePlateau[x, y + 1].couleurPiece == ConsoleColor.Black)
                    {
                        maListe.Add(new Coordonnee(x, y + 1));
                        valide = false;
                    }
                    else
                        valide = false;
                }
                else if (y + 1 < 8 && couleurPiece == ConsoleColor.Black)
                {
                    if (lePlateau[x, y + 1].GetType() == typeof(PieceVide))
                    {
                        maListe.Add(new Coordonnee(x, y + 1));
                        valide = true;
                        y++;
                    }
                    else if (lePlateau[x, y + 1].GetType() != typeof(PieceVide) && lePlateau[x, y + 1].couleurPiece == ConsoleColor.White)
                    {
                        maListe.Add(new Coordonnee(x, y + 1));
                        valide = false;
                    }
                    else
                        valide = false;
                }
            } while (valide);
        }
        void LigneDroite(bool valide, int x, int y, Piece[,] lePlateau, List<Coordonnee> maListe)
        {
            do
            {
                if (x + 1 < 8 && couleurPiece == ConsoleColor.White)
                {
                    if (lePlateau[x + 1, y].GetType() == typeof(PieceVide))
                    {
                        maListe.Add(new Coordonnee(x + 1, y));
                        valide = true;
                        x++;
                    }
                    else if (lePlateau[x + 1, y].GetType() != typeof(PieceVide) && lePlateau[x + 1, y].couleurPiece == ConsoleColor.Black)
                    {
                        maListe.Add(new Coordonnee(x + 1, y));
                        valide = false;
                    }
                    else
                        valide = false;
                }
                else if (x + 1 < 8 && couleurPiece == ConsoleColor.Black)
                {
                    if (lePlateau[x + 1, y].GetType() == typeof(PieceVide))
                    {
                        maListe.Add(new Coordonnee(x + 1, y));
                        valide = true;
                        x++;
                    }
                    else if (lePlateau[x + 1, y].GetType() != typeof(PieceVide) && lePlateau[x + 1, y].couleurPiece == ConsoleColor.White)
                    {
                        maListe.Add(new Coordonnee(x + 1, y));
                        valide = false;
                    }
                    else
                        valide = false;
                }
            } while (valide);
        }
        void LigneGauche(bool valide, int x, int y, Piece[,] lePlateau, List<Coordonnee> maListe)
        {
            do
            {
                if (x - 1 > 0 && couleurPiece == ConsoleColor.White)
                {
                    if (lePlateau[x - 1, y].GetType() == typeof(PieceVide))
                    {
                        maListe.Add(new Coordonnee(x - 1, y));
                        valide = true;
                        x--;
                    }
                    else if (lePlateau[x - 1, y].GetType() != typeof(PieceVide) && lePlateau[x - 1, y].couleurPiece == ConsoleColor.Black)
                    {
                        maListe.Add(new Coordonnee(x - 1, y));
                        valide = false;
                    }
                    else
                        valide = false;
                }
                else if (x - 1 > 0 && couleurPiece == ConsoleColor.Black)
                {
                    if (lePlateau[x - 1, y].GetType() == typeof(PieceVide))
                    {
                        maListe.Add(new Coordonnee(x - 1, y));
                        valide = true;
                        x--;
                    }
                    else if (lePlateau[x - 1, y].GetType() != typeof(PieceVide) && lePlateau[x - 1, y].couleurPiece == ConsoleColor.White)
                    {
                        maListe.Add(new Coordonnee(x - 1, y));
                        valide = false;
                    }
                    else
                        valide = false;
                }
            } while (valide);
        }
    }
}
