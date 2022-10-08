using Montreal.Bot.Poc.Models;

namespace Montreal.Bot.Poc.Interfaces;

public interface IAppRepository
{
    Task AddStepAsync(Step fragment);
    Task AddStageAsync(Stage stage);
    Task AddRouteAsync(Stage stage);
}