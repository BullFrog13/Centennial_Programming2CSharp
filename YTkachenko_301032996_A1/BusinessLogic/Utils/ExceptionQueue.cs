using System;

namespace BusinessLogic.Utils
{
    public class ExceptionQueue
    {
        private static readonly byte MAXIMUM_QUEUE_LENGTH = 10;

        public int ExceptionCount { get; private set; }

        private Exception[] Exceptions { get; }

        public ExceptionQueue()
        {
            Exceptions = new Exception[MAXIMUM_QUEUE_LENGTH];
        }

        public void Add(Exception exception)
        {
            if (ExceptionCount < MAXIMUM_QUEUE_LENGTH)
            {
                Exceptions[ExceptionCount++] = exception;
            }
        }

        public void ReleaseQueue()
        {
            if (ExceptionCount > 0)
            {
                throw new Exception(ComposeExceptionMessage());
            }
        }

        public void PrintQueue()
        {
            Console.Write(ComposeExceptionMessage());
        }

        private string ComposeExceptionMessage()
        {
            var exceptionMessage = string.Empty;

            if (ExceptionCount > 0)
            {
                for (var i = 0; i < ExceptionCount; i++)
                {
                    exceptionMessage += Exceptions[i].Message + "\n";
                }
            }

            return exceptionMessage;
        }
    }
}