namespace SinceAllTimeHigh.Config.Models;
public interface IMessage<T> where T : class {
    public Status Status { get; set; }
    public string Info { get; set; }
    public T? Data { get; set; }
}