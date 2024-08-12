using System;
using System.Collections.Generic;

namespace _3K1D_Final.Models;

public partial class NhanVien
{
    public string IdNv { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public DateOnly NgaySinh { get; set; }

    public string? DiaChi { get; set; }

    public string? Sdt { get; set; }

    public string? Cccd { get; set; }

    public byte[]? HinhAnh { get; set; }

    public virtual ICollection<Ve> Ves { get; set; } = new List<Ve>();
}
