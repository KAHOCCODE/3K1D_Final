using System;
using System.Collections.Generic;

namespace _3K1D_Final.Models;

public partial class TaiKhoan
{
    public string UserName { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public int LoaiTk { get; set; }

    public string IdNv { get; set; } = null!;

    public virtual NhanVien IdNvNavigation { get; set; } = null!;
}
