using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet2Chess
{
    class VraiFou : Fou
    {
        public VraiFou(ConsoleColor laCouleur):base(laCouleur)
        {}

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
             *      Tant que vrai
             *          Si le X de la case est inférieur ou égal à 7 et le Y de la case est supérieur ou égal à 0
             *              Si la case du haut à droite est vide
             *                  Ajouter cette case à la liste des positions valides
             *              Sinon si la case du haut à droite n'est pas vide et que la couleur de la pièce est ennemie
             *                  Ajouter cette case à la liste des positions valides
             *                  Sortir
             *              Sinon si la case du haut à droite n'est pas vide et que la couleur de la pièce est alliée
             *                  Sortir
             *              Incrémenter de 1 le nb pour la prochaine case en haut à droite
             *              Faire un saut dans l'itération
             *          Sortir
             *                  
             *      Tant que vrai
             *          Si le X de la case est supérieur ou égal à 0 et le Y de la case est supérieur ou égal à 0
             *              Si la case du haut à gauche est vide
             *                  Ajouter cette case à la liste des positions valides
             *              Sinon si la case du haut à gauche n'est pas vide et que la couleur de la pièce est enemie
             *                  Ajouter cette case à la liste des positions valides
             *                  Sortir
             *              Sinon si la case du haut à gauche n'est pas vide et que la couleur de la pièce est alliée
             *                  Sortir
             *              Incrémenter de 1 le nb pour la prochaine case en haut à gauche
             *              Faire un saut dans l'itération
             *          Sortir
             *          
             *          
             *      Tant que vrai
             *          Si le X de la case est inférieur ou égal à 7 et le Y de la case est inférieur ou égal à 7
             *              Si la case de droite en bas est vide
             *                  Ajouter cette case à la liste des positions valides
             *              Sinon si la case de droite en bas n'est pas vide et que la couleur de la pièce est enemie
             *                  Ajouter cette case à la liste des positions valides
             *                  Sortir
             *              Sinon si la case de droite en bas n'est pas vide et que la couleur de la pièce est alliée
             *                  Sortir
             *              Incrémenter de 1 le nb pour la prochaine case de droite en bas
             *              Faire un saut dans l'itération
             *          Sortir
             *              
             *      Tant que vrai
             *          Si le X de la case est supérieur ou égal à 0 et le Y de la case est inférieur ou égal à 7
             *              Si la case de gauche en bas est vide
             *                  Ajouter cette case à la liste des positions valides
             *              Sinon si la case de gauche en bas n'est pas vide et que la couleur de la pièce est enemie
             *                  Ajouter cette case à la liste des positions valides
             *                  Sortir
             *              Sinon si la case de gauche en bas n'est pas vide et que la couleur de la pièce est alliée
             *                  Sortir
             *              Incrémenter de 1 le nb pour la prochaine case de gauche en bas
             *              Faire un saut dans l'itération
             *          Sortir
             */


            //throw new NotImplementedException();
            //Vous pouvez utiliser la ligne qui suit pour vérifier le comportement attendu
            List<Coordonnee> maListe = new List<Coordonnee>();
            ConsoleColor coulEnnemi;

            //Obtenir la couleur ennemie
            if (lePlateau[maPosition.X, maPosition.Y].couleurPiece != ConsoleColor.White)
            {
                coulEnnemi = ConsoleColor.White;
            }
            else
            {
                coulEnnemi = ConsoleColor.Black;
            }

            //Appel des fonctions qui vérifient les déplacements
            HautDroite(lePlateau, maPosition, maListe, coulEnnemi);
            HautGauche(lePlateau, maPosition, maListe, coulEnnemi);
            BasDroite(lePlateau, maPosition, maListe, coulEnnemi);
            BasGauche(lePlateau, maPosition, maListe, coulEnnemi);

            //Retour de la liste des déplacements
            return maListe;

            //return base.DeterminerPositionsValides(lePlateau, maPosition);
        }
        /// <summary>
        /// Vérifier les déplacements vers la droite en haut
        /// </summary>
        /// <param name="lePlateau"></param>
        /// <param name="maPosition"></param>
        /// <param name="mesPositions"></param>
        /// <param name="coulEnnemi"></param>
        private void HautDroite(Piece[,] lePlateau, Coordonnee maPosition, List<Coordonnee> mesPositions, ConsoleColor coulEnnemi)
        {
            int nb = 1;
            bool valide = true;

            //Boucler jusqu'à ce que la condition soit fausse et qu'il y ait une sortie
            while (valide)
            {
                int nb2 = maPosition.X + nb;
                int nb3 = maPosition.Y - nb;

                //Conditions pour obtenir les déplacements
                if (nb2 <= 7 && nb3 >= 0)
                {
                    if (lePlateau[nb2, nb3] is PieceVide)
                    {
                        mesPositions.Add(new Coordonnee(nb2, nb3));
                    }
                    else if (lePlateau[nb2, nb3].couleurPiece == coulEnnemi)
                    {
                        mesPositions.Add(new Coordonnee(nb2, nb3));
                        break;
                    }
                    else if (lePlateau[nb2, nb3].couleurPiece == lePlateau[maPosition.X, maPosition.Y].couleurPiece)
                    {
                        break;
                    }

                    nb++; //Incrémentation de 1 le nb
                    continue; //Le continue fait un saut dans les itérations selon la condition et continu dans la prochaine itération, donc n'exécute pas le break
                }
                break;
            }
        }
        /// <summary>
        /// Vérifier les déplacements vers la gauche en haut
        /// </summary>
        /// <param name="lePlateau"></param>
        /// <param name="maPosition"></param>
        /// <param name="mesPositions"></param>
        /// <param name="coulEnnemi"></param>
        private void HautGauche(Piece[,] lePlateau, Coordonnee maPosition, List<Coordonnee> mesPositions, ConsoleColor coulEnnemi)
        {
            int nb = 1;
            bool valide = true;

            //Boucler jusqu'à ce que la condition soit fausse et qu'il y ait une sortie
            while (valide)
            {
                int nb2 = maPosition.X - nb;
                int nb3 = maPosition.Y - nb;

                //Conditions pour obtenir les déplacements
                if (nb2 >= 0 && nb3 >= 0)
                {
                    if (lePlateau[nb2, nb3] is PieceVide)
                    {
                        mesPositions.Add(new Coordonnee(nb2, nb3));
                    }
                    else if (lePlateau[nb2, nb3].couleurPiece == coulEnnemi)
                    {
                        mesPositions.Add(new Coordonnee(nb2, nb3));
                        break;
                    }
                    else if (lePlateau[nb2, nb3].couleurPiece == lePlateau[maPosition.X, maPosition.Y].couleurPiece)
                    {
                        break;
                    }

                    nb++; //Incrémentation de 1 le nb
                    continue; //Le continue fait un saut dans les itérations selon la condition et continu dans la prochaine itération, donc n'exécute pas le break
                }
                break;
            }
        }
        /// <summary>
        /// Vérifier les déplacements vers la droite en bas
        /// </summary>
        /// <param name="lePlateau"></param>
        /// <param name="maPosition"></param>
        /// <param name="mesPositions"></param>
        /// <param name="coulEnnemi"></param>
        private void BasDroite(Piece[,] lePlateau, Coordonnee maPosition, List<Coordonnee> mesPositions, ConsoleColor coulEnnemi)
        {
            int nb = 1;
            bool valide = true;

            //Boucler jusqu'à ce que la condition soit fausse et qu'il y ait une sortie
            while (valide)
            {
                int nb2 = maPosition.X + nb;
                int nb3 = maPosition.Y + nb;

                //Conditions pour obtenir les déplacements
                if (nb2 <= 7 && nb3 <= 7)
                {
                    if (lePlateau[nb2, nb3] is PieceVide)
                    {
                        mesPositions.Add(new Coordonnee(nb2, nb3));
                    }
                    else if (lePlateau[nb2, nb3].couleurPiece == coulEnnemi)
                    {
                        mesPositions.Add(new Coordonnee(nb2, nb3));
                        break;
                    }
                    else if (lePlateau[nb2, nb3].couleurPiece == lePlateau[maPosition.X, maPosition.Y].couleurPiece)
                    {
                        break;
                    }

                    nb++; //Incrémentation de 1 le nb
                    continue; //Le continue fait un saut dans les itérations selon la condition et continu dans la prochaine itération, donc n'exécute pas le break
                }
                break;
            }
        }
        /// <summary>
        /// Vérifier les déplacements vers la gauche en bas
        /// </summary>
        /// <param name="lePlateau"></param>
        /// <param name="maPosition"></param>
        /// <param name="mesPositions"></param>
        /// <param name="coulEnnemi"></param>
        private void BasGauche(Piece[,] lePlateau, Coordonnee maPosition, List<Coordonnee> mesPositions, ConsoleColor coulEnnemi)
        {
            int nb = 1;
            bool valide = true;

            //Boucler jusqu'à ce que la condition soit fausse et qu'il y ait une sortie
            while (valide)
            {
                int nb2 = maPosition.X - nb;
                int nb3 = maPosition.Y + nb;

                //Conditions pour obtenir les déplacements
                if (nb2 >= 0 && nb3 <= 7)
                {
                    if (lePlateau[nb2, nb3] is PieceVide)
                    {
                        mesPositions.Add(new Coordonnee(nb2, nb3));
                    }
                    else if (lePlateau[nb2, nb3].couleurPiece == coulEnnemi)
                    {
                        mesPositions.Add(new Coordonnee(nb2, nb3));
                        break;
                    }
                    else if (lePlateau[nb2, nb3].couleurPiece == lePlateau[maPosition.X, maPosition.Y].couleurPiece)
                    {
                        break;
                    }

                    nb++; //Incrémentation de 1 le nb
                    continue; //Le continue fait un saut dans les itérations selon la condition et continu dans la prochaine itération, donc n'exécute pas le break
                }
                break;
            }
        }
    }
}
