#pragma checksum "C:\Users\Kevin\Desktop\development\Intra\Intra\Views\Home\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "daff5159cc06600f5cfb5c5f72c90cf97bccd95a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Dashboard), @"mvc.1.0.view", @"/Views/Home/Dashboard.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Dashboard.cshtml", typeof(AspNetCore.Views_Home_Dashboard))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Kevin\Desktop\development\Intra\Intra\Views\_ViewImports.cshtml"
using Intra;

#line default
#line hidden
#line 2 "C:\Users\Kevin\Desktop\development\Intra\Intra\Views\_ViewImports.cshtml"
using Intra.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"daff5159cc06600f5cfb5c5f72c90cf97bccd95a", @"/Views/Home/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35359be6a4211d450034ca976664a5188473f923", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\Kevin\Desktop\development\Intra\Intra\Views\Home\Dashboard.cshtml"
  
    ViewData["Title"] = "Intra Dashboard";

#line default
#line hidden
            BeginContext(51, 124, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-12\">\r\n        <div class=\"jumbotron\">\r\n            <h1 class=\"text-left text-info\">");
            EndContext();
            BeginContext(176, 25, false);
#line 8 "C:\Users\Kevin\Desktop\development\Intra\Intra\Views\Home\Dashboard.cshtml"
                                       Write(ViewBag.TheUser.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(201, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(203, 24, false);
#line 8 "C:\Users\Kevin\Desktop\development\Intra\Intra\Views\Home\Dashboard.cshtml"
                                                                  Write(ViewBag.TheUser.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(227, 616, true);
            WriteLiteral(@"</h1>
        </div>
    </div>
</div>
<div class=""row"">
    <div class=""col-12 col-md-3 mt-5 mb-5"">
        <a href=""Users"" class=""btn btn-info btn-block btn-round"">Users</a>
    </div>
    <div class=""col-12 col-md-3 mt-5 mb-5"">
        <a href=""Todos"" class=""btn btn-success btn-block btn-round"">Todos</a>
    </div>
    <div class=""col-12 col-md-3 mt-5 mb-5"">
        <a href=""Calendar"" class=""btn btn-primary btn-block btn-round"">Calendar</a>
    </div>
    <div class=""col-12 col-md-3 mt-5 mb-5"">
        <a href=""Logout"" class=""btn btn-danger btn-block btn-round"">Logout</a>
    </div>
</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591