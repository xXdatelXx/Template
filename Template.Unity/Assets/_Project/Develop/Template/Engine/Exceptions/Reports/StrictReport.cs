using System;

namespace Template.Engine.Exceptions
{
    public sealed class StrictReport : IReport
    {
        private readonly IReport _origin;

        public StrictReport(IReport origin) =>
            _origin = origin;

        public void Send(Exception e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));

            _origin.Send(e);
        }
    }
}