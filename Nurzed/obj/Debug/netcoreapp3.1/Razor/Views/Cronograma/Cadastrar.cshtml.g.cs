#pragma checksum "F:\Senai\3DSB\Sprint3\TCC-Nurzed\Nurzed\Views\Cronograma\Cadastrar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8f3cb0947c82ff85e8f40047f041a27da453c696"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cronograma_Cadastrar), @"mvc.1.0.view", @"/Views/Cronograma/Cadastrar.cshtml")]
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
#line 1 "F:\Senai\3DSB\Sprint3\TCC-Nurzed\Nurzed\Views\_ViewImports.cshtml"
using Nurzed;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Senai\3DSB\Sprint3\TCC-Nurzed\Nurzed\Views\_ViewImports.cshtml"
using Nurzed.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "F:\Senai\3DSB\Sprint3\TCC-Nurzed\Nurzed\Views\Cronograma\Cadastrar.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Senai\3DSB\Sprint3\TCC-Nurzed\Nurzed\Views\Cronograma\Cadastrar.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f3cb0947c82ff85e8f40047f041a27da453c696", @"/Views/Cronograma/Cadastrar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"76629ceb5dd71cc905ea11c0a7fa98e956125bd0", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Cronograma_Cadastrar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/cronograma.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/periodo.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/voltar.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img_btn_voltar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Voltar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Usuarios", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("selecao_area_opicoes"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("myForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Cadastrar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/funcao.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/cronograma.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "F:\Senai\3DSB\Sprint3\TCC-Nurzed\Nurzed\Views\Cronograma\Cadastrar.cshtml"
  
    IEnumerable<Usuarios> listaEnfermeiros = ViewData["listaEnfermeiros"] as IEnumerable<Usuarios>;
    IEnumerable<Usuarios> listaTecnicos = ViewData["listaTecnicos"] as IEnumerable<Usuarios>;
    IEnumerable<Usuarios> listaAux = ViewData["listaAux"] as IEnumerable<Usuarios>;
    IEnumerable<string> listaDias = ViewData["listaDias"] as IEnumerable<string>;
  

    Usuarios u = JsonConvert.DeserializeObject<Usuarios>(Context.Session.GetString("usuarios"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "8f3cb0947c82ff85e8f40047f041a27da453c6969537", async() => {
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "8f3cb0947c82ff85e8f40047f041a27da453c69610652", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8f3cb0947c82ff85e8f40047f041a27da453c69611780", async() => {
                WriteLiteral("\r\n    <div class=\"contaner_titulo_index\">\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8f3cb0947c82ff85e8f40047f041a27da453c69612092", async() => {
                    WriteLiteral("\r\n            <button class=\"btn_voltar_adm\">\r\n                ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "8f3cb0947c82ff85e8f40047f041a27da453c69612421", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n            </button>\r\n        ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    </div>\r\n    <h1 class=\"titulo_pagina_adm\">Adicionar Cronograma</h1>\r\n");
#nullable restore
#line 27 "F:\Senai\3DSB\Sprint3\TCC-Nurzed\Nurzed\Views\Cronograma\Cadastrar.cshtml"
      
        string[,] meses1 = new string[6, 2] { { "Janeiro", "01" }, { "Fevereiro", "02" }, { "Março", "03" }, { "Abril", "04" }, { "Maio", "05" }, { "Junho", "06" } };
        string[,] meses2 = new string[6,2] {{"Julho","07"},{"Agosto","08"},{"Setembro","09"},{"Outubro","10"},{"Novembro","11"},{ "Dezembro", "12" } };
        var data = DateTime.Now;
        var mes = data.Month;
     
    

#line default
#line hidden
#nullable disable
                WriteLiteral("   \r\n    <div id=\"container_btns_adm\">\r\n        <div class=\"container\">      \r\n");
#nullable restore
#line 37 "F:\Senai\3DSB\Sprint3\TCC-Nurzed\Nurzed\Views\Cronograma\Cadastrar.cshtml"
             for(int i = 0;i < 6;i++)
            {
                var marker = i + 1;

                if(marker < mes)
                {
                   

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <button class=\"btn_mes_crono_adm\" style=\"opacity:0.5\"");
                BeginWriteAttribute("value", " value=\"", 1710, "\"", 1730, 1);
#nullable restore
#line 44 "F:\Senai\3DSB\Sprint3\TCC-Nurzed\Nurzed\Views\Cronograma\Cadastrar.cshtml"
WriteAttributeValue("", 1718, meses1[i,1], 1718, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" disabled onclick=\"EscolherMes(this)\">");
#nullable restore
#line 44 "F:\Senai\3DSB\Sprint3\TCC-Nurzed\Nurzed\Views\Cronograma\Cadastrar.cshtml"
                                                                                                                               Write(meses1[i,0]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</button>\r\n");
#nullable restore
#line 45 "F:\Senai\3DSB\Sprint3\TCC-Nurzed\Nurzed\Views\Cronograma\Cadastrar.cshtml"
                }else{

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <button class=\"btn_mes_crono_adm\"");
                BeginWriteAttribute("value", " value=\"", 1869, "\"", 1889, 1);
#nullable restore
#line 46 "F:\Senai\3DSB\Sprint3\TCC-Nurzed\Nurzed\Views\Cronograma\Cadastrar.cshtml"
WriteAttributeValue("", 1877, meses1[i,1], 1877, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" onclick=\"EscolherMes(this)\">");
#nullable restore
#line 46 "F:\Senai\3DSB\Sprint3\TCC-Nurzed\Nurzed\Views\Cronograma\Cadastrar.cshtml"
                                                                                                  Write(meses1[i,0]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</button>\r\n");
#nullable restore
#line 47 "F:\Senai\3DSB\Sprint3\TCC-Nurzed\Nurzed\Views\Cronograma\Cadastrar.cshtml"
                }
                
            
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\r\n        \r\n        <div class=\"container\">\r\n");
#nullable restore
#line 54 "F:\Senai\3DSB\Sprint3\TCC-Nurzed\Nurzed\Views\Cronograma\Cadastrar.cshtml"
             for(int i = 0;i < 6;i++)
            {
                var marker = i + 7;
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "F:\Senai\3DSB\Sprint3\TCC-Nurzed\Nurzed\Views\Cronograma\Cadastrar.cshtml"
                 if(marker < mes)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <button class=\"btn_mes_crono_adm\" style=\"opacity:0.5\" disabled");
                BeginWriteAttribute("value", " value=\"", 2290, "\"", 2310, 1);
#nullable restore
#line 59 "F:\Senai\3DSB\Sprint3\TCC-Nurzed\Nurzed\Views\Cronograma\Cadastrar.cshtml"
WriteAttributeValue("", 2298, meses2[i,1], 2298, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" onclick=\"EscolherMes(this)\">");
#nullable restore
#line 59 "F:\Senai\3DSB\Sprint3\TCC-Nurzed\Nurzed\Views\Cronograma\Cadastrar.cshtml"
                                                                                                                               Write(meses2[i,0]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</button>\r\n");
#nullable restore
#line 60 "F:\Senai\3DSB\Sprint3\TCC-Nurzed\Nurzed\Views\Cronograma\Cadastrar.cshtml"
                }else{

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <button class=\"btn_mes_crono_adm\"");
                BeginWriteAttribute("value", " value=\"", 2440, "\"", 2460, 1);
#nullable restore
#line 61 "F:\Senai\3DSB\Sprint3\TCC-Nurzed\Nurzed\Views\Cronograma\Cadastrar.cshtml"
WriteAttributeValue("", 2448, meses2[i,1], 2448, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" onclick=\"EscolherMes(this)\">");
#nullable restore
#line 61 "F:\Senai\3DSB\Sprint3\TCC-Nurzed\Nurzed\Views\Cronograma\Cadastrar.cshtml"
                                                                                                  Write(meses2[i,0]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</button>\r\n");
#nullable restore
#line 62 "F:\Senai\3DSB\Sprint3\TCC-Nurzed\Nurzed\Views\Cronograma\Cadastrar.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 62 "F:\Senai\3DSB\Sprint3\TCC-Nurzed\Nurzed\Views\Cronograma\Cadastrar.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                 \r\n       \r\n        </div>\r\n    </div>\r\n");
                WriteLiteral("        <input type=\"hidden\" id=\"mesRes\" name=\"mes\" value=\"teste\">\r\n\r\n        <div id=\"aux9\">\r\n          <select name=\"cars\"");
                BeginWriteAttribute("id", " id=\"", 2771, "\"", 2776, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"selecao_area\">\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8f3cb0947c82ff85e8f40047f041a27da453c69621388", async() => {
                    WriteLiteral("Selecione a Área");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("disabled", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_8.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8f3cb0947c82ff85e8f40047f041a27da453c69623280", async() => {
                    WriteLiteral("################# ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n          </select>\r\n        </div>\r\n\r\n        <p>");
#nullable restore
#line 78 "F:\Senai\3DSB\Sprint3\TCC-Nurzed\Nurzed\Views\Cronograma\Cadastrar.cshtml"
      Write(u.Id_Area);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p>


    <h1 class=""mes_selcionado_adm"" id=""h1_mes"">AGOSTO</h1>
    <input type=""hidden"" id=""ano"" name=""ano"">
    <div class=""conteiner_hario"">
        <div class=""vazio""></div>
    


      
        <div class=""conteiner_hora"">

            <input type=""radio"" name=""periodo"" id=""manha"" checked class=""radio_hora"" onclick=""EscolherPeriodo(this)"" value=""manha"">
            <p class=""radio_hora_text"">07:00 às 13:00</p>
        </div>

        <div class=""conteiner_hora"">
            <input type=""radio"" name=""periodo"" id=""tarde"" class=""radio_hora"" onclick=""EscolherPeriodo(this)"" value=""tarde"">
            <p class=""radio_hora_text"">13:00 às 19:00</p>
        </div>

        <div class=""conteiner_hora"">
            <input type=""radio"" name=""periodo"" id=""noite"" class=""radio_hora"" onclick=""EscolherPeriodo(this)"" value=""noite"">
            <p class=""radio_hora_text"">21:00 às 07:00</p>
        </div>

        <div class=""vazio""></div>
    </div>
    <input type=""hidden"" id=""periodoRes"" n");
                WriteLiteral(@"ame=""periodo"">
    <hr id=""linha_horario_adm"">
    </div>
   
    <div id=""aux10"">
        <a><button class=""btn_avancar_conograma_adm""  onclick=""clicar()"" id=""btn_Avancar"">Avançar</button></a>
    </div>


    <div id=""aux31"">
        <button class=""btn_avancar_conograma_adm"" onclick=""f5()"">Trocar Horário</button>
    </div>

    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8f3cb0947c82ff85e8f40047f041a27da453c69626158", async() => {
                    WriteLiteral(@"
    <section id=""aux30"">

        <div class=""aux11"">
            <p class=""leitos_titulo"">Leitos ativos:</p>
            <input type=""number"" class=""leitos_input"" min=""0"" minlength=""2"" maxlength=""250"" required/>
        </div>

        <div class=""aux11"">
            <p class=""leitos_titulo"">Leitos desativados:</p>
            <input type=""number"" class=""leitos_input"" min=""0"" minlength=""2"" maxlength=""250"" />
        </div>

        
        <div class=""aux13"" id=""div_Enfermeiros"">
                <table class=""tabela_crono_adm"" id=""tabela"">
                    <tbody id=""tbody_Enfermeiros"">
                        <tr id=""tr_Enfermeiros"" class=""linha_1_cronograma_enf"">
            
            
                       </tr>

                    </tbody>         

                </table>
        </div>



        <!-------------------------------------------------------------------->

        <div class=""aux13"" id=""div_Tecnicos"">
            <table class=""tabela_crono_adm"" >
");
                    WriteLiteral(@"                <tbody id=""tbody_Tecnicos"">
                    <tr id=""tr_Tecnicos"" class=""linha_1_cronograma_enf"" >
                    

                    </tr>
              </tbody>
            </table>
        </div>

        <!----------------------------------------------------------------------->


        <div class=""aux13"" id=""div_AuxEnf"">
            <table class=""tabela_crono_adm"">
                <tbody id=""tbody_AuxEnf"">
                    <tr id=""tr_AuxEnf""class=""linha_1_cronograma_enf"">
                   

                    </tr>
                </tbody>
            </table>
        </div>
       

        <input type=""hidden"" id=""legendas"" name=""legenda"">


        <div class=""aux12"">
            <button type=""submit"" id=""btn_finalizar_cronograma"">Finalizar</button>
        </div>
         ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_11.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
        <br><br>
        <section id=""sec_legenda"">

            <div class=""container_legenda"">
                <h3 id=""title_legenda"">Legenda</h3>
                <hr class=""linha_legenda"">
                <div class=""info_legenda_container"">
                    <p class=""info_legenda"">
                        PR:Presente <br>
                        X: Folga <br>
                        ABA: Folga Abonada <br>
                        LTS: Licença tratamento de saúde <br>
                        LP: Licença Prêmio  <br>
                        LG: Licença gala <br>
                        FE: Férias <br>
                    </p>

                    <p class=""info_legenda"">
                        FI: Falta injustificada <br>
                        PF: Ponto Facultativo <br>
                        CH: Compensação de hora <br>
                        TL: Projeto Trocando de Lugar <br>
                        AF: Afastado <br>
                        TC: Término de contrato <br>
  ");
                WriteLiteral("                      FT:Folga trabalhada<br>\r\n                    </p>\r\n\r\n                </div>\r\n\r\n            </div>\r\n\r\n        </section>\r\n          <br><br>\r\n\r\n    </section>\r\n");
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
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8f3cb0947c82ff85e8f40047f041a27da453c69631733", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8f3cb0947c82ff85e8f40047f041a27da453c69632774", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_13);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
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
