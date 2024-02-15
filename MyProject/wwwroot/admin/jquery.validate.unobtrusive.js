/**
 * @license
 * Unobtrusive validation support library for jQuery and jQuery Validate
 * Copyright (c) .NET Foundation. All rights reserved.
 * Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
 * @version v4.0.0
 */
!function (a) { "function" == typeof define && define.amd ? define("jquery.validate.unobtrusive", ["jquery-validation"], a) : "object" == typeof module && module.exports ? module.exports = a(require("jquery-validation")) : jQuery.validator.unobtrusive = a(jQuery) }(function (s) { var a, o = s.validator, d = "unobtrusiveValidation"; function l(a, e, n) { a.rules[e] = n, a.message && (a.messages[e] = a.message) } function u(a) { return a.replace(/([!"#$%&'()*+,./:;<=>?@\[\\\]^`{|}~])/g, "\\$1") } function n(a) { return a.substr(0, a.lastIndexOf(".") + 1) } function m(a, e) { return a = 0 === a.indexOf("*.") ? a.replace("*.", e) : a } function f(a) { var e = s(this), n = "__jquery_unobtrusive_validation_form_reset"; if (!e.data(n)) { e.data(n, !0); try { e.data("validator").resetForm() } finally { e.removeData(n) } e.find(".validation-summary-errors").addClass("validation-summary-valid").removeClass("validation-summary-errors"), e.find(".field-validation-error").addClass("field-validation-valid").removeClass("field-validation-error").removeData("unobtrusiveContainer").find(">*").removeData("unobtrusiveContainer") } } function p(n) { function a(a, e) { (a = r[a]) && s.isFunction(a) && a.apply(n, e) } var e = s(n), t = e.data(d), i = s.proxy(f, n), r = o.unobtrusive.options || {}; return t || (t = { options: { errorClass: r.errorClass || "input-validation-error", errorElement: r.errorElement || "span", errorPlacement: function () { !function (a, e) { var e = s(this).find("[data-valmsg-for='" + u(e[0].name) + "']"), n = (n = e.attr("data-valmsg-replace")) ? !1 !== s.parseJSON(n) : null; e.removeClass("field-validation-valid").addClass("field-validation-error"), a.data("unobtrusiveContainer", e), n ? (e.empty(), a.removeClass("input-validation-error").appendTo(e)) : a.hide() }.apply(n, arguments), a("errorPlacement", arguments) }, invalidHandler: function () { !function (a, e) { var n = s(this).find("[data-valmsg-summary=true]"), t = n.find("ul"); t && t.length && e.errorList.length && (t.empty(), n.addClass("validation-summary-errors").removeClass("validation-summary-valid"), s.each(e.errorList, function () { s("<li />").html(this.message).appendTo(t) })) }.apply(n, arguments), a("invalidHandler", arguments) }, messages: {}, rules: {}, success: function () { !function (a) { var e, n = a.data("unobtrusiveContainer"); n && (e = (e = n.attr("data-valmsg-replace")) ? s.parseJSON(e) : null, n.addClass("field-validation-valid").removeClass("field-validation-error"), a.removeData("unobtrusiveContainer"), e && n.empty()) }.apply(n, arguments), a("success", arguments) } }, attachValidation: function () { e.off("reset." + d, i).on("reset." + d, i).validate(this.options) }, validate: function () { return e.validate(), e.valid() } }, e.data(d, t)), t } return o.unobtrusive = { adapters: [], parseElement: function (t, a) { var e, i, r, o = s(t), d = o.parents("form")[0]; d && ((e = p(d)).options.rules[t.name] = i = {}, e.options.messages[t.name] = r = {}, s.each(this.adapters, function () { var a = "data-val-" + this.name, e = o.attr(a), n = {}; void 0 !== e && (a += "-", s.each(this.params, function () { n[this] = o.attr(a + this) }), this.adapt({ element: t, form: d, message: e, params: n, rules: i, messages: r })) }), s.extend(i, { __dummy__: !0 }), a || e.attachValidation()) }, parse: function (a) { var a = s(a), e = a.parents().addBack().filter("form").add(a.find("form")).has("[data-val=true]"); a.find("[data-val=true]").each(function () { o.unobtrusive.parseElement(this, !0) }), e.each(function () { var a = p(this); a && a.attachValidation() }) } }, (a = o.unobtrusive.adapters).add = function (a, e, n) { return n || (n = e, e = []), this.push({ name: a, params: e, adapt: n }), this }, a.addBool = function (e, n) { return this.add(e, function (a) { l(a, n || e, !0) }) }, a.addMinMax = function (a, t, i, r, e, n) { return this.add(a, [e || "min", n || "max"], function (a) { var e = a.params.min, n = a.params.max; e && n ? l(a, r, [e, n]) : e ? l(a, t, e) : n && l(a, i, n) }) }, a.addSingleVal = function (e, n, t) { return this.add(e, [n || "val"], function (a) { l(a, t || e, a.params[n]) }) }, o.addMethod("__dummy__", function (a, e, n) { return !0 }), o.addMethod("regex", function (a, e, n) { return !!this.optional(e) || (e = new RegExp(n).exec(a)) && 0 === e.index && e[0].length === a.length }), o.addMethod("nonalphamin", function (a, e, n) { var t; return t = n ? (t = a.match(/\W/g)) && t.length >= n : t }), o.methods.extension ? (a.addSingleVal("accept", "mimtype"), a.addSingleVal("extension", "extension")) : a.addSingleVal("extension", "extension", "accept"), a.addSingleVal("regex", "pattern"), a.addBool("creditcard").addBool("date").addBool("digits").addBool("email").addBool("number").addBool("url"), a.addMinMax("length", "minlength", "maxlength", "rangelength").addMinMax("range", "min", "max", "range"), a.addMinMax("minlength", "minlength").addMinMax("maxlength", "minlength", "maxlength"), a.add("equalto", ["other"], function (a) { var e = n(a.element.name), e = m(a.params.other, e); l(a, "equalTo", s(a.form).find(":input").filter("[name='" + u(e) + "']")[0]) }), a.add("required", function (a) { "INPUT" === a.element.tagName.toUpperCase() && "CHECKBOX" === a.element.type.toUpperCase() || l(a, "required", !0) }), a.add("remote", ["url", "type", "additionalfields"], function (t) { var i = { url: t.params.url, type: t.params.type || "GET", data: {} }, r = n(t.element.name); s.each((t.params.additionalfields || t.element.name).replace(/^\s+|\s+$/g, "").split(/\s*,\s*/g), function (a, e) { var n = m(e, r); i.data[n] = function () { var a = s(t.form).find(":input").filter("[name='" + u(n) + "']"); return a.is(":checkbox") ? a.filter(":checked").val() || a.filter(":hidden").val() || "" : a.is(":radio") ? a.filter(":checked").val() || "" : a.val() } }), l(t, "remote", i) }), a.add("password", ["min", "nonalphamin", "regex"], function (a) { a.params.min && l(a, "minlength", a.params.min), a.params.nonalphamin && l(a, "nonalphamin", a.params.nonalphamin), a.params.regex && l(a, "regex", a.params.regex) }), a.add("fileextensions", ["extensions"], function (a) { l(a, "extension", a.params.extensions) }), s(function () { o.unobtrusive.parse(document) }), o.unobtrusive });