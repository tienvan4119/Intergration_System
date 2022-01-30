using System;
using System.ComponentModel.DataAnnotations.Schema;
using TM.Domain.Entities.Base;
using TM.Domain.Entities.Cards;
using TM.Domain.Entities.Phases;

#nullable disable

namespace TM.Domain.Entities.CardMovements
{
    [Table("CardMovement")]
    public partial class CardMovement : AuditEntity
    {
        public int? CardId { get; set; }
        public int? PhaseId { get; set; }
        
        public bool? IsCurrent { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [ForeignKey(nameof(CardId))]
        [InverseProperty("CardMovements")]
        public virtual Card Card { get; set; }
        [ForeignKey(nameof(PhaseId))]
        [InverseProperty("CardMovements")]
        public virtual Phase Phase { get; set; }
    }
}
