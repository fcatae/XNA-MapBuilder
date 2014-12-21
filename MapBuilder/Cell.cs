using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MapBuilder
{
    class Cell : DrawableGameComponent
    {
        string _name;
        Texture2D _texture;
        SpriteBatch _spriteBatch;
        
        public Vector2 Position;

        public Cell(Game game, string name) : base(game) 
        {
            Debug.Assert(name != "");
            
            _name = name;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            _texture = Game.Content.Load<Texture2D>(_name);

            Debug.Assert(_texture != null);

            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(_texture, Position, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
