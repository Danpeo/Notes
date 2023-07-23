using System.ComponentModel.DataAnnotations;

namespace Notes.Dto;

public class NoteDto
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string Body { get; set; }
    public DateTime CreationDate { get; set; }

    public NoteDto()
    {
        
    }
    
    public NoteDto(string title, string body, DateTime creationDate)
    {
        Title = title;
        Body = body;
        CreationDate = creationDate;
    }
}