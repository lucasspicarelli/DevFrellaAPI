﻿namespace DevFreela.API.Entities
{
    public class UserSkill
    {
        public UserSkill(int idUser, int idSkill) : base()
        {
            IdUser = idUser;
            IdSkill = idSkill;
        }
        public int IdUser { get; private set; }
        public User User { get; set; }
        public int IdSkill { get; private set; }
        public Skill Skill { get; private set; }
    }
}
