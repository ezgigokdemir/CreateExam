using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SinavOlusturma.Entities;

namespace SinavOlusturma.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Exam> Exam { get; set; }
        public DbSet<FormQuestion> FormQuestion { get; set; }
        public DbSet<FormQuestionOption> FormQuestionOption { get; set; }
    }
}