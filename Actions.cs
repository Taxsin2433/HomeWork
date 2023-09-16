using HwCreateGame.HwCreateGame.Logger;
using System;
namespace HwCreateGame.Logger
{
    public static class Actions
    {
        public static Random random = new Random();
        public static Result InfoAction()
        {
            Result result = new Result
            {
                Status = LogLevel.Info,
                Message = "This is an info message",
                DateTime = DateTime.Now
            };
            Logger.Instance.Log(result);
            return result;
        }

        public static Result WarningAction()
        {
            Result result = new Result
            {
                Status = LogLevel.Warning,
                Message = "This is a warning message",
                DateTime = DateTime.Now
            };
            Logger.Instance.Log(result);
            return result;
        }

        public static Result ErrorAction()
        {  
            try
            {
                throw new BusinessException("BussinesException Happened"); 
            }
            catch (BusinessException ex)
            {
                Result result = new Result
                {

                    Status = LogLevel.Error,
                    Message = ex.Message,
                    DateTime = DateTime.Now
                };
                Logger.Instance.Log(result);
                return result;

            }

        }
    }
}