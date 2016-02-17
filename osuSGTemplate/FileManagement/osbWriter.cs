using osuSGTemplate.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osuSGTemplate.Utility;
using System.IO;

namespace osuSGTemplate.FileManagement
{
    public delegate void ProgressEventHandler(object sender, EventArgs e);
    class osbWriter
    {
        public event ProgressEventHandler Prog;
        private string location;
        private string[] dupe;
        public int current;

        public osbWriter(string[] l)
        {
            location = l[0];
            dupe = l;
        }
        public osbWriter(string l, int total)
        {
            //Finds the .osu in the song folder and creates .osb file according to the metadata... 
            //but since it had a lot of problems in extractor a while ago, I decided to just scrap it.  
            //Not going to completely delete because waste
            //string osbName = findOsbName(l);
            location = l;
            EventListener eventListener = new EventListener(this, total);
        }
        public void Write(List<Sprite> foreground, List<Sprite> background, List<Sprite> pass, List<Sprite> fail)
        {
            current = 0;
            StreamWriter writer = new StreamWriter(location);
            writer.WriteLine("[Events]");
            writer.WriteLine("//Background and Video Events");
            writer.WriteLine("//Storyboard Layer 0 (Background)");

            List<Merge> m = new List<Merge>();
            for (int i = 1; i < dupe.Length; i++)
            {
                Merge d = new Merge(dupe[i]);
                m.Add(d);
            }
            foreach (Sprite sprite in background)
            {
                foreach (string action in sprite.GetActionList())
                {
                    writer.WriteLine(action);
                }
            }            
            foreach(Merge d in m)
            {
                d.Write(0, writer);
            }

            writer.WriteLine("//Storyboard Layer 1 (Fail)");

            foreach (Merge d in m)
            {
                d.Write(1, writer);
            }

            foreach (Sprite sprite in fail)
            {
                foreach (string action in sprite.GetActionList())
                {
                    writer.WriteLine(action);
                }
            }

            writer.WriteLine("//Storyboard Layer 2 (Pass)");

            foreach (Merge d in m)
            {
                d.Write(2, writer);
            }

            foreach (Sprite sprite in pass)
            {
                foreach (string action in sprite.GetActionList())
                {
                    writer.WriteLine(action);
                }
            }

            writer.WriteLine("//Storyboard Layer 3 (Foreground)");

            foreach (Merge d in m)
            {
                d.Write(3, writer);
            }

            foreach (Sprite sprite in foreground)
            {
                foreach (string action in sprite.GetActionList())
                {
                    writer.WriteLine(action);
                }
            }
            writer.WriteLine("//Storyboard Sound Samples");
            writer.Dispose();
        }

        public void Progress()
        {
            current++;
            if (Prog != null)
                Prog(this, EventArgs.Empty);
        }

        /*private string findOsbName(String location)
        {
            string osbTitle;
            string[] files = Directory.GetFiles(location);
            string[] osuText = { "null" };
            foreach (string file in files)
            {
                if (file.Substring(file.Length - ".osu".Length).Equals(".osu"))
                {
                    osuText = File.ReadAllLines(file);
                }
            }
            if (osuText[0].Equals("null"))
            {
                throw new InvalidDataException();
            }
            else
            {
                osbTitle = findTitle(osuText);
            }
            return osbTitle;
        }

        private string findTitle(string[] osuText)
        {
            string osbTitle = "";
            string title = "";
            string artist = "";
            string creator = "";
            foreach (string text in osuText)
            {
                if (text.Contains("Title:"))
                {
                    title = text.Substring("Title:".Length);
                }
                if (text.Contains("Artist:"))
                {
                    artist = text.Substring("Artist:".Length);
                }
                if (text.Contains("Creator:"))
                {
                    creator = text.Substring("Creator:".Length);
                }
            }
            osbTitle = string.Format("{0} - {1} ({2})", artist, title, creator);
            return osbTitle;
        }
         */
    }
}
