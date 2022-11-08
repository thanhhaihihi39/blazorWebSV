using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorNhiber1
{
    public class TaiKhoanMap : ClassMap<TaiKhoan>
    {
        public TaiKhoanMap()
        {
            Table("taikhoan");
           
            Id(x => x.ID).GeneratedBy.Identity().Column("id");
            Map(x => x.TenDangNhap).Column("tendangnhap");
            Map(x => x.MatKhau).Column("matkhau");
        }
    }
}
