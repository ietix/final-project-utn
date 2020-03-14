using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AdquisitionWebApi.Models
{
  /// <summary>
  /// Represents a user entity
  /// </summary>
  [Table("User")]
  public class User
  {
    #region Private Fields

    #endregion

    #region Public Properties
    /// <summary>
    /// Id of user class
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("UserId")]
    public int Id { get; set; }

    /// <summary>
    /// User name
    /// </summary>
    [Column("Username")]
    public string Username { get; set; }

    /// <summary>
    /// User password
    /// </summary>
    [Column("Password")]
    public string Password { get; set; }

    /// <summary>
    /// First name of user
    /// </summary>
    [Column("FirstName")]
    public string FirstName { get; set; }

    /// <summary>
    /// Last name of user
    /// </summary>
    [Column("LastName")]
    public string LastName { get; set; }
    #endregion

    #region Constructor

    #endregion

    #region Public Methods

    #endregion
  }
}