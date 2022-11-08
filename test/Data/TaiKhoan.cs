using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorNhiber1
{
    public class TaiKhoan
    {
        
        public virtual int ID { get; set; }
        [Required]
        public virtual string TenDangNhap { get; set; }
        [Required]
        public virtual string MatKhau { get; set; }
    }
}
