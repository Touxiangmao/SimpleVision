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
    public class ROIPoint : ROI, RoiInterfac
    {

		private double midR, midC;  // second handle


		public ROIPoint()
		{
            RoiType = GetType().ToString();
            NumHandles = 1; // one midpoint
			activeHandleIdx = 0;
		}

        public ROIPoint(string Name)
        {
            RoiName = Name;
            RoiType = GetType().ToString();
            NumHandles = 1; // one midpoint
            activeHandleIdx = 0;
        }

        /// <summary>Creates a new ROI instance at the mouse position</summary>
        public override void createROI(double midX, double midY)
		{
			midR = midY;
			midC = midX;

		}


        public override void createROI(HTuple RoiParameters)
        {

            //return new HTuple(new double[] { midR, midC, radius });

            midR = RoiParameters[0];
            midC = RoiParameters[1];
        
        }


        /// <summary>Paints the ROI into the supplied window</summary>
        /// <param name="window">HALCON window</param>
        public override void draw(HalconDotNet.HWindow window)
		{
			
			window.DispCircle(midR, midC, 5);
            window.DispCross(midR, midC, 8, 0);
        
        }

		/// <summary> 
		/// Returns the distance of the ROI handle being
		/// closest to the image point(x,y)
		/// </summary>
		public override double distToClosestHandle(double x, double y)
		{
			double max = 10000;
			double [] val = new double[NumHandles];

		
			val[0] = HMisc.DistancePp(y, x, midR, midC); // midpoint 

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
                  
                  window.DispCircle(midR, midC, 5);
                  window.DispCross(midR, midC, 8, 0);
                    break;
			}
		}

		/// <summary>Gets the HALCON region described by the ROI</summary>
	

	

		/// <summary>
		/// Gets the model information described by 
		/// the  ROI
		/// </summary> 
		public override HTuple getModelData()
		{
			return new HTuple(new double[] { midR, midC });
		}

        public override HTuple getModelDataName()
        {
            return new HTuple(new string[] { "中心行", "中心列" });
        }

        /// <summary> 
        /// Recalculates the shape of the ROI. Translation is 
        /// performed at the active handle of the ROI object 
        /// for the image coordinate (x,y)
        /// </summary>
        public override void moveByHandle(double newX, double newY)
		{
		
			double shiftX,shiftY;

			switch (activeHandleIdx)
			{
				
				case 0: // midpoint 

					shiftY = midR - newY;
					shiftX = midC - newX;

					midR = newY;
					midC = newX;

					break;
			}
		}
	}//end of class
}//end of namespace
