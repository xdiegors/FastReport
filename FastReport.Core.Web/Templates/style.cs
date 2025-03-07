﻿using System.Drawing;

namespace FastReport.Web
{
    partial class WebReport
    {
        string template_style() => $@"
/**********
    MAIN
***********/
.{template_FR}-container {{
    {(Width.IsNullOrWhiteSpace() ? "" : $"width: {Width};")}
    {(Height.IsNullOrWhiteSpace() ? "" : $"height: {Height};")}
    background-color: white;
    display: {InlineStyle};
    flex-direction: {Toolbar.Vertical};
    position: relative;
    align-items: {Toolbar.Content};
}}

.{template_FR}-container * {{
    box-sizing: content-box;
    -moz-box-sizing: content-box;
}}

.{template_FR}-body {{
    display: flex;
    overflow: hidden;
    width: 100%;
    height: 100%;
}}

.{template_FR}-report {{
    overflow: auto;
    width: 100%;
    display: flex;
    flex-direction: {Toolbar.RowOrColumn};
    align-items: flex-start;
}}

/***********
    SPLIT
************/

.{template_FR}-gutter {{
    background-color: #f1f1f1;
    background-repeat: no-repeat;
    background-position: 50%;
}}

.{template_FR}-gutter.{template_FR}-gutter-horizontal {{
    background-image: url('data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAUAAAAeCAYAAADkftS9AAAAIklEQVQoU2M4c+bMfxAGAgYYmwGrIIiDjrELjpo5aiZeMwF+yNnOs5KSvgAAAABJRU5ErkJggg==');
    cursor: ew-resize;
}}

/*************
    TOOLBAR
**************/

.{template_FR}-toolbar {{
    flex-shrink: 1;
    font:{Toolbar.UserFontSettings};
    background-color: {ColorTranslator.ToHtml(Toolbar.Color)};
    /* {(Tabs.Count > 1 ? "" : "box-shadow: 0px 3px 4px -2px rgba(0, 0, 0, 0.2);")} */
    display: flex;
    flex-direction: {Toolbar.RowOrColumn};
    /* flex-wrap: wrap; */
    width: fit-content;
    height: {Toolbar.VerticalToolbarHeight};
    order:{Toolbar.TopOrBottom} ;
    position: relative;
    align-items: center;
    justify-content:{Toolbar.Content};
    z-index: 2;
    border-radius: {Toolbar.ToolbarRoundness}px;
    /*min-width: intrinsic;
    min-width: -moz-max-content;
    min-width: -webkit-max-content;
    min-width: max-content;*/
}}

.{template_FR}-toolbar-item {{
    height: {Toolbar.Height}px;
    border-radius:{Toolbar.ToolbarRoundness}px;
    background-color: #00000000;
    position: relative;
}}

.{template_FR}-toolbar-item:hover {{
    background-color: {ColorTranslator.ToHtml(Toolbar.Color)};
}}

.{template_FR}-toolbar-item > img {{
    height: calc({Toolbar.Height}px * 0.5);
    padding-top: calc({Toolbar.Height}px * 0.15);
    padding-bottom: calc({Toolbar.Height}px * 0.15);
    padding-left: calc({Toolbar.Height}px * 0.25);
    padding-right: calc({Toolbar.Height}px * 0.25);
    opacity: {Toolbar.TransparencyIcon};
    display: block;
    filter:invert({Toolbar.ColorIcon});
    margin-left: 10px;
    margin-right: 10px;
    margin-top: 5px;
}}

.{template_FR}-toolbar-item:hover > img {{
    opacity: 0.5;
}}

.{template_FR}-toolbar-notbutton:hover {{
    background-color: transparent;
}}

.{template_FR}-toolbar-notbutton:hover > img {{
    opacity: 1;
}}

/**********************
    TOOLBAR DROPDOWN
***********************/

.{template_FR}-toolbar-dropdown-content {{
    display: none;
    box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
    background-color: {ColorTranslator.ToHtml(Toolbar.DropDownMenuColor)};
    min-width: 50px;
    z-index: 2;
    position: absolute;
    {Toolbar.DropDownMenuPosition}
    white-space: nowrap;
    border-radius: {Toolbar.DropDownListBorder};
}}

.{template_FR}-toolbar-item:hover > .{template_FR}-toolbar-dropdown-content {{
    display: block;
}}

.{template_FR}-toolbar-dropdown-content > a {{
    float: none;
    color: {ColorTranslator.ToHtml(Toolbar.DropDownMenuTextColor)};
    padding: 6px 12px 6px 8px;
    text-decoration: none;
    display: block;
    text-align: left;
    height: auto;
    font-size: 14px;
    user-select: none;
}}

.{template_FR}-toolbar-dropdown-content > a:hover {{
    background-color: {ColorTranslator.ToHtml(Toolbar.DropDownMenuColor)};
    opacity: 0.5;
    cursor: pointer;
    border-radius: 0px 0px 10px 10px;
}}

.{template_FR}-zoom-selected {{
    font-weight: bold;
}}
.modalcontainer-overlay {{
    position: absolute;
    left: 0;
    top: 0;
    right: 0;
    bottom: 0;
    background-color: rgba(0, 0, 0, 0.7);
    display: flex;
    align-items: flex-start;
    justify-content: flex-start;
    opacity: 0;
    z-index: 2;
    visibility: hidden;
    transition: all 0.3s ease-in-out;
    align-content: flex-start;
}}

.modalcontainer {{
    background-color: #fff;
	width: 300px;
	height: 300px;
	display: flex;
	align-items: center;
	justify-content: center;
	display: none;
}}

.modalcontainer-overlay--visible {{
    opacity: 1;
	visibility: visible;
	transition: all 0.3s ease-in-out;
}}

.modalcontainer--visible {{
    display: flex;
    width: fit-content;
    height: fit-content;
    witdh: auto;
    min-width: 348px;
    height: auto;
    margin-top: 4rem;
    margin-left: 4rem;
    padding: 0px 9px 50px 9px;
    z-index: 4;
    border-radius: 30px 30px 12px 12px;
    background-color: #EFEFEF;
    flex-wrap: nowrap;
    align-content: center;
    justify-content: center;
    align-items: center;
    flex-direction: column;
    font-family: Arial,Verdana sans-serif;
}}
////////////////////
       POPUP
///////////////////
.fr-webreport-popup {{
    min-width: 100%;
    position: absolute;
    min-height: 100%;
    z-index: 3;
    padding-bottom: 1rem;
    background-color: #0000005c;
    display: flex;
    align-content: flex-start;
    flex-direction: row;
    flex-wrap: nowrap;
    justify-content: flex-start;
    align-items: flex-start;
}}

.fr-webreport-popup-content {{
    display: flex;
    width: fit-content;
    height: fit-content;
    margin-top: 2.5rem;
    margin-left: 2.6rem;
    padding: 0px 10px 50px 10px;
    z-index: 4;
    border-radius: 10px;
    background-color: white;
    flex-wrap: nowrap;
    align-content: center;
    justify-content: center;
    align-items: center;
    flex-direction: column;
    font-family: Arial,Verdana sans-serif;
}}

.fr-webreport-popup-content-title {{
    display: flex;
    width: 100%;
    background-color: #35363A;
    color: white;
    font-weight: bold;
    box-shadow: 0rem -0.1rem 0rem 0.6rem #35363A;
    margin-top: 10px; 
    margin-bottom: 10px;
    align-items: center;
    flex-direction: column;
    flex-wrap: nowrap;
    justify-content: flex-start;
    align-content: center;
    font: {Toolbar.Exports.UserFontSettingsStyle} 16px {Toolbar.Exports.UserFontSettingsFamily};
    border-radius: 12px 12px 0px 0px;
}}

.fr-webreport-popup-content-export-parameters-page-range-title{{
    margin-top: 25px;
}}

.fr-webreport-popup-content-title input {{
    background-color: white;
    border: 3px solid  {ColorTranslator.ToHtml(Toolbar.Exports.Color)};
    color: black;
    max-height: 9.8px;
    border-radius: 3px;
}}

button{{
    text-align: left;
}}

.fr-webreport-popup-content-export-parameters {{
    display: flex;
    width: 100%;
    -ms-flex-wrap: wrap;
    flex-direction: column;
    border-radius: 3px;
    padding-bottom: 1rem;
    align-content: flex-start;
    flex-wrap: wrap;
    align-items: flex-start;
    justify-content: flex-start;
    font: {Toolbar.Exports.UserFontSettingsStyle} 14px {Toolbar.Exports.UserFontSettingsFamily};
    font-weight: bold;
}}

.fr-webreport-popup-content-export-parameters-col {{
    display: flex;
    align-content: center;
    flex-wrap: nowrap;
    flex-direction: column;
    font: {Toolbar.Exports.UserFontSettingsStyle} 11px {Toolbar.Exports.UserFontSettingsFamily};
}}
.custom-select{{
    width:auto;
    outline: none;
    max-width: 170px;
    min-width: 20px;
    border: none;
    margin: 5px 5px 5px 5px;
    border-radius: 3px;
    height: 25px;
    font: {Toolbar.Exports.UserFontSettingsStyle} 12px {Toolbar.Exports.UserFontSettingsFamily};
    font-size: 11px;
    overflow: hidden;
    background: #ffffff url(/_fr/resources.getResource?resourceName=select-arrow.svg&contentType=image%2Fsvg%2Bxml) no-repeat;
    background-position: calc(100% - 10px) center;
    -moz-appearance:none; /* Firefox */
    -webkit-appearance:none; /* Safari and Chrome */
    appearance:none;
    padding:0 30px 0 10px !important;
    -webkit-padding-end: 30px !important;
    -webkit-padding-start: 10px !important;
}}
.fr-webreport-popup-content-export-parameters-input {{
    margin-left: 0.3rem;
    margin-bottom: 0.3rem;
    padding: 6px;
    max-width: 70px;
    height: 8px;
    outline: none;
    border: none;
    margin-left: 5px;
    margin-right: 5px;
    min-width: inherit;
    border-radius: 4px;
    font: {Toolbar.Exports.UserFontSettingsStyle} 10px {Toolbar.Exports.UserFontSettingsFamily};
}}
.fr-webreport-popup-content-export-parameters-row {{
    display: flex;
    padding-top: 5px;
    flex-direction: row;
    align-items: flex-start;
    justify-content: flex-start;
}}
.fr-webreport-popup-content-export-parameters-slider {{
    display: flex;
    margin: 0rem 0rem 0rem 0.35rem;
    background-color: transparent;
    border-radius: 10px;
    justify-content: flex-start;
    align-items: center;
    align-content: center;
    flex-direction: row;
}}

.fr-webreport-popup-content-export-parameters-slider span {{
    color: black;
    min-width: 128px;
    font: {Toolbar.Exports.UserFontSettingsStyle} 11px {Toolbar.Exports.UserFontSettingsFamily};
    font-weight: normal;
    white-space: nowrap;
}}
input[type=range] {{
    height: 1.7rem;
    overflow: hidden;
    -webkit-appearance: none;
    margin-left: 0;
    outline: none;
    background-color: #424242;
}}

input[type=range]::-webkit-slider-runnable-track {{
    width: 100%;
    height: 100%;
    cursor: pointer;
    animate: 0.2s;
    background: #424242;
    border-radius: 0px;
}}
input[type=range]::-webkit-slider-thumb {{
    height: 100%;
    width: 5%;
    border-radius: 0px;
    background: linear-gradient(gray,5%, {ColorTranslator.ToHtml(Toolbar.Exports.Color)});
    cursor: pointer;
    -webkit-appearance: none;
    box-shadow: -100vw 0vw 0vw 100vw {ColorTranslator.ToHtml(Toolbar.Exports.Color)};
    margin-top: 0px;
}}

label{{
     margin: 5px 0px;
}}
.fr-webreport-popup-content-export-parameters-col input[type=text] {{
    background-color: white;
    color: #000000;
    border: 2px solid  {ColorTranslator.ToHtml(Toolbar.Exports.Color)};
    max-height: 11px;
}}
.fr-webreport-popup-content-export-parameters-button {{
    padding: 5px;
    outline: none; 
    border: none;
    margin-left: 5px;
    margin-right: 5px;
    min-width: inherit; 
    font: {Toolbar.Exports.UserFontSettingsStyle} 11px {Toolbar.Exports.UserFontSettingsFamily};
    color: black;
    background: url(/_fr/resources.getResource?resourceName=button.svg&contentType=image%2Fsvg%2Bxml) no-repeat;
    background-position: 0px center;
    padding-left: 20px;
    vertical-align: middle;
    cursor: pointer;
}}

.fr-webreport-popup-content-buttons {{
    display: flex;
    margin-bottom: -2.3rem;
    width: 100%;
    flex-wrap: nowrap;
    align-content: center;
    justify-content: space-between;
    align-items: center;
    flex-direction: row;
}}

.fr-webreport-popup-content-btn-submit {{
    outline: none;
    border: none;
    background-color: #DD4433;
    border-radius: 3px;
    padding: 3px;
    font: {Toolbar.Exports.UserFontSettingsStyle} 14px {Toolbar.Exports.UserFontSettingsFamily};
    color: {ColorTranslator.ToHtml(Toolbar.Exports.FontColor)};
    min-width: 70px;
    width: fit-content;
    height: 30px;
    cursor: pointer;
    text-align: center;
}}

.fr-webreport-popup-content-btn-cancel{{
    padding: 3px;
    background-color: #D9D9D9;
    font: {Toolbar.Exports.UserFontSettingsStyle} 14px {Toolbar.Exports.UserFontSettingsFamily};
    min-width: 70px;
    width: fit-content;
    height: 30px;
    border-radius: 3px;
    border: none;
    outline: none;
    color: black;
    text-align: center;
}}

.fr-webreport-popup-content-btn-submit:hover {{
    transform: scale(1.015);
}}

.{template_FR}-container .activeButton {{
    background: url(/_fr/resources.getResource?resourceName=button-active.svg&contentType=image%2Fsvg%2Bxml) no-repeat;
    background-position: 0px center;
    vertical-align: middle;
}}


.fr-webreport-settings-btn {{
    background-color: transparent;
    color: transparent;
    padding-left: 1rem;
    margin-left: 230px;
    display: flex;
    float: right;
    margin-top: -1.6rem;
    outline: none;
    padding-right: 1rem;
    border: none;
    position: relative;
    z-index: 4;
    flex-direction: row;
    align-content: space-around;
    justify-content: space-between;
    filter:alpha(opacity=50);
    opacity: 1;
}}
.fr-webreport-settings-btn:hover{{
    background-color: transparent;
    color: transparent;
    padding-left: 1rem;
    margin-left: 230px;
    display: flex;
    float: right;
    margin-top: -1.6rem;
    outline: none;
    padding-right: 1rem;
    border: none;
    position: relative;
    z-index: 4;
    flex-direction: row;
    align-content: space-around;
    justify-content: space-between;
    transform: scale(1.1);
    filter:alpha(opacity=0);
    opacity: 0.5;
    cursor: pointer;
}}
.fr-webreport-settings-btn::-moz-focus-inner {{
    background-color: transparent;
    color: transparent;
    padding-left: 1rem;
    margin-left: 230px;
    display: flex;
    float: right;
    margin-top: -1.6rem;
    outline: none;
    padding-right: 1rem;
    border: none;
    position: relative;
    z-index: 4;
    flex-direction: row;
    align-content: space-around;
    justify-content: space-between;
}}

/************************
    TOOLBAR NAVIGATION
*************************/

.{template_FR}-toolbar-narrow > img {{
    transform: rotate({Toolbar.ToolbarNarrow}deg);
    padding-left: 0px;
    padding-right: 0px;
    height: calc({Toolbar.Height}px * 0.35);
    padding-top: 9px;
    margin: 5px 10px 0px;
}}

.{template_FR}-toolbar-slash{{
 }}

.{template_FR}-toolbar-slash > img {{
    margin-left: 0px;
    margin-right: 0px;
    height: calc({Toolbar.Height}px * 0.35);
    padding-top: 9px;
    margin: 5px 0px 0px;
    padding-right: 5px;
    padding-left: 5px;
}}

.{template_FR}-toolbar-item > input {{
    font: {Toolbar.Exports.UserFontSettingsStyle} 12px {Toolbar.Exports.UserFontSettingsFamily};
    font-size: calc({Toolbar.Height}px * 0.35);
    text-align: center;
    border: 0;
    background: #fbfbfb;
    border-radius:{Toolbar.ToolbarRoundness}px;
    height: calc({Toolbar.Height}px * 0.68);
    width: 3.5em;
    margin-top: calc({Toolbar.Height}px * 0.17);
    margin-bottom: calc({Toolbar.Height}px * 0.15);
    margin-left: calc({Toolbar.Height}px * 0.1);
    margin-right: calc({Toolbar.Height}px * 0.1);
    padding: 0;
    display: block;
    border-radius: 5px;
}}

.{template_FR}-toolbar-item > input:hover:not([readonly]) {{
    background: #fff;
}}

.{template_FR}-toolbar-item > input[readonly] {{
    cursor: default;
}}

/**************
    SPINNER
**************/

.{template_FR}-spinner {{
    height: 100%;
    width: 100%;
    position: absolute;
    background-color: rgba(255, 255, 255, 0.7);
    z-index: 10;
}}

.{template_FR}-spinner img {{
    width: 90px;
    height: 90px; 
    left: calc(50%-50px);
    top: calc(50%-50px);
    position: absolute;
    animation: {template_FR}-spin 1s infinite steps(8);
    opacity: 0.5;
}}

@keyframes {template_FR}-spin {{
	from {{ -webkit-transform: rotate(0deg); }}
	to {{ -webkit-transform: rotate(360deg); }}
}}

/************
    ERROR
************/

.{template_FR}-error-container {{
    width: 100%;
    height: 100%;
    display: flex;
    flex-direction: column;
    overflow: auto;
}}

.{template_FR}-error-text {{
    color: red;
    font-family: Consolas,monospace;
    font-size: 16px;
    margin: 20px;
    text-align: center;
}}

.{template_FR}-error-response {{
    height: 100%;
    position: relative;
}}

/***********
    TABS
***********/

.{template_FR}-tabs {{
    flex-shrink: 0;
    font-family: Verdana,Arial,sans-serif;
    background-color: #f1f1f1;
    display: table;
    width: {Toolbar.TabsPositionSettings};
    max-width: {ReportMaxWidth}px;
    box-shadow: 0px 3px 4px -2px rgba(0, 0, 0, 0.2);
    position: relative;
    border-radius: 9px;
    z-index: 1;
    {Toolbar.TabsPositionSettings}
}}


.{template_FR}-tabs .{template_FR}-tab {{
    float: left;
    display: block;
    color: #3b3b3b;
    text-align: center;
    text-decoration: none;
    font-size: 12px;
    background-color: #f1f1f1;
    margin-top: 2px;
    margin-right: 2px;
    height: 24px;
    border-radius: 9px;
}}

.{template_FR}-tabs .{template_FR}-tab-title {{
    display: block;
    float: left;
    padding: 4.5px 10px;
}}

.{template_FR}-tabs .{template_FR}-tab-close {{
    width: 13px;
    height: 13px;
    display: block;
    float: left;
    margin-top: 6px;
    margin-right: 6px;
}}

.{template_FR}-tabs .{template_FR}-tab-close img{{
    border-radius: 10px;
}}

.{template_FR}-tabs .{template_FR}-tab:hover {{
    background-color: lightgray;
    color: black;
    cursor: pointer;
}}

.{template_FR}-tabs .{template_FR}-tab.active {{
    background-color: lightgray;
    color: black;
    cursor: default;
}}

.{template_FR}-tabs .{template_FR}-tab a img {{
    height: 13px;
    opacity: 0;
}}

.{template_FR}-tabs .{template_FR}-tab.active a img {{
    opacity: 0.5;
}}

.{template_FR}-tabs .{template_FR}-tab:hover a img {{
    opacity: 0.5;
}}

.{template_FR}-tabs .{template_FR}-tab a img:hover {{
    opacity: 1;
    background-color: #f1f1f1;
    cursor: pointer;
}}

/***********
    MISC
***********/

.{template_FR}-pointer:hover {{
    cursor: pointer;
}}

.{template_FR}-disabled {{
    opacity: 0.5;
}}
.datetimepicker > input[type=""date""]{{
    background: url(""{template_resource_url("date-picker.svg", "image/svg+xml")}"") no-repeat;
    background-size: 10px;
    background-position: right 5px center;
    background-origin: content-box, content-box;
}}
.datetimepicker > input[type=""date""]:disabled {{
    background: url("""") no-repeat;
}}
input[type=date]::-webkit-calendar-picker-indicator {{
    opacity: 0;
}}
/**************
    OUTLINE
**************/

.{template_FR}-outline {{
    overflow: auto;
    height: auto;
    font-family: Verdana,Arial,sans-serif;
    font-size: 11px;
}}

.{template_FR}-outline img {{
    opacity: 0.5;
}}

.{template_FR}-outline-inner {{
    padding: 5px;
}}

.{template_FR}-outline-node {{
    display: flex;
    flex-wrap: wrap;
}}

.{template_FR}-outline-caret {{
    height: 14px;
    width: 14px;
    margin-top: 1.5px;
    margin-right: 4px;
}}

.{template_FR}-outline-caret:hover {{
    cursor: pointer;
}}

.{template_FR}-outline-caret-blank {{
    width: 18px;
}}

.{template_FR}-outline-file {{
    height: 14px;
    margin-top: 1.5px;
}}

.{template_FR}-outline-text {{
    white-space: nowrap;
    display: flex;
    align-items: center;
}}

.{template_FR}-outline-text > a {{
    margin: 2px;
    padding: 2px;
}}

.{template_FR}-outline-text > a:hover {{
    text-decoration: underline;
    cursor: pointer;
}}

.{template_FR}-outline-children {{
    padding-left: 20px;
}}
";
    }
}