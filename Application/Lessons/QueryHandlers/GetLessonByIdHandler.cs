using Application.Abstractions;
using Application.Lessons.Queries;
using Domain.Lesson;
using MediatR;

namespace Application.Lessons.QueryHandlers;

internal class GetLessonByIdHandler : IRequestHandler<GetLessonById, Lesson>
{
    private readonly ILessonRepository _lessonRepository;

    public GetLessonByIdHandler(ILessonRepository lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }

    public async Task<Lesson> Handle(GetLessonById request, CancellationToken cancellationToken)
    {
        return await _lessonRepository.GetLessonById(request.LessonId);
    }
}
