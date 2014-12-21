using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

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
        public Cell[,] MapCell;

        GameComponentCollection _components;
        ActiveCell _activeCell;

        public CellMap(Game game) : base(game)
        {
            Position = new Vector2(0,0);
            _activeCell = new ActiveCell(game);
        }

        public override void Initialize()
        {
            _components = new GameComponentCollection();

            MapCell = new Cell[Map.GetLength(0), Map.GetLength(1)];

            for (int y = 0; y < Map.GetLength(0); y++)
            {
                for (int x = 0; x < Map.GetLength(1); x++)
                {
                    Cell cell = new Cell(Game, Map[y, x]);
                    cell.Position = new Vector2(x * 64f + Position.X, y * 64f + Position.Y);

                    _components.Add(cell);
                    MapCell[y, x] = cell;
                }
            }

            _components.Add(_activeCell);

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

            Hover();

            base.Draw(gameTime);
        }

        void Hover()
        {
            MouseState state = Mouse.GetState();

            int cellX = (int)((state.Position.X - this.Position.X) / 64f);
            int cellY = (int)((state.Position.Y - this.Position.Y) / 64f);

            bool validY = (cellY >= 0) && (cellY < Map.GetLength(0));
            bool validX = (cellX >= 0) && (cellX < Map.GetLength(1));

            _activeCell.Current = (validX && validY) ? MapCell[cellY, cellX] : null;
        }
    }
}
