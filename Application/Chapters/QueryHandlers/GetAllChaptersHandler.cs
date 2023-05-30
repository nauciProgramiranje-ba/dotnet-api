using Application.Abstractions;
using Application.Chapters.Queries;
using Domain.Chapter;
using MediatR;

namespace Application.Chapters.QueryHandlers;

public class GetAllChaptersHandler : IRequestHandler<GetAllChapters, ICollection<Chapter>>
{
    private readonly IChapterRepository _chapterRepository;

    public GetAllChaptersHandler(IChapterRepository chapterRepository)
    {
        _chapterRepository = chapterRepository;
    }

    public async Task<ICollection<Chapter>> Handle(GetAllChapters request, CancellationToken cancellationToken)
    {
        return await _chapterRepository.GetAllChapters();
    }
}
