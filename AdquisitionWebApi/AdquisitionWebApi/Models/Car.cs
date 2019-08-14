using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AdquisitionWebApi.Models
{
  /// <summary>
  /// Represents a car entity
  /// </summary>
  [Table("Car")]
  public class Car
  {
    #region Private Fields
    #endregion

    #region Public Properties

    /// <summary>
    /// Id of car class
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("CarId")]
    public int Id { get; set; }

    /// <summary>
    /// Chasis number of car
    /// </summary>
    [Column("ChasisNumber")]
    public string ChasisNumber { get; set; }

    /// <summary>
    /// Motor number of car
    /// </summary>
    [Column("MotorNumber")]
    public string MotorNumber { get; set; }

    /// <summary>
    /// Plate number of car
    /// </summary>
    [Column("PlateNumber")]
    public string PlateNumber { get; set; }

    /// <summary>
    /// Custom linked to CarModel
    /// </summary>
    public virtual CarModel CarModel { get; set; }

    /// <summary>
    /// List of cars per customer linked to each car
    /// </summary>
    public virtual ICollection<CarPerCustomer> CarPerCustomers { get; set; }

    #endregion

    #region Constructors

    public Car()
    {
      this.CarPerCustomers = new HashSet<CarPerCustomer>();
    }

    #endregion

    #region Public Methods
    #endregion
  }
}