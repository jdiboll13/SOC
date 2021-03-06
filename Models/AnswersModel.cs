using System;
namespace SOC.Models
{
    public class AnswersModel
    {
        public AnswersModel()
        {
        }

        public string ID { get; set; }
        public string Body { get; set; }
        public int VoteCount { get; set; }
        public DateTime DatePosted { get; set; } = DateTime.Now;
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string QuestionsModelID { get; set; }
        public QuestionsModel QuestionsModel { get; set; }
    }
}