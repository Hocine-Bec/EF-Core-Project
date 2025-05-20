using EF_Core_Project.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EF_Core_Project.Data.Interceptors
{
    public class SoftDeleteInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, 
            InterceptionResult<int> result)
        {
            if (eventData.Context == null)
                return result;

            foreach (var entry in eventData.Context.ChangeTracker.Entries())
            {
                //if(entry != null || entry.State != EntityState.Modified || !(entry.Entity is ISoftDelete entity))
                if (entry is not { State: EntityState.Deleted, Entity: ISoftDelete entity })
                    continue;

                entry.State = EntityState.Modified;
                entity.Delete();
            }

            return result;
        }
    }
}
