﻿
namespace BubbleFramework
{
    using System;
    using System.Runtime.Serialization;

    //异常处理
    [Serializable]
    public class GameException : Exception
    {
        public GameException()
        {
        }

        public GameException(string message) : base(message)
        {
        }

        public GameException(string message, Exception inner) : base(message, inner)
        {
        }

        protected GameException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }

}
