using DatAccess.Models;
using DatAccess.Repositories.AuthorRepo;

namespace Core.AuthoreService;

public class AuthoreService
{
    private readonly IAuthorRepository _authorRepository;
    public AuthoreService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }
    public async Task<IEnumerable<Authore>>GetAllAuthores()
    {
        return await _authorRepository.GetAll();
    }
public async Task<Authore>GetAllAuthoresByID(int id)
    {
        return await _authorRepository.GetById(id);
    }


    public async Task CreateAuthore(Authore authore)
    {
        await _authorRepository.Add(authore);
    }
    public async Task UpdateAuthore(Authore authore)
    {
        await _authorRepository.Update(authore);
    }
    public async Task DeleteAuthore(Authore authore)
    {
        await _authorRepository.Delete(authore);
    }
}
