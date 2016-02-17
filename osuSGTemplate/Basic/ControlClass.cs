using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using osuSGTemplate.FileManagement;

namespace osuSGTemplate.Basic
{

    class ControlClass
    {
        public static List<Sprite> foreground = new List<Sprite>();
        public static List<Sprite> background = new List<Sprite>();
        public static List<Sprite> pass = new List<Sprite>();
        public static List<Sprite> fail = new List<Sprite>();

        public void Run(params string[] loc)
        {
            osbWriter writer = new osbWriter(loc);
            writer.Write(foreground, background, pass, fail);
        }
    }
}
