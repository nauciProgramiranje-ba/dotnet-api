﻿using Application.Abstractions;
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
            Id = new QuestionId(Guid.NewGuid()),
            LessonId = request.LessonId,
            Prompt = request.Prompt,
            Answer = request.Answer,
            IsCodeQuestion = request.IsCodeQuestion,
            QuestionNumber = request.QuestionNumber,
            PossibleAnswers = request.PossibleAnswers,
            AddedDate = DateTime.Now,
            LastModified = DateTime.Now,
        };

        return await _questionRepository.AddQuestion(question);
    }
}
