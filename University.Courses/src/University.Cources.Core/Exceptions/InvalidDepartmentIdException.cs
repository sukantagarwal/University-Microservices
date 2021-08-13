namespace University.Cources.Core.Exceptions
{
    public class InvalidDepartmentIdException : DomainException
    {
        public InvalidDepartmentIdException() : base("departmentId not be null")
        {
        }
    }
}