#pragma checksum "C:\Users\acater\Documents\NetTest\dotnetcode\InternalProject1\Views\Home\Add.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "386d8b075718686008a8b3f97257e24bf9090556"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Add), @"mvc.1.0.view", @"/Views/Home/Add.cshtml")]
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
#line 1 "C:\Users\acater\Documents\NetTest\dotnetcode\InternalProject1\Views\_ViewImports.cshtml"
using InternalProject1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\acater\Documents\NetTest\dotnetcode\InternalProject1\Views\_ViewImports.cshtml"
using InternalProject1.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"386d8b075718686008a8b3f97257e24bf9090556", @"/Views/Home/Add.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9eb3629d5598cb2496ec9c3f897cc43b030803eb", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Add : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<InternalProject1.Models.Employee>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1>\r\n    Employee Creation Page\r\n</h1>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "386d8b075718686008a8b3f97257e24bf90905563167", async() => {
                WriteLiteral("\r\n    Edit the fields below and use the button to confirm changes.\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<br></br>\r\n<div class=\"col-md-6\">\r\n");
#nullable restore
#line 11 "C:\Users\acater\Documents\NetTest\dotnetcode\InternalProject1\Views\Home\Add.cshtml"
    using(Html.BeginForm("AddEmployee","Home", FormMethod.Post)){
    

#line default
#line hidden
#nullable disable
            WriteLiteral("        <pre>Name:   ");
#nullable restore
#line 13 "C:\Users\acater\Documents\NetTest\dotnetcode\InternalProject1\Views\Home\Add.cshtml"
                Write(Html.TextBoxFor(m => m.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </pre>\r\n");
            WriteLiteral("        <pre>Role:   ");
#nullable restore
#line 15 "C:\Users\acater\Documents\NetTest\dotnetcode\InternalProject1\Views\Home\Add.cshtml"
                Write(Html.TextBoxFor(m => m.Role));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </pre>\r\n");
            WriteLiteral("        <pre>Email:  ");
#nullable restore
#line 17 "C:\Users\acater\Documents\NetTest\dotnetcode\InternalProject1\Views\Home\Add.cshtml"
                Write(Html.TextBoxFor(m => m.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </pre>\r\n        <br></br>\r\n    <div class = \"btn-group\">\r\n        <button type = \"submit\", class = \"btn-success\">Create</button>\r\n        <button type = \"reset\", class = \"btn-warning\">Clear</button>\r\n        ");
#nullable restore
#line 22 "C:\Users\acater\Documents\NetTest\dotnetcode\InternalProject1\Views\Home\Add.cshtml"
   Write(Html.ActionLink("Cancel","Index","Home",htmlAttributes: new {@class="btn btn-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 24 "C:\Users\acater\Documents\NetTest\dotnetcode\InternalProject1\Views\Home\Add.cshtml"
    
    
    
   }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<InternalProject1.Models.Employee> Html { get; private set; }
    }
}
#pragma warning restore 1591
