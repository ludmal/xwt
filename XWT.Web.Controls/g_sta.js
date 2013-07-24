var _time = 10000;

function addMethod(object, name, fn) {
    var old = object[name];
    object[name] = function () {
        if (fn.length == arguments.length)
            return fn.apply(this, arguments);
        else if (typeof old == 'function')
            return old.apply(this, arguments);
    };
}

function _util() {
    addMethod(this, "hide", function (ctrl) {
        $(ctrl).hide();

    });

    addMethod(this, "show", function (ctrl) {
        $(ctrl).show();

    });

    addMethod(this, "setLoc", function (ctrl) {
        var w = ($(window).width() / 2) - ($(ctrl).width() / 2);
        $(ctrl).css("left", w);

    });


    addMethod(this, "toggleClass", function (D, CS1, CS2) {
        if ($(D).hasClass(CS1)) {
            $(D).removeClass(CS1)
            $(D).addClass(CS2);
        } else {
            $(D).removeClass(CS2)
            $(D).addClass(CS1);
        }

    });
}
var util = new _util();

function _msg() {
    addMethod(this, "text", function (T) {
        _setMsg(T, '', 0, _time);
        return false;
    });

    addMethod(this, "text", function (T, CS, TM) {
        _setMsg(T, CS, 0, TM);
        return false;
    });

    addMethod(this, "html", function (T) {
        _setMsg(T, '', 1, _time);
        return false;
    });

    addMethod(this, "html", function (T, CS, TM) {
        _setMsg(T, CS, 1, TM);
        return false;
    });
}

function _setMsg(T, CS, isHtml, TM) {
    if ($("#___msg_box").is(":hidden")) {
        $("#___msg_box").show();
    }
    if (isHtml == 0) {
        $("#___msg_box").text(T);
    } else {
        $("#___msg_box").html(T);
    }
    if (CS != '') {
        $("#___msg_box").addClass(CS);
    } else {
        $("#___msg_box").addClass("msg_iwt");
    }

    _setMsgLocation();
    if (TM == 0) {
        TM = _time;
    }

    setTimeout(function () { $("#___msg_box").hide() }, TM);
    return false;
}

function _setMsgLocation() {
    var w = ($(window).width() / 2) - ($("#___msg_box").width() / 2);
    $("#___msg_box").css("left", w);
}

$(window).scroll(function () {
    $('#___msg_box').css("top", $(window).scrollTop() + "px")
});

$(window).resize(function () {
    $('#___msg_box').css("top", $(window).scrollTop() + "px")
    _setMsgLocation();
});

var msg = new _msg();

function modalDialog() {
    addMethod(this, "show", function (url, T) {
        _show(url, T, 600, 400);
    });
    addMethod(this, "show", function (url, T, W, H) {
        _show(url, T, W, H);
    });

    addMethod(this, "c", function () {
        util.hide('#overlay');
        $("body").css("overflow", "");
        util.hide('#modal_outer');
        sCor(1);
    });

    addMethod(this, "showHtml", function (HT, T) {
        _showHtml(HT, T, 600, 400);
    });

    addMethod(this, "showHtml", function (HT, T, W, H) {
        _showHtml(HT, T, W, H);
    });
}

function overlay_resize() {

}

function _showHtml(HT, T, W, H) {
    A(T, W, H);
    $(".modal_title").hide();
    $("#modal_iframe").html(HT);
    return false;
}

function A(T, W, H) {
    $("#modal_outer").width(W);
    $("#modal_outer").height(H + 18);
    var h = H;

    $("#modal_frame").height(h);
    $("#modal_iframe").height(h - 48);

    $("#modalTitle").text(T);

    util.show("#overlay");
    $("body").css("overflow", "hidden");

    $("#overlay").width($(window).width());
    $("#overlay").height($(window).height());

    util.setLoc('#modal_outer');

    util.show("#modal_outer");
}

function _show(url, T, W, H) {
    A(T, W, H);

    var frame = document.getElementById('modalIFrame');

    if (frame.src != url) {
        document.getElementById('modalIFrame').src = url;
    }

    return false;
}

var modal = new modalDialog();
