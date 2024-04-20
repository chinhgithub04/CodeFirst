using CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhVienController : ControllerBase
    {
        private readonly CodeFirstContext _context;

        public SinhVienController(CodeFirstContext context)
        {
            _context = context;
        }

        [HttpGet("GetSinhViensCNTTFrom18To20")]
        public ActionResult<IEnumerable<SinhVien>> GetSinhViensCNTTFrom18To20()
        {
            var sinhViensCNTT = _context.SinhViens
                .Include(sv => sv.Lop)
                    .ThenInclude(l => l.Khoa)
                .Where(sv => sv.Lop.Khoa.TenKhoa == "CNTT" && sv.Tuoi >= 18 && sv.Tuoi <= 20)
                .ToList();

            if (sinhViensCNTT == null || sinhViensCNTT.Count == 0)
            {
                return NotFound();
            }

            return Ok(sinhViensCNTT);
        }
        [HttpPost("AddSinhVien")]
        public async Task<ActionResult<SinhVien>> AddSinhVien()
        {
            var khoa = new Khoa { TenKhoa = "CNTT" };
            var lop = new Lop { TenLop = "Lop1", Khoa = khoa };
            var sinhVien1 = new SinhVien { Ten = "SinhVien1", Tuoi = 19, Lop = lop };
            var sinhVien2 = new SinhVien { Ten = "SinhVien2", Tuoi = 20, Lop = lop };

            _context.Khoas.Add(khoa); // Thêm khoa vào DbContext
            _context.Lops.Add(lop); // Thêm lop vào DbContext
            _context.SinhViens.Add(sinhVien1); // Thêm sinhVien1 vào DbContext
            _context.SinhViens.Add(sinhVien2); // Thêm sinhVien2 vào DbContext

            await _context.SaveChangesAsync(); // Lưu thay đổi vào cơ sở dữ liệu

            return Ok("Dữ liệu đã được thêm vào cơ sở dữ liệu.");
        }
    }
}
