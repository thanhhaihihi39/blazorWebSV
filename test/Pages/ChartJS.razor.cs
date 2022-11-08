using AntDesign.Charts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;


namespace BlazorNhiber1.Pages
{
    public partial class ChartJS : ComponentBase
    {
        object[] data3 = new object[49];

        protected override async Task OnInitializedAsync()
        {
            for (int i = 1; i < 50; i++)
            {
                Random rd = new Random();
                data3[i - 1] = new { type = $"分类 {i}", value = rd.Next(0, 10) + 1 };
            }

            await base.OnInitializedAsync();

        }

        #region Example 1

        readonly object[] data1 =
    {
        new
        {
            type = "Category One",
            value = 27
        },
        new
        {
            type = "Category Two",
            value = 25
        },
        new
        {
            type = "Category Three",
            value = 18
        },
        new
        {
            type = "Category Four",
            value = 15
        },
        new
        {
            type = "Category Five",
            value = 10
        },
        new
        {
            type = "Other",
            value = 5
        }
    };

        readonly PieConfig config1 = new PieConfig
        {
            ForceFit = true,
            Title = new Title
            {
                Visible = true,
                Text = "Multicolor Pie Chart"
            },
            Description = new Description
            {
                Visible = true,
                Text = "Specify the color mapping field (colorField), and the pie slice will be displayed in different colors according to the field data. To specify the color, you need to configure the color as an array. \nWhen the pie chart label type is set to inner, the label will be displayed inside the slice. Set the offset value of the offset control label."
            },
            Radius = 0.8,
            AngleField = "value",
            ColorField = "type",
            Label = new PieLabelConfig
            {
                Visible = true,
                Type = "inner"
            }
        };

        #endregion Example 1
        string _dragging;
        void OnDrop(DragEventArgs e, string s)
        {
            if (!string.IsNullOrEmpty(s) && !string.IsNullOrEmpty(_dragging))
            {
                System.Diagnostics.Trace.WriteLine(s);
                int index = data.IndexOf(s);
                data.Remove(_dragging);
                data.Insert(index, _dragging);
                _dragging = null;
                StateHasChanged();
            }
        }

        void OnDragStart(DragEventArgs e, string s)
        {
            e.DataTransfer.DropEffect = "move";
            e.DataTransfer.EffectAllowed = "move";
            _dragging = s;
        }

        public List<string> data = new List<string> {
        "Racing car sprays burning fuel into crowd.",
        "Japanese princess to wed commoner.",
        "Australian walks 100km after outback crash.",
        "Man charged over missing wedding girl.",
        "Los Angeles battles huge wildfires."
    };

    }
}
