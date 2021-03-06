using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

// For more information about this template visit http://aka.ms/azurebots-csharp-basic


[LuisModel("2181d3e3-76a7-45ba-91f9-0eb12aecb48a", "d5b5959666e84d2989eed9fbee088a0d")]
[Serializable]
public class RootLuisDialog : LuisDialog<object>
{
    [LuisIntent("tell.joke")]
    public async Task TellAJoke(IDialogContext context, LuisResult result)
    {
        var message = await argument;
        await context.PostAsync("A Joke");
        context.Wait(this.TellAJoke);
    }

    [LuisIntent("")]
    [LuisIntent("None")]
    public async Task DidntUnderstand(IDialogContext context, LuisResult result)
    {
        var message = await argument;
        await context.PostAsync("Sorry i dont understand");
        context.Wait(this.DidntUnderstand);
    }


}