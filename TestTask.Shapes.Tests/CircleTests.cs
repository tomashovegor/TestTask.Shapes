namespace TestTask.Shapes.Tests
{
    public class CircleTests
    {
        [Theory]
        [InlineData(0.01)]
        [InlineData(10)]
        [InlineData(10.7)]
        public void Constructor_RadiusGreaterThanZero_CreatedInstance(double radius)
        {
            // Arrange && Act
            Circle circle = new Circle(radius);

            // Assert
            Assert.NotNull(circle);
            Assert.Equal(radius, circle.Radius);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Constructor_RadiusLessThanOrEqualToZero_ArgumentOutOfRangeException(double radius)
        {
            // Arrange && Act && Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(radius));
        }

        [Theory]
        [InlineData(0.01, 0.0003141592653589793)]
        [InlineData(10, 314.1592653589793)]
        [InlineData(10.7, 359.68094290949534)]
        public void GetArea_ValidRadius_CorrectArea(double radius, double expectedArea)
        {
            // Arrange
            Circle circle = new Circle(radius);

            // Act
            double area = circle.GetArea();

            // Assert
            Assert.Equal(expectedArea, area);
        }
    }
}
