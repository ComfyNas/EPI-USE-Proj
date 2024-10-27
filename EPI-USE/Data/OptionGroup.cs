using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EPI_USE.Data
{
    public partial class OptionGroup
    {
        public OptionGroup()
        {
            Options = new HashSet<Option>();
        }
        [Key]
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<Option> Options { get; set; }
    }
}
