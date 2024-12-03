namespace Article
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Création de plusieurs articles
            Article article1 = new Article("Pâtes", 4, TypeArticle.Alimentaire, 50);
            Article article2 = new Article("Savon", 3, TypeArticle.Droguerie, 20);
            Article article3 = new Article("T-shirt", 15, TypeArticle.Habillement, 10);

            // Création de publications spécifiques
            Livre livre1 = new Livre("Livre de cuisine", 20, TypeArticle.Loisir, "123456789", 150, 5);
            Disque disque1 = new Disque("Album Rock", 25, TypeArticle.Electronique, "Label XYZ", 10);
            Video video1 = new Video("Film d'action", 30, TypeArticle.Loisir, 120, 3);

            // Création d'une liste de publications
            List<Publication> publications = new List<Publication> { livre1, disque1, video1 };

            // Affichage des détails des publications
            Console.WriteLine("\nDétails des publications :");
            foreach (var publication in publications)
            {
                publication.PublishDetails();
                Console.WriteLine();
            }

            ArticleTableau tableau = new ArticleTableau(article1, article2, article3);

            // Affichage des articles
            tableau.afficherArticles();

            Console.WriteLine("Articles initiaux :");
            article1.Afficher();
            article2.Afficher();
            article3.Afficher();

            // Application de remises
            Console.WriteLine("\nApplication des remises :");
            decimal remise = 0.1m; // Remise de 10%
            Console.WriteLine($"Prix de l'article {article1.designation} après remise : {RemiseManager.AppliquerRemise(article1.prix, remise)} €");
            Console.WriteLine($"Prix de l'article {article2.designation} après remise : {RemiseManager.AppliquerRemise(article2.prix, remise)} €");
            Console.WriteLine($"Prix de l'article {article3.designation} après remise : {RemiseManager.AppliquerRemise(article3.prix, remise)} €");

            Console.WriteLine("\nModification des quantités :");
            article1.Ajouter(10);
            article2.Retirer(5);
            article3.Ajouter(5);

            Console.WriteLine("\nArticles après modification :");
            article1.Afficher();
            article2.Afficher();
            article3.Afficher();

            Console.WriteLine("\nCréation d'un nouvel article par saisie utilisateur :");
            try
            {
                Console.Write("Entrez le nom de l'article : ");
                string designation = Console.ReadLine();

                Console.Write("Entrez le prix de l'article : ");
                decimal prix = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Entrez la quantité initiale : ");
                int quantite = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Entrez le type de l'article (Alimentaire, Droguerie, Habillement, Loisir, Electronique, Autre) :");
                string typeString = Console.ReadLine();
                TypeArticle type = (TypeArticle)Enum.Parse(typeof(TypeArticle), typeString, true);

                Article nouvelArticle = new Article(designation, (int)prix, type, quantite);

                Console.Write("Combien d'unités souhaitez-vous ajouter ? ");
                int ajout = Convert.ToInt32(Console.ReadLine());
                nouvelArticle.Ajouter(ajout);

                Console.Write("Combien d'unités souhaitez-vous retirer ? ");
                int retrait = Convert.ToInt32(Console.ReadLine());
                nouvelArticle.Retirer(retrait);

                Console.WriteLine("\nNouvel article créé et modifié :");
                nouvelArticle.Afficher();

                // Affichage du prix après remise pour le nouvel article
                Console.WriteLine($"\nPrix du nouvel article {nouvelArticle.designation} après remise : {RemiseManager.AppliquerRemise(nouvelArticle.prix, remise)} €");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la création de l'article : {ex.Message}");
            }
        }
    }
}
