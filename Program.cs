namespace Article;
class Program
{

        public static void Main(string[] args)
        {
            
             // Création de plusieurs articles
        Article article1 = new Article("Pâtes", 1, TypeArticle.Alimentaire, 50);
        Article article2 = new Article("Savon", 2, TypeArticle.Droguerie, 20);
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

        // Display table
        tableau.afficherArticles();

        Console.WriteLine("Articles initiaux :");
        article1.Afficher();
        article2.Afficher();
        article3.Afficher();

        Console.WriteLine("\nModification des quantités :");
        article1.Ajouter(10);
        article2.Retirer(5);
        article3.Ajouter(5);

        Console.WriteLine("\nArticles après modification :");
        article1.Afficher();
        article2.Afficher();
        article3.Afficher();

        // Création d'instances du délégué DiscountStrategy et association aux méthodes de remise
            RemiseManager.DiscountStrategy remiseFixeDelegate = RemiseManager.RemiseFixe;
            RemiseManager.DiscountStrategy remisePourcentageDelegate = RemiseManager.RemisePourcentage;
            RemiseManager.DiscountStrategy remiseBaséeSurTypeDelegate = RemiseManager.RemiseBaséeSurType;

            // Affichage des détails des articles avant remise
            Console.WriteLine("Articles initiaux :");
            article1.Afficher();
            article2.Afficher();
            article3.Afficher();

            // Demande des informations pour créer un nouvel article par l'utilisateur
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

                // Demande à l'utilisateur quel type de remise appliquer
                Console.WriteLine("\nChoisissez le type de remise à appliquer :");
                Console.WriteLine("1. Remise fixe (ex : 2€)");
                Console.WriteLine("2. Remise en pourcentage (ex : 10%)");
                Console.WriteLine("3. Remise basée sur le type d'article (ex : 10% sur les alimentaires)");

                int choixRemise = Convert.ToInt32(Console.ReadLine());
                decimal prixFinal = 0;

                switch (choixRemise)
                {
                    case 1:
                        // Application de la remise fixe
                        prixFinal = remiseFixeDelegate(nouvelArticle);
                        Console.WriteLine($"Prix après remise fixe pour {nouvelArticle.designation} : {prixFinal} €");
                        break;
                    case 2:
                        // Application de la remise en pourcentage
                        prixFinal = remisePourcentageDelegate(nouvelArticle);
                        Console.WriteLine($"Prix après remise en pourcentage pour {nouvelArticle.designation} : {prixFinal} €");
                        break;
                    case 3:
                        // Application de la remise basée sur le type
                        prixFinal = remiseBaséeSurTypeDelegate(nouvelArticle);
                        Console.WriteLine($"Prix après remise basée sur le type pour {nouvelArticle.designation} : {prixFinal} €");
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Aucune remise appliquée.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la création de l'article : {ex.Message}");
            }

            // Affichage des détails des articles après modification et application de la remise
            Console.WriteLine("\nArticles après modification :");
            article1.Afficher();
            article2.Afficher();
            article3.Afficher();


            // TP3 LInQ
    List<Article> articles = new List<Article> {
    new("Pomme", 25,TypeArticle.Alimentaire, 50),
    new("Banane", 25,TypeArticle.Alimentaire, 50),
    new("Saumon", 25,TypeArticle.Alimentaire, 50),
    new("Savon", 32,TypeArticle.Droguerie,20),
    new("T-shirt", 150,TypeArticle.Habillement,30) };

    //Étape 2 : Analyse des données avec LINQ

       //1. Requêtes LINQ de base 
           //Lister tous les articles appartenant à un type spécifique (ex. "Alimentaire"
           
           var typeArticle = articles.Where(article => article.type == TypeArticle.Alimentaire );

           foreach (var article in typeArticle){
                Console.WriteLine("article alimentaire" + "  " +article);     
           }


           int  totalStock=0;
            Console.WriteLine("########################################################################"); 
           //Trier les articles par prix décroissant
           var articleSorted = articles.OrderByDescending(article => article.prix).ToList();

           foreach (var article in articleSorted){
                Console.WriteLine(article); 
                totalStock +=article.quantite;    
           }

           Console.WriteLine("\n le total des articles est:" + " "+ totalStock); 
           
        }


           
}