using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DemoMeetupBot.Dialogs
{
    [Serializable]
    public class Opciones : IDialog<string>
    {
        List<string> options = new List<string>();

        public Opciones()
        {
            options.Add("Reservas");
            options.Add("Reclamos");
        }
        public async Task StartAsync(IDialogContext context)
        {
            var reply = context.MakeMessage();
            reply.AddHeroCard("Tengo estas opciones para ti 😊: ", options, options);
            await context.PostAsync(reply);
            context.Wait(MessageReceived);
        }

        private async Task MessageReceived(IDialogContext context, IAwaitable<object> result)
        {
            var message = await result as Activity;
            context.Done(message.Text);
        }
    }
}