using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osuSGTemplate.FileManagement
{
    class EventListener
    {
        private osbWriter writer;
        private int total;
        private int currentPercent;
        public EventListener(osbWriter w, int total)
        {
            writer = w;
            this.total = total;
            w.Prog += new ProgressEventHandler(Update);
            currentPercent = 0;
        }

        public void Update(object sender, EventArgs e)
        {
            if (percentChanged())
                Console.WriteLine("{2}%:{0}/{1}", writer.current, total, currentPercent);
        }

        public bool percentChanged()
        {
            int percent = (int)(((double)writer.current / (double)total) * 100);
            if (currentPercent != percent) {
                currentPercent = percent;
                return true;
            }
            return false;
        }
    }
}
