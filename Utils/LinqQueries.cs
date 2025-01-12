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

        //Query Expression
        return from libros in librosCollection where libros.PublishedDate.Year > 2000 select libros;
    }
    public IEnumerable<Book> LibrosInAction250Pages()
    {
        //Extension Method
        //return librosCollection.Where(p => p.PageCount > 250 && p.Title.Contains("in Action"));

        //Query expression
        return from libros in librosCollection where libros.PageCount > 250 && libros.Title.Contains("in Action") select libros;
    } 
    public bool NingunLibroVacio()
    {
        return librosCollection.All(r => r.Status != string.Empty);
    }
    public bool HayLibro2005()
    {
        return librosCollection.Any(l => l.PublishedDate.Year == 2005);
    }
    public IEnumerable<Book> LibrosPython()
    {
        return librosCollection.Where(l => l.Title.ToLower().Contains("python"));
    }
    public IEnumerable<Book> LibrosCategoriaJava()
    {
        return librosCollection.Where(l => l.Categories.Contains("Java")).OrderBy(l => l.Title);
    }
    public IEnumerable<Book> Libros450PagDescendentes()
    {
        return librosCollection.Where(l => l.PageCount > 450).OrderByDescending(l => l.PageCount);
    }
    public IEnumerable<Book> TresLibrosMasRecientes()
    {
        return librosCollection.Where(l => l.Categories.Contains("Java")).OrderByDescending(l => l.PublishedDate).Take(3);
    }
    public IEnumerable<Book> TercerYCuartoLibroConMasDe400()
    {
        return librosCollection.Where(l => l.PageCount > 400).Skip(2).Take(2);
    }
    public IEnumerable<Book> TresPrimersLibros()
    {
        return librosCollection.Take(3).Select(l => new Book()
        {
            Title = l.Title,
            PageCount = l.PageCount,
        });
    }
}