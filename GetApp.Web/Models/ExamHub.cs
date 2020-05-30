using GetApp.Data.Models;
using GetApp.Web;
using Microsoft.AspNet.SignalR;
using System;
using System.Threading.Tasks;

namespace WiredBrain.Hubs
{
    //[Authorize]
    public class CoffeeHub : Hub<IExamClient>
    {
        private static readonly ExamChecker _examChecker =
            new ExamChecker(new Random());
        //[Authorize(Roles = "admin")]
        public async Task GetUpdateForExam(Exam exam)
        {
            await Clients.Others.NewExam(exam);
            //UpdateInfo result;
            //do
            //{
            //    result = _examChecker.GetUpdate(exam);
            //    await Task.Delay(700);
            //    if (!result.New) continue;

            //    await Clients.Caller.ReceiveExamUpdate(result);
            //    await Clients.Group("allUpdateReceivers").ReceiveExamUpdate(result);
            //} while (!result.Finished);
            //await Clients.Caller.Finished(exam);
        }

        public override Task OnConnected()
        {
            if (Context.QueryString["group"] == "allUpdates")
                Groups.Add(Context.ConnectionId, "allUpdateReceivers");
            return base.OnConnected();
        }
    }
}