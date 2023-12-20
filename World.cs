using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Monogame_Parts_1_5_summative
{
    public static class World
    {
        public static float time { get; set; }
        public static ContentManager content { get; set; }
        public static SpriteBatch SpriteBatch { get; set; }
        public static GraphicsDevice Device { get; set; }
        public static Point windowSize { get; set; }
        public static void Update(GameTime gt)
        {
            time = (float)gt.ElapsedGameTime.TotalSeconds;
        }
    }
}
