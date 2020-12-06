using Moq;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using OCC.Models;

namespace OCC.UnitTest
{
    public static class MvcMockHelpers
    {
        public static HttpContext MockHttpContext()
        {
            var context = new Mock<HttpContext>();
            var request = new Mock<HttpRequest>();
            var response = new Mock<HttpResponse>();
            var session = new Mock<ISession>();
            response.SetupProperty(res => res.StatusCode, (int)System.Net.HttpStatusCode.OK);
            context.Setup(ctx => ctx.Request).Returns(request.Object);
            context.Setup(ctx => ctx.Response).Returns(response.Object);
            context.Setup(ctx => ctx.Session).Returns(session.Object);

            return context.Object;
        }

        public static void SetMockControllerContext(this Controller controller, HttpContext httpContext = null)
        {
            httpContext = httpContext ?? MockHttpContext();
            var modelState = new ModelStateDictionary();
            var modelMetadataProvider = new EmptyModelMetadataProvider();
            var actionContext = new ActionContext(httpContext, new RouteData(), new ControllerActionDescriptor(), modelState);
            var context = new ControllerContext(actionContext);

            controller.Url = new UrlHelper(actionContext);
            controller.TempData = new Mock<ITempDataDictionary>().Object;
            controller.ViewData = new ViewDataDictionary(modelMetadataProvider, modelState);
            controller.ControllerContext = context;
        }

        public static ApplicationDbContext GetMockDbContext() 
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("OneClickCleanerTest");
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}