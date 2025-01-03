﻿using Blogge.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blogge.Web.Data
{
    public class BloggieDbContext : DbContext
    {
        public BloggieDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<testTabel> Test {  get; set; }
    }
}
