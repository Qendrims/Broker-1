#pragma checksum "C:\Users\HP\Desktop\Broker-1\dotnetwebApp\Broker\Views\Post\PostPageCreate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ead69641902a94f53fba21335f3f0709f388bc31"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ead69641902a94f53fba21335f3f0709f388bc31", @"/Views/Post/PostPageCreate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7849adb06ffd185482dc9353d14a61692eb94780", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Post_PostPageCreate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CreatePostViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("myForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PostPageCreate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/CreatePostMap.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<link rel=\"stylesheet\" href=\"https://unpkg.com/leaflet@1.8.0/dist/leaflet.css\"\r\n      integrity=\"sha512-hoalWLoI8r4UszCkZ5kL8vayOGVae1oxXe/2A4AO6J9+580uKHDO3JdHb7NzwwzK5xr/Fs0W40kiNHxM9vyTtQ==\"");
            BeginWriteAttribute("crossorigin", "\r\n      crossorigin=\"", 274, "\"", 295, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n\r\n<script src=\"https://unpkg.com/leaflet@1.8.0/dist/leaflet.js\"\r\n        integrity=\"sha512-BB3hKbKWOc9Ez/TAwyWxNXeoV9c1v6FIeYiBieIWkpLjauysF18NzgR1MBNBXf8/KABdlkX68nAhlwcDFLGPCQ==\"");
            BeginWriteAttribute("crossorigin", "\r\n        crossorigin=\"", 481, "\"", 504, 0);
            EndWriteAttribute();
            WriteLiteral("></script>\r\n\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral(@"

<style type=""text/css"">
    #lat, #lon {
        text-align: right
    }

    .address {
        cursor: pointer;
    }

        .address:not(:last-child) {
            border-bottom: 1px solid black
        }

        .address:hover {
            color: #AA0000;
            text-decoration: underline
        }

    #map {
        height: 400px;
        min-width: 70%;
        margin-left: 20px;
    }

    #addr {
        width: 80% !important;
    }

        #addr:focus {
            outline: none !important;
        }

    .btn {
        margin: 5px !important;
    }

    .hidden {
        display: none;
    }

    input {
        margin-bottom: 5px;
    }

    .wrapper {
        margin-top: 10px;
        width: 100%;
        display: flex;
        justify-content: center;
        align-items: center;
        background-image: url(../../wwwroot/Assets/Images/grid1.jpg);
    }

    .post-preview {
        width: 45%;
        height: 90vh;
    }

 ");
                WriteLiteral(@"   .div-text {
        display: flex;
        justify-content: center;
        align-items: center;
        background-color: #5885AF;
        width: 45%;
        border-radius: 5px;
    }

    .flex {
        display: flex;
    }

    .btn-primary {
        margin: 20px 40px;
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

    #search {
        display: flex;
        align-items: center;
    }

    .hidden{
        display: none;
    }

    #results {
        background-color: #fff;
        width: 80%;
        margin-top: -8px;
        border-radius: 5px;
        padding-left: 5px;
    }

    .custom-file {
        height: auto !important;
    }

    #uploadedImages {
        width: 90%;
        position: relative;
        margin: auto;
        display");
                WriteLiteral(": flex;\r\n        justify-content: space-evenly;\r\n        gap: 15px;\r\n        flex-wrap: wrap;\r\n    }\r\n\r\n    figure {\r\n        width: 45%;\r\n    }\r\n\r\n    img {\r\n        width: 100%;\r\n    }\r\n</style>\r\n");
            }
            );
            WriteLiteral("\r\n\r\n<section>\r\n    <div class=\"wrapper\">\r\n        <div class=\"row col-md-8 col-md-offset-2 div-text\">\r\n            <h1>Create post</h1>\r\n\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ead69641902a94f53fba21335f3f0709f388bc319211", async() => {
                WriteLiteral(@"
                <div class=""form-group"">
                    <label for=""exampleInputEmail1"">Title</label>
                    <input type=""text""
                           name=""title""
                           class=""form-control together""
                           id=""exampleInputEmail1""
                           aria-describedby=""emailHelp""
                           placeholder=""Enter title"" /><br />
");
                WriteLiteral(@"                </div>

                <div class=""custom-file"">
                    <input type=""file""
                           name=""Image""
                           class=""custom-file-input together""
                           id=""inputGroupFile01""
                           onchange=""preview()""
                           multiple
                           aria-describedby=""inputGroupFileAddon01"" />
                    <label class=""custom-file-label"" for=""inputGroupFile01"">Choose file</label>
                    <p id=""filesNumber"">No files chosen</p>
                    <div id=""uploadedImages""></div>
                </div>
                <br />
                <div class=""input-group"">
                    <textarea class=""form-control together""
                              name=""description""
                              aria-label=""With textarea""
                              id=""description""
                              placeholder=""description""></textarea>
               ");
                WriteLiteral(" </div>\r\n                <br />\r\n");
                WriteLiteral("\r\n                <label>Choose Categories</label>\r\n                <br />\r\n");
#nullable restore
#line 195 "C:\Users\HP\Desktop\Broker-1\dotnetwebApp\Broker\Views\Post\PostPageCreate.cshtml"
                 foreach(var cat in @Model.categories)
                {
                   

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <input name=\"CategoryId\" type=\"checkbox\"");
                BeginWriteAttribute("value", " value=\"", 5206, "\"", 5229, 1);
#nullable restore
#line 198 "C:\Users\HP\Desktop\Broker-1\dotnetwebApp\Broker\Views\Post\PostPageCreate.cshtml"
WriteAttributeValue("", 5214, cat.CategoryId, 5214, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /> ");
#nullable restore
#line 198 "C:\Users\HP\Desktop\Broker-1\dotnetwebApp\Broker\Views\Post\PostPageCreate.cshtml"
                                                                                   Write(cat.CategoryName);

#line default
#line hidden
#nullable disable
#nullable restore
#line 198 "C:\Users\HP\Desktop\Broker-1\dotnetwebApp\Broker\Views\Post\PostPageCreate.cshtml"
                                                                                                         
                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                <br />
                <div class=""input-group together"">
                    <input type=""text""
                           class=""form-control""
                           id=""price""
                           name=""Price""
                           aria-label=""Dollar amount (with dot and two decimal places)"" />
                    <div class=""input-group-append flex"">
                        <span class=""input-group-text"">$</span>
                        <span class=""input-group-text"">0.00</span>
                    </div>
                </div>
                <br />


                <b>Search Address</b>
                <div id=""search"">
                    <input type=""text"" name=""addr"" class='form-control'");
                BeginWriteAttribute("value", " value=\"", 6026, "\"", 6034, 0);
                EndWriteAttribute();
                WriteLiteral(@" id=""addr"" size=""58"" />
                    <button type=""button"" class='btn btn-primary' onclick=""addr_search();"">Search</button>
                </div>


                <div id=""results""></div>


                <div style=""display: flex; flex-direction: column;"">
                    <p>Please mark the address on map</p>
                    <div id=""map""></div>
                    <h4 style=""text-align: center"" id=""currAddress""></h4>
                </div>

                <div class=""coord-input"">

                    <b>Coordinates</b>
                    <input type=""text"" name=""Latitude"" id=""lat"" size=12 class='form-control'");
                BeginWriteAttribute("value", " value=\"", 6691, "\"", 6699, 0);
                EndWriteAttribute();
                WriteLiteral(" readonly>\r\n                    <input type=\"text\" name=\"Longitude\" id=\"lon\" size=12 class=\'form-control\'");
                BeginWriteAttribute("value", " value=\"", 6805, "\"", 6813, 0);
                EndWriteAttribute();
                WriteLiteral(@" readonly>
                </div>


                <label>City</label>
                <input type=""text"" name=""City"" id=""city"" class=""form-control disabled"" readonly />
                <label>Country</label>
                <input type=""text"" name=""Country"" id=""country"" class=""form-control disabled"" readonly />
                <label>Neighbourhood</label>
                <input type=""text"" name=""Neighbourhood"" id=""neighbourhood"" class=""form-control disabled"" readonly />
                <label>Road</label>
                <input type=""text"" name=""Street"" id=""road"" class=""form-control disabled"" readonly />
                <label>State</label>
                <input type=""text"" name=""State"" id=""state"" class=""form-control disabled"" readonly />
                <label>House Number</label>
                <input type=""number"" name=""HouseNumber"" id=""housenumber"" class=""form-control disabled"" readonly />
                <label>Zip Code</label>
                <input type=""number"" name=""ZipCode"" id=""");
                WriteLiteral(@"zipcode"" class=""form-control disabled"" readonly />

                 <br />
                <!-- Button trigger modal -->
                <button type=""button"" class=""btn btn-success"" data-toggle=""modal"" data-target=""#exampleModalCenter"">
                  Send Invitation
                </button>

                <!-- Modal -->
                <div class=""modal fade"" id=""exampleModalCenter"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalCenterTitle"" aria-hidden=""true"">
                  <div class=""modal-dialog modal-dialog-centered"" role=""document"">
                    <div class=""modal-content"">
                      <div class=""modal-header"">
                        <h5 class=""modal-title"" id=""exampleModalLongTitle"">Agents</h5>
                        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                          <span aria-hidden=""true"">&times;</span>
                        </button>
                      </div>
                      <d");
                WriteLiteral("iv class=\"modal-body\">\r\n                          <input type=\"text\" class=\"form-control\" id=\"searchAgents\" />\r\n");
#nullable restore
#line 272 "C:\Users\HP\Desktop\Broker-1\dotnetwebApp\Broker\Views\Post\PostPageCreate.cshtml"
                         foreach(var ag in @Model.agents){

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <div>\r\n                            <input type=\"checkbox\" name=\"agentsInvited\" class=\"agentList\"");
                BeginWriteAttribute("value", " value=\"", 9158, "\"", 9176, 1);
#nullable restore
#line 274 "C:\Users\HP\Desktop\Broker-1\dotnetwebApp\Broker\Views\Post\PostPageCreate.cshtml"
WriteAttributeValue("", 9166, ag.UserId, 9166, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /><span>");
#nullable restore
#line 274 "C:\Users\HP\Desktop\Broker-1\dotnetwebApp\Broker\Views\Post\PostPageCreate.cshtml"
                                                                                                                Write(ag.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 274 "C:\Users\HP\Desktop\Broker-1\dotnetwebApp\Broker\Views\Post\PostPageCreate.cshtml"
                                                                                                                         Write(ag.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" - ");
#nullable restore
#line 274 "C:\Users\HP\Desktop\Broker-1\dotnetwebApp\Broker\Views\Post\PostPageCreate.cshtml"
                                                                                                                                        Write(ag.City);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                        </div>\r\n");
#nullable restore
#line 276 "C:\Users\HP\Desktop\Broker-1\dotnetwebApp\Broker\Views\Post\PostPageCreate.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                      </div>
                      <div class=""modal-footer"">
                        <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                        <button type=""button"" class=""btn btn-primary"">Send invite</button>
                      </div>
                    </div>
                  </div>
                </div>

                 <br />

                <input type=""submit"" class=""btn btn-primary"" value=""Submit"" />
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ead69641902a94f53fba21335f3f0709f388bc3121426", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
<script>

      $(document).ready(()=>{

          document.getElementById('searchAgents').addEventListener('keyup',searchAgents)

              document.querySelectorAll('input, textarea').forEach(inp => {
              inp.addEventListener('change',onChange)
          })

          document.querySelector('form').addEventListener('submit',handleSubmit)


      })

      function searchAgents(e){
          var searchText = e.target.value;

          //if(e.target.value == """"){
          //    return;
          //} 
          var elements = document.querySelectorAll('.agentList');
          elements.forEach(el => {
              el.parentElement.classList.remove('hidden')
              if(!el.nextElementSibling.innerHTML.match(searchText)){
                  el.parentElement.classList.add('hidden')
              }
          })
      }


      const handleSubmit=(e)=>{
          e.preventDefault()
          var form = new FormData();
          for(var file of allFilesList){
");
                WriteLiteral(@"
              form.append(""image"",file);
          }
          var els=document.querySelectorAll('input, textarea');

          for(var el of els){
           if(el.type == ""submit"" || el.name == ""Image"" || el.id == ""addr""){
               continue;
           }

           if(el.name == ""CategoryId"" || el.name == ""agentsInvited""){
               if(el.checked)
                form.append(el.name,el.value);
           } 
           else {
               form.append(el.name,el.value);
           }

           //if(el.name == ""CategoryId"" && el.checked){
           //    form.append(el.name,el.value);
           //}else if(el.name == ""CategoryId"" && !el.checked){
           //    continue;
           //}

           //    form.append(el.name,el.value);
          }


           var req = new XMLHttpRequest();
  req.open(""POST"", ""/Post/PostPageCreate"", true);
  req.onload = function(oEvent) {
 console.log(req);
  };

  req.send(form);

    //      $.ajax({
    //          typ");
                WriteLiteral(@"e: ""post"",
    //          url: ""/Post/PostPageCreate"",
    //          method:""post"",
    //          data: form,
    //          dataType: ""json"",
    //          contentType: ""multipart/form-data; charset=utf-8"",
    //          processData: false,
    //          success: function(response){
    //              //if request if made successfully then the response represent the data
    //              console.log('u perfundua me sukses')
    //              $( ""#result"" ).empty().append( response );
    //          }
    //});
          
          return false;
      }


      var data = {};



      function onChange(e){
          e.preventDefault();
          data = {
              ...data,
              [e.target.name]: e.target.value
          }

      }

          let fileInput = document.getElementById('inputGroupFile01');
          let imgContainer = document.getElementById('uploadedImages');
          let numOfFiles = document.getElementById('filesNumber');
       ");
                WriteLiteral(@"       imgContainer.innerHTML = """";
              let allFilesList = [];

          function preview(){
          let fileList = [];

              for(i of fileInput.files){
                  fileList.push(i);
                  let fileAlreadyUploaded = allFilesList.some(file => file.name == i.name);

                  if(!fileAlreadyUploaded){
                  allFilesList.push(i)
                  }
 
              }

              numOfFiles.textContent = `${allFilesList.length} Files Selected`;

              for(i of fileList){
                   let reader = new FileReader();
                  let figure = document.createElement(""figure"");

                  reader.onload=()=>{

                      let img = document.createElement(""img"");

                      img.setAttribute(""src"",reader.result);
                      figure.appendChild(img);
                  }
                  imgContainer.appendChild(figure);
                  reader.readAsDataURL(i);
          ");
                WriteLiteral("    }\r\n\r\n          }\r\n\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CreatePostViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
