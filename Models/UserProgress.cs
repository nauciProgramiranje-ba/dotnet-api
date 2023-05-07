using System;
using System.Collections.Generic;

namespace dotnet_api.Models;

public partial class UserProgress
{
    public int QuestionId { get; set; }

    public string UserId { get; set; } = null!;

    public string UserAnswer { get; set; } = null!;

    public bool IsCompleted { get; set; }

    public virtual Question Question { get; set; } = null!;
}
