using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace audio
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            while (true)
            {
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.D1)
                {
                    PlaySound(16383, 100000, 500, 16, 1, false, false);
                }

                if (cki.Key == ConsoleKey.D2)
                {
                    PlaySound(16383, 100000, 500, 16, 2, false, false);
                }

                if (cki.Key == ConsoleKey.D3)
                {
                    PlaySound(16383, 100000, 500, 16, 3, false, false);
                }

                if (cki.Key == ConsoleKey.D4)
                {
                    PlaySound(16383, 100000, 500, 16, 4, false, false);
                }

                if (cki.Key == ConsoleKey.Q)
                {
                    PlaySound(16383, 1000, 466.16, 16, 0, false, true); //Bb - 1
                }

                if (cki.Key == ConsoleKey.A)
                {
                    PlaySound(16383, 1000, 523.25, 16, 0, false, true); //Middle C
                }

                if (cki.Key == ConsoleKey.W)
                {
                    PlaySound(16383, 1000, 554.37, 16, 0, false, true); //Db
                }

                if (cki.Key == ConsoleKey.S)
                {
                    PlaySound(16383, 1000, 587.33, 16, 0, false, true); //D
                }

                if (cki.Key == ConsoleKey.E)
                {
                    PlaySound(16383, 1000, 622.25, 16, 0, false, true); //Eb
                }

                if (cki.Key == ConsoleKey.D)
                {
                    PlaySound(16383, 1000, 659.25, 16, 0, false, true); //E
                }

                if (cki.Key == ConsoleKey.F)
                {
                    PlaySound(16383, 1000, 698.46, 16, 0, false, true); //F
                }

                if (cki.Key == ConsoleKey.T)
                {
                    PlaySound(16383, 1000, 739.99, 16, 0, false, true); //Gb
                }

                if (cki.Key == ConsoleKey.G)
                {
                    PlaySound(16383, 1000, 783.99, 16, 0, false, true); //G
                }

                if (cki.Key == ConsoleKey.Y)
                {
                    PlaySound(16383, 1000, 830.61, 16, 0, false, true); //Ab
                }

                if (cki.Key == ConsoleKey.H)
                {
                    PlaySound(16383, 1000, 880.00, 16, 0, false, true); //A
                }

                if (cki.Key == ConsoleKey.U)
                {
                    PlaySound(16383, 1000, 932.33, 16, 0, false, true); //Bb
                }

                if (cki.Key == ConsoleKey.J)
                {
                    PlaySound(16383, 1000, 987.77, 16, 0, false, true); //B
                }

                if (cki.Key == ConsoleKey.K)
                {
                    PlaySound(16383, 1000, 1046.50, 16, 0, false, true); //C + 1
                }

                if (cki.Key == ConsoleKey.O)
                {
                    PlaySound(16383, 1000, 1108.73, 16, 0, false, true); //Db + 1
                }

                if (cki.Key == ConsoleKey.L)
                {
                    PlaySound(16383, 1000, 1174.66, 16, 0, false, true); //D + 1
                }

                if (cki.Key == ConsoleKey.D0)
                {
                    PlaySound(16383, 366, 622.25, 16, 0, true, true); //Eb

                    while (true)
                    {
                        PlaySound(16383, 366, 932.33, 16, 0, true, true); //Bb
                        PlaySound(16383, 366, 830.61, 16, 0, true, true); //Ab
                        PlaySound(16383, 366, 739.99, 16, 0, true, true); //Gb
                        PlaySound(16383, 366, 698.46, 16, 0, true, true); //F
                        PlaySound(16383, 366, 554.37, 16, 0, true, true); //Db
                        PlaySound(16383, 366, 466.16, 16, 0, true, true); //Bb - 1
                        PlaySound(16383, 2016, 622.25, 16, 0, true, true);//Eb
                        PlaySound(16383, 366, 554.37, 16, 0, true, true); //Db
                        PlaySound(16383, 366, 622.25, 16, 0, true, true); //Eb 
                        PlaySound(16383, 366, 739.99, 16, 0, true, true); //Gb
                        PlaySound(16383, 366, 1108.73, 16, 0, true, true);//Db + 1
                        PlaySound(16383, 1464, 932.33, 16, 0, true, true);//Bb
                        PlaySound(16383, 366, 698.46, 16, 0, true, true); //F
                        PlaySound(16383, 366, 739.99, 16, 0, true, true); //Gb
                        PlaySound(16383, 366, 830.61, 16, 0, true, true); //Ab
                        PlaySound(16383, 1464, 739.99, 16, 0, true, true);//Gb
                        PlaySound(16383, 366, 932.33, 16, 0, true, true); //Bb
                        PlaySound(16383, 366, 1244.51, 16, 0, true, true);//Eb + 1
                        PlaySound(16383, 366, 1396.91, 16, 0, true, true);//F + 1
                        PlaySound(16383, 366, 1479.98, 16, 0, true, true);//Gb + 1
                        PlaySound(16383, 366, 1864.66, 16, 0, true, true);//Bb + 1
                        PlaySound(16383, 366, 1244.51, 16, 0, true, true);//Eb + 1
                    }
                }
            }
        }


        // Function is heavily modified, but original code is here: https://stackoverflow.com/questions/12611982/generate-audio-tone-to-sound-card-in-c-or-c-sharp
        static void PlaySound(UInt16 volume, int msDuration, Double frequency, short bitsPerSample, int selection, bool wait, bool fade)
        {
            var mStrm = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(mStrm);
            
            const double TAU = 2 * Math.PI;
            int formatChunkSize = 16;
            int headerSize = 8;
            short formatType = 1;
            short tracks = 1;
            int samplesPerSecond = 44100;
            short frameSize = (short)(tracks * ((bitsPerSample + 7) / 8));
            int bytesPerSecond = samplesPerSecond * frameSize;
            int waveSize = 4;
            int samples = (int)((decimal)samplesPerSecond * msDuration / 1000);
            int dataChunkSize = samples * frameSize;
            int fileSize = waveSize + headerSize + formatChunkSize + headerSize + dataChunkSize;
            // var encoding = new System.Text.UTF8Encoding();
            writer.Write(0x46464952); // = encoding.GetBytes("RIFF")
            writer.Write(fileSize);
            writer.Write(0x45564157); // = encoding.GetBytes("WAVE")
            writer.Write(0x20746D66); // = encoding.GetBytes("fmt ")
            writer.Write(formatChunkSize);
            writer.Write(formatType);
            writer.Write(tracks);
            writer.Write(samplesPerSecond);
            writer.Write(bytesPerSecond);
            writer.Write(frameSize);
            writer.Write(bitsPerSample);
            writer.Write(0x61746164); // = encoding.GetBytes("data")
            writer.Write(dataChunkSize);
            {
                double theta = frequency * TAU / (double)samplesPerSecond;
                // 'volume' is UInt16 with range 0 thru Uint16.MaxValue ( = 65 535)
                // we need 'amp' to have the range of 0 thru Int16.MaxValue ( = 32 767)
                double amp = volume >> 2; // so we simply set amp = volume / 2
                for (int step = 0; step < samples; step++)
                {
                    if (selection == 1)
                    {
                        theta += (Math.Pow(1.00002, -step)) / 200;
                    }
                    else if (selection == 2)
                    {
                        theta += Math.Sin(step) / 1000;
                    }
                    else if (selection == 3)
                    {
                        theta += Math.Tan(step) / 10000000;
                    }
                    else if (selection == 4)
                    {
                        theta += Math.Sqrt(step) / 10000000;
                    }

                    //((amp) * (1 / ((step + 0.1) / 1000))

                    double mult = amp;

                    if (fade)
                    {
                        mult = (amp * (1 / ((step + 0.1) / 1000))) - (Math.Pow(1.0002, step) / 10);
                        //mult = amp + ;
                    }

                    if (mult <= 0)
                    {
                        mult = 0;
                    }

                    short s = (short)(mult * Math.Sin(theta * (double)step));

                    writer.Write(s);
                }
            }

            mStrm.Seek(0, SeekOrigin.Begin);
            new System.Media.SoundPlayer(mStrm).Play();
            writer.Close();
            mStrm.Close();

            if (wait)
            {
                System.Threading.Thread.Sleep(msDuration);
            }
        }
    }
}
