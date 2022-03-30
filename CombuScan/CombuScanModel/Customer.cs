using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CombuScanModel
{
  /// <summary>
  /// Represents a customer entity
  /// </summary>
  [Table("Customer")]
  public class Customer
  {
    #region Private Fields
    #endregion

    #region Public Properties

    /// <summary>
    /// Id of customer class
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("CustomerId")]
    public int Id { get; set; }

    /// <summary>
    /// Name of customer
    /// </summary>
    [Column("Name")]
    public string Name { get; set; }

    /// <summary>
    /// Surname of customer
    /// </summary>
    [Column("Surname")]
    public string Surname { get; set; }

    /// <summary>
    /// Address of customer
    /// </summary>
    [Column("Address")]
    public string Address { get; set; }

    /// <summary>
    /// Dni of customer
    /// </summary>
    [Column("Dni")]
    public int Dni { get; set; }

    /// <summary>
    /// Cuil of customer
    /// </summary>
    [Column("CuitCuil")]
    public string Cuil { get; set; }

    /// <summary>
    /// List of car per customer linked to each customer
    /// </summary>
    public virtual ICollection<CarPerCustomer> CarPerCustomers { get; set; }

    /// <summary>
    /// List of Diagnostic linked to each customer
    /// </summary>
    public virtual ICollection<Diagnostic> Diagnostics { get; set; }
    #endregion

    #region Constructors

    /// <summary>
    /// Class constructor
    /// </summary>
    public Customer()
    {
      this.CarPerCustomers = new List<CarPerCustomer>();
      this.Diagnostics = new List<Diagnostic>();
    }

    #endregion

    #region Public Methods
    #endregion
  }
}