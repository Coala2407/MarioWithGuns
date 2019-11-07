using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class Background
    {

        public Texture2D Texture { get; set; }
        public float ScrollingSpeed { get; set; }
        
        public float OffsetX { get; set; }
        public float OffsetY { get; set; }

    }
}
