﻿namespace Tabu.Exceptions
{
    public interface IBaseException
    {
        int StatusCode { get; }
        string ErrorMessage { get; }
    }
}
