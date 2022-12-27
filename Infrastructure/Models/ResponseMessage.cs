namespace SinceAllTimeHigh.Infrastructure.Models;
public class ResponseMessage<T> : IMessage<T> where T : class
{
    public Status Status { get; set; }
    public string Info { get; set; }
    public T? Data { get; set; }
    public ResponseMessage(Status status, string info, T? data)
    {
        this.Status = status;
        this.Info = info;
        this.Data = data;
    }
    public static IMessage<T> Success(string info, T? data) {
        return new ResponseMessage<T>(Status.Success, info, data);
    }
}