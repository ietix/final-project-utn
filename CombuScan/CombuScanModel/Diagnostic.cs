using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CombuScanModel
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
    /// Car linked to Diagnostic
    /// </summary>
    public virtual Car Car { get; set; }

    public int CustomerId { get; set; }

    /// <summary>
    /// Customer linked to Diagnostic
    /// </summary>
    public virtual Customer Customer { get; set; }

    public int DiagnosticTypeId { get; set; }

    /// <summary>
    /// DiagnosticType linked to Diagnostic
    /// </summary>
    public virtual DiagnosticType DiagnosticType { get; set; }

    public int FailureTypeId { get; set; }

    /// <summary>
    /// FailureType linked to Diagnostic
    /// </summary>
    public virtual FailureType FailureType { get; set; }

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
      this.Analyses = new List<Analysis>();
    }

    #endregion

    #region Public Methods
    #endregion
  }
}