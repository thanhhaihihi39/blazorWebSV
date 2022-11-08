
using BlazorNhiber1.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlazorNhiber1.Pages
{
   
       public partial class EditSinhVien : ComponentBase
    {
        [Parameter] public EventCallback Cancel { get; set; }
        [Parameter] public EventCallback<SinhVien> ValueChange { get; set; }
        SinhVienEditModel EditModel { get; set; } = new SinhVienEditModel();
        List<GioiTinh> gioitinhs;
        protected override void OnInitialized()
        {
            gioitinhs = new List<GioiTinh>
            {
            new GioiTinh  {Name = "Nam"},
            new GioiTinh  {Name = "Nữ"}
            };
        }


        public class GioiTinh
        {
            public string Name { get; set; }
        }
        public void UpdateSinhVien()
        {
            SinhVien sinhvien = new SinhVien();
            sinhvien.ID = EditModel.id;
            sinhvien.Name = EditModel.ten;
            sinhvien.Sex = EditModel.gioitinh;
            sinhvien.Age = EditModel.tuoi;
            sinhvien.DiemToan = EditModel.diemtoan;
            sinhvien.DiemVan = EditModel.diemvan;
            sinhvien.DiemAnh = EditModel.diemanh;

            sinhvien.DiemTrungBinh = sinhVienSevice.TinhDTB(sinhvien);
            sinhvien.HocLuc = sinhVienSevice.XepLoaiHocLuc(sinhvien);
            sinhVienSevice.UpdateSinhVien(sinhvien);
            Navigation.NavigateTo("list-sinhvien");
            ValueChange.InvokeAsync(sinhvien);
        }

        public void LoadData(SinhVien sinhvien)
        {
            EditModel.id = sinhvien.ID;
            EditModel.ten = sinhvien.Name;
            EditModel.gioitinh = sinhvien.Sex;
            EditModel.tuoi = sinhvien.Age;
            EditModel.diemtoan = sinhvien.DiemToan;
            EditModel.diemvan = sinhvien.DiemVan;
            EditModel.diemanh = sinhvien.DiemAnh;
            EditModel.diemtb = sinhvien.DiemTrungBinh;
            EditModel.hocluc = sinhvien.HocLuc;

            StateHasChanged();
        }
    }
}

