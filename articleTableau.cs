namespace Article;

public class ArticleTableau
{
protected Article[] Articles;

public ArticleTableau(Article art1, Article art2, Article art3){
    Articles= [art1, art2, art3];
}
public void afficherArticles()
{
    foreach (var articles in Articles){
        Console.WriteLine(articles);
    }

}

}
