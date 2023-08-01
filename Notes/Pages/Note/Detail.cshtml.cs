using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Notes.Data;
using Notes.Services;

namespace Notes.Pages.Note;

public class DetailModel : PageModel
{
    private readonly INoteService _noteService;
    public Models.Note? Note { get; set; } = new();
    
    public DetailModel(INoteService noteService)
    {
        _noteService = noteService;
    }
    
    public async Task<IActionResult> OnGet(int id)
    {
        Note = await _noteService.GetByIdAsync(id);

        if (Note == null)
            return NotFound();

        return Page();
    }
}