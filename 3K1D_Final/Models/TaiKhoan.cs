using System;
using System.Collections.Generic;

namespace _3K1D_Final.Models
{
    public partial class TaiKhoan
    {
        public string UserName { get; set; } = null!;
        public string Pass { get; set; } = null!;
        public int LoaiTk { get; set; } // Phân loại tài khoản: 1 - Nhân viên, 2 - Người dùng

        public string? IdNv { get; set; } // Có thể là null nếu không phải là nhân viên
        public string? IdKhachHang { get; set; } // Có thể là null nếu không phải là người dùng

        public virtual KhachHang? IdKhachHangNavigation { get; set; } // Navigation property cho Người dùng
    }
}
