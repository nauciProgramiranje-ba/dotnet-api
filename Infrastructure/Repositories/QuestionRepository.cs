using Application.Abstractions;
using Domain.Chapter;
using Domain.Lesson;
using Domain.Question;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class QuestionRepository : IQuestionRepository
{
    private readonly NauciProgramiranjeDbContext _context;

    public QuestionRepository(NauciProgramiranjeDbContext context)
    {
        _context = context;
    }
    public async Task<Question> AddQuestion(Question toCreate)
    {
        toCreate.AddedDate = DateTime.Now;
        toCreate.LastModified = DateTime.Now;

        _context.Question.Add(toCreate);
        await _context.SaveChangesAsync();

        return toCreate;
    }

    public async Task DeleteQuestion(QuestionId questionId)
    {
        var question = _context.Question
            .FirstOrDefault(q => q.Id == questionId);

        if (question is null) return;

        _context.Question.Remove(question);

        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Question>> GetAllQuestions()
    {
        return await _context.Question.OrderBy(q => q.QuestionNumber).ToListAsync();
    }

    public async Task<Question> GetQuestionById(QuestionId questionId)
    {
        return await _context.Question.FirstOrDefaultAsync(q => q.Id == questionId);
    }

    public async Task<Question> UpdateQuestion(QuestionId questionId, LessonId lessonId, string prompt, string answer, bool isCodeQuestion, int questionNumber)
    {
        var question = await _context.Question
            .FirstOrDefaultAsync(q => q.Id == questionId);

        question.Prompt = prompt;
        question.Answer = answer;
        question.IsCodeQuestion = isCodeQuestion;
        question.QuestionNumber = questionNumber;
        question.LastModified = DateTime.Now;

        await _context.SaveChangesAsync();

        return question;
    }
}
