namespace UnitOfWorkWithRepositoryPattern.DTOS
{
    public record CategoryCreated(string Name);
    public record CategoryUpdate(Guid Id, string Name);
    public record UserCreated(Guid Id, string Name);
    public record UserUpdate(Guid Id, string Name);

}
