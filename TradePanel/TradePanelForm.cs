using GuiMT;
using Serilog;
using Serilog.Sinks.Telegram;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
//using System.Windows.Forms.DataVisualization.Charting;

namespace TradePanel
{

    public partial class TradePanelForm : Form
    {

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private System.Windows.Forms.DataVisualization.Charting.Series series1;
        private System.Windows.Forms.DataVisualization.Charting.Series series2;
        
        public TradePanelForm()
        {
            InitializeComponent();
            //Log.Logger = new LoggerConfiguration()
            //    .WriteTo.Console()
            //    .WriteTo.Telegram("1846184053:AAHNyM1-KlW5dEdve7cmyPeE_aXVGX8uf7Y", "1279648811")
            //    .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
            //    .CreateLogger();

            this.Text = Resource1.Title;
            ButtonClose.Enabled = false;


            series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            series2 = new System.Windows.Forms.DataVisualization.Charting.Series();

            Chart.Series.Clear();
            Chart.Series.Add(series1);
            Chart.Series.Add(series2);

            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;

            Chart.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;

            Chart.Series[1].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;


            Chart.ChartAreas[0].CursorX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;

            Chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gainsboro;
            Chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gainsboro;
            //Chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            customBackgroundPainter(
            e,
            linethickness: 2,
            linecolor: Color.DarkGray,
            offsetborder: 3
            );
        }
        private void customBackgroundPainter(PaintEventArgs e, int linethickness = 2, Color linecolor = new Color(), int offsetborder = 6)
        {
            Rectangle rect = new Rectangle(offsetborder, offsetborder, this.ClientSize.Width - (offsetborder * 2), this.ClientSize.Height - (offsetborder * 2));

            Pen pen = new Pen(new Color());
            pen.Width = linethickness;
            if (linecolor != new Color())
            {
                pen.Color = linecolor;
            }
            else
            {
                pen.Color = Color.Black;
            }

            e.Graphics.DrawRectangle(pen, rect);
        }

        private void FormMain_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void FormMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void FormMain_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void AskLabel_TextChanged(object sender, EventArgs e)
        {
            var d = DateTime.Now;
            series1.Points.AddXY(d, Convert.ToDouble(AskLabel.Text.Replace(".", ",")));
            MinMax();
        }

        private void BidLabel_TextChanged(object sender, EventArgs e)
        {
            var d = DateTime.Now;
            series2.Points.AddXY(d, Convert.ToDouble(BidLabel.Text.Replace(".", ",")));
            MinMax();
        }

        private void MinMax()
        {
            if (series1.Points.Count == 100)
            {
                series1.Points.RemoveAt(100);
            }
            if (series2.Points.Count == 100)
            {
                series2.Points.RemoveAt(100);
            }
            double max = series1.Points.Max(x => x.YValues.Max()) > series2.Points.Max(x => x.YValues.Max())
                ? series1.Points.Max(x => x.YValues.Max())
                : series2.Points.Max(x => x.YValues.Max());

            double min = series1.Points.Min(x => x.YValues.Min()) < series2.Points.Min(x => x.YValues.Min())
                ? series1.Points.Min(x => x.YValues.Min())
                : series2.Points.Min(x => x.YValues.Min());


            if (min != max)
            {
                Chart.ChartAreas[0].AxisY.Minimum = min;
                Chart.ChartAreas[0].AxisY.Maximum = max;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                ButtonClose.Enabled = true;
            }
            else
            {
                ButtonClose.Enabled = false;
            }
        }
    }
}
