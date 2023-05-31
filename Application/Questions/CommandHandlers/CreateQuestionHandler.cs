using Application.Abstractions;
using Application.Questions.Commands;
using Domain.Question;
using MediatR;

namespace Application.Questions.CommandHandlers;

public class CreateQuestionHandler : IRequestHandler<CreateQuestion, Question>
{
    IQuestionRepository _questionRepository;

    public CreateQuestionHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<Question> Handle(CreateQuestion request, CancellationToken cancellationToken)
    {
        var question = new Question
        {
            LessonId = request.LessonId,
            Prompt = request.Prompt,
            Answer = request.Answer,
            IsCodeQuestion = request.IsCodeQuestion,
            QuestionNumber = request.QuestionNumber,
            AddedDate = DateTime.Now,
            LastModified = DateTime.Now,
        };

        return await _questionRepository.AddQuestion(question);
    }
}
