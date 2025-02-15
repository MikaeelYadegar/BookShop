using DatAccess.Data;
using DatAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DatAccess.Repositories.AuthorRepo;

public class AuthorRepository : IAuthorRepository
{
    private readonly BookDbContext _context;
    public AuthorRepository(BookDbContext context)
    {
        _context = context;
    }
    public async Task Add(Authore authore)
    {
       _context.Authores.Add(authore);
        await _context.SaveChangesAsync();  
    }

    public async Task Delete(int id)
    {
        var data = await GetById(id);
        _context.Authores.Remove(data);
       await _context.SaveChangesAsync();

    }

    public async Task Delete(Authore authore)
    {
        _context.Authores.Remove(authore);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Authore>> GetAll()
    {
        var data = await _context.Authores.ToListAsync();
        return data;
    }

    public async Task<Authore> GetById(int id)
    {
        return await _context.Authores.FindAsync(id);
    }

    public async Task Update(Authore authore)
    {
        _context.Authores.Update(authore);
        await _context.SaveChangesAsync();
    }
}
