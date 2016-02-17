using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osuSGTemplate.Basic
{
    class Animation : Sprite
    {
        private int frameCount, frameDelay;
        public enum loopType
        {
            LoopForever, LoopOnce
        }
        public Animation(String path, int frameCount, int frameDelay)
            : this(path, frameCount, frameDelay, layer.Foreground, origin.Centre, loopType.LoopForever) { }
        public Animation(String path, int frameCount, int frameDelay, loopType loopType)
            : this(path, frameCount, frameDelay, layer.Foreground, origin.Centre, loopType) { }
        public Animation(String path, int frameCount, int frameDelay, layer layer)
            : this(path, frameCount, frameDelay, layer, origin.Centre, loopType.LoopForever) { }
        public Animation(String path, int frameCount, int frameDelay, layer layer, loopType loopType)
            : this(path, frameCount, frameDelay, layer, origin.Centre, loopType) { }
        public Animation(String path, int frameCount, int frameDelay, origin origin)
            : this(path, frameCount, frameDelay, layer.Foreground, origin, loopType.LoopForever) { }
        public Animation(String path, int frameCount, int frameDelay, origin origin, loopType loopType)
            : this(path, frameCount, frameDelay, layer.Foreground, origin, loopType) { }
        public Animation(String path, int frameCount, int frameDelay, layer layer, origin origin)
            : this(path, frameCount, frameDelay, layer, origin, loopType.LoopForever) { }
        public Animation(String path, int frameCount, int frameDelay, layer layer, origin origin, loopType loopType)
        {
            layers = 0;
            currentX = 320;
            currentY = 240;
            currentAngle = 0;
            totalCode = 0;
            this.frameCount = frameCount;
            this.frameDelay = frameDelay;
            Add(string.Format("Animation,{0},{1},\"{2}\",320,240,{3},{4},{5}", layer, origin, path, frameCount, frameDelay, loopType));
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
        public int GetFrameCount()
        {
            return frameCount;
        }
        public int GetFrameDelay()
        {
            return frameDelay;
        }

    }
}
