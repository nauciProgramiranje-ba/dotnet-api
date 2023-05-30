using Domain.Chapter;
using MediatR;

namespace Application.Chapters.Queries;

public class GetAllChapters : IRequest<ICollection<Chapter>>
{
}
