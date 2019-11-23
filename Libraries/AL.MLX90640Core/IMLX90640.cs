using System;

namespace AL.MLX90640Core
{
    public interface IMLX90640
    {
        public void GetSerial();
        public void Init(string portname, Action<byte[]> ReciveDataFunc);
        public void Write(string str);
        public void Close();

        public Boolean IsOpen();
    }
}
