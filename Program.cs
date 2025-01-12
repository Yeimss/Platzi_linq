LinqQueries queries = new LinqQueries();

//Toda la colección
//ImprimirValores(queries.GetAll()); 

//Libros con fecha de publicación >= 2000
//ImprimirValores(queries.LibrosPost2000()); 

//250 paginas o mas y que el titulo contenga "in Action"
//ImprimirValores(queries.LibrosInAction250Pages());

//Todos los libros tienen status
//Console.WriteLine($"¿Todos los libros tienen status?: {queries.NingunLibroVacio()}");

//Algun libro publicado en 2005
//Console.WriteLine($"¿Algun libro publicado en 2005?: {queries.HayLibro2005()}");

//Libros python
//ImprimirValores(queries.LibrosPython());

//Libros Java ordenados por titulo
//ImprimirValores(queries.LibrosCategoriaJava());

//Libros Java ordenados por titulo
//ImprimirValores(queries.Libros450PagDescendentes());

//Los 3 libros más recientemente publicados
//ImprimirValores(queries.TresLibrosMasRecientes());

//Tercer y cuarto libro con más de 400 paginas
//ImprimirValores(queries.TercerYCuartoLibroConMasDe400());

//Tres primeros libros filtrados con select
//ImprimirValores(queries.TresPrimersLibros());

//Cantidad de libros entre 200 y 500 pag
Console.WriteLine($"Cantidad de libros que tienen entre 200 y 500 páginas: {queries.CantidadEntre200Y500Pag()}");
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
