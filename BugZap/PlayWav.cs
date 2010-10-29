//  Code for playing WAV files from : http://grouplab.cpsc.ucalgary.ca/cookbook/index.php?n=Toolkits.HowToPlayAWAVFile
 
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;

namespace PlayWav
{

    // Flags for playing sounds.  For this example, we are reading
    // the sound from a filename, so we need only specify
    // SND_FILENAME | SND_ASYNC
    [Flags]
    public enum SoundFlags : int
    {
        SND_SYNC = 0x0000,  // play synchronously (default)
        SND_ASYNC = 0x0001,  // play asynchronously
        SND_NODEFAULT = 0x0002,  // silence (!default) if sound not found
        SND_MEMORY = 0x0004,  // pszSound points to a memory file
        SND_LOOP = 0x0008,  // loop the sound until next sndPlaySound
        SND_NOSTOP = 0x0010,  // don't stop any currently playing sound
        SND_NOWAIT = 0x00002000, // don't wait if the driver is busy
        SND_ALIAS = 0x00010000, // name is a registry alias
        SND_ALIAS_ID = 0x00110000, // alias is a predefined ID
        SND_FILENAME = 0x00020000, // name is file name
        SND_RESOURCE = 0x00040004  // name is resource name or atom
    }

    /// <summary>
    /// Summary description for PlayWav.
    /// </summary>
    public class PlayWav
    {
        // PlaySound()
        [DllImport("winmm.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        static extern bool PlaySound(string pszSound, IntPtr hMod, SoundFlags sf);

        public PlayWav()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void Play(string filename)
        {
            FileInfo fi = new FileInfo(filename);
            Play(fi);
        }

        public static void Play(FileInfo fi)
        {
            if (fi.Exists == false)
            {
                MessageBox.Show("Sound file not found!");
                return;
            }
            if (fi.Extension.ToLower().Equals(".wav") == false)
            {
                MessageBox.Show("Not a WAV file!");
                return;
            }

            PlaySound(fi.FullName, IntPtr.Zero, SoundFlags.SND_FILENAME | SoundFlags.SND_ASYNC);
        }
    }
}