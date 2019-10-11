using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdquisitionWebApi.Models
{
  /// <summary>
  /// Represents an analysis entity
  /// </summary>
  [Table("Analysis")]
  public class Analysis
  {
    #region Private Fields
    #endregion

    #region Public Properties

    /// <summary>
    /// Id of analysis class
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("AnalysisId")]
    public int Id { get; set; }

    /// <summary>
    /// Date of analysis
    /// </summary>
    [Column("AnalysisDate")]
    public DateTime Date { get; set; }

    /// <summary>
    /// Path for data file
    /// </summary>
    [Column("DatafilePath")]
    public string FilePath { get; set; }

    public int DiagnosticId { get; set; }

    /// <summary>
    /// Diagnostic linked to analysis
    /// </summary>
    public virtual Diagnostic Diagnostic { get; set; }

    #endregion

    #region Constructors
    #endregion

    #region Public Methods
    #endregion
  }
}