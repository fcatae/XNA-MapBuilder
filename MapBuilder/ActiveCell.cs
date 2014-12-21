using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapBuilder
{
    class ActiveCell : DrawableGameComponent
    {
        public Cell Current;
        const float POSITION_OFFSET = 2f;
        SpriteBatch _spriteBatch;
        Texture2D _texture;
        Vector2 _position;

        public ActiveCell(Game game)
            : base(game)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            _texture = Game.Content.Load<Texture2D>("z1_68");
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            if (Current != null)
            {
                _position.X = Current.Position.X - POSITION_OFFSET;
                _position.Y = Current.Position.Y - POSITION_OFFSET;

                _spriteBatch.Begin();
                _spriteBatch.Draw(_texture, _position, Color.White);
                _spriteBatch.End();
            }
            base.Draw(gameTime);
        }
    }
}
