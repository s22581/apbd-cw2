namespace LegacyApp.Abstractions
{
    public interface IClientRepository
    {
        Client GetById(int clientId);
    }
}
