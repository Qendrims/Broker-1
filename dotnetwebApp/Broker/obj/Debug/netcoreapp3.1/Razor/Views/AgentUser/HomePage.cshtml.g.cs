#pragma checksum "C:\Users\PBCA\Desktop\BROKER-APP\Broker-1\dotnetwebApp\Broker\Views\AgentUser\HomePage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "989686a984fa053cb5bbec1f9ac4bbd35b372e41"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AgentUser_HomePage), @"mvc.1.0.view", @"/Views/AgentUser/HomePage.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"989686a984fa053cb5bbec1f9ac4bbd35b372e41", @"/Views/AgentUser/HomePage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8dd34985017babc5aa119b9517d3fd3f2459d754", @"/Views/_ViewImports.cshtml")]
    public class Views_AgentUser_HomePage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<HomeViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/welcomePage.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\PBCA\Desktop\BROKER-APP\Broker-1\dotnetwebApp\Broker\Views\AgentUser\HomePage.cshtml"
  
    Layout = "~/Views/Shared/_AgentUserLayout.cshtml";
    ViewData["Title"] = "Home Page";


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
  <div class=""homeSlider"">
    <div class=""homepage-slider"">
        <img src=""../../Assets/Images/grid1.jpg"" class=""homepage-slider-imgs"">
        <img src=""../../Assets/Images/slider4.jpg"" class=""homepage-slider-imgs"">
        <img src=""../../Assets/Images/slider5.jpg"" class=""homepage-slider-imgs"">   
        <div class=""homepage-search"">
            <input class=""homepageSearch"" type=""text"" placeholder=""Find an agent"">
            <div class=""searchResults""></div>
          </div>
 </div>
 </div>


<div id=""homepage-posts"">
");
#nullable restore
#line 27 "C:\Users\PBCA\Desktop\BROKER-APP\Broker-1\dotnetwebApp\Broker\Views\AgentUser\HomePage.cshtml"
     foreach (var m in @Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h1>");
#nullable restore
#line 29 "C:\Users\PBCA\Desktop\BROKER-APP\Broker-1\dotnetwebApp\Broker\Views\AgentUser\HomePage.cshtml"
       Write(m.category.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n        <div class=\"slider\">\r\n            <div class=\"homepage-posts-container slides\" data-category=\"");
#nullable restore
#line 31 "C:\Users\PBCA\Desktop\BROKER-APP\Broker-1\dotnetwebApp\Broker\Views\AgentUser\HomePage.cshtml"
                                                                   Write(m.category.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" id=\"slides\">\r\n");
#nullable restore
#line 32 "C:\Users\PBCA\Desktop\BROKER-APP\Broker-1\dotnetwebApp\Broker\Views\AgentUser\HomePage.cshtml"
             foreach(var posts in @m.posts)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                 <div class=\"homepage-post-cards content slide\">\r\n                <img src=\"../../Assets/Images/grid1.jpg\" alt=\"Home\">\r\n                <h1>");
#nullable restore
#line 36 "C:\Users\PBCA\Desktop\BROKER-APP\Broker-1\dotnetwebApp\Broker\Views\AgentUser\HomePage.cshtml"
               Write(posts.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                <p>");
#nullable restore
#line 37 "C:\Users\PBCA\Desktop\BROKER-APP\Broker-1\dotnetwebApp\Broker\Views\AgentUser\HomePage.cshtml"
              Write(posts.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <a class=\"btn btn-primary\" href=\"#\">Show Details</a>\r\n            </div>\r\n");
#nullable restore
#line 40 "C:\Users\PBCA\Desktop\BROKER-APP\Broker-1\dotnetwebApp\Broker\Views\AgentUser\HomePage.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n            <div class=\"prev\" id=\"prev\" data-category-btn=");
#nullable restore
#line 42 "C:\Users\PBCA\Desktop\BROKER-APP\Broker-1\dotnetwebApp\Broker\Views\AgentUser\HomePage.cshtml"
                                                     Write(m.category.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral(">\r\n                <i class=\"fas fa-caret-left\"></i>\r\n            </div>\r\n            <div class=\"next\" id=\"next\" data-category-btn=");
#nullable restore
#line 45 "C:\Users\PBCA\Desktop\BROKER-APP\Broker-1\dotnetwebApp\Broker\Views\AgentUser\HomePage.cshtml"
                                                     Write(m.category.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral(">\r\n                <i class=\"fas fa-caret-right\"></i>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 49 "C:\Users\PBCA\Desktop\BROKER-APP\Broker-1\dotnetwebApp\Broker\Views\AgentUser\HomePage.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "989686a984fa053cb5bbec1f9ac4bbd35b372e417759", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<HomeViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
