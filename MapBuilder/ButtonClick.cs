using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapBuilder
{
    class ButtonClick : DrawableGameComponent
    {
        Cell _current;
        ActiveCell _tmp;
        bool _lastState;

        public ButtonClick(Cell cell) : base(cell.Game)
        {
            _current = cell;
            _tmp = new ActiveCell(cell.Game);
            cell.Game.Components.Add(_tmp);
        }

        public override void Initialize()
        {
            _lastState = false;

            _current.Initialize();

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            bool isPressed = (Mouse.GetState().LeftButton == ButtonState.Pressed);

            if ((isPressed) && (!_lastState) && isInsideBox())
                ExecuteCommand();
            
            _lastState = isPressed;

            _current.Update(gameTime);

            base.Update(gameTime);
        }

        bool isInsideBox()
        {
            MouseState state = Mouse.GetState();
            if ((state.Position.X < _current.Position.X) || (state.Position.X > _current.Position.X + 64))
                return false;
            
            if ((state.Position.Y < _current.Position.Y) || (state.Position.Y > _current.Position.Y + 64))
                return false;
            
            return true;
        }

        public override void Draw(GameTime gameTime)
        {
            _current.Draw(gameTime);

            base.Draw(gameTime);
        }

        void ExecuteCommand()
        {
            _tmp.Current = (_tmp.Current == null) ? _current : null;
        }
    }
}
