using Enterprise.Chatbot.Common.Constants;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Chatbot.Information.Dialogs
{
    [Serializable]
    [LuisModel(LUISInformationConstants.MODELID, LUISConstants.SUSBSCRIPTION, domain: LUISConstants.DOMAIN)]
    public class InformationDialog : LuisDialog<string>
    {
        #region LUIS Intent

        [LuisIntent(LUISConstants.NONE)]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("");
        }

        [LuisIntent(LUISInformationConstants.SEEMOVEMENTS)]
        public async Task SeeMovements(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("");
        }

        [LuisIntent(LUISInformationConstants.UPDATEDATA)]
        public async Task UpdateData(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("");
        }

        #endregion
    }
}
