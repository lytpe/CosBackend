#pragma checksum "f:\Cos\Views\Mail\ShowMessage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4e018723fa9c7049786fd34e82eb8b424c1466f8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Mail_ShowMessage), @"mvc.1.0.view", @"/Views/Mail/ShowMessage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Mail/ShowMessage.cshtml", typeof(AspNetCore.Views_Mail_ShowMessage))]
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
#line 1 "f:\Cos\Views\_ViewImports.cshtml"
using Cos;

#line default
#line hidden
#line 2 "f:\Cos\Views\_ViewImports.cshtml"
using Cos.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e018723fa9c7049786fd34e82eb8b424c1466f8", @"/Views/Mail/ShowMessage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be9cb30d7b68c21ac3dd70274be853f13d3a0b5a", @"/Views/_ViewImports.cshtml")]
    public class Views_Mail_ShowMessage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "f:\Cos\Views\Mail\ShowMessage.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
            BeginContext(32, 4, true);
            WriteLiteral("<h1>");
            EndContext();
            BeginContext(37, 17, false);
#line 4 "f:\Cos\Views\Mail\ShowMessage.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(54, 369, true);
            WriteLiteral(@"</h1>

<p>Use this page to detail your site's Mail</p>
<div id=""bigpic""></div>
<script>
    	$.ajax({
		url:'/Mail/ShowMessag',
		type:'GET',
		dataType:'Json',
		contentType:""application/json"",
		success:function(data, textStatus){
			console.log(data);
			$(""#bigpic"").html(data);
		},
		error:function(){
			console.log(""请求失败!"");
		}
	});
</script>");
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