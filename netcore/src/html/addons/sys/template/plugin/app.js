/*! head.load - v1.0.3 */
(function (win, undefined) { var doc = win.document, domWaiters = [], handlers = {}, assets = {}, isAsync = "async" in doc.createElement("script") || "MozAppearance" in doc.documentElement.style || win.opera, isDomReady, headVar = win.head_conf && win.head_conf.head || "head", api = win[headVar] = (win[headVar] || function () { api.ready.apply(null, arguments) }), PRELOADING = 1, PRELOADED = 2, LOADING = 3, LOADED = 4; function noop() { } function each(arr, callback) { if (!arr) { return } if (typeof arr === "object") { arr = [].slice.call(arr) } for (var i = 0, l = arr.length; i < l; i++) { callback.call(arr, arr[i], i) } } function is(type, obj) { var clas = Object.prototype.toString.call(obj).slice(8, -1); return obj !== undefined && obj !== null && clas === type } function isFunction(item) { return is("Function", item) } function isArray(item) { return is("Array", item) } function toLabel(url) { var items = url.split("/"), name = items[items.length - 1], i = name.indexOf("?"); return i !== -1 ? name.substring(0, i) : name } function one(callback) { callback = callback || noop; if (callback._done) { return } callback(); callback._done = 1 } function conditional(test, success, failure, callback) { var obj = (typeof test === "object") ? test : { test: test, success: !!success ? isArray(success) ? success : [success] : false, failure: !!failure ? isArray(failure) ? failure : [failure] : false, callback: callback || noop }; var passed = !!obj.test; if (passed && !!obj.success) { obj.success.push(obj.callback); api.load.apply(null, obj.success) } else { if (!passed && !!obj.failure) { obj.failure.push(obj.callback); api.load.apply(null, obj.failure) } else { callback() } } return api } function getAsset(item) { var asset = {}; if (typeof item === "object") { for (var label in item) { if (!!item[label]) { asset = { name: label, url: item[label] } } } } else { asset = { name: toLabel(item), url: item } } var existing = assets[asset.name]; if (existing && existing.url === asset.url) { return existing } assets[asset.name] = asset; return asset } function allLoaded(items) { items = items || assets; for (var name in items) { if (items.hasOwnProperty(name) && items[name].state !== LOADED) { return false } } return true } function onPreload(asset) { asset.state = PRELOADED; each(asset.onpreload, function (afterPreload) { afterPreload.call() }) } function preLoad(asset, callback) { if (asset.state === undefined) { asset.state = PRELOADING; asset.onpreload = []; loadAsset({ url: asset.url, type: "cache" }, function () { onPreload(asset) }) } } function apiLoadHack() { var args = arguments, callback = args[args.length - 1], rest = [].slice.call(args, 1), next = rest[0]; if (!isFunction(callback)) { callback = null } if (isArray(args[0])) { args[0].push(callback); api.load.apply(null, args[0]); return api } if (!!next) { each(rest, function (item) { if (!isFunction(item) && !!item) { preLoad(getAsset(item)) } }); load(getAsset(args[0]), isFunction(next) ? next : function () { api.load.apply(null, rest) }) } else { load(getAsset(args[0])) } return api } function apiLoadAsync() { var args = arguments, callback = args[args.length - 1], items = {}; if (!isFunction(callback)) { callback = null } if (isArray(args[0])) { args[0].push(callback); api.load.apply(null, args[0]); return api } each(args, function (item, i) { if (item !== callback) { item = getAsset(item); items[item.name] = item } }); each(args, function (item, i) { if (item !== callback) { item = getAsset(item); load(item, function () { if (allLoaded(items)) { one(callback) } }) } }); return api } function load(asset, callback) { callback = callback || noop; if (asset.state === LOADED) { callback(); return } if (asset.state === LOADING) { api.ready(asset.name, callback); return } if (asset.state === PRELOADING) { asset.onpreload.push(function () { load(asset, callback) }); return } asset.state = LOADING; loadAsset(asset, function () { asset.state = LOADED; callback(); each(handlers[asset.name], function (fn) { one(fn) }); if (isDomReady && allLoaded()) { each(handlers.ALL, function (fn) { one(fn) }) } }) } function getExtension(url) { url = url || ""; var items = url.split("?")[0].split("."); return items[items.length - 1].toLowerCase() } function loadAsset(asset, callback) { callback = callback || noop; function error(event) { event = event || win.event; ele.onload = ele.onreadystatechange = ele.onerror = null; callback() } function process(event) { event = event || win.event; if (event.type === "load" || (/loaded|complete/.test(ele.readyState) && (!doc.documentMode || doc.documentMode < 9))) { win.clearTimeout(asset.errorTimeout); win.clearTimeout(asset.cssTimeout); ele.onload = ele.onreadystatechange = ele.onerror = null; callback() } } function isCssLoaded() { if (asset.state !== LOADED && asset.cssRetries <= 20) { for (var i = 0, l = doc.styleSheets.length; i < l; i++) { if (doc.styleSheets[i].href === ele.href) { process({ "type": "load" }); return } } asset.cssRetries++; asset.cssTimeout = win.setTimeout(isCssLoaded, 250) } } var ele; var ext = getExtension(asset.url); if (ext === "css") { ele = doc.createElement("link"); ele.type = "text/" + (asset.type || "css"); ele.rel = "stylesheet"; ele.href = asset.url; asset.cssRetries = 0; asset.cssTimeout = win.setTimeout(isCssLoaded, 500) } else { ele = doc.createElement("script"); ele.type = "text/" + (asset.type || "javascript"); ele.src = asset.url } ele.onload = ele.onreadystatechange = process; ele.onerror = error; ele.async = false; ele.defer = false; asset.errorTimeout = win.setTimeout(function () { error({ type: "timeout" }) }, 7000); var head = doc.head || doc.getElementsByTagName("head")[0]; head.insertBefore(ele, head.lastChild) } function init() { var items = doc.getElementsByTagName("script"); for (var i = 0, l = items.length; i < l; i++) { var dataMain = items[i].getAttribute("data-headjs-load"); if (!!dataMain) { api.load(dataMain); return } } } function ready(key, callback) { if (key === doc) { if (isDomReady) { one(callback) } else { domWaiters.push(callback) } return api } if (isFunction(key)) { callback = key; key = "ALL" } if (isArray(key)) { var items = {}; each(key, function (item) { items[item] = assets[item]; api.ready(item, function () { if (allLoaded(items)) { one(callback) } }) }); return api } if (typeof key !== "string" || !isFunction(callback)) { return api } var asset = assets[key]; if (asset && asset.state === LOADED || key === "ALL" && allLoaded() && isDomReady) { one(callback); return api } var arr = handlers[key]; if (!arr) { arr = handlers[key] = [callback] } else { arr.push(callback) } return api } function domReady() { if (!doc.body) { win.clearTimeout(api.readyTimeout); api.readyTimeout = win.setTimeout(domReady, 50); return } if (!isDomReady) { isDomReady = true; init(); each(domWaiters, function (fn) { one(fn) }) } } function domContentLoaded() { if (doc.addEventListener) { doc.removeEventListener("DOMContentLoaded", domContentLoaded, false); domReady() } else { if (doc.readyState === "complete") { doc.detachEvent("onreadystatechange", domContentLoaded); domReady() } } } if (doc.readyState === "complete") { domReady() } else { if (doc.addEventListener) { doc.addEventListener("DOMContentLoaded", domContentLoaded, false); win.addEventListener("load", domReady, false) } else { doc.attachEvent("onreadystatechange", domContentLoaded); win.attachEvent("onload", domReady); var top = false; try { top = !win.frameElement && doc.documentElement } catch (e) { } if (top && top.doScroll) { (function doScrollCheck() { if (!isDomReady) { try { top.doScroll("left") } catch (error) { win.clearTimeout(api.readyTimeout); api.readyTimeout = win.setTimeout(doScrollCheck, 50); return } domReady() } }()) } } } api.load = api.js = isAsync ? apiLoadAsync : apiLoadHack; api.test = conditional; api.ready = ready; api.ready(doc, function () { if (allLoaded()) { each(handlers.ALL, function (callback) { one(callback) }) } if (api.feature) { api.feature("domloaded", true) } }) }(window));
/*! jQuery v3.1.0 | (c) jQuery Foundation | jquery.org/license */
!function (a, b) { "use strict"; "object" == typeof module && "object" == typeof module.exports ? module.exports = a.document ? b(a, !0) : function (a) { if (!a.document) throw new Error("jQuery requires a window with a document"); return b(a) } : b(a) }("undefined" != typeof window ? window : this, function (a, b) {
    "use strict"; var c = [], d = a.document, e = Object.getPrototypeOf, f = c.slice, g = c.concat, h = c.push, i = c.indexOf, j = {}, k = j.toString, l = j.hasOwnProperty, m = l.toString, n = m.call(Object), o = {}; function p(a, b) { b = b || d; var c = b.createElement("script"); c.text = a, b.head.appendChild(c).parentNode.removeChild(c) } var q = "3.1.0", r = function (a, b) { return new r.fn.init(a, b) }, s = /^[\s\uFEFF\xA0]+|[\s\uFEFF\xA0]+$/g, t = /^-ms-/, u = /-([a-z])/g, v = function (a, b) { return b.toUpperCase() }; r.fn = r.prototype = { jquery: q, constructor: r, length: 0, toArray: function () { return f.call(this) }, get: function (a) { return null != a ? a < 0 ? this[a + this.length] : this[a] : f.call(this) }, pushStack: function (a) { var b = r.merge(this.constructor(), a); return b.prevObject = this, b }, each: function (a) { return r.each(this, a) }, map: function (a) { return this.pushStack(r.map(this, function (b, c) { return a.call(b, c, b) })) }, slice: function () { return this.pushStack(f.apply(this, arguments)) }, first: function () { return this.eq(0) }, last: function () { return this.eq(-1) }, eq: function (a) { var b = this.length, c = +a + (a < 0 ? b : 0); return this.pushStack(c >= 0 && c < b ? [this[c]] : []) }, end: function () { return this.prevObject || this.constructor() }, push: h, sort: c.sort, splice: c.splice }, r.extend = r.fn.extend = function () { var a, b, c, d, e, f, g = arguments[0] || {}, h = 1, i = arguments.length, j = !1; for ("boolean" == typeof g && (j = g, g = arguments[h] || {}, h++), "object" == typeof g || r.isFunction(g) || (g = {}), h === i && (g = this, h--); h < i; h++)if (null != (a = arguments[h])) for (b in a) c = g[b], d = a[b], g !== d && (j && d && (r.isPlainObject(d) || (e = r.isArray(d))) ? (e ? (e = !1, f = c && r.isArray(c) ? c : []) : f = c && r.isPlainObject(c) ? c : {}, g[b] = r.extend(j, f, d)) : void 0 !== d && (g[b] = d)); return g }, r.extend({ expando: "jQuery" + (q + Math.random()).replace(/\D/g, ""), isReady: !0, error: function (a) { throw new Error(a) }, noop: function () { }, isFunction: function (a) { return "function" === r.type(a) }, isArray: Array.isArray, isWindow: function (a) { return null != a && a === a.window }, isNumeric: function (a) { var b = r.type(a); return ("number" === b || "string" === b) && !isNaN(a - parseFloat(a)) }, isPlainObject: function (a) { var b, c; return !(!a || "[object Object]" !== k.call(a)) && (!(b = e(a)) || (c = l.call(b, "constructor") && b.constructor, "function" == typeof c && m.call(c) === n)) }, isEmptyObject: function (a) { var b; for (b in a) return !1; return !0 }, type: function (a) { return null == a ? a + "" : "object" == typeof a || "function" == typeof a ? j[k.call(a)] || "object" : typeof a }, globalEval: function (a) { p(a) }, camelCase: function (a) { return a.replace(t, "ms-").replace(u, v) }, nodeName: function (a, b) { return a.nodeName && a.nodeName.toLowerCase() === b.toLowerCase() }, each: function (a, b) { var c, d = 0; if (w(a)) { for (c = a.length; d < c; d++)if (b.call(a[d], d, a[d]) === !1) break } else for (d in a) if (b.call(a[d], d, a[d]) === !1) break; return a }, trim: function (a) { return null == a ? "" : (a + "").replace(s, "") }, makeArray: function (a, b) { var c = b || []; return null != a && (w(Object(a)) ? r.merge(c, "string" == typeof a ? [a] : a) : h.call(c, a)), c }, inArray: function (a, b, c) { return null == b ? -1 : i.call(b, a, c) }, merge: function (a, b) { for (var c = +b.length, d = 0, e = a.length; d < c; d++)a[e++] = b[d]; return a.length = e, a }, grep: function (a, b, c) { for (var d, e = [], f = 0, g = a.length, h = !c; f < g; f++)d = !b(a[f], f), d !== h && e.push(a[f]); return e }, map: function (a, b, c) { var d, e, f = 0, h = []; if (w(a)) for (d = a.length; f < d; f++)e = b(a[f], f, c), null != e && h.push(e); else for (f in a) e = b(a[f], f, c), null != e && h.push(e); return g.apply([], h) }, guid: 1, proxy: function (a, b) { var c, d, e; if ("string" == typeof b && (c = a[b], b = a, a = c), r.isFunction(a)) return d = f.call(arguments, 2), e = function () { return a.apply(b || this, d.concat(f.call(arguments))) }, e.guid = a.guid = a.guid || r.guid++ , e }, now: Date.now, support: o }), "function" == typeof Symbol && (r.fn[Symbol.iterator] = c[Symbol.iterator]), r.each("Boolean Number String Function Array Date RegExp Object Error Symbol".split(" "), function (a, b) { j["[object " + b + "]"] = b.toLowerCase() }); function w(a) { var b = !!a && "length" in a && a.length, c = r.type(a); return "function" !== c && !r.isWindow(a) && ("array" === c || 0 === b || "number" == typeof b && b > 0 && b - 1 in a) } var x = function (a) { var b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u = "sizzle" + 1 * new Date, v = a.document, w = 0, x = 0, y = ha(), z = ha(), A = ha(), B = function (a, b) { return a === b && (l = !0), 0 }, C = {}.hasOwnProperty, D = [], E = D.pop, F = D.push, G = D.push, H = D.slice, I = function (a, b) { for (var c = 0, d = a.length; c < d; c++)if (a[c] === b) return c; return -1 }, J = "checked|selected|async|autofocus|autoplay|controls|defer|disabled|hidden|ismap|loop|multiple|open|readonly|required|scoped", K = "[\\x20\\t\\r\\n\\f]", L = "(?:\\\\.|[\\w-]|[^\0-\\xa0])+", M = "\\[" + K + "*(" + L + ")(?:" + K + "*([*^$|!~]?=)" + K + "*(?:'((?:\\\\.|[^\\\\'])*)'|\"((?:\\\\.|[^\\\\\"])*)\"|(" + L + "))|)" + K + "*\\]", N = ":(" + L + ")(?:\\((('((?:\\\\.|[^\\\\'])*)'|\"((?:\\\\.|[^\\\\\"])*)\")|((?:\\\\.|[^\\\\()[\\]]|" + M + ")*)|.*)\\)|)", O = new RegExp(K + "+", "g"), P = new RegExp("^" + K + "+|((?:^|[^\\\\])(?:\\\\.)*)" + K + "+$", "g"), Q = new RegExp("^" + K + "*," + K + "*"), R = new RegExp("^" + K + "*([>+~]|" + K + ")" + K + "*"), S = new RegExp("=" + K + "*([^\\]'\"]*?)" + K + "*\\]", "g"), T = new RegExp(N), U = new RegExp("^" + L + "$"), V = { ID: new RegExp("^#(" + L + ")"), CLASS: new RegExp("^\\.(" + L + ")"), TAG: new RegExp("^(" + L + "|[*])"), ATTR: new RegExp("^" + M), PSEUDO: new RegExp("^" + N), CHILD: new RegExp("^:(only|first|last|nth|nth-last)-(child|of-type)(?:\\(" + K + "*(even|odd|(([+-]|)(\\d*)n|)" + K + "*(?:([+-]|)" + K + "*(\\d+)|))" + K + "*\\)|)", "i"), bool: new RegExp("^(?:" + J + ")$", "i"), needsContext: new RegExp("^" + K + "*[>+~]|:(even|odd|eq|gt|lt|nth|first|last)(?:\\(" + K + "*((?:-\\d)?\\d*)" + K + "*\\)|)(?=[^-]|$)", "i") }, W = /^(?:input|select|textarea|button)$/i, X = /^h\d$/i, Y = /^[^{]+\{\s*\[native \w/, Z = /^(?:#([\w-]+)|(\w+)|\.([\w-]+))$/, $ = /[+~]/, _ = new RegExp("\\\\([\\da-f]{1,6}" + K + "?|(" + K + ")|.)", "ig"), aa = function (a, b, c) { var d = "0x" + b - 65536; return d !== d || c ? b : d < 0 ? String.fromCharCode(d + 65536) : String.fromCharCode(d >> 10 | 55296, 1023 & d | 56320) }, ba = /([\0-\x1f\x7f]|^-?\d)|^-$|[^\x80-\uFFFF\w-]/g, ca = function (a, b) { return b ? "\0" === a ? "\ufffd" : a.slice(0, -1) + "\\" + a.charCodeAt(a.length - 1).toString(16) + " " : "\\" + a }, da = function () { m() }, ea = ta(function (a) { return a.disabled === !0 }, { dir: "parentNode", next: "legend" }); try { G.apply(D = H.call(v.childNodes), v.childNodes), D[v.childNodes.length].nodeType } catch (fa) { G = { apply: D.length ? function (a, b) { F.apply(a, H.call(b)) } : function (a, b) { var c = a.length, d = 0; while (a[c++] = b[d++]); a.length = c - 1 } } } function ga(a, b, d, e) { var f, h, j, k, l, o, r, s = b && b.ownerDocument, w = b ? b.nodeType : 9; if (d = d || [], "string" != typeof a || !a || 1 !== w && 9 !== w && 11 !== w) return d; if (!e && ((b ? b.ownerDocument || b : v) !== n && m(b), b = b || n, p)) { if (11 !== w && (l = Z.exec(a))) if (f = l[1]) { if (9 === w) { if (!(j = b.getElementById(f))) return d; if (j.id === f) return d.push(j), d } else if (s && (j = s.getElementById(f)) && t(b, j) && j.id === f) return d.push(j), d } else { if (l[2]) return G.apply(d, b.getElementsByTagName(a)), d; if ((f = l[3]) && c.getElementsByClassName && b.getElementsByClassName) return G.apply(d, b.getElementsByClassName(f)), d } if (c.qsa && !A[a + " "] && (!q || !q.test(a))) { if (1 !== w) s = b, r = a; else if ("object" !== b.nodeName.toLowerCase()) { (k = b.getAttribute("id")) ? k = k.replace(ba, ca) : b.setAttribute("id", k = u), o = g(a), h = o.length; while (h--) o[h] = "#" + k + " " + sa(o[h]); r = o.join(","), s = $.test(a) && qa(b.parentNode) || b } if (r) try { return G.apply(d, s.querySelectorAll(r)), d } catch (x) { } finally { k === u && b.removeAttribute("id") } } } return i(a.replace(P, "$1"), b, d, e) } function ha() { var a = []; function b(c, e) { return a.push(c + " ") > d.cacheLength && delete b[a.shift()], b[c + " "] = e } return b } function ia(a) { return a[u] = !0, a } function ja(a) { var b = n.createElement("fieldset"); try { return !!a(b) } catch (c) { return !1 } finally { b.parentNode && b.parentNode.removeChild(b), b = null } } function ka(a, b) { var c = a.split("|"), e = c.length; while (e--) d.attrHandle[c[e]] = b } function la(a, b) { var c = b && a, d = c && 1 === a.nodeType && 1 === b.nodeType && a.sourceIndex - b.sourceIndex; if (d) return d; if (c) while (c = c.nextSibling) if (c === b) return -1; return a ? 1 : -1 } function ma(a) { return function (b) { var c = b.nodeName.toLowerCase(); return "input" === c && b.type === a } } function na(a) { return function (b) { var c = b.nodeName.toLowerCase(); return ("input" === c || "button" === c) && b.type === a } } function oa(a) { return function (b) { return "label" in b && b.disabled === a || "form" in b && b.disabled === a || "form" in b && b.disabled === !1 && (b.isDisabled === a || b.isDisabled !== !a && ("label" in b || !ea(b)) !== a) } } function pa(a) { return ia(function (b) { return b = +b, ia(function (c, d) { var e, f = a([], c.length, b), g = f.length; while (g--) c[e = f[g]] && (c[e] = !(d[e] = c[e])) }) }) } function qa(a) { return a && "undefined" != typeof a.getElementsByTagName && a } c = ga.support = {}, f = ga.isXML = function (a) { var b = a && (a.ownerDocument || a).documentElement; return !!b && "HTML" !== b.nodeName }, m = ga.setDocument = function (a) { var b, e, g = a ? a.ownerDocument || a : v; return g !== n && 9 === g.nodeType && g.documentElement ? (n = g, o = n.documentElement, p = !f(n), v !== n && (e = n.defaultView) && e.top !== e && (e.addEventListener ? e.addEventListener("unload", da, !1) : e.attachEvent && e.attachEvent("onunload", da)), c.attributes = ja(function (a) { return a.className = "i", !a.getAttribute("className") }), c.getElementsByTagName = ja(function (a) { return a.appendChild(n.createComment("")), !a.getElementsByTagName("*").length }), c.getElementsByClassName = Y.test(n.getElementsByClassName), c.getById = ja(function (a) { return o.appendChild(a).id = u, !n.getElementsByName || !n.getElementsByName(u).length }), c.getById ? (d.find.ID = function (a, b) { if ("undefined" != typeof b.getElementById && p) { var c = b.getElementById(a); return c ? [c] : [] } }, d.filter.ID = function (a) { var b = a.replace(_, aa); return function (a) { return a.getAttribute("id") === b } }) : (delete d.find.ID, d.filter.ID = function (a) { var b = a.replace(_, aa); return function (a) { var c = "undefined" != typeof a.getAttributeNode && a.getAttributeNode("id"); return c && c.value === b } }), d.find.TAG = c.getElementsByTagName ? function (a, b) { return "undefined" != typeof b.getElementsByTagName ? b.getElementsByTagName(a) : c.qsa ? b.querySelectorAll(a) : void 0 } : function (a, b) { var c, d = [], e = 0, f = b.getElementsByTagName(a); if ("*" === a) { while (c = f[e++]) 1 === c.nodeType && d.push(c); return d } return f }, d.find.CLASS = c.getElementsByClassName && function (a, b) { if ("undefined" != typeof b.getElementsByClassName && p) return b.getElementsByClassName(a) }, r = [], q = [], (c.qsa = Y.test(n.querySelectorAll)) && (ja(function (a) { o.appendChild(a).innerHTML = "<a id='" + u + "'></a><select id='" + u + "-\r\\' msallowcapture=''><option selected=''></option></select>", a.querySelectorAll("[msallowcapture^='']").length && q.push("[*^$]=" + K + "*(?:''|\"\")"), a.querySelectorAll("[selected]").length || q.push("\\[" + K + "*(?:value|" + J + ")"), a.querySelectorAll("[id~=" + u + "-]").length || q.push("~="), a.querySelectorAll(":checked").length || q.push(":checked"), a.querySelectorAll("a#" + u + "+*").length || q.push(".#.+[+~]") }), ja(function (a) { a.innerHTML = "<a href='' disabled='disabled'></a><select disabled='disabled'><option/></select>"; var b = n.createElement("input"); b.setAttribute("type", "hidden"), a.appendChild(b).setAttribute("name", "D"), a.querySelectorAll("[name=d]").length && q.push("name" + K + "*[*^$|!~]?="), 2 !== a.querySelectorAll(":enabled").length && q.push(":enabled", ":disabled"), o.appendChild(a).disabled = !0, 2 !== a.querySelectorAll(":disabled").length && q.push(":enabled", ":disabled"), a.querySelectorAll("*,:x"), q.push(",.*:") })), (c.matchesSelector = Y.test(s = o.matches || o.webkitMatchesSelector || o.mozMatchesSelector || o.oMatchesSelector || o.msMatchesSelector)) && ja(function (a) { c.disconnectedMatch = s.call(a, "*"), s.call(a, "[s!='']:x"), r.push("!=", N) }), q = q.length && new RegExp(q.join("|")), r = r.length && new RegExp(r.join("|")), b = Y.test(o.compareDocumentPosition), t = b || Y.test(o.contains) ? function (a, b) { var c = 9 === a.nodeType ? a.documentElement : a, d = b && b.parentNode; return a === d || !(!d || 1 !== d.nodeType || !(c.contains ? c.contains(d) : a.compareDocumentPosition && 16 & a.compareDocumentPosition(d))) } : function (a, b) { if (b) while (b = b.parentNode) if (b === a) return !0; return !1 }, B = b ? function (a, b) { if (a === b) return l = !0, 0; var d = !a.compareDocumentPosition - !b.compareDocumentPosition; return d ? d : (d = (a.ownerDocument || a) === (b.ownerDocument || b) ? a.compareDocumentPosition(b) : 1, 1 & d || !c.sortDetached && b.compareDocumentPosition(a) === d ? a === n || a.ownerDocument === v && t(v, a) ? -1 : b === n || b.ownerDocument === v && t(v, b) ? 1 : k ? I(k, a) - I(k, b) : 0 : 4 & d ? -1 : 1) } : function (a, b) { if (a === b) return l = !0, 0; var c, d = 0, e = a.parentNode, f = b.parentNode, g = [a], h = [b]; if (!e || !f) return a === n ? -1 : b === n ? 1 : e ? -1 : f ? 1 : k ? I(k, a) - I(k, b) : 0; if (e === f) return la(a, b); c = a; while (c = c.parentNode) g.unshift(c); c = b; while (c = c.parentNode) h.unshift(c); while (g[d] === h[d]) d++; return d ? la(g[d], h[d]) : g[d] === v ? -1 : h[d] === v ? 1 : 0 }, n) : n }, ga.matches = function (a, b) { return ga(a, null, null, b) }, ga.matchesSelector = function (a, b) { if ((a.ownerDocument || a) !== n && m(a), b = b.replace(S, "='$1']"), c.matchesSelector && p && !A[b + " "] && (!r || !r.test(b)) && (!q || !q.test(b))) try { var d = s.call(a, b); if (d || c.disconnectedMatch || a.document && 11 !== a.document.nodeType) return d } catch (e) { } return ga(b, n, null, [a]).length > 0 }, ga.contains = function (a, b) { return (a.ownerDocument || a) !== n && m(a), t(a, b) }, ga.attr = function (a, b) { (a.ownerDocument || a) !== n && m(a); var e = d.attrHandle[b.toLowerCase()], f = e && C.call(d.attrHandle, b.toLowerCase()) ? e(a, b, !p) : void 0; return void 0 !== f ? f : c.attributes || !p ? a.getAttribute(b) : (f = a.getAttributeNode(b)) && f.specified ? f.value : null }, ga.escape = function (a) { return (a + "").replace(ba, ca) }, ga.error = function (a) { throw new Error("Syntax error, unrecognized expression: " + a) }, ga.uniqueSort = function (a) { var b, d = [], e = 0, f = 0; if (l = !c.detectDuplicates, k = !c.sortStable && a.slice(0), a.sort(B), l) { while (b = a[f++]) b === a[f] && (e = d.push(f)); while (e--) a.splice(d[e], 1) } return k = null, a }, e = ga.getText = function (a) { var b, c = "", d = 0, f = a.nodeType; if (f) { if (1 === f || 9 === f || 11 === f) { if ("string" == typeof a.textContent) return a.textContent; for (a = a.firstChild; a; a = a.nextSibling)c += e(a) } else if (3 === f || 4 === f) return a.nodeValue } else while (b = a[d++]) c += e(b); return c }, d = ga.selectors = { cacheLength: 50, createPseudo: ia, match: V, attrHandle: {}, find: {}, relative: { ">": { dir: "parentNode", first: !0 }, " ": { dir: "parentNode" }, "+": { dir: "previousSibling", first: !0 }, "~": { dir: "previousSibling" } }, preFilter: { ATTR: function (a) { return a[1] = a[1].replace(_, aa), a[3] = (a[3] || a[4] || a[5] || "").replace(_, aa), "~=" === a[2] && (a[3] = " " + a[3] + " "), a.slice(0, 4) }, CHILD: function (a) { return a[1] = a[1].toLowerCase(), "nth" === a[1].slice(0, 3) ? (a[3] || ga.error(a[0]), a[4] = +(a[4] ? a[5] + (a[6] || 1) : 2 * ("even" === a[3] || "odd" === a[3])), a[5] = +(a[7] + a[8] || "odd" === a[3])) : a[3] && ga.error(a[0]), a }, PSEUDO: function (a) { var b, c = !a[6] && a[2]; return V.CHILD.test(a[0]) ? null : (a[3] ? a[2] = a[4] || a[5] || "" : c && T.test(c) && (b = g(c, !0)) && (b = c.indexOf(")", c.length - b) - c.length) && (a[0] = a[0].slice(0, b), a[2] = c.slice(0, b)), a.slice(0, 3)) } }, filter: { TAG: function (a) { var b = a.replace(_, aa).toLowerCase(); return "*" === a ? function () { return !0 } : function (a) { return a.nodeName && a.nodeName.toLowerCase() === b } }, CLASS: function (a) { var b = y[a + " "]; return b || (b = new RegExp("(^|" + K + ")" + a + "(" + K + "|$)")) && y(a, function (a) { return b.test("string" == typeof a.className && a.className || "undefined" != typeof a.getAttribute && a.getAttribute("class") || "") }) }, ATTR: function (a, b, c) { return function (d) { var e = ga.attr(d, a); return null == e ? "!=" === b : !b || (e += "", "=" === b ? e === c : "!=" === b ? e !== c : "^=" === b ? c && 0 === e.indexOf(c) : "*=" === b ? c && e.indexOf(c) > -1 : "$=" === b ? c && e.slice(-c.length) === c : "~=" === b ? (" " + e.replace(O, " ") + " ").indexOf(c) > -1 : "|=" === b && (e === c || e.slice(0, c.length + 1) === c + "-")) } }, CHILD: function (a, b, c, d, e) { var f = "nth" !== a.slice(0, 3), g = "last" !== a.slice(-4), h = "of-type" === b; return 1 === d && 0 === e ? function (a) { return !!a.parentNode } : function (b, c, i) { var j, k, l, m, n, o, p = f !== g ? "nextSibling" : "previousSibling", q = b.parentNode, r = h && b.nodeName.toLowerCase(), s = !i && !h, t = !1; if (q) { if (f) { while (p) { m = b; while (m = m[p]) if (h ? m.nodeName.toLowerCase() === r : 1 === m.nodeType) return !1; o = p = "only" === a && !o && "nextSibling" } return !0 } if (o = [g ? q.firstChild : q.lastChild], g && s) { m = q, l = m[u] || (m[u] = {}), k = l[m.uniqueID] || (l[m.uniqueID] = {}), j = k[a] || [], n = j[0] === w && j[1], t = n && j[2], m = n && q.childNodes[n]; while (m = ++n && m && m[p] || (t = n = 0) || o.pop()) if (1 === m.nodeType && ++t && m === b) { k[a] = [w, n, t]; break } } else if (s && (m = b, l = m[u] || (m[u] = {}), k = l[m.uniqueID] || (l[m.uniqueID] = {}), j = k[a] || [], n = j[0] === w && j[1], t = n), t === !1) while (m = ++n && m && m[p] || (t = n = 0) || o.pop()) if ((h ? m.nodeName.toLowerCase() === r : 1 === m.nodeType) && ++t && (s && (l = m[u] || (m[u] = {}), k = l[m.uniqueID] || (l[m.uniqueID] = {}), k[a] = [w, t]), m === b)) break; return t -= e, t === d || t % d === 0 && t / d >= 0 } } }, PSEUDO: function (a, b) { var c, e = d.pseudos[a] || d.setFilters[a.toLowerCase()] || ga.error("unsupported pseudo: " + a); return e[u] ? e(b) : e.length > 1 ? (c = [a, a, "", b], d.setFilters.hasOwnProperty(a.toLowerCase()) ? ia(function (a, c) { var d, f = e(a, b), g = f.length; while (g--) d = I(a, f[g]), a[d] = !(c[d] = f[g]) }) : function (a) { return e(a, 0, c) }) : e } }, pseudos: { not: ia(function (a) { var b = [], c = [], d = h(a.replace(P, "$1")); return d[u] ? ia(function (a, b, c, e) { var f, g = d(a, null, e, []), h = a.length; while (h--) (f = g[h]) && (a[h] = !(b[h] = f)) }) : function (a, e, f) { return b[0] = a, d(b, null, f, c), b[0] = null, !c.pop() } }), has: ia(function (a) { return function (b) { return ga(a, b).length > 0 } }), contains: ia(function (a) { return a = a.replace(_, aa), function (b) { return (b.textContent || b.innerText || e(b)).indexOf(a) > -1 } }), lang: ia(function (a) { return U.test(a || "") || ga.error("unsupported lang: " + a), a = a.replace(_, aa).toLowerCase(), function (b) { var c; do if (c = p ? b.lang : b.getAttribute("xml:lang") || b.getAttribute("lang")) return c = c.toLowerCase(), c === a || 0 === c.indexOf(a + "-"); while ((b = b.parentNode) && 1 === b.nodeType); return !1 } }), target: function (b) { var c = a.location && a.location.hash; return c && c.slice(1) === b.id }, root: function (a) { return a === o }, focus: function (a) { return a === n.activeElement && (!n.hasFocus || n.hasFocus()) && !!(a.type || a.href || ~a.tabIndex) }, enabled: oa(!1), disabled: oa(!0), checked: function (a) { var b = a.nodeName.toLowerCase(); return "input" === b && !!a.checked || "option" === b && !!a.selected }, selected: function (a) { return a.parentNode && a.parentNode.selectedIndex, a.selected === !0 }, empty: function (a) { for (a = a.firstChild; a; a = a.nextSibling)if (a.nodeType < 6) return !1; return !0 }, parent: function (a) { return !d.pseudos.empty(a) }, header: function (a) { return X.test(a.nodeName) }, input: function (a) { return W.test(a.nodeName) }, button: function (a) { var b = a.nodeName.toLowerCase(); return "input" === b && "button" === a.type || "button" === b }, text: function (a) { var b; return "input" === a.nodeName.toLowerCase() && "text" === a.type && (null == (b = a.getAttribute("type")) || "text" === b.toLowerCase()) }, first: pa(function () { return [0] }), last: pa(function (a, b) { return [b - 1] }), eq: pa(function (a, b, c) { return [c < 0 ? c + b : c] }), even: pa(function (a, b) { for (var c = 0; c < b; c += 2)a.push(c); return a }), odd: pa(function (a, b) { for (var c = 1; c < b; c += 2)a.push(c); return a }), lt: pa(function (a, b, c) { for (var d = c < 0 ? c + b : c; --d >= 0;)a.push(d); return a }), gt: pa(function (a, b, c) { for (var d = c < 0 ? c + b : c; ++d < b;)a.push(d); return a }) } }, d.pseudos.nth = d.pseudos.eq; for (b in { radio: !0, checkbox: !0, file: !0, password: !0, image: !0 }) d.pseudos[b] = ma(b); for (b in { submit: !0, reset: !0 }) d.pseudos[b] = na(b); function ra() { } ra.prototype = d.filters = d.pseudos, d.setFilters = new ra, g = ga.tokenize = function (a, b) { var c, e, f, g, h, i, j, k = z[a + " "]; if (k) return b ? 0 : k.slice(0); h = a, i = [], j = d.preFilter; while (h) { c && !(e = Q.exec(h)) || (e && (h = h.slice(e[0].length) || h), i.push(f = [])), c = !1, (e = R.exec(h)) && (c = e.shift(), f.push({ value: c, type: e[0].replace(P, " ") }), h = h.slice(c.length)); for (g in d.filter) !(e = V[g].exec(h)) || j[g] && !(e = j[g](e)) || (c = e.shift(), f.push({ value: c, type: g, matches: e }), h = h.slice(c.length)); if (!c) break } return b ? h.length : h ? ga.error(a) : z(a, i).slice(0) }; function sa(a) { for (var b = 0, c = a.length, d = ""; b < c; b++)d += a[b].value; return d } function ta(a, b, c) { var d = b.dir, e = b.next, f = e || d, g = c && "parentNode" === f, h = x++; return b.first ? function (b, c, e) { while (b = b[d]) if (1 === b.nodeType || g) return a(b, c, e) } : function (b, c, i) { var j, k, l, m = [w, h]; if (i) { while (b = b[d]) if ((1 === b.nodeType || g) && a(b, c, i)) return !0 } else while (b = b[d]) if (1 === b.nodeType || g) if (l = b[u] || (b[u] = {}), k = l[b.uniqueID] || (l[b.uniqueID] = {}), e && e === b.nodeName.toLowerCase()) b = b[d] || b; else { if ((j = k[f]) && j[0] === w && j[1] === h) return m[2] = j[2]; if (k[f] = m, m[2] = a(b, c, i)) return !0 } } } function ua(a) { return a.length > 1 ? function (b, c, d) { var e = a.length; while (e--) if (!a[e](b, c, d)) return !1; return !0 } : a[0] } function va(a, b, c) { for (var d = 0, e = b.length; d < e; d++)ga(a, b[d], c); return c } function wa(a, b, c, d, e) { for (var f, g = [], h = 0, i = a.length, j = null != b; h < i; h++)(f = a[h]) && (c && !c(f, d, e) || (g.push(f), j && b.push(h))); return g } function xa(a, b, c, d, e, f) { return d && !d[u] && (d = xa(d)), e && !e[u] && (e = xa(e, f)), ia(function (f, g, h, i) { var j, k, l, m = [], n = [], o = g.length, p = f || va(b || "*", h.nodeType ? [h] : h, []), q = !a || !f && b ? p : wa(p, m, a, h, i), r = c ? e || (f ? a : o || d) ? [] : g : q; if (c && c(q, r, h, i), d) { j = wa(r, n), d(j, [], h, i), k = j.length; while (k--) (l = j[k]) && (r[n[k]] = !(q[n[k]] = l)) } if (f) { if (e || a) { if (e) { j = [], k = r.length; while (k--) (l = r[k]) && j.push(q[k] = l); e(null, r = [], j, i) } k = r.length; while (k--) (l = r[k]) && (j = e ? I(f, l) : m[k]) > -1 && (f[j] = !(g[j] = l)) } } else r = wa(r === g ? r.splice(o, r.length) : r), e ? e(null, g, r, i) : G.apply(g, r) }) } function ya(a) { for (var b, c, e, f = a.length, g = d.relative[a[0].type], h = g || d.relative[" "], i = g ? 1 : 0, k = ta(function (a) { return a === b }, h, !0), l = ta(function (a) { return I(b, a) > -1 }, h, !0), m = [function (a, c, d) { var e = !g && (d || c !== j) || ((b = c).nodeType ? k(a, c, d) : l(a, c, d)); return b = null, e }]; i < f; i++)if (c = d.relative[a[i].type]) m = [ta(ua(m), c)]; else { if (c = d.filter[a[i].type].apply(null, a[i].matches), c[u]) { for (e = ++i; e < f; e++)if (d.relative[a[e].type]) break; return xa(i > 1 && ua(m), i > 1 && sa(a.slice(0, i - 1).concat({ value: " " === a[i - 2].type ? "*" : "" })).replace(P, "$1"), c, i < e && ya(a.slice(i, e)), e < f && ya(a = a.slice(e)), e < f && sa(a)) } m.push(c) } return ua(m) } function za(a, b) { var c = b.length > 0, e = a.length > 0, f = function (f, g, h, i, k) { var l, o, q, r = 0, s = "0", t = f && [], u = [], v = j, x = f || e && d.find.TAG("*", k), y = w += null == v ? 1 : Math.random() || .1, z = x.length; for (k && (j = g === n || g || k); s !== z && null != (l = x[s]); s++) { if (e && l) { o = 0, g || l.ownerDocument === n || (m(l), h = !p); while (q = a[o++]) if (q(l, g || n, h)) { i.push(l); break } k && (w = y) } c && ((l = !q && l) && r-- , f && t.push(l)) } if (r += s, c && s !== r) { o = 0; while (q = b[o++]) q(t, u, g, h); if (f) { if (r > 0) while (s--) t[s] || u[s] || (u[s] = E.call(i)); u = wa(u) } G.apply(i, u), k && !f && u.length > 0 && r + b.length > 1 && ga.uniqueSort(i) } return k && (w = y, j = v), t }; return c ? ia(f) : f } return h = ga.compile = function (a, b) { var c, d = [], e = [], f = A[a + " "]; if (!f) { b || (b = g(a)), c = b.length; while (c--) f = ya(b[c]), f[u] ? d.push(f) : e.push(f); f = A(a, za(e, d)), f.selector = a } return f }, i = ga.select = function (a, b, e, f) { var i, j, k, l, m, n = "function" == typeof a && a, o = !f && g(a = n.selector || a); if (e = e || [], 1 === o.length) { if (j = o[0] = o[0].slice(0), j.length > 2 && "ID" === (k = j[0]).type && c.getById && 9 === b.nodeType && p && d.relative[j[1].type]) { if (b = (d.find.ID(k.matches[0].replace(_, aa), b) || [])[0], !b) return e; n && (b = b.parentNode), a = a.slice(j.shift().value.length) } i = V.needsContext.test(a) ? 0 : j.length; while (i--) { if (k = j[i], d.relative[l = k.type]) break; if ((m = d.find[l]) && (f = m(k.matches[0].replace(_, aa), $.test(j[0].type) && qa(b.parentNode) || b))) { if (j.splice(i, 1), a = f.length && sa(j), !a) return G.apply(e, f), e; break } } } return (n || h(a, o))(f, b, !p, e, !b || $.test(a) && qa(b.parentNode) || b), e }, c.sortStable = u.split("").sort(B).join("") === u, c.detectDuplicates = !!l, m(), c.sortDetached = ja(function (a) { return 1 & a.compareDocumentPosition(n.createElement("fieldset")) }), ja(function (a) { return a.innerHTML = "<a href='#'></a>", "#" === a.firstChild.getAttribute("href") }) || ka("type|href|height|width", function (a, b, c) { if (!c) return a.getAttribute(b, "type" === b.toLowerCase() ? 1 : 2) }), c.attributes && ja(function (a) { return a.innerHTML = "<input/>", a.firstChild.setAttribute("value", ""), "" === a.firstChild.getAttribute("value") }) || ka("value", function (a, b, c) { if (!c && "input" === a.nodeName.toLowerCase()) return a.defaultValue }), ja(function (a) { return null == a.getAttribute("disabled") }) || ka(J, function (a, b, c) { var d; if (!c) return a[b] === !0 ? b.toLowerCase() : (d = a.getAttributeNode(b)) && d.specified ? d.value : null }), ga }(a); r.find = x, r.expr = x.selectors, r.expr[":"] = r.expr.pseudos, r.uniqueSort = r.unique = x.uniqueSort, r.text = x.getText, r.isXMLDoc = x.isXML, r.contains = x.contains, r.escapeSelector = x.escape; var y = function (a, b, c) { var d = [], e = void 0 !== c; while ((a = a[b]) && 9 !== a.nodeType) if (1 === a.nodeType) { if (e && r(a).is(c)) break; d.push(a) } return d }, z = function (a, b) { for (var c = []; a; a = a.nextSibling)1 === a.nodeType && a !== b && c.push(a); return c }, A = r.expr.match.needsContext, B = /^<([a-z][^\/\0>:\x20\t\r\n\f]*)[\x20\t\r\n\f]*\/?>(?:<\/\1>|)$/i, C = /^.[^:#\[\.,]*$/; function D(a, b, c) { if (r.isFunction(b)) return r.grep(a, function (a, d) { return !!b.call(a, d, a) !== c }); if (b.nodeType) return r.grep(a, function (a) { return a === b !== c }); if ("string" == typeof b) { if (C.test(b)) return r.filter(b, a, c); b = r.filter(b, a) } return r.grep(a, function (a) { return i.call(b, a) > -1 !== c && 1 === a.nodeType }) } r.filter = function (a, b, c) { var d = b[0]; return c && (a = ":not(" + a + ")"), 1 === b.length && 1 === d.nodeType ? r.find.matchesSelector(d, a) ? [d] : [] : r.find.matches(a, r.grep(b, function (a) { return 1 === a.nodeType })) }, r.fn.extend({ find: function (a) { var b, c, d = this.length, e = this; if ("string" != typeof a) return this.pushStack(r(a).filter(function () { for (b = 0; b < d; b++)if (r.contains(e[b], this)) return !0 })); for (c = this.pushStack([]), b = 0; b < d; b++)r.find(a, e[b], c); return d > 1 ? r.uniqueSort(c) : c }, filter: function (a) { return this.pushStack(D(this, a || [], !1)) }, not: function (a) { return this.pushStack(D(this, a || [], !0)) }, is: function (a) { return !!D(this, "string" == typeof a && A.test(a) ? r(a) : a || [], !1).length } }); var E, F = /^(?:\s*(<[\w\W]+>)[^>]*|#([\w-]+))$/, G = r.fn.init = function (a, b, c) { var e, f; if (!a) return this; if (c = c || E, "string" == typeof a) { if (e = "<" === a[0] && ">" === a[a.length - 1] && a.length >= 3 ? [null, a, null] : F.exec(a), !e || !e[1] && b) return !b || b.jquery ? (b || c).find(a) : this.constructor(b).find(a); if (e[1]) { if (b = b instanceof r ? b[0] : b, r.merge(this, r.parseHTML(e[1], b && b.nodeType ? b.ownerDocument || b : d, !0)), B.test(e[1]) && r.isPlainObject(b)) for (e in b) r.isFunction(this[e]) ? this[e](b[e]) : this.attr(e, b[e]); return this } return f = d.getElementById(e[2]), f && (this[0] = f, this.length = 1), this } return a.nodeType ? (this[0] = a, this.length = 1, this) : r.isFunction(a) ? void 0 !== c.ready ? c.ready(a) : a(r) : r.makeArray(a, this) }; G.prototype = r.fn, E = r(d); var H = /^(?:parents|prev(?:Until|All))/, I = { children: !0, contents: !0, next: !0, prev: !0 }; r.fn.extend({ has: function (a) { var b = r(a, this), c = b.length; return this.filter(function () { for (var a = 0; a < c; a++)if (r.contains(this, b[a])) return !0 }) }, closest: function (a, b) { var c, d = 0, e = this.length, f = [], g = "string" != typeof a && r(a); if (!A.test(a)) for (; d < e; d++)for (c = this[d]; c && c !== b; c = c.parentNode)if (c.nodeType < 11 && (g ? g.index(c) > -1 : 1 === c.nodeType && r.find.matchesSelector(c, a))) { f.push(c); break } return this.pushStack(f.length > 1 ? r.uniqueSort(f) : f) }, index: function (a) { return a ? "string" == typeof a ? i.call(r(a), this[0]) : i.call(this, a.jquery ? a[0] : a) : this[0] && this[0].parentNode ? this.first().prevAll().length : -1 }, add: function (a, b) { return this.pushStack(r.uniqueSort(r.merge(this.get(), r(a, b)))) }, addBack: function (a) { return this.add(null == a ? this.prevObject : this.prevObject.filter(a)) } }); function J(a, b) { while ((a = a[b]) && 1 !== a.nodeType); return a } r.each({ parent: function (a) { var b = a.parentNode; return b && 11 !== b.nodeType ? b : null }, parents: function (a) { return y(a, "parentNode") }, parentsUntil: function (a, b, c) { return y(a, "parentNode", c) }, next: function (a) { return J(a, "nextSibling") }, prev: function (a) { return J(a, "previousSibling") }, nextAll: function (a) { return y(a, "nextSibling") }, prevAll: function (a) { return y(a, "previousSibling") }, nextUntil: function (a, b, c) { return y(a, "nextSibling", c) }, prevUntil: function (a, b, c) { return y(a, "previousSibling", c) }, siblings: function (a) { return z((a.parentNode || {}).firstChild, a) }, children: function (a) { return z(a.firstChild) }, contents: function (a) { return a.contentDocument || r.merge([], a.childNodes) } }, function (a, b) { r.fn[a] = function (c, d) { var e = r.map(this, b, c); return "Until" !== a.slice(-5) && (d = c), d && "string" == typeof d && (e = r.filter(d, e)), this.length > 1 && (I[a] || r.uniqueSort(e), H.test(a) && e.reverse()), this.pushStack(e) } }); var K = /\S+/g; function L(a) { var b = {}; return r.each(a.match(K) || [], function (a, c) { b[c] = !0 }), b } r.Callbacks = function (a) { a = "string" == typeof a ? L(a) : r.extend({}, a); var b, c, d, e, f = [], g = [], h = -1, i = function () { for (e = a.once, d = b = !0; g.length; h = -1) { c = g.shift(); while (++h < f.length) f[h].apply(c[0], c[1]) === !1 && a.stopOnFalse && (h = f.length, c = !1) } a.memory || (c = !1), b = !1, e && (f = c ? [] : "") }, j = { add: function () { return f && (c && !b && (h = f.length - 1, g.push(c)), function d(b) { r.each(b, function (b, c) { r.isFunction(c) ? a.unique && j.has(c) || f.push(c) : c && c.length && "string" !== r.type(c) && d(c) }) }(arguments), c && !b && i()), this }, remove: function () { return r.each(arguments, function (a, b) { var c; while ((c = r.inArray(b, f, c)) > -1) f.splice(c, 1), c <= h && h-- }), this }, has: function (a) { return a ? r.inArray(a, f) > -1 : f.length > 0 }, empty: function () { return f && (f = []), this }, disable: function () { return e = g = [], f = c = "", this }, disabled: function () { return !f }, lock: function () { return e = g = [], c || b || (f = c = ""), this }, locked: function () { return !!e }, fireWith: function (a, c) { return e || (c = c || [], c = [a, c.slice ? c.slice() : c], g.push(c), b || i()), this }, fire: function () { return j.fireWith(this, arguments), this }, fired: function () { return !!d } }; return j }; function M(a) { return a } function N(a) { throw a } function O(a, b, c) { var d; try { a && r.isFunction(d = a.promise) ? d.call(a).done(b).fail(c) : a && r.isFunction(d = a.then) ? d.call(a, b, c) : b.call(void 0, a) } catch (a) { c.call(void 0, a) } } r.extend({ Deferred: function (b) { var c = [["notify", "progress", r.Callbacks("memory"), r.Callbacks("memory"), 2], ["resolve", "done", r.Callbacks("once memory"), r.Callbacks("once memory"), 0, "resolved"], ["reject", "fail", r.Callbacks("once memory"), r.Callbacks("once memory"), 1, "rejected"]], d = "pending", e = { state: function () { return d }, always: function () { return f.done(arguments).fail(arguments), this }, "catch": function (a) { return e.then(null, a) }, pipe: function () { var a = arguments; return r.Deferred(function (b) { r.each(c, function (c, d) { var e = r.isFunction(a[d[4]]) && a[d[4]]; f[d[1]](function () { var a = e && e.apply(this, arguments); a && r.isFunction(a.promise) ? a.promise().progress(b.notify).done(b.resolve).fail(b.reject) : b[d[0] + "With"](this, e ? [a] : arguments) }) }), a = null }).promise() }, then: function (b, d, e) { var f = 0; function g(b, c, d, e) { return function () { var h = this, i = arguments, j = function () { var a, j; if (!(b < f)) { if (a = d.apply(h, i), a === c.promise()) throw new TypeError("Thenable self-resolution"); j = a && ("object" == typeof a || "function" == typeof a) && a.then, r.isFunction(j) ? e ? j.call(a, g(f, c, M, e), g(f, c, N, e)) : (f++ , j.call(a, g(f, c, M, e), g(f, c, N, e), g(f, c, M, c.notifyWith))) : (d !== M && (h = void 0, i = [a]), (e || c.resolveWith)(h, i)) } }, k = e ? j : function () { try { j() } catch (a) { r.Deferred.exceptionHook && r.Deferred.exceptionHook(a, k.stackTrace), b + 1 >= f && (d !== N && (h = void 0, i = [a]), c.rejectWith(h, i)) } }; b ? k() : (r.Deferred.getStackHook && (k.stackTrace = r.Deferred.getStackHook()), a.setTimeout(k)) } } return r.Deferred(function (a) { c[0][3].add(g(0, a, r.isFunction(e) ? e : M, a.notifyWith)), c[1][3].add(g(0, a, r.isFunction(b) ? b : M)), c[2][3].add(g(0, a, r.isFunction(d) ? d : N)) }).promise() }, promise: function (a) { return null != a ? r.extend(a, e) : e } }, f = {}; return r.each(c, function (a, b) { var g = b[2], h = b[5]; e[b[1]] = g.add, h && g.add(function () { d = h }, c[3 - a][2].disable, c[0][2].lock), g.add(b[3].fire), f[b[0]] = function () { return f[b[0] + "With"](this === f ? void 0 : this, arguments), this }, f[b[0] + "With"] = g.fireWith }), e.promise(f), b && b.call(f, f), f }, when: function (a) { var b = arguments.length, c = b, d = Array(c), e = f.call(arguments), g = r.Deferred(), h = function (a) { return function (c) { d[a] = this, e[a] = arguments.length > 1 ? f.call(arguments) : c, --b || g.resolveWith(d, e) } }; if (b <= 1 && (O(a, g.done(h(c)).resolve, g.reject), "pending" === g.state() || r.isFunction(e[c] && e[c].then))) return g.then(); while (c--) O(e[c], h(c), g.reject); return g.promise() } }); var P = /^(Eval|Internal|Range|Reference|Syntax|Type|URI)Error$/; r.Deferred.exceptionHook = function (b, c) { a.console && a.console.warn && b && P.test(b.name) && a.console.warn("jQuery.Deferred exception: " + b.message, b.stack, c) }, r.readyException = function (b) { a.setTimeout(function () { throw b }) }; var Q = r.Deferred(); r.fn.ready = function (a) { return Q.then(a)["catch"](function (a) { r.readyException(a) }), this }, r.extend({ isReady: !1, readyWait: 1, holdReady: function (a) { a ? r.readyWait++ : r.ready(!0) }, ready: function (a) { (a === !0 ? --r.readyWait : r.isReady) || (r.isReady = !0, a !== !0 && --r.readyWait > 0 || Q.resolveWith(d, [r])) } }), r.ready.then = Q.then; function R() { d.removeEventListener("DOMContentLoaded", R), a.removeEventListener("load", R), r.ready() } "complete" === d.readyState || "loading" !== d.readyState && !d.documentElement.doScroll ? a.setTimeout(r.ready) : (d.addEventListener("DOMContentLoaded", R), a.addEventListener("load", R)); var S = function (a, b, c, d, e, f, g) {
        var h = 0, i = a.length, j = null == c; if ("object" === r.type(c)) { e = !0; for (h in c) S(a, b, h, c[h], !0, f, g) } else if (void 0 !== d && (e = !0,
            r.isFunction(d) || (g = !0), j && (g ? (b.call(a, d), b = null) : (j = b, b = function (a, b, c) { return j.call(r(a), c) })), b)) for (; h < i; h++)b(a[h], c, g ? d : d.call(a[h], h, b(a[h], c))); return e ? a : j ? b.call(a) : i ? b(a[0], c) : f
    }, T = function (a) { return 1 === a.nodeType || 9 === a.nodeType || !+a.nodeType }; function U() { this.expando = r.expando + U.uid++ } U.uid = 1, U.prototype = { cache: function (a) { var b = a[this.expando]; return b || (b = {}, T(a) && (a.nodeType ? a[this.expando] = b : Object.defineProperty(a, this.expando, { value: b, configurable: !0 }))), b }, set: function (a, b, c) { var d, e = this.cache(a); if ("string" == typeof b) e[r.camelCase(b)] = c; else for (d in b) e[r.camelCase(d)] = b[d]; return e }, get: function (a, b) { return void 0 === b ? this.cache(a) : a[this.expando] && a[this.expando][r.camelCase(b)] }, access: function (a, b, c) { return void 0 === b || b && "string" == typeof b && void 0 === c ? this.get(a, b) : (this.set(a, b, c), void 0 !== c ? c : b) }, remove: function (a, b) { var c, d = a[this.expando]; if (void 0 !== d) { if (void 0 !== b) { r.isArray(b) ? b = b.map(r.camelCase) : (b = r.camelCase(b), b = b in d ? [b] : b.match(K) || []), c = b.length; while (c--) delete d[b[c]] } (void 0 === b || r.isEmptyObject(d)) && (a.nodeType ? a[this.expando] = void 0 : delete a[this.expando]) } }, hasData: function (a) { var b = a[this.expando]; return void 0 !== b && !r.isEmptyObject(b) } }; var V = new U, W = new U, X = /^(?:\{[\w\W]*\}|\[[\w\W]*\])$/, Y = /[A-Z]/g; function Z(a, b, c) { var d; if (void 0 === c && 1 === a.nodeType) if (d = "data-" + b.replace(Y, "-$&").toLowerCase(), c = a.getAttribute(d), "string" == typeof c) { try { c = "true" === c || "false" !== c && ("null" === c ? null : +c + "" === c ? +c : X.test(c) ? JSON.parse(c) : c) } catch (e) { } W.set(a, b, c) } else c = void 0; return c } r.extend({ hasData: function (a) { return W.hasData(a) || V.hasData(a) }, data: function (a, b, c) { return W.access(a, b, c) }, removeData: function (a, b) { W.remove(a, b) }, _data: function (a, b, c) { return V.access(a, b, c) }, _removeData: function (a, b) { V.remove(a, b) } }), r.fn.extend({ data: function (a, b) { var c, d, e, f = this[0], g = f && f.attributes; if (void 0 === a) { if (this.length && (e = W.get(f), 1 === f.nodeType && !V.get(f, "hasDataAttrs"))) { c = g.length; while (c--) g[c] && (d = g[c].name, 0 === d.indexOf("data-") && (d = r.camelCase(d.slice(5)), Z(f, d, e[d]))); V.set(f, "hasDataAttrs", !0) } return e } return "object" == typeof a ? this.each(function () { W.set(this, a) }) : S(this, function (b) { var c; if (f && void 0 === b) { if (c = W.get(f, a), void 0 !== c) return c; if (c = Z(f, a), void 0 !== c) return c } else this.each(function () { W.set(this, a, b) }) }, null, b, arguments.length > 1, null, !0) }, removeData: function (a) { return this.each(function () { W.remove(this, a) }) } }), r.extend({ queue: function (a, b, c) { var d; if (a) return b = (b || "fx") + "queue", d = V.get(a, b), c && (!d || r.isArray(c) ? d = V.access(a, b, r.makeArray(c)) : d.push(c)), d || [] }, dequeue: function (a, b) { b = b || "fx"; var c = r.queue(a, b), d = c.length, e = c.shift(), f = r._queueHooks(a, b), g = function () { r.dequeue(a, b) }; "inprogress" === e && (e = c.shift(), d--), e && ("fx" === b && c.unshift("inprogress"), delete f.stop, e.call(a, g, f)), !d && f && f.empty.fire() }, _queueHooks: function (a, b) { var c = b + "queueHooks"; return V.get(a, c) || V.access(a, c, { empty: r.Callbacks("once memory").add(function () { V.remove(a, [b + "queue", c]) }) }) } }), r.fn.extend({ queue: function (a, b) { var c = 2; return "string" != typeof a && (b = a, a = "fx", c--), arguments.length < c ? r.queue(this[0], a) : void 0 === b ? this : this.each(function () { var c = r.queue(this, a, b); r._queueHooks(this, a), "fx" === a && "inprogress" !== c[0] && r.dequeue(this, a) }) }, dequeue: function (a) { return this.each(function () { r.dequeue(this, a) }) }, clearQueue: function (a) { return this.queue(a || "fx", []) }, promise: function (a, b) { var c, d = 1, e = r.Deferred(), f = this, g = this.length, h = function () { --d || e.resolveWith(f, [f]) }; "string" != typeof a && (b = a, a = void 0), a = a || "fx"; while (g--) c = V.get(f[g], a + "queueHooks"), c && c.empty && (d++ , c.empty.add(h)); return h(), e.promise(b) } }); var $ = /[+-]?(?:\d*\.|)\d+(?:[eE][+-]?\d+|)/.source, _ = new RegExp("^(?:([+-])=|)(" + $ + ")([a-z%]*)$", "i"), aa = ["Top", "Right", "Bottom", "Left"], ba = function (a, b) { return a = b || a, "none" === a.style.display || "" === a.style.display && r.contains(a.ownerDocument, a) && "none" === r.css(a, "display") }, ca = function (a, b, c, d) { var e, f, g = {}; for (f in b) g[f] = a.style[f], a.style[f] = b[f]; e = c.apply(a, d || []); for (f in b) a.style[f] = g[f]; return e }; function da(a, b, c, d) { var e, f = 1, g = 20, h = d ? function () { return d.cur() } : function () { return r.css(a, b, "") }, i = h(), j = c && c[3] || (r.cssNumber[b] ? "" : "px"), k = (r.cssNumber[b] || "px" !== j && +i) && _.exec(r.css(a, b)); if (k && k[3] !== j) { j = j || k[3], c = c || [], k = +i || 1; do f = f || ".5", k /= f, r.style(a, b, k + j); while (f !== (f = h() / i) && 1 !== f && --g) } return c && (k = +k || +i || 0, e = c[1] ? k + (c[1] + 1) * c[2] : +c[2], d && (d.unit = j, d.start = k, d.end = e)), e } var ea = {}; function fa(a) { var b, c = a.ownerDocument, d = a.nodeName, e = ea[d]; return e ? e : (b = c.body.appendChild(c.createElement(d)), e = r.css(b, "display"), b.parentNode.removeChild(b), "none" === e && (e = "block"), ea[d] = e, e) } function ga(a, b) { for (var c, d, e = [], f = 0, g = a.length; f < g; f++)d = a[f], d.style && (c = d.style.display, b ? ("none" === c && (e[f] = V.get(d, "display") || null, e[f] || (d.style.display = "")), "" === d.style.display && ba(d) && (e[f] = fa(d))) : "none" !== c && (e[f] = "none", V.set(d, "display", c))); for (f = 0; f < g; f++)null != e[f] && (a[f].style.display = e[f]); return a } r.fn.extend({ show: function () { return ga(this, !0) }, hide: function () { return ga(this) }, toggle: function (a) { return "boolean" == typeof a ? a ? this.show() : this.hide() : this.each(function () { ba(this) ? r(this).show() : r(this).hide() }) } }); var ha = /^(?:checkbox|radio)$/i, ia = /<([a-z][^\/\0>\x20\t\r\n\f]+)/i, ja = /^$|\/(?:java|ecma)script/i, ka = { option: [1, "<select multiple='multiple'>", "</select>"], thead: [1, "<table>", "</table>"], col: [2, "<table><colgroup>", "</colgroup></table>"], tr: [2, "<table><tbody>", "</tbody></table>"], td: [3, "<table><tbody><tr>", "</tr></tbody></table>"], _default: [0, "", ""] }; ka.optgroup = ka.option, ka.tbody = ka.tfoot = ka.colgroup = ka.caption = ka.thead, ka.th = ka.td; function la(a, b) { var c = "undefined" != typeof a.getElementsByTagName ? a.getElementsByTagName(b || "*") : "undefined" != typeof a.querySelectorAll ? a.querySelectorAll(b || "*") : []; return void 0 === b || b && r.nodeName(a, b) ? r.merge([a], c) : c } function ma(a, b) { for (var c = 0, d = a.length; c < d; c++)V.set(a[c], "globalEval", !b || V.get(b[c], "globalEval")) } var na = /<|&#?\w+;/; function oa(a, b, c, d, e) { for (var f, g, h, i, j, k, l = b.createDocumentFragment(), m = [], n = 0, o = a.length; n < o; n++)if (f = a[n], f || 0 === f) if ("object" === r.type(f)) r.merge(m, f.nodeType ? [f] : f); else if (na.test(f)) { g = g || l.appendChild(b.createElement("div")), h = (ia.exec(f) || ["", ""])[1].toLowerCase(), i = ka[h] || ka._default, g.innerHTML = i[1] + r.htmlPrefilter(f) + i[2], k = i[0]; while (k--) g = g.lastChild; r.merge(m, g.childNodes), g = l.firstChild, g.textContent = "" } else m.push(b.createTextNode(f)); l.textContent = "", n = 0; while (f = m[n++]) if (d && r.inArray(f, d) > -1) e && e.push(f); else if (j = r.contains(f.ownerDocument, f), g = la(l.appendChild(f), "script"), j && ma(g), c) { k = 0; while (f = g[k++]) ja.test(f.type || "") && c.push(f) } return l } !function () { var a = d.createDocumentFragment(), b = a.appendChild(d.createElement("div")), c = d.createElement("input"); c.setAttribute("type", "radio"), c.setAttribute("checked", "checked"), c.setAttribute("name", "t"), b.appendChild(c), o.checkClone = b.cloneNode(!0).cloneNode(!0).lastChild.checked, b.innerHTML = "<textarea>x</textarea>", o.noCloneChecked = !!b.cloneNode(!0).lastChild.defaultValue }(); var pa = d.documentElement, qa = /^key/, ra = /^(?:mouse|pointer|contextmenu|drag|drop)|click/, sa = /^([^.]*)(?:\.(.+)|)/; function ta() { return !0 } function ua() { return !1 } function va() { try { return d.activeElement } catch (a) { } } function wa(a, b, c, d, e, f) { var g, h; if ("object" == typeof b) { "string" != typeof c && (d = d || c, c = void 0); for (h in b) wa(a, h, c, d, b[h], f); return a } if (null == d && null == e ? (e = c, d = c = void 0) : null == e && ("string" == typeof c ? (e = d, d = void 0) : (e = d, d = c, c = void 0)), e === !1) e = ua; else if (!e) return a; return 1 === f && (g = e, e = function (a) { return r().off(a), g.apply(this, arguments) }, e.guid = g.guid || (g.guid = r.guid++)), a.each(function () { r.event.add(this, b, e, d, c) }) } r.event = { global: {}, add: function (a, b, c, d, e) { var f, g, h, i, j, k, l, m, n, o, p, q = V.get(a); if (q) { c.handler && (f = c, c = f.handler, e = f.selector), e && r.find.matchesSelector(pa, e), c.guid || (c.guid = r.guid++), (i = q.events) || (i = q.events = {}), (g = q.handle) || (g = q.handle = function (b) { return "undefined" != typeof r && r.event.triggered !== b.type ? r.event.dispatch.apply(a, arguments) : void 0 }), b = (b || "").match(K) || [""], j = b.length; while (j--) h = sa.exec(b[j]) || [], n = p = h[1], o = (h[2] || "").split(".").sort(), n && (l = r.event.special[n] || {}, n = (e ? l.delegateType : l.bindType) || n, l = r.event.special[n] || {}, k = r.extend({ type: n, origType: p, data: d, handler: c, guid: c.guid, selector: e, needsContext: e && r.expr.match.needsContext.test(e), namespace: o.join(".") }, f), (m = i[n]) || (m = i[n] = [], m.delegateCount = 0, l.setup && l.setup.call(a, d, o, g) !== !1 || a.addEventListener && a.addEventListener(n, g)), l.add && (l.add.call(a, k), k.handler.guid || (k.handler.guid = c.guid)), e ? m.splice(m.delegateCount++, 0, k) : m.push(k), r.event.global[n] = !0) } }, remove: function (a, b, c, d, e) { var f, g, h, i, j, k, l, m, n, o, p, q = V.hasData(a) && V.get(a); if (q && (i = q.events)) { b = (b || "").match(K) || [""], j = b.length; while (j--) if (h = sa.exec(b[j]) || [], n = p = h[1], o = (h[2] || "").split(".").sort(), n) { l = r.event.special[n] || {}, n = (d ? l.delegateType : l.bindType) || n, m = i[n] || [], h = h[2] && new RegExp("(^|\\.)" + o.join("\\.(?:.*\\.|)") + "(\\.|$)"), g = f = m.length; while (f--) k = m[f], !e && p !== k.origType || c && c.guid !== k.guid || h && !h.test(k.namespace) || d && d !== k.selector && ("**" !== d || !k.selector) || (m.splice(f, 1), k.selector && m.delegateCount-- , l.remove && l.remove.call(a, k)); g && !m.length && (l.teardown && l.teardown.call(a, o, q.handle) !== !1 || r.removeEvent(a, n, q.handle), delete i[n]) } else for (n in i) r.event.remove(a, n + b[j], c, d, !0); r.isEmptyObject(i) && V.remove(a, "handle events") } }, dispatch: function (a) { var b = r.event.fix(a), c, d, e, f, g, h, i = new Array(arguments.length), j = (V.get(this, "events") || {})[b.type] || [], k = r.event.special[b.type] || {}; for (i[0] = b, c = 1; c < arguments.length; c++)i[c] = arguments[c]; if (b.delegateTarget = this, !k.preDispatch || k.preDispatch.call(this, b) !== !1) { h = r.event.handlers.call(this, b, j), c = 0; while ((f = h[c++]) && !b.isPropagationStopped()) { b.currentTarget = f.elem, d = 0; while ((g = f.handlers[d++]) && !b.isImmediatePropagationStopped()) b.rnamespace && !b.rnamespace.test(g.namespace) || (b.handleObj = g, b.data = g.data, e = ((r.event.special[g.origType] || {}).handle || g.handler).apply(f.elem, i), void 0 !== e && (b.result = e) === !1 && (b.preventDefault(), b.stopPropagation())) } return k.postDispatch && k.postDispatch.call(this, b), b.result } }, handlers: function (a, b) { var c, d, e, f, g = [], h = b.delegateCount, i = a.target; if (h && i.nodeType && ("click" !== a.type || isNaN(a.button) || a.button < 1)) for (; i !== this; i = i.parentNode || this)if (1 === i.nodeType && (i.disabled !== !0 || "click" !== a.type)) { for (d = [], c = 0; c < h; c++)f = b[c], e = f.selector + " ", void 0 === d[e] && (d[e] = f.needsContext ? r(e, this).index(i) > -1 : r.find(e, this, null, [i]).length), d[e] && d.push(f); d.length && g.push({ elem: i, handlers: d }) } return h < b.length && g.push({ elem: this, handlers: b.slice(h) }), g }, addProp: function (a, b) { Object.defineProperty(r.Event.prototype, a, { enumerable: !0, configurable: !0, get: r.isFunction(b) ? function () { if (this.originalEvent) return b(this.originalEvent) } : function () { if (this.originalEvent) return this.originalEvent[a] }, set: function (b) { Object.defineProperty(this, a, { enumerable: !0, configurable: !0, writable: !0, value: b }) } }) }, fix: function (a) { return a[r.expando] ? a : new r.Event(a) }, special: { load: { noBubble: !0 }, focus: { trigger: function () { if (this !== va() && this.focus) return this.focus(), !1 }, delegateType: "focusin" }, blur: { trigger: function () { if (this === va() && this.blur) return this.blur(), !1 }, delegateType: "focusout" }, click: { trigger: function () { if ("checkbox" === this.type && this.click && r.nodeName(this, "input")) return this.click(), !1 }, _default: function (a) { return r.nodeName(a.target, "a") } }, beforeunload: { postDispatch: function (a) { void 0 !== a.result && a.originalEvent && (a.originalEvent.returnValue = a.result) } } } }, r.removeEvent = function (a, b, c) { a.removeEventListener && a.removeEventListener(b, c) }, r.Event = function (a, b) { return this instanceof r.Event ? (a && a.type ? (this.originalEvent = a, this.type = a.type, this.isDefaultPrevented = a.defaultPrevented || void 0 === a.defaultPrevented && a.returnValue === !1 ? ta : ua, this.target = a.target && 3 === a.target.nodeType ? a.target.parentNode : a.target, this.currentTarget = a.currentTarget, this.relatedTarget = a.relatedTarget) : this.type = a, b && r.extend(this, b), this.timeStamp = a && a.timeStamp || r.now(), void (this[r.expando] = !0)) : new r.Event(a, b) }, r.Event.prototype = { constructor: r.Event, isDefaultPrevented: ua, isPropagationStopped: ua, isImmediatePropagationStopped: ua, isSimulated: !1, preventDefault: function () { var a = this.originalEvent; this.isDefaultPrevented = ta, a && !this.isSimulated && a.preventDefault() }, stopPropagation: function () { var a = this.originalEvent; this.isPropagationStopped = ta, a && !this.isSimulated && a.stopPropagation() }, stopImmediatePropagation: function () { var a = this.originalEvent; this.isImmediatePropagationStopped = ta, a && !this.isSimulated && a.stopImmediatePropagation(), this.stopPropagation() } }, r.each({ altKey: !0, bubbles: !0, cancelable: !0, changedTouches: !0, ctrlKey: !0, detail: !0, eventPhase: !0, metaKey: !0, pageX: !0, pageY: !0, shiftKey: !0, view: !0, "char": !0, charCode: !0, key: !0, keyCode: !0, button: !0, buttons: !0, clientX: !0, clientY: !0, offsetX: !0, offsetY: !0, pointerId: !0, pointerType: !0, screenX: !0, screenY: !0, targetTouches: !0, toElement: !0, touches: !0, which: function (a) { var b = a.button; return null == a.which && qa.test(a.type) ? null != a.charCode ? a.charCode : a.keyCode : !a.which && void 0 !== b && ra.test(a.type) ? 1 & b ? 1 : 2 & b ? 3 : 4 & b ? 2 : 0 : a.which } }, r.event.addProp), r.each({ mouseenter: "mouseover", mouseleave: "mouseout", pointerenter: "pointerover", pointerleave: "pointerout" }, function (a, b) { r.event.special[a] = { delegateType: b, bindType: b, handle: function (a) { var c, d = this, e = a.relatedTarget, f = a.handleObj; return e && (e === d || r.contains(d, e)) || (a.type = f.origType, c = f.handler.apply(this, arguments), a.type = b), c } } }), r.fn.extend({ on: function (a, b, c, d) { return wa(this, a, b, c, d) }, one: function (a, b, c, d) { return wa(this, a, b, c, d, 1) }, off: function (a, b, c) { var d, e; if (a && a.preventDefault && a.handleObj) return d = a.handleObj, r(a.delegateTarget).off(d.namespace ? d.origType + "." + d.namespace : d.origType, d.selector, d.handler), this; if ("object" == typeof a) { for (e in a) this.off(e, b, a[e]); return this } return b !== !1 && "function" != typeof b || (c = b, b = void 0), c === !1 && (c = ua), this.each(function () { r.event.remove(this, a, c, b) }) } }); var xa = /<(?!area|br|col|embed|hr|img|input|link|meta|param)(([a-z][^\/\0>\x20\t\r\n\f]*)[^>]*)\/>/gi, ya = /<script|<style|<link/i, za = /checked\s*(?:[^=]|=\s*.checked.)/i, Aa = /^true\/(.*)/, Ba = /^\s*<!(?:\[CDATA\[|--)|(?:\]\]|--)>\s*$/g; function Ca(a, b) { return r.nodeName(a, "table") && r.nodeName(11 !== b.nodeType ? b : b.firstChild, "tr") ? a.getElementsByTagName("tbody")[0] || a : a } function Da(a) { return a.type = (null !== a.getAttribute("type")) + "/" + a.type, a } function Ea(a) { var b = Aa.exec(a.type); return b ? a.type = b[1] : a.removeAttribute("type"), a } function Fa(a, b) { var c, d, e, f, g, h, i, j; if (1 === b.nodeType) { if (V.hasData(a) && (f = V.access(a), g = V.set(b, f), j = f.events)) { delete g.handle, g.events = {}; for (e in j) for (c = 0, d = j[e].length; c < d; c++)r.event.add(b, e, j[e][c]) } W.hasData(a) && (h = W.access(a), i = r.extend({}, h), W.set(b, i)) } } function Ga(a, b) { var c = b.nodeName.toLowerCase(); "input" === c && ha.test(a.type) ? b.checked = a.checked : "input" !== c && "textarea" !== c || (b.defaultValue = a.defaultValue) } function Ha(a, b, c, d) { b = g.apply([], b); var e, f, h, i, j, k, l = 0, m = a.length, n = m - 1, q = b[0], s = r.isFunction(q); if (s || m > 1 && "string" == typeof q && !o.checkClone && za.test(q)) return a.each(function (e) { var f = a.eq(e); s && (b[0] = q.call(this, e, f.html())), Ha(f, b, c, d) }); if (m && (e = oa(b, a[0].ownerDocument, !1, a, d), f = e.firstChild, 1 === e.childNodes.length && (e = f), f || d)) { for (h = r.map(la(e, "script"), Da), i = h.length; l < m; l++)j = e, l !== n && (j = r.clone(j, !0, !0), i && r.merge(h, la(j, "script"))), c.call(a[l], j, l); if (i) for (k = h[h.length - 1].ownerDocument, r.map(h, Ea), l = 0; l < i; l++)j = h[l], ja.test(j.type || "") && !V.access(j, "globalEval") && r.contains(k, j) && (j.src ? r._evalUrl && r._evalUrl(j.src) : p(j.textContent.replace(Ba, ""), k)) } return a } function Ia(a, b, c) { for (var d, e = b ? r.filter(b, a) : a, f = 0; null != (d = e[f]); f++)c || 1 !== d.nodeType || r.cleanData(la(d)), d.parentNode && (c && r.contains(d.ownerDocument, d) && ma(la(d, "script")), d.parentNode.removeChild(d)); return a } r.extend({ htmlPrefilter: function (a) { return a.replace(xa, "<$1></$2>") }, clone: function (a, b, c) { var d, e, f, g, h = a.cloneNode(!0), i = r.contains(a.ownerDocument, a); if (!(o.noCloneChecked || 1 !== a.nodeType && 11 !== a.nodeType || r.isXMLDoc(a))) for (g = la(h), f = la(a), d = 0, e = f.length; d < e; d++)Ga(f[d], g[d]); if (b) if (c) for (f = f || la(a), g = g || la(h), d = 0, e = f.length; d < e; d++)Fa(f[d], g[d]); else Fa(a, h); return g = la(h, "script"), g.length > 0 && ma(g, !i && la(a, "script")), h }, cleanData: function (a) { for (var b, c, d, e = r.event.special, f = 0; void 0 !== (c = a[f]); f++)if (T(c)) { if (b = c[V.expando]) { if (b.events) for (d in b.events) e[d] ? r.event.remove(c, d) : r.removeEvent(c, d, b.handle); c[V.expando] = void 0 } c[W.expando] && (c[W.expando] = void 0) } } }), r.fn.extend({ detach: function (a) { return Ia(this, a, !0) }, remove: function (a) { return Ia(this, a) }, text: function (a) { return S(this, function (a) { return void 0 === a ? r.text(this) : this.empty().each(function () { 1 !== this.nodeType && 11 !== this.nodeType && 9 !== this.nodeType || (this.textContent = a) }) }, null, a, arguments.length) }, append: function () { return Ha(this, arguments, function (a) { if (1 === this.nodeType || 11 === this.nodeType || 9 === this.nodeType) { var b = Ca(this, a); b.appendChild(a) } }) }, prepend: function () { return Ha(this, arguments, function (a) { if (1 === this.nodeType || 11 === this.nodeType || 9 === this.nodeType) { var b = Ca(this, a); b.insertBefore(a, b.firstChild) } }) }, before: function () { return Ha(this, arguments, function (a) { this.parentNode && this.parentNode.insertBefore(a, this) }) }, after: function () { return Ha(this, arguments, function (a) { this.parentNode && this.parentNode.insertBefore(a, this.nextSibling) }) }, empty: function () { for (var a, b = 0; null != (a = this[b]); b++)1 === a.nodeType && (r.cleanData(la(a, !1)), a.textContent = ""); return this }, clone: function (a, b) { return a = null != a && a, b = null == b ? a : b, this.map(function () { return r.clone(this, a, b) }) }, html: function (a) { return S(this, function (a) { var b = this[0] || {}, c = 0, d = this.length; if (void 0 === a && 1 === b.nodeType) return b.innerHTML; if ("string" == typeof a && !ya.test(a) && !ka[(ia.exec(a) || ["", ""])[1].toLowerCase()]) { a = r.htmlPrefilter(a); try { for (; c < d; c++)b = this[c] || {}, 1 === b.nodeType && (r.cleanData(la(b, !1)), b.innerHTML = a); b = 0 } catch (e) { } } b && this.empty().append(a) }, null, a, arguments.length) }, replaceWith: function () { var a = []; return Ha(this, arguments, function (b) { var c = this.parentNode; r.inArray(this, a) < 0 && (r.cleanData(la(this)), c && c.replaceChild(b, this)) }, a) } }), r.each({ appendTo: "append", prependTo: "prepend", insertBefore: "before", insertAfter: "after", replaceAll: "replaceWith" }, function (a, b) { r.fn[a] = function (a) { for (var c, d = [], e = r(a), f = e.length - 1, g = 0; g <= f; g++)c = g === f ? this : this.clone(!0), r(e[g])[b](c), h.apply(d, c.get()); return this.pushStack(d) } }); var Ja = /^margin/, Ka = new RegExp("^(" + $ + ")(?!px)[a-z%]+$", "i"), La = function (b) { var c = b.ownerDocument.defaultView; return c && c.opener || (c = a), c.getComputedStyle(b) }; !function () { function b() { if (i) { i.style.cssText = "box-sizing:border-box;position:relative;display:block;margin:auto;border:1px;padding:1px;top:1%;width:50%", i.innerHTML = "", pa.appendChild(h); var b = a.getComputedStyle(i); c = "1%" !== b.top, g = "2px" === b.marginLeft, e = "4px" === b.width, i.style.marginRight = "50%", f = "4px" === b.marginRight, pa.removeChild(h), i = null } } var c, e, f, g, h = d.createElement("div"), i = d.createElement("div"); i.style && (i.style.backgroundClip = "content-box", i.cloneNode(!0).style.backgroundClip = "", o.clearCloneStyle = "content-box" === i.style.backgroundClip, h.style.cssText = "border:0;width:8px;height:0;top:0;left:-9999px;padding:0;margin-top:1px;position:absolute", h.appendChild(i), r.extend(o, { pixelPosition: function () { return b(), c }, boxSizingReliable: function () { return b(), e }, pixelMarginRight: function () { return b(), f }, reliableMarginLeft: function () { return b(), g } })) }(); function Ma(a, b, c) { var d, e, f, g, h = a.style; return c = c || La(a), c && (g = c.getPropertyValue(b) || c[b], "" !== g || r.contains(a.ownerDocument, a) || (g = r.style(a, b)), !o.pixelMarginRight() && Ka.test(g) && Ja.test(b) && (d = h.width, e = h.minWidth, f = h.maxWidth, h.minWidth = h.maxWidth = h.width = g, g = c.width, h.width = d, h.minWidth = e, h.maxWidth = f)), void 0 !== g ? g + "" : g } function Na(a, b) { return { get: function () { return a() ? void delete this.get : (this.get = b).apply(this, arguments) } } } var Oa = /^(none|table(?!-c[ea]).+)/, Pa = { position: "absolute", visibility: "hidden", display: "block" }, Qa = { letterSpacing: "0", fontWeight: "400" }, Ra = ["Webkit", "Moz", "ms"], Sa = d.createElement("div").style; function Ta(a) { if (a in Sa) return a; var b = a[0].toUpperCase() + a.slice(1), c = Ra.length; while (c--) if (a = Ra[c] + b, a in Sa) return a } function Ua(a, b, c) { var d = _.exec(b); return d ? Math.max(0, d[2] - (c || 0)) + (d[3] || "px") : b } function Va(a, b, c, d, e) { for (var f = c === (d ? "border" : "content") ? 4 : "width" === b ? 1 : 0, g = 0; f < 4; f += 2)"margin" === c && (g += r.css(a, c + aa[f], !0, e)), d ? ("content" === c && (g -= r.css(a, "padding" + aa[f], !0, e)), "margin" !== c && (g -= r.css(a, "border" + aa[f] + "Width", !0, e))) : (g += r.css(a, "padding" + aa[f], !0, e), "padding" !== c && (g += r.css(a, "border" + aa[f] + "Width", !0, e))); return g } function Wa(a, b, c) { var d, e = !0, f = La(a), g = "border-box" === r.css(a, "boxSizing", !1, f); if (a.getClientRects().length && (d = a.getBoundingClientRect()[b]), d <= 0 || null == d) { if (d = Ma(a, b, f), (d < 0 || null == d) && (d = a.style[b]), Ka.test(d)) return d; e = g && (o.boxSizingReliable() || d === a.style[b]), d = parseFloat(d) || 0 } return d + Va(a, b, c || (g ? "border" : "content"), e, f) + "px" } r.extend({ cssHooks: { opacity: { get: function (a, b) { if (b) { var c = Ma(a, "opacity"); return "" === c ? "1" : c } } } }, cssNumber: { animationIterationCount: !0, columnCount: !0, fillOpacity: !0, flexGrow: !0, flexShrink: !0, fontWeight: !0, lineHeight: !0, opacity: !0, order: !0, orphans: !0, widows: !0, zIndex: !0, zoom: !0 }, cssProps: { "float": "cssFloat" }, style: function (a, b, c, d) { if (a && 3 !== a.nodeType && 8 !== a.nodeType && a.style) { var e, f, g, h = r.camelCase(b), i = a.style; return b = r.cssProps[h] || (r.cssProps[h] = Ta(h) || h), g = r.cssHooks[b] || r.cssHooks[h], void 0 === c ? g && "get" in g && void 0 !== (e = g.get(a, !1, d)) ? e : i[b] : (f = typeof c, "string" === f && (e = _.exec(c)) && e[1] && (c = da(a, b, e), f = "number"), null != c && c === c && ("number" === f && (c += e && e[3] || (r.cssNumber[h] ? "" : "px")), o.clearCloneStyle || "" !== c || 0 !== b.indexOf("background") || (i[b] = "inherit"), g && "set" in g && void 0 === (c = g.set(a, c, d)) || (i[b] = c)), void 0) } }, css: function (a, b, c, d) { var e, f, g, h = r.camelCase(b); return b = r.cssProps[h] || (r.cssProps[h] = Ta(h) || h), g = r.cssHooks[b] || r.cssHooks[h], g && "get" in g && (e = g.get(a, !0, c)), void 0 === e && (e = Ma(a, b, d)), "normal" === e && b in Qa && (e = Qa[b]), "" === c || c ? (f = parseFloat(e), c === !0 || isFinite(f) ? f || 0 : e) : e } }), r.each(["height", "width"], function (a, b) { r.cssHooks[b] = { get: function (a, c, d) { if (c) return !Oa.test(r.css(a, "display")) || a.getClientRects().length && a.getBoundingClientRect().width ? Wa(a, b, d) : ca(a, Pa, function () { return Wa(a, b, d) }) }, set: function (a, c, d) { var e, f = d && La(a), g = d && Va(a, b, d, "border-box" === r.css(a, "boxSizing", !1, f), f); return g && (e = _.exec(c)) && "px" !== (e[3] || "px") && (a.style[b] = c, c = r.css(a, b)), Ua(a, c, g) } } }), r.cssHooks.marginLeft = Na(o.reliableMarginLeft, function (a, b) { if (b) return (parseFloat(Ma(a, "marginLeft")) || a.getBoundingClientRect().left - ca(a, { marginLeft: 0 }, function () { return a.getBoundingClientRect().left })) + "px" }), r.each({ margin: "", padding: "", border: "Width" }, function (a, b) { r.cssHooks[a + b] = { expand: function (c) { for (var d = 0, e = {}, f = "string" == typeof c ? c.split(" ") : [c]; d < 4; d++)e[a + aa[d] + b] = f[d] || f[d - 2] || f[0]; return e } }, Ja.test(a) || (r.cssHooks[a + b].set = Ua) }), r.fn.extend({ css: function (a, b) { return S(this, function (a, b, c) { var d, e, f = {}, g = 0; if (r.isArray(b)) { for (d = La(a), e = b.length; g < e; g++)f[b[g]] = r.css(a, b[g], !1, d); return f } return void 0 !== c ? r.style(a, b, c) : r.css(a, b) }, a, b, arguments.length > 1) } }); function Xa(a, b, c, d, e) { return new Xa.prototype.init(a, b, c, d, e) } r.Tween = Xa, Xa.prototype = { constructor: Xa, init: function (a, b, c, d, e, f) { this.elem = a, this.prop = c, this.easing = e || r.easing._default, this.options = b, this.start = this.now = this.cur(), this.end = d, this.unit = f || (r.cssNumber[c] ? "" : "px") }, cur: function () { var a = Xa.propHooks[this.prop]; return a && a.get ? a.get(this) : Xa.propHooks._default.get(this) }, run: function (a) { var b, c = Xa.propHooks[this.prop]; return this.options.duration ? this.pos = b = r.easing[this.easing](a, this.options.duration * a, 0, 1, this.options.duration) : this.pos = b = a, this.now = (this.end - this.start) * b + this.start, this.options.step && this.options.step.call(this.elem, this.now, this), c && c.set ? c.set(this) : Xa.propHooks._default.set(this), this } }, Xa.prototype.init.prototype = Xa.prototype, Xa.propHooks = { _default: { get: function (a) { var b; return 1 !== a.elem.nodeType || null != a.elem[a.prop] && null == a.elem.style[a.prop] ? a.elem[a.prop] : (b = r.css(a.elem, a.prop, ""), b && "auto" !== b ? b : 0) }, set: function (a) { r.fx.step[a.prop] ? r.fx.step[a.prop](a) : 1 !== a.elem.nodeType || null == a.elem.style[r.cssProps[a.prop]] && !r.cssHooks[a.prop] ? a.elem[a.prop] = a.now : r.style(a.elem, a.prop, a.now + a.unit) } } }, Xa.propHooks.scrollTop = Xa.propHooks.scrollLeft = { set: function (a) { a.elem.nodeType && a.elem.parentNode && (a.elem[a.prop] = a.now) } }, r.easing = { linear: function (a) { return a }, swing: function (a) { return .5 - Math.cos(a * Math.PI) / 2 }, _default: "swing" }, r.fx = Xa.prototype.init, r.fx.step = {}; var Ya, Za, $a = /^(?:toggle|show|hide)$/, _a = /queueHooks$/; function ab() { Za && (a.requestAnimationFrame(ab), r.fx.tick()) } function bb() { return a.setTimeout(function () { Ya = void 0 }), Ya = r.now() } function cb(a, b) { var c, d = 0, e = { height: a }; for (b = b ? 1 : 0; d < 4; d += 2 - b)c = aa[d], e["margin" + c] = e["padding" + c] = a; return b && (e.opacity = e.width = a), e } function db(a, b, c) { for (var d, e = (gb.tweeners[b] || []).concat(gb.tweeners["*"]), f = 0, g = e.length; f < g; f++)if (d = e[f].call(c, b, a)) return d } function eb(a, b, c) { var d, e, f, g, h, i, j, k, l = "width" in b || "height" in b, m = this, n = {}, o = a.style, p = a.nodeType && ba(a), q = V.get(a, "fxshow"); c.queue || (g = r._queueHooks(a, "fx"), null == g.unqueued && (g.unqueued = 0, h = g.empty.fire, g.empty.fire = function () { g.unqueued || h() }), g.unqueued++ , m.always(function () { m.always(function () { g.unqueued-- , r.queue(a, "fx").length || g.empty.fire() }) })); for (d in b) if (e = b[d], $a.test(e)) { if (delete b[d], f = f || "toggle" === e, e === (p ? "hide" : "show")) { if ("show" !== e || !q || void 0 === q[d]) continue; p = !0 } n[d] = q && q[d] || r.style(a, d) } if (i = !r.isEmptyObject(b), i || !r.isEmptyObject(n)) { l && 1 === a.nodeType && (c.overflow = [o.overflow, o.overflowX, o.overflowY], j = q && q.display, null == j && (j = V.get(a, "display")), k = r.css(a, "display"), "none" === k && (j ? k = j : (ga([a], !0), j = a.style.display || j, k = r.css(a, "display"), ga([a]))), ("inline" === k || "inline-block" === k && null != j) && "none" === r.css(a, "float") && (i || (m.done(function () { o.display = j }), null == j && (k = o.display, j = "none" === k ? "" : k)), o.display = "inline-block")), c.overflow && (o.overflow = "hidden", m.always(function () { o.overflow = c.overflow[0], o.overflowX = c.overflow[1], o.overflowY = c.overflow[2] })), i = !1; for (d in n) i || (q ? "hidden" in q && (p = q.hidden) : q = V.access(a, "fxshow", { display: j }), f && (q.hidden = !p), p && ga([a], !0), m.done(function () { p || ga([a]), V.remove(a, "fxshow"); for (d in n) r.style(a, d, n[d]) })), i = db(p ? q[d] : 0, d, m), d in q || (q[d] = i.start, p && (i.end = i.start, i.start = 0)) } } function fb(a, b) { var c, d, e, f, g; for (c in a) if (d = r.camelCase(c), e = b[d], f = a[c], r.isArray(f) && (e = f[1], f = a[c] = f[0]), c !== d && (a[d] = f, delete a[c]), g = r.cssHooks[d], g && "expand" in g) { f = g.expand(f), delete a[d]; for (c in f) c in a || (a[c] = f[c], b[c] = e) } else b[d] = e } function gb(a, b, c) { var d, e, f = 0, g = gb.prefilters.length, h = r.Deferred().always(function () { delete i.elem }), i = function () { if (e) return !1; for (var b = Ya || bb(), c = Math.max(0, j.startTime + j.duration - b), d = c / j.duration || 0, f = 1 - d, g = 0, i = j.tweens.length; g < i; g++)j.tweens[g].run(f); return h.notifyWith(a, [j, f, c]), f < 1 && i ? c : (h.resolveWith(a, [j]), !1) }, j = h.promise({ elem: a, props: r.extend({}, b), opts: r.extend(!0, { specialEasing: {}, easing: r.easing._default }, c), originalProperties: b, originalOptions: c, startTime: Ya || bb(), duration: c.duration, tweens: [], createTween: function (b, c) { var d = r.Tween(a, j.opts, b, c, j.opts.specialEasing[b] || j.opts.easing); return j.tweens.push(d), d }, stop: function (b) { var c = 0, d = b ? j.tweens.length : 0; if (e) return this; for (e = !0; c < d; c++)j.tweens[c].run(1); return b ? (h.notifyWith(a, [j, 1, 0]), h.resolveWith(a, [j, b])) : h.rejectWith(a, [j, b]), this } }), k = j.props; for (fb(k, j.opts.specialEasing); f < g; f++)if (d = gb.prefilters[f].call(j, a, k, j.opts)) return r.isFunction(d.stop) && (r._queueHooks(j.elem, j.opts.queue).stop = r.proxy(d.stop, d)), d; return r.map(k, db, j), r.isFunction(j.opts.start) && j.opts.start.call(a, j), r.fx.timer(r.extend(i, { elem: a, anim: j, queue: j.opts.queue })), j.progress(j.opts.progress).done(j.opts.done, j.opts.complete).fail(j.opts.fail).always(j.opts.always) } r.Animation = r.extend(gb, { tweeners: { "*": [function (a, b) { var c = this.createTween(a, b); return da(c.elem, a, _.exec(b), c), c }] }, tweener: function (a, b) { r.isFunction(a) ? (b = a, a = ["*"]) : a = a.match(K); for (var c, d = 0, e = a.length; d < e; d++)c = a[d], gb.tweeners[c] = gb.tweeners[c] || [], gb.tweeners[c].unshift(b) }, prefilters: [eb], prefilter: function (a, b) { b ? gb.prefilters.unshift(a) : gb.prefilters.push(a) } }), r.speed = function (a, b, c) { var e = a && "object" == typeof a ? r.extend({}, a) : { complete: c || !c && b || r.isFunction(a) && a, duration: a, easing: c && b || b && !r.isFunction(b) && b }; return r.fx.off || d.hidden ? e.duration = 0 : e.duration = "number" == typeof e.duration ? e.duration : e.duration in r.fx.speeds ? r.fx.speeds[e.duration] : r.fx.speeds._default, null != e.queue && e.queue !== !0 || (e.queue = "fx"), e.old = e.complete, e.complete = function () { r.isFunction(e.old) && e.old.call(this), e.queue && r.dequeue(this, e.queue) }, e }, r.fn.extend({ fadeTo: function (a, b, c, d) { return this.filter(ba).css("opacity", 0).show().end().animate({ opacity: b }, a, c, d) }, animate: function (a, b, c, d) { var e = r.isEmptyObject(a), f = r.speed(b, c, d), g = function () { var b = gb(this, r.extend({}, a), f); (e || V.get(this, "finish")) && b.stop(!0) }; return g.finish = g, e || f.queue === !1 ? this.each(g) : this.queue(f.queue, g) }, stop: function (a, b, c) { var d = function (a) { var b = a.stop; delete a.stop, b(c) }; return "string" != typeof a && (c = b, b = a, a = void 0), b && a !== !1 && this.queue(a || "fx", []), this.each(function () { var b = !0, e = null != a && a + "queueHooks", f = r.timers, g = V.get(this); if (e) g[e] && g[e].stop && d(g[e]); else for (e in g) g[e] && g[e].stop && _a.test(e) && d(g[e]); for (e = f.length; e--;)f[e].elem !== this || null != a && f[e].queue !== a || (f[e].anim.stop(c), b = !1, f.splice(e, 1)); !b && c || r.dequeue(this, a) }) }, finish: function (a) { return a !== !1 && (a = a || "fx"), this.each(function () { var b, c = V.get(this), d = c[a + "queue"], e = c[a + "queueHooks"], f = r.timers, g = d ? d.length : 0; for (c.finish = !0, r.queue(this, a, []), e && e.stop && e.stop.call(this, !0), b = f.length; b--;)f[b].elem === this && f[b].queue === a && (f[b].anim.stop(!0), f.splice(b, 1)); for (b = 0; b < g; b++)d[b] && d[b].finish && d[b].finish.call(this); delete c.finish }) } }), r.each(["toggle", "show", "hide"], function (a, b) { var c = r.fn[b]; r.fn[b] = function (a, d, e) { return null == a || "boolean" == typeof a ? c.apply(this, arguments) : this.animate(cb(b, !0), a, d, e) } }), r.each({ slideDown: cb("show"), slideUp: cb("hide"), slideToggle: cb("toggle"), fadeIn: { opacity: "show" }, fadeOut: { opacity: "hide" }, fadeToggle: { opacity: "toggle" } }, function (a, b) { r.fn[a] = function (a, c, d) { return this.animate(b, a, c, d) } }), r.timers = [], r.fx.tick = function () { var a, b = 0, c = r.timers; for (Ya = r.now(); b < c.length; b++)a = c[b], a() || c[b] !== a || c.splice(b--, 1); c.length || r.fx.stop(), Ya = void 0 }, r.fx.timer = function (a) { r.timers.push(a), a() ? r.fx.start() : r.timers.pop() }, r.fx.interval = 13, r.fx.start = function () { Za || (Za = a.requestAnimationFrame ? a.requestAnimationFrame(ab) : a.setInterval(r.fx.tick, r.fx.interval)) }, r.fx.stop = function () { a.cancelAnimationFrame ? a.cancelAnimationFrame(Za) : a.clearInterval(Za), Za = null }, r.fx.speeds = { slow: 600, fast: 200, _default: 400 }, r.fn.delay = function (b, c) { return b = r.fx ? r.fx.speeds[b] || b : b, c = c || "fx", this.queue(c, function (c, d) { var e = a.setTimeout(c, b); d.stop = function () { a.clearTimeout(e) } }) }, function () { var a = d.createElement("input"), b = d.createElement("select"), c = b.appendChild(d.createElement("option")); a.type = "checkbox", o.checkOn = "" !== a.value, o.optSelected = c.selected, a = d.createElement("input"), a.value = "t", a.type = "radio", o.radioValue = "t" === a.value }(); var hb, ib = r.expr.attrHandle; r.fn.extend({ attr: function (a, b) { return S(this, r.attr, a, b, arguments.length > 1) }, removeAttr: function (a) { return this.each(function () { r.removeAttr(this, a) }) } }), r.extend({
        attr: function (a, b, c) { var d, e, f = a.nodeType; if (3 !== f && 8 !== f && 2 !== f) return "undefined" == typeof a.getAttribute ? r.prop(a, b, c) : (1 === f && r.isXMLDoc(a) || (e = r.attrHooks[b.toLowerCase()] || (r.expr.match.bool.test(b) ? hb : void 0)), void 0 !== c ? null === c ? void r.removeAttr(a, b) : e && "set" in e && void 0 !== (d = e.set(a, c, b)) ? d : (a.setAttribute(b, c + ""), c) : e && "get" in e && null !== (d = e.get(a, b)) ? d : (d = r.find.attr(a, b), null == d ? void 0 : d)) }, attrHooks: { type: { set: function (a, b) { if (!o.radioValue && "radio" === b && r.nodeName(a, "input")) { var c = a.value; return a.setAttribute("type", b), c && (a.value = c), b } } } }, removeAttr: function (a, b) {
            var c, d = 0, e = b && b.match(K);
            if (e && 1 === a.nodeType) while (c = e[d++]) a.removeAttribute(c)
        }
    }), hb = { set: function (a, b, c) { return b === !1 ? r.removeAttr(a, c) : a.setAttribute(c, c), c } }, r.each(r.expr.match.bool.source.match(/\w+/g), function (a, b) { var c = ib[b] || r.find.attr; ib[b] = function (a, b, d) { var e, f, g = b.toLowerCase(); return d || (f = ib[g], ib[g] = e, e = null != c(a, b, d) ? g : null, ib[g] = f), e } }); var jb = /^(?:input|select|textarea|button)$/i, kb = /^(?:a|area)$/i; r.fn.extend({ prop: function (a, b) { return S(this, r.prop, a, b, arguments.length > 1) }, removeProp: function (a) { return this.each(function () { delete this[r.propFix[a] || a] }) } }), r.extend({ prop: function (a, b, c) { var d, e, f = a.nodeType; if (3 !== f && 8 !== f && 2 !== f) return 1 === f && r.isXMLDoc(a) || (b = r.propFix[b] || b, e = r.propHooks[b]), void 0 !== c ? e && "set" in e && void 0 !== (d = e.set(a, c, b)) ? d : a[b] = c : e && "get" in e && null !== (d = e.get(a, b)) ? d : a[b] }, propHooks: { tabIndex: { get: function (a) { var b = r.find.attr(a, "tabindex"); return b ? parseInt(b, 10) : jb.test(a.nodeName) || kb.test(a.nodeName) && a.href ? 0 : -1 } } }, propFix: { "for": "htmlFor", "class": "className" } }), o.optSelected || (r.propHooks.selected = { get: function (a) { var b = a.parentNode; return b && b.parentNode && b.parentNode.selectedIndex, null }, set: function (a) { var b = a.parentNode; b && (b.selectedIndex, b.parentNode && b.parentNode.selectedIndex) } }), r.each(["tabIndex", "readOnly", "maxLength", "cellSpacing", "cellPadding", "rowSpan", "colSpan", "useMap", "frameBorder", "contentEditable"], function () { r.propFix[this.toLowerCase()] = this }); var lb = /[\t\r\n\f]/g; function mb(a) { return a.getAttribute && a.getAttribute("class") || "" } r.fn.extend({ addClass: function (a) { var b, c, d, e, f, g, h, i = 0; if (r.isFunction(a)) return this.each(function (b) { r(this).addClass(a.call(this, b, mb(this))) }); if ("string" == typeof a && a) { b = a.match(K) || []; while (c = this[i++]) if (e = mb(c), d = 1 === c.nodeType && (" " + e + " ").replace(lb, " ")) { g = 0; while (f = b[g++]) d.indexOf(" " + f + " ") < 0 && (d += f + " "); h = r.trim(d), e !== h && c.setAttribute("class", h) } } return this }, removeClass: function (a) { var b, c, d, e, f, g, h, i = 0; if (r.isFunction(a)) return this.each(function (b) { r(this).removeClass(a.call(this, b, mb(this))) }); if (!arguments.length) return this.attr("class", ""); if ("string" == typeof a && a) { b = a.match(K) || []; while (c = this[i++]) if (e = mb(c), d = 1 === c.nodeType && (" " + e + " ").replace(lb, " ")) { g = 0; while (f = b[g++]) while (d.indexOf(" " + f + " ") > -1) d = d.replace(" " + f + " ", " "); h = r.trim(d), e !== h && c.setAttribute("class", h) } } return this }, toggleClass: function (a, b) { var c = typeof a; return "boolean" == typeof b && "string" === c ? b ? this.addClass(a) : this.removeClass(a) : r.isFunction(a) ? this.each(function (c) { r(this).toggleClass(a.call(this, c, mb(this), b), b) }) : this.each(function () { var b, d, e, f; if ("string" === c) { d = 0, e = r(this), f = a.match(K) || []; while (b = f[d++]) e.hasClass(b) ? e.removeClass(b) : e.addClass(b) } else void 0 !== a && "boolean" !== c || (b = mb(this), b && V.set(this, "__className__", b), this.setAttribute && this.setAttribute("class", b || a === !1 ? "" : V.get(this, "__className__") || "")) }) }, hasClass: function (a) { var b, c, d = 0; b = " " + a + " "; while (c = this[d++]) if (1 === c.nodeType && (" " + mb(c) + " ").replace(lb, " ").indexOf(b) > -1) return !0; return !1 } }); var nb = /\r/g, ob = /[\x20\t\r\n\f]+/g; r.fn.extend({ val: function (a) { var b, c, d, e = this[0]; { if (arguments.length) return d = r.isFunction(a), this.each(function (c) { var e; 1 === this.nodeType && (e = d ? a.call(this, c, r(this).val()) : a, null == e ? e = "" : "number" == typeof e ? e += "" : r.isArray(e) && (e = r.map(e, function (a) { return null == a ? "" : a + "" })), b = r.valHooks[this.type] || r.valHooks[this.nodeName.toLowerCase()], b && "set" in b && void 0 !== b.set(this, e, "value") || (this.value = e)) }); if (e) return b = r.valHooks[e.type] || r.valHooks[e.nodeName.toLowerCase()], b && "get" in b && void 0 !== (c = b.get(e, "value")) ? c : (c = e.value, "string" == typeof c ? c.replace(nb, "") : null == c ? "" : c) } } }), r.extend({ valHooks: { option: { get: function (a) { var b = r.find.attr(a, "value"); return null != b ? b : r.trim(r.text(a)).replace(ob, " ") } }, select: { get: function (a) { for (var b, c, d = a.options, e = a.selectedIndex, f = "select-one" === a.type, g = f ? null : [], h = f ? e + 1 : d.length, i = e < 0 ? h : f ? e : 0; i < h; i++)if (c = d[i], (c.selected || i === e) && !c.disabled && (!c.parentNode.disabled || !r.nodeName(c.parentNode, "optgroup"))) { if (b = r(c).val(), f) return b; g.push(b) } return g }, set: function (a, b) { var c, d, e = a.options, f = r.makeArray(b), g = e.length; while (g--) d = e[g], (d.selected = r.inArray(r.valHooks.option.get(d), f) > -1) && (c = !0); return c || (a.selectedIndex = -1), f } } } }), r.each(["radio", "checkbox"], function () { r.valHooks[this] = { set: function (a, b) { if (r.isArray(b)) return a.checked = r.inArray(r(a).val(), b) > -1 } }, o.checkOn || (r.valHooks[this].get = function (a) { return null === a.getAttribute("value") ? "on" : a.value }) }); var pb = /^(?:focusinfocus|focusoutblur)$/; r.extend(r.event, { trigger: function (b, c, e, f) { var g, h, i, j, k, m, n, o = [e || d], p = l.call(b, "type") ? b.type : b, q = l.call(b, "namespace") ? b.namespace.split(".") : []; if (h = i = e = e || d, 3 !== e.nodeType && 8 !== e.nodeType && !pb.test(p + r.event.triggered) && (p.indexOf(".") > -1 && (q = p.split("."), p = q.shift(), q.sort()), k = p.indexOf(":") < 0 && "on" + p, b = b[r.expando] ? b : new r.Event(p, "object" == typeof b && b), b.isTrigger = f ? 2 : 3, b.namespace = q.join("."), b.rnamespace = b.namespace ? new RegExp("(^|\\.)" + q.join("\\.(?:.*\\.|)") + "(\\.|$)") : null, b.result = void 0, b.target || (b.target = e), c = null == c ? [b] : r.makeArray(c, [b]), n = r.event.special[p] || {}, f || !n.trigger || n.trigger.apply(e, c) !== !1)) { if (!f && !n.noBubble && !r.isWindow(e)) { for (j = n.delegateType || p, pb.test(j + p) || (h = h.parentNode); h; h = h.parentNode)o.push(h), i = h; i === (e.ownerDocument || d) && o.push(i.defaultView || i.parentWindow || a) } g = 0; while ((h = o[g++]) && !b.isPropagationStopped()) b.type = g > 1 ? j : n.bindType || p, m = (V.get(h, "events") || {})[b.type] && V.get(h, "handle"), m && m.apply(h, c), m = k && h[k], m && m.apply && T(h) && (b.result = m.apply(h, c), b.result === !1 && b.preventDefault()); return b.type = p, f || b.isDefaultPrevented() || n._default && n._default.apply(o.pop(), c) !== !1 || !T(e) || k && r.isFunction(e[p]) && !r.isWindow(e) && (i = e[k], i && (e[k] = null), r.event.triggered = p, e[p](), r.event.triggered = void 0, i && (e[k] = i)), b.result } }, simulate: function (a, b, c) { var d = r.extend(new r.Event, c, { type: a, isSimulated: !0 }); r.event.trigger(d, null, b) } }), r.fn.extend({ trigger: function (a, b) { return this.each(function () { r.event.trigger(a, b, this) }) }, triggerHandler: function (a, b) { var c = this[0]; if (c) return r.event.trigger(a, b, c, !0) } }), r.each("blur focus focusin focusout resize scroll click dblclick mousedown mouseup mousemove mouseover mouseout mouseenter mouseleave change select submit keydown keypress keyup contextmenu".split(" "), function (a, b) { r.fn[b] = function (a, c) { return arguments.length > 0 ? this.on(b, null, a, c) : this.trigger(b) } }), r.fn.extend({ hover: function (a, b) { return this.mouseenter(a).mouseleave(b || a) } }), o.focusin = "onfocusin" in a, o.focusin || r.each({ focus: "focusin", blur: "focusout" }, function (a, b) { var c = function (a) { r.event.simulate(b, a.target, r.event.fix(a)) }; r.event.special[b] = { setup: function () { var d = this.ownerDocument || this, e = V.access(d, b); e || d.addEventListener(a, c, !0), V.access(d, b, (e || 0) + 1) }, teardown: function () { var d = this.ownerDocument || this, e = V.access(d, b) - 1; e ? V.access(d, b, e) : (d.removeEventListener(a, c, !0), V.remove(d, b)) } } }); var qb = a.location, rb = r.now(), sb = /\?/; r.parseXML = function (b) { var c; if (!b || "string" != typeof b) return null; try { c = (new a.DOMParser).parseFromString(b, "text/xml") } catch (d) { c = void 0 } return c && !c.getElementsByTagName("parsererror").length || r.error("Invalid XML: " + b), c }; var tb = /\[\]$/, ub = /\r?\n/g, vb = /^(?:submit|button|image|reset|file)$/i, wb = /^(?:input|select|textarea|keygen)/i; function xb(a, b, c, d) { var e; if (r.isArray(b)) r.each(b, function (b, e) { c || tb.test(a) ? d(a, e) : xb(a + "[" + ("object" == typeof e && null != e ? b : "") + "]", e, c, d) }); else if (c || "object" !== r.type(b)) d(a, b); else for (e in b) xb(a + "[" + e + "]", b[e], c, d) } r.param = function (a, b) { var c, d = [], e = function (a, b) { var c = r.isFunction(b) ? b() : b; d[d.length] = encodeURIComponent(a) + "=" + encodeURIComponent(null == c ? "" : c) }; if (r.isArray(a) || a.jquery && !r.isPlainObject(a)) r.each(a, function () { e(this.name, this.value) }); else for (c in a) xb(c, a[c], b, e); return d.join("&") }, r.fn.extend({ serialize: function () { return r.param(this.serializeArray()) }, serializeArray: function () { return this.map(function () { var a = r.prop(this, "elements"); return a ? r.makeArray(a) : this }).filter(function () { var a = this.type; return this.name && !r(this).is(":disabled") && wb.test(this.nodeName) && !vb.test(a) && (this.checked || !ha.test(a)) }).map(function (a, b) { var c = r(this).val(); return null == c ? null : r.isArray(c) ? r.map(c, function (a) { return { name: b.name, value: a.replace(ub, "\r\n") } }) : { name: b.name, value: c.replace(ub, "\r\n") } }).get() } }); var yb = /%20/g, zb = /#.*$/, Ab = /([?&])_=[^&]*/, Bb = /^(.*?):[ \t]*([^\r\n]*)$/gm, Cb = /^(?:about|app|app-storage|.+-extension|file|res|widget):$/, Db = /^(?:GET|HEAD)$/, Eb = /^\/\//, Fb = {}, Gb = {}, Hb = "*/".concat("*"), Ib = d.createElement("a"); Ib.href = qb.href; function Jb(a) { return function (b, c) { "string" != typeof b && (c = b, b = "*"); var d, e = 0, f = b.toLowerCase().match(K) || []; if (r.isFunction(c)) while (d = f[e++]) "+" === d[0] ? (d = d.slice(1) || "*", (a[d] = a[d] || []).unshift(c)) : (a[d] = a[d] || []).push(c) } } function Kb(a, b, c, d) { var e = {}, f = a === Gb; function g(h) { var i; return e[h] = !0, r.each(a[h] || [], function (a, h) { var j = h(b, c, d); return "string" != typeof j || f || e[j] ? f ? !(i = j) : void 0 : (b.dataTypes.unshift(j), g(j), !1) }), i } return g(b.dataTypes[0]) || !e["*"] && g("*") } function Lb(a, b) { var c, d, e = r.ajaxSettings.flatOptions || {}; for (c in b) void 0 !== b[c] && ((e[c] ? a : d || (d = {}))[c] = b[c]); return d && r.extend(!0, a, d), a } function Mb(a, b, c) { var d, e, f, g, h = a.contents, i = a.dataTypes; while ("*" === i[0]) i.shift(), void 0 === d && (d = a.mimeType || b.getResponseHeader("Content-Type")); if (d) for (e in h) if (h[e] && h[e].test(d)) { i.unshift(e); break } if (i[0] in c) f = i[0]; else { for (e in c) { if (!i[0] || a.converters[e + " " + i[0]]) { f = e; break } g || (g = e) } f = f || g } if (f) return f !== i[0] && i.unshift(f), c[f] } function Nb(a, b, c, d) { var e, f, g, h, i, j = {}, k = a.dataTypes.slice(); if (k[1]) for (g in a.converters) j[g.toLowerCase()] = a.converters[g]; f = k.shift(); while (f) if (a.responseFields[f] && (c[a.responseFields[f]] = b), !i && d && a.dataFilter && (b = a.dataFilter(b, a.dataType)), i = f, f = k.shift()) if ("*" === f) f = i; else if ("*" !== i && i !== f) { if (g = j[i + " " + f] || j["* " + f], !g) for (e in j) if (h = e.split(" "), h[1] === f && (g = j[i + " " + h[0]] || j["* " + h[0]])) { g === !0 ? g = j[e] : j[e] !== !0 && (f = h[0], k.unshift(h[1])); break } if (g !== !0) if (g && a["throws"]) b = g(b); else try { b = g(b) } catch (l) { return { state: "parsererror", error: g ? l : "No conversion from " + i + " to " + f } } } return { state: "success", data: b } } r.extend({ active: 0, lastModified: {}, etag: {}, ajaxSettings: { url: qb.href, type: "GET", isLocal: Cb.test(qb.protocol), global: !0, processData: !0, async: !0, contentType: "application/x-www-form-urlencoded; charset=UTF-8", accepts: { "*": Hb, text: "text/plain", html: "text/html", xml: "application/xml, text/xml", json: "application/json, text/javascript" }, contents: { xml: /\bxml\b/, html: /\bhtml/, json: /\bjson\b/ }, responseFields: { xml: "responseXML", text: "responseText", json: "responseJSON" }, converters: { "* text": String, "text html": !0, "text json": JSON.parse, "text xml": r.parseXML }, flatOptions: { url: !0, context: !0 } }, ajaxSetup: function (a, b) { return b ? Lb(Lb(a, r.ajaxSettings), b) : Lb(r.ajaxSettings, a) }, ajaxPrefilter: Jb(Fb), ajaxTransport: Jb(Gb), ajax: function (b, c) { "object" == typeof b && (c = b, b = void 0), c = c || {}; var e, f, g, h, i, j, k, l, m, n, o = r.ajaxSetup({}, c), p = o.context || o, q = o.context && (p.nodeType || p.jquery) ? r(p) : r.event, s = r.Deferred(), t = r.Callbacks("once memory"), u = o.statusCode || {}, v = {}, w = {}, x = "canceled", y = { readyState: 0, getResponseHeader: function (a) { var b; if (k) { if (!h) { h = {}; while (b = Bb.exec(g)) h[b[1].toLowerCase()] = b[2] } b = h[a.toLowerCase()] } return null == b ? null : b }, getAllResponseHeaders: function () { return k ? g : null }, setRequestHeader: function (a, b) { return null == k && (a = w[a.toLowerCase()] = w[a.toLowerCase()] || a, v[a] = b), this }, overrideMimeType: function (a) { return null == k && (o.mimeType = a), this }, statusCode: function (a) { var b; if (a) if (k) y.always(a[y.status]); else for (b in a) u[b] = [u[b], a[b]]; return this }, abort: function (a) { var b = a || x; return e && e.abort(b), A(0, b), this } }; if (s.promise(y), o.url = ((b || o.url || qb.href) + "").replace(Eb, qb.protocol + "//"), o.type = c.method || c.type || o.method || o.type, o.dataTypes = (o.dataType || "*").toLowerCase().match(K) || [""], null == o.crossDomain) { j = d.createElement("a"); try { j.href = o.url, j.href = j.href, o.crossDomain = Ib.protocol + "//" + Ib.host != j.protocol + "//" + j.host } catch (z) { o.crossDomain = !0 } } if (o.data && o.processData && "string" != typeof o.data && (o.data = r.param(o.data, o.traditional)), Kb(Fb, o, c, y), k) return y; l = r.event && o.global, l && 0 === r.active++ && r.event.trigger("ajaxStart"), o.type = o.type.toUpperCase(), o.hasContent = !Db.test(o.type), f = o.url.replace(zb, ""), o.hasContent ? o.data && o.processData && 0 === (o.contentType || "").indexOf("application/x-www-form-urlencoded") && (o.data = o.data.replace(yb, "+")) : (n = o.url.slice(f.length), o.data && (f += (sb.test(f) ? "&" : "?") + o.data, delete o.data), o.cache === !1 && (f = f.replace(Ab, ""), n = (sb.test(f) ? "&" : "?") + "_=" + rb++ + n), o.url = f + n), o.ifModified && (r.lastModified[f] && y.setRequestHeader("If-Modified-Since", r.lastModified[f]), r.etag[f] && y.setRequestHeader("If-None-Match", r.etag[f])), (o.data && o.hasContent && o.contentType !== !1 || c.contentType) && y.setRequestHeader("Content-Type", o.contentType), y.setRequestHeader("Accept", o.dataTypes[0] && o.accepts[o.dataTypes[0]] ? o.accepts[o.dataTypes[0]] + ("*" !== o.dataTypes[0] ? ", " + Hb + "; q=0.01" : "") : o.accepts["*"]); for (m in o.headers) y.setRequestHeader(m, o.headers[m]); if (o.beforeSend && (o.beforeSend.call(p, y, o) === !1 || k)) return y.abort(); if (x = "abort", t.add(o.complete), y.done(o.success), y.fail(o.error), e = Kb(Gb, o, c, y)) { if (y.readyState = 1, l && q.trigger("ajaxSend", [y, o]), k) return y; o.async && o.timeout > 0 && (i = a.setTimeout(function () { y.abort("timeout") }, o.timeout)); try { k = !1, e.send(v, A) } catch (z) { if (k) throw z; A(-1, z) } } else A(-1, "No Transport"); function A(b, c, d, h) { var j, m, n, v, w, x = c; k || (k = !0, i && a.clearTimeout(i), e = void 0, g = h || "", y.readyState = b > 0 ? 4 : 0, j = b >= 200 && b < 300 || 304 === b, d && (v = Mb(o, y, d)), v = Nb(o, v, y, j), j ? (o.ifModified && (w = y.getResponseHeader("Last-Modified"), w && (r.lastModified[f] = w), w = y.getResponseHeader("etag"), w && (r.etag[f] = w)), 204 === b || "HEAD" === o.type ? x = "nocontent" : 304 === b ? x = "notmodified" : (x = v.state, m = v.data, n = v.error, j = !n)) : (n = x, !b && x || (x = "error", b < 0 && (b = 0))), y.status = b, y.statusText = (c || x) + "", j ? s.resolveWith(p, [m, x, y]) : s.rejectWith(p, [y, x, n]), y.statusCode(u), u = void 0, l && q.trigger(j ? "ajaxSuccess" : "ajaxError", [y, o, j ? m : n]), t.fireWith(p, [y, x]), l && (q.trigger("ajaxComplete", [y, o]), --r.active || r.event.trigger("ajaxStop"))) } return y }, getJSON: function (a, b, c) { return r.get(a, b, c, "json") }, getScript: function (a, b) { return r.get(a, void 0, b, "script") } }), r.each(["get", "post"], function (a, b) { r[b] = function (a, c, d, e) { return r.isFunction(c) && (e = e || d, d = c, c = void 0), r.ajax(r.extend({ url: a, type: b, dataType: e, data: c, success: d }, r.isPlainObject(a) && a)) } }), r._evalUrl = function (a) { return r.ajax({ url: a, type: "GET", dataType: "script", cache: !0, async: !1, global: !1, "throws": !0 }) }, r.fn.extend({ wrapAll: function (a) { var b; return this[0] && (r.isFunction(a) && (a = a.call(this[0])), b = r(a, this[0].ownerDocument).eq(0).clone(!0), this[0].parentNode && b.insertBefore(this[0]), b.map(function () { var a = this; while (a.firstElementChild) a = a.firstElementChild; return a }).append(this)), this }, wrapInner: function (a) { return r.isFunction(a) ? this.each(function (b) { r(this).wrapInner(a.call(this, b)) }) : this.each(function () { var b = r(this), c = b.contents(); c.length ? c.wrapAll(a) : b.append(a) }) }, wrap: function (a) { var b = r.isFunction(a); return this.each(function (c) { r(this).wrapAll(b ? a.call(this, c) : a) }) }, unwrap: function (a) { return this.parent(a).not("body").each(function () { r(this).replaceWith(this.childNodes) }), this } }), r.expr.pseudos.hidden = function (a) { return !r.expr.pseudos.visible(a) }, r.expr.pseudos.visible = function (a) { return !!(a.offsetWidth || a.offsetHeight || a.getClientRects().length) }, r.ajaxSettings.xhr = function () { try { return new a.XMLHttpRequest } catch (b) { } }; var Ob = { 0: 200, 1223: 204 }, Pb = r.ajaxSettings.xhr(); o.cors = !!Pb && "withCredentials" in Pb, o.ajax = Pb = !!Pb, r.ajaxTransport(function (b) { var c, d; if (o.cors || Pb && !b.crossDomain) return { send: function (e, f) { var g, h = b.xhr(); if (h.open(b.type, b.url, b.async, b.username, b.password), b.xhrFields) for (g in b.xhrFields) h[g] = b.xhrFields[g]; b.mimeType && h.overrideMimeType && h.overrideMimeType(b.mimeType), b.crossDomain || e["X-Requested-With"] || (e["X-Requested-With"] = "XMLHttpRequest"); for (g in e) h.setRequestHeader(g, e[g]); c = function (a) { return function () { c && (c = d = h.onload = h.onerror = h.onabort = h.onreadystatechange = null, "abort" === a ? h.abort() : "error" === a ? "number" != typeof h.status ? f(0, "error") : f(h.status, h.statusText) : f(Ob[h.status] || h.status, h.statusText, "text" !== (h.responseType || "text") || "string" != typeof h.responseText ? { binary: h.response } : { text: h.responseText }, h.getAllResponseHeaders())) } }, h.onload = c(), d = h.onerror = c("error"), void 0 !== h.onabort ? h.onabort = d : h.onreadystatechange = function () { 4 === h.readyState && a.setTimeout(function () { c && d() }) }, c = c("abort"); try { h.send(b.hasContent && b.data || null) } catch (i) { if (c) throw i } }, abort: function () { c && c() } } }), r.ajaxPrefilter(function (a) { a.crossDomain && (a.contents.script = !1) }), r.ajaxSetup({ accepts: { script: "text/javascript, application/javascript, application/ecmascript, application/x-ecmascript" }, contents: { script: /\b(?:java|ecma)script\b/ }, converters: { "text script": function (a) { return r.globalEval(a), a } } }), r.ajaxPrefilter("script", function (a) { void 0 === a.cache && (a.cache = !1), a.crossDomain && (a.type = "GET") }), r.ajaxTransport("script", function (a) { if (a.crossDomain) { var b, c; return { send: function (e, f) { b = r("<script>").prop({ charset: a.scriptCharset, src: a.url }).on("load error", c = function (a) { b.remove(), c = null, a && f("error" === a.type ? 404 : 200, a.type) }), d.head.appendChild(b[0]) }, abort: function () { c && c() } } } }); var Qb = [], Rb = /(=)\?(?=&|$)|\?\?/; r.ajaxSetup({ jsonp: "callback", jsonpCallback: function () { var a = Qb.pop() || r.expando + "_" + rb++; return this[a] = !0, a } }), r.ajaxPrefilter("json jsonp", function (b, c, d) { var e, f, g, h = b.jsonp !== !1 && (Rb.test(b.url) ? "url" : "string" == typeof b.data && 0 === (b.contentType || "").indexOf("application/x-www-form-urlencoded") && Rb.test(b.data) && "data"); if (h || "jsonp" === b.dataTypes[0]) return e = b.jsonpCallback = r.isFunction(b.jsonpCallback) ? b.jsonpCallback() : b.jsonpCallback, h ? b[h] = b[h].replace(Rb, "$1" + e) : b.jsonp !== !1 && (b.url += (sb.test(b.url) ? "&" : "?") + b.jsonp + "=" + e), b.converters["script json"] = function () { return g || r.error(e + " was not called"), g[0] }, b.dataTypes[0] = "json", f = a[e], a[e] = function () { g = arguments }, d.always(function () { void 0 === f ? r(a).removeProp(e) : a[e] = f, b[e] && (b.jsonpCallback = c.jsonpCallback, Qb.push(e)), g && r.isFunction(f) && f(g[0]), g = f = void 0 }), "script" }), o.createHTMLDocument = function () { var a = d.implementation.createHTMLDocument("").body; return a.innerHTML = "<form></form><form></form>", 2 === a.childNodes.length }(), r.parseHTML = function (a, b, c) { if ("string" != typeof a) return []; "boolean" == typeof b && (c = b, b = !1); var e, f, g; return b || (o.createHTMLDocument ? (b = d.implementation.createHTMLDocument(""), e = b.createElement("base"), e.href = d.location.href, b.head.appendChild(e)) : b = d), f = B.exec(a), g = !c && [], f ? [b.createElement(f[1])] : (f = oa([a], b, g), g && g.length && r(g).remove(), r.merge([], f.childNodes)) }, r.fn.load = function (a, b, c) { var d, e, f, g = this, h = a.indexOf(" "); return h > -1 && (d = r.trim(a.slice(h)), a = a.slice(0, h)), r.isFunction(b) ? (c = b, b = void 0) : b && "object" == typeof b && (e = "POST"), g.length > 0 && r.ajax({ url: a, type: e || "GET", dataType: "html", data: b }).done(function (a) { f = arguments, g.html(d ? r("<div>").append(r.parseHTML(a)).find(d) : a) }).always(c && function (a, b) { g.each(function () { c.apply(this, f || [a.responseText, b, a]) }) }), this }, r.each(["ajaxStart", "ajaxStop", "ajaxComplete", "ajaxError", "ajaxSuccess", "ajaxSend"], function (a, b) { r.fn[b] = function (a) { return this.on(b, a) } }), r.expr.pseudos.animated = function (a) { return r.grep(r.timers, function (b) { return a === b.elem }).length }; function Sb(a) { return r.isWindow(a) ? a : 9 === a.nodeType && a.defaultView } r.offset = { setOffset: function (a, b, c) { var d, e, f, g, h, i, j, k = r.css(a, "position"), l = r(a), m = {}; "static" === k && (a.style.position = "relative"), h = l.offset(), f = r.css(a, "top"), i = r.css(a, "left"), j = ("absolute" === k || "fixed" === k) && (f + i).indexOf("auto") > -1, j ? (d = l.position(), g = d.top, e = d.left) : (g = parseFloat(f) || 0, e = parseFloat(i) || 0), r.isFunction(b) && (b = b.call(a, c, r.extend({}, h))), null != b.top && (m.top = b.top - h.top + g), null != b.left && (m.left = b.left - h.left + e), "using" in b ? b.using.call(a, m) : l.css(m) } }, r.fn.extend({ offset: function (a) { if (arguments.length) return void 0 === a ? this : this.each(function (b) { r.offset.setOffset(this, a, b) }); var b, c, d, e, f = this[0]; if (f) return f.getClientRects().length ? (d = f.getBoundingClientRect(), d.width || d.height ? (e = f.ownerDocument, c = Sb(e), b = e.documentElement, { top: d.top + c.pageYOffset - b.clientTop, left: d.left + c.pageXOffset - b.clientLeft }) : d) : { top: 0, left: 0 } }, position: function () { if (this[0]) { var a, b, c = this[0], d = { top: 0, left: 0 }; return "fixed" === r.css(c, "position") ? b = c.getBoundingClientRect() : (a = this.offsetParent(), b = this.offset(), r.nodeName(a[0], "html") || (d = a.offset()), d = { top: d.top + r.css(a[0], "borderTopWidth", !0), left: d.left + r.css(a[0], "borderLeftWidth", !0) }), { top: b.top - d.top - r.css(c, "marginTop", !0), left: b.left - d.left - r.css(c, "marginLeft", !0) } } }, offsetParent: function () { return this.map(function () { var a = this.offsetParent; while (a && "static" === r.css(a, "position")) a = a.offsetParent; return a || pa }) } }), r.each({ scrollLeft: "pageXOffset", scrollTop: "pageYOffset" }, function (a, b) { var c = "pageYOffset" === b; r.fn[a] = function (d) { return S(this, function (a, d, e) { var f = Sb(a); return void 0 === e ? f ? f[b] : a[d] : void (f ? f.scrollTo(c ? f.pageXOffset : e, c ? e : f.pageYOffset) : a[d] = e) }, a, d, arguments.length) } }), r.each(["top", "left"], function (a, b) { r.cssHooks[b] = Na(o.pixelPosition, function (a, c) { if (c) return c = Ma(a, b), Ka.test(c) ? r(a).position()[b] + "px" : c }) }), r.each({ Height: "height", Width: "width" }, function (a, b) { r.each({ padding: "inner" + a, content: b, "": "outer" + a }, function (c, d) { r.fn[d] = function (e, f) { var g = arguments.length && (c || "boolean" != typeof e), h = c || (e === !0 || f === !0 ? "margin" : "border"); return S(this, function (b, c, e) { var f; return r.isWindow(b) ? 0 === d.indexOf("outer") ? b["inner" + a] : b.document.documentElement["client" + a] : 9 === b.nodeType ? (f = b.documentElement, Math.max(b.body["scroll" + a], f["scroll" + a], b.body["offset" + a], f["offset" + a], f["client" + a])) : void 0 === e ? r.css(b, c, h) : r.style(b, c, e, h) }, b, g ? e : void 0, g) } }) }), r.fn.extend({ bind: function (a, b, c) { return this.on(a, null, b, c) }, unbind: function (a, b) { return this.off(a, null, b) }, delegate: function (a, b, c, d) { return this.on(b, a, c, d) }, undelegate: function (a, b, c) { return 1 === arguments.length ? this.off(a, "**") : this.off(b, a || "**", c) } }), r.parseJSON = JSON.parse, "function" == typeof define && define.amd && define("jquery", [], function () { return r }); var Tb = a.jQuery, Ub = a.$; return r.noConflict = function (b) { return a.$ === r && (a.$ = Ub), b && a.jQuery === r && (a.jQuery = Tb), r }, b || (a.jQuery = a.$ = r), r
});

//tool.js
var g_selectReady = true;
var NS = {
    Register: function () {
        // body...
        var arg = arguments[0];
        var arr = arg.split('.');
        var context = window;
        for (var i = 0; i < arr.length; i++) {
            var str = arr[i];
            if (!context[str]) {
                context[str] = {};
            }
            context = context[str];
        };
    },
    REG: function () {
        Register();
    }
};

//#框架加载器
var g_moudel = "sys";// "{g_moudel}";
if (g_moudel === "{g_moudel}") {
    alert("警告:没有为模块在配置值:g_moudel");
    throw SyntaxError("警告:没有为模块在配置值:g_moudel");
}
var _c = {
    security: {
        encrypt_key: "xyj",
        decrypt_key: "xyj",
        expire: 7
    },
    dir: {
        app: "/addons/" + g_moudel + "/template", //注意末尾不能有/
        pc: "/addons/" + g_moudel + "/template" //注意末尾不能有/
    },
    runtime: {
        debug: true,
        fake: false,
        warn: true,
        third_login: false,
        is_win10: true,
        route: [
            { src: "/sports/crud/", target: "" },
            { src: "/sports/admin/", target: "" }
        ],
        url: window.location.pathname
    },
    sever: {
        host: "http://localhost:1649",//"http://139.199.205.245:8080", //业务服务器
        cdn: "http://cdn.qxamoy.com/xyj.framwork",
        host_sys: "http://localhost:1649",// "http://139.199.205.245:8080",//框架服务器[登陆,权限,报表]
        host_wx: "http://localhost:1649"//"http://139.199.205.245:8080" //微信服务器
    }

};

_c.app = {
    login: _c.dir.app + "/pages/login-m.html",
    login_auto: _c.dir.app + "/pages/login-auto-m.html",
    homepage: _c.dir.app + "/mobile/index.html",
    login_third: "we7"
    //bind: _c.dir.app + "/pages/bind-m.html",
    //wx_login: _c.sever.host_wx + "/WeChat/Web/Authorize?return_url=" + window.location.origin + g_login_wx, //微信自动登陆
    //pay_wx: _c.sever.host_wx + "/WeChat/WeChatPay/JsApiPayPage", //微信支付回调
    //pay_result_wx: window.location.origin + "/web/app/wxpay/charge-result.html?subSystem=system", //微信授权回调
    //wx: _c.sever.host + "/WeChat/WeChatPay/JsApiPayPage", //微信授权
    //charge_wx: "/web/app/" + g_app + "/framework-m/" + "charge.html", //充值
    //charge_result_wx: "/web/app/" + g_app + "/framework-m/" + "charge-result.html", //充值结果
    //wallet_wx: "/web/app/" + g_app + "/framework-m/" + "wallet.html", //钱包
    //withdraw_wx: "/web/app/" + g_app + "/framework-m/" + "-withdraw.html" //提现
};
_c.isDebug = _c.runtime.debug;
_c.isWin10 = _c.runtime.is_win10;
_c.pc = {
    login: _c.dir.pc + "/pages/login.html",
    login_auto: _c.dir.pc + "/pages/login-auto.html",
    homepage: _c.dir.pc + (_c.isWin10 ? "/pages/index-win10.html" : "/pages/index.html"),
    login_third: "we7",
    local_res: _c.dir.pc + "/web/",
    leftmenu: true,
    topmenu: false,
    form: _c.dir.pc + "/pages/form.html",
    report: _c.dir.pc + "/pages/report.html"
};
_c.cm = {
    loading: _c.dir.pc + "/pages/loading.html"
}

_c.isApp = (window.location.pathname.toLowerCase() == _c.app.login_auto || window.location.pathname.toLowerCase() == _c.app.login)//当前页面是移动端自动登陆页
    ? true
    : (window.location.pathname.toLowerCase() == _c.pc.login_auto || window.location.pathname.toLowerCase() == _c.pc.login)//当前页面是pc端自动登陆页
    ? false
    : (_c.dir.app !== "" && window.location.pathname.toLowerCase().indexOf("/mobile/") > -1);
_c.root = _c.isApp ? _c.dir.app : _c.dir.pc;
_c.login = _c.isApp ? _c.app.login : _c.pc.login;
_c.login_auto = _c.isApp ? _c.app.login_auto : _c.pc.login_auto;
_c.homepage = _c.isApp ? _c.app.homepage : _c.pc.homepage;
_c.login_third = _c.runtime.third_login ? (_c.isApp ? _c.app.login_third : _c.pc.login_third) : "";
//_c.pc.login_3rd_result = _c.dir.pc +"/pages/login-3rd-result.html";
//_c.pc.login_3rd = _c.sever.host + "/Oauth2/YiBan?returnUrl=" +localUrl(_c.pc.login_3rd_result);
//_c.pc.login_out_3rd = _c.sever.host + "/Json/Login/Logout?returnUrl=" + ;


_c.route = function (srcurl) {
    var url = (srcurl + "").replace("//", "/").toLowerCase();

    for (var i = 0; i < _c.runtime.route.length; i++) {//兼容旧版程序，路由映射
        var item = _c.runtime.route[i];
        if (url.indexOf(item.src) > -1) {//只要替换成功就跳出
            url = url.replace(item.src, item.target);
            break;
        }
    }
    return url;
};

//判断是否有值
_c.hasValue = function (value) {
    if (typeof (value) == "undefined")
        return false;
    if (typeof (value) == "function")
        return true;
    value = _c.isString(value) ? value.replace(_c.root, "") : value;
    return (value === "；" || value === ";" || value === "empty" || value === "#" || value === null || value == "undefined" || value === '' || value.length === 0) ? false : true;
}
//判断是否有值
_c.checkValue = function (obj, valueIfEmpty) {
    if (!_c.hasValue(obj))
        obj = valueIfEmpty;
    return obj;
}
//判断是否是函数
_c.isFunction = function (obj) {
    try {
        if (typeof obj === "function") { //是函数    其中 FunName 为函数名称
            return true;
            // alert("is function");
        } else { //不是函数
            // alert("not is function");
            return false;
        }
    } catch (e) { }
    return false;
}
//判断函数是否存在
_c.hasFunction = function (funcName) {
    try {
        if (typeof (eval(funcName)) == "function") {
            return true;
        }
    } catch (e) { }
    return false;
}
_c.doFunction = function (funcName, param) {

    if (_c.hasFunction(funcName)) {
        try {
            eval(funcName + "(" + (param == undefined ? "" : "'" + param.replace(/[\r\n]/g, "") + "'") + ")");
        } catch (ex) {
            _c.log(ex);
            _c.alert(funcName + "()函数执行出错,打开控制台查看详细信息:<br/>" + ex.message);
        }
    } else {
        _c.warn("在本页面中未找到" + funcName + "函数:");
    }
}
//对象转数组
_c.toArray = function (obj) {
    var title = [];
    var bodyRow = [];
    for (var p in obj) {//遍历对象属性和值
        if (typeof (obj[p]) != "function") {
            title.push(p);
            bodyRow.push(obj[p]);
        } else {
            //item[p]();
        }
    }
    return { p: title, v: bodyRow };
}//判断变量是否为数组
_c.isArray = function (o) {
    return Object.prototype.toString.call(o) === '[object Array]' && !_c.isObject(o);
}//判断变量是否为数组
_c.isObject = function (o) {
    if (o instanceof Array) {
        return false;//'Array'
    } else if (o instanceof Object) {
        return true;//'Object';
    } else {
        return false;//'param is no object type';
    }

}
_c.isArray2 = function (o) {
    return (_c.isArray(o) && o.length > 0 && _c.isArray(o[0]));
}//判断变量是否为字符串
_c.isString = function (str) {
    return (typeof str == 'string') && str.constructor == String;
}
_c.isInt = function (x) {

    try {
        var t = Number(x);
        return (typeof t === 'number') && (x % 1 === 0);
    } catch (ex) {
        return false;
    }


}
_c.ajax = function () {
    var ajaxData = {
        type: arguments[0].type || "GET",
        url: arguments[0].url || "",
        async: arguments[0].async || "true",
        data: arguments[0].data || null,
        dataType: arguments[0].dataType || "text",
        contentType: arguments[0].contentType || "application/x-www-form-urlencoded",
        beforeSend: arguments[0].beforeSend || function () { },
        success: arguments[0].success || function () { },
        error: arguments[0].error || function () { },
        complete: arguments[0].complete || function () { }
    }
    ajaxData.beforeSend();

    var xhr = (window.ActiveXObject ? new ActiveXObject("Microsoft.XMLHTTP") : new XMLHttpRequest());
    xhr.responseType = ajaxData.dataType;
    xhr.open(ajaxData.type, ajaxData.url, ajaxData.async);
    xhr.setRequestHeader("Content-Type", ajaxData.contentType);

    if (typeof ajaxData.data === 'object') {
        var convertResult = "";
        for (var c in ajaxData.data) {
            convertResult += c + "=" + ajaxData.data[c] + "&";
        }
        convertResult = convertResult.substring(0, convertResult.length - 1);
        xhr.send(convertResult);
    } else {
        xhr.send(ajaxData.data);
    }
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {

            ajaxData.complete();
            if (xhr.status == 200) {
                ajaxData.success(xhr.response);
            } else {
                ajaxData.error();
            }
        }
    }
}
_c.getFileName = function (path) {
    var dest = path.split("-split-")[1];
    // var dest = path.substring(path.lastIndexOf('/')+1).split("-split-")[0];

    return _c.hasValue(dest) ? decodeURI(dest) : "";
}
// 转为对象 
_c.toJson = function (obj) {
    return JSON.stringify(obj);
}
// 转为json  
_c.toObject = function (jsonString) {
    if (jsonString == undefined) {
        return "";
    }
    jsonString = jsonString.replace(/\n/g, "");
    return JSON.parse(jsonString);
}
// 批量替换  
_c.replace = function (str, arr) {
    // 
    if (!_c.hasValue(str)) return "";
    if (_c.isArray(arr) && arr.length > 0 && !_c.isArray(arr[0])) {
        arr = [arr];
    }

    for (var i = 0; i < arr.length; i++) {
        var item = arr[i];
        while (str.indexOf(item[0]) > -1) {
            str = str.replace(item[0], item[1]);
        }
    }
    return str;
}
// 加密算法可以公开  
_c.encrypt = function (plainText, key) {
    if (key == undefined) {
        key = g_encrypt_key;
    }
    return plainText ^ key;
}
// 解密算法也可以公开  
_c.decrypt = function (cipherText, key) {
    if (key == undefined) {
        key = g_decrypt_key;
    }
    return cipherText ^ key;
}
_c.notEmpty_m = function (nameArray, tip) {
    if (!_c.hasValue(tip)) {
        tip = "请将信息填写完整";

    }
    // 
    if (!_c.isArray(nameArray)) {
        nameArray = [nameArray];
    }
    for (var i = 0; i < nameArray.length; i++) {
        var v = _c.val_m(nameArray[i]);
        if (!_c.hasValue(v)) {
            _c.alert(tip);
            return false;
        }
    }
    return true;
}
_c.hasElem = function (array, targetElem, key) {
    for (var i = 0; i < array.length; i++) {
        {
            var item = array[i];
            if (item[key] == targetElem[key]) {
                return true;
            }
        }
    }
    return false;
}
_c.pushRange = function (array, targetArray) {
    if (!_c.hasValue(targetArray)) {
        targetArray = [];
    }
    var result = [];
    for (var i = 0; i < array.length; i++) {
        {
            var item = array[i];
            result.push(item);
        }
    }
    for (var j = 0; j < targetArray.length; j++) {
        {
            var item = array[j];
            result.push(item);
        }
    }
    return result;
}
_c.union = function (array, targetArray, key, doBeforeCompare) {
    var result = _c.pushRange(array);
    for (var i = 0; i < targetArray.length; i++) {
        {
            var item = targetArray[i];
            item = _c.hasValue(doBeforeCompare) ? doBeforeCompare(item) : item;
            if (!_c.hasElem(array, item, key)) {
                result.push(item);
            }
        }
    }
    return result;
}
_c.intersect = function (array, targetArray, key, doBeforeCompare) {
    var result = [];
    for (var i = 0; i < array.length; i++) {
        {
            var item = array[i];
            item = _c.hasValue(doBeforeCompare) ? doBeforeCompare(item) : item;
            if (_c.hasElem(targetArray, item, key)) {
                result.push(item);
            }
        }
    }
    return result;
}
_c.except = function (array, targetArray, key, doBeforeCompare) {
    var result = [];
    for (var i = 0; i < array.length; i++) {
        {
            var item = array[i];
            item = _c.hasValue(doBeforeCompare) ? doBeforeCompare(item) : item;

            if (!_c.hasElem(targetArray, item, key)) {
                result.push(item);
            }
        }
    }
    return result;
}
//模板
_c.qx_tpl = function (obj, tplFn) {
    return getTpl(tplFn).format(obj);
}
_c.sleep = function (millis, fn) {
    var intervalId = setInterval(function () {
        {
            fn();
            clearInterval(intervalId);
        }
    }, millis);
}
//获取网页
_c.getsubmiturl = function () {
    //thisURL = document.URL;     // http://localhost:81/Test/1.htm?Did=123
    //thisHREF = document.location.href; // http://localhost:81/Test/1.htm?Did=123
    //thisSLoc = self.location.href;   // http://localhost:81/Test/1.htm?Did=123
    //thisDLoc = document.location;   // http://localhost:81/Test/1.htm?Did=123

    //thisTLoc = top.location.href;   // http://localhost:81/Test/1.htm?Did=123
    //thisPLoc = parent.document.location;// http://localhost:81/Test/1.htm?Did=123
    //thisTHost = top.location.hostname; // localhost
    //thisHost = location.hostname;   // localhost

    //thisU1 = window.location.protocol; // http:
    //thisU2 = window.location.host;   // localhost:81
    //thisU3 = window.location.pathname; // /Test/1.htm
    // 
    var fullUrl = document.URL;
    var hostProtal = window.location.protocol + "//" + window.location.host;
    var relativeUrl = fullUrl.replace(hostProtal, "").
        replace("/pages/form.html?id=", "").
        replace("#", "");
    if (relativeUrl.length > 0 && relativeUrl[0] == '/') {
        relativeUrl = relativeUrl.substring(1);
    }
    return "/" + relativeUrl;
}
//获取网页
_c.geturl = function () {
    //thisURL = document.URL;     // http://localhost:81/Test/1.htm?Did=123
    //thisHREF = document.location.href; // http://localhost:81/Test/1.htm?Did=123
    //thisSLoc = self.location.href;   // http://localhost:81/Test/1.htm?Did=123
    //thisDLoc = document.location;   // http://localhost:81/Test/1.htm?Did=123

    //thisTLoc = top.location.href;   // http://localhost:81/Test/1.htm?Did=123
    //thisPLoc = parent.document.location;// http://localhost:81/Test/1.htm?Did=123
    //thisTHost = top.location.hostname; // localhost
    //thisHost = location.hostname;   // localhost

    //thisU1 = window.location.protocol; // http:
    //thisU2 = window.location.host;   // localhost:81
    //thisU3 = window.location.pathname; // /Test/1.htm
    return window.location.pathname;
}
//获取完整网页
_c.getfullurl = function (encodeUrl, extraParam) {
    //thisURL = document.URL;     // http://localhost:81/Test/1.htm?Did=123
    //thisHREF = document.location.href; // http://localhost:81/Test/1.htm?Did=123
    //thisSLoc = self.location.href;   // http://localhost:81/Test/1.htm?Did=123
    //thisDLoc = document.location;   // http://localhost:81/Test/1.htm?Did=123

    //thisTLoc = top.location.href;   // http://localhost:81/Test/1.htm?Did=123
    //thisPLoc = parent.document.location;// http://localhost:81/Test/1.htm?Did=123
    //thisTHost = top.location.hostname; // localhost
    //thisHost = location.hostname;   // localhost

    //thisU1 = window.location.protocol; // http:
    //thisU2 = window.location.host;   // localhost:81
    //thisU3 = window.location.pathname; // /Test/1.htm
    var src = document.URL;
    src = src.replace(/undefined/g, "empty");
    return _c.hasValue(encodeUrl) ? encodeURIComponent(src + extraParam) : src;
}
_c.addparam = function (name, value) {
    var currentUrl = window.location.href.split('#')[0];
    if (/\?/g.test(currentUrl)) {
        if (/name=[-\w]{4,25}/g.test(currentUrl)) {
            currentUrl = currentUrl.replace(/name=[-\w]{4,25}/g, name + "=" + value);
        } else {
            currentUrl += "&" + name + "=" + value;
        }
    } else {
        currentUrl += "?" + name + "=" + value;
    }
    if (window.location.href.split('#')[1]) {
        window.location.href = currentUrl + '#' + window.location.href.split('#')[1];
    } else {
        window.location.href = currentUrl;
    }
}
//用户标识
_c.uid = function (uid) {
    if (uid == undefined) {//read
        uid = _c.cookie("uid");
        if (!_c.hasValue(uid)) {
            try {
                uid = _c.q("uid");
            } catch (ex) {
                //清除cookie
                _c.cookie();
            }
        }
        return uid;
    } else {//write
        _c.cookie("uid", uid);
    }
}
//用户标识
_c.user_id = function () {
    return _c.cookie("user_id");
}
_c.user = function () {
    return { uid: _c.cookie("user_id"), name: _c.cookie("nick_name"), unit: _c.cookie("unit_name") };
}
_c.cookie = function (name, value, time) {
    if (time == undefined) {
        time = "d" + _c.security.expire;//默认*天过期
    }
    //设置过期时间
    var str = time;
    var str1 = str.substring(1, str.length) * 1;
    var str2 = str.substring(0, 1);
    if (str2 == "s") {
        time = str1 * 1000;
    } else if (str2 == "h") {
        time = str1 * 60 * 60 * 1000;
    } else if (str2 == "d") {
        time = str1 * 24 * 60 * 60 * 1000;
    }


    if (name == undefined) {
        //  
        //清除
        var keys = document.cookie.match(/[^ =;]+(?=\=)/g);
        if (keys) {
            for (var i = keys.length; i--;) {
                _c.cookie(keys[i], "", "d0");
            }
        }
    } else if (value == undefined) {//read
        var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
        if (arr = document.cookie.match(reg))
            return unescape(arr[2]);
        else
            return null;
    } else {//write
        var exp = new Date();
        exp.setTime(exp.getTime() + time * 1);
        //
        document.cookie = name + "=" + escape(value) + ";expires=" + exp.toGMTString() + ";path=/;";
    }
}
//用户单位
_c.unitid = function (unitid) {
    if (unitid == undefined) {
        unitid = _c.cookie("unitid");
        if (unitid == undefined) {
            try {
                unitid = _c.q("unitid");
            } catch (ex) {
                unitid = "";
            }

        }
        return unitid;
    } else {
        _c.cookie("unitid", unitid);
    }
}
_c.parsedate = function (str) {
    try {

        // _c.log(str)
        if (str.length > 10) {
            str = str.substring(0, 10);
        }
        var d = new Date(Date.parse(str.replace(/-/g, "/").replace(/T/g, " ")));
        var year = d.getFullYear();
        var month = d.getMonth() + 1;
        var day = d.getDate();
        var dateStr = year + "-" +
            (month < 10 ? "0" + month : month) + "-" +
            (day < 10 ? "0" + day : day);
        return dateStr;
    } catch (e) {
        _c.warn("日期转换异常:" + e);
        return str;
    }
}
_c.parsetime = function (str) {
    try {
        //  
        //_c.log(str)
        var d = new Date(Date.parse(str.replace(/-/g, "/").replace(/T/g, " ")));
        var year = d.getFullYear();
        var month = d.getMonth() + 1;
        var day = d.getDate();
        var hour = d.getHours();
        var minute = d.getMinutes();
        var second = d.getSeconds();
        var dateStr = year + "-" +
            (month < 10 ? "0" + month : month) + "-" +
            (day < 10 ? "0" + day : day) + " " +
            (hour < 10 ? "0" + hour : hour) + ":" +
            (minute < 10 ? "0" + minute : minute);
        //    + ":" +  (second < 10 ? "0" + second : second);
        return dateStr;
    } catch (e) {
        _c.warn("时间转换异常:" + e);
        return str;
    }
}
//随机码
_c.random = function () {
    return Guid.random();
}
//跳转网页
_c.go = function (url, waitSecond) {
    if (waitSecond >= 3) {
        waitSecond--;
    }
    if (!_c.hasValue(waitSecond)) waitSecond = 0;
    setTimeout(function () {
        if (_c.isInt(url)) {
            history.go(url);
            return;
        }
        //防止_c.q出错
        url = url.replace(/undefined/g, "empty");
        location.href = url;
    }, waitSecond * 1000);
}
//转换网页
_c.url = function (url, isFramWorkUrl) {
    if (_c.hasValue(isFramWorkUrl) && isFramWorkUrl === true) {//是框架网址i
        return _c.sever.host_sys + url;
    }
    return (("" + url).length > 4) && (("" + url).toLowerCase().substring(0, 4) === "http") ? url : _c.sever.host + url;

}
//转换资源地址
_c.cdn = function (url) {
    return _c.sever.cdn + url;
}
//转换路由地址
_c.parseurl = function (url, type) {

    // //
    var result = {};
    result.url = url;
    result.type = type;
    if (url.indexOf("@") > -1) {
        //crud
        result.destUrl = url;
        result.destType = "@";
    }
    else if (url.indexOf("http") > -1) {
        //http
    } else if (url.indexOf("*r") > -1) {
        //report
        result.destUrl = _c.pc.report + "?id=" + url.replace("*r", "");
        result.destType = "r";
    }
    else if (url.indexOf("*d") > -1 || url.indexOf("删除") > -1 || url.toLowerCase().indexOf("delete") > -1) {
        //delete
        result.destUrl = 'confirmDo' + url.replace('*d', '');
        result.destType = "d";
    } else if (url.indexOf("*h") > -1) {
        //html
        result.destUrl = (_c.res(url.replace('*h', "")) + ".html?uid=" + _c.uid() + "&unitid=" + _c.unitid());
        result.destType = "h";
    } else if (url.indexOf("*f") > -1) {
        //form 
        result.destUrl = (_c.pc.form + "?id=" + url.replace('*f', ""));
        result.destType = "f";
    } else {
        //_c.log(type)
        if (type != undefined) {
            switch (type) {
            case "http":
                {
                    //http
                };
                break;
            case "h":
                {
                    //html
                    result.destUrl = (_c.res(url.replace('*h', "")) + ".html?uid=" + _c.uid());
                    result.destType = "h";
                };
                break;
            case "f":
                {
                    //form 
                    result.destUrl = (_c.pc.form + "?id=" + url.replace('*f', ""));
                    result.destType = "f";

                };
                break;
            }

        } else {
            //report
            result.destUrl = _c.pc.report + "?id=" + url;
            result.destType = "r";
        }
    }
    return result;//_c.trim(url);
}
//清除空格
_c.trimString = function (s, isGlobal) {
    if (s == undefined) {
        return "";
    }
    s = s + "";

    s = s.replace(/(^\s+)|(\s+$)/g, "");
    s = s.replace(/\s/g, "");
    return s;
}
//本地资源
_c.res = function (url) {
    if (url[0] == "/") {//去除第一个/
        url = url.substring(1);
    }

    return _c.root + url;
}
//获取body
_c.body = function (html) {
    return html.substring(html.indexOf("<body>") + 6, html.indexOf("</body>"));

}
//打印日志
_c.log = function (obj) {
    if (_c.isDebug) {
        console.log(obj);
    }

}
//打印警告
_c.warn = function (obj) {
    if (_c.isDebug) {
        console.warn(obj);
    }
}
//根据配置生成selectHtml
_c.getOptionHtml = function (data, value, addDefaultOption) {
    if (!_c.hasValue(addDefaultOption)) {
        addDefaultOption = false;
    }
    if (typeof data == "string") {
        if (data.length <= 0) {
            return "";
        }//转换为对象
        data = _c.toObject(data);
    }
    var optionHtml = [];

    if (addDefaultOption) {
        optionHtml.push('<option value=";">全部</option>');
    }

    for (var i = 0; i < data.length; i++) {
        //
        var _v = _c.hasValue(data[i].value) ? data[i].value : data[i].Value;
        var _t = _c.hasValue(data[i].text) ? data[i].text : data[i].Text;
        // 
        optionHtml.push('<option ' + (value == _v ? 'selected="selected"' : '') + ' value="' + _v + '">' + _t + '</option>');
    }
    return optionHtml.join('');
}
//获取地址栏参数
_c.q = function (name) {
        // // 
        var currntUrl = _c.getfullurl();
        //特殊处理
        if (currntUrl.indexOf(_c.pc.form) > 0 || currntUrl.indexOf(_c.pc.report) > 0) {
            return currntUrl.substr(currntUrl.indexOf("?id=") + 4);
        }
        //-------------
        var data = {};
        var aPairs, aTmp;
        var queryString = new String(window.location.search);
        queryString = queryString.substr(1, queryString.length); //remove   "?"     
        aPairs = queryString.split("&");
        for (var i = 0; i < aPairs.length; i++) {
            aTmp = aPairs[i].split("=");
            data[aTmp[0]] = aTmp[1];
        }
        return data[name];
    },
    _c.qall = function (s) {
        var url = s.replace(/\s/g, ""); //获取url中"?"符后的字串 
        var theRequest = new Object();
        if (url.indexOf("?") != -1) {
            var str = url.substr(1);
            strs = str.split("&");
            for (var i = 0; i < strs.length; i++) {
                theRequest[strs[i].split("=")[0]] = unescape(strs[i].split("=")[1]);
            }
        }
        return theRequest;
    },
    _c.htmlEncode = function (html) {
        return HtmlUtil.htmlEncodeByRegExp(html);
    }
_c.htmlDecode = function (html) {
    return HtmlUtil.htmlDecodeByRegExp(html);
}
_c.click = function (id, fn) {
    var dom = document.getElementById(id);
    if (_c.hasValue(dom)) {
        dom.onclick = function () {
            fn(this);//  this 指当前发生事件的HTML元素
        }
    }
}
_c.cleanPage = function () {

    var doms = document.getElementsByTagName("body");
    var dom = document.getElementById("body");
    if (_c.hasValue(doms) && doms.length > 0) {
        dom = doms[0];
    }
    if (_c.hasValue(doms)) {
        dom.innerHTML = "";
    }

}
_c.isAutoLoginPage = function () {
    return _c.geturl() === _c.app.login_auto || _c.geturl() === _c.pc.login_auto;
};
_c.isLoadingPage = function () {
    return _c.runtime.url === _c.cm.loading;
};
_c.isLoginPage = function () {
    return _c.geturl() === _c.login;
};
_c.isHomePage = function () {
    return _c.geturl() === _c.homepage;
};
_c.isVisitor = function () {
    return !_c.isLoginPage() && !_c.isLoadingPage() && !_c.isAutoLoginPage() &&
        (!_c.hasValue(_c.unitid()) || !_c.hasValue(_c.uid()));
};
_c.loadLib = function (srcArray) {
    head.ready(function () {
        head.load(srcArray);
    });
}
_c.loadCoreLib = _c.isVisitor() || _c.isLoginPage() || _c.isLoadingPage() || _c.isAutoLoginPage();


function localUrl(url) {
    return window.location.protocol + "//" + window.location.host + _c.dir.pc + url;
};
function srcurl(src, folder) {

    //1.框架文件（framework目录）  2.程序文件（web目录）   3.cdn资源(调用时无folder参数)
    //自动补齐
    if (folder == undefined) {//3

        if (_c.sever.cdn.indexOf("http") > -1) { //远程cdn
            folder = _c.sever.cdn + "/vendor/";
        } else {//本地cdn
            folder = ((_c.sever.cdn === "/" || _c.sever.cdn === "") ? "/vendor/" : _c.root)
        }
    } else {//1,2
        folder = _c.root + folder;
    }
    var version = "";
    //添加版本号
    if (src.indexOf("head-js") > -1 || folder.indexOf("web") > -1) {
        var now = new Date();
        var number = now.getYear().toString() + now.getMonth().toString() + now.getDate().toString() + now.getHours().toString() + now.getMinutes().toString() + now.getSeconds().toString();
        version = "?v=" + number;
    }
    return folder + src + version;

};
_c.app.lib = {
    src: [
        //layui
        srcurl("layui-m/2.0/need/layer.css"),
        //jquery-weui
        //srcurl("jquery-weui/lib/weui.min.css"),
        //srcurl("jquery-weui/css/jquery-weui.css"),
        //srcurl("jquery-weui/demos/css/demos.css"),
        { "core-jquery": srcurl("jquery/jquery.min.js") },
        //jquery-weui
        { "fastclick": srcurl("jquery-weui/lib/fastclick.js") },
        //{ "jquery-weui": srcurl("jquery-weui/js/jquery-weui.js") },
        //layui
        { "core-layui": srcurl("layui-m/2.0/layer.js") }//,
        //framework
        // { "tools": srcurl("tools.js","/plugin/") } //,
        //{ "form-tool": srcurl("framework-m/js/form-tool.js", "/web/app/bx/") }
    ],
    ready: function () {
        // FastClick.attach(document.body);
    }
};

_c.pc.lib = {
    src: [
        //----------------css

        //sb2-datatables-plugins
        srcurl("sb2/css/plugins/dataTables/dataTables.bootstrap.css"),
        //win10-ui
        srcurl("win10-ui/css/animate.css"),
        srcurl("win10-ui/css/default.css"),
        srcurl("win10-ui/component/drawer/shortcut-drawer.min.css"),
        srcurl("win10-ui/component/font-awesome-4.7.0/css/font-awesome.min.css"),
        srcurl("win10-ui/plugins/theme_switcher/theme_switcher.css"),
        //bootstrap-switch
        srcurl("bootstrap-switch/static/stylesheets/bootstrap-switch.css"),
        srcurl("bootstrap-switch/static/stylesheets/bootstrap-switch-conquer.css"),
        srcurl("bootstrap-switch/static/stylesheets/flat-ui-fonts.css"),
        //bootstrap-datetime
        srcurl("bootstrap-datetimepicker/css/datetimepicker.css"),
        //bootstrap-daterangepicker
        srcurl("bootstrap-daterangepicker/daterangepicker-bs3.css"),
        //form-validation 
        srcurl("bootstrap-validator/0.5.3/css/bootstrapValidator.css"),

        //umeditor
        srcurl("umeditor/themes/default/css/umeditor.css"),
        //fileUpload

        srcurl("fileUpload/file/css/jquery.fileupload.css"),
        srcurl("fileUpload/file/css/blueimp-gallery.min.css"),
        srcurl("fileUpload/file/css/jquery.fileupload.css"),
        srcurl("fileUpload/file/css/jquery.fileupload-ui.css"),
        //sb2
        srcurl("sb2/css/bootstrap.min.css"),
        srcurl("sb2/font-awesome/css/font-awesome.css"),
        srcurl("sb2/css/sb-admin.css"),
        //app
        srcurl("app.css", "/plugin/"),
        srcurl("app-blue.css", "/plugin/"),



        //----------------js
        //sb2
        { "sb2-jquery": srcurl("sb2/js/jquery-1.10.2.js") },
        { "sb2-bootstrap": srcurl("sb2/js/bootstrap.min.js") },
        { "sb2-metisMenu": srcurl("sb2/js/plugins/metisMenu/jquery.metisMenu.js") },

        //sb2-jquery-dataTables
        { "sb2-jquery-dataTables": srcurl("sb2/js/plugins/dataTables/jquery.dataTables.js") },
        //sb2-dataTables-bootstrap
        { "sb2-dataTables-bootstrap": srcurl("sb2/js/plugins/dataTables/dataTables.bootstrap.js") },
        //win10-ui
        { "win10-ui-core": srcurl("win10-ui/js/win10.js") },
        { "win10-ui-folder": srcurl("win10-ui/component/drawer/shortcut-drawer.min.js") },
        { "win10-ui-child": srcurl("win10-ui/js/win10.child.js") },
        { "win10-ui-wallpaper": srcurl("win10-ui/plugins/theme_switcher/theme_switcher.js") },
        //bootstrap-datetime 
        { "bootstrap-datetimepicker": srcurl("bootstrap-datetimepicker/js/bootstrap-datetimepicker.min.js") },
        { "bootstrap-datetimepicker-zh": srcurl("bootstrap-datetimepicker/js/locales/bootstrap-datetimepicker.zh-CN.js") },
        //form-validation
        { "form-validation": srcurl("bootstrap-validator/0.5.3/js/bootstrapValidator.js") },
        { "form-validation-zh": srcurl("bootstrap-validator/0.5.3/js/language/zh_CN.js") },
        //bootstrap-switch 
        { "bootstrap-switch": srcurl("bootstrap-switch/static/js/bootstrap-switch.min.js") },
        //echarts 
        { "bootstrap-switch": srcurl("echarts/3.5.2/echarts.min.js") },
        //umeditor
        { "umeditor-config": srcurl("umeditor/umeditor.config.js") },
        { "umeditor": srcurl("umeditor/umeditor.js") },
        { "umeditor-zh": srcurl("umeditor/lang/zh-cn/zh-cn.js") },
        //bootstrap-daterangepicker
        { "bootstrap-daterangepicker": srcurl("bootstrap-daterangepicker/daterangepicker.js") },
        { "bootstrap-daterangepicker-moment": srcurl("bootstrap-daterangepicker/moment.min.js") },
        //jquery.cookie
        //{ "jquery-cookie": srcurl("jquery/jquery.cookie.js") },
        //layui
        { "core-layui": srcurl("layui/3.1.1/layer/layer.js") },

        //importxls
        { "importxls-shim": srcurl("importxls/js/shim.js") },
        { "importxls-xls": srcurl("importxls/js/xls.js") },
        //exportxls
        //{ "exportxls": srcurl("exportxls/js/tableExport.js") },
        //export2
        { "export-xlsx-core": srcurl("tableExport.jquery.plugin/libs/js-xlsx/xlsx.core.min.js") },
        { "export-FileSaver": srcurl("tableExport.jquery.plugin/libs/FileSaver/FileSaver.min.js") },
        { "export-jspdf": srcurl("tableExport.jquery.plugin/libs/jsPDF/jspdf.min.js") },
        {
            "export-jspdf-autotable": srcurl(
                "tableExport.jquery.plugin/libs/jsPDF-AutoTable/jspdf.plugin.autotable.js")
        },
        { "export-html2canvas": srcurl("tableExport.jquery.plugin/libs/html2canvas/html2canvas.min.js") },
        { "export-tableExport": srcurl("tableExport.jquery.plugin/tableExport.js") },
        /*
            <script type="text/javascript" src="tableExport.jquery.plugin/libs/js-xlsx/xlsx.core.min.js"></script>
            <script type="text/javascript" src="tableExport.jquery.plugin/libs/FileSaver/FileSaver.min.js"></script>
          <script type="text/javascript" src="tableExport.jquery.plugin/libs/jsPDF/jspdf.min.js"></script>
          <script type="text/javascript" src="tableExport.jquery.plugin/libs/jsPDF-AutoTable/jspdf.plugin.autotable.js"></script>
          <script type="text/javascript" src="tableExport.jquery.plugin/libs/html2canvas/html2canvas.min.js"></script>
            <script type="text/javascript" src="tableExport.jquery.plugin/tableExport.js"></script>
        */
        //html-to-pdf
        { "exportxls-jspdf": srcurl("html-to-pdf/js/jspdf.min.js") },
        { "exportxls-html2canvas": srcurl("html-to-pdf/js/html2canvas.min.js") },
        //fileUpload
        { "widget": srcurl("fileUpload/file/js/vendor/jquery.ui.widget.js") },
        { "tmpl": srcurl("fileUpload/file/js/tmpl.min.js") },
        { "load-image": srcurl("fileUpload/file/js/load-image.all.min.js") },
        { "canvas-to-blob": srcurl("fileUpload/file/js/canvas-to-blob.min.js") },
        { "blueimp": srcurl("fileUpload/file/js/jquery.blueimp-gallery.min.js") },
        { "iframe": srcurl("fileUpload/file/js/jquery.iframe-transport.js") },
        { "fileupload": srcurl("fileUpload/file/js/jquery.fileupload.js") },
        { "fileupload-process": srcurl("fileUpload/file/js/jquery.fileupload-process.js") },
        { "fileupload-image": srcurl("fileUpload/file/js/jquery.fileupload-image.js") },
        { "fileupload-audio": srcurl("fileUpload/file/js/jquery.fileupload-audio.js") },
        { "fileupload-video": srcurl("fileUpload/file/js/jquery.fileupload-video.js") },
        { "fileupload-validate": srcurl("fileUpload/file/js/jquery.fileupload-validate.js") },
        { "fileupload-ui": srcurl("fileUpload/file/js/jquery.fileupload-ui.js") },
        //framework
        { "importxls-acc": srcurl("importxls/js/excel.acc.js") },
        { "app-extension-pc": srcurl("app.extension.pc.js", "/plugin/") }
    ],
    ready: function () {

    }
};

_c.lib = function () {
    var all = _c.isApp ? _c.app.lib : _c.pc.lib;
    if (_c.loadCoreLib) {
        var mini = [];
        for (var i = 0; i < all.src.length; i++) {
            var o = all.src[i];
            var key = "";

            if (_c.isObject(o)) {
                key = _c.toArray(o).p[0];
            }

            if (key.indexOf("core-") > -1) {
                mini.push(o);
            }
        }
        all.src = mini;
    };
    return all;
}

_c.tool = function () {
    //扩展String
    String.prototype.append = function (str, arr) {
        if (!_c.hasValue(arr)) {
            arr = [];
        }
        return this + _c.replace(str, arr);
    };
    String.prototype.jn =
        String.prototype.join = function (another, colnumnOrTable) {//如何判断传入的是列名还是表名？
            if (!_c.hasValue(colnumnOrTable)) {//自动补全目标表的列名 （和本库相关，后端框架会自动补全库名）
                colnumnOrTable = another.split('.')[1];
            }///else if (colnumnOrTable.indexOf(".") === -1) {//自动补全目标表的列名（和本库无关，colnumn传入的是目标表名）
            //    colnumnOrTable = colnumnOrTable + "." + another.split('.')[1];
            //}
            return this.append("&search.join:" + another + "=" + colnumnOrTable);
        };
    String.prototype.in = function (colnumn, arr) {
        return this.append("&search.in:" + colnumn + "=('" + arr.join("','") + "')");
    };
    String.prototype.eq =
        String.prototype.equal = function (colnumn, value) {
            return this.append("&search.equal:" + colnumn + "=" + value);
        };
    String.prototype.neq =
        String.prototype.notequal = function (colnumn, value) {
            return this.append("&search.notequal:" + colnumn + "=" + value);
        };
    String.prototype.bg =
        String.prototype.biger = function (colnumn, value) {
            return this.append("&search.biger:" + colnumn + "=" + value);
        };
    String.prototype.be =
        String.prototype.bigerequal = function (colnumn, value) {
            return this.append("&search.bigerequal:" + colnumn + "=" + value);
        };
    String.prototype.ls =
        String.prototype.less = function (colnumn, value) {
            return this.append("&search.less:" + colnumn + "=" + value);
        };
    String.prototype.le =
        String.prototype.lessequal = function (colnumn, value) {
            return this.append("&search.lessequal:" + colnumn + "=" + value);
        };
    String.prototype.lk =
        String.prototype.like = function (colnumn, value) {

            if (!_c.hasValue(value)) {//传入条件值为空等价于没有like条件
                return this;
            }
            return this.append("&search.like:" + colnumn + "=" + value, '\'');
        };
    String.prototype.gp =
        String.prototype.group = function (colnumn, value) {
            if (!_c.hasValue(value)) {
                value = "_auto";
            }
            return this.append("&search.groupby:" + colnumn + "=" + value);
        };
    String.prototype.ob =
        String.prototype.orderby = function (colnumn, value) {
            if (!_c.hasValue(value)) {
                value = "+";
            }
            return this.append("&search.orderby:" + colnumn + "=" + value);
        };

    String.prototype.query = function (doAfterSuccess, autoToObject) {
        var url = this;
        $.Ajaxs(url, function (data) {
                // 
                var memberName = $.getMemberByUrl(url, true);
                var member = data[memberName];
                // 
                if (!_c.hasValue(member)) {
                    member = _c.hasValue(data) ? data : [];
                }
                doAfterSuccess(member);
            }, autoToObject
        );
    };
    String.prototype.submit = function (data, doAfterSuccess) {
        // 
        $.Ajax({
                url: this,
                data: data,
                success: function (data, code, msg, url) {
                    doAfterSuccess(data, code, msg, url);
                }
            }
        );
    };
    String.prototype.excute = function (doAfterSuccessForEach) {
        this.query(function (data) {
            for (var i = 0; i < data.length; i++) {
                var item = data[i];
                doAfterSuccessForEach(item, i, data.length);
            }
        });
    };
    String.prototype.format = function (args) {
        // 
        if (arguments.length > 0) {
            var result = this;
            var reg;
            if (arguments.length == 1 && typeof (args) == "object") {
                for (var key in args) {
                    if (!$.isInt(key)) {
                        reg = new RegExp("({" + key + "})", "g");
                        result = result.replace(reg, args[key]);
                    }
                }
            } else {
                for (var i = 0; i < arguments.length; i++) {
                    if (arguments[i] == undefined) { return ""; } else {
                        reg = new RegExp("({[" + i + "]})", "g");
                        result = result.replace(reg, arguments[i]);
                    }
                }
            } return result;
        } else { return this; }
    };
    //扩展string.tpl
    /*{}.prototype.tpl = function (tplFn) {
        return getTpl(tplFn).format(this);
    }*/
    //扩展Array
    //寻找重复元素
    Array.prototype.getdistinct = function () {
        // 遍历arr,把元素分别放入tmp数组(不存在才放)
        var tmp = new Array();
        var tmp2 = new Array();
        for (var i in this) {
            //该元素在tmp内部不存在才允许追加
            if (tmp.indexOf(this[i]) == -1) {
                tmp.push(this[i]);
            } else {
                {
                    if (tmp2.indexOf(this[i]) == -1) {
                        tmp2.push(this[i]);
                    }
                }
            }
        }
        return tmp2;
    };
    //去除重复元素
    Array.prototype.distinct = function () {
        // 遍历arr,把元素分别放入tmp数组(不存在才放)
        var tmp = new Array();
        for (var i in this) {
            //该元素在tmp内部不存在才允许追加
            if (tmp.indexOf(this[i]) == -1) {
                tmp.push(this[i]);
            }
        }
        return tmp;
    };

    //扩展jquery-使用命名空间定义函数

    $.extend({
        //ajax
        Ajax: function (cfg) {
            var showLoading = cfg.showLoading == undefined ? true : cfg.showLoading;
            cfg.url = ("" + cfg.url).toLowerCase();//转小写

            if (cfg.url.indexOf("@") > -1) {
                cfg.url = cfg.url.replace(/@/g, "-"); //ecampus.twxt.fake_api@add  
                if (cfg.url.indexOf("?cmd=") === -1) {
                    cfg.url = "/db/index?cmd=" + cfg.url; //ecampus.twxt.fake_api@add  
                }
            }

            var url = _c.url(cfg.url);

            //open下除文件api 其他转发到框架服务器
            if ((cfg.url.length > 6 && cfg.url.substring(0, 5) === "/open") &&//api为open系
                !(cfg.url.indexOf("/open/upload") > -1 || cfg.url.indexOf("/open/delete") > -1)) {//请求的不是文件api
                url = _c.url(cfg.url, true);
            }

            if (cfg.data == undefined) {
                cfg.data = {};
            }
            if (cfg.data.uid == undefined) {
                cfg.data.uid = _c.uid();
            }
            if (cfg.data.uname == undefined) {
                cfg.data.uname = _c.cookie("nick_name");
            }
            cfg.data.isDebug = _c.isDebug;
            cfg.data.unitid = _c.unitid();
            var lIndex = showLoading ? $.loading() : -1;

            $.ajax({
                type: "Post",
                url: url, //参数1
                data: cfg.data,
                success: function (response, status) {
                    if (showLoading) {
                        $.loaded(lIndex);
                    }
                    // //
                    try {
                        var result = response;
                        if (typeof (response) == "string") {
                            if (response.indexOf("<head") > 0) { //返回格式为html
                                $.dealError(url, "<p style='color:red;'>已成功与服务器取得连接,但服务器响应了错误格式的数据，这个格式疑似html代码,点击确认查看渲染后的视图</p>", result);

                                return;
                            } else { //返回格式为jsonString
                                result = _c.toObject(response);
                            }
                        } else { //返回格式为json
                            result = response;
                        }

                        if (result.code === -1) { //被服务器捕获的500错误
                            var errorMsg = _c.toObject(result.jsonData);
                            $.dealError(url, errorMsg.Message, errorMsg.StackTrace.replace(/\r\n/g, "<br/><br/>"));

                            return;
                        } else { //正常返回

                            var data = _c.toObject(result.jsonData);
                            cfg.success(data, result.code, result.msg, result.url);
                            return;
                        }
                    } catch (ex) {
                        $.dealError(ex.message, ex.message, ex.stack);
                    }

                },
                error: function (xmlHttpRequest, textStatus, errorThrown) {
                    $.loaded(lIndex);
                    // 

                    if (_c.isDebug) {
                        var errorData = xmlHttpRequest.responseText; //500错误时需要整体序列化
                        if (typeof (errorData) == "string") {
                            if (!_c.hasValue(xmlHttpRequest.responseText)) {
                                $.alert("服务器连接失败,请检查是否启动了服务器端,若问题依旧,请检查config.js中的 _c.sever.host配置项是否正确！", 2);
                                return;
                            } else {
                                $.dealError(url, "服务器错误:请确保服务器端代码已通过编译！", errorData);
                                return;
                            }
                        }

                        try { //服务器处理过的错误
                            var errorMsg = _c.toObject(errorData.jsonData);
                            $.dealError(url, errorMsg.Message, errorMsg.StackTrace.replace(/\r\n/g, "<br/><br/>"));
                        } catch (ex) { //致命错误
                            //
                            $.dealError(url, "服务器错误:请确保服务器已成功启动！", errorData);
                        }

                        //_c.log(errorMsg);
                        //_c.log(xmlHttpRequest.responseText);
                        //$.confirm("请求服务器的过程中出现错误,请检查:<br/>1.是否启动了服务器端<br/>2.服务器是否提供了正确的api<br/>3.检查config.js中的 _c.sever.host配置项是否正确<br/>4.若问题依旧,请点击确认查看详细错误信息", function () {
                        //    _c.go(url);
                        //}, 2);
                    } else {
                        $.alert("网络连接失败,请检查您的网络连接状态！", 5);
                    }
                }
            });
        },
        dealError: function (errorSrc, errorMessage, stack) {
            _c.warn(stack);
            $.alert("请求出错！点击确认查看详情<hr/><p style='color:red;'>" + errorMessage + "</p>", 2, function () {
                try {
                    //iframe窗
                    layer.open({
                        type: 1,
                        title: "来自" + errorSrc + "的详细错误信息",
                        closeBtn: 1, //不显示关闭按钮
                        shade: [0],
                        area: [600 + 'px', 450 + 'px'],
                        offset: 'rb', //右下角弹出
                        //time: 20000, //2秒后自动关闭
                        anim: 2,
                        skin: 'layer-ext-moon',
                        content: stack //errorMsg.StackTrace.replace(/\r\n/g, "<br/><br/>")
                    });
                } catch (ex) {
                    _c.warn("dealError函数依赖于layui");
                }

            });
        },
        dealAjax: function (data, code, msg, url) { //回调函数,result,返回值 
            // 
            switch (code) {
            case 1:
                {
                    $.msg(msg, code);
                };
                break;
            case 2:
                {
                    $.msg(msg, code);
                };
                break;
            case 3:
                {
                    $.confirm(msg, function () {
                        if (_c.hasValue(url)) {
                            _c.go(_c.parseurl(url).destUrl);
                        }
                    }, "", "", "", code);
                };
                break;
            case 5:
                {
                    $.confirm(msg, function () {
                        if (_c.hasValue(url)) {
                            _c.go(_c.parseurl(url).destUrl);
                        }
                    }, "", "", "", code);
                };
                break;
            case 6:
                {
                    $.confirm(msg, function () {
                        if (_c.hasValue(url)) {
                            _c.go(_c.parseurl(url).destUrl);
                        }
                    }, "", "", "", code);
                };
                break;
            case 7:
                {
                    $.confirm(msg, function () {
                        var index = parent.layer.getFrameIndex(window.name); //先得到当前iframe层的索引
                        parent.layer.close(index); //再执行关闭   
                        return true;
                    }, "", "", "", 3);
                };
                break;
            case 8:
                {
                    $.confirm(msg, function () {
                        layer.close();
                        return true;
                    }, "", "", "", 5);
                };
                break;
            case 9:
                { //下载文件
                    // // 

                    // _c.log(data.info);
                    // _c.log(data.name);
                    if (!_c.hasValue(data[data.name])) {
                        $.msg("用户没有上传文件", 0);
                        return;
                    }
                    $.ajax({
                        url: _c.url(data[data.name]),
                        success: function () {
                            _c.go($.url(data[data.name]));
                        },
                        error: function () {
                            $.msg("服务器文件已丢失", 2);
                        }
                    });
                    return;

                };
                break;
            case 10:
                {
                    $(".btn").remove();
                    $.msg(msg + "<br/><span id='lb_time'>3</span>秒后自动关闭窗口", 1);
                    setTimeout(function () {
                        var index = parent.layer.getFrameIndex(window.name); //先得到当前iframe层的索引
                        parent.layer.close(index); //再执行关闭   
                    }, 3000);

                };
                break;
                deafult: {
                    if (_c.isDebug) {
                        $.alert("服务器返回了错误的code,请检查api的返回值");
                    }
                }
            }
            try {
                refresh(data, code, msg, url);
            } catch (ex) {
                _c.warn("刷新失败" + ex);
            }
        },
        //检查页面是否合法-移动版
        checkPage: function () {
            var domsFromId = $("input[id*='-'],textarea[id*='-'],select[id*='-']"); //只住区input和area
            if (domsFromId.length > 0) {
                $.alert("页面不规范，请打开控制台查看修改建议！");
                _c.warn("移动端页面的数据控件(input,select,textarea)的id不能包含字符'-',当前不符合规范的如下:");
                for (var i = 0; i < domsFromId.length; i++) {
                    var item = $(domsFromId[i]);
                    _c.log('id="' + item.attr("id") + '"');
                }

            }

        },
        //取表单值-移动版
        vals_m: function (id, type) {

            var domsFromName = $("input[name*='-'],textarea[name*='-'],select[name*='-']"); //只住区input和area
            var domsFromId = $("input[id*='-'],textarea[id*='-'],select[id*='-']"); //只住区input和area
            var doms = $.union(domsFromName, domsFromId, "outerHTML");



            var json = "{";
            for (var i = 0; i < doms.length; i++) {
                var dom = $(doms[i]);
                var currentId = _c.hasValue(dom.attr("name")) ? dom.attr("name") : dom.attr("id");
                var value = $.val_m(dom);
                json += "\"" + currentId + "\":" + "\"" + value + "\"";
                if (i === doms.length - 1) {
                    json += "}";
                } else {
                    json += ",";
                }
            }
            if (doms.length === 0) json = "{}";
            return _c.toObject(json);
        },
        //取值-移动版
        val_m: function (domOrNameOrClass, doAfterGetValue) {
            if (!_c.hasValue(domOrNameOrClass)) {
                return "";
            }
            var dom;
            //
            if ($.isString(domOrNameOrClass)) {
                dom = $("input[name='" + domOrNameOrClass + "'],textarea[name='" + domOrNameOrClass + "'],textarea[select='" + domOrNameOrClass + "']");
                if (dom.length === 0) {
                    dom = $("." + domOrNameOrClass);
                    if (dom.length === 0) {
                        dom = $("#" + domOrNameOrClass);
                        if (dom.length === 0) {
                            _c.warn("未找到该元素：" + domOrNameOrClass);
                            return "";
                        }
                    }
                }
            } else {
                dom = domOrNameOrClass;

            }

            var v = dom.data("values"); //dom.val();
            if (!_c.hasValue(v) && _c.hasValue(dom.attr("value"))) {
                v = dom.attr("value");
            }
            if (!_c.hasValue(v) && _c.hasValue(dom.val())) {
                v = dom.val();
            }
            if (_c.hasValue(doAfterGetValue)) {
                doAfterGetValue(v, dom);
            }
            return _c.htmlEncode(v);
        },
        //取值
        val: function (id, type, uiType) {
            // 
            var value = "";
            uiType = $.checkValue(uiType, 'pc');
            switch (uiType) {
            case "pc":
            {
                switch (type) {
                case 201:
                case 203:
                case 209:
                case 210:
                case 211:
                case 212:
                case 213:
                case 214: //文本框
                    {
                        value = $('#' + id).val(); //jquery取值
                        //value=document.getElementById(id).value;//js取值
                    }
                    break;
                case 202:
                case 223: //时间
                    {
                        //
                        return $('#' + id).val(); //时间不转码
                    }
                    break;
                case 204: //下拉框
                    {
                        //
                        //把val()改为text(),value改为text可以实现取文本
                        value = $("#" + id + " option:selected").val(); //jquery取值
                        /*//js取值
                           var myselect=document.getElementById(id); 
                           var index=myselect.selectedIndex ; 
                           value=myselect.options[index].value; 
                          */
                    }
                    break;
                case 205: //单选框
                    {
                        value = $("input[name=" + id + "]:checked").val(); //jq 取值
                        //  obj = document.getElementsByName(id);//js取值

                    }
                    break;
                case 206: //编辑器
                    {
                        var ue = UM.getEditor(id);
                        ue.ready(function () {
                            //获取html内容,
                            value = _c.htmlEncode(ue.getContent());
                        });
                    }
                    break;
                case 207: //多选框
                    {
                        //var chk_value = []; //定义一个数组     jq取值 
                        //$("input[name=" + id + "]:checked").each(function () { //遍历每一个名字为nodes的复选框,其中选中的执行函数
                        //    chk_value.push($(this).val()); //将选中的值添加到数组chk_value中      
                        //});
                        //var groups = chk_value.join(",");
                        //value = groups;
                        ////jq 取值
                        //$("input:checkbox[value=3]").attr('checked', 'true'); //jq 赋值 
                        ////      			 obj = document.getElementsByName(id);//js取值
                        ////				    check_val = [];
                        ////				    for(k in obj){
                        ////				        if(obj[k].checked)
                        ////				           check_val.push(obj[k].value)
                        ////				    }
                        ////				      value=check_val;
                        var length = $('#' + id + ' .weui-check__label').length;
                        var str = "";
                        for (var i = 0; i < length; i++) {
                            if ($('#' + id + ' .weui-check__label').eq(i).find('input[type=checkbox]').is(':checked')) {
                                str += $('#' + id + ' .weui-check__label').eq(i).find('.weui-cell__bd p').text();
                            }
                        }
                        var groups = str.join(",");
                        value = groups;

                    }
                    break;
                case 208: //开关
                    {
                        value = $('#' + id).val(); //jquery取值
                    }
                    break;


                }
            }
            case "weui":
            {
                switch (type) {
                case 201:
                case 203:
                case 209:
                case 210:
                case 211:

                case 212:
                case 213:
                case 214:
                case 222:
                case 223:
                case 224:
                case 225:
                case 226://文本框
                    {
                        value = $('#' + id).val(); //jquery取值
                        //value=document.getElementById(id).value;//js取值
                    }
                    break;
                case 202:
                case 223: //时间
                    {
                        //
                        return $('#' + id).val(); //时间不转码
                    }
                    break;
                case 204: //下拉框
                    {
                        //
                        //把val()改为text(),value改为text可以实现取文本
                        value = $("#" + id + " option:selected").val(); //jquery取值
                        /*//js取值
                           var myselect=document.getElementById(id); 
                           var index=myselect.selectedIndex ; 
                           value=myselect.options[index].value; 
                          */
                    }
                    break;
                case 205: //单选框
                    {
                        value = $("input[name=" + id + "]:checked").val(); //jq 取值
                        //  obj = document.getElementsByName(id);//js取值

                    }
                    break;
                case 206: //编辑器
                    {
                        var ue = UM.getEditor(id);
                        ue.ready(function () {
                            //获取html内容,
                            value = _c.htmlEncode(ue.getContent());
                        });
                    }
                    break;
                case 207: //多选框
                    {
                        var chk_value = []; //定义一个数组     jq取值 
                        $("input[name=" + id + "]:checked").each(function () { //遍历每一个名字为nodes的复选框,其中选中的执行函数
                            chk_value.push($(this).val()); //将选中的值添加到数组chk_value中      
                        });
                        var groups = chk_value.join(",");
                        value = groups;
                        //jq 取值
                        $("input:checkbox[value=3]").attr('checked', 'true'); //jq 赋值 
                        //      			 obj = document.getElementsByName(id);//js取值
                        //				    check_val = [];
                        //				    for(k in obj){
                        //				        if(obj[k].checked)
                        //				           check_val.push(obj[k].value)
                        //				    }
                        //				      value=check_val;

                    }
                    break;
                case 208: //开关
                    {
                        value = $('#' + id).val(); //jquery取值
                    }
                    break;


                }
            }
            }


            //编码后返回
            return _c.hasValue(value) ? _c.htmlEncode(value) : "";
        },

        set_m: function (doms, v, p) {
            //
            if (doms == undefined) return;
            for (var i = 0; i < doms.length; i++) {
                var dom = $(doms[i]);
                if (dom == undefined) break;

                //_c.log(dom.attr("type"))
                //图片
                if (dom.attr("src") != undefined) {

                    if (_c.hasValue(v)) {
                        if (v.toLowerCase().indexOf("http") > -1) {
                            dom.attr("src", v);
                        } else {
                            dom.attr("src", _c.url(v));
                        }
                    } //文本框
                } else if (dom.attr("type") === "text") {
                    // dom.attr("name", p);//设置name属性
                    dom.val(v); //设置value属性
                } else if (dom[0].tagName === "SELECT") { //下拉框
                    //  
                    dom.val(v);
                } else if (dom[0].tagName === "P") { //下拉框
                    //  
                    dom.html(_c.htmlDecode(v));
                }
                {
                    if (!_c.hasValue(dom.attr("name"))) {
                        dom.attr("name", p);//页面没有该name时才改变name
                    }
                    dom.html(_c.htmlDecode(v));
                    //
                    _c.warn(
                        {
                            msg: "set_m函数出错，出现无法判断的控件类型,已经采用默认方法赋值(html元素优先，hide第二)", dom_type:
                                dom.attr("type"), dom_id:
                                dom.attr("id")
                        });
                    //_c.log(dom.type.toLowerCase())
                    //dom.attr("name", p);//设置name属性

                }


            }
        },
        set: function (id, type, vaule) {
            var currentId = id;
            var notTrimValue = _c.htmlDecode(vaule);//解码
            var value = _c.trimString(notTrimValue);
            var defultValue = _c.hasValue(value) ? value : "-12580";
            switch (type) {
            case 201: case 211: case 212: case 213://文本框
            {
                //  
                if (_c.hasValue(value))//无值的时候不操作
                    $('#' + currentId).val(value);//jquery赋值
                //document.getElementById(currentId).value='newvalue'//js赋值
            } break;
            case 202: case 216: case 223://时间
            {
                //    
                if (_c.hasValue(notTrimValue))//无值的时候不操作
                    $('#' + currentId).val($.parsetime(notTrimValue));
            } break;
            case 203: case 217://日期
            {
                // 
                if (_c.hasValue(value))
                    $('#' + currentId).val($.parsedate(value));
            } break;
            case 204: case 218://下拉框202
            {
                //
                if (_c.hasValue(value)) {
                    $("#" + currentId).val(value);//设置选中
                    $("#" + currentId).data("value", value);//缓存从服务器读取回来的值
                }
            } break;
            case 205: case 219://单选框
            {
                _c.log(_c.hasValue(value));
                if (_c.hasValue(value)) {
                    $("input:radio[value=" + defultValue + "]").attr('checked', 'true'); //jq 赋值 
                    /*  obj = document.getElementsByName(currentId);//eckbox取值    
                        for(k in obj){
                            if(obj[k].checked)
                               value= obj[k].value
                        }    */ //js赋值
                }

            } break;
            case 206: case 220://编辑器
            {
                if (_c.hasValue(notTrimValue)) {
                    var ue = UM.getEditor(currentId);
                    ue.ready(function () {
                        //设置编辑器的内容
                        // 
                        ue.setContent(_c.htmlDecode(notTrimValue));
                    });
                }

            } break;
            case 220: //编辑器查看
            {
                // 
                if (_c.hasValue(notTrimValue))
                    $('#' + currentId).html(_c.htmlDecode(notTrimValue));
            } break;
            case 207: case 221://多选框
            {
                if (_c.hasValue(value)) {
                    for (var k = 0; k < notTrimValue.length; k++) {
                        $("input:checkbox[value=" + notTrimValue[k] + "]").attr('checked', 'true'); //jq 赋值 
                        // document.getElementsByName(currentId)[2].checked = true; //js赋值 
                    }
                }


            } break;
            case 208: case 222://开关
            {
            } break;
            case 209: case 215: //多行文本框
            {
                if (_c.hasValue(notTrimValue)) {
                    $('#' + currentId).val(notTrimValue);  // jq赋值
                    // document.getElementById(currentId).value = "221";//js赋值   
                }

            } break;
            case 210: case 214://文件
            {

                if (_c.hasValue(value)) {
                    //把文件值放进hide中
                    $('#' + currentId).val(value);
                    //构造文件操作界面
                    $('#fileupload-' + currentId + ' tbody').html(FileItemsTpl(value, currentId, type == 210));
                }

            } break;
            default:
            }
        },
        //页面层-自定义
        diy: function (content, title) {
            if (title == undefined) {
                title = false;
            }
            try {
                layer.open({
                    type: 1,
                    title: title,
                    closeBtn: 1,
                    shadeClose: true,
                    skin: 'layui-layer-lan',
                    content: "<div >" + content + "</div>"
                });
            } catch (ex) {
                _c.warn("diy函数依赖于layui");
            }

        },

        //提示框
        window: function (url, title, width, height, closeBtn) {

            if (title == undefined) {
                title = false;
            }
            if (width == undefined) {
                width = 600;
            }
            if (height == undefined) {
                height = 450;
            }
            if (closeBtn == undefined) {
                closeBtn = 0;
            }
            //iframe窗
            try {
                layer.open({
                    type: 2,
                    title: title,
                    closeBtn: closeBtn, //不显示关闭按钮
                    shade: [0],
                    area: [width + 'px', height + 'px'],
                    offset: 'rb', //右下角弹出
                    //time: 20000, //2秒后自动关闭
                    anim: 2,
                    skin: 'layer-ext-moon',
                    content: [url, 'yes'] //iframe的url,no代表不显示滚动条

                });
            } catch (ex) {

                _c.warn("window函数依赖于layui");
            }

        },
        //提示框
        alert: function (content, icon, fn) {
            if (icon == undefined) {
                icon = 0;
            }
            var realFn = function (index) {
                if (_c.hasValue(fn)) {
                    fn(index);
                }
                layer.close(index);
            };
            try {

                layer.alert(content, {
                    icon: icon,
                    title: "提示",
                    skin: "layer-ext-moon" //该皮肤由layer.seaning.com友情扩展。关于皮肤的扩展规则,去这里查阅
                }, realFn);
            } catch (ex) {
                try {
                    return layer.open({
                        content: content
                        , btn: '我知道了'
                    });

                } catch (ex) {
                    _c.warn("alert函数执行出错");
                }


            }

        },
        //消息框
        msg: function (content, icon) {
            if (icon == undefined) {
                icon = 1;
            }
            if (content.indexOf("加载中") > -1) {
                icon = 0;
            }
            try {
                var index = layer.msg(content, {
                    icon: icon,
                    time: 2000 //2秒关闭（如果不配置，默认是3秒）
                });
                return index;
            } catch (ex) {
                //移动版本
                try {
                    return layer.open({
                        content: content,
                        skin: 'msg',
                        time: 2 //2秒后自动关闭
                    });
                } catch (ex) {
                    _c.warn("msg函数执行出错");
                }

            }
        },
        //打开加载层
        loading: function (style) {

            if (style == undefined) {
                style = 1;
            }
            try {
                var index = layer.load(style, {
                    shade: [0.1, '#fff'] //0.1透明度的白色背景
                });
                return index;
            } catch (ex) {
                try {
                    //移动版本
                    return layer.open({ type: 2 });

                } catch (ex) {
                    _c.warn("loading函数执行出错");
                }

            }
        },

        //关闭加载层
        loaded: function (index) {
            try {
                if (_c.hasValue(index)) {
                    layer.close(index);
                } else {
                    console.error("关闭所有loading:index=>" + index);
                    layer.closeAll('loading'); //关闭加载层 
                }
            } catch (ex) {
                try {
                    layer.close(index);

                } catch (ex) {
                    _c.warn("close函数执行出错");
                }

            }
        },
        //确认框
        confirm: function (content, confirmDoWhat, whenCancleDo, whenDoSuccess, whenDoFail, icon) {
            //
            if (content == undefined) {
                content = "请确认您的操作！";
            }
            if (!_c.hasValue(icon)) {
                icon = 3;
            }
            try {
                var iii = layer.confirm(content,
                    { icon: icon, title: '确认？', btn: ["确认", "取消"] },
                    function () {
                        layer.close(iii);
                        var ok = confirmDoWhat();
                        if (_c.hasValue(ok)) {
                            if (ok) {
                                if (!_c.hasValue(whenDoSuccess)) {
                                    $.msg("操作成功", 1);
                                } else {
                                    whenDoSuccess();
                                }
                            }
                            else {
                                if (!_c.hasValue(whenDoFail)) {
                                    $.msg("操作成功", 1);
                                } else {
                                    whenDoFail();
                                }
                            }

                        }
                    }, function () {
                        if (!_c.hasValue(whenCancleDo)) {
                            $.msg("操作已取消", 0);
                        } else {
                            whenCancleDo();
                        }

                    });
            } catch (ex) {
                layer.open({
                    content: content
                    , btn: ['确认', '取消']
                    , yes: function (index) {
                        layer.close(index);
                        var ok = confirmDoWhat();
                        if (_c.hasValue(ok)) {
                            if (_c.hasValue(ok)) {
                                if (ok) {
                                    if (!_c.hasValue(whenDoSuccess)) {
                                        $.msg("操作成功", 1);
                                    } else {
                                        whenDoSuccess();
                                    }
                                }
                                else {
                                    if (!_c.hasValue(whenDoFail)) {
                                        $.msg("操作成功", 1);
                                    } else {
                                        whenDoFail();
                                    }
                                }

                            }
                        }
                        //location.reload();  
                    }, no: function (index) {
                        if (!_c.hasValue(whenCancleDo)) {
                            $.msg("操作已取消", 0);
                        } else {
                            whenCancleDo();
                        }
                    }
                });
            }

        },

        //刷新界面-如果想整页刷新需要将ajaxOnly设为false
        refresh: function (ajaxOnly) {
            ajaxOnly = _c.hasValue(ajaxOnly) ? ajaxOnly : true;

            if (_c.geturl().indexOf(_c.pc.report) > -1) {//是报表？
                $(".Query").click();//报表刷新-页面内定义
            } else {
                if (ajaxOnly) {
                    $(".Query").click();
                    $.doFunction("refresh");//局部刷新-页面内定义
                } else {
                    location.reload();
                }

            }

        },
        //判断文件是否存在
        hasfile: function (path, doIfExsit) {
            if (path.indexOf("http") > -1) {
                path = _c.url(path);
            }

            $.ajax({
                url: path,
                success: doIfExsit,
                error: function () {
                    _c.warn('不存在文件');
                }
            });

        },
        loadBll: function () {

            //加载业务js
            var id = _c.geturl();
            var jsurl = id;//页面
            var flagIndex = id.lastIndexOf("/");
            if (flagIndex > -1) {
                var front = id.substring(0, flagIndex);
                //  
                var behind = id.substring(flagIndex);
                jsurl = front + "/bll" + behind.replace(".html", "");
            }
            $.ajax({
                url: jsurl + ".js",
                success: function () {
                    //head.load($.res(jsurl + ".js"));
                },
                error: function () {
                    if (_c.isDebug) {
                        _c.warn("未能加载业务js,请检查项目的web目录下是否存在" + (jsurl + ".js"));
                    }
                }
            });
        },
        //动态加载js
        load: function (array) {
            var othis = this;
            for (var i = 0; i < array.length; i++) {
                var oHead = document.getElementsByTagName('head')[0];
                var item = array[i];
                if (item.substring(item.length - 3).toLowerCase() === ".js") {
                    var script = document.createElement("script");
                    script.type = "text/javascript";
                    script.src = item;
                    oHead.appendChild(script);
                    othis.log("js loaded: " + item);
                } else if (item.substring(item.length - 4).toLowerCase() === ".css") {
                    var link = document.createElement("link");
                    link.rel = "stylesheet";
                    link.href = item;
                    oHead.appendChild(link);
                    othis.log("css loaded: " + item);
                } else {
                    othis.warn("你可能引用了一个假的js或css =>" + item);
                }
            }
        },//绑定函数
        bindFunction: function (pre) {
            if (!_c.hasValue(pre)) {
                pre = "bt-";
            }
            $('[id^=' + pre + ']').each(function () {
                var target = $(this);
                var id = target.attr("id");
                var href = target.attr("href");
                //删除onclick 和 href等属性
                target.removeAttr("onclick");
                target.removeAttr("href");

                $("#" + id).click(function () {
                    //  
                    $.doFunction(id.replace(pre, ""), href + "','" + target.prop("outerHTML"));
                });
            });
        },//批量请求
        getMemberByUrl: function (url, isSqlQeury) {
            if (_c.hasValue(isSqlQeury)) {
                url = "/db/index?cmd=" + url.replace("@", "-");
            }
            if (url.indexOf("&") > -1) {
                url = url.substring(0, url.indexOf("&"));
            }

            return url.replace(/=/g, "_").replace(/&/g, "_").replace(/\?/g, "_").replace(/\//g, "_").replace(/@/g, "_");

        },
        Ajaxs: function (dataUrlArray, doAfterSuccessful, autoToObjectIfSingle, timeOut) {
            // 
            //当只有单个成员时，自动转为对象【默认不转】
            autoToObjectIfSingle = _c.hasValue(autoToObjectIfSingle) ? autoToObjectIfSingle : false;
            if (!_c.hasValue(timeOut)) {//转换为数组
                timeOut = 20;//20秒超时
            }

            if (!$.isArray(dataUrlArray)) {//转换为数组
                dataUrlArray = [dataUrlArray];
            }


            var resultArray = [];
            for (var h = 0; h < dataUrlArray.length; h++) {
                var dataUrl = dataUrlArray[h];
                // 
                $.Ajax({
                    url: dataUrl,
                    success: function (data, code, msg, url) {
                        if (_c.hasValue(data.ReportId) &&
                            _c.hasValue(data.PageIndex) &&
                            _c.hasValue(data.PerCount)) {//报表请求
                            $.Ajax({
                                url: "/Report/Report2",
                                data: {
                                    ReportID: data.ReportId,
                                    Params: data.Params,
                                    DbConnStringKey: data.DbConnStringKey,
                                    dataSourceUrl: data.DataSourceUrl,
                                    pageIndex: data.PageIndex,
                                    perCount: data.PerCount
                                },
                                success: function (reportData, code, msg, url) {
                                    var obj = {};//报表请求
                                    obj[data.ReportId] = _c.toObject(reportData.FinalJson);
                                    resultArray.push(obj);
                                }
                            });

                        } else {//普通请求
                            if ($.isArray(data)) {//数组成员
                                //  
                                var memberName = $.getMemberByUrl(url);
                                var obj = {};
                                obj[memberName] = data;
                                resultArray.push(obj);
                            } else {//普通成员
                                resultArray.push(data);
                            }

                        }

                    }
                });
            }
            //等待完成
            var frequency = 4;//每秒刷新频率
            var freshCount = timeOut * frequency;//总共刷新次数
            var intervalId = setInterval(function () {
                try {
                    if (resultArray.length < dataUrlArray.length) {
                        _c.log("wating..." + (freshCount--));
                        if (freshCount < 0) {
                            //清除定时器
                            clearInterval(intervalId);
                            _c.warn("请求超时");
                        }
                    } else {
                        //清除定时器
                        clearInterval(intervalId);
                        //合并结果

                        var finalData = resultArray[0];
                        //
                        //针对只有一个成员进行优化
                        if (resultArray.length === 1) {

                            var theFirstProperOfTheOnlyMember = finalData[$.toArray(finalData).p[0]];
                            if ($.isObject(theFirstProperOfTheOnlyMember) || $.isArray(theFirstProperOfTheOnlyMember)) {
                                finalData = theFirstProperOfTheOnlyMember;
                                //针对只有一个成员的第一个成员进行优化
                                if (autoToObjectIfSingle && $.isArray(theFirstProperOfTheOnlyMember) && theFirstProperOfTheOnlyMember.length === 1) {
                                    //
                                    finalData = theFirstProperOfTheOnlyMember[0];
                                }
                            }
                        } else {
                            for (var j = 1; j < resultArray.length; j++) {
                                $.extend(finalData, resultArray[j]);// Merge object2 into object1
                            }
                        }

                        _c.log(finalData);

                        //成功后的回掉函数
                        if (_c.hasValue(doAfterSuccessful)) {
                            doAfterSuccessful(finalData);
                        } else {
                            _c.warn("Ajaxs(dataUrlArray, doAfterSuccessful)没有传入doAfterSuccessful处理函数");
                        }
                    }
                } catch (ex) {
                    //异常时清除定时器
                    clearInterval(intervalId);
                    _c.warn(ex);
                }
            }, 1000.0 / frequency);
        },//doBeforeSubmit返回false时会终止提交
        submitPage: function (url, doAfterSuccess, doBeforeSubmit) {
            var formData = $.vals_m();//用户填写的
            var jsonPageData = $("#page-data").val();//原来的-依赖于bindPage
            var submitData = {};
            //  
            if (_c.hasValue(jsonPageData)) {//有旧数据-处理后提交
                submitData = _c.toObject(jsonPageData);
                var arr = $.toArray(formData); //转换类型用于遍历
                for (var i = 0; i < arr.p.length; i++) {
                    var p = arr.p[i];
                    var v = arr.v[i];
                    if (submitData[p] != undefined) {
                        submitData[p] = v; //更新值
                    } else {
                        submitData[p] = v; //添加值
                    }
                }
            } else {//无旧数据-直接提交
                submitData = formData;
            }

            //包装数据
            var d = {};
            if (_c.hasValue(doBeforeSubmit)) {//预处理
                var dealed = doBeforeSubmit(submitData);
                if (_c.hasValue(dealed)) {
                    if (dealed == false) {
                        //当返回false时终止向下执行
                        _c.warn("submitPage函数已被doBeforeSubmit参数在提交前强制终止");
                        return;
                    }
                    submitData = dealed;
                } else {
                    _c.warn("submitPage: function (url, doAfterSuccess, doBeforeSubmit)的doBeforeSubmit参数没有返回正确的对象");
                }
            }
            d._json = _c.toJson(submitData);
            _c.log(d);
            $.Ajax({
                url: url,
                data: d,
                success: function (data, code, msg, url) {
                    if (_c.hasValue(doAfterSuccess)) {
                        doAfterSuccess(data, code, msg, url);
                    } else {
                        $.dealAjax(data, code, msg, url);
                    }
                }
            });
        },
        bindPage: function (dataUrlArray, tplArray, doBeforeBinded, doAfterBinded) {
            //检查页面是否规范2017-12-24
            $.checkPage();
            // 
            $.Ajaxs(dataUrlArray, function (data) {
                // 
                //缓存最原始的数据
                $("body").append("<input type='hidden' id='page-data' value='" + _c.toJson(data) + "'>");

                //前置处理函数
                if (_c.hasValue(doBeforeBinded)) {

                    try { //整体前置处理
                        _data = doBeforeBinded(data);
                    } catch (ex) {
                        _c.warn("bindPagede(dataUrlArray,tplArray,doBeforeBinded,doAfterBinded)的doBeforeBinded处理函数执行出错:" + ex);
                    }
                    if (_data == undefined) {//整体前置处理结果检测
                        _c.warn("bindPagede(dataUrlArray,tplArray,doBeforeBinded,doAfterBinded)的doBeforeBinded处理函数没有return正确的对象，已忽略前置处理函数并自动选择处理前的成员");
                    } else {
                        data = _data;
                    }
                }

                //普通值
                var arr = $.toArray(data);
                for (var i = 0; i < arr.p.length; i++) {
                    var p = arr.p[i];
                    var v = arr.v[i];
                    //
                    var dom = $("#" + p);//id
                    if (!_c.hasValue(dom)) {
                        var domForShow = $("." + p); //class
                        if (!_c.hasValue(domForShow)) {
                            var domForSubmit = $("input[name*='" + p + "'],textarea[name*='" + p + "']");//name 只住区input和area
                            $.set_m(domForSubmit, v, p);
                        } else {
                            $.set_m(domForShow, v, p);
                        }
                    } else {
                        $.set_m(dom, v, p);
                    }

                }

                //列表
                if (tplArray == undefined) tplArray = [];
                if (tplArray.length > 0 && $.isString(tplArray[0])) {
                    //判断是否只有一个配置 即一维数组
                    tplArray = [tplArray]; //自动转为二维数组
                }

                for (var k = 0; k < tplArray.length; k++) {
                    var hsaChildTpl = false;
                    var tplObj = tplArray[k];//模板对象
                    var targetId = tplObj[0]; //容器id
                    var tplFnObj = tplObj[1]; //模板函数对象
                    var tplData;
                    //
                    //自动获取成员
                    var autoSelectMember;

                    for (var r = 0; r < dataUrlArray.length; r++) {
                        var currntDataUrlArray = dataUrlArray[r];
                        var key = $.getMemberByUrl(currntDataUrlArray, true);
                        //  
                        if (($.isArray(data[key]) || _c.hasValue(data[key])) && k === r) { //第1次尝试
                            autoSelectMember = data[key];
                            _c.log("已为" + targetId + "的doBeforeBinded自动匹配数据源成员" + key + "");
                            //_c.log("已为"+targetId+"的doBeforeBinded自动选择成员" + key + "数据源：" + currntDataUrlArray);
                            break;
                        } else {
                            //第2次尝试
                            key = $.getMemberByUrl(currntDataUrlArray, true);
                            if (($.isArray(data[key]) || _c.hasValue(data[key])) && k === r) {
                                autoSelectMember = data[key];
                                _c.log("已为" + targetId + "的doBeforeBinded自动匹配数据源成员" + key + "");
                                //_c.log("已为"+targetId+"的doBeforeBinded自动选择成员" + key + "数据源：" + currntDataUrlArray);
                                break;
                            }
                        }
                    }
                    //自动获取成员的结果
                    var dataToDealForDoBeforeBinded;
                    if ($.isArray(autoSelectMember) || _c.hasValue(autoSelectMember)) {
                        dataToDealForDoBeforeBinded = autoSelectMember;
                    } else {
                        dataToDealForDoBeforeBinded = data;
                        _c.log("为" + targetId + "的doBeforeBinded自动匹配数据源成员失败,已忽略自动匹配并自动选择自动匹配前的成员");
                    }
                    //
                    //自动转数组
                    if (!$.isArray(dataToDealForDoBeforeBinded)) {
                        dataToDealForDoBeforeBinded = [dataToDealForDoBeforeBinded];
                    }
                    //是否存在前置处理函数?
                    if (tplObj.length === 3) {
                        try {//前置处理函数
                            tplData = tplObj[2](dataToDealForDoBeforeBinded);
                        } catch (ex) {
                            _c.warn("bindPage(dataUrlArray,tplArray,doBeforeBinded,doAfterBinded)的tplArray参数中的tplArray[" + k + "][3]前置处理函数执行出错:" + ex);
                        }

                        if (tplData == undefined) { //前置处理函数结果检测
                            tplData = dataToDealForDoBeforeBinded;
                            _c.warn("bindPage(dataUrlArray,tplArray,doBeforeBinded,doAfterBinded)的tplArray参数中的tplArray[" + k + "][3]前置处理函数没有return正确的对象,已忽略前置处理函数并自动选择处理前的成员");
                        }
                    } else {
                        tplData = dataToDealForDoBeforeBinded;
                    }

                    var tplFn = tplFnObj;//模板函数
                    //  var subTplFn;
                    var parentTplFn;
                    var doBeforeFillParentTpl;
                    if ($.isArray(tplFnObj)) {
                        //包含嵌套
                        hsaChildTpl = true;
                        tplFn = tplFnObj[0];//子模板函数
                        parentTplFn = tplFnObj[1];//父模板函数
                        doBeforeFillParentTpl = tplFnObj[2];//嵌套模板前置处理函数
                    }

                    if (data == undefined) {
                        _c.warn(targetId + "的数据源如下为空，请确保填写了正确url");
                        break;
                    }
                    //if (tplData == undefined) {
                    //    tplData = data;
                    //    _c.warn("bindPage(dataUrlArray,tplArray,doBeforeBinded,doAfterBinded)的tplArray参数中的tplArray[" + k + "][3]前置处理函数没有return正确的对象");
                    //}
                    _c.log(targetId + "的数据源如下:");
                    _c.log(tplData);
                    var target = $("#" + targetId);
                    if (target.length === 0) {
                        _c.warn("没有找到id=" + targetId + "的容器,请确保传入了正确的容器id");
                        break;
                    }
                    if (!$.isArray(tplData)) {
                        _c.warn(targetId + "的模板数据不是Array类型，请确保前置处理函数返回了正确的模板数据");
                        break;
                    }
                    //开始解析模板
                    var tiHtml = "";
                    for (var ti = 0; ti < tplData.length; ti++) {
                        tiHtml += _c.qx_tpl(tplData[ti], tplFn);
                    }
                    if (hsaChildTpl) {
                        //处理嵌套
                        var parentTplData;
                        if (!_c.hasValue(doBeforeFillParentTpl)) {

                            if ($.isArray(data) && data.length > 0) {
                                _c.warn("嵌套父模板数据为空,请确保嵌套模板前置处理函数doBeforeFillParentTpl返回了正确的对象:由于模板数据是数组，已默认选取了第一个元素");
                                parentTplData = data[0];
                            } else {
                                _c.warn("嵌套父模板数据为空,请确保嵌套模板前置处理函数doBeforeFillParentTpl返回了正确的对象:由于模板数据不是数组，已默认选取整个对象");
                                parentTplData = data;
                            }
                        } else {
                            parentTplData = doBeforeFillParentTpl(data);
                            if (!_c.hasValue(parentTplData)) {
                                if ($.isArray(data) && data.length > 0) {
                                    _c.warn("嵌套父模板数据为空,请确保嵌套模板前置处理函数doBeforeFillParentTpl返回了正确的对象:由于模板数据是数组，已默认选取了第一个元素");
                                    parentTplData = data[0];
                                } else {
                                    _c.warn("嵌套父模板数据为空,请确保嵌套模板前置处理函数doBeforeFillParentTpl返回了正确的对象:由于模板数据不是数组，已默认选取整个对象");
                                    parentTplData = data;
                                }
                            }
                        }
                        parentTplData["sub-tpl"] = tiHtml;
                        //
                        _c.log(targetId + "的嵌套父模板数据源如下:");
                        _c.log(parentTplData);
                        tiHtml = _c.qx_tpl(parentTplData, parentTplFn);
                    }
                    target.html(tiHtml);
                }
                if (_c.hasValue(doAfterBinded)) {
                    doAfterBinded(data);
                }
            }, true);


        },//联动下拉
        bindSelect: function (bindedId, targetId, url, isFirst, doAfterBinded) {

            var src = $("#" + bindedId);

            //
            src.change(function () {
                //取出旧值
                var oldBindedValue = $.val(bindedId, 204);
                var oldTargetValue = $.val(targetId, 204);
                //注意是大写的Ajax
                $.Ajax({
                    url: url,
                    //204代表select下拉框控件
                    data: { id: oldBindedValue, name: oldBindedValue },
                    //注意success中四个参数的顺序
                    success: function (data, code, msg, url) {
                        var target = $("#" + targetId);
                        target.html(_c.getOptionHtml(data, oldTargetValue));
                        target.change();
                        //写回旧值
                        $.set(bindedId, 204, oldBindedValue);
                        $.set(targetId, 204, oldTargetValue);
                        $.refresh();
                        if (_c.hasValue(doAfterBinded)) {
                            doAfterBinded(src, target);
                        }
                        //待优化  提交次数过多	
                    }
                });
            });
            if (_c.hasValue(isFirst) && isFirst) {
                $("#" + bindedId).change();
            }
        },


        fillTable: function (tableId, url) {

            if (!_c.hasValue(url))
                return;
            //注意是大写的Ajax
            $.Ajax({
                url: url,
                success: function (data, code, msg, url) {
                    $("#" + tableId + "-content").html(table(data).html);
                }
            });
        },

        fillSelect: function (selectId, urlOrSelectItems, value, addDefaultOption) {
            /*	if ($.isArray(selectId)&&!$.isString(selectId)) {//兼容二维数组
                    for (var i = 0; i < selectId.length; i++) {
                        var item = selectId[i];
                        //防止数组越界
                        $.fillSelect(item[0],item[1],item[2],item[3]);
                    }
                }*/
            //  
            if (!_c.hasValue(urlOrSelectItems))
                return;
            //传入的是url
            if ($.isString(urlOrSelectItems)) {
                var url = urlOrSelectItems;
                //注意是大写的Ajax
                $.Ajax({
                    url: url,
                    success: function (data, code, msg, url) {
                        var severValue = $("#" + selectId).data("value"); //服务器值优先
                        $("#" + selectId).html(_c.getOptionHtml(data, _c.hasValue(severValue) ? severValue : value, addDefaultOption));
                    }
                });
            } else {//传入的是数据
                var items = urlOrSelectItems;
                $("#" + selectId).html(_c.getOptionHtml(items, value));
            }


        },
        //当报表搜索框加载完成后的回调
        //searchReady: function (Fn) {
        //document.write("<script>"+Fn.toString()+"</script>");
        //},
        //判断是否是调试页面
        isDebugPage: function () {
            return document.URL.indexOf("/pages/form.html?id=/core/test/all") > -1 ||
                document.URL.indexOf("/pages/form.html?id=/debug/") > -1;
        },
        //判断是否有值
        hasValue: _c.hasValue,
        //判断是否有值
        checkValue: _c.checkValue,
        //判断是否是函数
        isFunction: _c.isFunction,
        //判断函数是否存在
        hasFunction: _c.hasFunction,
        doFunction: _c.doFunction,
        //对象转数组
        toArray: _c.toArray,
        isArray: _c.isArray,
        isObject: _c.isObject,
        isArray2: _c.isArray2,
        isString: _c.isString,
        isInt: _c.isInt,
        //编辑器
        editor: function (id) {
            head.ready(function () {
                KindEditor.ready(function (K) {
                    var options = {
                        allowFileManager: true,
                        cssPath: '/Include/KindEditor/plugins/code/prettify.css',
                        imageUploadJson: '/Include/KindEditor/asp.net/upload_json.ashx',
                        fileManagerJson: '/Include/KindEditor/asp.net/file_manager_json.ashx',
                        width: "98%", //编辑器的宽度为70%
                        height: "400px", //编辑器的高度为100px
                        filterMode: false, //不会过滤HTML代码
                        resizeMode: 1, //编辑器只能调整高度
                        afterBlur: function () { this.sync() }, //假如没有这一句,获取到的id为content的值空白
                        afterCreate: function () {
                            _c.log('KindEditor[' + id + ']ok');
                            //var self = this;
                            //K.ctrl(document, 13, function () {
                            //    self.sync();
                            //    K('form[name=example]')[0].submit();
                            //});
                            //K.ctrl(self.edit.doc, 13, function () {
                            //    self.sync();
                            //    K('form[name=example]')[0].submit();
                            //});
                        }
                    };
                    var editor = K.create('#' + id, options);
                    prettyPrint();
                });
            });
        },
        //设为子页面
        setSubPage: function (id) {
            var script = document.createElement("script");
            script.type = "text/javascript";
            script.innerText = "var pymChild = new pym.Child(); ";
            document.body.appendChild(script);
        }



    });
    _c.log(_c);
}
_c.bll = function () {
    var uid = _c.uid();
    var unitid = _c.unitid();


    //处理自动登陆
    if (_c.isAutoLoginPage()) {
        // 
        _c.cleanPage();
        $.loading();
        $.msg("加载中...");
        autoLogin(_c.q("userId"), _c.q("roleString"), _c.q("subSys"), _c.q("site"), _c.q("userName"));
        return;
    }
    //处理登陆
    if (_c.isLoginPage()) {
        if (_c.hasValue(_c.login_third)) {
            //第三方登陆
            _c.cleanPage();
            if (_c.login_third == "we7") {
                _c.cleanPage();
                alert("页面会话超时，请关闭页面后重新进入！");
            } else {
                window.location.replace(_c.login_third);
            }
        }
        _c.click("login",
            function () {
                var userid = document.getElementById("uid").value;
                var psw = document.getElementById("psw").value;
                if (!_c.hasValue(userid)) {
                    $.alert("账号不能为空", 2);
                    return;
                }
                login(userid, psw);
            });
        return;
    } else {
        if (_c.isWin10 && _c.isHomePage() && !_c.isApp) {
            $.alert("即将进入全屏，按F11可退出全屏", 0, function () {
                var el = document.documentElement;
                var rfs = el.requestFullScreen ||
                    el.webkitRequestFullScreen ||
                    el.mozRequestFullScreen ||
                    el.msRequestFullScreen;
                if (typeof rfs != "undefined" && rfs) {
                    rfs.call(el);
                } else if (typeof window.ActiveXObject != "undefined") {
                    var wscript = new ActiveXObject("WScript.Shell");
                    if (wscript != null) {
                        wscript.SendKeys("{F11}");
                    }
                }
            });
        }
        //会员
        $("#user_id").text(_c.cookie('user_id'));
        $("#nick_name").val(_c.cookie('nick_name')); $(".nick_name").text(_c.cookie('nick_name'));
        $("#unit_name").text(_c.cookie('unit_name'));//显示用户id//显示用户id
        $(".fa-sign-out").click(function () {//设置退出登录
            _c.cookie();
            $.msg("已退出登录");
            _c.go(_c.pc.login);
        });

        if (_c.isApp) {

            $.loadBll();//加载业务js
            $.bindFunction();//自动绑定页面参数
            $(".back").click(function () { _c.go(-1) });//后退按钮

        } else {
            //需要拉取工作流待办
            //InitWorkFlow();
            //报表初始化
            if (_c.geturl() === _c.pc.report) {
                //id为报表的数据api地址
                qx.grid.InitReport(_c.q("id"));
            }
            //表单初始化
            else if (_c.geturl() === _c.pc.form) {
                //sdebugger 
                //id为js路径或自定义页面路径
                InitForm(_c.q("id"));
            }
            //首页初始化
            else if (_c.geturl() === _c.pc.homepage) {
                menuStageTwo(uid);
            }
            else {
            }
        }
    }


}

//特殊页面处理
window.onload = function () {

    if (_c.isLoadingPage()) {
        var num = 0;
        var libs = _c.lib();
        for (var i = 0; i < libs.src.length; i++) {
            var o = libs.src[i];
            if (_c.isObject(o)) {
                o = _c.toArray(o).v[0];
            }
            _c.ajax({
                url: o,
                complete: function () {
                    var per = (Math.round((++num + 0.0000001) * 100 / libs.src.length));
                    slider.target.x = per - 50;
                    //  _c.log(per);
                    if (num === libs.src.length) {
                        window.location.replace('index.html');
                        //  document.getElementById("full").innerText = "点击进入";
                        //  window.open('index.html', '', 'fullscreen=yes');

                    }

                }
            });
        }
    }

    //处理访客
    else if (_c.isVisitor()) {
        _c.warn("请登陆");
        if (_c.hasValue(_c.login_third)) {
            if (_c.login_third == "we7") {
                _c.cleanPage();
                $.alert("页面会话超时，请关闭页面后重新进入！");
            } else {
                $.msg("加载中...");
                _c.go(_c.login_third + "?returnUrl=" + _c.login_auto);
            }

        } else {
            _c.go(_c.login);
        }
    }
    else {
        //加载资源

        head.load(_c.lib().src);
        head.ready(_c.lib().ready);
        head.ready(_c.tool);

        head.ready(_c.bll);
    }
}




function back() {
    history.go(-1);
}

function checkForm(fn) {
    if (event.keyCode == 13) {
        fn();
    }
}
var HtmlUtil = {
    /*1.用浏览器内部转换器实现html转码*/
    htmlEncode: function (html) {
        //1.首先动态创建一个容器标签元素，如DIV
        var temp = document.createElement("div");
        //2.然后将要转换的字符串设置为这个元素的innerText(ie支持)或者textContent(火狐，google支持)
        (temp.textContent != undefined) ? (temp.textContent = html) : (temp.innerText = html);
        //3.最后返回这个元素的innerHTML，即得到经过HTML编码转换的字符串了
        var output = temp.innerHTML;
        temp = null;
        return output;
    },
    /*2.用浏览器内部转换器实现html解码*/
    htmlDecode: function (text) {
        //1.首先动态创建一个容器标签元素，如DIV
        var temp = document.createElement("div");
        //2.然后将要转换的字符串设置为这个元素的innerHTML(ie，火狐，google都支持)
        temp.innerHTML = text;
        //3.最后返回这个元素的innerText(ie支持)或者textContent(火狐，google支持)，即得到经过HTML解码的字符串了。
        var output = temp.innerText || temp.textContent;
        temp = null;
        return output;
    },
    /*3.用正则表达式实现html转码*/
    htmlEncodeByRegExp: function (str) {
        var s = "";
        if (!_c.hasValue(str)) return "";
        s = ("" + str).replace(/&/g, "&amp;");
        s = s.replace(/</g, "&lt;");
        s = s.replace(/>/g, "&gt;");
        s = s.replace(/ /g, "&nbsp;");
        s = s.replace(/\'/g, "&#39;");
        s = s.replace(/\"/g, "&quot;");
        s = s.replace(/\r/g, "&nbsp;");
        s = s.replace(/\n/g, "#br");
        return s;
    },
    /*4.用正则表达式实现html解码*/
    htmlDecodeByRegExp: function (str) {
        var s = "";
        if (!_c.hasValue(str)) return "";
        s = ("" + str).replace(/&amp;/g, "&");
        s = s.replace(/&lt;/g, "<");
        s = s.replace(/&gt;/g, ">");
        s = s.replace(/&nbsp;/g, " ");
        s = s.replace(/&#39;/g, "\'");
        s = s.replace(/&quot;/g, "\"");
        s = s.replace(/&nbsp;/g, "\r");
        s = s.replace(/#br/g, "\n");
        return s;
    }
};





//生成 Guid 
function Guid(g) {
    var arr = new Array(); /*存放32位数值的数组*/    if (typeof (g) == "string") { /*如果构造函数的参数为字符串*/        InitByString(arr, g); } else { InitByOther(arr); } /*返回一个值,该值指示 Guid 的两个实例是否表示同一个值。*/    this.Equals = function (o) { if (o && o.IsGuid) { return this.ToString() == o.ToString(); } else { return false; } }; /*Guid对象的标记*/    this.IsGuid = function () { }; /*返回 Guid 类的此实例值的 String 表示形式。*/    this.ToString = function (format) { if (typeof (format) == "string") { if (format == "N" || format == "D" || format == "B" || format == "P") { return ToStringWithFormat(arr, format); } else { return ToStringWithFormat(arr, "D"); } } else { return ToStringWithFormat(arr, "D"); } }; /*由字符串加载*/    function InitByString(arr, g) { g = g.replace(/\{|\(|\)|\}|-/g, ""); g = g.toLowerCase(); if (g.length != 32 || g.search(/[^0-9,a-f]/i) != -1) { InitByOther(arr); } else { for (var i = 0; i < g.length; i++) { arr.push(g[i]); } } } /*由其他类型加载*/    function InitByOther(arr) { var i = 32; while (i--) { arr.push("0"); } }
    /*
        根据所提供的格式说明符,返回此 Guid 实例值的 String 表示形式。
        N  32 位： xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        D  由连字符分隔的 32 位数字 xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
        B  括在大括号中、由连字符分隔的 32 位数字：{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx}
        P  括在圆括号中、由连字符分隔的 32 位数字：(xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx)
        */
}
function ToStringWithFormat(arr, format) { switch (format) { case "N": return arr.toString().replace(/,/g, ""); case "D": var str = arr.slice(0, 8) + "-" + arr.slice(8, 12) + "-" + arr.slice(12, 16) + "-" + arr.slice(16, 20) + "-" + arr.slice(20, 32); str = str.replace(/,/g, ""); return str; case "B": var str = ToStringWithFormat(arr, "D"); str = "{" + str + "}"; return str; case "P": var str = ToStringWithFormat(arr, "D"); str = "(" + str + ")"; return str; default: return new Guid(); } } Guid.Empty = new Guid();/*Guid 类的默认实例,其值保证均为零。*/Guid.NewGuid = function () { var g = ""; var i = 32; while (i--) { g += Math.floor(Math.random() * 16.0).toString(16); } return new Guid(g); }; Guid.random = function () { var g = ""; var i = 32; while (i--) { g += Math.floor(Math.random() * 16.0).toString(16); } return new Guid(g).ToString(); };


//获取时间
function getNowFormatTime(onlydate) {

    var date = new Date();
    var seperator1 = "-";
    var seperator2 = ":";
    var strMonth = date.getMonth() + 1;
    var strDay = date.getDate();
    if (strMonth >= 1 && strMonth <= 9) {
        strMonth = "0" + strMonth;
    }
    if (strDay >= 0 && strDay <= 9) {
        strDay = "0" + strDay;
    }
    if (onlydate != undefined) {
        return date.getFullYear() + seperator1 + strMonth + seperator1 + strDay;

    } else {
        var strHour = date.getHours();
        var strMinute = date.getMinutes();
        var strSeconds = date.getSeconds();
        if (strHour >= 1 && strHour <= 9) {
            strHour = "0" + strHour;
        }
        if (strMinute >= 1 && strMinute <= 9) {
            strMinute = "0" + strMinute;
        }
        if (strSeconds >= 1 && strSeconds <= 9) {
            strSeconds = "0" + strSeconds;
        }
        return date.getFullYear() + seperator1 + strMonth + seperator1 + strDay
            + " " + strHour + seperator2 + strMinute
            + seperator2 + strSeconds;
    }

}
//基于bootstrap的Color
var Color = function () { }; Color.red = "danger"; Color.blue = "primary"; Color.green = "success"; Color.orange = "warning"; Color.white = "default";

//检查变量
function check(value, valueIfUndefined) {
    return (_c.hasValue(value) ? value :
        (valueIfUndefined == undefined) ? 4 : valueIfUndefined);
}

//获取代码块模板
function getTpl(fn) {
    var startIndex = 0;
    var endIndex = 0;
    var temp = fn.toString().split('\n');
    for (var i = 0; i < temp.length; i++) {
        if (temp[i].indexOf("/*") > -1) {
            if (startIndex === 0) {
                startIndex = i;//第一行
                break;
            }
        }
    }
    for (var j = temp.length - 1; j >= 0; j--) {
        if (temp[j].indexOf("*/") > -1) {
            if (endIndex === 0) {
                endIndex = j;//最后一行
                break;
            }
        }
    }

    return temp.slice(startIndex + 1, endIndex).join('\n') + '\n';
    //fn.toString().split('\n').slice(1, -1).join('\n') + '\n';
    //return fn.toString().replace('function () {/*', '').replace('*/', '');
}



function loginRedirect(units, index) {
    //
    //$.msg('加载中...', 0);
    // $.msg('即将以' + units.name[index] + "的身份进入系统", 0);
    _c.cookie('unit_name', units.name[index]);
    _c.unitid(units.id[index]);//加密版


    if (_c.hasValue(_c.bind)) {//跳转到绑定地址
        _c.go(_c.bind);
        return;
    }

    setTimeout(function () {
        window.location.replace(_c.homepage);
    }, 10);
}
function chooseOrgToLogin(units) {
    //
    if (units.id.length > 1) {
        //选择机构
        try {
            layer.confirm('请选择以什么机构进入系统？', {
                btn: units.name
            }, function () {
                loginRedirect(units, 0);
            }, function () {
                loginRedirect(units, 1);
            }, function () {
                loginRedirect(units, 2);
            }, function () {
                loginRedirect(units, 3);
            }, function () {
                loginRedirect(units, 4);
            });
        } catch (ex) {
            $.msg("已随机选择一个机构");
            setTimeout(function () {
                loginRedirect(units, 0);
            }, 1000);

            //layer.open({
            //    content: '请选择以什么机构进入系统-暂不支持移动端多机构选择？'
            //    , btn: units.name
            //    , yes: function (index) {
            //        loginRedirect(units, 0);
            //    }
            //});
        }

    } else if (units.id.length == 1) {
        loginRedirect(units, 0);
    } else {
        $.alert("未分配组织机构,无法登陆！", 5);
    }
}

function loginSuccess(uid) {
    // 
    _c.uid(uid); //存储加密版uid
    //根据uid获取用户信息
    $.Ajax({
        url: "/open/userInfo",
        success: function (data, code) {
            if (code === 1) {
                _c.cookie('nick_name', data.nick_name);//存储用户名称
                _c.cookie('user_id', data.user_id);//存储未加密uid
                var units = _c.toObject(data.units);
                chooseOrgToLogin(units);//选择组织机构
            } else {
                _c.warn(data);
                $.alert("获取用户信息失败！", 5);
            }
        }
    });
}
function login(userId, psw) {
    var index = $.loading();
    $.ajax({
        url: _c.url("/Open/login", true),
        data: { userId: userId, psw: psw },
        success: function (result) {
            $.loaded(index);
            var code = result.code;
            var data = _c.toObject(result.jsonData);
            if (code === 1) {
                //登陆成功-获取加密后的uid
                loginSuccess(data.uid);
            } else {
                $.alert("用户名或密码错误！", 5);
            }
        }, error: function (xmlHttpRequest, textStatus, errorThrown) {
            $.loaded(index);
            if (_c.isDebug) {
                $.alert("服务器连接失败,请检查服务器是否正常运转！", 2);
            } else {
                $.alert("网络连接失败,请检查您的网络连接状态！", 5);
            }


        }
    });
}

function autoLogin(userId, roleString, subSys, site, userName) {

    if (!_c.hasValue(roleString)) {
        roleString = "";
    }
    var index = $.loading();
    $.ajax({
        url: _c.url("/Open/autoLogin?userId=" + userId + "&roleString=" + roleString + "&subSys=" + subSys + "&site=" + site + "&userName=" + userName, true),
        success: function (result) {
            $.loaded(index);
            var code = result.code;
            var data = _c.toObject(result.jsonData);
            if (code === 1) {
                //登陆成功-获取加密后的uid
                loginSuccess(data.uid);
            } else {
                $.alert(result.msg, 5);
                return;
            }
        }, error: function (xmlHttpRequest, textStatus, errorThrown) {
            $.loaded(index);
            if (_c.isDebug) {
                $.alert("服务器连接失败,请检查服务器是否正常运转！", 2);
            } else {
                $.alert("网络连接失败,请检查您的网络连接状态！", 5);
            }


        }
    });
}

function confirmPay(totalFee) {
    $.loading();
    _c.go(g_pay_wx + "?uid=" + _c.uid() + "&total_fee=" + totalFee + "&return_url=" + g_pay_result_wx);
}
function YibanLogin() {

    _c.go(_c.sever.host + "/Oauth2/YiBan?returnUrl=" + localUrl(_c.pc.login_3rd_result));
}

function hide_m(objArray) {
    if (!$.isArray2(objArray)) {
        objArray = [objArray];
    }
    for (var i = 0; i < objArray.length; i++) {
        var arr = objArray[i];
        var name = arr[0];
        var value = arr.length > 1 ? arr[1] : "";
        $("body").append(' <input class="hidden" name="' + name + '" type="text" value="' + value + '">');
    }
}