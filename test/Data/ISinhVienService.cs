using NHibernate.Criterion;
using System.Runtime.Serialization;

namespace BlazorNhiber1.Data
{
    public interface ISinhVienService
    {
        Task<List<SinhVien>> GetListSinhVien();
        Task<List<SinhVien>> TaskListSearchSV(string name);
        Task<(List<SinhVien>, int)> GetSinhVien(SinhVienPaging model);
         Task<SinhVien> GetSinhVienByID(int id);
        Task<SinhVien> GetSinhVienByName(int Name);
        int GetSinhVienByHocLuc(string hocluc);
        float TinhDTB(SinhVien sv);
        string XepLoaiHocLuc(SinhVien sv);
        Task<bool> UpdateSinhVien(SinhVien sinhvien);
        Task<bool> SearchSinhVien(SinhVien sinhvien);
        Task<bool> AddSinhVien(SinhVien sinhvien);
        void AddListSinhVien(List<SinhVien> sinhvien);
        void DeleteSinhVien(SinhVien sinhVien);
      
    }

    [DataContract]
    public class ExcuteResponse
    {
        [DataMember(Order = 1)]
        public bool State { get; set; }
        
    }
}
