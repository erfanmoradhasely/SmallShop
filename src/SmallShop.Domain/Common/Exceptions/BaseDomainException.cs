﻿namespace SmallShop.Domain.Common.Exceptions
{
    public class BaseDomainException : Exception
    {
        public BaseDomainException()
        {
        }

        public BaseDomainException(string message) : base(message)
        {
        }
    }
}