using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace Udem.LlamaClothingCo.Presentation.Models
{
    public class ClientModel
    {
        public int ClientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RFC { get; set; }
        public bool IsClientActive { get; set; }
    }
}