public class Book
{
    public string? Title { get; set; }
    public int PageCount { get; set; }
    public string? Status { get; set; }
    public DateTime PublishedDate { get; set; }
    public string? TumbnailUrl { get; set; }
    public string? ShortDescription { get; set; }
    public string[]? Categories { get; set; }
    public string[]? Authors { get; set; }
}