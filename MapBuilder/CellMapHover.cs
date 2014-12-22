using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapBuilder
{
    class CellMapHover : DrawableGameComponent
    {
        ActiveCell _activeCell;
        Vector2 _position;
        Cell[,] _mapCell;
        
        public CellMapHover(CellMap map) : base(map.Game)
        {
            _activeCell = new ActiveCell(map.Game);
        }

        public override void Initialize()
        {
            _position = map.Position;
            _mapCell = map.MapCell;
            _activeCell.Initialize();
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            _activeCell.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            MouseState state = Mouse.GetState();

            if ((state.Position.X > this._position.X) && (state.Position.Y > this._position.Y))
            {
                int cellX = (int)((state.Position.X - this._position.X) / 64f);
                int cellY = (int)((state.Position.Y - this._position.Y) / 64f);

                bool validY = (cellY >= 0) && (cellY < _mapCell.GetLength(0));
                bool validX = (cellX >= 0) && (cellX < _mapCell.GetLength(1));

                _activeCell.Current = (validX && validY) ? _mapCell[cellY, cellX] : null;

                _activeCell.Draw(gameTime);
            }

            base.Draw(gameTime);
        }
    }
}
