using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GetApp.Data.Models;

namespace GetApp.Web
{
    public class ExamChecker
    {
        private readonly Random random;

        private readonly string[] Status =
            {"creating exam", "new exam"};

        private readonly Dictionary<int, int> StatusTracker = new Dictionary<int, int>();
        public ExamChecker(Random random)
        {
            this.random = random;
        }

        private int GetNextStatusIndex(int ExamNo)
        {
            if (!StatusTracker.ContainsKey(ExamNo))
                StatusTracker.Add(ExamNo, -1);

            StatusTracker[ExamNo]++;
            return StatusTracker[ExamNo];
        }

        public UpdateInfo GetUpdate(Exam exam)
        {
            if (random.Next(1, 3) != 3) return new UpdateInfo { New = false };

            var index = GetNextStatusIndex(exam.ExamId);

            if (Status.Length <= index) return new UpdateInfo { New = false };

            var result = new UpdateInfo
            {
                ExamId = exam.ExamId,
                New = true,
                Update = Status[index],
                Finished = Status.Length - 1 == index
            };
            return result;

        }
    }
}