namespace UnitOfWorkWithRepositoryPattern.DTOS
{
    public record CategoryCreated(string Name);
    public record CategoryUpdate(Guid Id, string Name);

}
