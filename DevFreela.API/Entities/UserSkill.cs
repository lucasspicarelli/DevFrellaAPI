namespace DevFreela.API.Entities
{
    public class UserSkill
    {
        public UserSkill(int idUser, int idSkill) : base()
        {
            Id = idUser;
            IdSkill = idSkill;
        }
        public int Id { get; private set; }
        public User User { get; set; }
        public int IdSkill { get; private set; }
        public Skill Skill { get; private set; }
    }
}
