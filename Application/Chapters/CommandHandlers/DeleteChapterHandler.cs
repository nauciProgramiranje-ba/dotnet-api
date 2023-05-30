using Application.Abstractions;
using Application.Chapters.Commands;
using MediatR;

namespace Application.Chapters.CommandHandlers;

public class DeleteChapterHandler : IRequestHandler<DeleteChapter>
{
    private readonly IChapterRepository _chapterRepository;

    public DeleteChapterHandler(IChapterRepository chapterRepository)
    {
        _chapterRepository = chapterRepository;
    }

    public async Task Handle(DeleteChapter request, CancellationToken cancellationToken)
    {
        await _chapterRepository.DeleteChapter(request.ChapterId);
    }
}
