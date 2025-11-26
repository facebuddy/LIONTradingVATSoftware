function setCookie(name, value, days) {
    var expires = "";
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toUTCString();
    }
    document.cookie = name + "=" + (value || "") + expires + "; path=/";
}

function getCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ')
            c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0)
            return c.substring(nameEQ.length, c.length);
    }
    return null;
}

function eraseCookie(name) {
    document.cookie = name + '=; Max-Age=-99999999;';
}

function EncryptData(data)
{
    var key = CryptoJS.enc.Utf8.parse('8056483646328763');
    var iv = CryptoJS.enc.Utf8.parse('8056483646328763');
    var encrypted = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse(data), key,
    {
        keySize: 128 / 8,
        iv: iv,
        mode: CryptoJS.mode.CBC,
        padding: CryptoJS.pad.Pkcs7
    }).toString();
    return encrypted;
}






$(document).ready(function() {
    $("#logOut").on("click", function(event) {

        eraseCookie('role_id');
        eraseCookie('user_id');
        window.location.href = "/";

        // alert("Success");
    });
});



