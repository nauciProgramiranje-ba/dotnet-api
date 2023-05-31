using Domain.Question;
using MediatR;

namespace Application.Questions.Commands;

public class DeleteQuestion : IRequest
{
    public QuestionId QuestionId { get; set; }
}
