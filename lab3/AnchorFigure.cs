using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab3
{
    class AnchorFigure
    {
        public List<BezierCurve> bezierCurves;
        public List<MyPoint> AnchorToBuild;
        public AnchorFigure(List<BezierCurve> _bezierCurves)
        {
            bezierCurves = _bezierCurves;
            AnchorToBuild = Build(bezierCurves);
        }

        public AnchorFigure()
        {
            bezierCurves = DefaultCurves();
            AnchorToBuild = Build(bezierCurves);
        }

        private List<MyPoint> Build(List<BezierCurve> curves)
        {
            List<MyPoint> ListToReturn = new List<MyPoint>();

            foreach (BezierCurve curve in curves)
            {
                ListToReturn.AddRange(curve.BezierCurvePoints);
            }

            return ListToReturn;
        }

        private List<BezierCurve> DefaultCurves()
        {
            List<BezierCurve> ListToReturn = new List<BezierCurve>();
            BezierCurve bc1 = new BezierCurve(163, 77, 120, 100, 109, 128);
            BezierCurve bc2 = new BezierCurve(109, 128, 110, 130, 127, 121);
            BezierCurve bc3 = new BezierCurve(127, 121, 123, 150, 131, 171);
            BezierCurve bc4 = new BezierCurve(137, 184, 145, 200, 173, 219);
            BezierCurve bc5 = new BezierCurve(173, 219, 195, 250, 181, 291);
            BezierCurve bc6 = new BezierCurve(181, 291, 230, 245, 281, 247);
            BezierCurve bc7 = new BezierCurve(281, 247, 425, 230, 436, 180);
            BezierCurve bc8 = new BezierCurve(436, 180, 440, 190, 451, 196);
            BezierCurve bc9 = new BezierCurve(451, 196, 455, 165, 445, 117);
            BezierCurve bc10 = new BezierCurve(445, 117, 420, 145, 390, 143);
            BezierCurve bc11 = new BezierCurve(390, 143, 400, 150, 411, 158);
            BezierCurve bc12 = new BezierCurve(411, 158, 380, 200, 314, 186);
            BezierCurve bc13 = new BezierCurve(314, 186, 275, 180, 279, 144);
            BezierCurve bc14 = new BezierCurve(282, 128, 280, 130, 310, 59);
            BezierCurve bc15 = new BezierCurve(310, 59, 320, 60, 337, 61);
            BezierCurve bc16 = new BezierCurve(337, 61, 345, 65, 353, 61);
            BezierCurve bc17 = new BezierCurve(353, 61, 360, 60, 368, 63);
            BezierCurve bc18 = new BezierCurve(368, 63, 370, 55, 368, 51);
            BezierCurve bc19 = new BezierCurve(368, 51, 360, 50, 355, 48);
            BezierCurve bc20 = new BezierCurve(355, 48, 355, 55, 353, 61);
            BezierCurve bc21 = new BezierCurve(355, 48, 350, 45, 339, 46);
            BezierCurve bc22 = new BezierCurve(339, 46, 340, 55, 337, 61);
            BezierCurve bc23 = new BezierCurve(339, 46, 310, 43, 268, 38);
            BezierCurve bc24 = new BezierCurve(268, 38, 268, 40, 255, 37);
            BezierCurve bc25 = new BezierCurve(255, 37, 250, 40, 247, 47);
            BezierCurve bc26 = new BezierCurve(247, 47, 253, 48, 258, 49);
            BezierCurve bc27 = new BezierCurve(258, 49, 262, 44, 268, 38);
            BezierCurve bc28 = new BezierCurve(258, 49, 273, 54, 289, 56);
            BezierCurve bc29 = new BezierCurve(289, 56, 300, 50, 310, 58);
            BezierCurve bc30 = new BezierCurve(317, 44, 325, 30, 311, 31);
            BezierCurve bc31 = new BezierCurve(311, 31, 305, 27, 299, 40);
            BezierCurve bc32 = new BezierCurve(289, 56, 272, 96, 247, 130);
            BezierCurve bc33 = new BezierCurve(227, 150, 205, 163, 193, 156);
            BezierCurve bc34 = new BezierCurve(174, 148, 150, 135, 152, 111);
            BezierCurve bc35 = new BezierCurve(152, 111, 163, 110, 172, 106);
            BezierCurve bc36 = new BezierCurve(172, 106, 160, 90, 163, 77);
            BezierCurve bc37 = new BezierCurve(303, 33, 270, 45, 287, 62);
            BezierCurve bc38 = new BezierCurve(305, 31, 255, 40, 282, 70);
            BezierCurve bc39 = new BezierCurve(301, 79, 345, 120, 271, 130);
            BezierCurve bc40 = new BezierCurve(271, 130, 180, 120, 76, 214);
            BezierCurve bc41 = new BezierCurve(76, 214, 76, 223, 77, 232);
            BezierCurve bc42 = new BezierCurve(77, 232, 170, 145, 241, 148);
            BezierCurve bc43 = new BezierCurve(241, 148, 375, 140, 306, 71);
            BezierCurve bc44 = new BezierCurve(318, 108, 324, 110, 329, 107);



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
