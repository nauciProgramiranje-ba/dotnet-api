using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dotnet_api.Models;

namespace dotnet_api.Data
{
    public class dotnet_apiContext : DbContext
    {
        public dotnet_apiContext (DbContextOptions<dotnet_apiContext> options)
            : base(options)
        {
        }

        public DbSet<dotnet_api.Models.Chapter> Chapter { get; set; } = default!;
    }
}
