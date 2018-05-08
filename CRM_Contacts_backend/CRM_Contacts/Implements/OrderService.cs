using CRM_Contacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Contacts.Implements
{
    public class OrderService : BaseService
    {
        public OrderService(ApplicationDBContext context) : base(context)
        {

        }

        public List<OrderModel> GetAll()
        {
            IQueryable<OrderModel> query = _context.Orders;
            return query.ToList();
        }

        public OrderModel GetById(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == id);
        }
    }
}
