using Stateless;
using Geolocation;
using Montreal.Bot.Poc.Interfaces;
using Montreal.Bot.Poc.Models;

namespace Montreal.Bot.Poc.Infrastructure;

public class PersonBehaviour : IChatBehaviour
{
    public ITelegramChat Chat { get; set; }

    private Coordinate? _target;

    private PersonState _state;


    public PersonBehaviour(ITelegramChat chat)
    {
        Chat = chat;
    }

    public Task SubmitAsync(string text) => throw new NotImplementedException();
    public Task SubmitAsync(Command command) => throw new NotImplementedException();
    public Task SubmitAsync(Fragment fragment) => throw new NotImplementedException();
}