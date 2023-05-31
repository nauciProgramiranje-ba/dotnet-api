using Application.Questions.Commands;
using Application.Questions.Queries;
using Domain.Lesson;
using Domain.Question;
using MediatR;
using WebAPI.Abstractions;
using WebAPI.Filters;

namespace WebAPI.EndpointDefinitions;

public class QuestionEndpoints : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        app.MapGet("api/lesson/{lessonId:guid}/questions", GetQuestionsByLessonId);
     
        var questions = app.MapGroup("/api/questions");

        questions.MapGet("/{id:guid}", GetQuestionById)
            .WithName("GetQueByIstiond");

        questions.MapGet("/", GetAllQuestions);

        questions.MapPost("/", CreateQuestion)
            .AddEndpointFilter<QuestionValidationFilter>();

        questions.MapPut("/{id:guid}", EditQuestion)
            .AddEndpointFilter<QuestionValidationFilter>();

        questions.MapDelete("/{id:guid}", DeleteQuestion);
    }

    private async Task<IResult> GetQuestionById(IMediator mediator, Guid id)
    {
        var getQuestion = new GetQuestionById { QuestionId = new QuestionId(id) };
        var question = await mediator.Send(getQuestion);

        return TypedResults.Ok(question);
    }

    private async Task<IResult> GetAllQuestions(IMediator mediator)
    {
        var getQuestions = new GetAllQuestions();
        var questions = await mediator.Send(getQuestions);

        return TypedResults.Ok(questions);
    }

    private async Task<IResult> GetQuestionsByLessonId(IMediator mediator, Guid lessonId)
    {
        var getQuestionsByLessonId = new GetQuestionsByLessonId { LessonId = new LessonId(lessonId) };
        var questions = await mediator.Send(getQuestionsByLessonId);

        return TypedResults.Ok(questions);
    }

    private async Task<IResult> CreateQuestion(IMediator mediator, Question question)
    {
        var createQuestion = new CreateQuestion 
        { 
            LessonId = question.LessonId,
            Prompt = question.Prompt, 
            Answer = question.Answer, 
            IsCodeQuestion = question.IsCodeQuestion, 
            QuestionNumber = question.QuestionNumber 
        };
        var createdQuestion = await mediator.Send(createQuestion);

        return TypedResults.Ok(createdQuestion);
    }

    private async Task<IResult> EditQuestion(IMediator mediator, Question question, Guid id)
    {
        var updateQuestion = new UpdateQuestion
        {
            QuestionId = new QuestionId(id),
            LessonId = question.LessonId,
            Prompt = question.Prompt,
            Answer = question.Answer,
            IsCodeQuestion = question.IsCodeQuestion,
            QuestionNumber = question.QuestionNumber
        };
        var updatedQuestion = await mediator.Send(updateQuestion);

        return TypedResults.Ok(updatedQuestion);
    }

    private async Task<IResult> DeleteQuestion(IMediator mediator, Guid id)
    {
        var deleteQuestion = new DeleteQuestion { QuestionId = new QuestionId(id) };
        await mediator.Send(deleteQuestion);

        return TypedResults.NoContent();
    }
}
