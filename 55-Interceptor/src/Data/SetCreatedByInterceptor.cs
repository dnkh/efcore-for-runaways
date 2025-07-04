using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Models;

namespace Data;

public class SetCreatedByInterceptor : SaveChangesInterceptor
{   
   
    public override Microsoft.EntityFrameworkCore.Diagnostics.InterceptionResult<int> SavingChanges(DbContextEventData eventData, Microsoft.EntityFrameworkCore.Diagnostics.InterceptionResult<int> result)
    {
        var context = eventData.Context;
        if (context == null) return base.SavingChanges(eventData, result);

        var newPosts = context.ChangeTracker
            .Entries<Post>()
            .Where(e => e.State == EntityState.Added ||
                        e.State == EntityState.Modified);

        foreach (var entry in newPosts)
        {
            entry.Entity.CreatedBy = "Anonym";
        }

        return base.SavingChanges(eventData, result);
    }
}