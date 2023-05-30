using Application.Abstractions;
using Application.Lessons.Commands;
using Domain.Lesson;
using MediatR;

namespace Application.Lessons.CommandHandlers;

public class CreateLessonHandler : IRequestHandler<CreateLesson, Lesson>
{
    private readonly ILessonRepository _lessonRepository;

    public CreateLessonHandler(ILessonRepository lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }

    public async Task<Lesson> Handle(CreateLesson request, CancellationToken cancellationToken)
    {
        var lesson = new Lesson
        {
            Id = new LessonId(Guid.NewGuid()),
            ChapterId = request.ChapterId,
            Title = request.Title,
            Description = request.Description,
            VideoUrl = request.VideoUrl,
            LessonNumber = request.LessonNumber
        };

        return await _lessonRepository.AddLesson(lesson);
    }
}
