﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanCtrl
{
    public class RGBnFCControl : BaseControl
    {
        private RGBnFC mRGBnFC = null;
        private int mIndex = 0;

        public RGBnFCControl(RGBnFC fc, int index, uint num) : base()
        {
            mRGBnFC = fc;
            mIndex = index;
            Name = "NZXT RGB＆Fan #" + num;
        }

        public override void update()
        {

        }

        public override int getMinSpeed()
        {
            return mRGBnFC.getMinFanSpeed(mIndex);
        }

        public override int getMaxSpeed()
        {
            return mRGBnFC.getMaxFanSpeed(mIndex);
        }

        public override int setSpeed(int value)
        {
            int min = this.getMinSpeed();
            int max = this.getMaxSpeed();

            if (value > max)
            {
                Value = max;
            }
            else if (value < min)
            {
                Value = min;
            }
            else
            {
                Value = value;
            }
            mRGBnFC.setFanSpeed(mIndex, Value);
            LastValue = Value;
            return Value;
        }
    }
}
