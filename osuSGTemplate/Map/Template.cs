using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osuSGTemplate.Basic;
using osuSGTemplate.FileManagement;
using osuSGTemplate.Utility;
using System.IO;
using System.Drawing;
namespace osuSGTemplate
{
    class Control : ControlClass
    {
        public static Random rand = new Random();
        public static int BPM = 175;
        public static string location = @"D:\Library\Game\osu!\Songs\334725 ChouCho - Starlog(Asterisk Remix)\ChouCho - Starlog(Asterisk Remix) (Depths).osb";
        public static string combine = @"";
        public static string folder = @"D:\Library\Game\osu!\Songs\334725 ChouCho - Starlog(Asterisk Remix)\";
        public static string wave = folder + @"06 Starlog(Asterisk Remix).wav";
        public static double beat = 60000.0 / BPM;
        public static double scale = 480.0 / 768.0;
        public static int beginning = -2000;
        public static int ending = 328097;
        public static List<List<string>> lyrics;
        public static List<List<int>> lyricWidth;
        public static List<List<int>> words;
        public static Dictionary<string, int> dict;

        static void Main(string[] args)
        {
            Control map = new Control();
            map.Code();
            map.Run(location);
            //Util.RemoveDuplicateText(folder + @"\sb\lyrics2.txt");
        }

        public void Code()
        {
            Background();
            Lyrics();
            Foreground();
        }

        #region Background
        public void Background()
        {
            //Instantiating the permanent ones
            Sprite delete = new Sprite(@"StarlogBG2.jpg", Sprite.layer.Background);

            Sprite bg = new Sprite(@"sb\bg\bg.jpg", Sprite.layer.Background);
            bg.Fade(beginning, 1);
            bg.Scale(0, scale);

            Sprite star = new Sprite(@"sb\bg\star.png");
            star.Fade(beginning, 1);

            Sprite ring = new Sprite(@"sb\bg\ring.png");
            ring.MoveY(258);
            ring.Fade(beginning, 1);

            Sprite[] perm = { bg, star, ring };

            Sprite starPulse = new Sprite(@"sb\bg\star.png");

            Sprite ringPulse = new Sprite(@"sb\bg\ring.png");
            ringPulse.MoveY(258);

            Sprite[][] hexagons = DrawHexagon();



            //The start and end of each section
            int start;
            int end;

            //reading the timing for each sections
            Queue<int> sections = LyricTiming(@"D:\Library\Game\osu!\Songs\334725 ChouCho - Starlog(Asterisk Remix)\ChouCho - Starlog(Asterisk Remix) (Depths) [sections].osu");

            //Each sections
            //Intro 1
            start = sections.Dequeue();
            end = sections.Dequeue();

            Pulse(starPulse, start, end, .2, beat, 1);
            Pulse(ringPulse, start, end, .2, beat * 16, .5);

            //Intro 2
            start = end;
            end = sections.Dequeue();

            Pulse(starPulse, start, end, .2, beat, 1);
            Pulse(ringPulse, start, end, .8, beat * 4, 1);

            //Vocals A1
            start = end;
            end = sections.Dequeue();

            Pulse(starPulse, start, end, .2, beat, 1);
            Pulse(ringPulse, start, end, .8, beat * 4, 1);

            //Vocals A2
            start = end;
            end = sections.Dequeue();

            FadeBackground(perm, start - beat, start, 1, 0);

            int f;
            f = start + (66154 - 66154);
            Flash(f);
            f = start + (66668 - 66154);
            Flash(f);
            f = start + (67183 - 66154);
            Flash(f);
            f = start + (67697 - 66154);
            Flash(f);

            f = start + (68897 - 66154);
            Flash(f);
            f = start + (69411 - 66154);
            Flash(f);
            f = start + (69926 - 66154);
            Flash(f);
            f = start + (70440 - 66154);
            Flash(f);

            f = start + (71640 - 66154);
            Flash(f);
            f = start + (72154 - 66154);
            Flash(f);
            f = start + (72326 - 66154);
            Flash(f);

            f = start + (73011 - 66154);
            Flash(f);
            f = start + (73268 - 66154);
            Flash(f);
            f = start + (73526 - 66154);
            Flash(f);

            f = start + (73697 - 66154);
            Flash(f);
            f = start + (73954 - 66154);
            Flash(f);
            f = start + (74211 - 66154);
            Flash(f);

            f = start + (68211 - 66154);
            Flash(f);
            f = start + (68554 - 66154);
            Flash(f);

            f = start + (70954 - 66154);
            Flash(f);
            f = start + (71297 - 66154);
            Flash(f);

            f = start + (74383 - 66154);
            Flash(f);
            f = start + (74897 - 66154);
            Flash(f);

            f = start + (75411 - 66154);
            Flash(f);
            f = start + (75497 - 66154);
            Flash(f);
            f = start + (75585 - 66154);
            Flash(f);

            f = start + (75926 - 66154);
            Flash(f);
            f = start + (76097 - 66154);
            Flash(f);

            //KiaiA1
            start = end;
            end = sections.Dequeue();

            FadeBackground(perm, start - beat, start, 0, 1);

            FlashHexagons(hexagons, start, end);
            DrawShootingStar(start, end);

            Pulse(starPulse, start, end, .2, beat, 1);
            Pulse(ringPulse, start, end, .8, beat * 4, 1);

            //KiaiA2
            start = end;
            end = sections.Dequeue();

            FlashHexagons(hexagons, start, end);
            DrawShootingStar(start, end);

            Pulse(starPulse, start, end, .2, beat, 1);
            Pulse(ringPulse, start, end, .8, beat * 4, 1);

            //Transition A2
            start = end;
            end = sections.Dequeue();

            Pulse(starPulse, start, end, .2, beat, 1);
            Pulse(ringPulse, start, end, .8, beat * 4, 1);

            //Quiet A
            start = end;
            end = sections.Dequeue();

            Pulse(ringPulse, start, end, .8, beat * 4, 1);

            //Vocal B1
            start = end;
            end = sections.Dequeue();

            Pulse(starPulse, start, end, .2, beat, 1);
            Pulse(ringPulse, start, end, .8, beat * 4, 1);

            //Vocal B2
            start = end;
            end = sections.Dequeue();

            FadeBackground(perm, start - beat, start, 1, 0);

            f = start + (66154 - 66154);
            Flash(f);
            f = start + (66668 - 66154);
            Flash(f);
            f = start + (67183 - 66154);
            Flash(f);
            f = start + (67697 - 66154);
            Flash(f);

            f = start + (68897 - 66154);
            Flash(f);
            f = start + (69411 - 66154);
            Flash(f);
            f = start + (69926 - 66154);
            Flash(f);
            f = start + (70440 - 66154);
            Flash(f);

            f = start + (71640 - 66154);
            Flash(f);
            f = start + (72154 - 66154);
            Flash(f);
            f = start + (72326 - 66154);
            Flash(f);

            f = start + (73011 - 66154);
            Flash(f);
            f = start + (73268 - 66154);
            Flash(f);
            f = start + (73526 - 66154);
            Flash(f);

            f = start + (73697 - 66154);
            Flash(f);
            f = start + (73954 - 66154);
            Flash(f);
            f = start + (74211 - 66154);
            Flash(f);

            f = start + (68211 - 66154);
            Flash(f);
            f = start + (68554 - 66154);
            Flash(f);

            f = start + (70954 - 66154);
            Flash(f);
            f = start + (71297 - 66154);
            Flash(f);

            f = start + (74383 - 66154);
            Flash(f);
            f = start + (74897 - 66154);
            Flash(f);

            f = start + (75411 - 66154);
            Flash(f);
            f = start + (75497 - 66154);
            Flash(f);
            f = start + (75585 - 66154);
            Flash(f);

            f = start + (75926 - 66154);
            Flash(f);
            f = start + (76097 - 66154);
            Flash(f);

            //Kiai B1
            start = end;
            end = sections.Dequeue();

            FadeBackground(perm, start - beat, start, 0, 1);

            FlashHexagons(hexagons, start, end);
            DrawShootingStar(start, end);

            Pulse(starPulse, start, end, .2, beat, 1);
            Pulse(ringPulse, start, end, .8, beat * 4, 1);

            //Kiai B2
            start = end;
            end = sections.Dequeue();

            FlashHexagons(hexagons, start, end);
            DrawShootingStar(start, end);

            Pulse(starPulse, start, end, .2, beat, 1);
            Pulse(ringPulse, start, end, .8, beat * 4, 1);

            //Quiet B1
            start = end;
            end = sections.Dequeue();

            Pulse(ringPulse, start, end, .8, beat * 4, 1);

            //Quiet B2
            start = end;
            end = sections.Dequeue();

            Sprite[] t1 = { star, ring };
            FadeBackground(perm, start - beat * 6.5, start - beat * 5.5, 1, 0);

            Pulse(ringPulse, start + beat * 4, end, .8, beat * 8, 1);

            //Vocal C1
            start = end;
            end = sections.Dequeue();
            
            Sprite[] t2 = { bg };

            FadeBackground(t2, start, end, 0, 1);
            FadeBackground(t1, start, start + beat / 2, 0, 1);
            Pulse(starPulse, start, end, .2, beat, 1);
            Pulse(ringPulse, start, end, .8, beat * 4, 1);

            //KiaiC2
            start = end;
            end = sections.Dequeue();

            FlashHexagons(hexagons, start + beat, end);
            DrawShootingStar(start + beat, end);

            Pulse(starPulse, start + beat, end, .2, beat, 1);
            Pulse(ringPulse, start, end, .8, beat * 4, 1);

            //Transition B2
            start = end;
            end = sections.Dequeue();

            FlashHexagons(hexagons, start, end - 100);

            Pulse(starPulse, start, end, .2, beat, 1);
            Pulse(ringPulse, start, end, .8, beat * 4, 1);

            //Outro 1
            start = end;
            end = sections.Dequeue();

            FlashHexagons(hexagons, start, end - 100);

            Pulse(starPulse, start, end, .2, beat, 1);
            Pulse(ringPulse, start, end, .8, beat * 4, 1);

            //Outro 2
            start = end;
            end = ending;

            Pulse(starPulse, start, end, .2, beat, 1);
            Pulse(ringPulse, start, end, .8, beat * 4, 1);
            
            //Others
            DrawKeyboard();
            DrawFirework();
            FadeBackground(perm, ending, ending + beat, 1, 0);
            Wave(3068);
            Wave(8554);
            Wave(14040);
            Wave(19526);
        }

        public Sprite[][] DrawHexagon()
        {
            double size = 15;
            double width = 1366 * Control.scale;
            
            int cx = 320;
            int cy = 320;
            double radius = size / 2;
            double scale = size / 100.0;
            double percentagex = 1;
            double percentagey = 1;
            double intervalx = radius * Math.Cos(30.0 * (Math.PI / 180.0)) * percentagex;
            double intervaly = 2 * ((radius) * Math.Sin(30.0 * (Math.PI / 180.0))) + size * percentagey;
            int amountx = (int)((width) / intervalx) + 5;

            Sprite[][] hexagons = new Sprite[amountx][];
            for (int i = 0; i < hexagons.Length; i++)
            {
                double t = Math.Abs(i - amountx / 2) * (10 / width);
                double height = Math.Pow(t, 2) * 400;
                int amounty = (int)((height) / intervaly) + 5;

                hexagons[i] = new Sprite[amounty];
                for (int j = 0; j < hexagons[i].Length; j++)
                {
                    
                    Sprite hexagon = new Sprite(@"sb\etc\hexagon.png", Sprite.layer.Background);
                    if (i < amountx / 2)
                    {
                        hexagon.MoveX((int)(cx - (intervalx * (amountx / 2 - i))));
                    } else
                    {
                        hexagon.MoveX((int)(cx + (intervalx * (i - amountx / 2))));
                    }

                    if (i % 2 == 0)
                    {
                        if (j < amounty / 2)
                        {
                            hexagon.MoveY((int)(cy - (intervaly * (amounty / 2 - j))));
                        }
                        else
                        {
                            hexagon.MoveY((int)(cy + (intervaly * (j - amounty / 2))));
                        }
                    }
                    else
                    {
                        if (j < amounty / 2)
                        {
                            hexagon.MoveY((int)(cy - (intervaly * (amounty / 2 - j)) + (radius + (radius * Math.Sin(30.0 * (Math.PI / 180.0))))));
                        }
                        else
                        {
                            hexagon.MoveY((int)(cy + (intervaly * (j - amounty / 2)) + (radius + (radius * Math.Sin(30.0 * (Math.PI / 180.0))))));
                        }
                    }
                    hexagon.Scale(scale);
                    hexagon.Parameters(0, 0, "A");
                    hexagon.Fade(0);
                    Color2 h = Color2.HSL2RGB((double)i / hexagons.Length, .7, .4);
                    hexagon.Color(h.red, h.green, h.blue);
                    hexagons[i][j] = hexagon;
                }
            }
            return hexagons;
        }

        public void Pulse(Sprite s, double startTime, double endTime, double size, double interval, double length)
        {
            double sc = s.GetScale();
            for (double currTime = startTime; currTime < endTime - 100; currTime += interval)
            {
                s.Scale(currTime, currTime + interval * length, sc, sc + size);
                s.Fade(4, currTime, currTime + interval * length, 1, 0);
            }
            s.currentScale = sc;
        }

        public void FlashHexagons(Sprite[][] hexagon, double startTime, double endTime)
        {
            for (double i = startTime; i < endTime; i += beat)
            {
                for (int j = 0; j < hexagon.Length; j++)
                {
                    for (int k = 0; k < hexagon[j].Length; k++)
                    {
                        if (Util.random(10))
                        {
                            hexagon[j][k].Fade(i, i + beat / 4, 0, 1);
                            hexagon[j][k].Fade(i + beat * 3 / 4, i + beat, 1, 0);
                        }
                    }
                }
            }
        }

        public void DrawFirework()
        {
            Queue<int> time = LyricTiming(@"D:\Library\Game\osu!\Songs\334725 ChouCho - Starlog(Asterisk Remix)\ChouCho - Starlog(Asterisk Remix) (Depths) [fw].osu");
            int c = 0;
            while (time.Count > 0)
            {
                int t = time.Dequeue();
                if (c % 2 == 0)
                {
                    Firework(t, rand.Next(0, 320), rand.Next(100, 380), rand.Next(4, 8));
                }
                else
                {
                    Firework(t, rand.Next(320, 640), rand.Next(100, 380), rand.Next(4, 8));
                }

                c++;
            }
        }

        public void Firework(double startTime, int ox, int oy, int layers)
        {
            int total = 7;
            int amount = rand.Next(9, 12);
            //int amount = 12;
            for (int i = 1; i <= layers; i++)
            {
                int angle = i;
                int r = rand.Next(1, total + 1);
                for (int j = 0; j < amount; j++)
                {
                    Sprite particle = GenerateParticles(r);

                    particle.Fade(startTime, startTime + beat / 4, 0, 1);
                    particle.Fade(startTime + + beat * 3, startTime + beat * 4, 1, 0);
                    particle.Rotate(angle);
                    particle.Parameters(startTime, startTime, "A");
                    Color2 c = Color2.HSL2RGB((double)i / layers, .8, .4);
                    particle.Color(c.red, c.green, c.blue);

                    Mathematics.ExpandPoint(particle, 4, startTime, startTime + beat * 4, angle, ox, oy, 0, i * 30);
                    angle += 360 / amount;
                }
                amount++;
            }
        }

        public Sprite GenerateParticles(int r)
        {
            Sprite p;
            switch (r)
            {
                case 1:
                    p = new Sprite(@"sb\etc\hexagon.png");
                    p.Scale(.2);
                    return p;
                case 2:
                    p = new Sprite(@"sb\etc\petal1.png");
                    p.Scale(.6);
                    return p;
                case 3:
                    p = new Sprite(@"sb\etc\petal2.png");
                    p.Scale(.6);
                    return p;
                case 4:
                    p = new Sprite(@"sb\etc\petal3.png");
                    p.Scale(.6);
                    return p;
                case 5:
                    p = new Sprite(@"sb\etc\petal4.png");
                    p.Scale(.6);
                    return p;
                case 6:
                    p = new Sprite(@"sb\etc\petal5.png");
                    p.Scale(.6);
                    return p;
                case 7:
                    p = Mathematics.DrawLines(0, 10, 40);
                    return p;
                default:
                    p = new Sprite(@"sb\etc\hexagon.png");
                    p.Scale(.6);
                    return p;
            }
        }

        public void FadeBackground(Sprite[] bg, double startTime, double endTime, double opacity1, double opacity2)
        {
            for (int i = 0; i < bg.Length; i++)
            {
                bg[i].Fade(startTime, endTime, opacity1, opacity2);
            }
        }

        public void Keyboard(double startTime, double endTime, int height)
        {
            int maxHeight = 16;
            Sprite key = Mathematics.DrawLines(startTime, 1000, 80, Sprite.layer.Background);
            key.Move(startTime, 320, 480 - height * (480 / maxHeight));
            key.Fade(0);
            key.Rotate(10);
            if (endTime - startTime < beat * 4)
                key.Fade(startTime, endTime + beat * 2, .1, 0);
            else
                key.Fade(startTime, startTime + beat * 2, .1, 0);

            //key.Color(255, 125, 30);
            key.Parameters(startTime, startTime, "A");
        }

        public void DrawKeyboard()
        {
            Queue<int> timing = LyricTiming(@"D:\Library\Game\osu!\Songs\334725 ChouCho - Starlog(Asterisk Remix)\ChouCho - Starlog(Asterisk Remix) (Depths) [keyboard1].osu");
            int start = timing.Dequeue();
            int end = timing.Dequeue();

            int maxHeight = 16;

            int count = 0;

            while (timing.Count > 0)
            {
                Keyboard(start, end, rand.Next(0, maxHeight + 1));
                start = end;
                end = timing.Dequeue();
                count++;
            }
        }

        public void Wave(int startTime)
        {
            int y = 240;
            int amount = 15;
            double interval = 1366 * Control.scale / (amount + 1);            

            for (double i = amount / -2.0; i < amount; i++)
            {
                double start = startTime + (i + amount / 2.0) * (beat / 16);
                double end = start + beat * 4;
                int x = (int)(320 + (i) * interval);
                int ty = (int)(Math.Sin(x / 180.0 * Math.PI) * 50 + y);
                Sprite line = Mathematics.DrawLines(start, 10, 160);
                line.Fade(start, start + beat / 2, 0, 1);
                Blink(line, start + beat / 2, end, 5);
                line.Move(start + i * (beat / 16), x, ty);
                line.MoveY(start, end, ty, ty + rand.Next(-70, 70));
                Color2 c = Color2.HSL2RGB((double)Math.Abs(i) / amount, .9, .4);
                line.Color(c.red, c.green, c.blue);
                line.Parameters(start, start, "A");
                line.Rotate(10);
            }
        }

        public void Blink(Sprite line, double startTime, double endTime, int frequency)
        {
            double time = startTime;
            while (time + 600< endTime)
            {
                int interval = rand.Next(10, 600);
                line.Fade(time, time + interval / 2, 1, 0);
                line.Fade(time + interval / 2, time + interval, 1, 0);
                time += interval;
            }

        }

        public bool Included(int x, int[] xs, int leniency)
        {
            for (int i = 0; i < xs.Length; i++)
            {
                if (x + 15 >= xs[i] && x - 15 <= xs[i])
                {
                    return true;
                }
            }
            return false;
        }

        public void Flash(int startTime)
        {
            Sprite white = new Sprite(@"sb\etc\p.png", Sprite.origin.BottomCentre);
            white.Fade(startTime, startTime + beat / 2, .7, 0);
            white.Scale(startTime, scale);
            white.Move(startTime, 320, 480);
            Color2 c = Color2.HSL2RGB(rand.Next(1, 100) / 100.0, .4, .8);
            white.Color(startTime, c.red, c.green, c.blue);
            white.Parameters(startTime, startTime, "A");
        }
        #endregion

        #region Foreground
        public void Foreground()
        {
            BlackOut(64783);
            BlackOut(152554);
            BlackOut(218211);

            DrawName();
        }
        public void BlackOut(int startTime)
        {
            int intx = 50;
            int inty = 42;
            for (int i = -300; i < 1366 * scale + 200; i += intx)
            {
                for (int j = -40 - ((i / intx + 120) % 2 * (inty / 2)); j < 520 + ((i / intx + 120) % 2 * (inty / 2)); j += inty)
                {
                    Sprite line = Mathematics.DrawLines(startTime, 1, 30);
                    line.Rotate((i / intx + 120) % 2 == 0 ? 45 : -45);

                    Mathematics.ScaleLines(line, 1, startTime, startTime + beat * 4, 50, 30);

                    line.Move(startTime, i, j);

                    line.Fade(0);
                    line.Fade(startTime, 1);
                    line.Fade(startTime + beat * 4, startTime + beat * 5, 1, 0);

                    line.Color(0, 0, 0);

                }

            }
        }
        #endregion

        #region Drawing
        public void ShootingStar(double startTime, int x, int dir)
        {
            int midPoint = rand.Next(230, 260);
            Sprite star = new Sprite(@"sb\bg\star.png");
            star.Scale(.1);
            star.Rotate(startTime, startTime + beat * 2, 0, rand.Next(60, 180));
            star.Move(1, startTime, startTime + beat / 4 * 3, x, -20, x, 500);
            star.Fade(startTime - 1, startTime, 0, 1);
            star.Parameters(startTime, startTime, "A");
            star.Color(247, 255, 168);

            Sprite line = Mathematics.DrawLines(startTime, 500, 10, dir == 1 ? Sprite.origin.CentreRight : Sprite.origin.CentreLeft);
            line.Rotate(startTime, 90 * dir);
            line.Move(1, startTime, startTime + beat / 4 * 3, x, -20, x, 500);
            Mathematics.ScaleLines(line, 1, startTime + beat, startTime + beat / 4 * 7, 1, 10);
            line.Parameters(startTime, startTime, "A");
            line.Color(247, 255, 168);
            line.Fade(startTime - 1, startTime, 0, 1);
        }

        public void DrawShootingStar(double startTime, double endTime)
        {
            int dir = 1;
            for (double i = startTime; i < endTime - 100; i += beat)
            {
                ShootingStar(i, rand.Next(0, 213), dir);
                ShootingStar(i, rand.Next(213, 426), dir);
                ShootingStar(i, rand.Next(426, 640), dir);
                dir *= -1;
            }
        }
        #endregion

        #region Lyrics
        public void Lyrics()
        {
            ReadLyrics(@"D:\Library\Game\osu!\Songs\334725 ChouCho - Starlog(Asterisk Remix)\sb\lyrics.txt");
            //starting number, ending number, then type of lyrics
            Queue<int> timing = LyricTiming(@"D:\Library\Game\osu!\Songs\334725 ChouCho - Starlog(Asterisk Remix)\ChouCho - Starlog(Asterisk Remix) (Depths) [lyrics].osu");
            int end = timing.Count - 4;
            double s = timing.Dequeue();
            s = DrawLyrics(timing, 1, 1, s, 0, false, 3);
            s = timing.Dequeue();
            s = DrawLyrics(timing, 2, 23, s, beat, false, 1, 2);
            s = DrawLyrics(timing, 24, 24, s, beat, false, 3);
            s = timing.Dequeue();
            s = DrawLyrics(timing, 25, 54, s, beat, false, 1, 2);
            s = timing.Dequeue();
            s = DrawLyrics(timing, 55, end - 1, s, beat, false, 1, 2);
            s = DrawLyrics(timing, end, end, s, beat, false, 3);
        }

        public double DrawLyrics(Queue<int> timing, int start, int end, double startTime, double interval, bool isRandom, params int[] types)
        {
            double s = startTime;
            double e = timing.Dequeue() - interval;
            for (int i = start; i <= end; i++)
            {
                int type = isRandom ? types[rand.Next(0, types.Length)] : types[i % types.Length];
                switch(type)
                {
                    case 1:
                        DrawLyrics1(i, s, e, 1);
                        break;

                    case 2:
                        DrawLyrics1(i, s, e, 0);
                        break;

                    case 3:
                        DrawLyrics1(i, s, e, 3);
                        break;

                    default:
                        break;
                }
                s = e + interval;
                if (i != end)
                    e = timing.Dequeue() - interval;
            }
            return s;
        }

        public void DrawLyrics1(int line, double startTime, double endTime, int isRight)
        {
            int ox, rx, y;
            int length = (lyrics[line].Count - 2) * 40;
            int size = 40;
            int range = 40;
            int x1 = isRight == 1 ? 320 : (-108 + length / 2 + range);
            int y1 = 240 + size;
            int x2 = isRight == 1 ? (750 - length / 2 - range) : 320;
            int y2 = 480 - size;
            Color2 c1 = new Color2(220, 219, 173);
            Color2 c2 = new Color2(220, 219, 173);

            ox = rand.Next(x1, x2) - (length % 2 == 0 ? 15 : 0);            
            y = rand.Next(y1, y2);

            if (isRight > 1)
            {
                ox = 320;
                y = 360;
                c2 = new Color2(174, 200, 220);
                c1 = new Color2(174, 200, 220);
            }

            rx = ox - length / 2;

            double speed = (endTime - startTime) / 1000 * 1;
            for (int i = 1; i < lyrics[line].Count; i++)
            {
                Sprite letter = new Sprite(string.Format(@"sb\text\{0}.png", lyrics[line][i]));
                letter.Scale(.4);
                letter.MoveX(startTime, endTime, rx + (i - 1) * 40, rx + (i - 1) * 40);
                letter.MoveY(startTime, endTime, y, y + rand.Next((int)speed - 5, (int)speed + 5) * (rand.Next(0, 2) == 1  ?  1 : -1));
                letter.Fade(startTime, startTime + beat / 2, 0, 1);
                letter.Fade(endTime - beat / 2, endTime, 1, 0);
                letter.Color(c1.red, c1.green, c1.blue);
            }

            //lines
            Sprite line1 = Mathematics.DrawLines(startTime, 1, 5, Sprite.origin.CentreLeft);
            int offset = 30;

            line1.Move(startTime, endTime, rx - 30, y + offset, rx - 30, y + offset);
            line1.Fade(startTime, startTime + beat / 2, 0, 1);
            Mathematics.ScaleLines(line1, 1, startTime, startTime + beat / 2, length + 60, 5);
            line1.Color(c2.red, c2.green, c2.blue);

            Sprite line2 = Mathematics.DrawLines(startTime, 1, 5, Sprite.origin.CentreRight);

            line2.Move(startTime, endTime, rx + ((lyrics[line].Count - 2) * 40) + 30, y - offset, rx + ((lyrics[line].Count - 2) * 40) + 30, y - offset);
            line2.Fade(startTime, startTime + beat / 2, 0, 1);
            Mathematics.ScaleLines(line2, 1, startTime, startTime + beat / 2, length + 60, 5);
            line2.Color(c2.red, c2.green, c2.blue);

            BubblingThing(startTime, endTime, ox, y + offset, length + 60, 1);
            BubblingThing(startTime, endTime, ox, y - offset, length + 60, -1);
        }

        public void BubblingThing(double startTime, double endTime, int xc, int yc, int length, int dir)
        {
            int x1, x2;
            x1 = xc - length / 2;
            x2 = xc + length / 2;
            int rate = (int)((endTime - startTime) / 1000 * 20);
            for (int i = 0; i < rate; i++)
            {
                int dist = 20 + rand.Next(0, 30);
                double start = rand.Next((int)startTime, (int)(endTime));
                double end = start + rand.Next((int)beat * 4, (int)beat * 16);
                int x = rand.Next(x1, x2);
                double size = rand.Next(10, 70) / 1000.0;
                Color2 c = Color2.HSL2RGB((double)(x - x1) / (x2 - x1), .8, .7);

                Sprite bubble = new Sprite(@"sb\etc\circle.png", dir == 1 ? Sprite.origin.TopCentre : Sprite.origin.BottomCentre);
                bubble.Fade(start, start + beat, 0, 1);
                bubble.Fade(end - beat, end, 1, 0);
                bubble.Scale(size);
                bubble.Move(1, start, end, x, yc, x, yc + dist * dir);
                bubble.Color(start, c.red, c.green, c.blue);
                //bubble.Parameters(start, start, "A");
            }

        }


        public void DrawWheels(double startTime, double endTime, int x, int y, double scale, int color, int aps)
        {
            double angle = Math.Abs(aps) * (endTime - startTime) / 1000;

            int amount = 16;
            double interval = 360 / amount;
            bool inv = aps < 0;
            for (double i = 0; i < 180 - 20; i += interval)
            {
                Sprite gear = Mathematics.DrawLines(startTime, 250 * scale, 35 * scale);
                gear.Rotate(startTime, endTime, i + (inv ? angle : 0), i + (inv ? 0 : angle));
                gear.Fade(startTime, startTime + beat / 2, 0, 1);
                gear.Fade(endTime - beat / 2, endTime, 1, 0);
                gear.Move(startTime, x, y);
            }

            Sprite mid = new Sprite(string.Format(@"sb\etc\stripe{0}.png", color));
            mid.Scale(scale - .03 * scale);
            mid.Move(x, y);
            mid.Fade(startTime, startTime + beat, 0, 1);
            mid.Fade(endTime - beat / 2, endTime, 1, 0);
            mid.Rotate(startTime, endTime, 0 + (inv ? angle : 0), 0 + (inv ? 0 : angle));

            Sprite outer = new Sprite(@"sb\etc\outer.png");
            outer.Scale(scale);
            outer.Move(x, y);
            outer.Fade(startTime, startTime + beat / 2, 0, 1);
            outer.Fade(endTime - beat / 2, endTime, 1, 0);

            Sprite inner = new Sprite(@"sb\etc\circle.png");
            inner.Scale(scale * .6);
            inner.Move(x, y);
            inner.Fade(startTime, startTime + beat / 2, 0, 1);
            inner.Fade(endTime - beat / 2, endTime, 1, 0);


        }

        public void DrawName()
        {

            Queue<int> timing = LyricTiming(@"D:\Library\Game\osu!\Songs\334725 ChouCho - Starlog(Asterisk Remix)\ChouCho - Starlog(Asterisk Remix) (Depths) [part].osu");
            int dir = -1;
            int offsetx = 320;
            int t = timing.Dequeue();
            int tNext = 0;
            Color2 c = new Color2(148, 196, 255);

            while (timing.Count > 0)
            {
                int r, g, b;
                r = dir == 1 ? c.red : c.blue;
                g = dir == 1 ? c.green : c.red;
                b = dir == 1 ? c.blue : c.green;
                tNext = timing.Dequeue();
                Sprite timeline = Mathematics.DrawLines(t, 215, 10, dir == -1 ? Sprite.origin.TopLeft : Sprite.origin.BottomRight);
                timeline.Move(t, 320 + offsetx * dir, 110 + 40 * dir);
                Mathematics.ScaleLines(timeline, 0, t, tNext, 73, 10);
                timeline.Fade(t, t + beat, 0, 1);
                if (timing.Count == 0)
                {
                    timeline.Fade(ending - beat * 2, ending - beat, 1, 0);
                }
                else
                {
                    timeline.Fade(tNext, tNext + beat, 1, 0);
                }
                timeline.Color(r, g, b);

                t = tNext;
                dir *= -1;
            }
            DrawNameThing();
        }

        public void DrawNameThing()
        {
            string[][] names =
                                {
                                    new string[]
                                    {
                                        Translate("D"),
                                        Translate("e"),
                                        Translate("p"),
                                        Translate("t"),
                                        Translate("h"),
                                        Translate("s"),
                                    },

                                    new string[]
                                    {
                                        Translate("C"),
                                        Translate("r"),
                                        Translate("y"),
                                        Translate("s"),
                                        Translate("t"),
                                        Translate("a"),
                                        Translate("l"),
                                    }
                                };
            int offsetx = 320;
            int y = 110;
            double size = .7;
            double size2 = size * .7;
            double radius = 80;
            double letterSize = .4;
            int lineLength = 215;
            int lineWidth = 40;
            int dist = 20;
            int offsetLettersX = -5;
            int offsetLettersY = 0;
            Color2 c = new Color2(148, 196, 255);


            //left: Depths
            Sprite line1 = Mathematics.DrawLines(beginning, 1, lineWidth, Sprite.origin.TopLeft);
            line1.Move(beginning, 320 - offsetx, y - (int)radius);
            Mathematics.ScaleLines(line1, 1, beginning + beat, beginning + beat * 2, lineLength, lineWidth);
            line1.Color(c.red, c.green, c.blue);
            line1.Fade(beginning + beat, beginning + beat * 2, 0, 1);
            line1.Fade(ending - beat * 2, ending - beat, 1, 0);

            Sprite circle1 = new Sprite(@"sb\etc\circle.png");
            circle1.Move(beginning, 320 - offsetx, y);
            circle1.Fade(beginning, beginning + beat, 0, 1);
            circle1.Fade(ending - beat, ending, 1, 0);
            circle1.Scale(beginning, size);

            Sprite circle2 = new Sprite(@"sb\etc\circle.png");
            circle2.Move(beginning, 320 - offsetx, y);
            circle2.Fade(beginning, beginning + beat, 0, 1);
            circle2.Fade(ending - beat, ending, 1, 0);
            circle2.Scale(beginning, size2);
            circle2.Color(c.red, c.green, c.blue);

            for (int i = 0; i < names[0].Length; i++)
            {
                Sprite letter = new Sprite($@"sb\text\{names[0][i]}.png", Sprite.origin.TopCentre);
                letter.Move(beginning, 320 - offsetx + (int)radius + offsetLettersX + i * dist, y - (int)radius - offsetLettersY);
                letter.Fade(beginning + beat * 2, beginning + beat * 2.5, 0, 1);
                letter.Fade(ending - beat * 2, ending - beat, 1, 0);
                letter.Scale(letterSize);
            }

            //right: Crystal
            Sprite line2 = Mathematics.DrawLines(beginning, 1, lineWidth, Sprite.origin.BottomRight);
            line2.Move(beginning, 320 + offsetx, y + (int)radius);
            Mathematics.ScaleLines(line2, 1, beginning + beat, beginning + beat * 2, lineLength, lineWidth);
            line2.Color(c.blue, c.red, c.green);
            line2.Fade(beginning + beat, beginning + beat * 2, 0, 1);
            line2.Fade(ending - beat * 2, ending - beat, 1, 0);

            Sprite circle3 = new Sprite(@"sb\etc\circle.png");
            circle3.Move(beginning, 320 + offsetx, y);
            circle3.Fade(beginning, beginning + beat, 0, 1);
            circle3.Fade(ending - beat, ending, 1, 0);
            circle3.Scale(beginning, size);

            Sprite circle4 = new Sprite(@"sb\etc\circle.png");
            circle4.Move(beginning, 320 + offsetx, y);
            circle4.Fade(beginning, beginning + beat, 0, 1);
            circle4.Fade(ending - beat, ending, 1, 0);
            circle4.Scale(beginning, size2);
            circle4.Color(c.blue, c.red, c.green);

            for (int i = 0; i < names[1].Length; i++)
            {
                Sprite letter = new Sprite($@"sb\text\{names[1][i]}.png", Sprite.origin.BottomCentre);
                letter.Move(beginning, 320 + offsetx - (int)radius - offsetLettersX - (names[1].Length - i - 1) * dist, y + (int)radius + offsetLettersY);
                letter.Fade(beginning + beat * 2, beginning + beat * 2.5, 0, 1);
                letter.Fade(ending - beat * 2, ending - beat, 1, 0);
                letter.Scale(letterSize);
            }

        }
        #endregion

        #region Read Lyrics
        public void ReadLyrics(string loc)
        {
            CreateDictionary();
            lyrics = new List<List<string>>();
            lyricWidth = new List<List<int>>();
            words = new List<List<int>>();
            lyrics.Add(new List<string>());
            lyricWidth.Add(new List<int>());
            words.Add(new List<int>());
            string[] lines = File.ReadAllLines(loc, Encoding.UTF8);
            foreach (string line in lines)
            {
                if (line.Length > 0)
                {
                    lyrics.Add(toLetters(line));
                }
            }
        }

        public List<string> toLetters(string line)
        {
            List<string> letters = new List<string>();
            letters.Add("");
            List<int> width = new List<int>();
            width.Add(0);
            List<int> word = new List<int>();
            word.Add(0);
            int wc = 0;
            while (line.Length > 0)
            {
                string letter;
                try
                {
                    letter = line.Substring(0, line.IndexOf(" "));
                }
                catch (ArgumentOutOfRangeException)
                {
                    letter = line;
                }
                if (!letter.Equals("|"))
                {
                    letters.Add(Translate(letter));
                }
                else
                    wc++;
                width.Add(FindWidth(Translate(letter)));
                try
                {
                    line = line.Substring(letter.Length + 1);
                }
                catch (ArgumentOutOfRangeException)
                {
                    line = "";
                }
                word.Add(wc);
            }

            words.Add(word);
            lyricWidth.Add(width);
            return letters;
        }

        public string Translate(string letter)
        {
            string translated = "";
            if (translated.Equals(""))
                translated = toHira(letter);
            if (translated.Equals(""))
                translated = toKana(letter);
            if (translated.Equals(""))
                translated = toAlpha(letter);
            if (translated.Equals(""))
            {
                translated = toKanji(letter);
            }
            return translated;
        }

        public string toHira(string letter)
        {
            switch (letter)
            {
                case "あ":
                    return "hira_a";
                case "い":
                    return "hira_i";
                case "う":
                    return "hira_u";
                case "え":
                    return "hira_e";
                case "お":
                    return "hira_o";
                case "か":
                    return "hira_ka";
                case "き":
                    return "hira_ki";
                case "く":
                    return "hira_ku";
                case "け":
                    return "hira_ke";
                case "こ":
                    return "hira_ko";
                case "さ":
                    return "hira_sa";
                case "し":
                    return "hira_shi";
                case "す":
                    return "hira_su";
                case "せ":
                    return "hira_se";
                case "そ":
                    return "hira_so";
                case "た":
                    return "hira_ta";
                case "ち":
                    return "hira_chi";
                case "つ":
                    return "hira_tsu";
                case "て":
                    return "hira_te";
                case "と":
                    return "hira_to";
                case "な":
                    return "hira_na";
                case "に":
                    return "hira_ni";
                case "ぬ":
                    return "hira_nu";
                case "ね":
                    return "hira_ne";
                case "の":
                    return "hira_no";
                case "は":
                    return "hira_ha";
                case "ひ":
                    return "hira_hi";
                case "ふ":
                    return "hira_fu";
                case "へ":
                    return "hira_he";
                case "ほ":
                    return "hira_ho";
                case "ま":
                    return "hira_ma";
                case "み":
                    return "hira_mi";
                case "む":
                    return "hira_mu";
                case "め":
                    return "hira_me";
                case "も":
                    return "hira_mo";
                case "や":
                    return "hira_ya";
                case "ゆ":
                    return "hira_yu";
                case "よ":
                    return "hira_yo";
                case "ら":
                    return "hira_ra";
                case "り":
                    return "hira_ri";
                case "る":
                    return "hira_ru";
                case "れ":
                    return "hira_re";
                case "ろ":
                    return "hira_ro";
                case "わ":
                    return "hira_wa";
                case "を":
                    return "hira_wo";
                case "ん":
                    return "hira_n";
                case "が":
                    return "hira_ga";
                case "ぎ":
                    return "hira_gi";
                case "ぐ":
                    return "hira_gu";
                case "げ":
                    return "hira_ge";
                case "ご":
                    return "hira_go";
                case "ざ":
                    return "hira_za";
                case "じ":
                    return "hira_ji";
                case "ず":
                    return "hira_zu";
                case "ぜ":
                    return "hira_ze";
                case "ぞ":
                    return "hira_zo";
                case "だ":
                    return "hira_da";
                case "ぢ":
                    return "hira_di";
                case "づ":
                    return "hira_du";
                case "で":
                    return "hira_de";
                case "ど":
                    return "hira_do";
                case "ば":
                    return "hira_ba";
                case "び":
                    return "hira_bi";
                case "ぶ":
                    return "hira_bu";
                case "べ":
                    return "hira_be";
                case "ぼ":
                    return "hira_bo";
                case "ぱ":
                    return "hira_pa";
                case "ぴ":
                    return "hira_pi";
                case "ぷ":
                    return "hira_pu";
                case "ぺ":
                    return "hira_pe";
                case "ぽ":
                    return "hira_po";
                case "ぁ":
                    return "hira_la";
                case "ぃ":
                    return "hira_li";
                case "ぅ":
                    return "hira_lu";
                case "ぇ":
                    return "hira_le";
                case "ぉ":
                    return "hira_lo";
                case "っ":
                    return "hira_ltsu";
                case "ゃ":
                    return "hira_lya";
                case "ゅ":
                    return "hira_lyu";
                case "ょ":
                    return "hira_lyo";
            }
            return "";
        }

        public string toKana(string letter)
        {
            switch (letter)
            {
                case "ア":
                    return "kata_a";
                case "イ":
                    return "kata_i";
                case "ウ":
                    return "kata_u";
                case "エ":
                    return "kata_e";
                case "オ":
                    return "kata_o";
                case "カ":
                    return "kata_ka";
                case "キ":
                    return "kata_ki";
                case "ク":
                    return "kata_ku";
                case "ケ":
                    return "kata_ke";
                case "コ":
                    return "kata_ko";
                case "サ":
                    return "kata_sa";
                case "シ":
                    return "kata_shi";
                case "ス":
                    return "kata_su";
                case "セ":
                    return "kata_se";
                case "ソ":
                    return "kata_so";
                case "タ":
                    return "kata_ta";
                case "チ":
                    return "kata_chi";
                case "ツ":
                    return "kata_tsu";
                case "テ":
                    return "kata_te";
                case "ト":
                    return "kata_to";
                case "ナ":
                    return "kata_na";
                case "ニ":
                    return "kata_ni";
                case "ヌ":
                    return "kata_nu";
                case "ネ":
                    return "kata_ne";
                case "ノ":
                    return "kata_no";
                case "ハ":
                    return "kata_ha";
                case "ヒ":
                    return "kata_hi";
                case "フ":
                    return "kata_fu";
                case "ヘ":
                    return "kata_he";
                case "ホ":
                    return "kata_ho";
                case "マ":
                    return "kata_ma";
                case "ミ":
                    return "kata_mi";
                case "ム":
                    return "kata_mu";
                case "メ":
                    return "kata_me";
                case "モ":
                    return "kata_mo";
                case "ヤ":
                    return "kata_ya";
                case "ユ":
                    return "kata_yu";
                case "ヨ":
                    return "kata_yo";
                case "ラ":
                    return "kata_ra";
                case "リ":
                    return "kata_ri";
                case "ル":
                    return "kata_ru";
                case "レ":
                    return "kata_re";
                case "ロ":
                    return "kata_ro";
                case "ワ":
                    return "kata_wa";
                case "ヲ":
                    return "kata_wo";
                case "ン":
                    return "kata_n";
                case "ガ":
                    return "kata_ga";
                case "ギ":
                    return "kata_gi";
                case "グ":
                    return "kata_gu";
                case "ゲ":
                    return "kata_ge";
                case "ゴ":
                    return "kata_go";
                case "ザ":
                    return "kata_za";
                case "ジ":
                    return "kata_ji";
                case "ズ":
                    return "kata_zu";
                case "ゼ":
                    return "kata_ze";
                case "ゾ":
                    return "kata_zo";
                case "ダ":
                    return "kata_da";
                case "ヂ":
                    return "kata_di";
                case "ヅ":
                    return "kata_du";
                case "デ":
                    return "kata_de";
                case "ド":
                    return "kata_do";
                case "バ":
                    return "kata_ba";
                case "ビ":
                    return "kata_bi";
                case "ブ":
                    return "kata_bu";
                case "ベ":
                    return "kata_be";
                case "ボ":
                    return "kata_bo";
                case "パ":
                    return "kata_pa";
                case "ピ":
                    return "kata_pi";
                case "プ":
                    return "kata_pu";
                case "ペ":
                    return "kata_pe";
                case "ポ":
                    return "kata_po";
                case "ァ":
                    return "kata_la";
                case "ィ":
                    return "kata_li";
                case "ゥ":
                    return "kata_lu";
                case "ェ":
                    return "kata_le";
                case "ォ":
                    return "kata_lo";
                case "ッ":
                    return "kata_ltsu";
                case "ャ":
                    return "kata_lya";
                case "ュ":
                    return "kata_lyu";
                case "ョ":
                    return "kata_lyo";
                case "ー":
                    return "kata_long";
            }
            return "";
        }

        public string toAlpha(string letter)
        {
            switch (letter)
            {
                case ("?"):
                    return "alpha_question";
                case ("!"):
                    return "alpha_exclamation";
                case ("."):
                    return "alpha_period";
                case (","):
                    return "alpha_comma";
                case ("\""):
                    return "alpha_quotation";
                case ("'"):
                    return "alpha_apostrophe";
                case ("+"):
                    return "alpha_plus";
                case ("-"):
                    return "alpha_minus";
                case ("="):
                    return "alpha_equals";
                case ("("):
                    return "alpha_paranthesis";
                case (")"):
                    return "alpha_paranthesisclose";
                case ("*"):
                    return "alpha_asterisk";
                case ("&"):
                    return "alpha_ampersand";
                case ("^"):
                    return "alpha_carot";
                case ("%"):
                    return "alpha_percent";
                case ("$"):
                    return "alpha_dollar";
                case ("#"):
                    return "alpha_hash";
                case ("@"):
                    return "alpha_at";
                case ("「"):
                    return "alpha_kakko";
                case ("」"):
                    return "alpha_kakkotoji";
                case ("、"):
                    return "alpha_ten";
                case ("。"):
                    return "alpha_maru";
                case ("<>"):
                    return "<>";
                case (":"):
                    return "alpha_colon";
                case ("・"):
                    return "alpha_dot";
                case ("—"):
                    return "alpha_em";
                default:
                    return UpperOrLower(letter);
            }
        }

        public string UpperOrLower(string letter)
        {
            char c = char.Parse(letter);
            if (letter.Length == 1 && ((c - 'a' >= 0 && c - 'a' <= 26) || (c - 'A' >= 0 && c - 'a' <= 26)) || (c - '0' >= 0 && c - '0' <= 10))
            {
                if (char.IsUpper(c))
                    return "alpha_" + "u" + letter.ToLower();
                else
                    return "alpha_" + c;
            }
            else
                return "";
        }

        public void CreateDictionary()
        {

            string dictionary = File.ReadAllText(@"D:\Library\Pictures\1sb\font\Japanese\1dic.txt", Encoding.UTF8);
            dict = new Dictionary<string, int>();
            for (int i = 1; i <= dictionary.Length; i++)
            {
                dict[dictionary[i - 1].ToString()] = i;
            }
        }

        public string toKanji(string letter)
        {
            return string.Format("kanji_{0}", dict[letter]);
        }

        public int FindWidth(string pic)
        {
            int width;
            try
            {
                Image letter = Image.FromFile(string.Format(@"{0}\sb\text\{1}.png", folder, pic));
                width = letter.Width;
            }
            catch (ArgumentException)
            {
                width = 30;
            }
            return (int)(width * scale);

        }

        public Queue<int> LyricTiming(string osupath)
        {
            string[] lines = File.ReadAllLines(osupath);
            string b = "";
            Queue<int> bookmarks = new Queue<int>();
            foreach (string line in lines)
            {
                if (line.Contains("Bookmarks: "))
                {
                    b = line;
                }
            }

            b = b.Substring("Bookmarks: ".Length);
            while (b.Length >= 1)
            {
                string num = b;
                if (b.IndexOf(",") > 0)
                    num = b.Substring(0, b.IndexOf(","));
                int n;
                bool isDigit = int.TryParse(num, out n);
                if (isDigit)
                {
                    bookmarks.Enqueue(n);
                }
                try
                {
                    b = b.Substring(num.Length + 1);
                } catch (ArgumentOutOfRangeException ex)
                {
                    b = "";
                }
            }
            return bookmarks;
        }
        #endregion
    }
}