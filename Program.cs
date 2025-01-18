using System.Collections.Generic;

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
//Console.WriteLine($"Cantidad de libros que tienen entre 200 y 500 páginas: {queries.CantidadEntre200Y500Pag()}");

//Menor fecha de publicación
//Console.WriteLine($"Menor fecha de publicación: {queries.MinimaFechaDePublicacion()}");

//Mayor número de páginas
//Console.WriteLine($"Mayor número de páginas: {queries.MaximoNumeroDePaginas()}");

//Minimo numero de paginas diferente de cero
//Book libro = queries.MenorNumeroDePaginasMayorQueCero();    
//Console.WriteLine($"El libro con menor número de páginas es {libro.Title} con {libro.PageCount} páginas");

//Libro con fecha de publicación mayor
//libro = queries.LibroConFechaMasReciente();
//Console.WriteLine($"El libro con la fecha más reciente es {libro.Title} y fue publicado el {libro.PublishedDate.ToShortDateString()}");

//Suma total de paginas de todos los libros entre 0 y 500
//Console.WriteLine($"Suma de paginas de libros entre 0 y 500 paginas: {queries.CantPagBetween0and500()}");

//Titulos de los libros que son mayores al 2015
//Console.WriteLine($"Libros publicados después del 2015: \n{queries.TituloLibrosDespuesDel2015Concatenados()}");

//Promedio de caracteres que tienen los titulos de la colección
//Console.WriteLine($"Promedio de caracteres por titulo: {queries.promedioCaracteresTitulos()}");

//Libros después del 2000 agrupados por año
//ImprimirGrupo(queries.librosPublicadosDespuesDel2000AgrupadosPorAno());

//LookUp con la inicial del libro
//var dictionaryLoop = queries.DiccionariosDeLibrosPorLetra();
//ImprimirDiccionario(dictionaryLoop, 'S');

//Join
ImprimirValores(queries.Join500PagAndPost2005());
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
void ImprimirGrupo(IEnumerable<IGrouping<int, Book>> ListadeLibros)
{
    foreach (var grupo in ListadeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: {grupo.Key}");
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach (var item in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
        }
    } 
}
void ImprimirDiccionario(ILookup<char, Book> ListadeLibros, char letra)
{
    Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach (var item in ListadeLibros[letra])
    {
        Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
    }
}