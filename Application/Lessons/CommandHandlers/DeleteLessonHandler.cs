using Application.Abstractions;
using Application.Lessons.Commands;
using MediatR;

namespace Application.Lessons.CommandHandlers;

public class DeleteLessonHandler : IRequestHandler<DeleteLesson, Unit>
{
    private readonly ILessonRepository _lessonRepository;

    public DeleteLessonHandler(ILessonRepository lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }

    public async Task<Unit> Handle(DeleteLesson request, CancellationToken cancellationToken)
    {
        await _lessonRepository.DeleteLesson(request.LessonId);

        return Unit.Value;
    }
}
