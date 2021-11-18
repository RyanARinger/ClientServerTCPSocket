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
        public DummyMaker(string filename)
        {
            this.Filename = filename;
            
        }
        public void MakeFile(long nBytes)
        {
            if (nBytes > 1000000000L)
            {
                nBytes = 1000000000L;
            }
            FileStream fs = new FileStream(this.Filename, FileMode.CreateNew);
            fs.Seek(nBytes, SeekOrigin.Begin);
            fs.WriteByte(0);
            fs.Close();
        }

        public byte[] getBytes()
        {
            return File.ReadAllBytes(this.Filename);

        }
    }
}
