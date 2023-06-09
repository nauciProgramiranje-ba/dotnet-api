﻿using Domain.Chapter;
using MediatR;

namespace Application.Chapters.Commands;

public class CreateChapter : IRequest<Chapter>
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public int ChapterNumber { get; set; }

    public int DurationInHrs { get; set; }
}
