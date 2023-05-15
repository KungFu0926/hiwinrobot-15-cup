using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExclusiveProgram
{
    public class AX12
    {
        private readonly SerialPort _serialPort;
        private readonly int _serialPortBaudrate= 1000000;
        private readonly int _id;
        public int _maxPos;
        public int _minPos;




        public AX12(SerialPort serialPort, int id)
        {
            if (_id < 0 || _id > 254)
            {
                throw new ArgumentOutOfRangeException("馬達ID超出允許範圍 (0 ~ 254，254為全體廣播ID)。");
            }
            //張開
            _maxPos = 820;
            //閉合
            _minPos = 250; 

            _serialPort = serialPort;
            _id = id;
        }


        /// <summary>
        /// Left=260~512
        /// Right=512~764
        /// 平行夾爪250(開)~835(閉)
        /// </summary>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void ControlAX12( int position, int speed)
        {
            _serialPort.Open();
            _serialPort.BaudRate = _serialPortBaudrate;
            // 避免數值超出允許範圍。

            if (position > _maxPos)
            {
                position = _maxPos;
            }
            else if (position < _minPos)
            {
                position = _minPos;
            }

            if (speed > 1023)
            {
                speed = 1023;
            }
            else if (speed < 0)
            {
                speed = 0;
            }

            // 建立資料封包。
            // 官方說明：https://emanual.robotis.com/docs/en/dxl/protocol1/#instruction-packet
            byte[] dataPackage = new byte[11];
            dataPackage[0] = 0xFF;     // 標頭1 (Header1)，固定為0xFF。
            dataPackage[1] = 0xFF;     // 標頭2 (Header2)，固定為0xFF。
            dataPackage[2] = (byte)_id; // 封包傳送的ID (Packet ID)。
            dataPackage[3] = (byte)7;  // 長度 (Length)，其數值為參數位元組數量+3。
            dataPackage[4] = 0x03;     // 指令 (Instruction)，0x03為"Write"指令。
            dataPackage[5] = (byte)30; // 起始地址 (Starting address)。地址"30"對應的是"Goal Position"。
            dataPackage[6] = (byte)(position & 0xFF); // "Goal Position"參數位元組1 (低8位元)。
            dataPackage[7] = (byte)(position >> 8);   // "Goal Position"參數位元組2 (高8位元)。
            dataPackage[8] = (byte)(speed & 0xFF);    // "Moving Speed"參數位元組1 (低8位元)。
            dataPackage[9] = (byte)(speed >> 8);      // "Moving Speed"參數位元組2 (高8位元)。

            // 計算校驗和 (Checksum)。
            byte a = 0;
            for (int i = 2; i < 10; i++)
            {
                a += dataPackage[i];
            }
            dataPackage[10] = (byte)(0xFF - a);

            try
            {
                _serialPort.Write(dataPackage, 0, dataPackage.Length); // 傳送。
                Thread.Sleep(1); // Delay 1 ms.
            }
            catch (Exception ex)
            {
                MessageBox.Show($"傳送封包時出錯。\r\n{ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            _serialPort.Close();
        }

        public static void ParallelOpen(AX12 ax12)
        {
            ax12.ControlAX12(820,200);
        }


        public static void ParallelClose(AX12 ax12)
        {
            //680
            ax12.ControlAX12(250, 100); 
        }

    }
}
