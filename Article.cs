namespace Article;

public class Article: Publication
 {
   public string designation ; // Propriété en lecture seule
        public int prix ; // Propriété en lecture seule
        public int quantite ; // Propriété en lecture seule
        public TypeArticle type; // Propriété en lecture seule


    public Article (string designation, int prix,TypeArticle type,int quantite = 0, int v = 0) {
        this.designation = designation; 
        this.prix = prix;
        this.quantite = quantite;
        this.type = type;
    }

    public void Acheter(){
       
    }

    public void Afficher()
    {
        Console.WriteLine($"Désignation : {designation}");
        Console.WriteLine($"Prix : {prix} €");
        Console.WriteLine($"Quantité disponible : {quantite}");
        Console.WriteLine($"Type : {type}");
    }
    public override string ToString()
    {
        return "" + designation + "" + "prix" +"  "+ prix +"  "+ " " + quantite +"  "+ "type" + type;
    }

    // Méthode pour ajouter des quantités
    public void Ajouter(int quantite)
    {
        if (quantite <= 0)
        {
            Console.WriteLine("La quantité à ajouter doit être un entier positif.");
            return;
        }
        this.quantite += quantite;
        Console.WriteLine($"{quantite} unité(s) ajoutée(s). Nouvelle quantité : {this.quantite}");
    }

    // Méthode pour retirer des quantités
    public void Retirer(int quantite)
    {
        if (quantite <= 0)
        {
            Console.WriteLine("La quantité à retirer doit être un entier positif.");
            return;
        }

        if (quantite > this.quantite)
        {
            Console.WriteLine("Impossible de retirer plus que la quantité disponible.");
            return;
        }

        this.quantite -= quantite;
        Console.WriteLine($"{quantite} unité(s) retirée(s). Quantité restante : {this.quantite}");
    }

    public override void PublishDetails()
    {
        throw new NotImplementedException();
    }
}
