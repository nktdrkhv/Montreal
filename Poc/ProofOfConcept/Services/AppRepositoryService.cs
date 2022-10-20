using Microsoft.Extensions.Logging;
using Montreal.Bot.Poc.Models;
using Montreal.Bot.Poc.Interfaces;
using Montreal.Bot.Poc.Infrastructure;

namespace Montreal.Bot.Poc.Services;

public class AppRepositoryService : IAppRepository
{
    #region Ctor and properties

    private BotDbContext _context;
    private ILogger<AppRepositoryService> _logger;

    public AppRepositoryService(BotDbContext context, ILogger<AppRepositoryService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IQueryable<Target> Targets => _context.Targets;
    public IQueryable<Fragment> Fragments => _context.Fragments;
    public IQueryable<Step> Steps => _context.Steps;
    public IQueryable<StepInStage> StepsInStage => _context.StepsInStage;
    public IQueryable<Stage> Stages => _context.Stages;
    public IQueryable<StageSequence> Sequences => _context.Sequences;
    public IQueryable<Route> Routes => _context.Routes;
    public IQueryable<Feedback> Feedbacks => _context.Feedbacks;
    public IQueryable<Person> People => _context.People;

    #endregion Ctor and properties

    #region Interface's mathods

    public void SaveAndDispose()
    {
        _context.SaveChanges();
        _context.Dispose();
    }

    public Person GetPerson(long telegramId)
    {
        var person = People.Where(p => p.TelegramIdentity == telegramId).SingleOrDefault();
        if (person is null)
        {
            person = new Person() { TelegramIdentity = telegramId };
            _context.People.Add(person);
            _context.SaveChanges();
        }
        return person;
    }

    // public Step GetStep(string name) => throw new NotImplementedException();
    // public Stage GetStage(string name) => throw new NotImplementedException();
    // public Route GetRoute(string name) => throw new NotImplementedException();

    // public Target AddTarget(string name) => throw new NotImplementedException();
    // public Step AddStep(Step fragment) => throw new NotImplementedException();
    // public Stage AddStage(Stage stage) => throw new NotImplementedException();
    // public Route AddRoute(Route route) => throw new NotImplementedException();

    #endregion Interface's mathods
}