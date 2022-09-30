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
             *      SI la position est a l'intérieur du plateau
             *          SI la position n'est pas de la meme couleur
             *              Ajouter cette position a la liste
             */
            List<Coordonnee> coordonneesValides = new List<Coordonnee>();
            //Ajoute toutes les cases ou le cavalier peut se rendre dans une liste
            List<Coordonnee> cases = new List<Coordonnee>();
            cases.Add(new Coordonnee(maPosition.X-2, maPosition.Y + 1));
            cases.Add(new Coordonnee(maPosition.X - 1, maPosition.Y + 2));
            cases.Add(new Coordonnee(maPosition.X + 1, maPosition.Y + 2));
            cases.Add(new Coordonnee(maPosition.X + 2, maPosition.Y +1));
            cases.Add(new Coordonnee(maPosition.X + 2, maPosition.Y - 1));
            cases.Add(new Coordonnee(maPosition.X + 1, maPosition.Y - 2));
            cases.Add(new Coordonnee(maPosition.X - 1, maPosition.Y - 2));
            cases.Add(new Coordonnee(maPosition.X - 2, maPosition.Y -1));

            ConsoleColor couleur = this.couleurPiece;

            //Vérifie chaque case
            foreach (Coordonnee caseAutour in cases)
            {
                VerifCase(caseAutour);
            }

            //vérifie si une case est occuper par un allié, si non, la case est valide et est ajoutée à la liste
            void VerifCase(Coordonnee caseAutour)
            {
                if (caseAutour.X <= 7 && caseAutour.X >= 0 && caseAutour.Y <= 7 && caseAutour.Y >= 0)
                {
                    if (lePlateau[caseAutour.X, caseAutour.Y].couleurPiece != couleur)
                    {
                        coordonneesValides.Add(caseAutour);
                    }
                }
            }
            return coordonneesValides;

            //throw new NotImplementedException();
            //Vous pouvez utiliser la ligne qui suit pour vérifier le comportement attendu
            //return base.DeterminerPositionsValides(lePlateau, maPosition);
        }
    }
}
