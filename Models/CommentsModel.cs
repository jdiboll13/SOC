using System;
namespace SOC.Models
{
    public class CommentsModel
    {
        public CommentsModel()
        {
        }

        public int ID { get;set; }
        public string Body { get;set; }
        public DateTime DatePosted { get;set; }
        public int UserID { get;set; }
        public UsersModel UsersModel { get;set; }
        public int QuestionID { get;set; }
        public QuestionsModel QuestionsModel { get;set; }
        public int AnswerID { get;set; }
        public AnswersModel AnswersModel { get;set; }
    }
}