using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class Form1 : Form
    {
        AnchorFigure anchorFigure, altAnchor = new AnchorFigure();
        private bool DGVEmpty = true;
        public Form1()
        {
            InitializeComponent();
            bezierCurvesInfo_dgv.Columns.Add("id", "Number");
            bezierCurvesInfo_dgv.Columns.Add("sx", "Start X");
            bezierCurvesInfo_dgv.Columns.Add("sy", "Start Y");
            bezierCurvesInfo_dgv.Columns.Add("mx", "Middle X");
            bezierCurvesInfo_dgv.Columns.Add("my", "Middle Y");
            bezierCurvesInfo_dgv.Columns.Add("ex", "End X");
            bezierCurvesInfo_dgv.Columns.Add("ey", "End Y");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<BezierCurve> bezierCurvesToBuild = new List<BezierCurve>();

            if (!DGVEmpty)
            {
                for (int i = 0; i < bezierCurvesInfo_dgv.Rows.Count - 1; i++)
                {
                    MyPoint sp = new MyPoint
                    {
                        X = (float)Convert.ToDouble(bezierCurvesInfo_dgv.Rows[i].Cells[1].Value),
                        Y = (float)Convert.ToDouble(bezierCurvesInfo_dgv.Rows[i].Cells[2].Value)
                    };

                    MyPoint mp = new MyPoint
                    {
                        X = (float)Convert.ToDouble(bezierCurvesInfo_dgv.Rows[i].Cells[3].Value),
                        Y = (float)Convert.ToDouble(bezierCurvesInfo_dgv.Rows[i].Cells[4].Value)
                    };

                    MyPoint ep = new MyPoint
                    {
                        X = (float)Convert.ToDouble(bezierCurvesInfo_dgv.Rows[i].Cells[5].Value),
                        Y = (float)Convert.ToDouble(bezierCurvesInfo_dgv.Rows[i].Cells[6].Value)
                    };
                    BezierCurve bc = new BezierCurve(sp, mp, ep);
                    bezierCurvesToBuild.Add(bc);
                }
                anchorFigure = new AnchorFigure(bezierCurvesToBuild);
            }
            else
            {
                anchorFigure = new AnchorFigure();
            }

            //graphics.DrawImage(Properties.Resources.Untitled, new Point(0, 0));

            DrawAnchor(anchorFigure);
            

            //pictureBox1.Image = bmp;
        }

        private void DrawAnchor(AnchorFigure aF)
        {
            Graphics graphics = pictureBox1.CreateGraphics();
            graphics.Clear(Color.White);

            for (int i = 0; i < aF.AnchorToBuild.Count; i++)
            {
                if (!aF.AnchorToBuild[i].NewStart) graphics.DrawLine(new Pen(Color.Red, 2), aF.AnchorToBuild[i - 1].GetPoint(), aF.AnchorToBuild[i].GetPoint());
                //Thread.Sleep(2);
            }
            bezierCurvesInfo_dgv.Rows.Clear();

            int curveNumber = 0;
            foreach (BezierCurve bc in aF.bezierCurves)
            {
                curveNumber++;
                DataGridViewRow newRow = new DataGridViewRow();
                bezierCurvesInfo_dgv.Rows.Add(curveNumber, bc.StartPoint.X, bc.StartPoint.Y, bc.MiddlePoint.X, bc.MiddlePoint.Y, bc.EndPoint.X, bc.EndPoint.Y);
                DGVEmpty = false;
                if (drawPoints_chb.Checked)
                {
                    graphics.DrawLine(new Pen(Color.Gray, 1), bc.StartPoint.GetPoint(), bc.MiddlePoint.GetPoint());
                    graphics.DrawLine(new Pen(Color.Gray, 1), bc.MiddlePoint.GetPoint(), bc.EndPoint.GetPoint());
                    graphics.DrawRectangle(new Pen(Color.Gray, 1), bc.StartPoint.X - 2, bc.StartPoint.Y - 2, 4, 4);
                    graphics.DrawRectangle(new Pen(Color.Gray, 1), bc.MiddlePoint.X - 2, bc.MiddlePoint.Y - 2, 4, 4);
                    graphics.DrawString(curveNumber.ToString(), new Font("Calibri", 12), Brushes.Gray, bc.MiddlePoint.X + 4, bc.MiddlePoint.Y + 4);

                    graphics.DrawRectangle(new Pen(Color.Gray, 1), bc.EndPoint.X - 2, bc.EndPoint.Y - 2, 4, 4);
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            width_label.Text = $"Width: {e.X}";
            height_label.Text = $"Height: {e.Y}";

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (bezierCurvesInfo_dgv.SelectedCells.Count == 2)
            {
                bezierCurvesInfo_dgv.SelectedCells[0].Value = e.Y;
                bezierCurvesInfo_dgv.SelectedCells[1].Value = e.X;
            }

        }
    }
}
