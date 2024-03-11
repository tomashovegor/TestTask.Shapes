namespace TestTask.Shapes
{
    public class Triangle : Shape
    {
        public double SideA { get; init; }
        public double SideB { get; init; }
        public double SideC { get; init; }

        public Triangle(double sideA, double sideB, double sideC)
        {
            ValidateTriangleSides(sideA, sideB, sideC);

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        private void ValidateTriangleSides(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(sideA), "Сторона треугольника не может быть меньше или равна 0");
            }

            if (sideB <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(sideB), "Сторона треугольника не может быть меньше или равна 0");
            }

            if (sideC <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(sideC), "Сторона треугольника не может быть меньше или равна 0");
            }

            bool sideAIsValid = sideA < (sideB + sideC);
            bool sideBIsValid = sideB < (sideA + sideC);
            bool sideCIsValid = sideC < (sideA + sideB);

            if (sideAIsValid == false)
            {
                throw new ArgumentException("Треугольник не существует, сторона A меньше суммы двух других сторон", nameof(sideA));
            }

            if (sideBIsValid == false)
            {
                throw new ArgumentException("Треугольник не существует, сторона B меньше суммы двух других сторон", nameof(sideB));
            }

            if (sideCIsValid == false)
            {
                throw new ArgumentException("Треугольник не существует, сторона C меньше суммы двух других сторон", nameof(sideC));
            }
        }

        public override double GetSquare()
        {
            double p = (SideA + SideB + SideC) / 2;

            // Округление не добавлено, так как в условиях не было указано, нужно ли округлять результаты
            return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }

        public bool IsRightAngled()
        {
            List<double> sides = new List<double>() { SideA, SideB, SideC };
            double hypotenuse = sides.Max();

            sides.Remove(hypotenuse);

            double expectedHypotenuse = Math.Sqrt(Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2));

            return hypotenuse == expectedHypotenuse;
        }
    }
}