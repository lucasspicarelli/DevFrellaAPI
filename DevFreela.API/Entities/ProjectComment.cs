namespace DevFreela.API.Entities
{
    public class ProjectComment : BaseEntity
    {
        public string Content { get; private set; }
        public int IdProject { get; private set; }
        public Project Project { get; private set; }
        public int MyProperty { get; set; }

    }
}
