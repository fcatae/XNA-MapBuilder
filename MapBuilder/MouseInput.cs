using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapBuilder
{
    class MouseInput : DrawableGameComponent
    {
        SpriteBatch _spriteBatch;
        Texture2D _texture;
        Vector2 _position;
        bool _visible;

        public MouseInput(Game game)
            : base(game)
        {

        }

        public override void Initialize()
        {
            Game.IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            _texture = Game.Content.Load<Texture2D>("z1_68");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            MouseState state = Mouse.GetState();

            //state.LeftButton

            _position.X = state.Position.X;
            _position.Y = state.Position.Y;
            
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Draw(_texture, _position, Color.White);
            
            base.Draw(gameTime);
        }
    }
}
