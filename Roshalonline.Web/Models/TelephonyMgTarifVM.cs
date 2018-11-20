﻿using Roshalonline.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Roshalonline.Data.Entities.PeriodicTarif;

namespace Roshalonline.Web.Models
{
    public class TelephonyMgTarifVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Relevance Category { get; set; }
        public TargetAudience Audience { get; set; }
        public string DestinationName { get; set; }
        public string CodeZone { get; set; }
        public decimal FullParice { get; set; }
        public decimal TimeDiscountPrice { get; set; }
        public decimal HolidayDiscountPrice { get; set; }

        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
    }
}