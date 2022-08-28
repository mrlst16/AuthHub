using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Models.Repo.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthHub.DAL.EntityFramework
{
    public class EFHelper<T, Tid>
        where T: EntityBase
    {
        private readonly DbContext _context;

        protected EFHelper(
            
            )
        {
            
        }

        public virtual async Task Save(T source)
        {

        }

       
    }
}
