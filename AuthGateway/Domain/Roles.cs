using AuthGateway.Domain.Common;

namespace AuthGateway.Domain
{
    public sealed class Roles : BaseEntity
    {
        public Roles(int Id, string roleName, DateTime createdDate): base(Id)
        {
            RoleName = roleName;
            CreatedDate = createdDate;
        }
        public string RoleName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
