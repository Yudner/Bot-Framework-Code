using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace DemoMeetupBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var message = await result as Activity;
            if(message.Text.ToLower().Contains("hola") || message.Text.ToLower().Contains("opciones"))
            {
                //opciones principales
                context.Call(new Opciones(), OpcionesResume);
            }
        }

        private async Task OpcionesResume(IDialogContext context, IAwaitable<string> result)
        {
            var option = await result;
            switch (option)
            {
                case "Reservas":
                    //menú
                    var reply = context.MakeMessage();
                    reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                    reply.Attachments = ReservaCard();
                    await context.PostAsync(reply);
                    context.Wait(MessageReceivedOption);
                    break;
                case "Reclamos":
                    await Reclamos(context);

                    break;
                default:
                    break;
            }

        }

        private async Task Reclamos(IDialogContext context)
        {
            await Task.Delay(2000);
            await context.PostAsync("😥 Gracias por reportar tu reclamo, por favor ingresa al siguiente enlace: ");
            var reply = context.MakeMessage();
            reply.Attachments.Add(Web());
            await context.PostAsync(reply);
        }

        private async Task MessageReceivedOption(IDialogContext context, IAwaitable<object> result)
        {
            await Task.Delay(2000);
            await context.PostAsync("Felicitaciones tu reserva está lista");
            context.Done<string>(null);
        }

        #region Cards

        private Attachment Web()
        {
            var web = new HeroCard()
            {
                Title = "Soporte al cliente",
                Buttons = new List<CardAction>()
                {
                    new CardAction(type: ActionTypes.OpenUrl, title: "Ir a la web", value: "https://azure.microsoft.com/es-es/support/options/")
                }
            }.ToAttachment();

            return web;
        }
        private List<Attachment> ReservaCard()
        {
            var lista = new List<Attachment>();

            var card1 = new HeroCard()
            {
                Title = "Trujillo - S/ 300.00",
                Subtitle = "Lugar para un buen fin de semana",
                Images = new List<CardImage> { new CardImage(url: "https://reservabotstorage.blob.core.windows.net/images/Trujillo.jpg") },
                Buttons = new List<CardAction>()
                {
                    new CardAction(type: ActionTypes.ImBack, title: "Trujillo", value: "Trujillo")
                }
            }.ToAttachment();

            var card2 = new HeroCard()
            {
                Title = "Piura - S/ 400.00",
                Subtitle = "Lugar para un buen fin de semana",
                Images = new List<CardImage> { new CardImage(url: "https://reservabotstorage.blob.core.windows.net/images/piura.jpg") },
                Buttons = new List<CardAction>()
                {
                    new CardAction(type: ActionTypes.ImBack, title: "Piura", value: "Piura")
                }
            }.ToAttachment();

            lista.Add(card1);
            lista.Add(card2);
            return lista;
        }

        #endregion
    }
}