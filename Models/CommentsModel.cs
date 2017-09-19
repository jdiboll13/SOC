using System;
namespace SOC.Models
{
    public class CommentsModel
    {
        public CommentsModel()
        {
        }

        public string ID { get;set; }
        public string Body { get;set; }
        public DateTime DatePosted { get;set; } = DateTime.Now;
        public string ApplicationUserId { get;set; }
        public ApplicationUser ApplicationUser { get;set; }
        public string QuestionsModelID { get;set; }
        public QuestionsModel QuestionsModel { get;set; }
        public string AnswersModelID { get;set; }
        public AnswersModel AnswersModel { get;set; }
    }
}