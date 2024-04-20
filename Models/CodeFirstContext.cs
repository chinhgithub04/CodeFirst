using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Models
{
    public class CodeFirstContext : DbContext
    {

        public CodeFirstContext(DbContextOptions<CodeFirstContext> options) : base (options){ }
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<Lop> Lops { get; set; }
        public DbSet<Khoa> Khoas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=JOEL-MILLER\\SQLEXPRESS;Initial Catalog=code_first;User ID=sa;Password=0915146847;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
