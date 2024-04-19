using System;
using System.Collections.Generic;
using System.IO; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final
{
    // Définition de la classe student
    public class student
    {
        // Propriétés
        public int numeroEtudiant;
        public string nom;
        public string prenom;

        // Accesseurs
        public int NumeroEtudiant
        {
            get { return numeroEtudiant; }
            set { numeroEtudiant = value; }
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        // Constructeurs
        public student() { }

        public student(int numeroEtudiant, string nom, string prenom)
        {
            this.numeroEtudiant = numeroEtudiant;
            this.nom = nom;
            this.prenom = prenom;
        }

        // Redéfinition de la méthode ToString
        public override string ToString()
        {
            return $"Numéro étudiant: {NumeroEtudiant}, Nom: {Nom}, Prénom: {Prenom}";
        }
    }

    // Définition de la classe courses
    public class courses : student
    {
        // Propriétés
        public int numeroCours;
        public string code;
        public string titre;

        // Accesseurs
        public int NumeroCours
        {
            get { return numeroCours; }
            set { numeroCours = value; }
        }
        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        public string Titre
        {
            get { return titre; }
            set { titre = value; }
        }

        // Constructeurs
        public courses() { }

        public courses(int numeroCours, string code, string titre)
        {
            this.numeroCours = numeroCours;
            this.code = code;
            this.titre = titre;
        }

        // Redéfinition de la méthode ToString
        public override string ToString()
        {
            return $"Numéro cours: {NumeroCours}, Code: {Code}, Titre: {Titre}";
        }
    }

    // Définition de la classe grade
    public class grade : courses
    {
        // Propriétés
        public double note;

        // Accesseur
        public double Note
        {
            get { return note; }
            set { note = value; }
        }

        // Constructeurs
        public grade() { }
        public grade(double note, int numeroEtudiant, int numeroCours)
        {
            this.note = note;
            base.numeroEtudiant = numeroEtudiant;
            base.numeroCours = numeroCours;
        }

        // Redéfinition de la méthode ToString
        public override string ToString()
        {
            return $"Numéro étudiant: {NumeroEtudiant}, Numéro cours: {NumeroCours}, Note: {note}";
        }
    }

    // Classe principale du programme
    internal class Program
    {
        static void Main(string[] args)
        {
            // Saisie des informations de l'étudiant
            Console.WriteLine("ENTRER LES INFORMATIONS DE L'ÉTUDIANT:");
            Console.Write("Numero de l'etudiant :");
            int numeroE = int.Parse(Console.ReadLine());
            Console.Write("Nom : ");
            string nomE = Console.ReadLine();
            Console.Write("Prenom :");
            string prenomE = Console.ReadLine();

            // Saisie des informations du cours
            Console.WriteLine("\nENTRER LES INFORMATIONS DU COURS:");
            Console.Write("Numero du cours :");
            int numeroC = int.Parse(Console.ReadLine());
            Console.Write("Code du cours : ");
            string codeC = Console.ReadLine();
            Console.Write("Titre du cours :");
            string titreC = Console.ReadLine();

            // Saisie de la note
            Console.WriteLine("\nENTRER LES INFORMATIONS DE LA NOTE:");
            Console.Write("Note : ");
            double noteC = Double.Parse(Console.ReadLine());

            // Création des objets
            student etudiant1 = new student(numeroE, nomE, prenomE);
            courses cours1 = new courses(numeroC, codeC, titreC);
            grade note1 = new grade(noteC, numeroE, numeroC);

            // Ecriture des données dans un fichier texte
            string directoryPath = @"C:\Users\Phanuelle Lienou\Documents"; //le chemin du répertoire où les fichiers sont enregistrer
            string fileName = Path.Combine(directoryPath, $"{etudiant1.NumeroEtudiant}_releve_notes.txt");

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine("INFORMATIONS DE L'ÉTUDIANT:");
                writer.WriteLine(etudiant1.ToString());
                writer.WriteLine("\nINFORMATIONS DU COURS:");
                writer.WriteLine(cours1.ToString());
                writer.WriteLine("\nINFORMATIONS DE LA NOTE:");
                writer.WriteLine(note1.ToString());
            }

            // Affichage du relevé de notes 
            Console.WriteLine("Entrez le numéro de l'étudiant pour afficher le relevé de notes (0 pour quitter) :");
            int input = int.Parse(Console.ReadLine());
            while (input != 0)
            {
                string fileToRead = $"{input}_releve_notes.txt";
                if (File.Exists(fileToRead))
                {
                    using (StreamReader reader = new StreamReader(fileToRead))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Aucun fichier trouvé pour l'étudiant avec le numéro {input}.");
                }

                Console.WriteLine("\nEntrez le numéro de l'étudiant pour afficher le relevé de notes (0 pour quitter) :");
                input = int.Parse(Console.ReadLine());
            }

           
            Console.ReadLine();
        }
    }
}