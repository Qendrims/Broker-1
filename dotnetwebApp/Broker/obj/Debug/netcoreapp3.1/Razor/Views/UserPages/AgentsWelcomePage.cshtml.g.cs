#pragma checksum "C:\Users\PBCA\Desktop\BROKER-APP\Broker-1\dotnetwebApp\Broker\Views\UserPages\AgentsWelcomePage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e50c9721f444b689598881505a708618f52ec025"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserPages_AgentsWelcomePage), @"mvc.1.0.view", @"/Views/UserPages/AgentsWelcomePage.cshtml")]
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
#nullable restore
#line 1 "C:\Users\PBCA\Desktop\BROKER-APP\Broker-1\dotnetwebApp\Broker\Views\_ViewImports.cshtml"
using Broker;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\PBCA\Desktop\BROKER-APP\Broker-1\dotnetwebApp\Broker\Views\_ViewImports.cshtml"
using Broker.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\PBCA\Desktop\BROKER-APP\Broker-1\dotnetwebApp\Broker\Views\UserPages\AgentsWelcomePage.cshtml"
using Broker.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e50c9721f444b689598881505a708618f52ec025", @"/Views/UserPages/AgentsWelcomePage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8dd34985017babc5aa119b9517d3fd3f2459d754", @"/Views/_ViewImports.cshtml")]
    public class Views_UserPages_AgentsWelcomePage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FilteredPostViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\PBCA\Desktop\BROKER-APP\Broker-1\dotnetwebApp\Broker\Views\UserPages\AgentsWelcomePage.cshtml"
  
    Pagination pager = new Pagination();
   
    if(ViewBag.Pager != null)
    {
        pager = ViewBag.Pager;
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<link");
            BeginWriteAttribute("href", " href=\"", 322, "\"", 371, 1);
#nullable restore
#line 17 "C:\Users\PBCA\Desktop\BROKER-APP\Broker-1\dotnetwebApp\Broker\Views\UserPages\AgentsWelcomePage.cshtml"
WriteAttributeValue("", 329, Url.Content("~/css/views/AgentsPage.css"), 329, 42, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" rel=\"stylesheet\" type=\"text/css\" />");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FilteredPostViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
