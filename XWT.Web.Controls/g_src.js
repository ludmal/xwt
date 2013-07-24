var _T = 10000;

function addMethod(O, N, F) {
    var old = O[N];
    O[N] = function () {
        if (F.length == arguments.length)
            return F.apply(this, arguments);
        else if (typeof old == 'function')
            return old.apply(this, arguments);
    };
}

function _util() {
    addMethod(this, "hide", function (C) {
        $(C).hide();

    });

    addMethod(this, "show", function (C) {
        $(C).show();

    });

    addMethod(this, "setLoc", function (C) {
        var w = ($(window).width() / 2) - ($(C).width() / 2);
        $(C).css("left", w);

    });


    addMethod(this, "toggleClass", function (D, C, E) {
        if ($(D).hasClass(C)) {
            $(D).removeClass(C)
            $(D).addClass(E);
        } else {
            $(D).removeClass(E)
            $(D).addClass(C);
        }

    });
}
var util = new _util();

function _msg() {
    addMethod(this, "text", function (T) {
        _setMsg(T, '', 0, _T);
        return false;
    });

    addMethod(this, "text", function (T, C, A) {
        _setMsg(T, C, 0, A);
        return false;
    });

    addMethod(this, "html", function (T) {
        _setMsg(T, '', 1, _T);
        return false;
    });

    addMethod(this, "html", function (T, C, A) {
        _setMsg(T, C, 1, A);
        return false;
    });
}

function _setMsg(T, C, H, B) {
    if ($("#___msg_box").is(":hidden")) {
        $("#___msg_box").show();
    }
    if (H == 0) {
        $("#___msg_box").text(T);
    } else {
        $("#___msg_box").html(T);
    }
    if (C != '') {
        $("#___msg_box").addClass(C);
    } else {
        $("#___msg_box").addClass("msg_iwt");
    }

    _setMsgLoc();
    if (B == 0) {
        B = _T;
    }

    setTimeout(function () { $("#___msg_box").hide() }, B);
    return false;
}

function _setMsgLoc() {
    var w = ($(window).width() / 2) - ($("#___msg_box").width() / 2);
    $("#___msg_box").css("left", w);
}

$(window).scroll(function () {
    $('#___msg_box').css("top", $(window).scrollTop() + "px")
});

$(window).resize(function () {
    $('#___msg_box').css("top", $(window).scrollTop() + "px")
    _setMsgLoc();
});

var msg = new _msg();

function modalDialog() {
    addMethod(this, "show", function (U, T) {
        _show(U, T, 600, 400);
    });
    addMethod(this, "show", function (U, T, W, H) {
        _show(U, T, W, H);
    });

    addMethod(this, "c", function () {
        util.hide('#overlay');
        $("body").css("overflow", "");
        util.hide('#modal_outer');
        sCor(1);
    });

    addMethod(this, "showHtml", function (M, T) {
        _showHtml(M, T, 600, 400);
    });

    addMethod(this, "showHtml", function (M, T, W, H) {
        _showHtml(M, T, W, H);
    });
}

function overlay_resize() {

}

function _showHtml(M, T, H, B) {
    _showCore(T, H, B);
    $(".modal_title").hide();   
    $("#modal_iframe").html(M);
    return false;
}

function _showCore(T, H, B) {
    $("#modal_outer").width(H);
    $("#modal_outer").height(B + 18);
    var h = B;
    sCor(0);
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

function _show(U, T, H, B) {
    _showCore(T, H, B);

    var frame = document.getElementById('modalIFrame');

    if (frame.src != U) {
        document.getElementById('modalIFrame').src = U;
    }

    return false;
}

function sCor(v) {
    if (v == 0) {
        util.hide("#carousel");

    } else {
        util.show("#carousel");
    }
}

var modal = new modalDialog();
