using System;

namespace TradePanel
{
    partial class TradePanelForm
    {

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series19 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series20 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.CurrentVolume = new System.Windows.Forms.TextBox();
            this.IncrementVol = new System.Windows.Forms.VScrollBar();
            this.BidLabel = new System.Windows.Forms.TextBox();
            this.AskLabel = new System.Windows.Forms.TextBox();
            this.Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TabSample = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.ButtonBuy = new System.Windows.Forms.Button();
            this.ButtonSell = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).BeginInit();
            this.TabSample.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // CurrentVolume
            // 
            this.CurrentVolume.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CurrentVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CurrentVolume.Location = new System.Drawing.Point(88, 12);
            this.CurrentVolume.Name = "CurrentVolume";
            this.CurrentVolume.Size = new System.Drawing.Size(64, 29);
            this.CurrentVolume.TabIndex = 7;
            this.CurrentVolume.Text = "-.--";
            this.CurrentVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // IncrementVol
            // 
            this.IncrementVol.AllowDrop = true;
            this.IncrementVol.Location = new System.Drawing.Point(154, 12);
            this.IncrementVol.Name = "IncrementVol";
            this.IncrementVol.Size = new System.Drawing.Size(18, 29);
            this.IncrementVol.TabIndex = 9;
            // 
            // BidLabel
            // 
            this.BidLabel.BackColor = System.Drawing.Color.Red;
            this.BidLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BidLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BidLabel.ForeColor = System.Drawing.Color.White;
            this.BidLabel.Location = new System.Drawing.Point(13, 47);
            this.BidLabel.Name = "BidLabel";
            this.BidLabel.ReadOnly = true;
            this.BidLabel.Size = new System.Drawing.Size(69, 22);
            this.BidLabel.TabIndex = 11;
            this.BidLabel.Text = "1.14068";
            this.BidLabel.TextChanged += new System.EventHandler(this.BidLabel_TextChanged);
            // 
            // AskLabel
            // 
            this.AskLabel.BackColor = System.Drawing.Color.Blue;
            this.AskLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AskLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AskLabel.ForeColor = System.Drawing.Color.White;
            this.AskLabel.Location = new System.Drawing.Point(175, 47);
            this.AskLabel.Name = "AskLabel";
            this.AskLabel.ReadOnly = true;
            this.AskLabel.Size = new System.Drawing.Size(68, 22);
            this.AskLabel.TabIndex = 12;
            this.AskLabel.Text = "1.14068";
            this.AskLabel.TextChanged += new System.EventHandler(this.AskLabel_TextChanged);
            // 
            // Chart
            // 
            this.Chart.BorderlineWidth = 0;
            chartArea10.Name = "ChartArea1";
            this.Chart.ChartAreas.Add(chartArea10);
            this.Chart.Location = new System.Drawing.Point(6, 6);
            this.Chart.Name = "Chart";
            series19.ChartArea = "ChartArea1";
            series19.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series19.Name = "Series1";
            series20.ChartArea = "ChartArea1";
            series20.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series20.Name = "Series2";
            this.Chart.Series.Add(series19);
            this.Chart.Series.Add(series20);
            this.Chart.Size = new System.Drawing.Size(457, 138);
            this.Chart.TabIndex = 13;
            this.Chart.Text = "Chart";
            // 
            // TabSample
            // 
            this.TabSample.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabSample.Controls.Add(this.TabPage1);
            this.TabSample.Controls.Add(this.TabPage2);
            this.TabSample.Controls.Add(this.tabPage3);
            this.TabSample.Location = new System.Drawing.Point(12, 81);
            this.TabSample.Name = "TabSample";
            this.TabSample.SelectedIndex = 0;
            this.TabSample.Size = new System.Drawing.Size(477, 178);
            this.TabSample.TabIndex = 0;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.Chart);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(469, 152);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Ticks";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // TabPage2
            // 
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(469, 152);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Position Size Calculator";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // ButtonClose
            // 
            this.ButtonClose.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonClose.Image = global::GuiMT.Resource1.buttonBigClose;
            this.ButtonClose.Location = new System.Drawing.Point(250, 12);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(91, 61);
            this.ButtonClose.TabIndex = 10;
            this.ButtonClose.Text = "Close";
            this.ButtonClose.UseVisualStyleBackColor = false;
            // 
            // ButtonBuy
            // 
            this.ButtonBuy.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonBuy.BackgroundImage = global::GuiMT.Resource1.buttonBlue;
            this.ButtonBuy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonBuy.ForeColor = System.Drawing.Color.White;
            this.ButtonBuy.Location = new System.Drawing.Point(175, 12);
            this.ButtonBuy.Name = "ButtonBuy";
            this.ButtonBuy.Size = new System.Drawing.Size(68, 29);
            this.ButtonBuy.TabIndex = 4;
            this.ButtonBuy.Text = "Buy";
            this.ButtonBuy.UseVisualStyleBackColor = false;
            // 
            // ButtonSell
            // 
            this.ButtonSell.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonSell.BackgroundImage = global::GuiMT.Resource1.buttonRed;
            this.ButtonSell.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonSell.ForeColor = System.Drawing.Color.White;
            this.ButtonSell.Location = new System.Drawing.Point(13, 12);
            this.ButtonSell.Name = "ButtonSell";
            this.ButtonSell.Size = new System.Drawing.Size(69, 29);
            this.ButtonSell.TabIndex = 3;
            this.ButtonSell.Text = "Sell";
            this.ButtonSell.UseVisualStyleBackColor = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 262);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(501, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.checkBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(469, 152);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Settings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(19, 14);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(128, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Close Button Enabled";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // TradePanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(501, 284);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.AskLabel);
            this.Controls.Add(this.BidLabel);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.IncrementVol);
            this.Controls.Add(this.CurrentVolume);
            this.Controls.Add(this.ButtonBuy);
            this.Controls.Add(this.ButtonSell);
            this.Controls.Add(this.TabSample);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "TradePanelForm";
            this.TopMost = true;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).EndInit();
            this.TabSample.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        #endregion
        private System.Windows.Forms.Button ButtonSell;
        private System.Windows.Forms.Button ButtonBuy;
        private System.Windows.Forms.TextBox CurrentVolume;
        private System.Windows.Forms.VScrollBar IncrementVol;
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.TextBox BidLabel;
        private System.Windows.Forms.TextBox AskLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart;
        private System.Windows.Forms.TabControl TabSample;
        private System.Windows.Forms.TabPage TabPage1;
        private System.Windows.Forms.TabPage TabPage2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.ComponentModel.IContainer components;
    }
}