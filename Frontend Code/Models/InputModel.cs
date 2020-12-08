using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lawn_Mow_App.Models
{
    public class InputModel
    {
        [Required(ErrorMessage = "Please Enter Sqare Meter")]
        public float SqMeter { get; set; }

        public float TotalSquareMeter { get; set; }
        public float PricePerSqMeter { get; set; }
        public string Discount { get; set; }
        public float TotalAmount { get; set; }
        public float DiscountAmount { get; set; }
        public float NetAmount { get; set; }
    }
}