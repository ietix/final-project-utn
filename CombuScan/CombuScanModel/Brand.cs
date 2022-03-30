using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CombuScanModel
{
  /// <summary>
  /// Represents a brand entity
  /// </summary>
  [Table("Brand")]
  public class Brand
  {
    #region Private Fields
    #endregion

    #region Public Properties

    /// <summary>
    /// Id of analysis class
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("BrandId")]
    public int Id { get; set; }

    /// <summary>
    /// Name of brand
    /// </summary>
    [Column("Name")]
    public string Name { get; set; }

    /// <summary>
    /// Description of brand
    /// </summary>
    [Column("Description")]
    public string Description { get; set; }

    #endregion

    #region Constructors
    #endregion

    #region Public Methods
    #endregion
  }
}
