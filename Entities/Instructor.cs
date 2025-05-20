using EF_Core_Project.Interfaces;

namespace EF_Core_Project.Entities
{
    public class Instructor : Entity, ISoftDelete
    {
        public string? FName { get; set; }
        public string? LName { get; set; }
        public string FullName => $"{FName} {LName}";
        public int OfficeId { get; set; }
        public Office? Office { get; set; }
        public ICollection<Section> Sections { get; set; } = new List<Section>();

        public bool IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
