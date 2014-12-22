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
    class ButtonCollection : DrawableGameComponent
    {
        const float SPACE_OFFSET = 80f;

        public Vector2 Position;
        public Cell[] ButtonCells;
        ActiveCell _activeCell;

        GameComponentCollection _components;

        public ButtonCollection(Game game)
            : base(game)
        {
            ButtonCells = new Cell[] {
                new Cell(game, "a0"),
                new Cell(game, "b0"),
                new Cell(game, "b1"),
                new Cell(game, "c0"),
                new Cell(game, "c2"),
                new Cell(game, "d0")
                };

            _activeCell = new ActiveCell(game);

            _components = new GameComponentCollection();

            foreach (var button in ButtonCells)
            {
                _components.Add(new ButtonClick(button));
            }

            _components.Add(_activeCell);
        }

        public override void Initialize()
        {
            float spacing = 0f;

            foreach (var button in ButtonCells)
            {
                button.Position.X = this.Position.X + spacing;
                button.Position.Y = this.Position.Y;

                spacing += SPACE_OFFSET;
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
