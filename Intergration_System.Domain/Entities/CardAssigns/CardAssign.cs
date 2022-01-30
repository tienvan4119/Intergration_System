using System.ComponentModel.DataAnnotations.Schema;
using TM.Domain.Entities.Base;
using TM.Domain.Entities.Cards;
using TM.Domain.Entities.Users;

#nullable disable

namespace TM.Domain.Entities.CardAssigns
{
    [Table("CardAssign")]
    public partial class CardAssign : Entity 
    { 
        public int? UserId { get; set; }
        public int? CardId { get; set; }
        public bool? IsAssigned { get; set; }

        [ForeignKey(nameof(CardId))]
        [InverseProperty("CardAssigns")]
        public virtual Card Card { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("CardAssigns")]
        public virtual User User { get; set; }
    }
}
