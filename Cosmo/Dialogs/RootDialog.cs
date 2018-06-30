using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Web;
using System.Net;
using System.Xml;
using System.Text.RegularExpressions;

namespace Cosmo.Dialogs
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
            var activity = await result as Activity;

            var webClient = new WebClient();
            var pageSourceCode = webClient.DownloadString("http://en.wikipedia.org/w/api.php?format=xml&action=query&prop=extracts&exsentences=2&titles=" + activity.Text + "&redirects=true");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(pageSourceCode);
            var fnode = doc.GetElementsByTagName("extract")[0];

            try
            {
                string ss = fnode.InnerText;
                Regex regex = new Regex("\\<[^\\>]*\\>");
                string.Format("Before:{0}", ss);
                ss = regex.Replace(ss, string.Empty);
                string res = String.Format(ss);
                await context.PostAsync(res);

            }
            catch(Exception)
            {
                await context.PostAsync("error");
            }


            //var url = "https://en.wikipedia.org/w/api.php?format=xml&action=query&prop=extracts&exintro=&exsentences=1&explaintext=&titles=";


            // Calculate something for us to return
            //int length = (activity.Text ?? string.Empty).Length;
            //var data = url + activity.Text;
           
            // Return our reply to the user
            //await context.PostAsync($"You sent {activity.Text} which was {length} characters");
            //await context.PostAsync($"{data}");

            //Strings conditions = await GetWiki.GetData(data);
            //await context.PostAsync(string.Format("Title :{0}", conditions));

            context.Wait(MessageReceivedAsync);
        }
    }
}