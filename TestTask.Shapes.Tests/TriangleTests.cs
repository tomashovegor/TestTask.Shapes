namespace TestTask.Shapes.Tests
{
    public class TriangleTests
    {
        [Theory]
        [InlineData(0.01, 0.01, 0.01)]
        [InlineData(6, 8, 10)]
        [InlineData(6, 5, 2.2)]
        [InlineData(5, 5, 5)]
        [InlineData(5, 5, 9)]
        public void Constructor_SidesGreaterThanZero_CreatedInstance(double sideA, double sideB, double sideC)
        {
            // Arrange && Act
            Triangle triangle = new Triangle(sideA, sideB, sideC);

            // Assert
            Assert.NotNull(triangle);
            Assert.Equal(sideA, triangle.SideA);
            Assert.Equal(sideB, triangle.SideB);
            Assert.Equal(sideC, triangle.SideC);
        }

        [Theory]
        [InlineData(-6, 8, 10)]
        [InlineData(6, -8, 10)]
        [InlineData(6, 8, -10)]
        [InlineData(0, 8, 10)]
        [InlineData(6, 0, 10)]
        [InlineData(6, 8, 0)]
        public void Constructor_SidesLessThanOrEqualToZero_ArgumentOutOfRangeException(double sideA, double sideB, double sideC)
        {
            // Arrange && Act && Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(sideA, sideB, sideC));
        }

        [Theory]
        [InlineData(10, 3, 4)]
        [InlineData(4, 10, 3)]
        [InlineData(3, 4, 10)]
        public void Constructor_SideGreaterThanOthersSidesSum_ArgumentException(double sideA, double sideB, double sideC)
        {
            // Arrange && Act && Assert
            Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
        }

        [Theory]
        [InlineData(0.01, 0.01, 0.01, 4.3301270189221919E-05)]
        [InlineData(6, 8, 10, 24)]
        [InlineData(6, 5, 2.2, 5.279999999999998)]
        [InlineData(5, 5, 5, 10.825317547305483)]
        [InlineData(5, 5, 9, 9.807522622966516)]
        public void GetArea_ValidSides_CorrectArea(double sideA, double sideB, double sideC, double expectedArea)
        {
            // Arrange
            Triangle triangle = new Triangle(sideA, sideB, sideC);

            // Act
            double area = triangle.GetArea();

            // Assert
            Assert.Equal(expectedArea, area);
        }

        [Fact]
        public void IsRightAngled_RightAngledTriangle_ReturnsTrue()
        {
            // Arrange
            Triangle triangle = new Triangle(6, 8, 10);

            // Act
            bool isRightAngled = triangle.IsRightAngled();

            // Assert
            Assert.True(isRightAngled);
        }

        [Theory]
        [InlineData(6, 6, 10)]
        [InlineData(8, 8, 8)]
        [InlineData(15, 14, 8)]
        [InlineData(15, 9, 8)]
        public void IsRightAngled_NotRightAngledTriangle_ReturnsFalse(double sideA, double sideB, double sideC)
        {
            // Arrange
            Triangle triangle = new Triangle(sideA, sideB, sideC);

            // Act
            bool isRightAngled = triangle.IsRightAngled();

            // Assert
            Assert.False(isRightAngled);
        }
    }
}
