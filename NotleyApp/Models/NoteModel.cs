using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NotleyApp.Models
{
    public class NoteModel
    {
        public Guid ID { get; set; }
        [Required(ErrorMessage = "Please enter the subject")]
        public string Subject { get; set; }
        public string Detail { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted{ get; set; }

    }
}
