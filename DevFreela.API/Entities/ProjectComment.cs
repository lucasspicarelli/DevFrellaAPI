﻿namespace DevFreela.API.Entities
{
    public class ProjectComment : BaseEntity
    {
        public ProjectComment(string content, int idProject, int idUser)
        { 
            Content = content;
            IdProject = idProject;
            IdUser = idUser;
        }
        public string Content { get; private set; }
        public int IdProject { get; private set; }
        public Project Project { get; private set; }
        public int IdUser { get; set; }

    }
}
