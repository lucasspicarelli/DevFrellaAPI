using DevFreela.Core.Entities;

namespace DevFreela.Application.Models
{
    public class ProjectViewModel
    {
        public ProjectViewModel(int id, int idClient, int idFreelancer, string clientName, string freelancerName, string title, string description, decimal totalCost, List<ProjectComment> comments)
        {
            Id = id;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            ClientName = clientName;
            FreelancerName = freelancerName;
            Title = title;
            Description = description;
            TotalCost = totalCost;
            Comments = comments.Select(c => c.Content).ToList();
        }
        // Properties
        public int Id { get; private set; }
        public int IdClient { get; private set; }
        public int IdFreelancer { get; private set; }
        public string ClientName { get; private set; }
        public string FreelancerName { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal TotalCost { get; private set; }
        public List<string> Comments { get; private set; }


        public static ProjectViewModel FromEntity(Project entity)
        => new(
            entity.Id,
            entity.IdClient,
            entity.IdFreelancer,
            entity.Client.FullName,
            entity.Freelancer.FullName,
            entity.Title,
            entity.Description,
            entity.TotalCost,
            entity.Comments
        );

    }
}