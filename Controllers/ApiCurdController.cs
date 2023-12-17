using ApiPhoneEcommerce.Models.Curd;
using ApiPhoneEcommerce.Models.Entity;
using DemoApi.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace ApiPhoneEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="admin")]
    public class ApiCurdController : ControllerBase
    {
        private readonly PhoneEcommerceContext _context;

        public ApiCurdController(PhoneEcommerceContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet("Show-danh-sach")]        
        public IActionResult DanhSach()
        {
            var item = _context.Products
                .Select(x => new OutputProduct(){
                    Id =  x.Id,
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    UnitPrice = x.UnitPrice,
                    Urlimg = x.Urlimg 

                 })
                .ToList();
            return  Ok(item);

        }

        [HttpPost("them-san-pham")]
        public IActionResult AddSP([FromForm] InputProduct input)
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
                
                foreach (var img in input.Urlimg)
                {
                    OutputImage output = new OutputImage();
                    output.Urlimg = UploadFiles.SaveImage(img);
                    output.Position = 1;
                    listimage.Add(output);
                }
                product.Urlimg = JsonSerializer.Serialize(listimage);

                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok(product);
            }
            return BadRequest();
        }

        //api get 1 data
        [AllowAnonymous]
        [HttpGet("thong-tin-san-pham/{id}")]        
        public IActionResult ItemKhoa(string id)
        {
            var item = _context.Products.FirstOrDefault(x => x.Id == id);
            return Ok(item);
        }

        [HttpDelete("xoa-san-pham/{id}")]
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

        [HttpPut("cap-nhat-san-pham/{id}")]
        public IActionResult CapNhat(Guid id, [FromForm] UpdateProduct input)
        {
            var item = _context.Products.FirstOrDefault(c => c.Id == id.ToString());
            if (item != null)
            {
                item.ProductId = input.ProductId;
                item.ProductName = input.ProductName;
                item.Description = input.Description;
                item.UnitPrice = input.UnitPrice;
                item.Filter = input.ProductId + " " + input.ProductName;

                _context.Products.Update(item);
                _context.SaveChanges();
                return Ok(item);
            }
            return NotFound();
        }
    }
}

