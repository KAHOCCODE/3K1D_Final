﻿using System;
using System.Collections.Generic;

namespace _3K1D_Final.Models;

public partial class Ve
{
    public int IdVe { get; set; }

    public int? LoaiVe { get; set; }

    public string? IdLichChieu { get; set; }

    public string? MaGheNgoi { get; set; }

    public string? IdKhachHang { get; set; }

    public int TrangThai { get; set; }

    public decimal? TienBanVe { get; set; }

    public string? IdNv { get; set; }

    public DateTime? NgayMua { get; set; }

    public virtual KhachHang? IdKhachHangNavigation { get; set; }

    public virtual LichChieu? IdLichChieuNavigation { get; set; }

    public virtual NhanVien? IdNvNavigation { get; set; }
}
