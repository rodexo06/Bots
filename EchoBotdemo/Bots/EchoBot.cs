// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.6.2

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace EchoBotdemo.Bots
{
    public class EchoBot : ActivityHandler
    {


        //activity é a mensagem
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            if(turnContext.Activity.Text == "Erich") await turnContext.SendActivityAsync(CreateActivityWithTextAndSpeak($"Cuzão"), cancellationToken);
            else if (turnContext.Activity.Text == "Rafael") await turnContext.SendActivityAsync(CreateActivityWithTextAndSpeak($"Monstro"), cancellationToken);
                else if (turnContext.Activity.Text == "Nathinha") await turnContext.SendActivityAsync(CreateActivityWithTextAndSpeak($"So falta integrar cuzão"), cancellationToken);
                    else if (turnContext.Activity.Text == "Jheninha") await turnContext.SendActivityAsync(CreateActivityWithTextAndSpeak($"Amor da minha vida"), cancellationToken);
                        else await turnContext.SendActivityAsync(CreateActivityWithTextAndSpeak($"Echo: {turnContext.Activity.Text}"), cancellationToken);

        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(CreateActivityWithTextAndSpeak($"Hello and NÃO LIGO!"), cancellationToken);
                }
            }
        }

        private IActivity CreateActivityWithTextAndSpeak(string message)
        {
            var activity = MessageFactory.Text(message);
            string speak = @"<speak version='1.0' xmlns='https://www.w3.org/2001/10/synthesis' xml:lang='en-US'>
              <voice name='Microsoft Server Speech Text to Speech Voice (en-US, JessaRUS)'>" +
              $"{message}" + "</voice></speak>";
            activity.Speak = speak;
            return activity;
        }
    }
}
