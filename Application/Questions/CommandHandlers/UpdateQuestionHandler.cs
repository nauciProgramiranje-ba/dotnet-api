using Application.Abstractions;
using Application.Questions.Commands;
using Domain.Question;
using MediatR;

namespace Application.Questions.CommandHandlers;

public class UpdateQuestionHandler : IRequestHandler<UpdateQuestion, Question>
{
    IQuestionRepository _questionRepository;

    public UpdateQuestionHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<Question> Handle(UpdateQuestion request, CancellationToken cancellationToken)
    {
        var question = await _questionRepository.UpdateQuestion(request.QuestionId, request.LessonId, request.Prompt, request.Answer, request.IsCodeQuestion, request.QuestionNumber);
        return question;
    }
}
