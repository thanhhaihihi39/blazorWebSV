using BlazorNhiber1.Data;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ISession = NHibernate.ISession;

namespace BlazorNhiber1
{
    public class TaiKhoanService
    {
        public async Task<TaiKhoan> LoginAsync(string tenDangNhap, string matKhau)
        {
            try
            {
                TaiKhoan taiKhoan = new TaiKhoan();

                if (matKhau == null)
                {
                    return null;
                }


                byte[] temp = ASCIIEncoding.ASCII.GetBytes(matKhau);
                byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

                string hasPass = "";

                foreach (byte item in hasData)
                {
                    hasPass += item;
                }
                using (ISession session = FluentNHibernateHelper.OpenSession())// nghiên cứu  open statelesssesion()
                {
                    try
                    {
                        var query = await session.QueryOver<TaiKhoan>().Where(x => x.TenDangNhap == tenDangNhap && x.MatKhau == hasPass).ListAsync();
                        taiKhoan = query.FirstOrDefault();
                    }
                    catch (Exception e)
                    {

                        throw;
                    }


                }
                return taiKhoan;
            }
            catch (Exception e)
            {

                throw e;
            }
                
            
         
            
           
        }
    }
}
