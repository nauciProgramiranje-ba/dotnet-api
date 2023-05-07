﻿namespace dotnet_api.Models;

public partial class Chapter
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;
}