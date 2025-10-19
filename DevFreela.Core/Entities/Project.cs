using DevFreela.Core.Enums;

namespace DevFreela.Core.Entities
{
    public class Project : BaseEntity
    {
        protected Project() { }
        public Project(string title, string description, int idClient, int idFreelancer, decimal totalCost)
            : base()
        {
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            TotalCost = totalCost;

            Status = ProjecStatusEnum.Created;
            Comments = [];
        }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdClient { get; private set; }
        public User Client { get; set; }
        public int IdFreelancer { get; private set; }
        public User Freelancer { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? CompletedAt { get; private set; }
        public ProjecStatusEnum Status { get; private set; }
        public List<ProjectComment> Comments { get; private set; }

        public void Cancel()
        {
            if (Status == ProjecStatusEnum.InProgress || Status == ProjecStatusEnum.Suspended)
            {
                Status = ProjecStatusEnum.Cancelled;
            }
        }
        public void Start()
        {
            if(Status == ProjecStatusEnum.Created)
            {
               Status = ProjecStatusEnum.InProgress;
                StartedAt = DateTime.Now;
            }
        }
        public void Complete()
        {
            if (Status == ProjecStatusEnum.PaymentPendig || Status == ProjecStatusEnum.InProgress)
            {
                Status = ProjecStatusEnum.Completed;
                CompletedAt = DateTime.Now;
            }
        }
        public void SetPaymentPending()
        {
            if (Status != ProjecStatusEnum.InProgress)
            {
                Status = ProjecStatusEnum.PaymentPendig;
            }
        }
        public void Update(string title, string description, decimal totalCost)
        {
            Title = title;
            Description = description;
            TotalCost = totalCost;
        }
    }
}