using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AdquisitionWebApi.Models
{
  /// <summary>
  /// Represents a Contact entity
  /// </summary>
  [Table("Contact")]
  public class Contact
  {
    #region Private Fields
    #endregion

    #region Public Properties

    /// <summary>
    /// Id of Contact class
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("BrandId")]
    public int Id { get; set; }

    /// <summary>
    /// Value of Contact
    /// </summary>
    [Column("Value")]
    public string Value { get; set; }

    /// <summary>
    /// ContactType linked to Contact
    /// </summary>
    public virtual ContactType ContactType { get; set; }

    /// <summary>
    /// Customer linked to Contact
    /// </summary>
    public virtual Customer Customer { get; set; }
    #endregion

    #region Constructors
    
    #endregion

    #region Public Methods
    #endregion
  }
}