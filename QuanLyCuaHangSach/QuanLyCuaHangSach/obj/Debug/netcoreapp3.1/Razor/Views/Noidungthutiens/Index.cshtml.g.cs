#pragma checksum "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "51779c2de7ffee086fcde9cf2f8111c3c54713d052a05058a56a037c33eb1dbd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Noidungthutiens_Index), @"mvc.1.0.view", @"/Views/Noidungthutiens/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"51779c2de7ffee086fcde9cf2f8111c3c54713d052a05058a56a037c33eb1dbd", @"/Views/Noidungthutiens/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"e3b3f5241f1d2810f81c835c2b2f5d837a072a29c62f2abdad3d909fbef1aa2e", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Noidungthutiens_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<QuanLyCuaHangSach.Models.Noidungthutien>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/stylegd.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/icon.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("150px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-top:10px; margin-left:100px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Sửa"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = null;
    QLCHSContext context = new QLCHSContext();
    Nhanvien nv = context.Nhanviens.Find(Int32.Parse(User.Identity.Name));
    Phieuthutienban pttb = TempData["phieuthutienban"] as Phieuthutienban;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "51779c2de7ffee086fcde9cf2f8111c3c54713d052a05058a56a037c33eb1dbd6656", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "51779c2de7ffee086fcde9cf2f8111c3c54713d052a05058a56a037c33eb1dbd7665", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "51779c2de7ffee086fcde9cf2f8111c3c54713d052a05058a56a037c33eb1dbd10365", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 57 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
     if (@TempData["AlertMessage1"] != null)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <script>\r\n            swal({\r\n                type: \'success\',\r\n                title: \'Success!\',\r\n                text: \'");
#nullable restore
#line 63 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
                  Write(TempData["AlertMessage1"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\',\r\n                showCloseButton: true,\r\n                confirmButtonText: \'Close\'\r\n            });\r\n        </script>\r\n");
#nullable restore
#line 68 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 70 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
     if (@TempData["AlertMessagetk"] != null)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <script>\r\n            swal({\r\n                type: \'warning\',\r\n                title: \'Not Found\',\r\n                text: \'");
#nullable restore
#line 76 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
                  Write(TempData["AlertMessagetk"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\',\r\n                showCloseButton: true,\r\n                confirmButtonText: \'Close\'\r\n            });\r\n        </script>\r\n");
#nullable restore
#line 81 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("    <div class=\"menu-bar\">\r\n        <h1 class=\"logo\">");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "51779c2de7ffee086fcde9cf2f8111c3c54713d052a05058a56a037c33eb1dbd12642", async() => {
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
                BeginWriteAttribute("href", " href=\"", 3313, "\"", 3350, 1);
#nullable restore
#line 96 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
WriteAttributeValue("", 3320, Url.Action("Index","Tacgias"), 3320, 30, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Tác giả</a></li>\r\n                                    <li><a");
                BeginWriteAttribute("href", " href=\"", 3412, "\"", 3452, 1);
#nullable restore
#line 97 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
WriteAttributeValue("", 3419, Url.Action("Index","Loaisaches"), 3419, 33, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Loại sách</a></li>\r\n                                    <li><a");
                BeginWriteAttribute("href", " href=\"", 3516, "\"", 3557, 1);
#nullable restore
#line 98 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
WriteAttributeValue("", 3523, Url.Action("Index","Nhaxuatbans"), 3523, 34, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Nhà xuất bản</a></li>\r\n                                    <li><a");
                BeginWriteAttribute("href", " href=\"", 3624, "\"", 3662, 1);
#nullable restore
#line 99 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
WriteAttributeValue("", 3631, Url.Action("Index","Ngonngus"), 3631, 31, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Ngôn ngữ</a></li>\r\n                                </ul>\r\n                            </div>\r\n                        </li>\r\n                        <li><a");
                BeginWriteAttribute("href", " href=\"", 3819, "\"", 3855, 1);
#nullable restore
#line 103 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
WriteAttributeValue("", 3826, Url.Action("Index","Saches"), 3826, 29, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Sách</a></li>\r\n                        <li><a");
                BeginWriteAttribute("href", " href=\"", 3902, "\"", 3941, 1);
#nullable restore
#line 104 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
WriteAttributeValue("", 3909, Url.Action("Index","Nganhangs"), 3909, 32, false);

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
                BeginWriteAttribute("href", " href=\"", 4229, "\"", 4270, 1);
#nullable restore
#line 110 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
WriteAttributeValue("", 4236, Url.Action("Index","Nhacungcaps"), 4236, 34, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Nhà cung cấp</a></li>\r\n                                    <li><a");
                BeginWriteAttribute("href", " href=\"", 4337, "\"", 4382, 1);
#nullable restore
#line 111 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
WriteAttributeValue("", 4344, Url.Action("Index","Donvivanchuyens"), 4344, 38, false);

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
                BeginWriteAttribute("href", " href=\"", 4787, "\"", 4826, 1);
#nullable restore
#line 120 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
WriteAttributeValue("", 4794, Url.Action("Index","Nhanviens"), 4794, 32, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Nhân viên</a></li>\r\n                                    <li><a");
                BeginWriteAttribute("href", " href=\"", 4890, "\"", 4930, 1);
#nullable restore
#line 121 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
WriteAttributeValue("", 4897, Url.Action("Index","Khachhangs"), 4897, 33, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Khách hàng</a></li>\r\n                                </ul>\r\n                            </div>\r\n                        </li>\r\n                        <li><a");
                BeginWriteAttribute("href", " href=\"", 5089, "\"", 5124, 1);
#nullable restore
#line 125 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
WriteAttributeValue("", 5096, Url.Action("Index","Httts"), 5096, 28, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Hình thức thanh toán</a></li>\r\n                        <li><a");
                BeginWriteAttribute("href", " href=\"", 5187, "\"", 5227, 1);
#nullable restore
#line 126 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
WriteAttributeValue("", 5194, Url.Action("Index","Trangthais"), 5194, 33, false);

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
                BeginWriteAttribute("href", " href=\"", 5764, "\"", 5810, 1);
#nullable restore
#line 140 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
WriteAttributeValue("", 5771, Url.Action("Index","Phieudathangmuas"), 5771, 39, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Phiếu đặt hàng mua</a></li>\r\n                                    <li><a");
                BeginWriteAttribute("href", " href=\"", 5883, "\"", 5935, 1);
#nullable restore
#line 141 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
WriteAttributeValue("", 5890, Url.Action("Index","Phieuthanhtoantienmuas"), 5890, 45, false);

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
                BeginWriteAttribute("href", " href=\"", 6343, "\"", 6389, 1);
#nullable restore
#line 151 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
WriteAttributeValue("", 6350, Url.Action("Index","Phieudathangbans"), 6350, 39, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Phiếu đặt hàng bán</a></li>\r\n                                    <li><a");
                BeginWriteAttribute("href", " href=\"", 6462, "\"", 6508, 1);
#nullable restore
#line 152 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
WriteAttributeValue("", 6469, Url.Action("Index","Phieuthutienbans"), 6469, 39, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Phiếu thu tiền</a></li>\r\n                                </ul>\r\n                            </div>\r\n                        </li>\r\n\r\n                        <li><a");
                BeginWriteAttribute("href", " href=\"", 6673, "\"", 6726, 1);
#nullable restore
#line 157 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
WriteAttributeValue("", 6680, Url.Action("Indexxacnhan","Phieudathangmuas"), 6680, 46, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Xác nhận đặt hàng</a></li>\r\n\r\n                    </ul>\r\n                </div>\r\n            </li>\r\n\r\n            <li><a");
                BeginWriteAttribute("href", " href=\"", 6848, "\"", 6896, 1);
#nullable restore
#line 163 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
WriteAttributeValue("", 6855, Url.Action("Indexbaocao","Chitietnhaps"), 6855, 41, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Báo Cáo</a></li>\r\n");
#nullable restore
#line 164 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
             if (nv == null)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <li><a href=\"/login\">Đăng nhập</a></li>\r\n");
#nullable restore
#line 167 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"

            }
            else
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <li><a href=\"/Login/Logout\">Đăng xuất</a></li>\r\n");
#nullable restore
#line 172 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </ul>\r\n    </div>\r\n\r\n    <div class=\"btn_backdiv\">\r\n        <a");
                BeginWriteAttribute("href", " href=\"", 7217, "\"", 7263, 1);
#nullable restore
#line 177 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
WriteAttributeValue("", 7224, Url.Action("Index","Phieuthutienbans"), 7224, 39, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"btn_back\">Quay lại</a>\r\n    </div>\r\n\r\n    <div class=\"table\">\r\n        <div class=\"table_header\">\r\n            <p>Nội dung thu tiền</p>\r\n            <div>\r\n                <a");
                BeginWriteAttribute("href", " href=\"", 7446, "\"", 7523, 1);
#nullable restore
#line 184 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
WriteAttributeValue("", 7453, Url.Action("Create", "Noidungthutiens", new { Idpttb = pttb.Idpttb }), 7453, 70, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""add_new"">+ Thêm Mới</a>
            </div>
        </div>
        <div class=""table-section"">
            <table>
                <thead>
                    <tr>
                        
                        <th>
                            Số phiếu đặt hàng bán
                        </th>
                        <th>
                            Số phiếu thu tiền
                        </th>
                        <th>
                            Số tiền thu
                        </th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 205 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\r\n                            \r\n                            <td>\r\n                                ");
#nullable restore
#line 210 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.PhieudathangbanidpdhbNavigation.Sopdhb));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 213 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.PhieuthutienbanidpttbNavigation.Sopttb));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </td>\r\n                            <td style=\"text-align:right;\">\r\n                                ");
#nullable restore
#line 216 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
                           Write(string.Format("{0:#,0}", @item.Sotienthu));

#line default
#line hidden
#nullable disable
                WriteLiteral("VND\r\n                            </td>\r\n                            <td>\r\n                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "51779c2de7ffee086fcde9cf2f8111c3c54713d052a05058a56a037c33eb1dbd28619", async() => {
                    WriteLiteral("<i class=\"far fa-edit\"></i>");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 219 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
                                                       WriteLiteral(item.Idndthu);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                <a");
                BeginWriteAttribute("href", " href=\"", 9019, "\"", 9107, 1);
#nullable restore
#line 220 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
WriteAttributeValue("", 9026, Url.Action("DeleteConfirmed", "Noidungthanhtoans", new { Idpttb = pttb.Idpttb }), 9026, 81, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" onclick=\"return ConfirmDelete(this);\" title=\"Xóa\"><i class=\"fas fa-trash\"></i></a>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 223 "D:\QuanLyCuaHangSach\QuanLyCuaHangSach\Views\Noidungthutiens\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<QuanLyCuaHangSach.Models.Noidungthutien>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
