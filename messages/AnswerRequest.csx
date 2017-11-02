using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

// For more information about this template visit http://aka.ms/azurebots-csharp-basic
[Serializable]
public class AnswerRequest : IDialog<object>
{

    public Task StartAsync(IDialogContext context)
    {
        try
        {
            context.Wait(MessageReceivedAsync);
        }
        catch (OperationCanceledException error)
        {
            return Task.FromCanceled(error.CancellationToken);
        }
        catch (Exception error)
        {
            return Task.FromException(error);
        }

        return Task.CompletedTask;
    }

    public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
    {
        var message = await argument;
            await context.PostAsync($"You said {message.Text}");
            context.Wait(MessageReceivedAsync);
    }

}


[LuisModel("2181d3e3-76a7-45ba-91f9-0eb12aecb48a", "d5b5959666e84d2989eed9fbee088a0d")]
public class RootLuisDialog : LuisDialog<object>
{
    [LuisIntent("tell.joke")]
    public async Task TellAJoke(IDialogContext context, LuisResult result)
    {
        var message = await argument;
        await context.PostAsync($"A Joke");
        context.Wait(MessageReceivedAsync);
    }

    [LuisIntent("")]
    [LuisIntent("None")]
    public async Task DidntUnderstand(IDialogContext context, LuisResult result)
    {
        var message = await argument;
        await context.PostAsync($"Sorry i dont understand");
        context.Wait(MessageReceivedAsync);
    }
}