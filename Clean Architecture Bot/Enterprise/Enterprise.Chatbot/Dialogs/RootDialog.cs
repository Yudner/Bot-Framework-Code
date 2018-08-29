using System;
using System.Threading.Tasks;
using Enterprise.Chatbot.Common.Constants;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;

namespace Enterprise.Chatbot.Dialogs
{
    [Serializable]
    [LuisModel(LUISRootConstants.MODELID, LUISConstants.SUSBSCRIPTION, domain: LUISConstants.DOMAIN)]

    public class RootDialog : LuisDialog<string>
    {
        #region LUIS Intent

        [LuisIntent(LUISConstants.NONE)]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await MessageError(context, result.Query);
        }

        [LuisIntent(LUISRootConstants.GREETINGS)]
        public async Task Greetings(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Hi");

        }

        [LuisIntent(LUISRootConstants.HELP)]
        public async Task Help(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Help");

        }
        #endregion


        #region Methods
        private async Task MessageError(IDialogContext context, string query)
        {
            await context.PostAsync("");
        }
        #endregion
    }
}