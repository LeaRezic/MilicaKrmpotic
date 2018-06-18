function getCookie(name) {
    var dc = document.cookie;
    var prefix = name + "=";
    var begin = dc.indexOf("; " + prefix);
    if (begin == -1) {
        begin = dc.indexOf(prefix);
        if (begin != 0) return null;
    }
    else {
        begin += 2;
        var end = document.cookie.indexOf(";", begin);
        if (end == -1) {
            end = dc.length;
        }
    }
    return decodeURI(dc.substring(begin + prefix.length, end));
}

function hideOrStyleEditButtons() {
    var myCookie = getCookie("notifyNonAdmin");
    if (myCookie != null) {
        hideEditButtons();
    }
    else {
        styleButtonsAsLinks();
    }
}

function hideEditButtons() {
    var buttons = document.querySelectorAll('input[type="button"]');
    Array.from(buttons).forEach(b => b.style.visibility = "hidden");
    var repeaterButtons = document.querySelectorAll('[id^="mainContent_myRepeater_lbtnEdit"]');
    Array.from(repeaterButtons).forEach(b => b.style.visibility = "hidden");
}

function styleButtonsAsLinks() {
    var updateButtons = document.querySelectorAll('input[type="submit"]');
    for (var i = 0; i < updateButtons.length; i++) {
        if (updateButtons[i].id != "btnLogOut" && updateButtons[i].id != "btnEmailAdmin") {
            updateButtons[i].setAttribute("class", "btn btn-link");
        }
    }
    var editSelectButtons = document.querySelectorAll('input[type="button"]');
    Array.from(editSelectButtons).forEach(b => b.setAttribute("class", "btn btn-link"));
}

function test(type, tekst) {
    switch (type) {
        case 'warning':
            toastr.warning("This is a WARNING toastr from SCRIPT tags " + tekst);
        case 'info':
            toastr.info("This is an INFO toastr from SCRIPT tags " + tekst);
        case 'success':
            toastr.success("This is a SUCCESS toastr from SCRIPT tags " + tekst);
        default:
    }
}