namespace Article;

public class Disque : Article, IRentable
    {
        protected string label;

        public Disque(string designation, int prix, TypeArticle type, string label, int quantite = 0)
            : base(designation, prix, type, quantite)
        {
            this.label = label;
        }

        public decimal CalculateRent()
        {
            return prix * 0.1m; // Coût de location : 10% du prix
        }

        public override void PublishDetails()
        {
            Console.WriteLine($"Disque - {designation} (Label: {label}, Prix: {prix} €, Quantité: {quantite})");
        }

        public new void Afficher()
        {
            base.Afficher();
            Console.WriteLine($"Label : {label}");
        }

        public void Ecouter()
        {
            Console.WriteLine("J'écoute le disque.");
        }
    }