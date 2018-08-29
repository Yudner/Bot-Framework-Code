using Enterprise.Chatbot.Common.Constants;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Chatbot.Operations.Dialogs
{
    [Serializable]
    [LuisModel(LUISOperationsConstants.MODELID, LUISConstants.SUSBSCRIPTION, domain: LUISConstants.DOMAIN)]
    public class OperationsDialog : LuisDialog<string>
    {
        #region LUIS Intent

        [LuisIntent(LUISConstants.NONE)]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("");
        }

        [LuisIntent(LUISOperationsConstants.MAKERESERVATION)]
        public async Task MakeReservation(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("");
        }

        [LuisIntent(LUISOperationsConstants.SUBSCRIBENOTIFICATIONS)]
        public async Task SubscribeNotifications(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("");
        }
        #endregion
    }
}
