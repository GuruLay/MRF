#pragma checksum "C:\WorkingFolder\GitHub\MRF\MRF.Web\Views\Inventory\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "22f601e5077b9a830bdf4d46fd123837c93ba8bf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Inventory_Index), @"mvc.1.0.view", @"/Views/Inventory/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Inventory/Index.cshtml", typeof(AspNetCore.Views_Inventory_Index))]
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
#line 1 "C:\WorkingFolder\GitHub\MRF\MRF.Web\Views\_ViewImports.cshtml"
using MRF.Web;

#line default
#line hidden
#line 2 "C:\WorkingFolder\GitHub\MRF\MRF.Web\Views\_ViewImports.cshtml"
using MRF.Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22f601e5077b9a830bdf4d46fd123837c93ba8bf", @"/Views/Inventory/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"83bd441ed3b638b2c56c20eeab9972f3dfd8f9b5", @"/Views/_ViewImports.cshtml")]
    public class Views_Inventory_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MRF.Web.ViewModels.InventoryIndexViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\WorkingFolder\GitHub\MRF\MRF.Web\Views\Inventory\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(92, 827, true);
            WriteLiteral(@"
<div class=""contentpanel"">
    <div class=""row pull-right"">
        <div class=""col-md-12"">
            <a class=""btn btn-primary"">Add</a>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-md-12"">
            <h5 class=""subtitle mb5"">Inventory List</h5>
            <p class=""mb20"">Show a Summary List of In and Out Products from All Warehouses</p>
            <div class=""table-responsive"">
                <table class=""table table-striped mb30"">
                    <thead>
                        <tr>
                            <th>Product Name</th>
                            <th>Quantity</th>
                            <th>DateTime</th>
                            <th>Warehouse</th>
                        </tr>
                    </thead>
                    <tbody>
");
            EndContext();
#line 27 "C:\WorkingFolder\GitHub\MRF\MRF.Web\Views\Inventory\Index.cshtml"
                         foreach (var inventory in Model.Inventories)
                        {

#line default
#line hidden
            BeginContext(1017, 70, true);
            WriteLiteral("                            <tr>\r\n                                <td>");
            EndContext();
            BeginContext(1088, 21, false);
#line 30 "C:\WorkingFolder\GitHub\MRF\MRF.Web\Views\Inventory\Index.cshtml"
                               Write(inventory.ProductName);

#line default
#line hidden
            EndContext();
            BeginContext(1109, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(1153, 18, false);
#line 31 "C:\WorkingFolder\GitHub\MRF\MRF.Web\Views\Inventory\Index.cshtml"
                               Write(inventory.Quantity);

#line default
#line hidden
            EndContext();
            BeginContext(1171, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(1215, 32, false);
#line 32 "C:\WorkingFolder\GitHub\MRF\MRF.Web\Views\Inventory\Index.cshtml"
                               Write(inventory.DateTime.ToString("d"));

#line default
#line hidden
            EndContext();
            BeginContext(1247, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(1291, 19, false);
#line 33 "C:\WorkingFolder\GitHub\MRF\MRF.Web\Views\Inventory\Index.cshtml"
                               Write(inventory.Warehouse);

#line default
#line hidden
            EndContext();
            BeginContext(1310, 42, true);
            WriteLiteral("</td>\r\n                            </tr>\r\n");
            EndContext();
#line 35 "C:\WorkingFolder\GitHub\MRF\MRF.Web\Views\Inventory\Index.cshtml"
                        }

#line default
#line hidden
            BeginContext(1379, 139, true);
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div><!-- table-responsive -->\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MRF.Web.ViewModels.InventoryIndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
