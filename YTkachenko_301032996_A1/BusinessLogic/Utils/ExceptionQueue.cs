using System;

namespace BusinessLogic.Utils
{
    public class ExceptionQueue
    {
        private static readonly byte MAXIMUM_QUEUE_LENGTH = 10;

        private int exceptionCount;

        private Exception[] Exceptions { get; }

        public ExceptionQueue()
        {
            Exceptions = new Exception[MAXIMUM_QUEUE_LENGTH];
        }

        public void Add(Exception exception)
        {
            if (exceptionCount < MAXIMUM_QUEUE_LENGTH)
            {
                Exceptions[exceptionCount++] = exception;
            }
        }

        public void ReleaseQueue()
        {
            throw new Exception(ComposeExceptionMessage());
        }

        public void PrintQueue()
        {
            Console.Write(ComposeExceptionMessage());
        }

        private string ComposeExceptionMessage()
        {
            var exceptionMessage = string.Empty;

            if (exceptionCount > 0)
            {
                for (var i = 0; i < exceptionCount; i++)
                {
                    exceptionMessage += Exceptions[i].Message + "\n";
                }
            }

            return exceptionMessage;
        }
    }
}