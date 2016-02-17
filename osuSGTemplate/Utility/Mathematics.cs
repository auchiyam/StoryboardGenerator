using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osuSGTemplate.Basic;

namespace osuSGTemplate.Utility
{
    class Mathematics
    {
        public static Sprite DrawPoint(Sprite img, double startTime, double angle, int xc, int yc, int radius)
        {
            Sprite spr = img;
            int x = (int)(radius * Math.Cos(angle * (Math.PI / 180.0))) + xc;
            int y = (int)(radius * Math.Sin(angle * (Math.PI / 180.0))) + yc;
            spr.Move(startTime, x, y);
            return spr;
        }

        public static Sprite ExpandPoint(Sprite img, int ease, double startTime, double endTime, int angle, int xc, int yc, int radius1, int radius2)
        {
            Sprite spr = img;
            int x1 = (int)(radius1 * Math.Cos(angle * (Math.PI / 180.0))) + xc;
            int y1 = (int)(radius1 * Math.Sin(angle * (Math.PI / 180.0))) + yc;
            int x2 = (int)(radius2 * Math.Cos(angle * (Math.PI / 180.0))) + xc;
            int y2 = (int)(radius2 * Math.Sin(angle * (Math.PI / 180.0))) + yc;
            spr.Move(ease, startTime, endTime, x1, y1, x2, y2);
            return spr;
        }

        public static Sprite MovePoint(Sprite img, int ease, double startTime, double endTime, int angle1, int angle2, int xc, int yc, int radius)
        {
            Sprite spr = img;
            int x1 = (int)(radius * Math.Cos(angle1 * (Math.PI / 180.0))) + xc;
            int y1 = (int)(radius * Math.Sin(angle1 * (Math.PI / 180.0))) + yc;
            int x2 = (int)(radius * Math.Cos(angle2 * (Math.PI / 180.0))) + xc;
            int y2 = (int)(radius * Math.Sin(angle2 * (Math.PI / 180.0))) + yc;
            spr.Move(ease, startTime, endTime, x1, y1, x2, y2);
            return spr;
        }

        public static void MoveCircular(Sprite light, double startTime, double endTime, int startAngle, int endAngle, int radius, int x, int y)
        {
            MoveCircular(light, startTime, endTime, startAngle, endAngle, radius, x, y, x, y, 30, false);
        }

        public static void MoveCircular(Sprite light, double startTime, double endTime, int startAngle, int endAngle, int radius, int x, int y, bool rotate)
        {
            MoveCircular(light, startTime, endTime, startAngle, endAngle, radius, x, y, x, y, 30, false);
        }

        public static void MoveCircular(Sprite light, double startTime, double endTime, int startAngle, int endAngle, int radius, int x, int y, int accuracy)
        {
            MoveCircular(light, startTime, endTime, startAngle, endAngle, radius, x, y, x, y, accuracy, false);
        }

        public static void MoveCircular(Sprite light, double startTime, double endTime, int startAngle, int endAngle, int radius, int x, int y, int accuracy, bool rotate)
        {
            MoveCircular(light, startTime, endTime, startAngle, endAngle, radius, x, y, x, y, accuracy, rotate);
        }

        public static void MoveCircular(Sprite light, double startTime, double endTime, int startAngle, int endAngle, int radius, int originStartX, int originStartY, int originEndX, int originEndY)
        {
            MoveCircular(light, startTime, endTime, startAngle, endAngle, radius, originStartX, originStartY, originEndX, originEndY, 30, false);
        }

        public static void MoveCircular(Sprite light, double startTime, double endTime, int startAngle, int endAngle, int radius, int originStartX, int originStartY, int originEndX, int originEndY, int accuracy)
        {
            MoveCircular(light, startTime, endTime, startAngle, endAngle, radius, originStartX, originStartY, originEndX, originEndY, accuracy, false);
        }

        public static void MoveCircular(Sprite light, double startTime, double endTime, int startAngle, int endAngle, int radius, int originStartX, int originStartY, int originEndX, int originEndY, bool rotate)
        {
            MoveCircular(light, startTime, endTime, startAngle, endAngle, radius, originStartX, originStartY, originEndX, originEndY, 30, rotate);
        }

        public static void MoveCircular(Sprite light, double startTime, double endTime, int startAngle, int endAngle, int radius, int originStartX, int originStartY, int originEndX, int originEndY, int accuracy, bool rotate)
        {
            double originX = originStartX;
            double originY = originStartY;
            double offsetx = ((originStartX - originEndX) / ((endTime - startTime) / accuracy));
            double offsety = ((originStartY - originEndY) / ((endTime - startTime) / accuracy));
    
            double currAngle = startAngle;
            double incAngle = (endAngle - startAngle) / ((endTime - startTime) / accuracy);

            double rotAngle = startAngle * -1;
            double decAngle = (endAngle - startAngle) / ((endTime - startTime) / accuracy);
    
            for (double j = startTime; j < endTime; j += accuracy)
            {
                MoveCurve(light, j, j + accuracy, (int)currAngle, (int)(currAngle + incAngle), (int)originX, (int)originY, offsetx, offsety, radius);
                if (rotate)
                {
                    light.Rotate(j, j + accuracy, rotAngle, rotAngle - decAngle);
                }
                currAngle = currAngle + incAngle;
                rotAngle = rotAngle - decAngle;
                originX = originX - offsetx;
                originY = originY - offsety;            
            }
        }

        public static void MoveCurve(Sprite light, double startTime, double endTime, int angle1, int angle2, int xc, int yc, double offsetx, double offsety, int radius)
        {
            var radangle1 = angle1 * (Math.PI / 180.0);
            var radangle2 = angle2 * (Math.PI / 180.0);
            int x1 = (int)(radius * Math.Sin(radangle1 - Math.PI / 2) + xc);
            int y1 = (int)(radius * Math.Sin(radangle1) + yc);
            int x2 = (int)(radius * Math.Sin(radangle2 - Math.PI / 2) + xc - offsetx);
            int y2 = (int)(radius * Math.Sin(radangle2) + yc - offsety);
            light.Move(startTime, endTime, x1, y1, x2, y2);
        }

        public static Sprite DrawLines(double startTime, double length, double width)
        {
            Sprite line = DrawLines(startTime, length, width, Sprite.layer.Foreground, Sprite.origin.Centre);
            return line;
        }
        public static Sprite DrawLines(double startTime, double length, double width, Sprite.layer layer)
        {
            Sprite line = DrawLines(startTime, length, width, layer, Sprite.origin.Centre);
            return line;
        }
        public static Sprite DrawLines(double startTime, double length, double width, Sprite.origin origin)
        {
            Sprite line = DrawLines(startTime, length, width, Sprite.layer.Foreground, origin);
            return line;
        }
        public static Sprite DrawLines(double startTime, double length, double width, Sprite.layer layer, Sprite.origin origin)
        {
            Sprite line = new Sprite(@"sb\etc\line.png", layer, origin);
            ScaleLines(line, 0, startTime, startTime, length, width);
            return line;
        }
        public static void ScaleLines(Sprite line, int ease, double startTime, double endTime, double length, double width)
        {
            double scaleX = length / 9.0;
            double scaleY = width / 9.0;
            line.Vector(ease, startTime, endTime, line.GetScaleX(), line.GetScaleY(), scaleX, scaleY);
        }
    }
}
