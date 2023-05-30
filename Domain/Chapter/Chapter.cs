namespace Domain.Chapter;

public class Chapter
{
    public ChapterId Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int ChapterNumber { get; set; }
}
