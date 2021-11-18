using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ServerAppTest
{
    class DummyMaker
    {
        public string Filename { get; set; }
        public FileStream Fs { get; set; }
        public DummyMaker(string filename)
        {
            this.Filename = filename;
            this.Fs = File.Create(this.Filename);
            
        }
        public void MakeFile(long nBytes)
        {
            if (nBytes > 1000000000L)
            {
                nBytes = 1000000000L;
            }
            this.Fs.Seek(nBytes, SeekOrigin.Begin);
            this.Fs.WriteByte(0);
            this.Fs.Close();
        }

        public byte[] getBytes()
        {
            return File.ReadAllBytes(this.Filename);

        }

        ~DummyMaker()
        {
            this.Fs.Close();
        }
    }
}
