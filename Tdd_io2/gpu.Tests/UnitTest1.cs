namespace gpu.Tests
{
   public class GpuTests
    {
        [Fact]
        public void Start_ShouldChangeStatusToRunning()
        {
            // Arrange
            var gpu = new GPU();

            // Act
            gpu.Start();

            // Assert
            Assert.True(gpu.IsRunning);
        }
    }
}