using Discord;
using Discord.Interactions;
using Discord.WebSocket;

namespace Nano.Discord.Modules;

public class HasidimModule : InteractionModuleBase<SocketInteractionContext>
{
    private readonly ulong _roleId = 1089672961654526073;

    [SlashCommand("ping", "Receive a ping message.")]
    public async Task EchoCommand()
    {
        var context = Context;

        await RespondAsync("Pong!");
    }

    [SlashCommand("components", "Receive a message with components.")]
    public async Task HandleComponentCommand()
    {
        var button = new ButtonBuilder
        {
            Label = "Click me!",
            CustomId = "click_one",
            Style = ButtonStyle.Primary
        };

        var menu = new SelectMenuBuilder
        {
            CustomId = "menu",
            Placeholder = "Sample Menu"
        };
        menu.AddOption("First", "first");
        menu.AddOption("Second", "second");

        var component = new ComponentBuilder()
            .WithButton(button)
            .WithSelectMenu(menu);

        await RespondAsync("testing", components: component.Build());
    }

    [ComponentInteraction("click_one")]
    public async Task HandleButtonInteraction()
    {
        await RespondWithModalAsync<DemoModal>("demo_modal");
    }

    [ModalInteraction("demo_modal")]
    public async Task HandleModalInput(DemoModal modal)
    {
        var input = modal.Greeting;

        await RespondAsync($"You said: {input}");
    }

    [UserCommand("give-role")]
    public async Task HandleUserCommand(IUser user)
    {
        await (user as SocketGuildUser).AddRoleAsync(_roleId);

        var roles = (user as SocketGuildUser).Roles;

        var rolesList = roles.Aggregate(string.Empty, (current, role) => current + role.Name + ", ");

        await RespondAsync($"User {user.Mention} now has the following roles: {rolesList}");
    }

    [MessageCommand("msg-command")]
    public async Task HandleMessageCommand(IMessage message)
    {
        await RespondAsync($"Message content: {message.Content}");
    }
}

public class DemoModal : IModal
{
    [InputLabel("Send a greeting")]
    [ModalTextInput("greeting_input", TextInputStyle.Short, "Hello, world!")]
    public string Greeting { get; set; }

    public string Title => "Demo Modal";
}