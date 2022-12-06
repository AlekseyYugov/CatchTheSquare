using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace CatchTheSquare
{
    public class Game
    {
        public static int Scores;
        public static bool IsLost;
        private Font mainFont;
        private Text scoreText;
        private Text loseText;
        private SquaresList squares;
        private int MaxScores;
        public Game()
        {
            mainFont = new Font("Comic Sans MS.ttf");
            squares = new SquaresList();

            scoreText = new Text();
            scoreText.Font = mainFont;
            scoreText.FillColor = Color.Black;
            scoreText.CharacterSize = 16;
            scoreText.Position = new Vector2f(10, 10);

            loseText = new Text();
            loseText.Font = mainFont;
            loseText.FillColor = Color.Black;
            loseText.DisplayedString = "Ты проиграл! Нажми R чтобы перезапустить игру!";
            loseText.Position = new Vector2f(20, 290);

            Reset();
        }

        private void Reset()
        {
            squares.Reset();
            Scores = 0;
            IsLost = false;
            squares.SpawnPlayerSquare();
            squares.quantitySquares++;
            squares.SpawnEnemySquare();
        }
        public void Update(RenderWindow win)
        {
            if (IsLost)
            {
                win.Draw(loseText);
                if (Scores > MaxScores)
                {
                    MaxScores = Scores;
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.R))
                {
                    squares.quantitySquares = 1;
                    Reset();
                }
            }
            if (!IsLost)
            {
                squares.Update(win);
                if (squares.SquareHasRemoved)
                {
                    if (squares.RemovedSquare is PlayerSquare)
                    {
                        squares.SpawnPlayerSquare();
                    }
                }
            }
            scoreText.DisplayedString = "Score: " + Scores.ToString() + "\nMax: " + MaxScores.ToString();
            win.Draw(scoreText);
        }
    }
}
