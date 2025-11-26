
$("document").ready(function () {

    //***************** Bootstrap Affix ***********************
    $(".navbar").affix({
        offset: {
            top: $('.header').height()
        }
    });
    $(".navbar-wrpper").height($(".navbar").height());
    //*****************End  Bootstrap Affix ***********************

    //**************** Menu Highlight *****************************
    var url = window.location;   
    // passes on every "a" tag
    $(".nav a").each(function () {
       
        // checks if its the same on the address bar
        if (url == (this.href)) {
            $(".navbar a").removeClass("active-menu");
            $(this).closest("li").addClass("active-menu");
        }
    });
    $(".navbar-brand").each(function () {
        if (url == (this.href)) {
            $(this).closest(".navbar a").addClass("active-menu");
        }
    });
    //**************** End Menu Highlight *****************************

    /*Start // added by nour on 3rd Oct, 2019*/
    $(".onlyNumber").keypress(function (e) {
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            var err = "#" + $(this).attr('data-error');
            var errElm = $(err);
            if (errElm.length) {
                $(err).html("Digits Only").show().fadeOut(3000);
            }
            return false;
        }
    });
    $(".onlyFloat").keypress(function (e) {
        if (e.which != 8 && e.which != 0 && e.which != 46 && (e.which < 48 || e.which > 57)) {
            var err = "#" + $(this).attr('data-error');
            var errElm = $(err);
            if (errElm.length) {
                $(err).html("Digits Only").show().fadeOut(3000);
            }
            return false;
        }
    });
    $(".onlyMobile").keypress(function (e) {
        if ($(this).val().length == 0) {
            if (e.which != 48) {
                var errr = "#" + $(this).attr('data-error');
                var errrElm = $(errr);
                if (errrElm.length) {
                    $(errr).html("First number must be 0").show().fadeOut(3000);
                }
                return false;
            }
        }

        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            var err = "#" + $(this).attr('data-error');
            var errElm = $(err);
            if (errElm.length) {
                $(err).html("Digits Only").show().fadeOut(3000);
            }
            return false;
        }
    });
    /*End // added by nour on 3rd Oct, 2019*/
});

function swalert(title, msg, type) {
    title = title ? title : 'Success';
    msg = msg ? msg : 'Action Complete Successfully';
    type = type ? type : 'success';

    Swal.fire(
        title + ' !',
        msg + ' !',
        type
    );
}

var prm = Sys.WebForms.PageRequestManager.getInstance();
prm.add_endRequest(function () {
    $(".onlyNumber").keypress(function (e) {
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            var err = "#" + $(this).attr('data-error');
            var errElm = $(err);
            if (errElm.length) {
                $(err).html("Digits Only").show().fadeOut(3000);
            }
            return false;
        }
    });
    $(".onlyFloat").keypress(function (e) {
        if (e.which != 8 && e.which != 0 && e.which != 46 && (e.which < 48 || e.which > 57)) {
            var err = "#" + $(this).attr('data-error');
            var errElm = $(err);
            if (errElm.length) {
                $(err).html("Digits Only").show().fadeOut(3000);
            }
            return false;
        }
    });
    $(".onlyMobile").keypress(function (e) {
        if ($(this).val().length == 0) {
            if (e.which != 48) {
                var errr = "#" + $(this).attr('data-error');
                var errrElm = $(errr);
                if (errrElm.length) {
                    $(errr).html("First number must be 0").show().fadeOut(3000);
                }
                return false;
            }
        }

        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            var err = "#" + $(this).attr('data-error');
            var errElm = $(err);
            if (errElm.length) {
                $(err).html("Digits Only").show().fadeOut(3000);
            }
            return false;
        }
    });
    function swalert(title, msg, type) {
        title = title ? title : 'Success';
        msg = msg ? msg : 'Action Complete Successfully';
        type = type ? type : 'success';

        Swal.fire(
            title + ' !',
            msg + ' !',
            type
        );
    }
});