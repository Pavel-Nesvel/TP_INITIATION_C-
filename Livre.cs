namespace Article;
    public class Livre : Article, IRentable
    {
        public string ISB { get; set; }
        public int NbPages { get; set; } = 0;

        public Livre(string designation, int prix, TypeArticle type, string ISB, int NbPages, int quantite = 0)
            : base(designation, prix, type, quantite)
        {
            this.ISB = ISB;
            this.NbPages = NbPages;
        }

        public decimal CalculateRent()
        {
            return prix * 0.05m + 0.1m * NbPages; // Coût de location : 5% du prix + 0,1€ par page
        }

        public override void PublishDetails()
        {
            Console.WriteLine($"Livre - {designation} (ISBN: {ISB}, Pages: {NbPages}, Prix: {prix} €, Quantité: {quantite})");
        }

        public new void Afficher()
        {
            base.Afficher();
            Console.WriteLine($"ISBN : {ISB}");
            Console.WriteLine($"Nombre de pages : {NbPages}");
        }
    }