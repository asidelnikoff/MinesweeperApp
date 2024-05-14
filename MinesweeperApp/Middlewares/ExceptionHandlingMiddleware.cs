using Domain.Exceptions;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MinesweeperApp.Models;
using System;
using System.Threading.Tasks;

namespace MinesweeperApp.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        _logger.LogError(exception.ToString());
        ErrorResponse response = exception switch
        {
            CantCreateGameException _ => new ErrorResponse() { Error = "Невозможно создать игру с такими параметрами." },
            GameCompletedException _ => new ErrorResponse() { Error = "Игра уже завершена." },
            CellAlreadyCheckedException _ => new ErrorResponse() { Error = "Клетка уже открыта." },
            GameAlreadyExistsException _ => new ErrorResponse() { Error = "Игра с таким Id уже существует." },
            NoSuchGameException _ => new ErrorResponse() { Error = "Игры с таким Id не существует." },
            _ => new ErrorResponse() { Error = "Произошла непредвиденная ошибка." }
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        await context.Response.WriteAsJsonAsync(response);
    }
}
