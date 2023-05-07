using System;
using System.Collections.Generic;

namespace dotnet_api.Models;

public partial class Chapter
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
