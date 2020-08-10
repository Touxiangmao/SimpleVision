using HalconDotNet;

namespace SimpleVision.Base
{
    public class Templatelocation
    {
        public HTuple Row, Column, Angle;

    }
    public class LHimg
    {
        public HImage image;
        public Templatelocation Templatelocation;
    }
}