namespace Domain.Common;

public interface IEntity
{

}

public abstract class BaseEntity : IEntity
{
    public DateTime? CreatedDate { get; set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; set; }
    public Guid Id { get; set; }

    public BaseEntity()
    {
        Id = Guid.NewGuid();
    }

}
