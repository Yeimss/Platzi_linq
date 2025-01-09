LinqQueries quieries = new LinqQueries();

ImprimirValores(quieries.GetAll());

void ImprimirValores(IEnumerable<Book> libros)
{
    Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach (var libro in libros)
    {
        Console.WriteLine("{0,-60} {1, 15} {2, 15}", libro.Title, libro.PageCount, libro.PublishedDate.ToShortDateString());
    }
}