﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet2Chess
{
    class VraiRoi : Roi
    {
        public VraiRoi(ConsoleColor laCouleur) : base(laCouleur)
        { }

        /// <summary>
        /// Détermine toutes les cases valides pour le roi en regardant le plateau
        /// </summary>
        /// <param name="lePlateau"></param>
        /// <param name="maPosition"></param>
        /// <returns></returns>
        public override List<Coordonnee> DeterminerPositionsValides(Piece[,] lePlateau, Coordonnee maPosition)
        {
            /*  
             *  int mouvement = -1
             *  SI la couleur est blanche
             *      mouvement = 1
             *  SI la position en haut n'est pas de la même couleur
             *      Ajouter cette position à la liste
             *  SI la position au coin haut-droit n'est pas de la même couleur
             *      Ajouter cette position à la liste
             *  SI la position à droite n'est pas de la même couleur
             *      Ajouter cette position à la liste
             *  SI la position au coin bas-droite n'est pas de la même couleur
             *      Ajouter cette position à la liste
             *  SI la position au bas n'est pas de la même couleur
             *      Ajouter cette position à la liste
             *  SI la position au bas-gauche n'est pas de la même couleur
             *      Ajouter cette position à la liste
             *  SI la position à gauche n'est pas de la même couleur
             *      Ajouter cette position à la liste
             *  SI la position au coin haut-gauche n'est pas de la même couleur
             *      Ajouter cette position à la liste
             */

            List<Coordonnee> coordonneesValides = new List<Coordonnee>();
            //Ajoute toutes les cases autour du roi dans une liste
            List<Coordonnee> cases = new List<Coordonnee>();
            cases.Add(new Coordonnee(maPosition.X, maPosition.Y+1));
            cases.Add(new Coordonnee(maPosition.X+1, maPosition.Y+1));
            cases.Add(new Coordonnee(maPosition.X+1, maPosition.Y));
            cases.Add(new Coordonnee(maPosition.X+1, maPosition.Y-1));
            cases.Add(new Coordonnee(maPosition.X, maPosition.Y-1));
            cases.Add(new Coordonnee(maPosition.X-1, maPosition.Y-1));
            cases.Add(new Coordonnee(maPosition.X-1, maPosition.Y));
            cases.Add(new Coordonnee(maPosition.X-1, maPosition.Y+1));

            ConsoleColor couleur = this.couleurPiece;

            //Vérifie chaque case autour du roi
            foreach (Coordonnee caseAutour in cases)
            {
                VerifCase(caseAutour);
            }

            //vérifie si une case est occuper par un allié, si non, la case est valide et est ajoutée à la liste
            void VerifCase(Coordonnee caseAutour)
            {
                try
                {
                    if (lePlateau[caseAutour.X,caseAutour.Y].couleurPiece != couleur)
                    {
                        coordonneesValides.Add(caseAutour);
                    }
                }
                catch (IndexOutOfRangeException e)
                {
                    
                }
            }
            return coordonneesValides;

            //throw new NotImplementedException();
            //Vous pouvez utiliser la ligne qui suit pour vérifier le comportement attendu
            //return base.DeterminerPositionsValides(lePlateau, maPosition);
        }
    }
}
