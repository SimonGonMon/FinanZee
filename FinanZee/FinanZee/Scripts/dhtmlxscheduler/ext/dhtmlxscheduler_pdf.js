/*

@license
dhtmlxScheduler v.5.3.6 Standard

To use dhtmlxScheduler in non-GPL projects (and get Pro version of the product), please obtain Commercial/Enterprise or Ultimate license on our site https://dhtmlx.com/docs/products/dhtmlxScheduler/#licensing or contact us at sales@dhtmlx.com

(c) XB Software Ltd.

*/
Scheduler.plugin(function(e){!function(){function t(e){return e.replace(k,"\n").replace(w,"")}function a(e,t){e=parseFloat(e),t=parseFloat(t),isNaN(t)||(e-=t);var a=i(e);return e=e-a.width+a.cols*b,isNaN(e)?"auto":100*e/b}function n(e,t,a){e=parseFloat(e),t=parseFloat(t),!isNaN(t)&&a&&(e-=t);var n=i(e);return e=e-n.width+n.cols*b,isNaN(e)?"auto":100*e/(b-(isNaN(t)?0:t))}function i(t){for(var a=0,n=e._els.dhx_cal_header[0].childNodes,i=n[1]?n[1].childNodes:n[0].childNodes,r=0;r<i.length;r++){
var o=i[r].style?i[r]:i[r].parentNode,d=parseFloat(o.style.width);if(!(t>d))break;t-=d+1,a+=d+1}return{width:a,cols:r}}function r(e){return e=parseFloat(e),isNaN(e)?"auto":100*e/x}function o(e,t){return(window.getComputedStyle?window.getComputedStyle(e,null)[t]:e.currentStyle?e.currentStyle[t]:null)||""}function d(t,a){for(var n=parseInt(t.style.left,10),i=0;i<e._cols.length;i++)if((n-=e._cols[i])<0)return i;return a}function s(t,a){
for(var n=parseInt(t.style.top,10),i=0;i<e._colsS.heights.length;i++)if(e._colsS.heights[i]>n)return i;return a}function _(e){return e?"<"+e+">":""}function l(e){return e?"</"+e+">":""}function c(e,t,a,n){var i="<"+e+" profile='"+t+"'";return a&&(i+=" header='"+a+"'"),n&&(i+=" footer='"+n+"'"),i+=">"}function h(){var a="",n=e._mode;if(e.matrix&&e.matrix[e._mode]&&(n="cell"==e.matrix[e._mode].render?"matrix":"timeline"),a+="<scale mode='"+n+"' today='"+e._els.dhx_cal_date[0].innerHTML+"'>",
"week_agenda"==e._mode)for(var i=e._els.dhx_cal_data[0].getElementsByTagName("DIV"),r=0;r<i.length;r++)"dhx_wa_scale_bar"==i[r].className&&(a+="<column>"+t(i[r].innerHTML)+"</column>");else if("agenda"==e._mode||"map"==e._mode){var i=e._els.dhx_cal_header[0].childNodes[0].childNodes;a+="<column>"+t(i[0].innerHTML)+"</column><column>"+t(i[1].innerHTML)+"</column>"
}else if("year"==e._mode)for(var i=e._els.dhx_cal_data[0].childNodes,r=0;r<i.length;r++)a+="<month label='"+t(i[r].querySelector(".dhx_year_month").innerHTML)+"'>",a+=g(i[r].querySelector(".dhx_year_week").childNodes),a+=u(i[r].querySelector(".dhx_year_body")),a+="</month>";else{a+="<x>";var i=e._els.dhx_cal_header[0].childNodes;a+=g(i),a+="</x>";var o=e._els.dhx_cal_data[0];if(e.matrix&&e.matrix[e._mode]){a+="<y>";for(var r=0;r<o.firstChild.rows.length;r++){var d=o.firstChild.rows[r]
;a+="<row><![CDATA["+t(d.cells[0].innerHTML)+"]]></row>"}a+="</y>",x=o.firstChild.rows[0].cells[0].offsetHeight}else if("TABLE"==o.firstChild.tagName)a+=u(o);else{for(o=o.childNodes[o.childNodes.length-1];-1==o.className.indexOf("dhx_scale_holder");)o=o.previousSibling;o=o.childNodes,a+="<y>";for(var r=0;r<o.length;r++)a+="\n<row><![CDATA["+t(o[r].innerHTML)+"]]></row>";a+="</y>",x=o[0].offsetHeight}}return a+="</scale>"}function u(e){for(var a="",n=e.querySelectorAll("tr"),i=0;i<n.length;i++){
for(var r=[],o=n[i].querySelectorAll("td"),d=0;d<o.length;d++)r.push(o[d].querySelector(".dhx_month_head").innerHTML);a+="\n<row height='"+o[0].offsetHeight+"'><![CDATA["+t(r.join("|"))+"]]></row>",x=o[0].offsetHeight}return a}function g(a){var n,i="";e.matrix&&e.matrix[e._mode]&&(e.matrix[e._mode].second_scale&&(n=a[1].childNodes),a=a[0].childNodes);for(var r=0;r<a.length;r++)i+="\n<column><![CDATA["+t(a[r].innerHTML)+"]]></column>";if(b=a[0].offsetWidth,
n)for(var o=0,d=a[0].offsetWidth,s=1,r=0;r<n.length;r++)i+="\n<column second_scale='"+s+"'><![CDATA["+t(n[r].innerHTML)+"]]></column>",o+=n[r].offsetWidth,o>=d&&(d+=a[s]?a[s].offsetWidth:0,s++),b=n[0].offsetWidth;return i}function f(i){var _="",l=e._rendered,c=e.matrix&&e.matrix[e._mode]
;if("agenda"==e._mode||"map"==e._mode)for(var h=0;h<l.length;h++)_+="<event><head><![CDATA["+t(l[h].childNodes[0].innerHTML)+"]]></head><body><![CDATA["+t(l[h].childNodes[2].innerHTML)+"]]></body></event>";else if("week_agenda"==e._mode)for(var h=0;h<l.length;h++)_+="<event day='"+l[h].parentNode.getAttribute("day")+"'><body>"+t(l[h].innerHTML)+"</body></event>";else if("year"==e._mode)for(var l=e.get_visible_events(),h=0;h<l.length;h++){var u=l[h].start_date
;for(u.valueOf()<e._min_date.valueOf()&&(u=e._min_date);u<l[h].end_date;){var g=u.getMonth()+12*(u.getFullYear()-e._min_date.getFullYear())-e.week_starts._month,f=e.week_starts[g]+u.getDate()-1,v=i?o(e._get_year_cell(u),"color"):"",m=i?o(e._get_year_cell(u),"backgroundColor"):"";if(_+="<event day='"+f%7+"' week='"+Math.floor(f/7)+"' month='"+g+"' backgroundColor='"+m+"' color='"+v+"'></event>",u=e.date.add(u,1,"day"),u.valueOf()>=e._max_date.valueOf())break}
}else if(c&&"cell"==c.render)for(var l=e._els.dhx_cal_data[0].getElementsByTagName("TD"),h=0;h<l.length;h++){var v=i?o(l[h],"color"):"",m=i?o(l[h],"backgroundColor"):"";_+="\n<event><body backgroundColor='"+m+"' color='"+v+"'><![CDATA["+t(l[h].innerHTML)+"]]></body></event>"}else for(var h=0;h<l.length;h++){var p,y;if(e.matrix&&e.matrix[e._mode])p=a(l[h].style.left),y=a(l[h].offsetWidth)-1;else{var b=e.config.use_select_menu_space?0:26;p=n(l[h].style.left,b,!0),y=n(l[h].style.width,b)-1}
if(!isNaN(1*y)){var w=r(l[h].style.top),k=r(l[h].style.height),D=l[h].className.split(" ")[0].replace("dhx_cal_","");if("dhx_tooltip_line"!==D){var E=e.getEvent(l[h].getAttribute("event_id"));if(E){var f=E._sday,N=E._sweek,S=E._length||0;if("month"==e._mode)k=parseInt(l[h].offsetHeight,10),w=parseInt(l[h].style.top,10)-e.xy.month_head_height,f=d(l[h],f),N=s(l[h],N);else if(e.matrix&&e.matrix[e._mode]){f=0;var M=l[h].parentNode.parentNode.parentNode;N=M.rowIndex;var A=x
;x=l[h].parentNode.offsetHeight,w=r(l[h].style.top),w-=.2*w,x=A}else{if(l[h].parentNode==e._els.dhx_cal_data[0])continue;var C=e._els.dhx_cal_data[0].childNodes[0],O=parseFloat(-1!=C.className.indexOf("dhx_scale_holder")?C.style.left:0);p+=a(l[h].parentNode.style.left,O)}if(_+="\n<event week='"+N+"' day='"+f+"' type='"+D+"' x='"+p+"' y='"+w+"' width='"+y+"' height='"+k+"' len='"+S+"'>","event"==D){_+="<header><![CDATA["+t(l[h].childNodes[1].innerHTML)+"]]></header>"
;var v=i?o(l[h].childNodes[2],"color"):"",m=i?o(l[h].childNodes[2],"backgroundColor"):"";_+="<body backgroundColor='"+m+"' color='"+v+"'><![CDATA["+t(l[h].childNodes[2].innerHTML)+"]]></body>"}else{var v=i?o(l[h],"color"):"",m=i?o(l[h],"backgroundColor"):"";_+="<body backgroundColor='"+m+"' color='"+v+"'><![CDATA["+t(l[h].innerHTML)+"]]></body>"}_+="</event>"}}}}return _}function v(t,a,n,i,r,o){var d=!1;"fullcolor"==i&&(d=!0,i="color"),i=i||"color";var s="";if(t){var u=e._date,g=e._mode
;a=e.date[n+"_start"](a),a=e.date["get_"+n+"_end"]?e.date["get_"+n+"_end"](a):e.date.add(a,1,n),s=c("pages",i,r,o);for(var v=new Date(t);+v<+a;v=this.date.add(v,1,n))this.setCurrentView(v,n),s+=_("page")+h().replace("–","-")+f(d)+l("page");s+=l("pages"),this.setCurrentView(u,g)}else s=c("data",i,r,o)+h().replace("–","-")+f(d)+l("data");return s}function m(t,a){var n=e.uid(),i=document.createElement("div");i.style.display="none",document.body.appendChild(i),
i.innerHTML='<form id="'+n+'" method="post" target="_blank" action="'+a+'" accept-charset="utf-8" enctype="application/x-www-form-urlencoded"><input type="hidden" name="mycoolxmlbody"/> </form>',document.getElementById(n).firstChild.value=encodeURIComponent(t),document.getElementById(n).submit(),i.parentNode.removeChild(i)}function p(e,t,a,n,i,r,o){var d="";d="object"==typeof i?y(i):v.apply(this,[e,t,a,i,r,o]),m(d,n)}function y(e){
for(var t="<data>",a=0;a<e.length;a++)t+=e[a].source.getPDFData(e[a].start,e[a].end,e[a].view,e[a].mode,e[a].header,e[a].footer);return t+="</data>"}var b,x,w=new RegExp("<[^>]*>","g"),k=new RegExp("<br[^>]*>","g");e.getPDFData=v,e.toPDF=function(e,t,a,n){return p.apply(this,[null,null,null,e,t,a,n])},e.toPDFRange=function(t,a,n,i,r,o,d){return"string"==typeof t&&(t=e.templates.api_date(t),a=e.templates.api_date(a)),p.apply(this,arguments)}}()});
//# sourceMappingURL=../sources/ext/dhtmlxscheduler_pdf.js.map