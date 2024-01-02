using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Template.Engine.Time;

namespace Template.Tests.EditMode
{
    internal sealed class TimersTest
    {
        [Test]
        public async Task AsyncTimerWorkCorrectly()
        {
            const int time = 1;
            var timer = new AsyncTimer(time);
            var start = DateTime.Now;

            timer.Play();
            await timer.End();
            int duration = (DateTime.Now - start).Seconds;

            Assert.AreEqual(duration, time);
        }
    }
}