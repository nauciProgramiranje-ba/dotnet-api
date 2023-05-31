using Application.Abstractions;
using Domain.Chapter;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ChapterRepository : IChapterRepository
{
    private readonly NauciProgramiranjeDbContext _context;

    public ChapterRepository(NauciProgramiranjeDbContext context)
    {
        _context = context;
    }

    public async Task<Chapter> AddChapter(Chapter toCreate)
    {
        toCreate.AddedDate = DateTime.Now;
        toCreate.LastModified = DateTime.Now;

        _context.Chapter.Add(toCreate);
        await _context.SaveChangesAsync();

        return toCreate;
    }

    public async Task DeleteChapter(ChapterId chapterId)
    {
        var chapter = _context.Chapter
            .FirstOrDefault(c => c.Id == chapterId);

        if (chapter is null) return;

        _context.Chapter.Remove(chapter);

        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Chapter>> GetAllChapters()
    {
        return await _context.Chapter.OrderBy(c => c.ChapterNumber).ToListAsync();
    }

    public async Task<Chapter> GetChapterById(ChapterId chapterId)
    {
        return await _context.Chapter.FirstOrDefaultAsync(c => c.Id == chapterId);
    }

    public async Task<Chapter> UpdateChapter(ChapterId chapterId, string title, string description, int chapterNumber)
    {
        var chapter = await _context.Chapter
            .FirstOrDefaultAsync(c => c.Id == chapterId);

        chapter.Title = title;
        chapter.Description = description;
        chapter.ChapterNumber = chapterNumber;
        chapter.LastModified = DateTime.Now;

        await _context.SaveChangesAsync();

        return chapter;
    }
}
