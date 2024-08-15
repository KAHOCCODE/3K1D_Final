using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace _3K1D_Final.Models;

public partial class KhachHang : IValidatableObject
{
    [DisplayName("Mã khách hàng")]
    [Required(ErrorMessage = "Mã khách hàng không được để trống")]
    [RegularExpression(@"^KH\d+$", ErrorMessage = "Mã khách hàng phải bắt đầu bằng 'KH' và theo sau là số")]
    public string IdKhachHang { get; set; } = null!;

    [DisplayName("Họ tên")]
    [Required(ErrorMessage = "Họ tên không được để trống")]
    [MaxLength(50, ErrorMessage = "Họ tên không được vượt quá 50 ký tự")]
    public string HoTen { get; set; } = null!;

    [DisplayName("Ngày sinh")]
    [Required(ErrorMessage = "Ngày sinh không được để trống")]
    public DateOnly NgaySinh { get; set; }

    [DisplayName("Địa chỉ")]
    [Required(ErrorMessage = "Địa chỉ không được để trống")]
    [MaxLength(100, ErrorMessage = "Địa chỉ không được vượt quá 100 ký tự")]
    public string DiaChi { get; set; } = null!;

    [DisplayName("Số điện thoại")]
    [Required(ErrorMessage = "Số điện thoại không được để trống")]
    [MaxLength(10, ErrorMessage = "Số điện thoại phải là 10 số")]
    [MinLength(10, ErrorMessage = "Số điện thoại phải là 10 số")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Số điện thoại chỉ được chứa 10 chữ số")]
    public string Sdt { get; set; } = null!;

    [DisplayName("CCCD")]
    [Required(ErrorMessage = "CCCD không được để trống")]
    [MaxLength(12, ErrorMessage = "CCCD phải là 12 số")]
    [MinLength(12, ErrorMessage = "CCCD phải là 12 số")]
    [RegularExpression(@"^\d{12}$", ErrorMessage = "CCCD chỉ được chứa 12 chữ số")]
    public string Cccd { get; set; } = null!;


    public string? Email { get; set; }

    [DisplayName("Điểm tích lũy")]
    public int? DiemTichLuy { get; set; }

    public virtual ICollection<Ve> Ves { get; set; } = new List<Ve>();

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!Regex.IsMatch(IdKhachHang, @"^KH\d+$"))
        {
            yield return new ValidationResult("Mã khách hàng phải bắt đầu bằng 'KH' và theo sau là số", new[] { nameof(IdKhachHang) });
        }
    }
}
