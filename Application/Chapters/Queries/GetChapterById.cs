using Domain.Chapter;
using MediatR;

namespace Application.Chapters.Queries;

public class GetChapterById : IRequest<Chapter>
{
    public ChapterId ChapterId { get; set; }
}
