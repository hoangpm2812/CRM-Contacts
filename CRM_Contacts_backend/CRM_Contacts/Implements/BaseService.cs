using CRM_Contacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Contacts.Implements
{
    public class BaseService
    {
        protected readonly ApplicationDBContext _context;

        public BaseService(ApplicationDBContext context)
        {
            _context = context;
        }
    }
}
