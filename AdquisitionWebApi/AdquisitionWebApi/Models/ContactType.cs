using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AdquisitionWebApi.Models
{
  /// <summary>
  /// Represents a ContactType entity
  /// </summary>
  [Table("ContactType")]
  public class ContactType
  {
    #region Private Fields
    #endregion

    #region Public Properties

    /// <summary>
    /// Id of ContactType class
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("ContactTypeId")]
    public int Id { get; set; }

    /// <summary>
    /// Name of ContactType
    /// </summary>
    [Column("Name")]
    public string Name { get; set; }

    /// <summary>
    /// Description of ContactType
    /// </summary>
    [Column("Description")]
    public string Description { get; set; }

    /// <summary>
    /// List of Contact linked to each ContactType
    /// </summary>
    public virtual ICollection<Contact> Contacts { get; set; }
    #endregion

    #region Constructors

    /// <summary>
    /// Class constructor
    /// </summary>
    public ContactType()
    {
      this.Contacts = new List<Contact>();
    }

    #endregion

    #region Public Methods
    #endregion
  }
}