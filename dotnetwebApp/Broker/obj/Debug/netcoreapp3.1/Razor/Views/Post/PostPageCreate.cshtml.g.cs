#pragma checksum "C:\Users\HP\Desktop\Broker-1\dotnetwebApp\Broker\Views\Post\PostPageCreate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2ac53aaca348047f5540b0ce84e05f0fea5d568a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Post_PostPageCreate), @"mvc.1.0.view", @"/Views/Post/PostPageCreate.cshtml")]
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
#line 1 "C:\Users\HP\Desktop\Broker-1\dotnetwebApp\Broker\Views\_ViewImports.cshtml"
using Broker;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\Desktop\Broker-1\dotnetwebApp\Broker\Views\_ViewImports.cshtml"
using Broker.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\Desktop\Broker-1\dotnetwebApp\Broker\Views\_ViewImports.cshtml"
using Broker.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ac53aaca348047f5540b0ce84e05f0fea5d568a", @"/Views/Post/PostPageCreate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7849adb06ffd185482dc9353d14a61692eb94780", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Post_PostPageCreate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "3", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("myForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/CreatePostMap.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\HP\Desktop\Broker-1\dotnetwebApp\Broker\Views\Post\PostPageCreate.cshtml"
  
    ViewData["Title"] = "PostPageCreate";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n <link rel=\"stylesheet\" href=\"https://unpkg.com/leaflet@1.8.0/dist/leaflet.css\"\r\n   integrity=\"sha512-hoalWLoI8r4UszCkZ5kL8vayOGVae1oxXe/2A4AO6J9+580uKHDO3JdHb7NzwwzK5xr/Fs0W40kiNHxM9vyTtQ==\"");
            BeginWriteAttribute("crossorigin", "\r\n   crossorigin=\"", 243, "\"", 261, 0);
            EndWriteAttribute();
            WriteLiteral("/>\r\n\r\n    <script src=\"https://unpkg.com/leaflet@1.8.0/dist/leaflet.js\"\r\n   integrity=\"sha512-BB3hKbKWOc9Ez/TAwyWxNXeoV9c1v6FIeYiBieIWkpLjauysF18NzgR1MBNBXf8/KABdlkX68nAhlwcDFLGPCQ==\"");
            BeginWriteAttribute("crossorigin", "\r\n   crossorigin=\"", 445, "\"", 463, 0);
            EndWriteAttribute();
            WriteLiteral("></script>\r\n\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral(@"

<style type=""text/css"">
    #lat, #lon { text-align:right }
.address { cursor:pointer }
.address:hover { color:#AA0000;text-decoration:underline }
    #map{
        height: 400px;
        min-width: 60%;
        margin-left: 20px;
    }
    #addr{
        width: 60% !important;
    }
    .btn{
        margin: 0 5px !important;
    }
    .hidden{
        display: none;
    }
    .coord-input{
        margin-left: 20px;
    }
     input{
         margin-bottom: 5px;
     }
    .wrapper {
        margin-top: 10px;
        width: 100%;
        display: flex;
        justify-content: center;
        align-items: center;
    }
    .post-preview {
        width: 45%;
        height: 90vh;
    }
    .div-text {
        display: flex;
        justify-content: center;
        align-items: center;
        background-color: #5885AF;
        width: 45%;
        border-radius: 5%;
    }
    .flex {
        display: flex;
    }
    .btn-primary {
        margin: 20px 40px;");
                WriteLiteral(@"
    }
    
    #inner-posts {
        border: 1px solid black;
    }
        #inner-posts h1 {
            font-size: 20px;
            padding: 2% 2%;
        }
        #inner-posts p {
            font-size: 15px;
            padding: 2% 2%;
        }
</style>
");
            }
            );
            WriteLiteral("\r\n\r\n<section>\r\n    <div class=\"wrapper\">\r\n        <div class=\"row col-md-8 col-md-offset-2 div-text\">\r\n            <h1>Create post</h1>\r\n\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2ac53aaca348047f5540b0ce84e05f0fea5d568a7917", async() => {
                WriteLiteral(@"
                <div class=""form-group"">
                    <label for=""exampleInputEmail1"">Title</label>
                    <input type=""text""
                           name=""title""
                           class=""form-control together""
                           id=""exampleInputEmail1""
                           aria-describedby=""emailHelp""
                           placeholder=""Enter title"" /><br />
                    <small id=""emailHelp"" class=""form-text text-muted"">Please fill your title.</small>
                </div>

                <div class=""custom-file"">
                    <input type=""file""
                           name=""image""
                           class=""custom-file-input together""
                           id=""inputGroupFile01""
                           aria-describedby=""inputGroupFileAddon01"" />
                    <label class=""custom-file-label"" for=""inputGroupFile01"">Choose file</label>
                </div>
                <br />
                <d");
                WriteLiteral(@"iv class=""input-group"">
                    <textarea class=""form-control together""
                              name=""description""
                              aria-label=""With textarea""
                              id=""description""
                              placeholder=""description""></textarea>
                </div>
                <br />
                <select class=""form-select"" aria-label=""Default select example"">
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2ac53aaca348047f5540b0ce84e05f0fea5d568a9745", async() => {
                    WriteLiteral("Categories");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2ac53aaca348047f5540b0ce84e05f0fea5d568a11106", async() => {
                    WriteLiteral("House");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2ac53aaca348047f5540b0ce84e05f0fea5d568a12349", async() => {
                    WriteLiteral("Apartment");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2ac53aaca348047f5540b0ce84e05f0fea5d568a13596", async() => {
                    WriteLiteral("Office");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                </select>
                <br />
                <div class=""input-group together"">
                    <input type=""text""
                           class=""form-control""
                           id=""price""
                           aria-label=""Dollar amount (with dot and two decimal places)"" />
                    <div class=""input-group-append flex"">
                        <span class=""input-group-text"">$</span>
                        <span class=""input-group-text"">0.00</span>
                    </div>
                </div>
                <br />
                <input type=""text"" name=""City"" id=""city"" class=""hidden""/>
                <input type=""text"" name=""Country"" id=""country"" class=""hidden""/>
                <input type=""text"" name=""Neighbourhood"" id=""neighbourhood"" class=""hidden""/>
                <input type=""text"" name=""Road"" id=""road"" class=""hidden""/>
                <input type=""text"" name=""State"" id=""state"" class=""hidden""/>
                <input type=""n");
                WriteLiteral(@"umber"" name=""HouseNumber"" id=""housenumber"" class=""hidden""/>
                <input type=""number"" name=""ZipCode"" id=""zipcode"" class=""hidden""/>

<div class=""coord-input"">

<b>Coordinates</b>
<input type=""text"" name=""latitude"" id=""lat"" size=12 class='form-control'");
                BeginWriteAttribute("value", " value=\"", 4949, "\"", 4957, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n<input type=\"text\" name=\"longitude\" id=\"lon\" size=12 class=\'form-control\'");
                BeginWriteAttribute("value", " value=\"", 5034, "\"", 5042, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n</div>\r\n \r\n");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2ac53aaca348047f5540b0ce84e05f0fea5d568a16638", async() => {
                    WriteLiteral("\r\n<b>Search Address</b>\r\n<div id=\"search\">\r\n<input type=\"text\" name=\"addr\" class=\'form-control\'");
                    BeginWriteAttribute("value", " value=\"", 5158, "\"", 5166, 0);
                    EndWriteAttribute();
                    WriteLiteral(" id=\"addr\" size=\"58\" />\r\n<button type=\"button\" class=\'btn btn-primary\' onclick=\"addr_search();\">Search</button>\r\n</div>\r\n");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n<div id=\"results\"></div>\r\n\r\n\r\n<div style=\"display: flex;\">\r\n<div id=\"map\"></div>\r\n <h3 style=\"text-align: center\" id=\"currAddress\"></h3>\r\n</div>\r\n\r\n<input type=\"submit\" class=\"btn btn-primary\" value=\"Submit\" />\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

        </div>
        <div class=""second-div"" id=""post-preview"">
            <!-- <h1>Post Preview</h1>
                <div id=""inner-posts"">
                    <img src=""../imgs/"" alt="""">
                    <h1 class=""""></h1>
                    <p></p>
                </div> -->
        </div>
    </div>
</section>






");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2ac53aaca348047f5540b0ce84e05f0fea5d568a20117", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
<script>

//            var data=[];
//            let title = document.getElementById('exampleInputEmail1');
//            let file = document.getElementById('inputGroupFile01');
//            let description = document.getElementById('description');
//            var body = document.getElementById(""post-preview"");
//            let price= document.getElementById(""price"")
//            function postPreview(e){
//                e.preventDefault();
//                var text=`
//                <h1>Post Preview</h1>
//                 <div id=""inner-posts"">
//                    <h1>${title.value}</h1>
//                <p>${description.value}</p>
//                <p>${price.value}</p>
//            </div>`;
//                body.innerHTML +=text;
//}
//document.getElementById(""myForm"").addEventListener(""submit"",e=>postPreview(e));


</script>
");
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
