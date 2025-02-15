using DatAccess.Models;

namespace DatAccess.Repositories.AuthorRepo;

public interface IAuthorRepository
{
    Task<IEnumerable<Authore>> GetAll();
    Task<Authore> GetById(int id);
    Task Add(Authore authore);
    Task Update(Authore authore);
    Task Delete(int id);
    Task Delete(Authore authore);
}
