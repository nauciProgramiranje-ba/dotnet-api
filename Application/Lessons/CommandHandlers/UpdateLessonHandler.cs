using Application.Abstractions;
using Application.Lessons.Commands;
using Domain.Lesson;
using MediatR;

namespace Application.Lessons.CommandHandlers;

public class UpdateLessonHandler : IRequestHandler<UpdateLesson, Lesson>
{
    private readonly ILessonRepository _lessonRepository;

    public UpdateLessonHandler(ILessonRepository lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }

    public async Task<Lesson> Handle(UpdateLesson request, CancellationToken cancellationToken)
    {
        var lesson = await _lessonRepository.UpdateLesson(request.LessonId, request.ChapterId, request.Title, request.Description, request.VideoUrl, request.LessonNumber);
        return lesson;
    }
}
