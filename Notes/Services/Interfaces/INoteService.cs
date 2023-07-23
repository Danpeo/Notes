using Notes.Models;

namespace Notes.Services;

public interface INoteService
{
    Task<List<Note?>> GetAllAsync();
    Task<List<Note?>> SearchAsync(string searchQuery, DateTime? searchDate);
    Task<Note?> GetByIdAsync(int id);
    Task<bool> CreateAsync(Note? note);
    Task<bool> UpdateAsync(int id, Note? note);
    Task<bool> DeleteAsync(int id);
}