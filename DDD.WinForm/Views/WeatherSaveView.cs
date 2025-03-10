﻿using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DDD.Domain.Entities;
using DDD.Domain.ValueObjects;
using DDD.WinForm.ViewModels;

namespace DDD.WinForm.Views
{
    public partial class WeatherSaveView : Form
    {
        private WeatherSaveViewModel _viewModel = new WeatherSaveViewModel();
        public WeatherSaveView()
        {
            InitializeComponent();

            //private System.Windows.Forms.Button SaveButton;
            //private System.Windows.Forms.ComboBox AreaIdComboBox;
            //private System.Windows.Forms.DateTimePicker DateTimeTextBox;
            //private System.Windows.Forms.ComboBox ConditionComboBox;
            //private System.Windows.Forms.TextBox TemperatureTextBox;
            //private System.Windows.Forms.Label UnitLabel;

            this.AreaIdComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.AreaIdComboBox.DataBindings.Add("SelectedValue", _viewModel, nameof(_viewModel.SelectedAreaId));
            this.AreaIdComboBox.DataBindings.Add("DataSource", _viewModel, nameof(_viewModel.Areas));
            this.AreaIdComboBox.ValueMember = nameof(AreaEntity.AreaId);
            this.AreaIdComboBox.DisplayMember = nameof(AreaEntity.AreaName);

            DateTimeTextBox.DataBindings.Add("Value", _viewModel, nameof(_viewModel.DataDateValue));

            this.ConditionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ConditionComboBox.DataBindings.Add("SelectedValue", _viewModel, nameof(_viewModel.SelectedCondition));
            this.ConditionComboBox.DataBindings.Add("DataSource", _viewModel, nameof(_viewModel.Conditions));
            this.ConditionComboBox.ValueMember = nameof(Condition.Value);
            this.ConditionComboBox.DisplayMember = nameof(Condition.DisplayValue);

            TemperatureTextBox.DataBindings.Add("Text", _viewModel, nameof(_viewModel.TemperatureText));

            //SaveButton.Click += (_, __) =>
            //{
            //    try
            //    {
            //        _viewModel.Save();
            //    }
            //    catch(Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //};
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                _viewModel.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
