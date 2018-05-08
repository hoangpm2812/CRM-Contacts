using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Contacts.Models
{
    public class ContactCom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string LinkCV { get; set; }
        public int OrderId { get; set; }
        public string Source { get; set; }
        public DateTime CreateAt { get; set; }
        public string Founder { get; set; }
        public string Recommender { get; set; }
        public string Status { get; set; }
        public DateTime UpdateAt { get; set; }
        public int CreateBy { get; set; }
    }
}
