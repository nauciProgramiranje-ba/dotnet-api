using Application.Abstractions;
using Application.Questions.Queries;
using Domain.Question;
using MediatR;

namespace Application.Questions.QueryHandlers;

public class GetQuestionByIdHandler : IRequestHandler<GetQuestionById, Question>
{
    IQuestionRepository _questionRepository;

    public GetQuestionByIdHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<Question> Handle(GetQuestionById request, CancellationToken cancellationToken)
    {
        return await _questionRepository.GetQuestionById(request.QuestionId);
    }
}
