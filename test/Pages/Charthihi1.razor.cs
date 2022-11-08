using AntDesign;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;

using AntDesign.Charts;
using Title = AntDesign.Charts.Title;


namespace BlazorNhiber1.Pages
{
    
    public partial class Charthihi1 : ComponentBase
    {
        List<object> data1 = new List<object>();
        IChartComponent myChart;
        void handleChange(string value)
        {
            SinhVienSerivce service = new SinhVienSerivce();
            var sll = service.GetSoLuongChart(value);
            int G1 = sll.slGioi;
            int K1 = sll.slKha;
            int TB1 = sll.slTb;
            int Y1 = sll.slYeu;
            setChart(G1, K1, TB1, Y1);
        }

        void setChart(int G, int K, int TB, int Y)
        {
            data1.Clear();
            data1.Add(
               new
               {
                   type = "Giỏi",
                   sales = G
               });
            data1.Add(
           new
           {
               type = "Khá",
               sales = K
           });
            data1.Add(
                  new
                  {
                      type = "Trung Bình",
                      sales = TB
                  });
            data1.Add(
              new
              {
                  type = "Yếu",
                  sales = Y
              });
            myChart.ChangeData(data1, true);
        }

        #region 示例1
        protected override async Task OnInitializedAsync()
        {
            SinhVienSerivce service = new SinhVienSerivce();
            var sll = service.GetSoLuongChart("SLToan");
            int G1 = sll.slGioi;
            int K1 = sll.slKha;
            int TB1 = sll.slTb;
            int Y1 = sll.slYeu;
            data1.Add(
               new
               {
                   type = "Giỏi",
                   sales = G1
               });
            data1.Add(
           new
           {
               type = "Khá",
               sales = K1
           });
            data1.Add(
                  new
                  {
                      type = "Trung Bình",
                      sales = TB1
                  });
            data1.Add(
              new
              {
                  type = "Yếu",
                  sales = Y1
              });
            await base.OnInitializedAsync();

        }




        ColumnConfig config1 = new ColumnConfig
        {
            Title = new Title
            {
                Visible = true,
                Text = "基础柱状图"
            },
            ForceFit = true,
            Padding = "auto",
            XField = "type",
            YField = "sales",
            Meta = new
            {
                Type = new
                {
                    Alias = "类别"
                },
                Sales = new
                {
                    Alias = "销售额(万)"
                }
            }
        };

        #endregion 示例1
    }

}

