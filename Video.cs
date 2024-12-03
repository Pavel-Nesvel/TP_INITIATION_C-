namespace Article;

 public class Video : Article, IRentable
    {
        public int duree { get; set; }

        public Video(string designation, int prix, TypeArticle type, int duree, int quantite = 0)
            : base(designation, prix, type, quantite)
        {
            this.duree = duree;
        }

        public decimal CalculateRent()
        {
            return prix * 0.2m + 0.5m * duree; // Coût de location : 20% du prix + 0,5€ par minute
        }

        public override void PublishDetails()
        {
            Console.WriteLine($"Vidéo - {designation} (Durée: {duree} min, Prix: {prix} €, Quantité: {quantite})");
        }

        public new void Afficher()
        {
            base.Afficher();
            Console.WriteLine($"Durée : {duree} minutes");
        }
    }