namespace BlazorNhiber1.Data
{
    public class SinhVien
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string  Sex { get; set; }
        public virtual int Age { get; set; }
        public virtual float DiemToan { get; set; }
        public virtual float DiemAnh { get; set; }
        public virtual float DiemVan { get; set; }
        public virtual float DiemTrungBinh { get; set; }
        public virtual string HocLuc { get; set; }
    }
}
