#pragma checksum "C:\Users\kevin\Desktop\codingDojo\C#\Products\Views\Home\ProductProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8aaed45eb459c23650e34e0f012dda64079b0723"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ProductProfile), @"mvc.1.0.view", @"/Views/Home/ProductProfile.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/ProductProfile.cshtml", typeof(AspNetCore.Views_Home_ProductProfile))]
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
#line 1 "C:\Users\kevin\Desktop\codingDojo\C#\Products\Views\_ViewImports.cshtml"
using Products;

#line default
#line hidden
#line 2 "C:\Users\kevin\Desktop\codingDojo\C#\Products\Views\_ViewImports.cshtml"
using Products.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8aaed45eb459c23650e34e0f012dda64079b0723", @"/Views/Home/ProductProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"148c3c49f2a018175631a3f0648da03bd8c1f699", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ProductProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(4, 8, true);
            WriteLiteral("    <h1>");
            EndContext();
            BeginContext(13, 20, false);
#line 2 "C:\Users\kevin\Desktop\codingDojo\C#\Products\Views\Home\ProductProfile.cshtml"
   Write(ViewBag.Profile.Name);

#line default
#line hidden
            EndContext();
            BeginContext(33, 34, true);
            WriteLiteral("</h1>\r\n    <h2>Categories: </h2>\r\n");
            EndContext();
#line 4 "C:\Users\kevin\Desktop\codingDojo\C#\Products\Views\Home\ProductProfile.cshtml"
    foreach(var x in ViewBag.Profile.ProductCategories) {

#line default
#line hidden
            BeginContext(126, 17, true);
            WriteLiteral("            <p>--");
            EndContext();
            BeginContext(144, 15, false);
#line 5 "C:\Users\kevin\Desktop\codingDojo\C#\Products\Views\Home\ProductProfile.cshtml"
            Write(x.Category.Name);

#line default
#line hidden
            EndContext();
            BeginContext(159, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 6 "C:\Users\kevin\Desktop\codingDojo\C#\Products\Views\Home\ProductProfile.cshtml"
    }

#line default
#line hidden
            BeginContext(175, 27, true);
            WriteLiteral("\r\n<h4>Add Category: </h4>\r\n");
            EndContext();
            BeginContext(202, 349, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8aaed45eb459c23650e34e0f012dda64079b07235034", async() => {
                BeginContext(280, 27, true);
                WriteLiteral("\r\n    <select name=\"cat\">\r\n");
                EndContext();
#line 12 "C:\Users\kevin\Desktop\codingDojo\C#\Products\Views\Home\ProductProfile.cshtml"
          
            foreach(var x in ViewBag.Categories) {

#line default
#line hidden
                BeginContext(371, 16, true);
                WriteLiteral("                ");
                EndContext();
                BeginContext(387, 44, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8aaed45eb459c23650e34e0f012dda64079b07235759", async() => {
                    BeginContext(416, 6, false);
#line 14 "C:\Users\kevin\Desktop\codingDojo\C#\Products\Views\Home\ProductProfile.cshtml"
                                       Write(x.Name);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 14 "C:\Users\kevin\Desktop\codingDojo\C#\Products\Views\Home\ProductProfile.cshtml"
                  WriteLiteral(x.CategoryId);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(431, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 15 "C:\Users\kevin\Desktop\codingDojo\C#\Products\Views\Home\ProductProfile.cshtml"
            }
        

#line default
#line hidden
                BeginContext(459, 85, true);
                WriteLiteral("    </select>\r\n    <input type=\"submit\"class=\"btn btn-success\"value=\"Add category\">\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 216, "/products/", 216, 10, true);
#line 10 "C:\Users\kevin\Desktop\codingDojo\C#\Products\Views\Home\ProductProfile.cshtml"
AddHtmlAttributeValue("", 226, ViewBag.Profile.ProductId, 226, 26, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 252, "/add-category", 252, 13, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
