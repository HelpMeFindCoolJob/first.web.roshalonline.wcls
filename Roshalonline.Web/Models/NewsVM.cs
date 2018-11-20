﻿using System;
using Roshalonline.Data.Models;

namespace Roshalonline.Web.Models
{
    public class NewsVM
    {
        public int ID { get; set; }
        public string Header { get; set; }
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public Relevance Category { get; set; }
        public BackgroundType Type { get; set; }
        public string PathToIcon { get; set; }
        public string PathToCover { get; set; }
        public DateTime CreateDate { get; set; }
        public string Body { get; set; }
        public long ViewsCount { get; set; }
    }
}