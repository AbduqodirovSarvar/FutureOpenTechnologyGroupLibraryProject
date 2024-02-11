namespace Library.Application.Exceptions
{
    public class LoginException : Exception
    {
        public LoginException() : base("Login or password incorrect!") { }
    }
}
