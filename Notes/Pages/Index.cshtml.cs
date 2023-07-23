using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Notes.Data;
using Notes.Services;

namespace Notes.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly INoteService _noteService;
    public List<Models.Note?> Notes { get; set; }

    /*public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }*/

    public IndexModel(INoteService noteService)
    {
        _noteService = noteService;
    }

    public async Task<PageResult> OnGet(string searchQuery, DateTime? searchDate)
    {
        if (string.IsNullOrEmpty(searchQuery) && !searchDate.HasValue)
        {
            Notes = await _noteService.GetAllAsync();
        }
        else
        {
            Notes = await _noteService.SearchAsync(searchQuery, searchDate);
        }
        return Page();
    }
}