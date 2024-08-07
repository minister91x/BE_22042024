﻿using EBook.DataAccess.NetCore.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Security.Claims;

namespace BE_22042024.Filter
{
    public class EShopAuthorizeAttribute : TypeFilterAttribute
    {
        public EShopAuthorizeAttribute(string functionCode, string permission) : base(typeof(DemoAuthorizeActionFilter))
        {
            Arguments = new object[] { functionCode, permission };
        }
    }

    public class DemoAuthorizeActionFilter : IAsyncAuthorizationFilter
    {
        private readonly string _functionCode;
        private readonly string _permission;
        private IUnitOfWork _unitOfWork;
        public DemoAuthorizeActionFilter(string functionCode, string permission, IUnitOfWork unitOfWork)
        {
            _functionCode = functionCode;
            _permission = permission;
            _unitOfWork = unitOfWork;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            try
            {
                var identity = context.HttpContext.User.Identity as ClaimsIdentity;

                if (identity != null)
                {
                    var userClaims = identity.Claims;

                    if (userClaims.Count() == 0)
                    {
                        context.HttpContext.Response.ContentType = "application/json";
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        context.Result = new JsonResult(new
                        {
                            Code = 404,
                            Message = "Vui lòng đăng nhập để thực hiện chức năng này "
                        });

                        return;
                    }

                    var userId = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value;

                    if (userId == null) // không có token
                    {
                        context.HttpContext.Response.ContentType = "application/json";
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        context.Result = new JsonResult(new
                        {
                            Code = 404,
                            Message = "Vui lòng đăng nhập để thực hiện chức năng này "
                        });

                        return;

                    }

                    // Check Quyền
                    // bước 1: lấy functionId theo FunctionCode
                    var function = await _unitOfWork._accountServices.GetFunction(_functionCode);

                    if (function == null || function.FunctionID <= 0) // không có token
                    {
                        context.HttpContext.Response.ContentType = "application/json";
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        context.Result = new JsonResult(new
                        {
                            Code = 102,
                            Message = "Chức năng không hợp lệ "
                        });

                        return;

                    }

                    // bước 2: lấy quyền của userid 
                    var permission = await _unitOfWork._accountServices.User_PermissionById(function.FunctionID, Convert.ToInt32(userId));

                    switch (_permission)
                    {
                        case "VIEW":
                            if (permission.IViews == 0)
                            {
                                context.HttpContext.Response.ContentType = "application/json";
                                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                                context.Result = new JsonResult(new
                                {
                                    Code = 100,
                                    Message = "Bạn không có quyền thực hiện chức năng này"
                                });

                                return;
                            }
                            break;

                        case "INSERT": break;
                        case "UPDATE": break;
                        case "DELETE": break;
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
