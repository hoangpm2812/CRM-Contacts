using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CRM_Contacts.Implements;
using CRM_Contacts.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace CRM_Contacts.Controllers
{
    //[Produces("application/json")]
    [Route("api/Contact")]
    [EnableCors("AllowSpecificOrigin")]
    public class ContactController : BaseController
    {
        private readonly ContactService _contactService;
        private IHostingEnvironment _hostingEnvironment;

        public ContactController(ApplicationDBContext context, IHostingEnvironment hostingEnvironment)
        {
            _contactService = new ContactService(context);
            _hostingEnvironment = hostingEnvironment;
        }

        //GET: api/<controller>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_contactService.GetAll(1));
        }

        //GET: api/<controller>/id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _contactService.GetById(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);

        }

        // POST: api/<controller>
        [HttpPost]
        public IActionResult Create([FromBody]ContactCom contact)
        {
            if (contact == null)
            {
                return BadRequest();
            }
            return Ok(_contactService.Create(contact));
        }

        //PUT: api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]ContactCom contact)
        {
            if (contact == null || contact.Id != id)
            {
                return BadRequest();
            }

            var updated = _contactService.Update(id, contact);

            if (updated != null)
            {
                return Ok(updated);
            }

            return NotImplemented();
        }

        //DELETE: api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_contactService.Delete(id))
            {
                return new NoContentResult();
            }
            return NotImplemented();
        }

        [HttpPost]
        [Route("checkDuplicatePhone")]
        public IActionResult ChekDuplicatePhoneNumber([FromBody]string phoneNumber)
        {
            return Ok(_contactService.CheckDuplicatePhoneNumber(phoneNumber));
        }

        [HttpPost]
        [Route("checkDuplicateEmail")]
        public IActionResult ChekDuplicateEmail([FromBody]string email)
        {
            return Ok(_contactService.CheckDuplicateEmail(email));
        }


        //[HttpGet]
        //[Route("download-template")]
        //public async Task<IActionResult> DownloadTemplate()
        //{
        //    string path = Path.Combine(_hostingEnvironment.ContentRootPath, "FileImport.xlsx");
        //    XSSFWorkbook workbook;
        //    using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
        //    {
        //        workbook = new XSSFWorkbook(file);
        //        file.Close();
        //    }
        //    var sheettoget = workbook.GetSheet("ImportProducts");
        //    var row = sheettoget.GetRow(0);
        //    var listAddInfo = _danhMucService.GetDanhMucByLoai(8);
        //    int index = 30;
        //    for (int i = 0; i < listAddInfo.Count; i++)
        //    {
        //        row.CreateCell(index).SetCellValue(listAddInfo[i].Ten);
        //        index++;
        //    }

        //    using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
        //    {
        //        workbook.Write(fs);
        //        fs.Close();
        //    }
        //    var memory = new MemoryStream();
        //    using (var stream = new FileStream(path, FileMode.Open))
        //    {
        //        await stream.CopyToAsync(memory);
        //    }
        //    memory.Position = 0;

        //    return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ImportProductsTemplate.xlsx");
        //}


        [HttpPost]
        [Route("import")]
        public IActionResult Import(IFormFile file)
        {
            if (file == null)
            {
                return BadRequest();
            }
            string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
            //string path = Path.Combine(_hostingEnvironment.WebRootPath, $"{Guid.NewGuid().ToString()}.xlsx");
            string path = Path.Combine(_hostingEnvironment.WebRootPath, filename);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
                stream.Position = 0;
                
                XSSFWorkbook xSSFWorkbook = new XSSFWorkbook(stream); 
                ISheet sheet = xSSFWorkbook.GetSheetAt(0);              //get first sheet from workbook
                IRow headerRow = sheet.GetRow(0);                       //get header row
                int cellCount = headerRow.LastCellNum;
                string validateNull = "";
                string validateType = "";
                ContactModel contact;
                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)   //read excel file
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue;
                    if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                    
                    
                }
               
                
            }

            System.IO.File.Delete(path);

            return Ok();
        }



    }
}