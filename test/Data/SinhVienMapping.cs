using FluentNHibernate.Mapping;

namespace BlazorNhiber1.Data
{
    public class SinhVienMapping
    {
        class SinhVienMappping : ClassMap<SinhVien>
        {

            public SinhVienMappping()
            {
                Id(x => x.ID).GeneratedBy.Identity().Column("ID");
                Map(x => x.Name).Column("Name");
                Map(x => x.Sex).Column("Sex");
                Map(x => x.Age).Column("Age");
                Map(x => x.DiemToan).Column("DiemToan");
                Map(x => x.DiemAnh).Column("DiemAnh");
                Map(x => x.DiemVan).Column("DiemVan");
                Map(x => x.DiemTrungBinh).Column("DiemTrungBinh");
                Map(x => x.HocLuc).Column("HocLuc");
                Table("T_SinhVIen");
            }
        }
    }
}

