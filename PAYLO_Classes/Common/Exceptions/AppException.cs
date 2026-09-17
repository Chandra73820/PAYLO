namespace PAYLO_Classes.Common.Exceptions
{
    // Base for all expected business exceptions — these are 4xx, not 5xx
    public abstract class AppException : Exception
    {
        public abstract int StatusCode { get; }
        protected AppException(string message) : base(message) { }
        protected AppException(string message, Exception inner) : base(message, inner) { }
    }

    public class ValidationException : AppException
    {
        public override int StatusCode => 400;
        public ValidationException(string message) : base(message) { }
    }

    public class UnauthorizedException : AppException
    {
        public override int StatusCode => 401;
        public UnauthorizedException(string message) : base(message) { }
    }

    public class ForbiddenException : AppException
    {
        public override int StatusCode => 403;
        public ForbiddenException(string message) : base(message) { }
    }

    public class NotFoundException : AppException
    {
        public override int StatusCode => 404;
        public NotFoundException(string message) : base(message) { }
    }

    public class BusinessRuleException : AppException
    {
        public override int StatusCode => 422;
        public BusinessRuleException(string message) : base(message) { }
    }
}