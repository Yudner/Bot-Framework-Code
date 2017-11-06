using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace "your Namespace"
{
    [Serializable]
    public class FacebookLocationControlDialog : IDialog<Place>
    {
        string _title;
        public FacebookLocationControlDialog(string title)
        {
            _title = title;
        }
        public async Task StartAsync(IDialogContext context)
        {
            var reply = context.MakeMessage();

            reply.Text = _title;

            if (reply.ChannelId.Equals("facebook", StringComparison.InvariantCultureIgnoreCase))
            {
                var channelData = JObject.FromObject(new
                {
                    quick_replies = new dynamic[]
                    {
                        new
                        {
                            content_type = "location",
                        }
                    }
                });

                reply.ChannelData = channelData;
            }
            await context.PostAsync(reply);
            context.Wait(MessageReceivedAsync);
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var msg = await argument;
            var location = msg.Entities?.Where(t => t.Type == "Place").Select(t => t.GetAs<Place>()).FirstOrDefault();
            context.Done(location);

        }

    }
}
