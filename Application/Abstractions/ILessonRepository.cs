using Domain.Chapter;
using Domain.Lesson;

namespace Application.Abstractions;

public interface ILessonRepository
{
    Task<ICollection<Lesson>> GetAllLessons();

    Task<Lesson> GetLessonById(LessonId lessonId);

    Task<Lesson> AddLesson(Lesson toCreate);

    Task<Lesson> UpdateLesson(LessonId lessonId, ChapterId chapterId, string title, string description, Uri videoUrl, int lessonNumber);

    Task DeleteLesson(LessonId lessonId);
}
