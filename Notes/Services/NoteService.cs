using Microsoft.EntityFrameworkCore;
using Notes.Data;
using Notes.Models;

namespace Notes.Services;

public class NoteService : INoteService
{
    private readonly ApplicationDbContext _context;

    public NoteService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Note?>> GetAllAsync()
    {
        return await _context.Notes.ToListAsync();
    }

    public async Task<List<Note?>> SearchAsync(string searchQuery, DateTime? searchDate)
    {
        if (string.IsNullOrEmpty(searchQuery) && !searchDate.HasValue)
        {
            return await GetAllAsync();
        }

        var query = _context.Notes.AsQueryable();
        
        query = _context.Notes
            .Where(n => (n.Title != null && EF.Functions.Like(n.Title, $"%{searchQuery}%")) ||
                        (EF.Functions.Like(n.TextBody, $"%{searchQuery}%")));

        if (searchDate.HasValue)
        {
            query = query.Where(note => note != null && note.CreationDate.Date == searchDate.Value.Date);
        }

        return await query.ToListAsync();
    }

    public async Task<Note?> GetByIdAsync(int id)
    {
        return await _context.Notes.FirstOrDefaultAsync(n => n != null && n.Id == id);
    }

    public async Task<bool> CreateAsync(Note? note)
    {
        var newNote = new Note(note.Title, note.TextBody, DateTime.Now);
        _context.Notes.Add(newNote);
        return await SaveAsync();
    }

    public async Task<bool> UpdateAsync(int id, Note? note)
    {
        var noteForUpdate = await _context.Notes.SingleAsync(n => n != null && n.Id == id);

        if (noteForUpdate != null)
        {
            noteForUpdate.Title = note.Title;
            noteForUpdate.TextBody = note.TextBody;

            return await SaveAsync();
        }

        return false;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var noteForDelete = await _context.Notes.SingleAsync(n => n != null && n.Id == id);

        if (noteForDelete != null)
        {
            _context.Notes.Remove(noteForDelete);
            return await SaveAsync();
        }

        return false;
    }

    public async Task<bool> SaveAsync()
    {
        var saved = await _context.SaveChangesAsync();
        return saved > 0;
    }
}