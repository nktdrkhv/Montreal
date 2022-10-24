using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types;
using Montreal.Bot.Poc.Abstract;

namespace Montreal.Bot.Poc.Models;

public class BotDbContext : DbContext
{
    public DbSet<Target> Targets => Set<Target>();
    public DbSet<Media> Media => Set<Media>();
    public DbSet<Fragment> Fragments => Set<Fragment>();
    public DbSet<Step> Steps => Set<Step>();
    public DbSet<StepInStage> StepsInStage => Set<StepInStage>();
    public DbSet<Stage> Stages => Set<Stage>();
    public DbSet<StageSequence> Sequences => Set<StageSequence>();
    public DbSet<Route> Routes => Set<Route>();
    public DbSet<ContentPointer> Pointers => Set<ContentPointer>();

    public DbSet<Person> People => Set<Person>();
    public DbSet<Feedback> Feedbacks => Set<Feedback>();
    public DbSet<Activity> Activities => Set<Activity>();


    public DbSet<FileIdentity> FileIdentities => Set<FileIdentity>();
    public DbSet<ContentBase> Content => Set<ContentBase>();
    public DbSet<FileBase> Files => Set<FileBase>();


    public BotDbContext()
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=Montreal.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FileBase>().HasKey(f => f.FileId);
        modelBuilder.Entity<FileBase>().ToTable("TelegramFile");
        modelBuilder.Entity<Sticker>().Ignore(s => s.MaskPosition);
        modelBuilder.Entity<Button>().Property(b => b.Label).HasField("_label");

        /*-----------------------------------------------------------------------------*/

        modelBuilder.Entity<Target>().HasOne(t => t.Pointer);
        modelBuilder.Entity<Fragment>().HasMany(f => f.Buttons);
        modelBuilder.Entity<Fragment>().HasMany(f => f.Media);
        modelBuilder.Entity<Stage>().HasOne(s => s.Location);
        modelBuilder.Entity<Feedback>().HasOne(f => f.Cause);
        modelBuilder.Entity<Feedback>().HasMany(f => f.Payload);
        modelBuilder.Entity<Person>().HasMany(p => p.ActivityLog);
        modelBuilder.Entity<Activity>().HasOne(a => a.Pointer);

        modelBuilder.Entity<FileBase>().Ignore(fb => fb.FileUniqueId);
        modelBuilder.Entity<Audio>().Ignore(fb => fb.FileUniqueId);
        modelBuilder.Entity<PhotoSize>().Ignore(fb => fb.FileUniqueId);

        /*-----------------------------------------------------------------------------*/

        modelBuilder.Entity<Route>().Navigation(r => r.InitialStage).AutoInclude();
        modelBuilder.Entity<Route>().Navigation(r => r.Stages).AutoInclude();
        modelBuilder.Entity<StageSequence>().Navigation(s => s.To).AutoInclude();
        modelBuilder.Entity<StageSequence>().Navigation(s => s.From).AutoInclude();
        modelBuilder.Entity<Stage>().Navigation(s => s.Steps).AutoInclude();
        modelBuilder.Entity<Stage>().Navigation(s => s.Location).AutoInclude();
        modelBuilder.Entity<StepInStage>().Navigation(s => s.Payload).AutoInclude();
        modelBuilder.Entity<Fragment>().Navigation(f => f.Media).AutoInclude();
        modelBuilder.Entity<Fragment>().Navigation(f => f.Buttons).AutoInclude();
        modelBuilder.Entity<Button>().Navigation(b => b.Target).AutoInclude();
        modelBuilder.Entity<Target>().Navigation(t => t.Pointer).AutoInclude();
        modelBuilder.Entity<ContentPointer>().Navigation(p => p.Stage).AutoInclude();
        modelBuilder.Entity<ContentPointer>().Navigation(p => p.Step).AutoInclude();
        modelBuilder.Entity<ContentPointer>().Navigation(p => p.Route).AutoInclude();
        modelBuilder.Entity<Activity>().Navigation(a => a.Pointer).AutoInclude();
        modelBuilder.Entity<Media>().Navigation(m => m.Sound).AutoInclude();
        modelBuilder.Entity<Media>().Navigation(m => m.Photo).AutoInclude();
        modelBuilder.Entity<Sound>().Navigation(s => s.Audio).AutoInclude();
    }
}