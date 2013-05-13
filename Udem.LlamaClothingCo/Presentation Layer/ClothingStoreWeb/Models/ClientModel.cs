using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace ClothingStoreWeb.Models
{
    public class ClientModel
    {
    }
    public class LocalClientModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "RFC")]
        public string RFC { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Client Type")]
        public string ClientType { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telephone")]
        public string Telephone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

    }
}