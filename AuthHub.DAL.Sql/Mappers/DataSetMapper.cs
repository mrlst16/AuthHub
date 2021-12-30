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
    public class DataSetMapper : IDataSetMapper
    {
        public Password MapPassword(DataTable table)
        {
            var result = new Password();
            if (table.HasDataForRow(0, out DataRow? row))
            {
                return new Password()
                {
                    Iterations = row.Field<int>(""),
                    HashLength = row.Field<int>("HasLength")
                    
                };
            }
            return result;
        }
//        CREATE TABLE[dbo].[Password]
//        (

//   [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
//    [FK_User] UNIQUEIDENTIFIER NOT NULL, 
//    [UserName] NCHAR(200) NOT NULL,
//    [PasswordHash] VARBINARY(MAX) NOT NULL,
//    [Salt] VARBINARY(MAX) NOT NULL,
//    [HashLength] INT NOT NULL, 
//    [CreatedUTC] DATETIME NOT NULL default getutcdate(), 
//    [ModifiedUTC] DATETIME NOT NULL default getutcdate(), 
//    [DeletedUTC]
//        DATETIME NULL,
//    CONSTRAINT[FK_Password_ToUser] FOREIGN KEY(FK_User) REFERENCES[User] (Id)
//)

        public User MapUser(DataTable? table)
        {
            var result = new User();
            if (table?.HasDataForRow(0, out DataRow? row) ?? false)
            {
                result = new User()
                {
                    ID = row.Field<Guid>("ID"),
                    FirstName = row.Field<string>("FirstName"),
                    LastName = row.Field<string>("LastName"),
                    Email = row.Field<string>("Email"),
                    UserName = row.Field<string>("UserName")
                };
            }
            return result;
        }
    }
}
