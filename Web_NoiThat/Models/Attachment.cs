using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_NoiThat.Models
{
    public class Attachment
    {
        public int Id { get; set; }
        public string Filename { get; set; }
        public string Filetype { get; set; }
        public long FileSize { get; set; }
        public string Guid { get; set; }
        public bool Deleted { get; set; }

        public int CaseId { get; set; }
    }
}