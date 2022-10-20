using Montreal.Bot.Poc.Models;

namespace Montreal.Bot.Poc.Interfaces;

public interface IAppRepository
{
    IQueryable<Target> Targets { get; }
    IQueryable<Fragment> Fragments { get; }
    IQueryable<Step> Steps { get; }
    IQueryable<StepInStage> StepsInStage { get; }
    IQueryable<Stage> Stages { get; }
    IQueryable<StageSequence> Sequences { get; }
    IQueryable<Route> Routes { get; }
    IQueryable<Feedback> Feedbacks { get; }
    IQueryable<Person> People { get; }

    Person GetPerson(long telegramId);

    // Step GetStep(string name);
    // Stage GetStage(string name);
    // Route GetRoute(string name);

    // Step AddStep(Step step);
    // Stage AddStage(Stage stage);
    // Route AddRoute(Route route);
    // Target AddTarget(string name);

    void SaveAndDispose();
}