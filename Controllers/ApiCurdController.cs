using ApiPhoneEcommerce.Models.Curd;
using ApiPhoneEcommerce.Models.Entity;
using DemoApi.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace ApiPhoneEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCurdController : ControllerBase
    {
        private readonly PhoneEcommerceContext _context;

        public ApiCurdController(PhoneEcommerceContext context)
        {
            _context = context;
        }
        [HttpGet("Show-danh-sach")]
        public IActionResult DanhSach()
        {
            var item = _context.Products
                .Select(x => new OutputProduct(){
                    
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    UnitPrice = x.UnitPrice,

                 })
                .ToList();
            return  Ok(item);

        }

        [HttpPost("them-san-pham")]
        //public IActionResult TaoKhoa(InputKhoa input)
        public IActionResult AddSP([FromForm] InputCurd input)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product();
                product.Id = Guid.NewGuid().ToString();
                product.ProductId = input.ProductId;
                product.ProductName = input.ProductName;
                product.Description = input.Description;
                product.UnitPrice = input.UnitPrice;
                product.Filter = input.ProductId + " " + input.ProductName;
                List<OutputImage> listimage = new List<OutputImage>();
                foreach (var img in input.Images)
                {
                    OutputImage output = new OutputImage();
                    output.UrlImage = UploadFiles.SaveImage(img);
                    output.Position = 1;
                    listimage.Add(output);
                }
                //product.UrlImages = JsonSerializer.Serialize(listimage);

                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok(product);
            }
            return BadRequest();
        }

        //api get 1 data
        [HttpGet("thong-tin-khoa/{id}")]
        public IActionResult ItemKhoa(string id)
        {
            var item = _context.Products.FirstOrDefault(x => x.Id == id);
            return Ok(item);
        }

        [HttpDelete("xoa-khoa/{id}")]
        public IActionResult Delete(string id)
        {
            var item = _context.Products.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _context.Products.Remove(item);
                _context.SaveChanges();
            }
            return Ok();
        }
    }
}

