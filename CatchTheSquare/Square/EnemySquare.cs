using SFML.System;
using SFML.Graphics;

namespace CatchTheSquare
{
    public class EnemySquare : Square
    {
        private static Color Color = new Color(230, 50, 50);
        private static float MaxMoventSpeed = 3;
        private static float MovementStep = 0.05f;
        private static float MaxSize = 150f;
        private static float SizeStep = 10;
        public EnemySquare(Vector2f position, float movementSpeed, IntRect movementBounds) :
            base(position, movementSpeed, movementBounds)
        {
            shape.FillColor = Color;
        }
        protected override void OnClick()
        {
            Game.IsLost = true;
        }
        protected override void OnReachedTarget()
        {
            if (movementSpeed < MaxMoventSpeed) movementSpeed += MovementStep;
            if (shape.Size.X < MaxSize) shape.Size += new Vector2f(SizeStep, SizeStep);
        }
    }
}
