using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osuSGTemplate.Utility
{
    class Util
    {
        public static void RemoveDuplicateText(string path)
        {
            string txt = File.ReadAllText(path);
            string dupe = "";
            bool isDupe = false;
            for (int i = 0; i < txt.Length; i++)
            {
                for (int j = 0; j < dupe.Length; j++)
                {
                    if (txt[i].Equals(dupe[j]))
                    {
                        isDupe = true;
                    }
                }
                if (!isDupe)
                {
                    dupe = dupe + txt[i];
                }
                isDupe = false;
            }
            string txt2 = File.ReadAllText(@"D:\Library\Pictures\1sb\font\Japanese\1exists.txt");
            for (int i = 0; i < txt2.Length; i++)
            {
                if (dupe.Contains(txt2[i]))
                {
                    dupe = dupe.Remove(dupe.IndexOf(txt2[i]), 1);
                }
            }
            File.WriteAllText(path, dupe, Encoding.UTF8);
        }

        public static void Test(string test)
        {
            System.Console.WriteLine(test);
            System.Console.ReadLine();
        }

        //Stolen from http://stackoverflow.com/questions/8754111/how-to-read-the-data-in-a-wav-file-to-an-array
        // convert two bytes to one double in the range -1 to 1
        static double bytesToDouble(byte firstByte, byte secondByte)
        {
            // convert two bytes to one short (little endian)
            short s = (short)((secondByte << 8) | firstByte);
            // convert to range from -1 to (just below) 1
            return s / 32768.0;
        }

        // Returns left and right double arrays. 'right' will be null if sound is mono.
        public static void openWav(string filename, out double[] left, out double[] right)
        {
            byte[] wav = File.ReadAllBytes(filename);

            // Determine if mono or stereo
            int channels = wav[22];     // Forget byte 23 as 99.999% of WAVs are 1 or 2 channels

            // Get past all the other sub chunks to get to the data subchunk:
            int pos = 12;   // First Subchunk ID from 12 to 16

            // Keep iterating until we find the data chunk (i.e. 64 61 74 61 ...... (i.e. 100 97 116 97 in decimal))
            while (!(wav[pos] == 100 && wav[pos + 1] == 97 && wav[pos + 2] == 116 && wav[pos + 3] == 97))
            {
                pos += 4;
                int chunkSize = wav[pos] + wav[pos + 1] * 256 + wav[pos + 2] * 65536 + wav[pos + 3] * 16777216;
                pos += 4 + chunkSize;
            }
            pos += 8;

            // Pos is now positioned to start of actual sound data.
            int samples = (wav.Length - pos) / 2;     // 2 bytes per sample (16 bit sound mono)
            if (channels == 2) samples /= 2;        // 4 bytes per sample (16 bit stereo)

            // Allocate memory (right will be null if only mono sound)
            left = new double[samples];
            if (channels == 2) right = new double[samples];
            else right = null;

            // Write to double array/s:
            int i = 0;
            while (pos < wav.Length)
            {
                Console.WriteLine(String.Format("currently at: {0} / {1}", pos, wav.Length));
                left[i] = bytesToDouble(wav[pos], wav[pos + 1]);
                pos += 2;
                if (channels == 2)
                {
                    right[i] = bytesToDouble(wav[pos], wav[pos + 1]);
                    pos += 2;
                }
                i++;
            }
        }

        public static bool random(int percentage)
        {
            return Control.rand.Next(0, 100) <= percentage;
        }
    }
}
