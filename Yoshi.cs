using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Monogame_Parts_1_5_summative
{
    public class Yoshi : Sprite
    {
        private const float speed = 750f;
        private const float gravity = 5000f;
        private const float jump = 1500f;
        private Vector2 _velocity;
        private bool _onGround = true;
        public Yoshi(Texture2D texture, Vector2 position) : base(texture, position)
        {

        }
        private void UpdateVelocity()
        {
            var jumping = Keyboard.GetState();
            if (!_onGround)
            {
                _velocity.Y += gravity;
            }
            if (jumping.IsKeyDown(Keys.W) && _onGround)
            {
                _velocity.Y = -jump;
                _onGround = false;
            }
        }
        public void Update()
        {
            UpdateVelocity();
            position += _velocity;
        }
    }
}
