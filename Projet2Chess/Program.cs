using System;
using System.Collections.Generic;

namespace Projet2Chess
{
    class Program
    {
        static PartieEchecs laPartie;

        static string nomJoueur1, nomJoueur2;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            InitialiserPartie();
            
            while(true)
            {
                laPartie.AfficherPlateau();
                CoupJoueur1();
                laPartie.AfficherPlateau();
                CoupJoueur2();
            }
        }

        private static void CoupJoueur1()
        {
            CoupJoueur(ConsoleColor.White, nomJoueur1);
        }

        private static void CoupJoueur2()
        {
            CoupJoueur(ConsoleColor.Black, nomJoueur2);
        }

        private static void CoupJoueur(ConsoleColor couleurJoueur, string nomJoueur)
        {
            Console.WriteLine("C'est le tour de " + nomJoueur + ", choisissez une pièce à bouger.");
            Coordonnee coordonneeDestination;

            do
            {
                bool sourceValide = false;

                while (!sourceValide)
                {
                    Coordonnee coordonneeABouger = DemanderCoordonnees("Entrez la coordonnée de la pièce que vous voulez bouger : ");

                    sourceValide = laPartie.SelectionnerPieceEtAfficher(coordonneeABouger, couleurJoueur);
                }

                coordonneeDestination = DemanderCoordonnees("Entrez la coordonnée de destination : ");

            } while (!laPartie.EntrerDestinationEtConfirmer(coordonneeDestination, couleurJoueur));
        }

        private static Coordonnee DemanderCoordonnees(string messageAAfficher)
        {
            string rep;
            Console.WriteLine(messageAAfficher);
            rep = Console.ReadLine();
            Coordonnee maCoord = DecortiquerCoordonnee(rep);
            return maCoord;
            //throw new NotImplementedException();
        }

        private static Coordonnee DecortiquerCoordonnee(string coordonneeADecortiquer)
        {
            Dictionary<string, int> coord1 = new Dictionary<string, int>();
            coord1.Add("A", 0);
            coord1.Add("B", 1);
            coord1.Add("C", 2);
            coord1.Add("D", 3);
            coord1.Add("E", 4);
            coord1.Add("F", 5);
            coord1.Add("G", 6);
            coord1.Add("H", 7);

            Dictionary<string, int> coord2 = new Dictionary<string, int>();
            coord2.Add("1", 0);
            coord2.Add("2", 1);
            coord2.Add("3", 2);
            coord2.Add("4", 3);
            coord2.Add("5", 4);
            coord2.Add("6", 5);
            coord2.Add("7", 6);
            coord2.Add("8", 7);

            string caract1, caract2;
            int nb1, nb2;
            bool valide, verif;
            Coordonnee maCoord;

            caract1 = coordonneeADecortiquer.Substring(0, 1).ToUpper();
            caract2 = coordonneeADecortiquer.Substring(1, 1);
            verif = coord1.TryGetValue(caract1, out nb1);
            valide = coord2.TryGetValue(caract2, out nb2);
            if (valide && verif)
            {
                maCoord = new Coordonnee(nb1, nb2);
                return maCoord;
            }
            else
            {
                return null;
            }
            //throw new NotImplementedException();
        }

        private static void InitialiserPartie()
        {
            laPartie = new VraiePartieEchec();

            Console.WriteLine("Quel est le nom du joueur 1?");
            nomJoueur1 = Console.ReadLine();

            Console.WriteLine("Quel est le nom du joueur 2?");
            nomJoueur2 = Console.ReadLine();
        }
    }
}
