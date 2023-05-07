using System;
using System.Collections.Generic;

namespace dotnet_api.Models;

public partial class Question
{
    public int Id { get; set; }

    public int LessonId { get; set; }

    public string Prompt { get; set; } = null!;

    public string Answer { get; set; } = null!;

    public bool CodeQuestion { get; set; }

    public virtual Lesson Lesson { get; set; } = null!;

    public virtual ICollection<UserProgress> UserProgresses { get; set; } = new List<UserProgress>();
}
