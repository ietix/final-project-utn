
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AdquisitionWebApi.Models
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
    /// Id of diagnostic class
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

    /// <summary>
    /// List of car models linked to each brand
    /// </summary>
    public virtual ICollection<CarModel> CarModels { get; set; }
    #endregion

    #region Constructors

    /// <summary>
    /// Class constructor
    /// </summary>
    public Brand()
    {
      this.CarModels = new List<CarModel>();
    }

    #endregion

    #region Public Methods
    #endregion
  }
}