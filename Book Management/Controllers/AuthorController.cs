using Application.DTOs.AuthorDTOs;
using Application.DTOs.ResponseDTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Book_Management.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorsController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAuthors()
    {
        var authors = await _authorService.GetAuthors();
        return Ok(new ApiResponse<List<AuthorGetModel>>
        {
            Status = "Success",
            Message = "Authors retrieved successfully",
            Data = authors
        });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAuthor(int id)
    {
        var author = await _authorService.GetAuthor(id);
        if (author is null)
            return NotFound(new ApiResponse<object> { Status = "Error", Message = "Author not found" });

        return Ok(new ApiResponse<AuthorGetModel>
        {
            Status = "Success",
            Message = "Author details retrieved successfully",
            Data = author
        });
    }

    [HttpPost]
    public async Task<IActionResult> AddAuthor([FromBody] AuthorPostModel author)
    {
        await _authorService.AddAuthor(author);
        return CreatedAtAction(nameof(GetAuthors), new ApiResponse<object>
        {
            Status = "Success",
            Message = "Author added successfully"
        });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAuthor([FromBody] AuthorPutModel author)
    {
        await _authorService.UpdateAuthor(author);
        return Ok(new ApiResponse<object>
        {
            Status = "Success",
            Message = "Author updated successfully"
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAuthor(int id)
    {
        await _authorService.DeleteAuthor(id);
        return Ok(new ApiResponse<object>
        {
            Status = "Success",
            Message = "Author deleted successfully"
        });
    }
}