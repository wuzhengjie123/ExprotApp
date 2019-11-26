using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Forms;

namespace D.Forms
{
    public sealed class PictureAnimation : Animation
    {
        public PictureAnimation(Control target, int speed, int duration) : base(target, speed, duration)
        {
        }

        protected override void DoAnimation()
        {
            
        }
    }
}
