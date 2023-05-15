using RASDK.Arm;
using RASDK.Basic.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RASDK.Vision.Zed;
using RASDK.Arm.Type;
using RASDK.Arm;
using System.Threading;

namespace ExclusiveProgram
{
    public class Cupplayer
    {
        private readonly RoboticArm _arm;
        private readonly Zed2i _zedcamera;
        private readonly MessageHandler _messageHandler;


        public Cupplayer(RoboticArm arm,
                        Zed2i zedcamera,
                        MessageHandler messageHandler
                        )
        {
            _arm = arm;
            _zedcamera = zedcamera;
            _messageHandler = messageHandler;
        }



        /// <summary>
        /// Descartes
        /// </summary>
        private double[] TakePhotoPos => new double[] { -0.364, 375.744, 605.998, 20.642, -89.145, -110.038 };

        /// <summary>
        /// Descartes
        /// </summary>
        private double[] AfterTakePhotoPos => new double[] { 369.416, 64.6, -12.071, 154.16, 88.988, 163.806 };

        private double[] ReadyPos => new double[] { -24.677, 321.051, 24.139, -179.268, 3.253, 94.038 };


        private double[] text => new double[] { -40.57, 522.491, 266.666, 154.646, 88.99, -109.692 };




        public void MoveToTakePhotoPos()
        {
            _arm.Speed = 40;
            _arm.MoveAbsolute(TakePhotoPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
        }

        public void MoveToReadyPos()
        {
            _arm.Speed = 40;
            _arm.MoveAbsolute(ReadyPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
        }
        public void MoveToAfterCapturePos()
        {

            _arm.Speed = 40;
            _arm.MoveAbsolute(300.217, 91.007, 24.148, -179.268, 3.251, 16.959, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            _arm.MoveAbsolute(ReadyPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
        }
        

        public void Cup1(AX12 ax12)
        {
            _arm.Speed = 100;
            _arm.MoveAbsolute(ReadyPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelOpen(ax12);

            //對準cup1
            _arm.MoveAbsolute(-24.677, 321.051, 24.139, -179.268, 3.253, 94.038, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });


            //伸進去cup1
            _arm.Speed = 40;
            _arm.MoveAbsolute(-23.194, 554.225, 42.847, 179.781, 3.283, 94.584, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelClose(ax12);
            Thread.Sleep(1000);


            //伸進去後往上抬
            _arm.Speed = 60;
            _arm.MoveAbsolute(-23.196, 554.221, 316.478, 179.782, 3.291, 94.581, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //到放置位置
            _arm.MoveAbsolute(-226.829, 370.409, 282.128, 179.747, 2.477, 115.85, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });


            //在放置位置下降
            _arm.Speed = 40;
            _arm.MoveAbsolute(-226.829, 370.409, 24.469, 179.747, 2.477, 115.85, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            AX12.ParallelOpen(ax12);
            Thread.Sleep(1000);

            //回到放置位置上面
            _arm.Speed = 100;
            _arm.MoveAbsolute(-226.829, 370.409, 282.128, 179.747, 2.477, 115.85, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            //回到拍照點
            _arm.MoveAbsolute(TakePhotoPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            Thread.Sleep(1000);

        }
        public void Cup2(AX12 ax12)
        {
            _arm.Speed = 100;
            _arm.MoveAbsolute(ReadyPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelOpen(ax12);

            //對準cup2
            _arm.MoveAbsolute(83.682, 298.83, 24.118, -179.269, 3.258, 75.056, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });


            //伸進去cup2
            _arm.Speed = 40;
            _arm.MoveAbsolute(83.685, 408.69, 32.638, -179.268, 3.257, 75.058, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelClose(ax12);
            Thread.Sleep(2000);


            //抬高
            _arm.Speed = 60;
            _arm.MoveAbsolute(83.683, 408.693, 266.796, -179.268, 3.256, 75.056, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //移動到放置位置
            _arm.MoveAbsolute(-226.829, 370.409, 282.128, 179.747, 2.477, 115.85, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });


            //下放
            _arm.Speed = 40;
            _arm.MoveAbsolute(-226.829, 370.409, 142.101, 179.747, 2.477, 115.85, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            AX12.ParallelOpen(ax12);
            Thread.Sleep(2000);


            //回到放置位置
            _arm.Speed = 100;
            _arm.MoveAbsolute(-226.829, 370.409, 282.128, 179.747, 2.477, 115.85, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });

            //回到拍照點
            _arm.MoveAbsolute(TakePhotoPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            Thread.Sleep(1000);
        }


        public void Cup3(AX12 ax12)
        {
            _arm.Speed = 100;
            _arm.MoveAbsolute(ReadyPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelOpen(ax12);
            //對準cup3
            _arm.MoveAbsolute(132.624, 315.817, 40.234, -179.268, 3.256, 65.38, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //伸進去cup3
            _arm.Speed = 40;
            _arm.MoveAbsolute(169.802, 419.262, 40.253, -179.268, 3.253, 59.313, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelClose(ax12);
            Thread.Sleep(2000);

            //抬高
            _arm.Speed = 60;
            _arm.MoveAbsolute(169.802, 419.262, 326.778, -179.268, 3.253, 59.313, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //移動到放置位置
            _arm.MoveAbsolute(-226.829, 370.409, 326.778, 179.747, 2.477, 115.85, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //下放
            _arm.Speed = 40;
            _arm.MoveAbsolute(-226.829, 370.409, 182.005, 179.747, 2.477, 115.85, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes,MotionType=MotionType.Linear });
            AX12.ParallelOpen(ax12);
            Thread.Sleep(2000);

            //回到放置位置
            _arm.Speed = 100;
            _arm.MoveAbsolute(-226.829, 370.409, 326.778, 179.747, 2.477, 115.85, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            //回到拍照點
            _arm.MoveAbsolute(TakePhotoPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            Thread.Sleep(1000);
        }

        public void Cup4(AX12 ax12)
        {
            _arm.Speed = 100;
            _arm.MoveAbsolute(ReadyPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelOpen(ax12);

            //對準cup4
            _arm.MoveAbsolute(63.575, 366.252, 43.595, -179.269, 3.256, 79.217, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //伸進去cup4
            _arm.Speed = 40;
            _arm.MoveAbsolute(87.567, 561.134, 43.591, -179.269, 3.254, 76.133, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelClose(ax12);
            Thread.Sleep(2000);

            //抬高
            _arm.Speed = 60;
            _arm.MoveAbsolute(87.567, 561.134, 179.682, -179.269, 3.254, 76.133, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //到中間抬高
            _arm.MoveAbsolute(87.567, 329.159, 374.783, -179.269, 3.254, 76.133, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //到擺放位置
            _arm.MoveAbsolute(-226.829, 370.409, 326.778, 179.747, 2.477, 115.85, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });


            //下放
            _arm.Speed = 40;
            _arm.MoveAbsolute(-226.829, 370.409, 209.653, 179.747, 2.477, 115.85, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes,MotionType=MotionType.Linear });
            AX12.ParallelOpen(ax12);
            Thread.Sleep(2000);

            //回到擺放位置
            _arm.Speed = 100;
            _arm.MoveAbsolute(-226.829, 370.409, 326.778, 179.747, 2.477, 115.85, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes , MotionType = MotionType.Linear });

            //回到拍照點
            _arm.MoveAbsolute(TakePhotoPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            Thread.Sleep(1000);

        }

        public void Cup5(AX12 ax12)
        {
            _arm.Speed = 100;
            _arm.MoveAbsolute(ReadyPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelOpen(ax12);

            ////對準cup5
            _arm.MoveAbsolute(124.685, 413.27, 37.731, -179.269, 3.256, 67.505, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //伸進去cup5
            _arm.Speed = 40;
            _arm.MoveAbsolute(175.514, 580.198, 37.758, -179.268, 3.254, 60.886, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelClose(ax12);
            Thread.Sleep(2000);

            //抬高
            _arm.Speed = 60;
            _arm.MoveAbsolute(175.514, 580.198, 140.958, -179.268, 3.254, 60.886, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //到中間抬高
            _arm.MoveAbsolute(87.567, 329.159, 374.783, -179.269, 3.254, 76.133, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //到擺放位置
            _arm.MoveAbsolute(-226.829, 370.409, 374.783, 179.747, 2.477, 115.85, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });


            //下放
            _arm.Speed = 40;
            _arm.MoveAbsolute(-226.829, 370.409, 206.558, 179.747, 2.477, 115.85, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes,MotionType=MotionType.Linear });
            AX12.ParallelOpen(ax12);
            Thread.Sleep(2000);

            //回到擺放位置
            _arm.Speed = 100;
            _arm.MoveAbsolute(-226.829, 370.409, 374.783, 179.747, 2.477, 115.85, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });

            //回到拍照點
            _arm.MoveAbsolute(TakePhotoPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            Thread.Sleep(1000);

        }
        public void Cup6(AX12 ax12)
        {
            _arm.Speed = 100;
            _arm.MoveAbsolute(ReadyPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelOpen(ax12);

            //對準cup6
            _arm.MoveAbsolute(-83.252, 432.978, 38.16, -179.268, 3.256, 103.386, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //伸進去cup6
            _arm.Speed = 40;
            _arm.MoveAbsolute(-106.75, 573.21, 38.183, -179.268, 3.254, 106.34, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelClose(ax12);
            Thread.Sleep(2000);

            //抬高
            _arm.Speed = 60;
            _arm.MoveAbsolute(-83.252, 432.978, 140.958, -179.268, 3.256, 103.386, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //到中間抬高
            _arm.MoveAbsolute(87.567, 329.159, 374.783, -179.269, 3.254, 76.133, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //到擺放位置
            _arm.MoveAbsolute(-226.829, 370.409, 374.783, 179.747, 2.477, 115.85, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });


            //下放
            _arm.Speed = 40;
            _arm.MoveAbsolute(-226.829, 370.409, 217.217, 179.747, 2.477, 115.85, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes ,MotionType=MotionType.Linear});
            AX12.ParallelOpen(ax12);
            Thread.Sleep(2000);

            //回到擺放位置
            _arm.Speed = 100;
            _arm.MoveAbsolute(-226.829, 370.409, 374.783, 179.747, 2.477, 115.85, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });

            //回到拍照點
            _arm.MoveAbsolute(TakePhotoPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            Thread.Sleep(1000);

        }



        public void Lip1(AX12 ax12)
        {
            _arm.Speed = 100;
            _arm.MoveAbsolute(-45, -6.658, 49.67, 1.064, -42.223, -1.076, new AdditionalMotionParameters { CoordinateType = CoordinateType.Joint });
            _arm.MoveAbsolute(226.894, 228.477, 24.131, -179.268, 3.254, 44.845, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            _arm.MoveAbsolute(ReadyPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelOpen(ax12);

            //對準lip1
            _arm.MoveAbsolute(4.369, 311.505, 54.943, -179.294, -0.292, 89.206, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });


            //伸進去lip1
            _arm.Speed = 40;
            _arm.MoveAbsolute(4.369, 454.532, 54.952, -179.293, -0.294, 89.204, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelClose(ax12);
            Thread.Sleep(2000);

            //抬高
            _arm.MoveAbsolute(4.369, 454.532, 166.651, -179.293, -0.294, 89.204, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });


            //到放置地點
            _arm.MoveAbsolute(191.136, 412.415, 166.656, -179.293, -0.295, 64.889, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //下放
            _arm.MoveAbsolute(191.136, 412.415, -51.815, -179.293, -0.295, 64.889, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            AX12.ParallelOpen(ax12);
            Thread.Sleep(2000);

            //回到放置地點
            _arm.Speed = 80;
            _arm.MoveAbsolute(191.136, 412.415, 166.656, -179.293, -0.295, 64.889, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });

            //回拍照點旁邊
            _arm.MoveAbsolute(-45, -6.658, 49.67, 1.064, -42.223, -1.076, new AdditionalMotionParameters { CoordinateType = CoordinateType.Joint });
            //回拍照點
            _arm.MoveAbsolute(TakePhotoPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            Thread.Sleep(1000);

        }

        public void Lip2(AX12 ax12)
        {
            _arm.Speed = 100;
            _arm.MoveAbsolute(-45, -6.658, 49.67, 1.064, -42.223, -1.076, new AdditionalMotionParameters { CoordinateType = CoordinateType.Joint });
            _arm.MoveAbsolute(226.894, 228.477, 24.131, -179.268, 3.254, 44.845, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            _arm.MoveAbsolute(ReadyPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelOpen(ax12);

            //對準lip2
            _arm.MoveAbsolute(-60.369, 324.493, 60.514, -179.362, 2.032, 100.359, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });


            //伸進去lip2
            _arm.Speed = 40;
            _arm.MoveAbsolute(-79.318, 468.852, 60.514, -179.362, 2.032, 103.549, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelClose(ax12);
            Thread.Sleep(2000);

            //抬高
            _arm.MoveAbsolute(-79.318, 468.852, 170.514, -179.362, 2.032, 103.549, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });


            //到放置地點
            _arm.MoveAbsolute(191.136, 412.415, 166.656, -179.293, -0.295, 64.889, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //下放
            _arm.MoveAbsolute(191.136, 412.415, -51.815, -179.293, -0.295, 64.889, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            AX12.ParallelOpen(ax12);
            Thread.Sleep(2000);

            //回到放置地點
            _arm.Speed = 80;
            _arm.MoveAbsolute(191.136, 412.415, 166.656, -179.293, -0.295, 64.889, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });

            //回拍照點旁邊
            _arm.MoveAbsolute(-45, -6.658, 49.67, 1.064, -42.223, -1.076, new AdditionalMotionParameters { CoordinateType = CoordinateType.Joint });
            //回拍照點
            _arm.MoveAbsolute(TakePhotoPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            Thread.Sleep(1000);
        }
        public void Lip3(AX12 ax12)
        {
            _arm.Speed = 100;
            _arm.MoveAbsolute(-45, -6.658, 49.67, 1.064, -42.223, -1.076, new AdditionalMotionParameters { CoordinateType = CoordinateType.Joint });
            _arm.MoveAbsolute(226.894, 228.477, 24.131, -179.268, 3.254, 44.845, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            _arm.MoveAbsolute(ReadyPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelOpen(ax12);

            //對準lip3
            _arm.MoveAbsolute(-182.984, 353.438, 62.656, 179.92, 3.336, 101.382, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });


            //伸進去lip3
            _arm.Speed = 40;
            _arm.MoveAbsolute(-203.199, 471.639, 62.669, 179.92, 3.334, 104.516, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelClose(ax12);
            Thread.Sleep(2000);

            //抬高
            _arm.MoveAbsolute(-203.199, 471.639, 182.669, 179.92, 3.334, 104.516, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });


            //到放置地點
            _arm.MoveAbsolute(191.136, 412.415, 166.656, -179.293, -0.295, 64.889, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //下放
            _arm.MoveAbsolute(191.136, 412.415, -34.693, -179.293, -0.295, 64.888, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            AX12.ParallelOpen(ax12);
            Thread.Sleep(2000);

            //回到放置地點
            _arm.Speed = 80;
            _arm.MoveAbsolute(191.136, 412.415, 166.656, -179.293, -0.295, 64.889, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });

            //回拍照點旁邊
            _arm.MoveAbsolute(-45, -6.658, 49.67, 1.064, -42.223, -1.076, new AdditionalMotionParameters { CoordinateType = CoordinateType.Joint });
            //回拍照點
            _arm.MoveAbsolute(TakePhotoPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            Thread.Sleep(1000);
        }


        public void Lip4(AX12 ax12)
        {
            _arm.Speed = 100;
            _arm.MoveAbsolute(-45, -6.658, 49.67, 1.064, -42.223, -1.076, new AdditionalMotionParameters { CoordinateType = CoordinateType.Joint });
            _arm.MoveAbsolute(226.894, 228.477, 24.131, -179.268, 3.254, 44.845, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            _arm.MoveAbsolute(ReadyPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelOpen(ax12);

            //對準lip4
            _arm.MoveAbsolute(6.095, 375.086, 95.875, -179.269, 3.253, 89.374, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });


            //伸進去lip4
            _arm.Speed = 40;
            _arm.MoveAbsolute(6.095, 606.325, 95.875, -179.269, 3.253, 89.374, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelClose(ax12);
            Thread.Sleep(2000);

            //抬高
            _arm.MoveAbsolute(6.095, 606.325, 215.875, -179.269, 3.253, 89.374, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });


            //到放置地點
            _arm.MoveAbsolute(191.136, 412.415, 166.656, -179.293, -0.295, 64.889, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //下放
            _arm.MoveAbsolute(191.136, 412.415, -11.943, -179.293, -0.295, 64.888, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            AX12.ParallelOpen(ax12);
            Thread.Sleep(2000);

            //回到放置地點
            _arm.Speed = 80;
            _arm.MoveAbsolute(191.136, 412.415, 166.656, -179.293, -0.295, 64.889, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });

            //回拍照點旁邊
            _arm.MoveAbsolute(-45, -6.658, 49.67, 1.064, -42.223, -1.076, new AdditionalMotionParameters { CoordinateType = CoordinateType.Joint });
            //回拍照點
            _arm.MoveAbsolute(TakePhotoPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            Thread.Sleep(1000);
        }


        public void Lip5(AX12 ax12)
        {
            _arm.Speed = 100;
            _arm.MoveAbsolute(-45, -6.658, 49.67, 1.064, -42.223, -1.076, new AdditionalMotionParameters { CoordinateType = CoordinateType.Joint });
            _arm.MoveAbsolute(226.894, 228.477, 24.131, -179.268, 3.254, 44.845, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            _arm.MoveAbsolute(ReadyPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelOpen(ax12);

            //對準lip5
            _arm.MoveAbsolute(-86.951, 383.118, 95.104, -179.268, 3.255, 102.462, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });


            //伸進去lip5
            _arm.Speed = 40;
            _arm.MoveAbsolute(-86.952, 609.296, 95.113, -179.268, 3.253, 102.463, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelClose(ax12);
            Thread.Sleep(2000);

            //抬高
            _arm.MoveAbsolute(-86.952, 609.296, 215.113, -179.268, 3.253, 102.463, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });


            //到放置地點
            _arm.MoveAbsolute(191.136, 412.415, 166.656, -179.293, -0.295, 64.889, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //下放
            _arm.MoveAbsolute(191.136, 412.415, -8.893, -179.293, -0.295, 64.888, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            AX12.ParallelOpen(ax12);
            Thread.Sleep(2000);

            //回到放置地點
            _arm.Speed = 80;
            _arm.MoveAbsolute(191.136, 412.415, 166.656, -179.293, -0.295, 64.889, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });

            //回拍照點旁邊
            _arm.MoveAbsolute(-45, -6.658, 49.67, 1.064, -42.223, -1.076, new AdditionalMotionParameters { CoordinateType = CoordinateType.Joint });
            //回拍照點
            _arm.MoveAbsolute(TakePhotoPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            Thread.Sleep(1000);
        }

        public void Lip6(AX12 ax12)
        {
            _arm.Speed = 100;
            _arm.MoveAbsolute(-45, -6.658, 49.67, 1.064, -42.223, -1.076, new AdditionalMotionParameters { CoordinateType = CoordinateType.Joint });
            _arm.MoveAbsolute(226.894, 228.477, 24.131, -179.268, 3.254, 44.845, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            _arm.MoveAbsolute(ReadyPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelOpen(ax12);

            //對準lip6
            _arm.MoveAbsolute(-196.658, 376.035, 93.965, -179.772, 3.32, 107.47, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });


            //伸進去lip6
            _arm.Speed = 40;
            _arm.MoveAbsolute(-196.651, 609.538, 93.952, -179.772, 3.322, 107.47, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes,MotionType=MotionType.Linear });
            AX12.ParallelClose(ax12);
            Thread.Sleep(2000);

            //抬高
            _arm.MoveAbsolute(-196.651, 609.538, 150.967, -179.772, 3.322, 107.47, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });


            //到放置地點
            _arm.MoveAbsolute(191.136, 412.415, 166.656, -179.293, -0.295, 64.889, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //下放
            _arm.MoveAbsolute(191.136, 412.415, -5.993, -179.293, -0.295, 64.888, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            AX12.ParallelOpen(ax12);
            Thread.Sleep(2000);

            //回到放置地點
            _arm.Speed = 80;
            _arm.MoveAbsolute(191.136, 412.415, 166.656, -179.293, -0.295, 64.889, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });

            //回拍照點旁邊
            _arm.MoveAbsolute(-45, -6.658, 49.67, 1.064, -42.223, -1.076, new AdditionalMotionParameters { CoordinateType = CoordinateType.Joint });
            //回拍照點
            _arm.MoveAbsolute(TakePhotoPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            Thread.Sleep(1000);
        }



        public void PutLip1(AX12 ax12)
        {
            _arm.Speed = 100;
            _arm.MoveAbsolute(-45, -6.658, 49.67, 1.064, -42.223, -1.076, new AdditionalMotionParameters { CoordinateType = CoordinateType.Joint });
            _arm.MoveAbsolute(226.894, 228.477, 24.131, -179.268, 3.254, 44.845, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            _arm.MoveAbsolute(ReadyPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelOpen(ax12);

            //對準cup1
            _arm.MoveAbsolute(12.082, 325.776, 28.353, -179.268, 3.257, 87.498, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //伸進去cup1
            _arm.Speed = 40;
            _arm.MoveAbsolute(12.082, 425.476, 28.353, -179.268, 3.257, 87.498, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            AX12.ParallelClose(ax12);
            Thread.Sleep(1000);

            //抬高
            _arm.MoveAbsolute(12.082, 425.476, 245.253, -179.268, 3.257, 87.498, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });

            //到指定地點
            _arm.MoveAbsolute(-28, -10.199, 2.941, 0.775, -85.99, 0.663, new AdditionalMotionParameters { CoordinateType = CoordinateType.Joint });
            _arm.MoveAbsolute(198.8, 507.464, 245.238, -179.267, 3.259, 61.283, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //下放
            _arm.MoveAbsolute(198.802, 507.468, 22.717, -179.268, 3.26, 61.286, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            AX12.ParallelOpen(ax12);
            Thread.Sleep(1000);



            //回ReadyPos
            _arm.Speed = 100;
            _arm.MoveAbsolute(-24.624, -29.958, -9.822, 1.198, -53.431, -3.918, new AdditionalMotionParameters { CoordinateType = CoordinateType.Joint });
            _arm.MoveAbsolute(ReadyPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelOpen(ax12);

            //對準lip1
            _arm.MoveAbsolute(12.62, 406.425, -40.38, -179.268, 3.255, 87.513, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //伸進去lip1
            _arm.Speed = 40;
            _arm.MoveAbsolute(12.62, 572.716, -40.38, -179.268, 3.255, 87.513, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            AX12.ParallelClose(ax12);
            Thread.Sleep(1000);

            //抬高
            _arm.MoveAbsolute(12.62, 572.716, 160.38, -179.268, 3.255, 87.513, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });

            //到指定地點
            _arm.MoveAbsolute(198.8, 507.464, 245.238, -179.267, 3.259, 61.283, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //下放
            _arm.MoveAbsolute(198.799, 511.708, 99.11, -179.267, 3.26, 61.287, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            AX12.ParallelOpen(ax12);
            Thread.Sleep(1000);

            //回到蓋子上方
            _arm.MoveAbsolute(198.8, 507.464, 150, -179.267, 3.259, 61.283, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });

            //壓中間

            _arm.MoveAbsolute(223.994, 580.832, 150.002, -179.267, 3.258, 58.336, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            _arm.MoveAbsolute(223.994, 580.832, 115.238, -179.267, 3.258, 58.336, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            Thread.Sleep(500);
            _arm.MoveAbsolute(223.994, 580.832, 150.002, -179.267, 3.258, 58.336, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });


            //壓前面
            _arm.MoveAbsolute(246.519, 593.681, 165.849, -179.265, 3.257, 56.152, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            _arm.MoveAbsolute(246.531, 593.681, 114.406, -179.266, 3.262, 56.153, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            Thread.Sleep(500);
            _arm.MoveAbsolute(246.519, 593.681, 140.849, -179.265, 3.257, 56.152, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });

            //壓後面
            _arm.MoveAbsolute(223.995, 545.7, 154.817, -179.268, 3.261, 58.333, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            _arm.MoveAbsolute(223.995, 545.37, 109.608, -179.268, 3.261, 58.333, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            Thread.Sleep(500);
            _arm.MoveAbsolute(223.995, 545.7, 154.817, -179.268, 3.261, 58.333, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });


            //回拍照位置
            _arm.Speed = 100;
            _arm.MoveAbsolute(TakePhotoPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            Thread.Sleep(1000);

        }
        public void PutLip2(AX12 ax12)
        {
            _arm.Speed = 100;
            _arm.MoveAbsolute(-45, -6.658, 49.67, 1.064, -42.223, -1.076, new AdditionalMotionParameters { CoordinateType = CoordinateType.Joint });
            _arm.MoveAbsolute(226.894, 228.477, 24.131, -179.268, 3.254, 44.845, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            _arm.MoveAbsolute(ReadyPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelOpen(ax12);

            //對準cup1
            _arm.MoveAbsolute(-89.668, 342.818, 33.338, -179.268, 3.254, 105.09, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //伸進去cup1
            _arm.Speed = 40;
            _arm.MoveAbsolute(-89.668, 434.299, 33.338, -179.268, 3.254, 105.09, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            AX12.ParallelClose(ax12);
            Thread.Sleep(1000);

            //抬高
            _arm.MoveAbsolute(-89.668, 434.299, 250, -179.268, 3.254, 105.09, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });

            //到指定地點
            _arm.MoveAbsolute(-13, -13.282, 7.45, 0.531, -87.461, -3.546, new AdditionalMotionParameters { CoordinateType = CoordinateType.Joint });
            _arm.MoveAbsolute(98.976, 494.856, 250, -179.268, 3.254, 80.528, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //下放
            _arm.MoveAbsolute(91.417, 498.384, 27.955, -179.268, 3.256, 81.528, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            AX12.ParallelOpen(ax12);
            Thread.Sleep(1000);

            //往後
            _arm.Speed = 100;
            _arm.MoveAbsolute(91.417, 300, 27.955, -179.268, 3.256, 81.528, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });

            //回ReadyPos
       
            _arm.MoveAbsolute(ReadyPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelOpen(ax12);

            //對準lip1
            _arm.MoveAbsolute(-77.146, 372.109, -38.413, -179.268, 3.256, 101.48, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //伸進去lip1
            _arm.Speed = 40;
            _arm.MoveAbsolute(-77.146, 577.199, -38.413, -179.268, 3.256, 101.48, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            AX12.ParallelClose(ax12);
            Thread.Sleep(1000);

            //抬高
            _arm.MoveAbsolute(-77.146, 577.199, 180, -179.268, 3.256, 101.48, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });

            //到指定地點
            _arm.MoveAbsolute(97.573, 497.917, 180, -179.268, 3.258, 83.942, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //下放
            _arm.MoveAbsolute(97.573, 497.917, 98.907, -179.268, 3.258, 83.942, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            AX12.ParallelOpen(ax12);
            Thread.Sleep(1000);

            //回到蓋子上方
            _arm.MoveAbsolute(97.573, 497.917, 180, -179.268, 3.258, 83.942, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });

            //壓中間

            _arm.MoveAbsolute(97.571, 570.526, 161.158, -179.268, 3.26, 83.941, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            _arm.MoveAbsolute(97.571, 570.527, 112.662, -179.268, 3.26, 83.941, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            Thread.Sleep(500);
            _arm.MoveAbsolute(97.571, 570.526, 161.158, -179.268, 3.26, 83.941, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });


            //壓前面
            _arm.MoveAbsolute(97.571, 605.646, 152.165, -179.268, 3.26, 83.941, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            _arm.MoveAbsolute(97.571, 605.646, 112.8, -179.268, 3.26, 83.941, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            Thread.Sleep(500);
            _arm.MoveAbsolute(97.571, 605.646, 152.165, -179.268, 3.26, 83.941, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });

            //壓後面
            _arm.MoveAbsolute(97.571, 546.139, 142.717, -179.268, 3.26, 83.941, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            _arm.MoveAbsolute(97.571, 546.139, 112.749, -179.268, 3.26, 83.941, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            Thread.Sleep(500);
            _arm.MoveAbsolute(97.571, 546.139, 142.717, -179.268, 3.26, 83.941, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });

            //回拍照位置
            _arm.Speed = 100;
            _arm.MoveAbsolute(TakePhotoPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            Thread.Sleep(1000);


        }
        public void PutLip3(AX12 ax12)
        {
            _arm.Speed = 100;
            _arm.MoveAbsolute(-45, -6.658, 49.67, 1.064, -42.223, -1.076, new AdditionalMotionParameters { CoordinateType = CoordinateType.Joint });
            _arm.MoveAbsolute(226.894, 228.477, 24.131, -179.268, 3.254, 44.845, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            _arm.MoveAbsolute(ReadyPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelOpen(ax12);

            //對準cup3
            _arm.MoveAbsolute(33, -17.136, -26.655, -1.08, -49.439, 25.308, new AdditionalMotionParameters { CoordinateType = CoordinateType.Joint });

            //伸進去cup3
            _arm.Speed = 40;
            _arm.MoveAbsolute(-215.175, 427.904, 33.521, 177.91, 2.592, 98.371, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            AX12.ParallelClose(ax12);
            Thread.Sleep(1000);

            //抬高
            _arm.MoveAbsolute(-215.175, 427.904, 250, 177.91, 2.592, 98.371, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });

            //到指定地點
            _arm.MoveAbsolute(-38.028, 484.78, 250, 177.91, 2.592, 98.371, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //下放
            _arm.MoveAbsolute(-38.028, 484.78, 24.849, 177.91, 2.592, 98.371, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            AX12.ParallelOpen(ax12);
            Thread.Sleep(1000);

            //往後
            _arm.Speed = 100;
            _arm.MoveAbsolute(-38.028, 398.943, 24.849, 177.91, 2.592, 98.371, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });

            //回ReadyPos
            _arm.MoveAbsolute(ReadyPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelOpen(ax12);

            //對準lip1
            _arm.MoveAbsolute(-200.591, 413.739, -40.096, 179.449, 3.29, 101.101, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //伸進去lip1
            _arm.Speed = 40;
            _arm.MoveAbsolute(-200.591, 575.014, -40.096, 179.449, 3.29, 101.101, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            AX12.ParallelClose(ax12);
            Thread.Sleep(1000);

            //抬高
            _arm.MoveAbsolute(-200.591, 575.014, 180, 179.449, 3.29, 101.101, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });

            //到指定地點
            _arm.MoveAbsolute(-38.028, 484.78, 250, 177.91, 2.592, 98.371, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //下放
            _arm.MoveAbsolute(-38.028, 488.358, 97.079, 177.91, 2.592, 98.371, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            AX12.ParallelOpen(ax12);
            Thread.Sleep(1000);

            //回到蓋子上方
            _arm.MoveAbsolute(-38.028, 484.78, 250, 177.91, 2.592, 98.371, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });

            //壓中間

            _arm.MoveAbsolute(-38.027, 561.845, 165.164, 177.91, 2.594, 98.371, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            _arm.MoveAbsolute(-38.027, 564.645, 113.067, 177.91, 2.594, 98.371, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            Thread.Sleep(500);
            _arm.MoveAbsolute(-38.027, 561.845, 165.164, 177.91, 2.594, 98.371, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });



            //壓前面
            _arm.MoveAbsolute(-38.027, 591.789, 145.554, 177.91, 2.594, 98.371, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            _arm.MoveAbsolute(-38.027, 591.789, 111.878, 177.91, 2.594, 98.371, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            Thread.Sleep(500);
            _arm.MoveAbsolute(-38.027, 591.789, 145.554, 177.91, 2.594, 98.371, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });


            //壓後面
            _arm.MoveAbsolute(-38.027, 523.202, 148.472, 177.91, 2.594, 98.371, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            _arm.MoveAbsolute(-38.027, 523.202, 108.572, 177.91, 2.594, 98.371, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            Thread.Sleep(500);
            _arm.MoveAbsolute(-38.027, 523.202, 148.472, 177.91, 2.594, 98.371, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });

            //回拍照位置
            _arm.Speed = 100;
            _arm.MoveAbsolute(TakePhotoPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            Thread.Sleep(1000);


        }

        public void Test(AX12 ax12)
        {
            _arm.Speed = 100;
            _arm.MoveAbsolute(-45, -6.658, 49.67, 1.064, -42.223, -1.076, new AdditionalMotionParameters { CoordinateType = CoordinateType.Joint });
            _arm.MoveAbsolute(226.894, 228.477, 24.131, -179.268, 3.254, 44.845, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            _arm.MoveAbsolute(ReadyPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelOpen(ax12);

            //對準cup3
            _arm.MoveAbsolute(-35.536, 394.545, 42.535, -179.268, 3.253, 95.481, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //伸進去cup3
            _arm.Speed = 60;
            _arm.MoveAbsolute(-35.536, 485.969, 42.535, -179.268, 3.253, 95.481, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            AX12.ParallelClose(ax12);
            Thread.Sleep(1000);

            //夾起來
            _arm.MoveAbsolute(-35.536, 485.969, 262.535, -179.268, 3.253, 95.481, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });


            //晃
            _arm.MoveAbsolute(4.067, -20, 19.927, 90, -91.925, -1.39, new AdditionalMotionParameters { CoordinateType = CoordinateType.Joint });
            _arm.MoveAbsolute(4.067, -20, 19.927, -90, -91.925, -1.39, new AdditionalMotionParameters { CoordinateType = CoordinateType.Joint });
            _arm.MoveAbsolute(4.067, -20, 19.927, 0, -91.925, -1.39, new AdditionalMotionParameters { CoordinateType = CoordinateType.Joint });

            //回到伸進去的點
            _arm.MoveAbsolute(-35.536, 485.969, 42.535, -179.268, 3.253, 95.481, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            AX12.ParallelOpen(ax12);
            Thread.Sleep(1000);

            //回到對準點
            _arm.Speed = 100;
            _arm.MoveAbsolute(-35.536, 394.545, 42.535, -179.268, 3.253, 95.481, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //回到準備位
            _arm.MoveAbsolute(ReadyPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });





            _arm.Speed = 100;
            _arm.MoveAbsolute(ReadyPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelOpen(ax12);

            //對準cup2
            _arm.MoveAbsolute(79.805, 395.453, 42.085, -179.268, 3.255, 76.756, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //伸進去cup2
            _arm.Speed = 60;
            _arm.MoveAbsolute(79.805, 494.991, 42.085, -179.268, 3.255, 76.756, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelClose(ax12);
            Thread.Sleep(1000);

            //抬高
            _arm.MoveAbsolute(79.805, 395.453, 260, -179.268, 3.255, 76.756, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            //晃
            _arm.MoveAbsolute(-11.586, -6.425, 1.105, 90, -87.913, 1.625, new AdditionalMotionParameters { CoordinateType = CoordinateType.Joint });
            _arm.MoveAbsolute(-11.586, -6.425, 1.105, -90, -87.913, 1.625, new AdditionalMotionParameters { CoordinateType = CoordinateType.Joint });
            _arm.MoveAbsolute(-11.586, -6.425, 1.105, 0, -87.913, 1.625, new AdditionalMotionParameters { CoordinateType = CoordinateType.Joint });

            //回到伸進去的位置
            _arm.MoveAbsolute(79.805, 494.991, 42.085, -179.268, 3.255, 76.756, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            AX12.ParallelOpen(ax12);
            Thread.Sleep(1000);

            //回到對準位
            _arm.Speed = 100;
            _arm.MoveAbsolute(79.805, 395.453, 42.085, -179.268, 3.255, 76.756, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });
            //回準備位置
            _arm.MoveAbsolute(ReadyPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

            AX12.ParallelOpen(ax12);

            //對準cup1
            _arm.MoveAbsolute(-24.624, -29.958, -9.822, 1.198, -53.431, -3.918, new AdditionalMotionParameters { CoordinateType = CoordinateType.Joint });

            //伸進cup1
            _arm.Speed = 60;
            _arm.MoveAbsolute(198.802, 507.468, 34.744, -179.268, 3.26, 61.286, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            AX12.ParallelClose(ax12);
            Thread.Sleep(1000);

            //抬高
            _arm.MoveAbsolute(198.802, 507.468, 243.613, -179.268, 3.26, 61.286, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });


            //晃
            _arm.MoveAbsolute(-21.572, -32.387, 32.867, 60, -93.625, 7.199, new AdditionalMotionParameters { CoordinateType = CoordinateType.Joint });
            _arm.MoveAbsolute(-21.572, -32.387, 32.867, -60, -93.625, 7.199, new AdditionalMotionParameters { CoordinateType = CoordinateType.Joint });
            _arm.MoveAbsolute(-21.572, -32.387, 32.867, 1.134, -93.625, 7.199, new AdditionalMotionParameters { CoordinateType = CoordinateType.Joint });

            //回到伸進去
            _arm.Speed = 100;
            _arm.MoveAbsolute(198.802, 507.468, 34.744, -179.268, 3.26, 61.286, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes, MotionType = MotionType.Linear });
            AX12.ParallelOpen(ax12);
            Thread.Sleep(1000);

            //回到對準
            _arm.MoveAbsolute(-24.624, -29.958, -9.822, 1.198, -53.431, -3.918, new AdditionalMotionParameters { CoordinateType = CoordinateType.Joint });

            //回到準備位
            _arm.MoveAbsolute(ReadyPos, new AdditionalMotionParameters { CoordinateType = CoordinateType.Descartes });

        }
    }
}
