using DevFreela.Core.Entities;

namespace DevFreela.Application.Models
{
    public class ProjectItemViewModel
    {
        public ProjectItemViewModel(int id, string title, string clientName, string nameFreelancer, decimal totalCost)
        {
            Id = id;
            Title = title;
            ClientName = clientName;
            NameFreelancer = nameFreelancer;
            TotalCost = totalCost;
        }
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Title { get; private set; }
        public string ClientName { get; private set; }
        public string NameFreelancer { get; private set; }
        public decimal TotalCost { get; private set; }

        public static ProjectItemViewModel FromEntity(Project project) 
            => new(
                project.Id,
                project.Title,
                project.Client.FullName,
                project.Freelancer.FullName,
                project.TotalCost
            );
    }
}