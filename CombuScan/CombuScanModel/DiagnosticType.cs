using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CombuScanModel
{
  /// <summary>
  /// Represents a DiagnosticType entity
  /// </summary>
  [Table("DiagnosticType")]
  public class DiagnosticType
  {
    #region Private Fields
    #endregion

    #region Public Properties

    /// <summary>
    /// Id of DiagnosticType class
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("DiagnosticTypeId")]
    public int Id { get; set; }

    /// <summary>
    /// Name of DiagnosticType
    /// </summary>
    [Column("Name")]
    public string Name { get; set; }

    /// <summary>
    /// Description of DiagnosticType
    /// </summary>
    [Column("Description")]
    public string Description { get; set; }

    /// <summary>
    /// List of car models linked to each brand
    /// </summary>
    public virtual ICollection<Diagnostic> Diagnostics { get; set; }
    #endregion

    #region Constructors

    /// <summary>
    /// Class constructor
    /// </summary>
    public DiagnosticType()
    {
      this.Diagnostics = new List<Diagnostic>();
    }

    #endregion

    #region Public Methods
    #endregion
  }
}