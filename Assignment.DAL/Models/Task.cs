using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Assignment.DAL.Models;

[Table("Task")]
public partial class Task
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("categoryid")]
    public int? Categoryid { get; set; }

    [Column("taskname")]
    [StringLength(100)]
    public string Taskname { get; set; } = null!;

    [Column("assignee")]
    [StringLength(100)]
    public string? Assignee { get; set; }

    [Column("notes")]
    [StringLength(500)]
    public string? Notes { get; set; }

    [Column("duedate", TypeName = "timestamp without time zone")]
    public DateTime? Duedate { get; set; }

    [Column("city")]
    [StringLength(100)]
    public string? City { get; set; }

    [Column("category", TypeName = "character varying")]
    public string? Category { get; set; }

    [ForeignKey("Categoryid")]
    [InverseProperty("Tasks")]
    public virtual Category? CategoryNavigation { get; set; }
}
