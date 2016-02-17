using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osuSGTemplate.FileManagement;

namespace osuSGTemplate.Basic
{
    class Sprite
    {
        //Variables
        public double currentX, currentY, currentAngle, currentR, currentG, currentB;
        public double currentScale, currentScaleX, currentScaleY, currentOpacity;
        protected int layers;
        protected List<String> action = new List<String>();
        protected int totalCode;
        protected string path;
        protected Sprite.layer l;
        protected Sprite.origin o; 
        // Enum stuff
        public enum layer
        {
            Foreground, Background, Pass, Fail
        };
        public enum origin
        {
            TopLeft, TopCentre, TopRight,
            CentreLeft, Centre, CentreRight,
            BottomLeft, BottomCentre, BottomRight
        };
        public enum trigger
        {
            HitSoundClap, HitSoundFinish, HitSountWhistle,
            Passing, Failing
        };
        // Constructors
        public Sprite(Sprite copy)
        {
            layers = copy.layers;
            currentX = copy.currentX;
            currentY = copy.currentY;
            currentAngle = copy.currentAngle;
            currentR = copy.currentR;
            currentG = copy.currentG;
            currentB = copy.currentB;
            totalCode = copy.totalCode;
            path = copy.path;
            action = copy.GetActionList();
            l = copy.l;
            o = copy.o;

            switch (l)
            {
                case (layer.Foreground):
                    ControlClass.foreground.Add(this);
                    break;
                case (layer.Background):
                    ControlClass.background.Add(this);
                    break;
                case (layer.Pass):
                    ControlClass.pass.Add(this);
                    break;
                case (layer.Fail):
                    ControlClass.fail.Add(this);
                    break;
            }
        }

        public Sprite() { }
        public Sprite(String path)
            : this(path, layer.Foreground, origin.Centre) { }
        public Sprite(String path, layer layer)
            : this(path, layer, origin.Centre) { }
        public Sprite(String path, origin origin)
            : this(path, layer.Foreground, origin) { }
        public Sprite(String path, layer layer, origin origin)
        {
            layers = 0;
            currentX = 320;
            currentY = 240;

            currentOpacity = 1;

            currentScale = 1;

            currentScaleX = 1;
            currentScaleY = 1;

            currentAngle = 0;

            currentR = 255;
            currentG = 255;
            currentB = 255;

            totalCode = 0;
            this.path = path;

            Add(string.Format("Sprite,{0},{1},\"{2}\",320,240", layer, origin, path));
            layers++;
            switch (layer)
            {
                case (layer.Foreground):
                    ControlClass.foreground.Add(this);
                    break;
                case (layer.Background):
                    ControlClass.background.Add(this);
                    break;
                case (layer.Pass):
                    ControlClass.pass.Add(this);
                    break;
                case (layer.Fail):
                    ControlClass.fail.Add(this);
                    break;
            }
        }



        //Move
        public void Move(int x, int y)
        {
            Move(0, 0, 0, x, y, x, y);
        }
        public void Move(double startTime, int x, int y)
        {
            Move(0, startTime, startTime, x, y, x, y);
        }
        public void Move(double startTime, double endTime, int startX, int startY, int endX, int endY)
        {
            Move(0, startTime, endTime, startX, startY, endX, endY);
        }
        public void Move(int ease, double startTime, double endTime, int startX, int startY, int endX, int endY)
        {
            MoveX(ease, startTime, endTime, startX, endX);
            MoveY(ease, startTime, endTime, startY, endY);
        }

        //Fade
        public void Fade(double opacity)
        {
            Fade(0, 0, 0, opacity, opacity);
        }
        public void Fade(double startTime, double opacity)
        {
            Fade(0, startTime, startTime, opacity, opacity);
        }
        public void Fade(double startTime, double endTime, double startOpacity, double endOpacity)
        {
            Fade(0, startTime, endTime, startOpacity, endOpacity);
        }
        public void Fade(int ease, double startTime, double endTime, double startOpacity, double endOpacity)
        {
            string endT = ((int)endTime).ToString();
            if (startTime == endTime)
            {
                endT = "";
            }
            if (startOpacity == endOpacity)
            {
                Add(string.Format("F,{0},{1},{2},{3}", ease, (int)startTime, endT, startOpacity));
            }
            else
            {
                Add(string.Format("F,{0},{1},{2},{3},{4}", ease, (int)startTime, endT, startOpacity, endOpacity));
            }
            currentOpacity = endOpacity;
        }

        //Rotate
        public void Rotate(double angle)
        {
            Rotate(0, 0, 0, angle, angle);
        }
        public void Rotate(double startTime, double angle)
        {
            Rotate(0, startTime, startTime, angle, angle);
        }
        public void Rotate(double startTime, double endTime, double startAngle, double endAngle)
        {
            Rotate(0, startTime, endTime, startAngle, endAngle);
        }
        public void Rotate(int ease, double startTime, double endTime, double startAngle, double endAngle)
        {
            startAngle = (startAngle * 3.14159) / 180;
            endAngle = (endAngle * 3.14159) / 180;
            string endT = ((int)endTime).ToString();
            if (startTime == endTime)
            {
                endT = "";
            }
            if (startAngle == endAngle)
            {
                Add(string.Format("R,{0},{1},{2},{3}", ease, (int)startTime, endT, startAngle));
            }
            else
            {
                Add(string.Format("R,{0},{1},{2},{3},{4}", ease, (int)startTime, endT, startAngle, endAngle));
                currentAngle = (int)endAngle;
            }
        }

        //Scale
        public void Scale(double scaleSize)
        {
            Scale(0, 0, 0, scaleSize, scaleSize);
        }
        public void Scale(double startTime, double scaleSize)
        {
            Scale(0, startTime, startTime, scaleSize, scaleSize);
        }
        public void Scale(double startTime, double endTime, double startScale, double endScale)
        {
            Scale(0, startTime, endTime, startScale, endScale);
        }
        public void Scale(int ease, double startTime, double endTime, double startScale, double endScale)
        {
            string endT = ((int)endTime).ToString();
            if (startTime == endTime)
            {
                endT = "";
            }
            if (startScale == endScale)
            {
                Add(string.Format("S,{0},{1},{2},{3}", ease, (int)startTime, endT, startScale));
            }
            else
            {
                Add(string.Format("S,{0},{1},{2},{3},{4}", ease, (int)startTime, endT, startScale, endScale));
            }
            currentScale = endScale;
        }

        //MoveX
        public void MoveX(int x)
        {
            MoveX(0, 0, 0, x, x);
        }
        public void MoveX(double startTime, int x)
        {
            MoveX(0, startTime, startTime, x, x);
        }
        public void MoveX(double startTime, double endTime, int startX, int endX)
        {
            MoveX(0, startTime, endTime, startX, endX);
        }
        public void MoveX(int ease, double startTime, double endTime, int startX, int endX)
        {
            string endT = ((int)endTime).ToString();
            if (startTime == endTime)
            {
                endT = "";
            }
            if (startX == endX)
            {
                Add(string.Format("MX,{0},{1},{2},{3}", ease, (int)startTime, endT, startX));
            }
            else
            {
                Add(string.Format("MX,{0},{1},{2},{3},{4}", ease, (int)startTime, endT, startX, endX));
            }
            currentX = endX;
        }

        //MoveY
        public void MoveY(double y)
        {
            MoveY(0, 0, 0, y, y);
        }
        public void MoveY(double startTime, double y)
        {
            MoveY   (0, startTime, startTime, y, y);
        }
        public void MoveY(double startTime, double endTime, double startY, double endY)
        {
            MoveY(0, startTime, endTime, startY, endY);
        }
        public void MoveY(int ease, double startTime, double endTime, double startY, double endY)
        {
            string endT = ((int)endTime).ToString();
            if (startTime == endTime)
            {
                endT = "";
            }
            if (startY == endY)
            {
                Add(string.Format("MY,{0},{1},{2},{3}", ease, (int)startTime, endT, startY));
            }
            else
            {
                Add(string.Format("MY,{0},{1},{2},{3},{4}", ease, (int)startTime, endT, startY, endY));
            }
            currentY = endY;
        }

        //Color
        public void Color(int r, int g, int b)
        {
            Color(0, 0, 0, r, g, b, r, g, b);
        }
        public void Color(double time, int r, int g, int b)
        {
            Color(0, time, time, r, g, b, r, g, b);
        }
        public void Color(double startTime, double endTime, int r1, int g1, int b1, int r2, int g2, int b2)
        {
            Color(0, startTime, endTime, r1, g1, b1, r2, g2, b2);
        }
        public void Color(int ease, double startTime, double endTime, int r1, int g1, int b1, int r2, int g2, int b2)
        {
            string endT = ((int)endTime).ToString();
            if (startTime == endTime)
            {
                endT = "";
            }
            if (r1 == r2 && g1 == g2 && b1 == b2)
            {
                Add(string.Format("C,{0},{1},{2},{3},{4},{5}", ease, (int)startTime, endT, r1, g1, b1));
                currentR = r1;
                currentG = g1;
                currentB = b1;
            }
            else
            {
                Add(string.Format("C,{0},{1},{2},{3},{4},{5},{6},{7},{8}", ease, (int)startTime, endTime, r1, g1, b1, r2, g2, b2));
                currentR = r2;
                currentG = g2;
                currentB = b2;
            }
        }

        public void Loop(double startTime, int loopcount)
        {
            Add(string.Format("L,{0},{1}", (int)startTime, loopcount));
            layers++;
        }
        public void Trigger(trigger trig, double startTime, int endTime)
        {
            Add(string.Format("T,{0},{1},{2}", trig, (int)startTime, endTime));
            layers++;
        }
        public void EndLoop()
        {
            if (layers >= 1)
                layers--;
        }
        public void Parameters(double startTime, double endTime, string parameter)
        {
            Parameters(0, startTime, endTime, parameter);
        }
        public void Parameters(int ease, double startTime, double endTime, string parameter)
        {
            Add(string.Format("P,{0},{1},{2},{3}", ease, (int)startTime, (int)endTime, parameter));
        }

        public void Vector(double scaleX, double scaleY)
        {
            Vector(0, 0, 0, scaleX, scaleY, scaleX, scaleY);
        }
        public void Vector(double startTime, double scaleX, double scaleY)
        {
            Vector(0, startTime, startTime, scaleX, scaleY, scaleX, scaleY);
        }
        public void Vector(double startTime, double endTime, double startScaleX, double startScaleY, double endScaleX, double endScaleY) 
        {
            Vector(0, startTime, endTime, startScaleX, startScaleY, endScaleX, endScaleY);
        }
        public void Vector(int ease, double startTime, double endTime, double startScaleX, double startScaleY, double endScaleX, double endScaleY)
        {
            Add(string.Format("V,{0},{1},{2},{3},{4},{5},{6}", ease, (int)startTime, (int)endTime, startScaleX, startScaleY, endScaleX, endScaleY));
            currentScaleX = endScaleX;
            currentScaleY = endScaleY;
        }

        public double GetX()
        {
            return currentX;
        }
        public double GetY()
        {
            return currentY;
        }
        public double GetAngle()
        {
            return currentAngle;
        }
        public double GetScale()
        {
            return currentScale;
        }
        public double GetScaleX()
        {
            return currentScaleX;
        }
        public double GetScaleY()
        {
            return currentScaleY;
        }
        public double GetColorR()
        {
            return currentR;
        }
        public double GetColorG()
        {
            return currentG;
        }
        public double GetColorB()
        {
            return currentB;
        }
        public List<String> GetActionList()
        {
            return action;
        }
        public int GetTotal()
        {
            return totalCode;
        }
        public double GetOpacity()
        {
            return currentOpacity;
        }
        public void Add(string act)
        {
            string act2 = "";
            for (int i = 0; i < layers; i++)
            {
                act2 += " ";
            }
            act2 += act;
            action.Add(act2);
            totalCode++;
        }

        public override string ToString()
        {
            return path;
        }

        public bool Equals(string path)
        {
            return this.path.Equals(path);
        }
        public Sprite Copy()
        {
            return this;
        }
    }
}
