using AuthHub.Models.Passwords;
using AuthHub.Models.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.DAL.Sql.Mappers
{
    public interface IDataSetMapper
    {
        User MapUser(DataTable? table);
        Password MapPassword(DataTable? table);
    }
}
