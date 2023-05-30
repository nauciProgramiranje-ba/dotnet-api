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
        return await _context.Question.ToListAsync();
    }

    public async Task<Question> GetQuestionById(QuestionId questionId)
    {
        return await _context.Question.FirstOrDefaultAsync(q => q.Id == questionId);
    }

    public async Task<Question> UpdateQuestion(QuestionId questionId, LessonId lessonId, string prompt, string answer, bool isCodeQuestion)
    {
        var question = await _context.Question
            .FirstOrDefaultAsync(q => q.Id == questionId);

        question.Prompt = prompt;
        question.Answer = answer;
        question.IsCodeQuestion = isCodeQuestion;

        await _context.SaveChangesAsync();

        return question;
    }
}
