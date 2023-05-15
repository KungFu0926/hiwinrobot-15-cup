using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RASDK.Arm;
using RASDK.Basic;
using RASDK.Basic.Message;
using RASDK.Gripper;
using RASDK.Vision.Zed;

namespace ExclusiveProgram
{
    public partial class Control : MainForm.ExclusiveControl
    {
        SerialPort serialPort = new SerialPort("COM5");
        private Cupplayer _cupPlayer;
        private Zed2i _zedcamera;
        private MessageHandler _messageHandler;
        public Control()
        {
            InitializeComponent();
            Config = new Config();
        }






        private void InitButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Zed相機開啟
                if (_zedcamera == null)
                {
                    _zedcamera = new Zed2i();
                }

                if (_zedcamera.Connected == false)
                {
                    _zedcamera.Connect();
                }
                _cupPlayer = new Cupplayer(Arm, _zedcamera, _messageHandler);
            }

            catch (Exception ex)
            {
                MessageHandler.Show(ex, LoggingLevel.Error);
            }
            textBoxMain.AppendText("Init 完成\r\n");

        }

        private void GripCupButton_Click(object sender, EventArgs e)
        {
            AX12.ParallelClose(new AX12(serialPort,3)); ;
        }





        private void ToTakePhotoPosButton_Click(object sender, EventArgs e)
        {
            _cupPlayer.MoveToTakePhotoPos();
        }

        private void ToOriginPos_Click(object sender, EventArgs e)
        {
            _cupPlayer.MoveToAfterCapturePos();
            textBoxMain.AppendText("At OriginPos\r\n");
        }




        private void ToReadyPos_Click(object sender, EventArgs e)
        {
            _cupPlayer.MoveToReadyPos();
        }

        private void Open_Click(object sender, EventArgs e)
        {
            AX12.ParallelOpen(new AX12(serialPort, 3));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AX12 axid3 = new AX12(serialPort,3);
            _cupPlayer.Cup1(axid3);
        }

        private void Cup2_Click(object sender, EventArgs e)
        {
            AX12 axid3 = new AX12(serialPort, 3);
            _cupPlayer.Cup2(axid3);
        }

        private void Cup3_Click(object sender, EventArgs e)
        {
            AX12 axid3 = new AX12(serialPort, 3);
            _cupPlayer.Cup3(axid3);
        }

        private void Cup4_Click(object sender, EventArgs e)
        {
            AX12 axid3 = new AX12(serialPort, 3);
            _cupPlayer.Cup4(axid3);
        }

        private void Cup5_Click(object sender, EventArgs e)
        {
            AX12 axid3 = new AX12(serialPort, 3);
            _cupPlayer.Cup5(axid3);
        }

        private void Cup6_Click(object sender, EventArgs e)
        {
            AX12 axid3 = new AX12(serialPort, 3);
            _cupPlayer.Cup6(axid3);
        }

        private void ALL_Click(object sender, EventArgs e)
        {
            AX12 axid3 = new AX12(serialPort, 3);
            _cupPlayer.Cup1(axid3);
            _cupPlayer.Cup2(axid3);
            _cupPlayer.Cup3(axid3);
            _cupPlayer.Cup4(axid3);
            _cupPlayer.Cup5(axid3);
            _cupPlayer.Cup6(axid3);

        }

        private void Lip1_Click(object sender, EventArgs e)
        {
            AX12 axid3 = new AX12(serialPort, 3);
            _cupPlayer.Lip1(axid3);
        }



        private void Lip2_Click(object sender, EventArgs e)
        {
            AX12 axid3 = new AX12(serialPort, 3);
            _cupPlayer.Lip2(axid3);
        }

        private void GripLip_Click(object sender, EventArgs e)
        {
            AX12 axid3 = new AX12(serialPort, 3);
            AX12.ParallelClose(axid3);

        }

        private void Lip3_Click(object sender, EventArgs e)
        {
            AX12 axid3 = new AX12(serialPort, 3);
            _cupPlayer.Lip3(axid3);
        }

        private void Lip4_Click(object sender, EventArgs e)
        {
            AX12 axid3 = new AX12(serialPort, 3);
            _cupPlayer.Lip4(axid3);
        }

        private void Lip5_Click(object sender, EventArgs e)
        {
            AX12 axid3 = new AX12(serialPort, 3);
            _cupPlayer.Lip5(axid3);
        }

        private void Lip6_Click(object sender, EventArgs e)
        {
            AX12 axid3 = new AX12(serialPort, 3);
            _cupPlayer.Lip6(axid3);
        }

        private void ALL2_Click(object sender, EventArgs e)
        {
            AX12 axid3 = new AX12(serialPort, 3);
            _cupPlayer.Lip1(axid3);
            _cupPlayer.Lip2(axid3);
            _cupPlayer.Lip3(axid3);
            _cupPlayer.Lip4(axid3);
            _cupPlayer.Lip5(axid3);
            _cupPlayer.Lip6(axid3);
        }

        private void PutLip_Click(object sender, EventArgs e)
        {
            AX12 axid3 = new AX12(serialPort, 3);
            _cupPlayer.PutLip1(axid3);
        }


        private void PutLip2_Click(object sender, EventArgs e)
        {
            AX12 axid3 = new AX12(serialPort, 3);
            _cupPlayer.PutLip2(axid3);
        }

        private void PutLip3_Click(object sender, EventArgs e)
        {
            AX12 axid3 = new AX12(serialPort, 3);
            _cupPlayer.PutLip3(axid3);
        }


        private void Test_Click(object sender, EventArgs e)
        {
            AX12 axid3 = new AX12(serialPort, 3);
            _cupPlayer.Test(axid3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AX12 axid3 = new AX12(serialPort, 3);
            //_cupPlayer.PutLip1(axid3);
            //_cupPlayer.PutLip2(axid3);
            //_cupPlayer.PutLip3(axid3);
            //_cupPlayer.Test(axid3);
            axid3.ControlAX12(270,50);
        }
    }
}
