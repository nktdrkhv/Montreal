using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types;
using Montreal.Bot.Poc.Abstract;

namespace Montreal.Bot.Poc.Models;

public class BotDbContext : DbContext
{
    public DbSet<Target> Targets => Set<Target>();
    public DbSet<Fragment> Fragments => Set<Fragment>();
    public DbSet<Step> Steps => Set<Step>();
    public DbSet<StepInStage> StepsInStage => Set<StepInStage>();
    public DbSet<Stage> Stages => Set<Stage>();
    public DbSet<StageSequence> Sequences => Set<StageSequence>();
    public DbSet<Route> Routes => Set<Route>();

    public DbSet<Person> People => Set<Person>();
    public DbSet<Feedback> Feedbacks => Set<Feedback>();
    public DbSet<Activity> Activities => Set<Activity>();

    protected DbSet<ContentBase> Content => Set<ContentBase>();
    protected DbSet<FileBase> Files => Set<FileBase>();

    public BotDbContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=Montreal.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FileBase>().HasKey(f => f.FileId);
        modelBuilder.Entity<FileBase>().ToTable("TelegramFile");
        modelBuilder.Entity<Sticker>().Ignore(s => s.MaskPosition);
        modelBuilder.Entity<Button>().Property(b => b.Label).HasField("_label");
        //modelBuilder.Entity<Target>().Property(t => t.Pointer).HasField("_pointer");
        modelBuilder.Entity<Target>().HasOne(t => t.Pointer);
        modelBuilder.Entity<Fragment>().OwnsOne(f => f.Timer);
        modelBuilder.Entity<Fragment>().HasMany(f => f.Buttons);
        modelBuilder.Entity<Fragment>().OwnsMany(f => f.Media);
        modelBuilder.Entity<Stage>().OwnsOne(s => s.Location);
        modelBuilder.Entity<Feedback>().OwnsOne(f => f.Cause);
        modelBuilder.Entity<Feedback>().HasMany(f => f.Payload);
        modelBuilder.Entity<Person>().HasMany(p => p.ActivityLog);
        modelBuilder.Entity<Activity>().OwnsOne(a => a.Pointer);
    }
}