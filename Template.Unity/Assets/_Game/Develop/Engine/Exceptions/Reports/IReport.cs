using System;

namespace Template.Engine.Exceptions
{
   public interface IReport
   {
      void Send(Exception e);
   }
}