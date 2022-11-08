using AntDesign;
using AntDesign.TableModels;
using BlazorNhiber1.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Xml.Linq;


namespace BlazorNhiber1.Pages
{
    public partial class SinhVienList : ComponentBase
    {
        [Inject] ISinhVienService sinhVienService { get; set; }

        List<SinhVien> SinhViens { get; set; }
        List<SinhVienViewModel> SinhVienViewModels { get; set; }
        EditSinhVien editSinhVien;
         TaskSearchSinhVien TaskSearchSinhViens = new TaskSearchSinhVien();
        SinhVienPaging SinhVienPaging1 { get; set; }
        bool visible = false;
        
       
        protected override async Task OnInitializedAsync()
        {
            SinhVienPaging1 = new SinhVienPaging();
            SinhVienViewModels = new List<SinhVienViewModel>();
            SinhVienPaging1.PageIndex = 1;
            SinhVienPaging1.PageSize = 5;
            SinhViens = new();
      
            await LoadAsync();
        }

        public async Task LoadAsync()
        {
            SinhVienViewModels.Clear();
            SinhViens = await sinhVienService.GetListSinhVien();
            SinhVienViewModels = GetViewModels(SinhViens);
            StateHasChanged();
        }
        public async Task Search()
        {
            var name = TaskSearchSinhViens.Name;
            SinhVienViewModels.Clear();
            SinhViens = await sinhVienService.TaskListSearchSV(name);
            SinhVienViewModels = GetViewModels(SinhViens);
            StateHasChanged();
        }
        async Task DeleteSinhVienAsync(int id)
        {
            try
            {
                SinhVien sv = await sinhVienService.GetSinhVienByID(id);
                sinhVienService.DeleteSinhVien(sv);
                await LoadAsync();
            }
            catch (Exception e)
            {
                throw e;
            }


        }
        List<SinhVienViewModel> GetViewModels(List<SinhVien> datas)
        {
            var models = new List<SinhVienViewModel>();
            SinhVienViewModel model;
            int stt = 1;
            datas.ForEach(c =>
            {
                model = new SinhVienViewModel();
                model.stt = stt;
                model.ten = c.Name;
                model.gioitinh = c.Sex;
                model.tuoi = c.Age;
                model.diemtoan = c.DiemToan;
                model.diemanh = c.DiemAnh;
                model.diemvan = c.DiemVan;
                model.diemtb = c.DiemTrungBinh;
                model.hocluc = c.HocLuc;
                model.id = c.ID;
                models.Add(model);
                stt++;
            });
            return models;
        }

        async Task PageIndexChangeAsync(PaginationEventArgs e)
        {
            try
            {
                SinhVienPaging1.PageIndex = e.Page;
                await LoadAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        async Task PageSizeChangeAsync(PaginationEventArgs e)
        {
            try
            {
                SinhVienPaging1.PageSize = e.PageSize;
                await LoadAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        void Add()
        {
            var sinhVienData = new SinhVien();
            ShowDetail(sinhVienData);
        }
        void ShowDetail(SinhVien data)
        {
            editSinhVien.LoadData(data);
            visible = true;
        }
        void Edit(SinhVienViewModel model)
        {
            var sinhVienData = SinhViens.FirstOrDefault(c => c.ID == model.id);
            ShowDetail(sinhVienData);
        }

        async Task Save(SinhVien data)
        {
            if (data.ID == 0)
            {
                var resultAdd = await sinhVienService.AddSinhVien(data);
            }
            else
            {

            }
            await LoadAsync();

        }   

        async Task Search(SinhVien data)
        {
            if (data.ID == 0)
            {
                var resultAdd = await sinhVienService.AddSinhVien(data);
            }
            else
            {

            }
            await LoadAsync();

        }
        async Task Update(SinhVien data)
        {
            if (data.ID == 0)
            {
                var resultAdd = await sinhVienService.UpdateSinhVien(data);

            }
            else
            {

            }
            await LoadAsync();
        }
        public class TaskSearchSinhVien
        {
            public string Name { get; set; }
        }
    }
}
