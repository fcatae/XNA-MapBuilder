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

        public void SetMapCell(int x, int y, string type)
        {
            Map[y, x] = type;
            MapCell[y, x].SetType(type);
        }

        public CellMap(Game game) : base(game)
        {
            _components = new GameComponentCollection();

            MapCell = new Cell[Map.GetLength(0), Map.GetLength(1)];

            for (int y = 0; y < Map.GetLength(0); y++)
            {
                for (int x = 0; x < Map.GetLength(1); x++)
                {
                    Cell cell = new Cell(Game, Map[y, x]);
                    _components.Add(cell);
                    MapCell[y, x] = cell;
                }
            }

            //_components.Add(new CellMapHover(this));
            _components.Add(new CellMapClick(this));

        }

        public override void Initialize()
        {
            for (int y = 0; y < Map.GetLength(0); y++)
            {
                for (int x = 0; x < Map.GetLength(1); x++)
                {
                    Cell cell = MapCell[y, x];
                    cell.Position = new Vector2(x * 64f + Position.X, y * 64f + Position.Y);
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

        public override void Update(GameTime gameTime)
        {
            foreach (var comp in _components)
            {
                IUpdateable cell = comp as IUpdateable;

                if (cell != null)
                {
                    cell.Update(gameTime);
                }
            }

            base.Update(gameTime);
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
