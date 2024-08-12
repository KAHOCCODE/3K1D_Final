using System;
using System.Collections.Generic;

namespace _3K1D_Final.Models;

public partial class PhongChieu
{
    public string IdPhongChieu { get; set; } = null!;

    public string TenPhong { get; set; } = null!;

    public virtual ICollection<LichChieu> LichChieus { get; set; } = new List<LichChieu>();
}
