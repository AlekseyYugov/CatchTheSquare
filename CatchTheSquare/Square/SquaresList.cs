using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace CatchTheSquare
{
    public class SquaresList
    {
        private List<Square> squares;
        public bool SquareHasRemoved;
        public Square RemovedSquare;
        public int quantitySquares = 1; // количество Player Square

        public SquaresList()
        {
            squares = new List<Square>();
        }
        public void Reset()
        {
            SquareHasRemoved = false;
            RemovedSquare = null;
            squares.Clear();
        }
        public void Update(RenderWindow win)
        {
            SquareHasRemoved = false;
            RemovedSquare = null;

            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                for (int i = 0; i < squares.Count; i++)
                {
                    squares[i].CheckMousePosition(Mouse.GetPosition(win));
                }
            }

            for (int i = 0; i < squares.Count; i++)
            {
                squares[i].Move();
                squares[i].Draw(win);
                if (!squares[i].IsActive)
                {
                    RemovedSquare = squares[i];
                    squares.Remove(squares[i]);
                    SquareHasRemoved = true;
                }
            }
        }

        public void SpawnPlayerSquare()
        {
            for (int i = 0; i < quantitySquares; i++)
            {
                squares.Add(new PlayerSquare(new Vector2f(Mathf.Random.Next(0, 800), (Mathf.Random.Next(0, 800))), 5, new IntRect(0, 0, 800, 600)));
            }
        }
        public void SpawnEnemySquare()
        {
            squares.Add(new EnemySquare(new Vector2f(Mathf.Random.Next(0, 800), (Mathf.Random.Next(0, 800))), 5, new IntRect(0, 0, 800, 600)));
        }
    }
}
