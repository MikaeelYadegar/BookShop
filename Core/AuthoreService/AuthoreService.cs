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
    public async Task CreateAuthore(Authore authore)
    {
        await _authorRepository.Add(authore);
    }
}
