namespace SOC.Models
{
    public class UsersModel
    {
        public UsersModel()
        {
        }

        public int ID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool BitForMod { get; set; }
    }
}