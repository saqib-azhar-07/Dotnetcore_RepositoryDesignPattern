namespace PRJ.Utility.OutputData;

public static class ResponseMessage
{
    public const string GET = "Records get successfully.";
    public const string NOT_FOUND = "Record not found.";
    public const string USER_CREATE = "User is created successfully.";
    public const string USER_UPDATE = "User is updated successfully.";
    public const string USER_DELETE = "User is celeted successfully.";
    public const string USER_EXIST = "User is already exist.";
    public const string USER_NOT_FOUND = "User does not exist.";
    public const string GET_USER = "User gets successfully.";
    public const string GET_ALL_USERS = "Users get successfully.";
    public const string INVALID_CREDENTIALS = "Invalid Email/Password.";
    public const string SUCCESSFULLY_LOGIN = "You are successfully login.";
    public const string EMAIL_EXIST = "Email already exist.";
    public const string SUCCESSFULLY_REGISTER = "You are successfully register.";
}

public enum ResponseCode
{
    GET,
    NOT_FOUND,
    USER_CREATE,
    USER_UPDATE,
    USER_DELETE,
    USER_EXIST,
    USER_NOT_FOUND,
    GET_USER,
    GET_ALL_USERS,
    INVALID_CREDENTIALS,
    SUCCESSFULLY_LOGIN,
    EMAIL_EXIST,
    SUCCESSFULLY_REGISTER,
}




