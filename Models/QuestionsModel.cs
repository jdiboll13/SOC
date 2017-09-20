using System;
using System.Collections.Generic;

namespace SOC.Models
{
    public class QuestionsModel
    {
        public QuestionsModel()
        {
        }

        public string ID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int VoteCount { get; set; }
        public DateTime DatePosted { get; set; } = DateTime.Now;
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string TagName { get; set; }
        public TagsModel TagsModel { get; set; }
        public ICollection<AnswersModel> AnswersModel { get; set; } = new HashSet<AnswersModel>();
    }
}