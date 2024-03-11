namespace TestTask.Shapes
{
    public class Circle : Shape
    {
        public double Radius { get; init; }

        public Circle(double radius)
        {
            ValidateCircleRadius(radius);

            Radius = radius;
        }

        private void ValidateCircleRadius(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(radius), "Радиус не может быть меньше или равен 0");
            }
        }

        public override double GetArea()
        {
            // Округление не добавлено, так как в условиях не было указано, нужно ли округлять результаты
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}