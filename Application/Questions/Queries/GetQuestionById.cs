using Domain.Question;
using MediatR;

namespace Application.Questions.Queries;

public class GetQuestionById : IRequest<Question>
{
    public QuestionId QuestionId { get; set; }
}
