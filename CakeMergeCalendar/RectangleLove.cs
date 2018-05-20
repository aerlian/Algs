using System;
using System.Collections.Generic;
using System.Text;

namespace CakeMergeCalendar
{
    public class Rectangle
    {
        // Coordinates of bottom left corner
        public int LeftX { get; set; }
        public int BottomY { get; set; }

        // Dimensions
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle() { }

        public Rectangle(int leftX, int bottomY, int width, int height)
        {
            LeftX = leftX;
            BottomY = bottomY;
            Width = width;
            Height = height;
        }
    }

    class RectangleLove
    {
        public static void RectangleMain()
        {
            //var rc = Intersect(new Rectangle(1, 1, 6, 3), new Rectangle(5, 2, 3, 6));
            //var rc = Intersect(new Rectangle(0, 0, 1, 1), new Rectangle(0, 0, 2, 2));
            //var rc = Intersect(new Rectangle(0, 0, 2, 2), new Rectangle(1, 0, 2, 2));
            //var rc = Intersect(new Rectangle(0, 0, 1, 1), new Rectangle(2, 0, 1, 1));
            //var rc = Intersect(new Rectangle(0, 0, 2, 2), new Rectangle(1, 1, 1, 1));
            var rc = Intersect(new Rectangle(0, 0, 2, 2), new Rectangle(2, 0, 2, 2));
        }

        private static Rectangle Intersect(Rectangle a, Rectangle b)
        {
            var right = Math.Min(a.LeftX + a.Width, b.LeftX + b.Width);
            var left = Math.Max(a.LeftX, b.LeftX);

            if (left >= right)
            {
                return new Rectangle(0, 0, 0, 0);
            }

            var top = Math.Min(a.BottomY + a.Height, b.BottomY + b.Height);
            var bottom = Math.Max(a.BottomY, b.BottomY);

            if (bottom >= top)
            {
                return new Rectangle(0, 0, 0, 0);
            }


            //var maxRight = Math.Max(b.LeftX + b.Width, w.LeftX + w.Width);
            //var minLeft = Math.Min(b.LeftX, w.LeftX);

            //var maxHeight = Math.Max(b.BottomY + b.Height, w.BottomY + w.Height);
            //var minHeight = Math.Min(b.BottomY, w.BottomY);

            return new Rectangle(left, bottom, right - left, top - bottom);
        }
    }
}
