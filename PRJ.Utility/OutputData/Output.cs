using System.Net;
namespace PRJ.Utility.OutputData;

public static class Output
{
    public static OutputDTO<T> Handler<T>(int responseCode, T dto)
    {
        var obj = new OutputDTO<T>()
        {
            Data = dto,
        };

        switch (responseCode)
        {
            case (int) ResponseCode.GET:
                obj.HttpStatusCode = (int) HttpStatusCode.OK;
                obj.Message = ResponseMessage.GET;
                break;

            case (int) ResponseCode.USER_CREATE:
                obj.HttpStatusCode = (int) HttpStatusCode.Created;
                obj.Message = ResponseMessage.USER_CREATE;
                break;

            case (int) ResponseCode.USER_DELETE:
                obj.HttpStatusCode = (int) HttpStatusCode.OK;
                obj.Message = ResponseMessage.USER_DELETE;
                break;

            case (int) ResponseCode.GET_USER:
                obj.HttpStatusCode = (int) HttpStatusCode.OK;
                obj.Message = ResponseMessage.GET_USER;
                break;

            case (int) ResponseCode.GET_ALL_USERS:
                obj.HttpStatusCode = (int) HttpStatusCode.OK;
                obj.Message = ResponseMessage.GET_ALL_USERS;
                break;

            case (int) ResponseCode.USER_EXIST:
                obj.HttpStatusCode = (int) HttpStatusCode.Conflict;
                obj.Succeeded = false;
                obj.Message = ResponseMessage.USER_EXIST;
                break;

            case (int) ResponseCode.USER_NOT_FOUND:
                obj.HttpStatusCode = (int) HttpStatusCode.NotFound;
                obj.Succeeded = false;
                obj.Message = ResponseMessage.USER_NOT_FOUND;
                break;

            case (int) ResponseCode.SUCCESSFULLY_REGISTER:
                obj.HttpStatusCode = (int) HttpStatusCode.OK;
                obj.Succeeded = true;
                obj.Message = ResponseMessage.SUCCESSFULLY_REGISTER;
                break;

            case (int) ResponseCode.EMAIL_EXIST:
                obj.HttpStatusCode = (int) HttpStatusCode.Conflict;
                obj.Succeeded = false;
                obj.Message = ResponseMessage.EMAIL_EXIST;
                break;

            case (int) ResponseCode.SUCCESSFULLY_LOGIN:
                obj.HttpStatusCode = (int) HttpStatusCode.OK;
                obj.Succeeded = true;
                obj.Message = ResponseMessage.SUCCESSFULLY_LOGIN;
                break;

            case (int) ResponseCode.INVALID_CREDENTIALS:
                obj.HttpStatusCode = (int) HttpStatusCode.NotFound;
                obj.Succeeded = true;
                obj.Message = ResponseMessage.INVALID_CREDENTIALS;
                break;
        }

        return obj;
    }
}
