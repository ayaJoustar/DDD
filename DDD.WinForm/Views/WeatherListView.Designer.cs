﻿namespace DDD.WinForm.Views
{
    partial class WeatherListView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WeathersDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.WeathersDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // WeathersDataGrid
            // 
            this.WeathersDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WeathersDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WeathersDataGrid.Location = new System.Drawing.Point(0, 0);
            this.WeathersDataGrid.Name = "WeathersDataGrid";
            this.WeathersDataGrid.RowTemplate.Height = 21;
            this.WeathersDataGrid.Size = new System.Drawing.Size(676, 348);
            this.WeathersDataGrid.TabIndex = 0;
            // 
            // WeatherListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 348);
            this.Controls.Add(this.WeathersDataGrid);
            this.Name = "WeatherListView";
            this.Text = "WeatherListView";
            ((System.ComponentModel.ISupportInitialize)(this.WeathersDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView WeathersDataGrid;
    }
}