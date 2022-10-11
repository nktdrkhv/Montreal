using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types;
using Montreal.Bot.Poc.Abstract;

namespace Montreal.Bot.Poc.Models;

public class BotDbContext : DbContext
{
    public DbSet<Fragment> Fragments => Set<Fragment>();
    public DbSet<Step> Steps => Set<Step>();
    public DbSet<Stage> Stages => Set<Stage>();
    public DbSet<Route> Routes => Set<Route>();
    public DbSet<Feedback> Feedbacks => Set<Feedback>();

    protected DbSet<ContentBase> Content => Set<ContentBase>();
    protected DbSet<FileBase> Files => Set<FileBase>();
    protected DbSet<Audio> Audios => Set<Audio>();
    protected DbSet<Video> Videos => Set<Video>();
    protected DbSet<Sticker> Stickers => Set<Sticker>();
    protected DbSet<VideoNote> VideoNotes => Set<VideoNote>();
    protected DbSet<Sound> Sounds => Set<Sound>();
    protected DbSet<PhotoSize> Photos => Set<PhotoSize>();
    protected DbSet<Location> Locations => Set<Location>();

    public BotDbContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=Montreal.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FileBase>().HasKey(f => f.FileId);
        modelBuilder.Entity<FileBase>().ToTable("TelegramFile");
        modelBuilder.Entity<Location>().HasKey(l => new { l.Latitude, l.Longitude });
        modelBuilder.Entity<Location>().ToTable("Location");
        modelBuilder.Entity<Sticker>().Ignore(s => s.MaskPosition);
    }
}