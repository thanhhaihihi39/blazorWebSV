using AntDesign;
using BlazorNhiber1;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorNhiber1.Data;

namespace BlazorNhiber1.Pages
{
    public partial class Login : ComponentBase
    {

        TaiKhoanService taiKhoanService = new TaiKhoanService();

        TaiKhoan taikhoan;
        protected override Task OnInitializedAsync()
        {
            taikhoan = new TaiKhoan();
            return base.OnInitializedAsync();
        }
        public async Task<bool> login()
        {


            
                try
                  {
                if (true)
                {

                }

                    var tk = await taiKhoanService.LoginAsync(taikhoan.TenDangNhap, taikhoan.MatKhau);
                           if (tk != null  )
                {
                    //((CustomAuthenticationStateProvider)AuthenticationStateProvider).MarkUserAsAuthienticated(tk.TenDangNhap);
                    NavigationManager.NavigateTo("/list-sinhvien");

                    await sessionStorage.SetItemAsync("tenDangNhap", tk.TenDangNhap);
                   
                    return await Task.FromResult(true);
                }
                else
                {

                    await _notice.Open(new NotificationConfig()
                    {
                        Message = "Thông báo",
                        Description = "Tài khoản hoặc mật khẩu không đúng"
                    });
                    return await Task.FromResult(false);
                }
            }
            catch (Exception y)
            {

                throw y;
            }
                 

       

    }
        private void OnFinish(EditContext editContext)
        {
            Console.WriteLine($"Success:{JsonSerializer.Serialize(taikhoan)}");
        }

        private void OnFinishFailed(EditContext editContext)
        {
            Console.WriteLine($"Failed:{JsonSerializer.Serialize(taikhoan)}");
        }
    }
}
