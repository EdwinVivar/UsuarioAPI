using Microsoft.EntityFrameworkCore;
using UsuarioAPI.Models;

namespace UsuarioAPI.Data.Repository
{
    public class UsuarioRepository
    {

        private readonly AppDbContext _dbContext;

        public UsuarioRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddUsuario(Usuarios usuarios)
        {
            await _dbContext.Set<Usuarios>().AddAsync(usuarios);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<List<Usuarios>> GetUsuarios()
        {
            return await _dbContext.Usuario.ToListAsync();
        }

        public async Task UpdateUsuarios(int id, Usuarios model)
        {
            var usuario = await _dbContext.Usuario.FindAsync(id);
            if (usuario == null)
            {
                throw new Exception("Usuario No Encontrado");
            }
            usuario.Name = model.Name;
            usuario.Mail = model.Mail;
            await _dbContext.SaveChangesAsync();
        }
    }
}
