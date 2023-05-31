using Domain.Lesson;
using Domain.Question;

namespace Application.Abstractions;

public interface IQuestionRepository
{
    Task<ICollection<Question>> GetAllQuestions();

    Task<ICollection<Question>> GetQuestionsByLessonId(LessonId lessonId);

    Task<Question> GetQuestionById(QuestionId questionId);

    Task<Question> AddQuestion(Question toCreate);

    Task<Question> UpdateQuestion(QuestionId questionId, LessonId lessonId, string prompt, string answer, bool isCodeQuestion, int questionNumber);

    Task DeleteQuestion(QuestionId questionId);
}
