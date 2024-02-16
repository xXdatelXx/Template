using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Template.Engine.Exceptions;
using Template.Engine.Time;

namespace Template.Tests.EditMode
{
   internal sealed class ReportsTest
   {
      [Test]
      public void LimitReportThrowsExceptionCorrectly()
      {
         IReport report = new LimitReport(new EmptyReport(), limit: 5, time: 10);

         Assert.Throws<InvalidOperationException>(() =>
         {
            for (int i = 0; i <= 10; i++)
               report.Send(default);
         });
      }

      [Test]
      public async Task LimitReportResettingWorkCorrectly()
      {
         IReport report = new LimitReport(new EmptyReport(), limit: 5, time: 1);
         var timer = new AsyncTimer(0.5f);

         for (int i = 0; i <= 5; i++)
            report.Send(default);

         timer.Play();
         await timer.End();

         Assert.DoesNotThrow(() => report.Send(default));
      }
   }
}