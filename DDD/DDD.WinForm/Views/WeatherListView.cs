using DDD.WinForm.ViewModels;
using System.Windows.Forms;

namespace DDD.WinForm.Views
{
    public partial class WeatherListView : Form
    {
        private WeatherListViewModel viewModel = new WeatherListViewModel();

        public WeatherListView()
        {
            InitializeComponent();

            this.DataBind();
        }

        private void DataBind()
        {
            WeathersDataGrid.DataBindings.Add(
                "DataSource", viewModel, nameof(viewModel.Weathers));
        }
    }
}
