namespace BLL.Classes
{
    public class TransferResult
    {
        public ErrorCodeEnum ErrorCode { get; set; }

        public TransferResult()
        {
            ErrorCode = ErrorCodeEnum.Succeeded;
        }
    }

    public enum ErrorCodeEnum
    {
        Succeeded, NotFoundPlayer, NotFoundTeam, DuplicatePlayer
    }
}
