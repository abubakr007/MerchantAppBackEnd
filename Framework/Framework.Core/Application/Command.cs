using System;

namespace Framework.Core.Application
{
    public abstract class Command
    {
        public Command()
        {
            TimeStamp = DateTime.Now;
        }


        private DateTime TimeStamp { get; set; }


        public DateTime GetTimeStamp()
        {
            return TimeStamp;
        }
    }
}