namespace ExamIkki.DataAccess.Entities;

public class BookEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Pages { get; set; }
    public double Rating { get; set; }
    public int NumberOfCopiesSold { get; set; }
    public DateTime PublishedDate { get; set; }
}
