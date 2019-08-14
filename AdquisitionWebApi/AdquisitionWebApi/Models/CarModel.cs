using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AdquisitionWebApi.Models
{
  /// <summary>
  /// Represents a car model entity
  /// </summary>
  [Table("CarModel")]
  public class CarModel
  {
    #region Private Fields
    #endregion

    #region Public Properties

    /// <summary>
    /// Id of car model class
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("CarModelId")]
    public int Id { get; set; }

    /// <summary>
    /// Name of car model
    /// </summary>
    [Column("Name")]
    public string Name { get; set; }

    /// <summary>
    /// Description of car model
    /// </summary>
    [Column("Description")]
    public string Description { get; set; }

    /// <summary>
    /// Brand linked to CarModel
    /// </summary>
    public virtual Brand Brand { get; set; }

    #endregion

    #region Constructors

    #endregion

    #region Public Methods
    #endregion
  }
}