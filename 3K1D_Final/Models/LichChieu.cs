﻿using System;
using System.Collections.Generic;

namespace _3K1D_Final.Models;

public partial class LichChieu
{
    public string IdLichChieu { get; set; } = null!;

    public DateTime GioChieu { get; set; }

    public string IdPhongChieu { get; set; } = null!;

    public decimal GiaVe { get; set; }

    public int TrangThai { get; set; }

    public string? IdPhim { get; set; }

    public virtual Phim? IdPhimNavigation { get; set; }

    public virtual PhongChieu IdPhongChieuNavigation { get; set; } = null!;

    public virtual ICollection<Ve> Ves { get; set; } = new List<Ve>();
}
