using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Contacts.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string LinkCV { get; set; }
        public OrderModel Order { get; set; }
        public string Source { get; set; }
        public DateTime CreateAt { get; set; }
        public string Founder { get; set; }
        public string Recommender { get; set; }
        public string Status { get; set; }
        public DateTime UpdateAt { get; set; }
        public int CreateBy { get; set; }

        

        //public int Assignee { get; set; }
        //public int Converter { get; set; }




    }
}
