using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapBuilder
{
    class CellMapClick : GameComponent
    {
        CellMap _map;
        Vector2 _position;
        Cell[,] _mapCell;
        bool _lastState;

        public CellMapClick(CellMap map)
            : base(map.Game)
        {
            _map = map;
            _mapCell = map.MapCell;
        }

        public override void Initialize()
        {
            _position = _map.Position;
            base.Initialize();
        }
        
        public override void Update(GameTime gameTime)
        {
            bool isPressed = (Mouse.GetState().LeftButton == ButtonState.Pressed);

            if ((isPressed) && (!_lastState))
                ExecuteCommand();

            _lastState = isPressed;

            base.Update(gameTime);
        }

        void ExecuteCommand()
        {
            MouseState state = Mouse.GetState();

            if ((state.Position.X > this._position.X) && (state.Position.Y > this._position.Y))
            {
                int cellX = (int)((state.Position.X - this._position.X) / 64f);
                int cellY = (int)((state.Position.Y - this._position.Y) / 64f);

                bool validY = (cellY >= 0) && (cellY < _mapCell.GetLength(0));
                bool validX = (cellX >= 0) && (cellX < _mapCell.GetLength(1));

                if (validX && validY)
                    _map.SetMapCell(cellX, cellY, "a0");
            }
        }
    }
}
