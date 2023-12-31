﻿using EduHome.Core.Entities;
using EduHome.Core.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

public class EventDetails : IEntity
{
	public int Id { get; set; }
    public string Description { get; set; }
    public string Venue { get; set; }
    [ForeignKey("Events")]
	public int EventId { get; set; }
	public Events Event { get; set; }
    public ICollection<Speakers> Speakers { get; set; }
}