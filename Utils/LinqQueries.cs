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
    public int CantidadEntre200Y500Pag()
    {
        return librosCollection.Count(l => l.PageCount >= 200 && l.PageCount <= 500);
    }
    public DateTime MinimaFechaDePublicacion()
    {
        return librosCollection.Min(l => l.PublishedDate);
    }
    public int MaximoNumeroDePaginas()
    {
        return librosCollection.Max(l => l.PageCount);
    }
    public Book MenorNumeroDePaginasMayorQueCero()
    {
        return librosCollection.Where(l=>l.PageCount != 0).MinBy(l => l.PageCount);
    }
    public Book LibroConFechaMasReciente()
    {
        return librosCollection.MaxBy(l => l.PublishedDate);
    }
    public int CantPagBetween0and500()
    {
        return librosCollection.Where(l => l.PageCount <= 500).Sum(l => l.PageCount);
    }
    public string TituloLibrosDespuesDel2015Concatenados()
    {
        return librosCollection.Where(l => l.PublishedDate.Year >= 2015)
            .Aggregate("", (titulosLibros, next) =>
            {
                titulosLibros += $" - {next.Title}\n";
                return titulosLibros;
            });
            
    }
    public double promedioCaracteresTitulos()
    {
        return librosCollection.Average(l => l.Title.Length);
    }
    public IEnumerable<IGrouping<int, Book>> librosPublicadosDespuesDel2000AgrupadosPorAno()
    {
        return librosCollection.Where(l => l.PublishedDate.Year >= 2000).GroupBy(l => l.PublishedDate.Year);
    }
    public ILookup<char, Book> DiccionariosDeLibrosPorLetra()
    {
        return librosCollection.ToLookup(l => l.Title[0], l => l );
    }
    public IEnumerable<Book> LibrosDespuesDel2005()
    {
        return librosCollection.Where(l => l.PublishedDate.Year >= 2005);
    }
    public IEnumerable<Book> LibrosSuperioresA500Pag()
    {
        return librosCollection.Where(l => l.PageCount >= 500);
    }
    public IEnumerable<Book> Join500PagAndPost2005()
    {
        IEnumerable<Book> post2005 = LibrosDespuesDel2005();
        IEnumerable<Book> moreThan500Pag = LibrosSuperioresA500Pag();
        return post2005.Join(moreThan500Pag, p => p.Title, x => x.Title, (p, x) => p);
    }
}