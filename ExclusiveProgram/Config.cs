﻿using System;

namespace ExclusiveProgram
{
    public class Config : MainForm.Config
    {
        public override string ArmIp => "192.168.0.3";

        public override bool ArmEnable => true;

        public override string GripperComPort => "COM5";

        public override bool GripperEnable => false;
    }
}
