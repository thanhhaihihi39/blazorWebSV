using BlazorNhiber1.Data;
using FluentNHibernate.Testing.Values;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using ISession = NHibernate.ISession;

namespace BlazorNhiber1
{
    public class SinhVienSerivce : ISinhVienService
    {

        public async Task<List<SinhVien>> GetListSinhVien()
        {
            try
            {
                List<SinhVien> sv;
                using (NHibernate.ISession session = FluentNHibernateHelper.OpenSession())
                {
                    sv = session.Query<SinhVien>().ToList();

                }
                return sv;

            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public int GetSinhVienByHocLuc(string hocluc)
        {
            int sl;
            using (NHibernate.ISession session = FluentNHibernateHelper.OpenSession())
            {
                sl = session.Query<SinhVien>().Where(c => c.HocLuc == hocluc).Count();

            }
            return sl;

        }
        public (int slGioi, int slKha, int slTb,int slYeu) GetSoLuongChart(string monhoc)
        {
            int slGioi = 0;
            int slKha = 0;
            int slTb = 0;
            int slYeu = 0;
            if (monhoc == "SLToan")
            {

                using (NHibernate.ISession session = FluentNHibernateHelper.OpenSession())
                {
                    slGioi = session.Query<SinhVien>().Where(c => c.DiemToan >= 8).Count();
                    slKha = session.Query<SinhVien>().Where(c => c.DiemToan >= 6.5).Count();
                    slTb = session.Query<SinhVien>().Where(c => c.DiemToan >= 5).Count();
                    slYeu = session.Query<SinhVien>().Where(c => c.DiemToan >= 0 && c.DiemToan < 5).Count();

                }

            }
            else if (monhoc == "SLVan")
            {
                using (NHibernate.ISession session = FluentNHibernateHelper.OpenSession())
                {
                    slGioi = session.Query<SinhVien>().Where(c => c.DiemVan >= 8).Count();
                    slKha = session.Query<SinhVien>().Where(c => c.DiemVan >= 6.5).Count();
                    slTb = session.Query<SinhVien>().Where(c => c.DiemVan >= 5).Count();
                    slYeu = session.Query<SinhVien>().Where(c => c.DiemVan >= 0 && c.DiemVan < 5).Count();

                }
            }
            else if (monhoc == "SLAnh")
            {
                using (NHibernate.ISession session = FluentNHibernateHelper.OpenSession())
                {
                    slGioi = session.Query<SinhVien>().Where(c => c.DiemAnh >= 8).Count();
                    slKha = session.Query<SinhVien>().Where(c => c.DiemAnh >= 6.5).Count();
                    slTb = session.Query<SinhVien>().Where(c => c.DiemAnh >= 5).Count();
                    slYeu = session.Query<SinhVien>().Where(c => c.DiemAnh >= 0 && c.DiemAnh < 5).Count();

                }
            }
            return (slGioi, slKha, slTb, slYeu);


        }

        public async Task<List<SinhVien>> TaskListSearchSV(string name)
        {
            try
            {
                List<SinhVien> sv;
                using (NHibernate.ISession session = FluentNHibernateHelper.OpenSession())
                {
                    sv = session.Query<SinhVien>().Where(c=> c.Name == name).ToList();

                }
                return sv;

            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public async Task<(List<SinhVien>, int)> GetSinhVien(SinhVienPaging model)
        {
            List<SinhVien> sv;
            int count = 0;
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                count = (await session.Query<SinhVien>().ToListAsync()).Count();
                sv = (await session.Query<SinhVien>().OrderByDescending(c => c.ID).Skip((model.PageIndex - 1) * model.PageSize)
                        .Take(model.PageSize).ToListAsync());

            }
            return (sv, count);

        }
        public void AddListSinhVien(List<SinhVien> sinhvienList)
        {
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    try
                    {
                        foreach (var sinhvien in sinhvienList)
                        {

                            session.Save(sinhvien);
                        }
                        tran.Commit();
                    }
                    catch (Exception exx)
                    {
                        tran.Rollback();
                        throw exx;
                    }
                }
            }
        }
        
        public void DeleteSinhVien(SinhVien sinhVien)
        {
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    session.Delete(sinhVien);
                    tran.Commit();
                }
            }
        }
        public float TinhDTB(SinhVien sv) // hàm tính điểm trung bình 
        {
            float DiemTB = (sv.DiemToan + sv.DiemVan + sv.DiemAnh) / 3;
            DiemTB = (float)Math.Round(DiemTB, 2); // làm tròn số thập phân 2 chữ số sau giấu phẩy 
            return DiemTB;
        }
       
        public string XepLoaiHocLuc(SinhVien sv) // hàm xếp loại học lực
        {
            string HocLuc;
            if (sv.DiemTrungBinh >= 8)
            {
                HocLuc = "Giỏi";
            }
            else if (sv.DiemTrungBinh >= 6.5)
            {
                HocLuc = "Khá";
            }
            else if (sv.DiemTrungBinh >= 5)
            {
                HocLuc = "Trung Bình";
            }
            else
            {
                HocLuc = "Yếu";
            }
            return HocLuc;
        }
        //    public List<SinhVien> GetListSinhVien()
        //    {
        //        var rnd = new Random();
        //        var item = new List<SinhVien>();
        //        for(int i = 1;i<=100,i++)
        //        {
        //            item.Add(new SinhVien()
        //            {
        //                ID = i ,


        //            });
        //        }    


        public async Task<bool> UpdateSinhVien(SinhVien sv)
        {

            using (var session = FluentNHibernateHelper.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    try
                    {

                        session.Update(sv);

                        tran.Commit();
                        return true;
                    }
                    catch (Exception exx)
                    {
                        tran.Rollback();
                        throw exx;
                        return false;
                    }
                }
            }
        }

        public async Task<bool> AddSinhVien(SinhVien sv)
        {

            using (var session = FluentNHibernateHelper.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    try
                    {

                        session.Save(sv);

                        tran.Commit();
                        return true;
                    }
                    catch (Exception exx)
                    {
                        tran.Rollback();
                        throw exx;
                        return false;
                    }
                }
            }
        }


        public async Task<SinhVien>  GetSinhVienByID(int id)
        {
            SinhVien sv;
            using (ISession session = FluentNHibernateHelper.OpenSession())// nghiên cứu  open statelesssesion()
            {
                using (var tran = session.BeginTransaction())
               try
                {
                    sv = session.Get<SinhVien>(id);
                     return sv;
                }
                catch (Exception exx)
                {
                    tran.Rollback();
                    throw exx;
                    return sv;
                }
            }
           

        }

        public Task<List<SinhVien>> TaskSearchSinhVien()
        {
            throw new NotImplementedException();
        }

        public Task<SinhVien> GetSinhVienByName(int Name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SearchSinhVien(SinhVien sinhvien)
        {
            throw new NotImplementedException();
        }

        public string FindByName(string Name)
        {
            throw new NotImplementedException();
        }

        public Task<List<SinhVien>> TaskListSearchSV()
        {
            throw new NotImplementedException();
        }

        public Task<SinhVien> GetDiemTB(string Name)
        {
            throw new NotImplementedException();
        }
    }
}




