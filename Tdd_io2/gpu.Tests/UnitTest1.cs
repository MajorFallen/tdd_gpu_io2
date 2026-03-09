using Tdd_io2;

namespace gpu.Tests
{
   public class GpuTests
    {
        [Fact]
        public void Start_ShouldSetIsRunningToTrue()
        {
            var clock = new FakeClock { Now = new DateTime(2024, 1, 1, 10, 0, 0) };
            var gpu = new GPU(clock);

            gpu.Start();

            Assert.True(gpu.IsRunning);
        }

        [Fact]
        public void Start_WhenAlreadyRunning_ShouldThrowException()
        {
            var clock = new FakeClock { Now = new DateTime(2024, 1, 1, 10, 0, 0) };
            var gpu = new GPU(clock);

            gpu.Start();

            Assert.Throws<InvalidOperationException>(() => gpu.Start());
        }

        [Fact]
        public void Stop_ShouldSetIsRunningToFalse()
        {
            var clock = new FakeClock { Now = new DateTime(2024, 1, 1, 10, 0, 0) };
            var gpu = new GPU(clock);

            gpu.Start();
            gpu.Stop();

            Assert.False(gpu.IsRunning);
        }

        [Fact]
        public void Stop_WhenGpuNotRunning_ShouldThrowException()
        {
            var clock = new FakeClock { Now = new DateTime(2024, 1, 1, 10, 0, 0) };
            var gpu = new GPU(clock);

            Assert.Throws<InvalidOperationException>(() => gpu.Stop());
        }

        [Fact]
        public void RunningTime_ShouldBeOneHour()
        {
            var clock = new FakeClock { Now = new DateTime(2024, 1, 1, 10, 0, 0) };
            var gpu = new GPU(clock);

            gpu.Start();
            clock.Now = clock.Now.AddHours(1);
            gpu.Stop();

            Assert.Equal(1, gpu.TotalHours);
        }

        [Fact]
        public void MultipleRuns_ShouldAccumulateTime()
        {
            var clock = new FakeClock { Now = new DateTime(2024, 1, 1, 10, 0, 0) };
            var gpu = new GPU(clock);

            gpu.Start();
            clock.Now = clock.Now.AddHours(2);
            gpu.Stop();

            gpu.Start();
            clock.Now = clock.Now.AddHours(3);
            gpu.Stop();

            Assert.Equal(5, gpu.TotalHours);
        }

        [Fact]
        public void CalculateCost_ShouldReturnCorrectValue()
        {
            var clock = new FakeClock { Now = new DateTime(2024, 1, 1, 10, 0, 0) };
            var gpu = new GPU(clock);

            gpu.Start();
            clock.Now = clock.Now.AddHours(2);
            gpu.Stop();

            double hourlyRate = 10;

            Assert.Equal(20, gpu.CalculateCost(hourlyRate));
        }

        [Fact]
        public void CalculateCost_WithZeroRate_ShouldThrowException()
        {
            var clock = new FakeClock { Now = new DateTime(2024, 1, 1, 10, 0, 0) };
            var gpu = new GPU(clock);

            gpu.Start();
            clock.Now = clock.Now.AddHours(1);
            gpu.Stop();

            Assert.Throws<ArgumentException>(() => gpu.CalculateCost(0));
        }
    }
}