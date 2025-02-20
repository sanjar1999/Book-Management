namespace Application.DTOs.ResponseDTOs;

public record ApiResponse<T>
{
    public string Status { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
}
