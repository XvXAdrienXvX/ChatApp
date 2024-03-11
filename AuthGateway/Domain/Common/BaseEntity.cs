namespace AuthGateway.Domain.Common
{
    public abstract class BaseEntity : IEquatable<BaseEntity>
    {
        protected BaseEntity(int id) 
        {
            Id = id;
        }
        public int Id { get; private init; }

        public static bool operator ==(BaseEntity left, BaseEntity right)
        {
            return left is not null && right is not null && left.Equals(right);
        }

        public static bool operator !=(BaseEntity left, BaseEntity right)
        {
            return !(left == right);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            // type not equal to type of current object
            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (obj is not BaseEntity entity) 
            {
                return false;
            }

            return entity.Id == Id;
        }

        public bool Equals(BaseEntity? other)
        {
            if (other is null)
            {
                return false;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return other.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
