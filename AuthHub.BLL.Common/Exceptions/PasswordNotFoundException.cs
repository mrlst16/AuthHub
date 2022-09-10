using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.BLL.Common.Exceptions
{
    public class PasswordNotFoundException: NotFoundException
    {

        public PasswordNotFoundException(Guid id)
        {
            
        }
    }
}
