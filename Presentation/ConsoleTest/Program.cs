using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            AL.MLX90640Core.IMLX90640 mLX90640 = new AL.MLX90640Core.MLX90640();
            //mLX90640.GetSerial();
            string portname = "COM5";
            mLX90640.Init(portname);
            while (true)
            {
                string str = Console.ReadLine();
                if (str == "exit")
                {
                    //步骤 3
                    mLX90640.Close();
                    break;
                }
            }

            Console.WriteLine("串口已经关闭");
            Console.ReadLine();
        }
    }
}
