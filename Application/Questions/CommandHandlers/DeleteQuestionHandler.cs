using Application.Abstractions;
using Application.Questions.Commands;
using MediatR;

namespace Application.Questions.CommandHandlers;

public class DeleteQuestionHandler : IRequestHandler<DeleteQuestion, Unit>
{
    IQuestionRepository _questionRepository;

    public DeleteQuestionHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<Unit> Handle(DeleteQuestion request, CancellationToken cancellationToken)
    {
        await _questionRepository.DeleteQuestion(request.QuestionId);

        return Unit.Value;
    }
}
