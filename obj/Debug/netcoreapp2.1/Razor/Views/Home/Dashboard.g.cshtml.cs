#pragma checksum "C:\Users\rober\Desktop\Code Dojo\CSharp\exam\Views\Home\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d5fbb06f6968d3fd3b9b309cba4b01b9c95bb2d2"
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
#line 1 "C:\Users\rober\Desktop\Code Dojo\CSharp\exam\Views\_ViewImports.cshtml"
using exam;

#line default
#line hidden
#line 2 "C:\Users\rober\Desktop\Code Dojo\CSharp\exam\Views\_ViewImports.cshtml"
using exam.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5fbb06f6968d3fd3b9b309cba4b01b9c95bb2d2", @"/Views/Home/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ecb2a55d59d82a6188c718c6158103bf5dc00b82", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 55, true);
            WriteLiteral("<h1>Dojo Activity Center</h1> \r\n<p ALIGN=RIGHT>Welcome ");
            EndContext();
            BeginContext(56, 12, false);
#line 2 "C:\Users\rober\Desktop\Code Dojo\CSharp\exam\Views\Home\Dashboard.cshtml"
                  Write(ViewBag.Name);

#line default
#line hidden
            EndContext();
            BeginContext(68, 470, true);
            WriteLiteral(@"!<a href=""../logout"">
        <button>Logout</button> </p> </a>

<table class=""table"">
    <thead class=""thead-dark"">
        <tr>
            <th scope=""col"">Activity</th>
            <th scope=""col"">Date and Time</th>
            <th scope=""col"">Duration</th>
            <th scope=""col"">Event Coordinator</th>
            <th scope=""col"">Number of Participants</th>
            <th scope=""col"">Actions</th>
        </tr>
        </thead>
    <tbody>

");
            EndContext();
#line 18 "C:\Users\rober\Desktop\Code Dojo\CSharp\exam\Views\Home\Dashboard.cshtml"
         foreach(var something in @ViewBag.Activity)
        {
            DateTime CurrentTime = DateTime.Now;
            if(@something.Date > CurrentTime)
            {

#line default
#line hidden
            BeginContext(715, 16, true);
            WriteLiteral("<tr>\r\n      <td>");
            EndContext();
            BeginContext(732, 13, false);
#line 24 "C:\Users\rober\Desktop\Code Dojo\CSharp\exam\Views\Home\Dashboard.cshtml"
     Write(something.Act);

#line default
#line hidden
            EndContext();
            BeginContext(745, 3, true);
            WriteLiteral(" <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 748, "\"", 788, 2);
            WriteAttributeValue("", 755, "../activity/", 755, 12, true);
#line 24 "C:\Users\rober\Desktop\Code Dojo\CSharp\exam\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 767, something.ActivityId, 767, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(789, 78, true);
            WriteLiteral("><button>View\r\n                        Activity</button></a> </td>\r\n      <td>");
            EndContext();
            BeginContext(868, 34, false);
#line 26 "C:\Users\rober\Desktop\Code Dojo\CSharp\exam\Views\Home\Dashboard.cshtml"
     Write(something.Date.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(902, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(904, 14, false);
#line 26 "C:\Users\rober\Desktop\Code Dojo\CSharp\exam\Views\Home\Dashboard.cshtml"
                                         Write(something.Time);

#line default
#line hidden
            EndContext();
            BeginContext(918, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 27 "C:\Users\rober\Desktop\Code Dojo\CSharp\exam\Views\Home\Dashboard.cshtml"
       if(something.Duration <= 60)
            {

#line default
#line hidden
            BeginContext(977, 20, true);
            WriteLiteral("                <td>");
            EndContext();
            BeginContext(998, 18, false);
#line 29 "C:\Users\rober\Desktop\Code Dojo\CSharp\exam\Views\Home\Dashboard.cshtml"
               Write(something.Duration);

#line default
#line hidden
            EndContext();
            BeginContext(1016, 15, true);
            WriteLiteral(" Minutes</td>\r\n");
            EndContext();
#line 30 "C:\Users\rober\Desktop\Code Dojo\CSharp\exam\Views\Home\Dashboard.cshtml"
            }
            else if(something.Duration <= 1440)
            {
                int duration = something.Duration/60;

#line default
#line hidden
            BeginContext(1165, 20, true);
            WriteLiteral("                <td>");
            EndContext();
            BeginContext(1186, 8, false);
#line 34 "C:\Users\rober\Desktop\Code Dojo\CSharp\exam\Views\Home\Dashboard.cshtml"
               Write(duration);

#line default
#line hidden
            EndContext();
            BeginContext(1194, 13, true);
            WriteLiteral(" Hours</td>\r\n");
            EndContext();
#line 35 "C:\Users\rober\Desktop\Code Dojo\CSharp\exam\Views\Home\Dashboard.cshtml"
            }
            else
            {
                int duration = something.Duration/1440;

#line default
#line hidden
            BeginContext(1312, 20, true);
            WriteLiteral("                <td>");
            EndContext();
            BeginContext(1333, 8, false);
#line 39 "C:\Users\rober\Desktop\Code Dojo\CSharp\exam\Views\Home\Dashboard.cshtml"
               Write(duration);

#line default
#line hidden
            EndContext();
            BeginContext(1341, 12, true);
            WriteLiteral(" Days</td>\r\n");
            EndContext();
#line 40 "C:\Users\rober\Desktop\Code Dojo\CSharp\exam\Views\Home\Dashboard.cshtml"
            }

#line default
#line hidden
            BeginContext(1368, 10, true);
            WriteLiteral("\r\n    <td>");
            EndContext();
            BeginContext(1379, 21, false);
#line 42 "C:\Users\rober\Desktop\Code Dojo\CSharp\exam\Views\Home\Dashboard.cshtml"
   Write(something.Coordinator);

#line default
#line hidden
            EndContext();
            BeginContext(1400, 23, true);
            WriteLiteral("</td>\r\n    \r\n      <td>");
            EndContext();
            BeginContext(1424, 23, false);
#line 44 "C:\Users\rober\Desktop\Code Dojo\CSharp\exam\Views\Home\Dashboard.cshtml"
     Write(something.ActRSVP.Count);

#line default
#line hidden
            EndContext();
            BeginContext(1447, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 45 "C:\Users\rober\Desktop\Code Dojo\CSharp\exam\Views\Home\Dashboard.cshtml"
             if (@ViewBag.User == @something.UserId)
            {

#line default
#line hidden
            BeginContext(1523, 19, true);
            WriteLiteral("            <td> <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1542, "\"", 1580, 2);
            WriteAttributeValue("", 1549, "../delete/", 1549, 10, true);
#line 47 "C:\Users\rober\Desktop\Code Dojo\CSharp\exam\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 1559, something.ActivityId, 1559, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1581, 36, true);
            WriteLiteral("><button>Delete</button></a> </td>\r\n");
            EndContext();
#line 48 "C:\Users\rober\Desktop\Code Dojo\CSharp\exam\Views\Home\Dashboard.cshtml"
            }
            else
            {
                bool temp = false;
                

#line default
#line hidden
#line 52 "C:\Users\rober\Desktop\Code Dojo\CSharp\exam\Views\Home\Dashboard.cshtml"
                 foreach(var a in @something.ActRSVP)
                {
                    if (a.UserId == @ViewBag.User)
                    {
                    temp = true;
                    }
                }

#line default
#line hidden
#line 58 "C:\Users\rober\Desktop\Code Dojo\CSharp\exam\Views\Home\Dashboard.cshtml"
                 

                if (temp == false)
                {

#line default
#line hidden
            BeginContext(1983, 44, true);
            WriteLiteral("                <td>\r\n                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2027, "\"", 2075, 4);
            WriteAttributeValue("", 2034, "/RSVP/", 2034, 6, true);
#line 63 "C:\Users\rober\Desktop\Code Dojo\CSharp\exam\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 2040, something.ActivityId, 2040, 21, false);

#line default
#line hidden
            WriteAttributeValue("", 2061, "/", 2061, 1, true);
#line 63 "C:\Users\rober\Desktop\Code Dojo\CSharp\exam\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 2062, ViewBag.User, 2062, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2076, 44, true);
            WriteLiteral("><button>Join</button></a>\r\n                ");
            EndContext();
            BeginContext(2121, 17, false);
#line 64 "C:\Users\rober\Desktop\Code Dojo\CSharp\exam\Views\Home\Dashboard.cshtml"
           Write(ViewBag.samedayrs);

#line default
#line hidden
            EndContext();
            BeginContext(2138, 27, true);
            WriteLiteral("\r\n\r\n                </td>\r\n");
            EndContext();
#line 67 "C:\Users\rober\Desktop\Code Dojo\CSharp\exam\Views\Home\Dashboard.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(2225, 52, true);
            WriteLiteral("                    <td>\r\n                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2277, "\"", 2327, 4);
            WriteAttributeValue("", 2284, "/unRSVP/", 2284, 8, true);
#line 71 "C:\Users\rober\Desktop\Code Dojo\CSharp\exam\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 2292, something.ActivityId, 2292, 21, false);

#line default
#line hidden
            WriteAttributeValue("", 2313, "/", 2313, 1, true);
#line 71 "C:\Users\rober\Desktop\Code Dojo\CSharp\exam\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 2314, ViewBag.User, 2314, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2328, 82, true);
            WriteLiteral("><button>Leave\r\n                        </button></a>\r\n                    </td>\r\n");
            EndContext();
#line 74 "C:\Users\rober\Desktop\Code Dojo\CSharp\exam\Views\Home\Dashboard.cshtml"
                }
            }

#line default
#line hidden
            BeginContext(2444, 11, true);
            WriteLiteral("    </tr>\r\n");
            EndContext();
#line 77 "C:\Users\rober\Desktop\Code Dojo\CSharp\exam\Views\Home\Dashboard.cshtml"
    }
        }

#line default
#line hidden
            BeginContext(2473, 123, true);
            WriteLiteral("  </tbody>\r\n</table>\r\n\r\n\r\n        <p ALIGN=RIGHT><a href=\"/new\">\r\n        <button>Add New Activity</button> </p> </a>\r\n\r\n\r\n");
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
