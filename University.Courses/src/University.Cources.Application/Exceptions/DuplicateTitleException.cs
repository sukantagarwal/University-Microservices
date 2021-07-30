namespace University.Cources.Application.Exceptions
{
    public class DuplicateTitleException: AppException
    {
        public DuplicateTitleException() : base("title already exist!")
        {
        }
    }
}