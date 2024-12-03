namespace Article
{
    public class RemiseManager
    {
        // Définition du délégué pour les stratégies de remise
        public delegate decimal DiscountStrategy(Article article);

        // Méthode statique : Remise fixe
        public static decimal RemiseFixe(Article article)
        {
            decimal remise = 5; // Exemple de remise fixe de 5 unités monétaires
            return article.prix - remise;
        }

        // Méthode statique : Remise en pourcentage
        public static decimal RemisePourcentage(Article article)
        {
            decimal pourcentage = 0.1m; // Remise de 10%
            return article.prix - (article.prix * pourcentage);
        }

        // Méthode statique : Remise basée sur le type d'article
        public static decimal RemiseBaséeSurType(Article article)
        {
            return article.type switch
            {
                TypeArticle.Alimentaire => article.prix * 0.8m, // 20% de remise pour les aliments
                TypeArticle.Electronique => article.prix * 0.85m, // 15% de remise pour l'électronique
                _ => article.prix, // Pas de remise pour les autres types
            };
        }
    }
}
