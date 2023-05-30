using Application.Abstractions;
using Application.Chapters.Queries;
using Domain.Chapter;
using MediatR;

namespace Application.Chapters.QueryHandlers;

public class GetChapterByIdHandler : IRequestHandler<GetChapterById, Chapter>
{
    private readonly IChapterRepository _chapterRepository;

    public GetChapterByIdHandler(IChapterRepository chapterRepository)
    {
        _chapterRepository = chapterRepository;
    }

    public async Task<Chapter> Handle(GetChapterById request, CancellationToken cancellationToken)
    {
        return await _chapterRepository.GetChapterById(request.ChapterId);
    }
}
