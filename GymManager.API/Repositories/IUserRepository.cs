namespace GymManager.API.Repositories; // MUSI się zgadzać z using

using GymManager.API.Models; // import modelu User

public interface IUserRepository
{
    Task<User?> GetByEmail(string email); // znajdź usera po emailu

    Task Add(User user); // dodaj usera
}