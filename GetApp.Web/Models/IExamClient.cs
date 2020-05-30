using System.Threading.Tasks;
using GetApp.Data.Models;


namespace GetApp.Web
{
    public interface IExamClient
    {
        Task NewExam(Exam exam);
        Task ReceiveExamUpdate(UpdateInfo info);
        Task Finished(Exam exam);
    }
}