using CRM_Contacts.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Contacts.Implements
{
    public class ContactService : BaseService
    {
        private OrderService _orderService;
        public ContactService(ApplicationDBContext context) : base(context)
        {
            _orderService = new OrderService(context);
        }

        public List<ContactModel> GetAll(int numberOfPages)
        {
            IQueryable<ContactModel> query = _context.Contacts;
            return query.ToList();
        }

        public ContactModel GetById(int id)
        {
            return _context.Contacts.FirstOrDefault(c => c.Id == id);
        }

        public ContactModel GetByEmail(string email)
        {
            return _context.Contacts.FirstOrDefault(c => c.Email == email);
        }

        public ContactCom Create(ContactCom contactCom)
        {
            ContactModel contact = new ContactModel();
            contact.Name = contactCom.Name;
            contact.PhoneNumber = contactCom.PhoneNumber;
            contact.Email = contactCom.Email;
            contact.LinkCV = contactCom.LinkCV;
            contact.Order = _orderService.GetById(contactCom.OrderId);
            contact.Source = contactCom.Source;
            contact.CreateAt = contactCom.CreateAt;
            contact.Founder = contactCom.Founder;
            contact.Recommender = contactCom.Recommender;

            _context.Contacts.Add(contact);
            _context.SaveChanges();
            
            return contactCom;
        }

        public ContactCom Update(int id, ContactCom contactCom)
        {
            var contactModel = GetById(id);

            if (contactModel == null)
            {
                return null;
            }

            var orderModel = _orderService.GetById(contactCom.OrderId);

            contactModel.Email = contactCom.Email;
            contactModel.Name = contactCom.Name;
            contactModel.PhoneNumber = contactCom.PhoneNumber;
            contactModel.LinkCV = contactCom.LinkCV;
            contactModel.Order = orderModel;
            contactModel.Source = contactCom.Source;
            contactModel.Founder = contactCom.Founder;
            contactModel.Recommender = contactCom.Recommender;
            //model.Status = contact.Status;
            contactModel.UpdateAt = DateTime.Now;

            _context.Contacts.Update(contactModel);
            _context.SaveChanges();

            return contactCom;
        }
        public bool Delete(int id)
        {
            var contact = GetById(id);
            
            if (contact == null)
            {
                return false;
            }

            _context.Contacts.Remove(contact);
            _context.SaveChanges();

            return true;
        }

        public bool CheckDuplicatePhoneNumber(string phoneNumber)
        {
            var model =  _context.Contacts.Where(c => c.PhoneNumber == phoneNumber).FirstOrDefault();
            if (model == null)
            {
                return false;
            }
            return true;
        }

        public bool CheckDuplicateEmail(string email)
        {
            var model = _context.Contacts.Where(c => c.Email == email).FirstOrDefault();
            if (model == null)
            {
                return false;
            }
            return true;
        }

        //private void ExcelConn(string filepath, OleDbConnection Econ)
        //{
        //    string conStr = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", filepath);
        //    Econ = new OleDbConnection(conStr);
        //}

        //private string InsertExcelData(string filepath, string filename)
        //{
        //    string fullpath = Server.MapPath("/Excel folder/") + filename;
        //    ExcelConn(fullpath);
        //    string query = string.Format("select * from [{0}]", "Sheet1$");

        //    string query_check = string.Format("select * from [{0}] where column2_xls is null", "Sheet1$");

        //    //OleDbCommand Ecom = new OleDbCommand(query, Econ);
        //    Econ.Open();

        //    DataSet ds = new DataSet();
        //    OleDbDataAdapter oda = new OleDbDataAdapter(query, Econ);
        //    Econ.Close();
        //    oda.Fill(ds);

        //    DataTable dt = ds.Tables[0];

        //    //if (dt.Rows.Count > 0)
        //    //{
        //    //    return dt.Rows.Count + " rows error !";
        //    //}

        //    SqlBulkCopy objbulk = new SqlBulkCopy(con);
        //    objbulk.DestinationTableName = "Student";
        //    objbulk.ColumnMappings.Add("name", "name");
        //    objbulk.ColumnMappings.Add("age", "age");
        //    objbulk.ColumnMappings.Add("address", "address");
        //    objbulk.ColumnMappings.Add("salary", "salary");
        //    objbulk.ColumnMappings.Add("phone1", "phone1");
        //    objbulk.ColumnMappings.Add("phone2", "phone2");
        //    objbulk.ColumnMappings.Add("name2", "name2");
        //    objbulk.ColumnMappings.Add("name3", "name3");
        //    objbulk.ColumnMappings.Add("name4", "name4");
        //    objbulk.ColumnMappings.Add("name5", "name5");
        //    objbulk.ColumnMappings.Add("name6", "name6");
        //    con.Open();
        //    objbulk.WriteToServer(dt);
        //    con.Close();
        //    return "susscess";
        //}
    }
}
