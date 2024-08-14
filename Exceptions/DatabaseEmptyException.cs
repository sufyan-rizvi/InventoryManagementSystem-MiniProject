using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Exceptions
{
    internal class DatabaseEmptyException:Exception

    {
        public DatabaseEmptyException(string message):base(message)
        {
            
        }
    }
}
