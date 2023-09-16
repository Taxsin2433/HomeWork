using HwCreateGame.HwCreateGame.Logger;
using System;
namespace HwCreateGame.Logger
{
    public class Result
    {
        public LogLevel Status { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
    }
}