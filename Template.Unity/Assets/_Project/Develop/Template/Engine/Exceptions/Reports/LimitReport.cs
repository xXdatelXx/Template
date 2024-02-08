using System;
using Template.Engine.Time;

namespace Template.Engine.Exceptions
{
   public sealed class LimitReport : IReport
   {
      private readonly IReport _origin;
      private readonly int _limit;
      private readonly ITimer _timer;
      private int _reports;

      public LimitReport(IReport origin, int limit, ITimer timer)
      {
         _origin = origin;
         _limit = limit;
         _timer = timer;
      }

      public LimitReport(IReport origin, int limit, int time) : this(origin, limit, new AsyncTimer(time))
      { }

      public void Send(Exception e)
      {
         if (_reports > _limit)
            throw new InvalidOperationException($"Out of reports limit. Limit: {_limit}");

         _reports++;
         _origin.Send(e);

         if (_timer.Rest())
            Reset();
      }

      private void Reset()
      {
         _reports = 0;
         _timer.Play();
      }
   }
}