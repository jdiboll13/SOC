using System;
namespace SOC.Models
{
    public class QuestionsModel
    {
        public QuestionsModel()
        {
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int VoteCount { get; set; }
        public DateTime DatePosted { get; set; }
        public int UserId { get; set; }
        public UsersModel UsersModel { get; set; }
    }
}