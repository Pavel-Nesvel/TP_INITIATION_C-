namespace Article;
public static class RemiseManager
{
    // Délégué pour définir le type de méthode de remise
    public delegate decimal RemiseArticle(decimal prix, decimal taux);

    // Méthodes de remise
    public static decimal RemiseFixe(decimal prix, decimal taux)
    {
        return prix * taux; // Remise de type pourcentage (ex. 0.1 pour 10%)
    }

    public static decimal RemiseAbsolue(decimal prix, decimal taux)
    {
        return taux; // Remise fixe (ex. 5 €)
    }

    // Tableau de délégués pour stocker les stratégies de remise
    private static RemiseArticle[] discountStrategies = new RemiseArticle[]
    {
        RemiseFixe,
        RemiseAbsolue
    };

    // Méthode pour appliquer la première stratégie de remise
    public static decimal AppliquerRemise(decimal prix, decimal taux)
    {
        // On utilise la première stratégie (par exemple)
        return discountStrategies[0](prix, taux);
    }
}
