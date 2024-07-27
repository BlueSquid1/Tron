using SFML.System;
using SFML.Graphics;

namespace tron
{
    public class Background
    {
        public enum SquareState
        {
            unused,
            used
        }
        public struct Square
        {
            public RectangleShape sprite;
            public SquareState state;

        }
        private Square[,] squares;

        public Background(int width, int height)
        {
            this.squares = new Square[width, height];
            for(int col = 0; col < this.squares.GetLength(0); ++col)
            {
                for(int row = 0; row < this.squares.GetLength(1); ++row)
                {
                    Square curSquare = this.squares[col, row];
                    curSquare.state = SquareState.unused;
                    curSquare.sprite = new RectangleShape(new Vector2f(10f, 10f));
                    curSquare.sprite.Position = new Vector2f(col * 10f, row * 10f);
                    curSquare.sprite.FillColor = Color.White;
                    this.squares[col, row] = curSquare;
                }
            }
        }

        public void SetSquareToUsed(Vector2i pos)
        {
            this.squares[pos.X, pos.Y].state = SquareState.used;
            this.squares[pos.X, pos.Y].sprite.FillColor = Color.Blue;
        }

        public void Render(ref RenderWindow window)
        {
            for(int col = 0; col < this.squares.GetLength(0); ++col)
            {
                for(int row = 0; row < this.squares.GetLength(1); ++row)
                {
                    window.Draw(this.squares[col, row].sprite);
                }
            }
        }
    }
}