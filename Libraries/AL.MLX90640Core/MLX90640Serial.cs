using flyfire.IO.Ports;
using RJCP.IO.Ports;
using System;
using System.Collections.Generic;
using System.Text;

namespace AL.MLX90640Core
{
    public class MLX90640Serial : CustomSerialPort
    {
        public MLX90640Serial(string portName, int baudRate = 115200, Parity parity = Parity.None, int databits = 8, StopBits stopBits = StopBits.One)
                          : base(portName, baudRate, parity, databits, stopBits)
        {

        }
        //无意义，只是因为父类的 Sp_DataReceived() 不是 public
        public void StartMonitotData()
        {

            Sp_DataReceived(new object(), new SerialDataReceivedEventArgs(SerialData.Eof));
        }
    }
}
