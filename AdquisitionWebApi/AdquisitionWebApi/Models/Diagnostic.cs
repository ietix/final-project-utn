using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AdquisitionWebApi.Models
{
  /// <summary>
  /// Represents a diagnostic entity
  /// </summary>
  [Table("Diagnostic")]
  public class Diagnostic
  {
    #region Private Fields
    #endregion

    #region Public Properties

    /// <summary>
    /// Id of diagnostic class
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("DiagnosticId")]
    public int Id { get; set; }

    /// <summary>
    /// Name of diagnostic
    /// </summary>
    [Column("Name")]
    public string Name { get; set; }

    /// <summary>
    /// Description of diagnostic
    /// </summary>
    [Column("Description")]
    public string Description { get; set; }

    /// <summary>
    /// Date of diagnostic
    /// </summary>
    [Column("Date")]
    public DateTime Date { get; set; }

    /// <summary>
    /// List of analysis linked to each diagnostic
    /// </summary>
    public virtual ICollection<Analysis> Analyses { get; set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Class constructor
    /// </summary>
    public Diagnostic()
    {
      this.Analyses = new HashSet<Analysis>();
    }

    #endregion

    #region Public Methods
    #endregion
  }
}