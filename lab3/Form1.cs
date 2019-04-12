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
        Bitmap figBmp;
        MyPoint n = new MyPoint();
        bool IsMouseDown = false;
        PointF prevMousePos;
        int[] minIndex;
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


            DrawAnchor(anchorFigure);


            //pictureBox1.Image = bmp;
        }

        private void DrawAnchor(AnchorFigure aF)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //Graphics graphics = pictureBox1.CreateGraphics();
            Graphics graphics = Graphics.FromImage(bmp);
            graphics.Clear(Color.White);
            //graphics.DrawImage(Properties.Resources.u, new Point(0, 0));

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
                    //graphics.DrawString(curveNumber.ToString(), new Font("Calibri", 12), Brushes.Gray, bc.MiddlePoint.X + 4, bc.MiddlePoint.Y + 4);

                    graphics.DrawRectangle(new Pen(Color.Gray, 1), bc.EndPoint.X - 2, bc.EndPoint.Y - 2, 4, 4);
                }
            }
            pictureBox1.Image = bmp;
            figBmp = bmp;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            width_label.Text = $"Width: {e.X}";
            height_label.Text = $"Height: {e.Y}";
            if (!DGVEmpty && !IsMouseDown)
            {
                minIndex = NearestPoint(anchorFigure.bezierCurves, new PointF(e.X, e.Y));
                Bitmap bmp = new Bitmap(figBmp);
                Graphics graphics = Graphics.FromImage(bmp);
                graphics.DrawRectangle(new Pen(Color.Red, 1), n.X - 3, n.Y - 3, 6, 6);
                pictureBox1.Image = bmp;
            }
            if (!IsMouseDown) return;
            float xMove = e.X - prevMousePos.X;
            float yMove = e.Y - prevMousePos.Y;
            List<BezierCurve> bezCur = anchorFigure.bezierCurves;
            switch (minIndex[1])
            {
                case 1:
                    bezCur[minIndex[0]].StartPoint.X += xMove;
                    bezCur[minIndex[0]].StartPoint.Y += yMove;
                    break;
                case 2:
                    bezCur[minIndex[0]].MiddlePoint.X += xMove;
                    bezCur[minIndex[0]].MiddlePoint.Y += yMove;
                    break;
                case 3:
                    bezCur[minIndex[0]].EndPoint.X += xMove;
                    bezCur[minIndex[0]].EndPoint.Y += yMove;
                    break;
            }
            prevMousePos = new PointF(e.X, e.Y);
            bezCur[minIndex[0]].Validate();
            anchorFigure = new AnchorFigure(bezCur);
            DrawAnchor(anchorFigure);
            pictureBox1.Update();
            //bezierCurvesInfo_dgv.Update();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            prevMousePos = new PointF(e.X, e.Y);
            IsMouseDown = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseDown = false;
        }

        private int[] NearestPoint(List<BezierCurve> bezierList, PointF mousePos)
        {
            n = new MyPoint();
            float min = float.MaxValue;
            int index = 0;
            int[] mIndex = { 0, 1 };
            foreach (BezierCurve bc in bezierList)
            {
                float d1 = (float)Math.Sqrt(Math.Pow(mousePos.X - bc.StartPoint.X, 2) + Math.Pow(mousePos.Y - bc.StartPoint.Y, 2));
                float d2 = (float)Math.Sqrt(Math.Pow(mousePos.X - bc.MiddlePoint.X, 2) + Math.Pow(mousePos.Y - bc.MiddlePoint.Y, 2));
                float d3 = (float)Math.Sqrt(Math.Pow(mousePos.X - bc.EndPoint.X, 2) + Math.Pow(mousePos.Y - bc.EndPoint.Y, 2));
                if (d1 < min) { min = d1; mIndex[0] = index; mIndex[1] = 1; n = bc.StartPoint; }
                if (d2 < min) { min = d2; mIndex[0] = index; mIndex[1] = 2; n = bc.MiddlePoint; }
                if (d3 < min) { min = d3; mIndex[0] = index; mIndex[1] = 3; n = bc.EndPoint; }
                index++;
            }
            return mIndex;
        }

        private void animation_btn_Click(object sender, EventArgs e)
        {
            List<BezierCurve> buildList = anchorFigure.bezierCurves;
            List<BezierCurve> dist = new List<BezierCurve>();
            List<BezierCurve> anotherFigure = AnimationCurves();

            for (int i = 0; i < anchorFigure.bezierCurves.Count; i++)
            {
                MyPoint newS = new MyPoint(anchorFigure.bezierCurves[i].StartPoint.X - anotherFigure[i].StartPoint.X, anchorFigure.bezierCurves[i].StartPoint.Y - anotherFigure[i].StartPoint.Y);
                MyPoint newM = new MyPoint(anchorFigure.bezierCurves[i].MiddlePoint.X - anotherFigure[i].MiddlePoint.X, anchorFigure.bezierCurves[i].MiddlePoint.Y - anotherFigure[i].MiddlePoint.Y);
                MyPoint newE = new MyPoint(anchorFigure.bezierCurves[i].EndPoint.X - anotherFigure[i].EndPoint.X, anchorFigure.bezierCurves[i].EndPoint.Y - anotherFigure[i].EndPoint.Y);

                dist.Add(new BezierCurve(newS, newM, newE));
            }
            int itr = 30;
            for (int i = 0; i < itr; i++)
            {
                for (int j = 0; j < buildList.Count; j++)
                {
                    MyPoint newS = new MyPoint(buildList[j].StartPoint.X - dist[j].StartPoint.X / itr, buildList[j].StartPoint.Y - dist[j].StartPoint.Y / itr);
                    MyPoint newM = new MyPoint(buildList[j].MiddlePoint.X - dist[j].MiddlePoint.X / itr, buildList[j].MiddlePoint.Y - dist[j].MiddlePoint.Y / itr);
                    MyPoint newE = new MyPoint(buildList[j].EndPoint.X - dist[j].EndPoint.X / itr, buildList[j].EndPoint.Y - dist[j].EndPoint.Y / itr);

                    buildList[j] = new BezierCurve(newS, newM, newE);
                    buildList[j].Validate();
                }
                AnchorFigure af = new AnchorFigure(buildList);
                DrawAnchor(af);
                pictureBox1.Update();
                
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (bezierCurvesInfo_dgv.SelectedCells.Count == 2)
            {
                bezierCurvesInfo_dgv.SelectedCells[0].Value = e.Y;
                bezierCurvesInfo_dgv.SelectedCells[1].Value = e.X;
            }

        }

        private List<BezierCurve> AnimationCurves()
        {
            List<BezierCurve> ListToReturn = new List<BezierCurve>();
            BezierCurve bc1 = new BezierCurve(73, 127, 75, 137, 84, 146);
            BezierCurve bc2 = new BezierCurve(84, 146, 89, 154, 86, 170);
            BezierCurve bc3 = new BezierCurve(86, 170, 95, 171, 98, 162);
            BezierCurve bc4 = new BezierCurve(98, 162, 113, 185, 119, 211);
            BezierCurve bc5 = new BezierCurve(119, 211, 126, 210, 128, 213);
            BezierCurve bc6 = new BezierCurve(128, 213, 136, 217, 144, 212);
            BezierCurve bc7 = new BezierCurve(143, 211, 153, 206, 148, 197);
            BezierCurve bc8 = new BezierCurve(148, 197, 138, 183, 153, 163);
            BezierCurve bc9 = new BezierCurve(153, 163, 160, 170, 158, 189);
            BezierCurve bc10 = new BezierCurve(158, 189, 151, 209, 160, 224);
            BezierCurve bc11 = new BezierCurve(160, 224, 116, 241, 93, 293);
            BezierCurve bc12 = new BezierCurve(93, 293, 85, 299, 89, 305);
            BezierCurve bc13 = new BezierCurve(89, 305, 90, 312, 87, 317);
            BezierCurve bc14 = new BezierCurve(87, 317, 84, 324, 90, 327);
            BezierCurve bc15 = new BezierCurve(90, 327, 119, 306, 109, 297);
            BezierCurve bc16 = new BezierCurve(109, 297, 120, 293, 122, 279);
            BezierCurve bc17 = new BezierCurve(122, 279, 126, 265, 132, 267);
            BezierCurve bc18 = new BezierCurve(132, 267, 160, 313, 201, 291);
            BezierCurve bc19 = new BezierCurve(201, 291, 183, 271, 174, 284);
            BezierCurve bc20 = new BezierCurve(174, 284, 163, 276, 161, 267);
            BezierCurve bc21 = new BezierCurve(161, 267, 219, 254, 223, 246);
            BezierCurve bc22 = new BezierCurve(223, 246, 267, 255, 308, 240);
            BezierCurve bc23 = new BezierCurve(308, 240, 313, 257, 320, 262);
            BezierCurve bc24 = new BezierCurve(320, 262, 324, 287, 325, 307);
            BezierCurve bc25 = new BezierCurve(325, 307, 322, 330, 271, 358);
            BezierCurve bc26 = new BezierCurve(271, 358, 283, 365, 297, 364);
            BezierCurve bc27 = new BezierCurve(297, 364, 306, 345, 322, 342);
            BezierCurve bc28 = new BezierCurve(322, 342, 350, 319, 354, 289);
            BezierCurve bc29 = new BezierCurve(354, 289, 385, 304, 351, 378);
            BezierCurve bc30 = new BezierCurve(351, 378, 369, 376, 383, 369);
            BezierCurve bc31 = new BezierCurve(383, 369, 380, 315, 406, 296);
            BezierCurve bc32 = new BezierCurve(406, 296, 382, 255, 405, 211);
            BezierCurve bc33 = new BezierCurve(405, 211, 413, 188, 397, 165);
            BezierCurve bc34 = new BezierCurve(397, 165, 423, 131, 484, 136);
            BezierCurve bc35 = new BezierCurve(484, 136, 436, 117, 375, 149);
            BezierCurve bc36 = new BezierCurve(375, 149, 312, 151, 255, 147);
            BezierCurve bc37 = new BezierCurve(255, 147, 195, 92, 117, 120);
            BezierCurve bc38 = new BezierCurve(117, 120, 114, 115, 112, 108);
            BezierCurve bc39 = new BezierCurve(112, 108, 106, 116, 104, 127);
            BezierCurve bc40 = new BezierCurve(104, 127, 98, 130, 92, 135);
            BezierCurve bc41 = new BezierCurve(92, 135, 84, 129, 73, 127);
            BezierCurve bc42 = new BezierCurve(142, 113, 149, 79, 181, 74);
            BezierCurve bc43 = new BezierCurve(181, 74, 155, 86, 158, 110);
            BezierCurve bc44 = new BezierCurve(417, 132, 439, 133, 482, 135);



            ListToReturn.Add(bc1);
            ListToReturn.Add(bc2);
            ListToReturn.Add(bc3);
            ListToReturn.Add(bc4);
            ListToReturn.Add(bc5);
            ListToReturn.Add(bc6);
            ListToReturn.Add(bc7);
            ListToReturn.Add(bc8);
            ListToReturn.Add(bc9);
            ListToReturn.Add(bc10);
            ListToReturn.Add(bc11);
            ListToReturn.Add(bc12);
            ListToReturn.Add(bc13);
            ListToReturn.Add(bc14);
            ListToReturn.Add(bc15);
            ListToReturn.Add(bc16);
            ListToReturn.Add(bc17);
            ListToReturn.Add(bc18);
            ListToReturn.Add(bc19);
            ListToReturn.Add(bc20);
            ListToReturn.Add(bc21);
            ListToReturn.Add(bc22);
            ListToReturn.Add(bc23);
            ListToReturn.Add(bc24);
            ListToReturn.Add(bc25);
            ListToReturn.Add(bc26);
            ListToReturn.Add(bc27);
            ListToReturn.Add(bc28);
            ListToReturn.Add(bc29);
            ListToReturn.Add(bc30);
            ListToReturn.Add(bc31);
            ListToReturn.Add(bc32);
            ListToReturn.Add(bc33);
            ListToReturn.Add(bc34);
            ListToReturn.Add(bc35);
            ListToReturn.Add(bc36);
            ListToReturn.Add(bc37);
            ListToReturn.Add(bc38);
            ListToReturn.Add(bc39);
            ListToReturn.Add(bc40);
            ListToReturn.Add(bc41);
            ListToReturn.Add(bc42);
            ListToReturn.Add(bc43);
            ListToReturn.Add(bc44);


            return ListToReturn;

        }

    }
}
