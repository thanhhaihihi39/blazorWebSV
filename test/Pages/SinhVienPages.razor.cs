using AntDesign;
using AntDesign.TableModels;
using BlazorNhiber1.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Xml.Linq;


namespace BlazorNhiber1.Pages
{
    public partial class SinhVienPages : ComponentBase
    {
        [Inject] ISinhVienService sinhVienService { get; set; }

        List<SinhVien> Sinhvien { get; set; }
        EditSinhVien editSinhVien;
        SinhVienPaging SinhVienPaging1 { get; set; }
        bool visible = false;
        protected override async Task OnInitializedAsync()
        {
            SinhVienPaging1 = new SinhVienPaging();
            SinhVienPaging1.PageIndex = 1;
            SinhVienPaging1.PageSize = 5;
            Sinhvien = new();
            await LoadAsync();
        }

        public async Task LoadAsync()
        {
            Sinhvien = await sinhVienService.GetListSinhVien();
            StateHasChanged();
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
            var sinhVienData = Sinhvien.FirstOrDefault(c => c.ID == model.id);
            ShowDetail(sinhVienData);
        }

    }
}
