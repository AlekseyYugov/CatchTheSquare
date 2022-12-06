using SFML.System;
using SFML.Graphics;

namespace CatchTheSquare
{
    public class PlayerSquare : Square
    {
        private static Color Color = new Color(50, 50, 50);
        private static float SizeStep = 10;
        private static float MinSize = 30;
        public PlayerSquare(Vector2f position, float movementSpeed, IntRect movementBounds) :
            base(position, movementSpeed, movementBounds)
        {
            shape.FillColor = Color;
        }
        protected override void OnClick()
        {
            Game.Scores++;
            shape.Size -= new Vector2f(SizeStep, SizeStep);
            if (shape.Size.X < MinSize)
            {
                IsActive = false;
                return;
            }
            UpdateMovementTarget();
            shape.Position = movementTarget;
        }
    }
}
