using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace _3K1D_Final.Models;

public partial class Phim
{
    public string IdPhim { get; set; } = null!;

    public string TenPhim { get; set; } = null!;

    public string? MoTa { get; set; }

    public double ThoiLuong { get; set; }

    public DateOnly NgayKhoiChieu { get; set; }

    public DateOnly NgayKetThuc { get; set; }

    public string QuocGiaSanXuat { get; set; } = null!;

    public string? DaoDien { get; set; }

    public int NamSx { get; set; }

    public byte[]? ApPhich { get; set; }

    public string? DinhDangPhim { get; set; }

    public virtual ICollection<LichChieu> LichChieus { get; set; } = new List<LichChieu>();

    public virtual ICollection<TheLoai> IdTheLoais { get; set; } = new List<TheLoai>();
}
    