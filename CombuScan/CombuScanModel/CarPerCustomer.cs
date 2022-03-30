using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CombuScanModel
{
  /// <summary>
  /// Represents a carpercustomer entity
  /// </summary>
  [Table("CarPerCustomer")]
  public class CarPerCustomer
  {
    #region Private Fields
    #endregion

    #region Public Properties

    /// <summary>
    /// Id of carpercustomer class
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("CarPerCustomerId")]
    public int Id { get; set; }

    public int CarId { get; set; }

    /// <summary>
    /// Car linked to CarPerCustomer
    /// </summary>
    public virtual Car Car { get; set; }

    public int CustomerId { get; set; }

    /// <summary>
    /// Customer linked to CarPerCustomer
    /// </summary>
    public virtual Customer Customer { get; set; }
    #endregion

    #region Constructors

    #endregion

    #region Public Methods
    #endregion
  }
}