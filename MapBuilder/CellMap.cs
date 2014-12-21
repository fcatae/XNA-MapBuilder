using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapBuilder
{
    class CellMap : DrawableGameComponent
    {
        public Vector2 Position;
        public string[,] Map = {
                               {"z0", "z0", "z0", "z0"},
                               {"z0", "z0", "z0", "z0"},
                               {"z0", "z0", "z0", "z0"}
                               };
        GameComponentCollection _components;

        public CellMap(Game game) : base(game)
        {
            Position = new Vector2(0,0);
            _components = new GameComponentCollection();
        }

        public override void Initialize()
        {
            for (int y = 0; y < Map.GetLength(0); y++)
            {
                for (int x = 0; x < Map.GetLength(1); x++)
                {
                    Cell cell = new Cell(Game, Map[y, x]);
                    cell.Position = new Vector2(x * 64f + Position.X, y * 64f + Position.Y);

                    _components.Add(cell);
                }
            }
            base.Initialize();
        }

        protected override void LoadContent()
        {
            foreach (var comp in _components)
            {
                comp.Initialize();
            }

            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            foreach(var comp in _components)
            {
                IDrawable cell = comp as IDrawable;

                if (cell != null)
                {
                    cell.Draw(gameTime);
                }
            }

            base.Draw(gameTime);
        }
    }
}
