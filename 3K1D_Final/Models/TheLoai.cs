using System;
using System.Collections.Generic;

namespace _3K1D_Final.Models;

public partial class TheLoai
{
    public string IdTheLoai { get; set; } = null!;

    public string TenTheLoai { get; set; } = null!;

    public string? MoTa { get; set; }

    public virtual ICollection<Phim> IdPhims { get; set; } = new List<Phim>();
    
}
