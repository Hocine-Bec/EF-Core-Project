namespace EF_Core_Project.Interfaces
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
        DateTime? DateDeleted { get; set; } 

        public void Delete()
        {
            IsDeleted = true;
            DateDeleted = DateTime.Now;
        }
        public void UndoDelete()
        {
            IsDeleted = false;
            DateDeleted = null;
        }
    }
}
