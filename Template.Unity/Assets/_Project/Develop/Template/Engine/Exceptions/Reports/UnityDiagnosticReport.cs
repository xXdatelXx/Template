using System;

namespace Template.Engine.Exceptions
{
    public sealed class UnityDiagnosticReport : IReport
    {
        private readonly UserReportingScript _origin;

        public UnityDiagnosticReport(UserReportingScript origin) =>
            _origin = origin;

        public void Send(Exception e)
        {
            _origin.DescriptionInput.text = e.ToString();
            _origin.CreateUserReport();
        }
    }
}