using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Notes.Data;
using Notes.Services;

namespace Notes.Pages.Note;

public class EditModel : PageModel
{
    private readonly INoteService _noteService;

    [BindProperty] public Models.Note? Note { get; set; } = new();

    public EditModel(ApplicationDbContext context, INoteService noteService)
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

    public async Task<IActionResult> OnPost(int id)
    {
        if (ModelState.IsValid)
        {
            bool edited = await _noteService.UpdateAsync(id, Note);

            if (edited)
                return RedirectToPage("/Index");
        }

        return Page();
    }
}