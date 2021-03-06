using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entity
{
    public class Note
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoteID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }

        public bool IsPin { get; set; }
        public bool IsArchive { get; set; }
        public bool IsRemainder { get; set; }
        public bool IsTrash { get; set; }

        public DateTime Remainder { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifedDate { get; set; }
        public int UserId { get; set; }
        public virtual User user { get; set; }


    }
}
