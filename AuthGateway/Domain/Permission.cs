using AuthGateway.Domain.Common;

namespace AuthGateway.Domain
{
    public sealed class Permission : BaseEntity
    {
        public Permission(int Id, string permissionName): base(Id)
        {
            PermissionName = permissionName;
        }
        public string PermissionName { get; set; }
    }
}
