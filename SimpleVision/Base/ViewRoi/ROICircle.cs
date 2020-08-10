using System;
using HalconDotNet;

namespace ViewROI
{
    /// <summary>
    /// This class demonstrates one of the possible implementations for a 
    /// circular ROI. ROICircle inherits from the base class ROI and 
    /// implements (besides other auxiliary methods) all virtual methods 
    /// defined in ROI.cs.
    /// </summary>
    public class ROICircle : ROI,RoiInterfac
	{

		private double radius;
		private double row1, col1;  // first handle
		private double midR, midC;  // second handle

      

        public ROICircle()
		{
            RoiType = GetType().ToString();
			NumHandles = 2; // one at corner of circle + midpoint
			activeHandleIdx = 1;
		}

        public ROICircle(string Name)
        {
            RoiName = Name;
            RoiType = GetType().ToString();
            NumHandles = 2; // one at corner of circle + midpoint
            activeHandleIdx = 1;
        }

        /// <summary>Creates a new ROI instance at the mouse position</summary>
        public override void createROI(double midX, double midY)
		{
			midR = midY;
			midC = midX;

			radius = 100;

			row1 = midR;
			col1 = midC + radius;
		}


        public override void createROI(HTuple RoiParameters)
        {

            //return new HTuple(new double[] { midR, midC, radius });

            midR = RoiParameters[0];
            midC = RoiParameters[1];

            radius = RoiParameters[2];

            row1 = midR;
            col1 = midC + radius;
        }


        /// <summary>Paints the ROI into the supplied window</summary>
        /// <param name="window">HALCON window</param>
        public override void draw(HalconDotNet.HWindow window)
		{
			window.DispCircle(midR, midC, radius);
			window.DispRectangle2(row1, col1, 0, 5, 5);
			window.DispRectangle2(midR, midC, 0, 5, 5);
		}

		/// <summary> 
		/// Returns the distance of the ROI handle being
		/// closest to the image point(x,y)
		/// </summary>
		public override double distToClosestHandle(double x, double y)
		{
			double max = 10000;
			double [] val = new double[NumHandles];

			val[0] = HMisc.DistancePp(y, x, row1, col1); // border handle 
			val[1] = HMisc.DistancePp(y, x, midR, midC); // midpoint 

			for (int i=0; i < NumHandles; i++)
			{
				if (val[i] < max)
				{
					max = val[i];
					activeHandleIdx = i;
				}
			}// end of for 
			return val[activeHandleIdx];
		}

		/// <summary> 
		/// Paints the active handle of the ROI object into the supplied window 
		/// </summary>
		public override void displayActive(HalconDotNet.HWindow window)
		{

			switch (activeHandleIdx)
			{
				case 0:
					window.DispRectangle2(row1, col1, 0, 5, 5);
					break;
				case 1:
					window.DispRectangle2(midR, midC, 0, 5, 5);
					break;
			}
		}

		/// <summary>Gets the HALCON region described by the ROI</summary>
		public override HRegion getRegion()
		{
			HRegion region = new HRegion();
			region.GenCircle(midR, midC, radius);
			return region;
		}

		public override double getDistanceFromStartPoint(double row, double col)
		{
			double sRow = midR; // assumption: we have an angle starting at 0.0
			double sCol = midC + 1 * radius;

			double angle = HMisc.AngleLl(midR, midC, sRow, sCol, midR, midC, row, col);

			if (angle < 0)
				angle += 2 * Math.PI;

			return (radius * angle);
		}

		/// <summary>
		/// Gets the model information described by 
		/// the  ROI
		/// </summary> 
		public override HTuple getModelData()
		{
			return new HTuple(new double[] { midR, midC, radius });
		}

        public override HTuple getModelDataName()
        {
            return new HTuple(new string[] { "中心行", "中心列", "半径" });
        }

        /// <summary> 
        /// Recalculates the shape of the ROI. Translation is 
        /// performed at the active handle of the ROI object 
        /// for the image coordinate (x,y)
        /// </summary>
        public override void moveByHandle(double newX, double newY)
		{
			HTuple distance;
			double shiftX,shiftY;

			switch (activeHandleIdx)
			{
				case 0: // handle at circle border

					row1 = newY;
					col1 = newX;
					HOperatorSet.DistancePp(new HTuple(row1), new HTuple(col1),
											new HTuple(midR), new HTuple(midC),
											out distance);

					radius = distance[0].D;
					break;
				case 1: // midpoint 

					shiftY = midR - newY;
					shiftX = midC - newX;

					midR = newY;
					midC = newX;

					row1 -= shiftY;
					col1 -= shiftX;
					break;
			}
		}
	}//end of class
}//end of namespace
