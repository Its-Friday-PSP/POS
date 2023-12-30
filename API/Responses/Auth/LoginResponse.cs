namespace API.Responses.Auth
{
    public class LoginResponse
    {
        public string AuthToken { get; set; }

        public LoginResponse(string authToken)
        {
            AuthToken = authToken;
        }
    }
}
