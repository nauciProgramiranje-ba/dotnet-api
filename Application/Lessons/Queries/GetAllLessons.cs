using Domain.Lesson;
using MediatR;

namespace Application.Lessons.Queries;

public class GetAllLessons : IRequest<ICollection<Lesson>>
{
}
