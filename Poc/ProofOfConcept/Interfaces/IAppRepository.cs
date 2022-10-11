using Montreal.Bot.Poc.Models;

namespace Montreal.Bot.Poc.Interfaces;

public interface IAppRepository
{
    Task<Stage> GetStartStageAsync();
    Task<Stage> GetFinalStageAsync();

    Task<Step> GetStepAsync(Step step);
    Task<Stage> GetStageAsync(Stage stage);
    Task<Route> GetRouteAsync(Route route);

    Task<Step> AddStepAsync(Step step);
    Task<Stage> AddStageAsync(Stage stage);
    Task<Route> AddRouteAsync(Route route);
}