using Application.Abstractions;
using Application.Chapters.Commands;
using Domain.Chapter;
using MediatR;

namespace Application.Chapters.CommandHandlers;

public class CreateChapterHandler : IRequestHandler<CreateChapter, Chapter>
{
    private readonly IChapterRepository _chapterRepository;

    public CreateChapterHandler(IChapterRepository chapterRepository)
    {
        _chapterRepository = chapterRepository;
    }

    public async Task<Chapter> Handle(CreateChapter request, CancellationToken cancellationToken)
    {
        var chapter = new Chapter
        {
            Id = new ChapterId(Guid.NewGuid()),
            Title = request.Title,
            Description = request.Description,
            ChapterNumber = request.ChapterNumber,
            AddedDate = DateTime.Now,
            LastModified = DateTime.Now,
            DurationInHrs = request.DurationInHrs,
        };

        return await _chapterRepository.AddChapter(chapter);
    }
}
