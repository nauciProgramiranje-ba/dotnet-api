using Application.Abstractions;
using Application.Lessons.Queries;
using Domain.Chapter;
using Domain.Lesson;
using MediatR;

namespace Application.Lessons.QueryHandlers;

public class GetLessonsByChapterIdHandler : IRequestHandler<GetLessonsByChapterId, ICollection<Lesson>>
{
    private readonly ILessonRepository _lessonRepository;

    public GetLessonsByChapterIdHandler(ILessonRepository lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }

    public async Task<ICollection<Lesson>> Handle(GetLessonsByChapterId request, CancellationToken cancellationToken)
    {
        return await _lessonRepository.GetLessonsByChapterId(request.ChapterId);
    }
}
