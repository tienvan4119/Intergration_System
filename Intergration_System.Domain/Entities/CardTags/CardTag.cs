using System.ComponentModel.DataAnnotations.Schema;
using TM.Domain.Entities.Base;
using TM.Domain.Entities.Cards;
using TM.Domain.Entities.Tags;


#nullable disable

namespace TM.Domain.Entities.CardTags
{
    [Table("CardTag")]
    public partial class CardTag :Entity
    {
        public int? CardId { get; set; }
        public int? TagId { get; set; }

        [ForeignKey(nameof(CardId))]
        [InverseProperty("CardTags")]
        public virtual Card Card { get; set; }
        [ForeignKey(nameof(TagId))]
        [InverseProperty("CardTags")]
        public virtual Tag Tag { get; set; }
    }
}
