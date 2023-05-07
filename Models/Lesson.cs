﻿namespace dotnet_api.Models;

public partial class Lesson
{
    public int Id { get; set; }

    public int ChapterId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Video { get; set; } = null!;

}