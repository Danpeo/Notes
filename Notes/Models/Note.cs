using System.ComponentModel.DataAnnotations;
using Notes.Dto;

namespace Notes.Models;

public class Note
{
    public int Id { get; set; }

    [StringLength(150, ErrorMessage = "Название не должно превышать 150 символов")]
    public string? Title { get; set; }

    [Required]
    [StringLength(3000, ErrorMessage = "Название не должно превышать 3000 символов")]
    public string TextBody { get; set; }

    public DateTime CreationDate { get; set; }

    public Note()
    {
    }

    public Note(string title, string textBody, DateTime creationDate)
    {
        Title = title;
        TextBody = textBody;
        CreationDate = creationDate;
    }

    public Note(NoteDto noteDto)
    {
        Title = noteDto.Title;
        TextBody = noteDto.Body;
        CreationDate = noteDto.CreationDate;
    }

    /*public NoteDto ToDto()
    {
        return new NoteDto()
        {
            Title = this.Title,
            Body = this.Body,
            CreationDate = this.CreationDate
        };
    }*/
}