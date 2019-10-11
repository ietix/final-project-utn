using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AdquisitionWebApi.Models
{
  /// <summary>
  /// Represents a FailureType entity
  /// </summary>
  [Table("FailureType")]
  public class FailureType
  {
    #region Private Fields
    #endregion

    #region Public Properties

    /// <summary>
    /// Id of FailureType class
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("FailureTypeId")]
    public int Id { get; set; }

    /// <summary>
    /// Name of FailureType
    /// </summary>
    [Column("Name")]
    public string Name { get; set; }

    /// <summary>
    /// Description of FailureType
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
    public FailureType()
    {
      this.Diagnostics = new List<Diagnostic>();
    }

    #endregion

    #region Public Methods
    #endregion
  }
}