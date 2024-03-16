namespace PassingTrips;

public class LoginTokenDto
{
    public bool IsSuccess { get; set; }
    public string ErrorMessage { get; set; }
    public string JwtToken { get; set; }

    public LoginTokenDto(bool isSuccess, string result)
    {
        IsSuccess = isSuccess;
        if (IsSuccess)
            JwtToken = result;
        else
            ErrorMessage = result;
    }
}