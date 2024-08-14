using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Exceptions
{
    internal class NotEnoughQuantityExistsException:Exception
    {
        public NotEnoughQuantityExistsException(string message):base(message)
        {
            
        }
    }
}
