using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EPI_USE.Data
{
    public partial class Option
    {
       //public Option()
       //{
       //    MemberGenderNavigations = new HashSet<Member>();
       //    MemberMaritalStatusNavigations = new HashSet<Member>();
       //    MemberRelationshipGenderNavigations = new HashSet<MemberRelationship>();
       //    MemberRelationshipMaritalStatusNavigations = new HashSet<MemberRelationship>();
       //    MemberRelationshipRelationshipWithMemberNavigations = new HashSet<MemberRelationship>();
       //    MemberRelationshipTitleNavigations = new HashSet<MemberRelationship>();
       //    MemberTitleNavigations = new HashSet<Member>();
       //}
        [Key]
        public long Id { get; set; }
        public string? Name { get; set; }
        public long? OptionGroupId { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual OptionGroup? OptionGroup { get; set; }
        //public virtual ICollection<Member> MemberGenderNavigations { get; set; }
        //public virtual ICollection<Member> MemberMaritalStatusNavigations { get; set; }
        //public virtual ICollection<MemberRelationship> MemberRelationshipGenderNavigations { get; set; }
        //public virtual ICollection<MemberRelationship> MemberRelationshipMaritalStatusNavigations { get; set; }
        //public virtual ICollection<MemberRelationship> MemberRelationshipRelationshipWithMemberNavigations { get; set; }
        //public virtual ICollection<MemberRelationship> MemberRelationshipTitleNavigations { get; set; }
        //public virtual ICollection<Member> MemberTitleNavigations { get; set; }
    }
}
