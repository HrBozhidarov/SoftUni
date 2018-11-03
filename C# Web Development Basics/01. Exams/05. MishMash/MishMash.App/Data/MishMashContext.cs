using Microsoft.EntityFrameworkCore;
using MishMash.App.Models;

namespace MishMash.App.Data
{
    public class MishMashContext : DbContext
    {
        public MishMashContext(DbContextOptions options) : base(options)
        {
        }

        public MishMashContext()
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Channel> Channels { get; set; }

        public DbSet<UserChannel> UsersChannels { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<ChannelTag> ChannelTags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=SomeServer;Database=MishMash;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserChannel>().HasKey(x => new { x.ChannelId, x.UserId });

            modelBuilder.Entity<ChannelTag>().HasKey(x => new { x.ChannelId, x.TagId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
