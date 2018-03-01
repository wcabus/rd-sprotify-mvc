using System;
using System.ComponentModel.DataAnnotations;

namespace Sprotify.Web.Models
{
    public class Band
    {
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }
    }
}
