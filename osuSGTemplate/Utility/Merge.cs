using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osuSGTemplate.Basic;
using osuSGTemplate.FileManagement;
using System.IO;

namespace osuSGTemplate.Utility
{
    class Merge
    {
        private string secondLocation;
        private List<string> foreground2 = new List<string>();
        private List<string> background2 = new List<string>();
        private List<string> pass2 = new List<string>();
        private List<string> fail2 = new List<string>();

        public Merge(string s)
        {
            secondLocation = s;
            DivideIntoList();
        }

        private void DivideIntoList()
        {
            string[] lines = File.ReadAllLines(secondLocation);
            int l = -1;
            List<string> buffer = new List<string>();
            foreach (string line in lines)
            {
                if (line.Contains("//"))
                {
                    AddToList(buffer, l);
                    buffer.Clear();
                    l++;
                }
                else
                {
                    buffer.Add(line);
                }
            }
        }

        private void AddToList(List<string> b, int type)
        {
            switch (type)
            {
                case 1:
                    Add(b, background2);
                    break;
                case 2:
                    Add(b, fail2);
                    break;
                case 3:
                    Add(b, pass2);
                    break;
                case 4:
                    Add(b, foreground2);
                    break;
            }
        }

        private void Add(List<string> b, List<string> x)
        {
            foreach(string line in b)
            {
                x.Add(line);
            }
        }

        public void Write(int type, StreamWriter writer)
        {
            switch (type)
            {
                case 0:
                    Write(writer, background2);
                    break;
                case 1:
                    Write(writer, fail2);
                    break;
                case 2:
                    Write(writer, pass2);
                    break;
                case 3:
                    Write(writer, foreground2);
                    break;
            }
        }

        public void Write(StreamWriter writer, List<string> x)
        {
            foreach(string s in x)
            {
                writer.WriteLine(s);
            }
        }
    }
}
