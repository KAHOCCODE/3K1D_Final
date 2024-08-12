using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace _3K1D_Final.Models;

public partial class KhachHang
{
    [DisplayName("Mã khách hàng")]
    public string IdKhachHang { get; set; } = null!;
    [DisplayName("Họ tên")]
    public string HoTen { get; set; } = null!;
    [DisplayName("Ngày sinh")]

    public DateOnly NgaySinh { get; set; }
    [DisplayName("Địa chỉ")]

    public string? DiaChi { get; set; }
    [DisplayName("Số điện thoại")]

    public string? Sdt { get; set; }
    [DisplayName("CCCD")]

    public string? Cccd { get; set; }
    [DisplayName("Điểm tích lũy")]

    public int? DiemTichLuy { get; set; }

    public virtual ICollection<Ve> Ves { get; set; } = new List<Ve>();
}
