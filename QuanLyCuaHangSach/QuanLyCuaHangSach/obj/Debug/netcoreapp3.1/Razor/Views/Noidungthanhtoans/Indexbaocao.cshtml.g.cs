#pragma checksum "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "f667853716bf7ff354eede568c0324f8a49a828b4cc4ebf068e7a70b0a9d4b2f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Noidungthanhtoans_Indexbaocao), @"mvc.1.0.view", @"/Views/Noidungthanhtoans/Indexbaocao.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\_ViewImports.cshtml"
using QuanLyCuaHangSach;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\_ViewImports.cshtml"
using QuanLyCuaHangSach.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"f667853716bf7ff354eede568c0324f8a49a828b4cc4ebf068e7a70b0a9d4b2f", @"/Views/Noidungthanhtoans/Indexbaocao.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"e3b3f5241f1d2810f81c835c2b2f5d837a072a29c62f2abdad3d909fbef1aa2e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Noidungthanhtoans_Indexbaocao : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<QuanLyCuaHangSach.Models.Noidungthanhtoan>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/stylegd.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/icon.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("150px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-top:10px; margin-left:100px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = null;
    QLCHSContext context = new QLCHSContext();
    Nhanvien nv = context.Nhanviens.Find(Int32.Parse(User.Identity.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f667853716bf7ff354eede568c0324f8a49a828b4cc4ebf068e7a70b0a9d4b2f5856", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>QUẢN LÝ</title>
    <script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.6.4/jquery.min.js""></script>
    <!--sweetalert-->
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.js""></script>
    <link href=""https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.3/sweetalert.min.css"" rel=""stylesheet"" />
    <!--sweetalert.end-->


    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css"" />
");
                WriteLiteral("    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f667853716bf7ff354eede568c0324f8a49a828b4cc4ebf068e7a70b0a9d4b2f6865", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
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
            WriteLiteral(@"

<script>
    var object = { stat: false, ele: null };
    function ConfirmDelete(ev) {
        if (object.stat) { return true; };
        swal({
            title: ""Are you sure?"",
            text: ""Are you want to delete this item!"",
            type: ""warning"",
            showCancelButton: true,
            cancelButtonColor: ""#DD6B55"",
            confirmButtonColor: ""#DD6B55"",
            confirmButtonText: ""Confirm"",
            closeOnConfirm: true
        },
            function () {
                //swal(""Deleted!"", ""Your imaginary file has been deleted."", ""success"");
                object.stat = true;
                object.ele = ev;
                object.ele.click();
            });
        return false;
    };
</script>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f667853716bf7ff354eede568c0324f8a49a828b4cc4ebf068e7a70b0a9d4b2f9565", async() => {
                WriteLiteral("\r\n\r\n");
#nullable restore
#line 57 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
     if (@TempData["AlertMessage1"] != null)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <script>\r\n            swal({\r\n                type: \'success\',\r\n                title: \'Success!\',\r\n                text: \'");
#nullable restore
#line 63 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
                  Write(TempData["AlertMessage1"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\',\r\n                showCloseButton: true,\r\n                confirmButtonText: \'Close\'\r\n            });\r\n        </script>\r\n");
#nullable restore
#line 68 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 70 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
     if (@TempData["AlertMessagetk"] != null)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <script>\r\n            swal({\r\n                type: \'warning\',\r\n                title: \'Not Found\',\r\n                text: \'");
#nullable restore
#line 76 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
                  Write(TempData["AlertMessagetk"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\',\r\n                showCloseButton: true,\r\n                confirmButtonText: \'Close\'\r\n            });\r\n        </script>\r\n");
#nullable restore
#line 81 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <div class=\"menu-bar\">\r\n        <h1 class=\"logo\">");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f667853716bf7ff354eede568c0324f8a49a828b4cc4ebf068e7a70b0a9d4b2f11897", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</h1>\r\n        <ul>\r\n");
                WriteLiteral(@"            <li>
                <a href=""#"">Danh mục<i class=""fas fa-caret-down iconbar""></i></a>
                <div class=""dropdown-menu"">
                    <ul>
                        <li>
                            <a href=""#"">Chi tiết sách<i class=""fas fa-caret-right iconbar""></i></a>

                            <div class=""dropdown-menu-1"">
                                <ul>
                                    <li><a");
                BeginWriteAttribute("href", " href=\"", 3243, "\"", 3280, 1);
#nullable restore
#line 97 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
WriteAttributeValue("", 3250, Url.Action("Index","Tacgias"), 3250, 30, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Tác giả</a></li>\r\n                                    <li><a");
                BeginWriteAttribute("href", " href=\"", 3342, "\"", 3382, 1);
#nullable restore
#line 98 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
WriteAttributeValue("", 3349, Url.Action("Index","Loaisaches"), 3349, 33, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Loại sách</a></li>\r\n                                    <li><a");
                BeginWriteAttribute("href", " href=\"", 3446, "\"", 3487, 1);
#nullable restore
#line 99 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
WriteAttributeValue("", 3453, Url.Action("Index","Nhaxuatbans"), 3453, 34, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Nhà xuất bản</a></li>\r\n                                    <li><a");
                BeginWriteAttribute("href", " href=\"", 3554, "\"", 3592, 1);
#nullable restore
#line 100 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
WriteAttributeValue("", 3561, Url.Action("Index","Ngonngus"), 3561, 31, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Ngôn ngữ</a></li>\r\n                                </ul>\r\n                            </div>\r\n                        </li>\r\n                        <li><a");
                BeginWriteAttribute("href", " href=\"", 3749, "\"", 3785, 1);
#nullable restore
#line 104 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
WriteAttributeValue("", 3756, Url.Action("Index","Saches"), 3756, 29, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Sách</a></li>\r\n                        <li><a");
                BeginWriteAttribute("href", " href=\"", 3832, "\"", 3871, 1);
#nullable restore
#line 105 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
WriteAttributeValue("", 3839, Url.Action("Index","Nganhangs"), 3839, 32, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">Ngân hàng</a></li>
                        <li>
                            <a href=""#"">Đối tác<i class=""fas fa-caret-right iconbar""></i></a>

                            <div class=""dropdown-menu-1"">
                                <ul>
                                    <li><a");
                BeginWriteAttribute("href", " href=\"", 4159, "\"", 4200, 1);
#nullable restore
#line 111 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
WriteAttributeValue("", 4166, Url.Action("Index","Nhacungcaps"), 4166, 34, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Nhà cung cấp</a></li>\r\n                                    <li><a");
                BeginWriteAttribute("href", " href=\"", 4267, "\"", 4312, 1);
#nullable restore
#line 112 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
WriteAttributeValue("", 4274, Url.Action("Index","Donvivanchuyens"), 4274, 38, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">Đơn vị vận chuyển</a></li>
                                </ul>
                            </div>
                        </li>
                        <li>
                            <a href=""#"">Người dùng<i class=""fas fa-caret-right iconbar""></i></a>

                            <div class=""dropdown-menu-1"">
                                <ul>
                                    <li><a");
                BeginWriteAttribute("href", " href=\"", 4717, "\"", 4756, 1);
#nullable restore
#line 121 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
WriteAttributeValue("", 4724, Url.Action("Index","Nhanviens"), 4724, 32, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Nhân viên</a></li>\r\n                                    <li><a");
                BeginWriteAttribute("href", " href=\"", 4820, "\"", 4860, 1);
#nullable restore
#line 122 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
WriteAttributeValue("", 4827, Url.Action("Index","Khachhangs"), 4827, 33, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Khách hàng</a></li>\r\n                                </ul>\r\n                            </div>\r\n                        </li>\r\n                        <li><a");
                BeginWriteAttribute("href", " href=\"", 5019, "\"", 5054, 1);
#nullable restore
#line 126 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
WriteAttributeValue("", 5026, Url.Action("Index","Httts"), 5026, 28, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Hình thức thanh toán</a></li>\r\n                        <li><a");
                BeginWriteAttribute("href", " href=\"", 5117, "\"", 5157, 1);
#nullable restore
#line 127 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
WriteAttributeValue("", 5124, Url.Action("Index","Trangthais"), 5124, 33, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">Trạng thái</a></li>
                    </ul>
                </div>
            </li>

            <li>
                <a href=""#"">Quản lý<i class=""fas fa-caret-down iconbar""></i></a>
                <div class=""dropdown-menu"">
                    <ul>
                        <li>
                            <a href=""#"">Đặt hàng mua<i class=""fas fa-caret-right iconbar""></i></a>

                            <div class=""dropdown-menu-1"">
                                <ul>
                                    <li><a");
                BeginWriteAttribute("href", " href=\"", 5694, "\"", 5740, 1);
#nullable restore
#line 141 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
WriteAttributeValue("", 5701, Url.Action("Index","Phieudathangmuas"), 5701, 39, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Phiếu đặt hàng mua</a></li>\r\n                                    <li><a");
                BeginWriteAttribute("href", " href=\"", 5813, "\"", 5865, 1);
#nullable restore
#line 142 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
WriteAttributeValue("", 5820, Url.Action("Index","Phieuthanhtoantienmuas"), 5820, 45, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">Phiếu thanh toán</a></li>
                                </ul>
                            </div>
                        </li>

                        <li>
                            <a href=""#"">Đặt hàng bán<i class=""fas fa-caret-right iconbar""></i></a>

                            <div class=""dropdown-menu-1"">
                                <ul>
                                    <li><a");
                BeginWriteAttribute("href", " href=\"", 6273, "\"", 6319, 1);
#nullable restore
#line 152 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
WriteAttributeValue("", 6280, Url.Action("Index","Phieudathangbans"), 6280, 39, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Phiếu đặt hàng bán</a></li>\r\n                                    <li><a");
                BeginWriteAttribute("href", " href=\"", 6392, "\"", 6438, 1);
#nullable restore
#line 153 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
WriteAttributeValue("", 6399, Url.Action("Index","Phieuthutienbans"), 6399, 39, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Phiếu thu tiền</a></li>\r\n                                </ul>\r\n                            </div>\r\n                        </li>\r\n\r\n                        <li><a");
                BeginWriteAttribute("href", " href=\"", 6603, "\"", 6656, 1);
#nullable restore
#line 158 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
WriteAttributeValue("", 6610, Url.Action("Indexxacnhan","Phieudathangmuas"), 6610, 46, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Xác nhận đặt hàng</a></li>\r\n\r\n                    </ul>\r\n                </div>\r\n            </li>\r\n\r\n            <li><a");
                BeginWriteAttribute("href", " href=\"", 6778, "\"", 6826, 1);
#nullable restore
#line 164 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
WriteAttributeValue("", 6785, Url.Action("Indexbaocao","Chitietnhaps"), 6785, 41, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Báo Cáo</a></li>\r\n");
#nullable restore
#line 165 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
             if (nv == null)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <li><a href=\"/login\">Đăng nhập</a></li>\r\n");
#nullable restore
#line 168 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"

            }
            else
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <li><a href=\"/Login/Logout\">Đăng xuất</a></li>\r\n");
#nullable restore
#line 173 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </ul>\r\n    </div>\r\n\r\n    <div class=\"table\">\r\n        <div class=\"table_header\">\r\n            <p>Báo cáo thanh toán</p>\r\n            <div>\r\n");
                WriteLiteral(@"
            </div>
        </div>
        <div class=""table-section"">
            <table>
                <thead>
                    <tr>
                        <th>
                            Số phiếu đặt hàng mua
                        </th>
                        <th>
                            Số phiếu thanh toán
                        </th>
                        <th>
                            Số tiền thanh toán
                        </th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 202 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\r\n\r\n                            <td>\r\n                                ");
#nullable restore
#line 207 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
                           Write(Html.DisplayFor(modelItem => item.PhieudathangmuaidpdhmNavigation.Sopdhm));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 210 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
                           Write(Html.DisplayFor(modelItem => item.PhieuthanhtoantienmuaidptttmNavigation.Soptttm));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </td>\r\n                            <td style=\"text-align:right;\">\r\n                                ");
#nullable restore
#line 213 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
                           Write(string.Format("{0:#,0}", @item.Sotienthanhtoan));

#line default
#line hidden
#nullable disable
                WriteLiteral("VND\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 216 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthanhtoans\Indexbaocao.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n");
                WriteLiteral("    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</html>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<QuanLyCuaHangSach.Models.Noidungthanhtoan>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
