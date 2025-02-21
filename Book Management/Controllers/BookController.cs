using Application.DTOs.BookDTOs;
using Application.DTOs.ResponseDTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Book_Management.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks(int pageNumber = 1, int pageSize = 10)
    {
        var books = await _bookService.GetBooks(pageNumber, pageSize);
        return Ok(new ApiResponse<List<BooksGetModel>>
        {
            Status = "Success",
            Message = "Books retrieved successfully",
            Data = books
        });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById(int id)
    {
        var book = await _bookService.GetBook(id);
        if (book is null)
            return NotFound(new ApiResponse<object> { Status = "Error", Message = "Book not found" });

        return Ok(new ApiResponse<BookDetailsGetModel>
        {
            Status = "Success",
            Message = "Book details retrieved successfully",
            Data = book
        });
    }

    [HttpPost]
    public async Task<IActionResult> AddBooks([FromBody] List<BookPostModel> books)
    {
        await _bookService.AddBooks(books);
        return CreatedAtAction(nameof(GetBooks), new ApiResponse<object>
        {
            Status = "Success",
            Message = "Books added successfully"
        });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBook([FromBody] BookPutModel book)
    {
        await _bookService.UpdateBook(book);
        return Ok(new ApiResponse<object>
        {
            Status = "Success",
            Message = "Book updated successfully"
        });
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBooks([FromBody] List<int> ids)
    {
        await _bookService.DeleteBooks(ids);
        return Ok(new ApiResponse<object>
        {
            Status = "Success",
            Message = "Books deleted successfully"
        });
    }
}