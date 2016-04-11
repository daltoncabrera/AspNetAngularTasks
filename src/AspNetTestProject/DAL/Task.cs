using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNetTestProject.DAL
{

    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Title Required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description Required")]
        public string Description { get; set; }

        public int? Status { get; set; }

        public Task()
        {
            Status = (int) TaskStatusID.ToDO;
        }
    }
}