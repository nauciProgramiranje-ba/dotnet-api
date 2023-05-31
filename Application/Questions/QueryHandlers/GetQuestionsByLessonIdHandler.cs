using Application.Abstractions;
using Application.Questions.Queries;
using Domain.Question;
using MediatR;

namespace Application.Questions.QueryHandlers;

public class GetQuestionsByLessonIdHandler : IRequestHandler<GetQuestionsByLessonId, ICollection<Question>>
{
    IQuestionRepository _questionRepository;

    public GetQuestionsByLessonIdHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<ICollection<Question>> Handle(GetQuestionsByLessonId request, CancellationToken cancellationToken)
    {
        return await _questionRepository.GetQuestionsByLessonId(request.LessonId);
    }
}
