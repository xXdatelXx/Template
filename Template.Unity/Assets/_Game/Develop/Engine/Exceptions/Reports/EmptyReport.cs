using System;
using UnityEngine;

namespace Template.Engine.Exceptions
{
   public sealed class EmptyReport : IReport
   {
      public void Send(Exception e) =>
         Debug.Log(e);
   }
}