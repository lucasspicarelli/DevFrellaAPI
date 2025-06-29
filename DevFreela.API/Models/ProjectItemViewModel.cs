using DevFreela.API.Entities;

namespace DevFreela.API.Models
{
    public class ProjectItemViewModel
    {
        public ProjectItemViewModel(int id, string clientName, string nameFreelancer, decimal totalCost)
        {
            Id = id;
            ClientName = clientName;
            NameFreelancer = nameFreelancer;
            TotalCost = totalCost;
        }
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string ClientName { get; private set; }
        public string NameFreelancer { get; private set; }
        public decimal TotalCost { get; private set; }
    }
}
