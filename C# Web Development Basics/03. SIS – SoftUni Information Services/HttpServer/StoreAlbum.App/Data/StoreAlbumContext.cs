namespace StoreAlbum.App.Data
{
    using Microsoft.EntityFrameworkCore;
    using StoreAlbum.App.Models;

    public class StoreAlbumContext : DbContext
    {
        public StoreAlbumContext()
        {
        }

        public StoreAlbumContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Track> Tracks { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<AlbumTrack> AlbumsTracks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(@"Server=DESKTOP-N9Q97SK\SQLEXPRESS;Database=StoreAlbums;Integrated Security=True");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlbumTrack>().HasKey(x => new { x.AlbumId, x.TrackId });

            modelBuilder.Entity<AlbumTrack>()
            .HasOne(x => x.Album)
            .WithMany(x => x.Tracks)
            .HasForeignKey(x => x.AlbumId);

            modelBuilder.Entity<AlbumTrack>()
            .HasOne(x => x.Track)
            .WithMany(x => x.Albums)
            .HasForeignKey(x => x.TrackId);
        }
    }
}
