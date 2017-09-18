namespace SOC.Models
{
    public class QTiesModel
    {
        public QTiesModel()
        {
        }

        public int ID { get;set; }
        public int TagID { get;set; }
        public TagsModel TagsModel { get;set; }
        public int QuestionID { get;set; }
        public QuestionsModel QuestionsModel { get;set; }
    }
}