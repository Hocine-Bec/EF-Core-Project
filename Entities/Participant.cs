namespace EF010.CodeFirstMigration.Entities
{
    public class Participant
    {
        public int Id { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }
        public ICollection<Section> Sections { get; set; } = new List<Section>();

    }
    public class Individual : Participant
    {
        public string University { get; set; }
        public int YearOfGrad { get; set; }
        public bool IsIntern { get; set; }

        public override string ToString()
        {
            return $"{Id} | {FName} {LName} | Graduated {YearOfGrad} from {University} {(IsIntern ? "| Internship" : "")}";
        }

    }
    public class Corporate : Participant
    {
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public override string ToString()
        {
            return $"{Id} | {FName} {LName} | {JobTitle} at {Company}";
        }
    }
}
