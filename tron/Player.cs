using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace tron
{
    public class Player
    {
        public enum Direction
        {
            UP,
            LEFT,
            RIGHT,
            DOWN
        }

        public Vector2i curPosition {get; set;}
        private RectangleShape playerSprite;

        private Direction curDirection;

        public Player(int startCol, int startRow, Direction startDir)
        {
            this.playerSprite = new RectangleShape(new Vector2f(10f, 10f));
            this.playerSprite.FillColor = Color.Cyan;

            this.curPosition = new Vector2i(startCol, startRow);

        }

        public void HandleUserInput()
        {
            if(Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                this.curDirection = Direction.RIGHT;
            }
            else if(Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                this.curDirection = Direction.UP;
            }
            else if(Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                this.curDirection = Direction.LEFT;
            }
            else if(Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                this.curDirection = Direction.DOWN;
            }
        }

        public void Process()
        {
            switch(this.curDirection)
            {
                case Direction.UP:
                {
                    Vector2i newPosition = this.curPosition;
                    newPosition.Y -= 1;
                    this.curPosition = newPosition;
                    break;
                }
                case Direction.LEFT:
                {
                    Vector2i newPosition = this.curPosition;
                    newPosition.X -= 1;
                    this.curPosition = newPosition;
                    break;
                }
                case Direction.DOWN:
                {
                    Vector2i newPosition = this.curPosition;
                    newPosition.Y += 1;
                    this.curPosition = newPosition;
                    break;
                }
                case Direction.RIGHT:
                {
                    Vector2i newPosition = this.curPosition;
                    newPosition.X += 1;
                    this.curPosition = newPosition;
                    break;
                }
            }

            Vector2f translatedPos = new Vector2f();
            translatedPos.X = this.curPosition.X * 10f;
            translatedPos.Y = this.curPosition.Y * 10f;
            this.playerSprite.Position = translatedPos;
        }

        public void Render(ref RenderWindow window)
        {
            window.Draw(this.playerSprite);
        }
    }
}