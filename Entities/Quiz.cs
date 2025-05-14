using EF010.CodeFirstMigration.Entities;

namespace EF_Core_Project.Entities
{
    public abstract class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Course Course { get; set; }
    }
}
