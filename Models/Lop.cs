namespace CodeFirst.Models
{
    public class Lop
    {
        public int LopId { get; set; }
        public string TenLop { get; set; }
        public int KhoaId { get; set; }
        public virtual Khoa Khoa { get; set; }
        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
