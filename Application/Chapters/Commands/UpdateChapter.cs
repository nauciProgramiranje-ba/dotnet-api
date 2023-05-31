using Domain.Chapter;
using MediatR;

namespace Application.Chapters.Commands;

public class UpdateChapter : IRequest<Chapter>
{
    public ChapterId ChapterId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public int ChapterNumber { get; set; }

    public int DurationInHrs { get; set; }
}
