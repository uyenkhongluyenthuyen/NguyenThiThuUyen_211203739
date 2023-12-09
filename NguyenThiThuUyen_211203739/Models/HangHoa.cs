using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;



namespace NguyenThiThuUyen_211203739.Models
{
    public partial class HangHoa
    {

        public int MaHang { get; set; }

        [Required(ErrorMessage = "Mã loại không được để trống.")]
        public int? MaLoai { get; set; }

        [Required(ErrorMessage = "Tên hàng không được để trống.")]
        public string? TenHang { get; set; }

        [Required(ErrorMessage = "Giá không được để trống.")]
        [Range(100, 5000, ErrorMessage = "Giá phải nằm trong khoảng từ 100 đến 5000.")]
        public decimal? Gia { get; set; }

        [Required(ErrorMessage = "Tên file ảnh không được để trống.")]
        [RegularExpression(@"^.*\.(jpg|png|gif|tiff)$", ErrorMessage = "Tên file ảnh phải có đuôi: .jpg | .png | .gif | .tiff")]
        public string? Anh { get; set; }

        public virtual LoaiHang MaLoaiNavigation { get; set; } = null!;

    }
   
   
}
