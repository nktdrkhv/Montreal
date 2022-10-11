using Montreal.Bot.Poc.Models;
using Montreal.Bot.Poc.Interfaces;
using Montreal.Bot.Poc.Infrastructure;

namespace Montreal.Bot.Poc.Services;

public class AppRepositoryService : IAppRepository
{
    private BotDbContext _context;

    public AppRepositoryService(BotDbContext context)
    {
        _context = context;
    }

    public async Task<Stage> GetStartStageAsync()
    {
        var stage = new Stage
        {
            Id = 1,
            Name = "Init",
            Type = StageType.Start,
        };
        var stepOrder = new StepInStage[]
        {
            new()
            {
                Id = 10,
                AttachedStage = stage,
                Order = 2,
                Payload = new()
                {
                    Fragments = new[]
                    {
                        new Fragment()
                        {
                            Type = FragmentType.Text,
                            Text = "Текст 2"
                        }
                    }
                }
            },
            new()
            {
                Id = 10,
                AttachedStage = stage,
                Order = 1,
                Payload = new()
                {
                    Fragments = new[]
                    {
                        new Fragment()
                        {
                            Type = FragmentType.Text,
                            Text = "Текст 1"
                        }
                    }
                }
            }
        };
        stage.Steps = stepOrder;
        return await Task.FromResult<Stage>(stage);
    }
    public Task<Stage> GetFinalStageAsync() => throw new NotImplementedException();

    public Task<Step> GetStepAsync(Step fragment) => throw new NotImplementedException();
    public Task<Stage> GetStageAsync(Stage stage) => throw new NotImplementedException();
    public Task<Route> GetRouteAsync(Route route) => throw new NotImplementedException();

    public Task<Step> AddStepAsync(Step fragment) => throw new NotImplementedException();
    public Task<Stage> AddStageAsync(Stage stage) => throw new NotImplementedException();
    public Task<Route> AddRouteAsync(Route route) => throw new NotImplementedException();
}