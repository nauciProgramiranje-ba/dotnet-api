using Application.Abstractions;
using Domain.Chapter;
using Domain.Lesson;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class LessonRepository : ILessonRepository
{
    private readonly NauciProgramiranjeDbContext _context;

    public LessonRepository(NauciProgramiranjeDbContext context)
    {
        _context = context;
    }

    public async Task<Lesson> AddLesson(Lesson toCreate)
    {
        _context.Lesson.Add(toCreate);
        await _context.SaveChangesAsync();

        return toCreate;
    }

    public async Task DeleteLesson(LessonId lessonId)
    {
        var lesson = _context.Lesson
            .FirstOrDefault(l => l.Id == lessonId);

        if (lesson is null) return;

        _context.Lesson.Remove(lesson);

        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Lesson>> GetAllLessons()
    {
        return await _context.Lesson.ToListAsync();
    }

    public async Task<Lesson> GetLessonById(LessonId lessonId)
    {
        return await _context.Lesson.FirstOrDefaultAsync(l => l.Id == lessonId);
    }

    public async Task<Lesson> UpdateLesson(LessonId lessonId, ChapterId chapterId, string title, string description, string videoUrl)
    {
        var lesson = await _context.Lesson
            .FirstOrDefaultAsync(l => l.Id == lessonId);

        lesson.Title = title;
        lesson.ChapterId = chapterId;
        lesson.Description = description;
        lesson.VideoUrl = new Uri(videoUrl);

        await _context.SaveChangesAsync();

        return lesson;
    }
}
