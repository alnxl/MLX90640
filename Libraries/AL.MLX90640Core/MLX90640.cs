using System;
using System.Collections.Generic;
using System.Text;
using flyfire.IO.Ports;
using RJCP.IO.Ports;
using System.Threading;
using System.Threading.Tasks;

namespace AL.MLX90640Core
{
    public class MLX90640 : IMLX90640
    {
        Boolean IsOpend = false;
        static Action<byte[]> mLX_ReciveDataFunc;
        MLX90640Serial mLX;
        public void GetSerial()
        {
            //CustomSerialPort.GetPortNames() 静态方法，获取计算机的所有串口名称
            //因为已经继承，也可以使用 string[] vs = 串口通讯.GetPortNames();
            string[] vs = CustomSerialPort.GetPortNames();
            Console.WriteLine("Serial List：");
            foreach (var i in vs)
            {
                Console.WriteLine(i);
            }
        }
        public void Init(string portname,Action<byte[]> ReciveDataFunc)
        {
            mLX = new MLX90640Serial(portname);
            mLX_ReciveDataFunc = ReciveDataFunc;
            if(mLX.Open())
            {
                IsOpend = true;
                StartMonitor();
            }
        }
        public void Close()
        {
            if (mLX.IsOpen)
            {
                mLX.Close();
                IsOpend = false;
                mLX.Dispose();
            }
        }
        public void Write(string str)
        {
            //方式 1
            mLX.Write(str);
            Console.WriteLine("已经向串口输入：" + str);
            Thread.Sleep(500);
        }
        public void StartMonitor()
        {
            //收到消息时要触发的事件
            mLX.ReceivedEvent += RecivedData;
            mLX.StartMonitotData();
        }
        public static void RecivedData(object sender, byte[] bytes)
        {
            Task.Run(() => {
                mLX_ReciveDataFunc.Invoke(bytes);
            });
        }

        public bool IsOpen()
        {
            return this.IsOpend;
        }
    }
}
