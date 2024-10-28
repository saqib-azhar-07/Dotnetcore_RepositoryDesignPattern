namespace PRJ.Utility.OutputData;

public class OutputDTO<T>
{
    public bool Succeeded { get; set; } = true;
    public int HttpStatusCode { get; set; } = 200;
    public string? Message { get; set; } 
    public T Data { get; set; }
}
