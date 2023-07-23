using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Notes.Data;
using Notes.Dto;
using Notes.Services;

namespace Notes.Pages.Note;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly INoteService _noteService;

    [BindProperty] public Models.Note? Note { get; set; } = new();

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
        _noteService = new NoteService(_context);
    }
    
    public void OnGet()
    {
        
    }

    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid)
        {
            bool created = await _noteService.CreateAsync(Note);
            if (created)
                return RedirectToPage("/Index");
        }
    
        return Page();
    }

}