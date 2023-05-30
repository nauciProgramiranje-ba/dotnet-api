using Application.Abstractions;
using Application.Lessons.Queries;
using Domain.Lesson;
using MediatR;

namespace Application.Lessons.QueryHandlers;

public class GetAllLessonsHandler : IRequestHandler<GetAllLessons, ICollection<Lesson>>
{
    private readonly ILessonRepository _lessonRepository;

    public GetAllLessonsHandler(ILessonRepository lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }

    public async Task<ICollection<Lesson>> Handle(GetAllLessons request, CancellationToken cancellationToken)
    {
        return await _lessonRepository.GetAllLessons();
    }
}
