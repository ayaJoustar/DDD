using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DDD.WinForm.ViewModels;

namespace DDD.WinForm.Views
{
    public partial class WeatherListView : Form
    {
        private WeatherListViewModel _viewmodel = new WeatherListViewModel();

        public WeatherListView()
        {
            InitializeComponent();

            WeathersDataGrid.DataBindings.Add("DataSource",_viewmodel,nameof(_viewmodel.Weathers));
        }
    }
}
