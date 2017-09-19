namespace SOC.Models
{
    public class QTiesModel
    {
        public QTiesModel()
        {
        }

        public string ID { get;set; }
        public string TagID { get;set; }
        public TagsModel TagsModel { get;set; }
        public string QuestionID { get;set; }
        public QuestionsModel QuestionsModel { get;set; }
    }
}