﻿namespace Library.API.Application.Exceptions
{
    public class DeleteModeRestrictViolation : Exception
    {
        public DeleteModeRestrictViolation()
        { }

        public DeleteModeRestrictViolation(string message)
            : base(message)
        { }

        public DeleteModeRestrictViolation(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
