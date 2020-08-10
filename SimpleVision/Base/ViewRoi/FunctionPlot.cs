using System;
using System.Drawing;
using System.Windows.Forms;
using HalconDotNet;


namespace ViewROI
{
    /// <summary>
    /// This class allows you to print a function into a Windows.Forms.Control.
    /// The function must be supplied as an array of either double, float or
    /// int values. When initializing the class you must provide the control that 
    /// actually draws the function plot. During the initialization you 
    /// can also decide whether the mouse event is used to return the (x,y) 
    /// coordinates of the plotted function. The scaling 
    /// of the x-y axis is performed automatically and depent on the length 
    /// of the function as well as the settings for the y-axis scaling: 
    ///     * AXIS_RANGE_FIXED
    ///     * AXIS_RANGE_INCREASING
    ///     * AXIS_RANGE_ADAPTING 
    /// 
    /// Constraints of the function plot class:
    /// So far only functions containing a positive range of y-values can
    /// be plotted correctly. Also only a positive and ascending x-range
    /// can be plotted. The origin of the coordinate system is set to
    /// be in the lower left corner of the control. Another definition 
    /// of the origin and hence the direction of the coordinate axis 
    /// is not implemented yet. 
    /// </summary>
    public class FunctionPlot
	{
		// panels for display
		private Graphics gPanel, backBuffer;

		// graphical settings
		private Pen          pen, penCurve, penCursor;
		private SolidBrush   brushCS, brushFuncPanel;
		private Font         drawFont;
		private StringFormat format;
		private Bitmap       functionMap;

		// dimensions of panels 
		private float panelWidth;
		private float panelHeight;
		private float margin;

		// origin
		private float originX;
		private float originY;

		private PointF[]    points;
		private HFunction1D func;

		// axis 
		private int   axisAdaption;
		private float axisXLength;
		private float axisYLength;
		private float scaleX, scaleY;

		public const int AXIS_RANGE_FIXED       = 3;
		public const int AXIS_RANGE_INCREASING  = 4;
		public const int AXIS_RANGE_ADAPTING    = 5;

		int PreX, BorderRight, BorderTop;


		/// <summary>
		/// Initializes a FunctionPlot instance by providing a GUI control
		/// and a flag specifying the mouse interaction mode.
		/// The control is used to determine the available space to draw
		/// the axes and to plot the supplied functions. Depending on the
		/// available space, the values of the function as well as the axis
		/// steps are adjusted (scaled) to fit into the visible part of the 
		/// control.
		/// </summary>
		/// <param name="panel">
		/// An instance of the Windows.Forms.Control to plot the 
		/// supplied functions in
		/// </param>
		/// <param name="useMouseHandle">
		/// Flag that specifies whether or not mouse interaction should
		/// be used to create a navigation bar for the plotted function 
		/// </param>
		public FunctionPlot(Control panel, bool useMouseHandle)
		{
			gPanel = panel.CreateGraphics();

			panelWidth = panel.Size.Width - 32;
			panelHeight = panel.Size.Height - 22;

			originX = 32;
			originY = panel.Size.Height - 22;
			margin = 5.0f;

			BorderRight = (int)(panelWidth + originX - margin);
			BorderTop = (int)panelHeight;

			PreX = 0;
			scaleX = scaleY = 0.0f;


			//default setting for axis scaling
			axisAdaption = AXIS_RANGE_ADAPTING;
			axisXLength = 10.0f;
			axisYLength = 10.0f;

			pen = new Pen(System.Drawing.Color.DarkGray, 1);
			penCurve = new Pen(System.Drawing.Color.Blue, 1);
			penCursor = new Pen(System.Drawing.Color.LightSteelBlue, 1);
			penCursor.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

			brushCS = new SolidBrush(Color.Black);
			brushFuncPanel = new SolidBrush(Color.White);
			drawFont = new Font("Arial", 6);
			format = new StringFormat();
			format.Alignment = StringAlignment.Far;

			functionMap = new Bitmap(panel.Size.Width, panel.Size.Height);
			backBuffer = Graphics.FromImage(functionMap);
			resetPlot();

			panel.Paint += new System.Windows.Forms.PaintEventHandler(this.paint);

			if (useMouseHandle)
				panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMoved);
		}

		/// <summary>
		/// Convenience method for constructor call. For this case the 
		/// useMouseHandle flag is set to false by default.
		/// </summary>
		/// <param name="panel">
		/// An instance of the Windows.Forms.Control to plot the 
		/// supplied function in.
		/// </param>
		public FunctionPlot(Control panel)
			: this(panel, false)
		{
		}


		/// <summary>
		/// Changes the origin of the coordinate system to be 
		/// at the control positions x and y.
		/// </summary>
		/// <param name="x">
		/// X position within the control coordinate system
		/// </param>
		/// <param name="y">
		/// Y position within the control coordinate system. 
		/// </param>
		public void setOrigin(int x, int y)
		{
			float tmpX;

			if (x < 1 || y < 1)
				return;

			tmpX = originX;
			originX = x;
			originY = y;

			panelWidth = panelWidth + tmpX - originX;
			panelHeight = originY;
			BorderRight = (int)(panelWidth + originX - margin);
			BorderTop = (int)panelHeight;
		}


		/// <summary>
		/// Sets the type of scaling for the y-axis. If the 
		/// y-axis is defined to be of fixed size, then the upper 
		/// limit has to be provided with val. Otherwise,
		/// an 8-bit image is assumed, so the fixed size is set
		/// to be 255.
		/// </summary>
		/// <param name="mode">
		/// Class constant starting with AXIS_RANGE_*
		/// </param>
		/// <param name="val">
		/// For the mode AXIS_RANGE_FIXED the value 
		/// val must be positive, otherwise
		/// it has no meaning.
		/// </param>
		public void setAxisAdaption(int mode, float val)
		{
			switch (mode)
			{
				case AXIS_RANGE_FIXED:
					axisAdaption = mode;
					axisYLength = (val > 0) ? val : 255.0f;
					break;
				default:
					axisAdaption = mode;
					break;
			}
		}

		public void setAxisAdaption(int mode)
		{
			setAxisAdaption(mode, -1.0f);
		}


		/// <summary>
		/// Plots a function of double values.
		/// </summary>
		/// <param name="grayValues">
		/// Y-values defined as an array of doubles
		/// </param>
		public void plotFunction(double[] grayValues)
		{
			drawFunction(new HTuple(grayValues));
		}


		/// <summary>
		/// Plots a function of float values.
		/// </summary>
		/// <param name="grayValues">
		/// Y-values defined as an array of floats
		/// </param>
		public void plotFunction(float[] grayValues)
		{
			drawFunction(new HTuple(grayValues));
		}


		/// <summary>
		/// Plots a function of integer values.
		/// </summary>
		/// <param name="grayValues">
		/// Y-values defined as an array of integers
		/// </param>
		public void plotFunction(int[] grayValues)
		{
			drawFunction(new HTuple(grayValues));
		}


		/// <summary>Plots a function provided as an HTuple</summary>
		private void drawFunction(HTuple tuple)
		{
			HTuple val;
			int maxY,maxX;
			float stepOffset;

			if (tuple.Length == 0)
			{
				resetPlot();
				return;
			}

			val = tuple.TupleSortIndex();
			maxX = tuple.Length - 1;
			maxY = (int)tuple[val[val.Length - 1].I].D;

			axisXLength = maxX;

			switch (axisAdaption)
			{
				case AXIS_RANGE_ADAPTING:
					axisYLength = maxY;
					break;
				case AXIS_RANGE_INCREASING:
					axisYLength = (maxY > axisYLength) ? maxY : axisYLength;
					break;
			}

			backBuffer.Clear(System.Drawing.Color.WhiteSmoke);
			backBuffer.FillRectangle(brushFuncPanel, originX, 0, panelWidth, panelHeight);

			stepOffset = drawXYLabels();
			drawLineCurve(tuple, stepOffset);
			backBuffer.Flush();

			gPanel.DrawImageUnscaled(functionMap, 0, 0);
			gPanel.Flush();
		}


		/// <summary>
		/// Clears the panel and displays only the coordinate axes.
		/// </summary>
		public void resetPlot()
		{
			backBuffer.Clear(System.Drawing.Color.WhiteSmoke);
			backBuffer.FillRectangle(brushFuncPanel, originX, 0, panelWidth, panelHeight);
			func = null;
			drawXYLabels();
			backBuffer.Flush();
			repaint();
		}


		/// <summary>
		/// Puts (=flushes) the current content of the graphics object on screen 
		/// again.
		/// </summary>
		private void repaint()
		{
			gPanel.DrawImageUnscaled(functionMap, 0, 0);
			gPanel.Flush();
		}


		/// <summary>Plots the points of the function.</summary>
		private void drawLineCurve(HTuple tuple, float stepOffset)
		{
			int length;

			if (stepOffset > 1)
				points = scaleDispValue(tuple);
			else
				points = scaleDispBlockValue(tuple);

			length = points.Length;

			func = new HFunction1D(tuple);

			for (int i = 0; i < length - 1; i++)
				backBuffer.DrawLine(penCurve, points[i], points[i + 1]);

		}


		/// <summary>
		/// Scales the function to the dimension of the graphics object 
		/// (provided by the control). 
		/// </summary>
		/// <param name="tup">
		/// Function defined as a tuple of y-values
		/// </param>
		/// <returns>
		/// Array of PointF values, containing the scaled function data
		/// </returns>
		private PointF[] scaleDispValue(HTuple tup)
		{
			PointF [] pVals;
			float  xMax, yMax, yV, x, y;
			int length;

			xMax = axisXLength;
			yMax = axisYLength;

			scaleX = (xMax != 0.0f) ? ((panelWidth - margin) / xMax) : 0.0f;
			scaleY = (yMax != 0.0f) ? ((panelHeight - margin) / yMax) : 0.0f;

			length = tup.Length;
			pVals = new PointF[length];

			for (int j=0; j < length; j++)
			{
				yV = (float)tup[j].D;
				x = originX + (float)j * scaleX;
				y = panelHeight - (yV * scaleY);
				pVals[j] = new PointF(x, y);
			}

			return pVals;
		}


		/// <summary>
		/// Scales the function to the dimension of the graphics object 
		/// (provided by the control). If the stepsize  for the x-axis is
		/// 1, the points are scaled in a block shape.
		/// </summary>
		/// <param name="tup">
		/// Function defined as a tuple of y-values 
		/// </param>
		/// <returns>
		/// Array of PointF values, containing the scaled function data
		/// </returns>
		private PointF[] scaleDispBlockValue(HTuple tup)
		{
			PointF [] pVals;
			float  xMax, yMax, yV,x,y;
			int length, idx;

			xMax = axisXLength;
			yMax = axisYLength;

			scaleX = (xMax != 0.0f) ? ((panelWidth - margin) / xMax) : 0.0f;
			scaleY = (yMax != 0.0f) ? ((panelHeight - margin) / yMax) : 0.0f;

			length = tup.Length;
			pVals = new PointF[length * 2];

			y = 0;
			idx = 0;

			for (int j=0; j < length; j++)
			{
				yV = (float)tup[j].D;
				x = originX + (float)j * scaleX - (scaleX / 2.0f);
				y = panelHeight - (yV * scaleY);
				pVals[idx] = new PointF(x, y);
				idx++;

				x = originX + (float)j * scaleX + (scaleX / 2.0f);
				pVals[idx] = new PointF(x, y);
				idx++;
			}

			//trim the end points of the curve
			idx--;
			x = originX + (float)(length - 1) * scaleX;
			pVals[idx] = new PointF(x, y);

			idx = 0;
			yV = (float)tup[idx].D;
			x = originX;
			y = panelHeight - (yV * scaleY);
			pVals[idx] = new PointF(x, y);

			return pVals;
		}


		/// <summary>Draws x- and y-axis and its labels.</summary>
		/// <returns>Step size used for the x-axis</returns>
		private float drawXYLabels()
		{
			float pX,pY,length, XStart,YStart;
			float YCoord, XCoord, XEnd, YEnd, offset, offsetString, offsetStep;
			float scale = 0.0f;

			offsetString = 5;
			XStart = originX;
			YStart = originY;

			//prepare scale data for x-axis
			pX = axisXLength;
			if (pX != 0.0)
				scale = (panelWidth - margin) / pX;

			if (scale > 10.0)
				offset = 1.0f;
			else if (scale > 2)
				offset = 10.0f;
			else if (scale > 0.2)
				offset = 100.0f;
			else
				offset = 1000.0f;


			/***************   draw X-Axis   ***************/
			XCoord = 0.0f;
			YCoord = YStart;
			XEnd = (scale * pX);

			backBuffer.DrawLine(pen, XStart, YStart, XStart + panelWidth - margin, YStart);
			backBuffer.DrawLine(pen, XStart + XCoord, YCoord, XStart + XCoord, YCoord + 6);
			backBuffer.DrawString(0 + "", drawFont, brushCS, XStart + XCoord + 4, YCoord + 8, format);
			backBuffer.DrawLine(pen, XStart + XEnd, YCoord, XStart + XEnd, YCoord + 6);
			backBuffer.DrawString(((int)pX + ""), drawFont, brushCS, XStart + XEnd + 4, YCoord + 8, format);

			length = (int)(pX / offset);
			length = (offset == 10) ? length - 1 : length;
			for (int i=1; i <= length; i++)
			{
				XCoord = (float)(offset * i * scale);

				if ((XEnd - XCoord) < 20)
					continue;

				backBuffer.DrawLine(pen, XStart + XCoord, YCoord, XStart + XCoord, YCoord + 6);
				backBuffer.DrawString(((int)(i * offset) + ""), drawFont, brushCS, XStart + XCoord + 5, YCoord + 8, format);
			}

			offsetStep = offset;

			//prepare scale data for y-axis
			pY = axisYLength;
			if (pY != 0.0)
				scale = ((panelHeight - margin) / pY);

			if (scale > 10.0)
				offset = 1.0f;
			else if (scale > 2)
				offset = 10.0f;
			else if (scale > 0.8)
				offset = 50.0f;
			else if (scale > 0.12)
				offset = 100.0f;
			else
				offset = 1000.0f;

			/***************    draw Y-Axis   ***************/
			XCoord = XStart;
			YCoord = 5.0f;
			YEnd = YStart - (scale * pY);

			backBuffer.DrawLine(pen, XStart, YStart, XStart, YStart - (panelHeight - margin));
			backBuffer.DrawLine(pen, XCoord, YStart, XCoord - 10, YStart);
			backBuffer.DrawString(0 + "", drawFont, brushCS, XCoord - 12, YStart - offsetString, format);
			backBuffer.DrawLine(pen, XCoord, YEnd, XCoord - 10, YEnd);
			backBuffer.DrawString(pY + "", drawFont, brushCS, XCoord - 12, YEnd - offsetString, format);

			length = (int)(pY / offset);
			length = (offset == 10) ? length - 1 : length;
			for (int i=1; i <= length; i++)
			{
				YCoord = (YStart - ((float)offset * i * scale));

				if ((YCoord - YEnd) < 10)
					continue;

				backBuffer.DrawLine(pen, XCoord, YCoord, XCoord - 10, YCoord);
				backBuffer.DrawString(((int)(i * offset) + ""), drawFont, brushCS, XCoord - 12, YCoord - offsetString, format);
			}

			return offsetStep;
		}


		/// <summary>
		/// Action call for the Mouse-Move event. For the x-coordinate
		/// supplied by the MouseEvent, the unscaled x and y coordinates
		/// of the plotted function are determined and displayed 
		/// on the control.
		/// </summary>
		private void mouseMoved(object sender, MouseEventArgs e)
		{
			int Xh, Xc;
			HTuple Ytup;
			float Yh, Yc;

			Xh = e.X;

			if (PreX == Xh || Xh < originX || Xh > BorderRight || func == null)
				return;

			PreX = Xh;

			Xc = (int)Math.Round((Xh - originX) / scaleX);
			Ytup = func.GetYValueFunct1d(new HTuple(Xc), "zero");

			Yc = (float)Ytup[0].D;
			Yh = panelHeight - (Yc * scaleY);

			gPanel.DrawImageUnscaled(functionMap, 0, 0);
			gPanel.DrawLine(penCursor, Xh, 0, Xh, BorderTop);
			gPanel.DrawLine(penCursor, originX, Yh, BorderRight + margin, Yh);
			gPanel.DrawString(("X = " + Xc), drawFont, brushCS, panelWidth - margin, 10);
			gPanel.DrawString(("Y = " + (int)Yc), drawFont, brushCS, panelWidth - margin, 20);
			gPanel.Flush();
		}


		/// <summary>
		/// Action call for the Paint event of the control to trigger the
		/// repainting of the function plot. 
		/// </summary>
		private void paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			repaint();
		}

	}//end of class
}//end of namespace
