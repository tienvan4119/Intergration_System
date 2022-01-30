using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TM.Domain.Entities.Base;
using TM.Domain.Entities.CardAssigns;
using TM.Domain.Entities.CardHistories;
using TM.Domain.Entities.ProjectMembers;

#nullable disable

namespace TM.Domain.Entities.Users
{
    [Table("User")]
    public partial class User : Entity
    {
        public User()
        {
            CardAssigns = new HashSet<CardAssign>();
            CardHistories = new HashSet<CardHistory>();
            ProjectMembers = new HashSet<ProjectMember>();
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsActive { get; set; }
        public string Phone { get; set; }
        public DateTime? Birthday { get; set; }

        public virtual ICollection<CardAssign> CardAssigns { get; set; }
        public virtual ICollection<CardHistory> CardHistories { get; set; }
        public virtual ICollection<ProjectMember> ProjectMembers { get; set; }
    }
}
