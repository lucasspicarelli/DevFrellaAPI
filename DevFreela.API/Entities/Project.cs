using DevFreela.API.Controllers;
using DevFreela.API.Enums;

namespace DevFreela.API.Entities
{
    public class Project : BaseEntity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdClient { get; private set; }
        public User MyProperty { get; private set; }
        public int IdFreelancer { get; private set; }
        public User Freelancer { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? CompletedAt { get; private set; }
        public ProjecStatusEnum Status  { get; private set; }
        public List<Project> Projects { get; private set; }

    }
}
