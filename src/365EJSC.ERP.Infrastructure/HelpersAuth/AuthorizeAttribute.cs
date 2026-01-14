using _365EJSC.ERP.Contract.Enumerations;
using _365EJSC.ERP.Contract.Shared;
using _365EJSC.ERP.Domain.Abstractions.Repositories.Sql.Auth;
using _365EJSC.ERP.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Net;

public class AuthorizeAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        // Lấy IJwtUtils và IUserValidatorService từ DI
        var jwtUtils = context.HttpContext.RequestServices.GetRequiredService<IJwtUtils>();
        var userValidator = context.HttpContext.RequestServices.GetRequiredService<IAuthenticationSqlRepository>();

        // Kiểm tra AllowAnonymous
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata
            .OfType<AllowAnonymousAttribute>()
            .Any();

        if (!allowAnonymous)
        {
            // Lấy token từ header Authorization
            var token = context.HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
            {
                context.Result = new JsonResult(new Result<object>
                {
                    MessageCode = MsgCode.ERR_UNAUTHORIZED,
                    StatusCode = (int)HttpStatusCode.Unauthorized,
                    Error = new _365EJSC.ERP.Contract.Errors.Error("TOKEN_MISSING", new[] { "Authorization token is required." })
                })
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized // Đặt status code cho response
                };
                return;
            }

            try
            {
                // Validate token
                var userClaims = jwtUtils.ValidateJwtToken(token);
                if (userClaims == null)
                {
                    if (userClaims == null)
                    {
                        context.Result = new JsonResult(new Result<object>
                        {
                            MessageCode = MsgCode.ERR_UNAUTHORIZED,
                            StatusCode = (int)HttpStatusCode.Unauthorized,
                            Error = new _365EJSC.ERP.Contract.Errors.Error("INVALID_TOKEN", new[] { "The provided token is invalid." })
                        })
                        {
                            StatusCode = (int)HttpStatusCode.Unauthorized
                        };
                        return;
                    }
                }

                // Kiểm tra người dùng trong DB để đảm bảo đăng nhập đúng tài khoản
                bool isUserValid = await userValidator.ValidateUserAsync(userClaims.id, userClaims.type);
                if (!isUserValid)
                {
                    context.Result = new JsonResult(new Result<object>
                    {
                        MessageCode = MsgCode.ERR_UNAUTHORIZED,
                        StatusCode = (int)HttpStatusCode.Unauthorized,
                        Error = new _365EJSC.ERP.Contract.Errors.Error("USER_NOT_FOUND", new[] { $"User with ID {userClaims.id} not found as {userClaims.type}." })
                    })
                    {
                        StatusCode = (int)HttpStatusCode.Unauthorized
                    };
                    return;
                }

                // Lưu thông tin userClaims vào HttpContext.Items
                context.HttpContext.Items["UserClaims"] = userClaims;
            }
            catch (SecurityTokenException ex)
            {
                var errorCode = ex.Message == "Token has expired" ? "TOKEN_EXPIRED" : "INVALID_TOKEN";
                context.Result = new JsonResult(new Result<object>
                {
                    MessageCode = MsgCode.ERR_UNAUTHORIZED,
                    StatusCode = (int)HttpStatusCode.Unauthorized,
                    Error = new _365EJSC.ERP.Contract.Errors.Error(errorCode, new[] { ex.Message })
                })
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized
                };
                return;
            }
        }

        await next();
    }
}

/*
public class AuthorizeAttribute : ActionFilterAttribute
{
    private JwtUtils _jwtUtils;

    public AuthorizeAttribute()
    {
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        _jwtUtils= new JwtUtils();
        // Kiểm tra AllowAnonymous
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata
            .OfType<AllowAnonymousAttribute>()
            .Any();

        if (!allowAnonymous)
        {
            // Lấy token từ header Authorization
            var token = context.HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
            {
                context.Result = new JsonResult(new Result<object>
                {
                    MessageCode = MsgCode.ERR_UNAUTHORIZED,
                    StatusCode = (int)HttpStatusCode.Unauthorized,
                    Error = new _365EJSC.ERP.Contract.Errors.Error("TOKEN_MISSING", new[] { "Authorization token is required." })
                })
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized // Đặt status code cho response
                };
                return;
            }

            // Validate token
            var userClaims = _jwtUtils.ValidateJwtToken(token);
            if (userClaims == null)
            {
                context.Result = new JsonResult(new Result<object>
                {
                    MessageCode = MsgCode.ERR_UNAUTHORIZED,
                    StatusCode = (int)HttpStatusCode.Unauthorized,
                    Error = new _365EJSC.ERP.Contract.Errors.Error("INVALID_TOKEN", new[] { "The provided token is invalid." })
                })
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized
                };
                return;
            }

            // Lưu thông tin userClaims vào HttpContext.Items
            context.HttpContext.Items["UserClaims"] = userClaims;
        }

        base.OnActionExecuting(context);
    }
}
*/