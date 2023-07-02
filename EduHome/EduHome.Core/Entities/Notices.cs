using EduHome.Core.Interfaces;

namespace EduHome.Core.Entities;

using System;
using System.ComponentModel.DataAnnotations;

public class Notices : IEntity
{
    public int Id { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}")]
    public DateTime? Date { get; set; }

    public string Description { get; set; }
    public bool isLeft { get; set; }
    public string? Title { get; set; }
}

