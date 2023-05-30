using Application.Abstractions;
using Application.Chapters.Commands;
using Domain.Chapter;
using MediatR;

namespace Application.Chapters.CommandHandlers;

public class UpdateChapterHandler : IRequestHandler<UpdateChapter, Chapter>
{
    private readonly IChapterRepository _chapterRepository;

    public UpdateChapterHandler(IChapterRepository chapterRepository)
    {
        _chapterRepository = chapterRepository;
    }

    public async Task<Chapter> Handle(UpdateChapter request, CancellationToken cancellationToken)
    {
        var chapter = await _chapterRepository.UpdateChapter(request.ChapterId, request.Title, request.Description, request.ChapterNumber);
        return chapter;
    }
}
