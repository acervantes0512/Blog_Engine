using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime CreationDate { get; set; }
        public int InitialStatusId { get; set; }
        public int FinalStatusId { get; set; }

        public StatusPost InitialStatus { get; set; }
        public StatusPost FinalStatus { get; set; }
    }
}
