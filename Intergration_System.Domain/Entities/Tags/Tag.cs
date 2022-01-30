using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TM.Domain.Entities.Base;
using TM.Domain.Entities.CardTags;

#nullable disable

namespace TM.Domain.Entities.Tags
{
    [Table("Tag")]
    public partial class Tag : Entity
    {
        public Tag()
        {
            CardTags = new HashSet<CardTag>();
        }

        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(20)]
        public string Color { get; set; }

        [InverseProperty(nameof(CardTag.Tag))]
        public virtual ICollection<CardTag> CardTags { get; set; }
    }
}
