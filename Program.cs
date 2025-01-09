LinqQueries quieries = new LinqQueries();

//Toda la colección
//ImprimirValores(quieries.GetAll()); 

//Libros con fecha de publicación >= 2000
//ImprimirValores(quieries.LibrosPost2000()); 

//250 paginas o mas y que el titulo contenga "in Action"
ImprimirValores(quieries.LibrosInAction250Pages());
void ImprimirValores(IEnumerable<Book> libros)
{
    Console.WriteLine("{0, -10} {1,-60} {2, 15} {3, 15}\n", "#", "Titulo", "N. Paginas", "Fecha publicacion");
    int i = 1;
    foreach (var libro in libros)
    {
        Console.WriteLine("{0, -10} {1,-60} {2, 15} {3, 15}", i, libro.Title, libro.PageCount, libro.PublishedDate.ToShortDateString());
        i++;
    }
}
