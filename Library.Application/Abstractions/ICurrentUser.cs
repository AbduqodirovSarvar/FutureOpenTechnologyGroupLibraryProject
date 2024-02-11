namespace Library.Application.Abstractions
{
    public interface ICurrentUser
    {
        Guid UserId { get; }
        //UserRole UserRole { get; }
    }
}
