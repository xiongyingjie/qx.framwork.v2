namespace xyj.core.Models.Http
{
    public enum State
    {

        Success = 1,
        Fail = 2,
        Confirm = 3,
        SuccessConfirm = 6,
        FailConfirm = 5,
        SuccessConfirmClose = 7,
        FailConfirmClose = 8,
        File = 9,
        SuccessAutoClose = 10,
        BalanceNotEnough = 11,
        UserInfoNotComplete = 12,
        Error = -1,
    }
}