using Domain.Chapter;

namespace Application.Abstractions;

public interface IChapterRepository
{
    Task<ICollection<Chapter>> GetAllChapters();
    
    Task<Chapter> GetChapterById(ChapterId chapterId);
    
    Task<Chapter> AddChapter(Chapter toCreate);

    Task<Chapter> UpdateChapter(ChapterId chapterId, string title, string description, int chapterNumber);

    Task DeleteChapter(ChapterId chapterId);
}
