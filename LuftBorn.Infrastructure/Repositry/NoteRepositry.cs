using LuftBorn.Domain.Model;
using LuftBorn.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftBorn.Infrastructure.Repositry
{
    public class NoteRepositry : IRepository<Note>
    {
        private LuftBornContext _context;
        private IHttpContextAccessor _httpContextAccessor;

        public NoteRepositry(LuftBornContext context , IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Note note = await GetByIdAsync(id);
            if (note == null) return false;
            _context.Remove<Note>(note);
            return _context.SaveChanges() == 1 ? true : false;
        }

        public async Task<IQueryable<Note>> GetAllAsync()
        {
            return  _context.Notes.AsQueryable();
        }

        public async Task<Note> GetByIdAsync(Guid id)
        {
            return await _context.Notes.SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> InsertAsync(Note obj)
        {
            obj.CreatedBy = _httpContextAccessor.HttpContext.User.Identity.Name ?? "LuftBornUser";
            obj.Created = DateTime.UtcNow;
            _context.Notes.AddAsync(obj);
            return _context.SaveChanges() == 1 ?  true :  false;
        }

        public async Task<bool> UpdateAsync(Note obj)
        {
            obj.LastModifiedBy = _httpContextAccessor.HttpContext.User.Identity.Name ?? "LuftBornUser";
            obj.LastModified = DateTime.UtcNow;
            _context.Entry(obj).State = EntityState.Modified;
            return _context.SaveChanges() == 1 ? true : false;
        }
    }
}
