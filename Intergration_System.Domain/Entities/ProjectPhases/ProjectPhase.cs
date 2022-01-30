using System.ComponentModel.DataAnnotations.Schema;
using TM.Domain.Entities.Base;
using TM.Domain.Entities.Phases;
using TM.Domain.Entities.Projects;

#nullable disable

namespace TM.Domain.Entities.ProjectPhases
{
    [Table("ProjectPhase")]
    public partial class ProjectPhase : Entity
    {
        public int? ProjectId { get; set; }
        public int? PhaseId { get; set; }

        [ForeignKey(nameof(PhaseId))]
        [InverseProperty("ProjectPhases")]
        public virtual Phase Phase { get; set; }
        [ForeignKey(nameof(ProjectId))]
        [InverseProperty("ProjectPhases")]
        public virtual Project Project { get; set; }
    }
}
