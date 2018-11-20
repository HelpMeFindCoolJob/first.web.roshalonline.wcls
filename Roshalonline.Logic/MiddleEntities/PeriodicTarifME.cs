﻿using Roshalonline.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Roshalonline.Data.Entities.PeriodicTarif;

namespace Roshalonline.Logic.MiddleEntities
{
    public class PeriodicTarifME
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Relevance Category { get; set; }
        public TargetAudience Audience { get; set; }
        public string Description { get; set; }
        public Technology TarifTechnology { get; set; }
        public decimal Price { get; set; }

        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
    }
}