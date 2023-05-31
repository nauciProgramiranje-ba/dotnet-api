using Domain.Question;
using MediatR;

namespace Application.Questions.Queries;

public class GetAllQuestions : IRequest<ICollection<Question>>
{
}
