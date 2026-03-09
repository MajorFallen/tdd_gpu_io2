using Tdd_io2;

namespace gpu.Tests
{
   public class GpuTests
    {
        [Fact]
        public void Start_ShouldChangeStatusToRunning()
        {
            var gpu = new GPU();
            gpu.Start();
            Assert.True(gpu.IsRunning);
        }

        [Fact]
        public void Start_WhenAlreadyRunning_ShouldThrowException()
        {
            var gpu = new GPU();
            gpu.Start();
            Assert.Throws<InvalidOperationException>(() => gpu.Start());
        }

        [Fact]
        public void RunningTime_ShouldIncreaseAfterStart()
        {
            var gpu = new GPU();
            gpu.Start();
            Thread.Sleep(1000);
            Assert.True(gpu.RunningTime.TotalSeconds >= 1);
        }
    }
}