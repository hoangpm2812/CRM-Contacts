using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Contacts.Models
{
    public class ResultModel
    {
        public string Message { get; set; }
        public object Data { get; set; }
    }

    public class ResultSmsServiceModel
    {
        //trạng thái status = 0 là thành công
        public int Status { get; set; }
        //Status Code có giá trị khi có lỗi 
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
