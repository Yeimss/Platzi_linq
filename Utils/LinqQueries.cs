public class LinqQueries
{
    private List<Book> librosCollection = new List<Book>();

    public LinqQueries()
    {
        using (StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }

    public IEnumerable<Book> GetAll()
    {
        return librosCollection;
    }
    public IEnumerable<Book> LibrosPost2000()
    {
        //Extension Method
        //return librosCollection.Where(p => p.PublishedDate.Year > 2000); 

        //Query Expresion
        return from libros in librosCollection where libros.PublishedDate.Year > 2000 select libros;
    }
    public IEnumerable<Book> LibrosInAction250Pages()
    {
        //Extension Method
        //return librosCollection.Where(p => p.PageCount > 250 && p.Title.Contains("in Action"));

        //Query expresion
        return from libros in librosCollection where libros.PageCount > 250 && libros.Title.Contains("in Action") select libros;
    }
}