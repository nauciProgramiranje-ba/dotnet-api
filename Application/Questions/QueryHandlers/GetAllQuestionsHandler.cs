using Application.Abstractions;
using Application.Questions.Queries;
using Domain.Question;
using MediatR;

namespace Application.Questions.QueryHandlers;

public class GetAllQuestionsHandler : IRequestHandler<GetAllQuestions, ICollection<Question>>
{
    IQuestionRepository _questionRepository;

    public GetAllQuestionsHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<ICollection<Question>> Handle(GetAllQuestions request, CancellationToken cancellationToken)
    {
        return await _questionRepository.GetAllQuestions();
    }
}
