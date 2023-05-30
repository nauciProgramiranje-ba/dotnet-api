using Domain.Chapter;
using MediatR;

namespace Application.Chapters.Commands;

public class DeleteChapter : IRequest
{
    public ChapterId ChapterId { get; set; }
}
