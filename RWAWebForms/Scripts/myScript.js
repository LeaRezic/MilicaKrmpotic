
function markCurrentNavButton(buttonID) {
    var currentLB = document.getElementById(buttonID);
    currentLB.setAttribute("class", "btn btn-primary");
}

function showMasterLoginEmailButtons() {
    var btnEmail = document.getElementById("btnEmailAdmin");
    var btnLogOut = document.getElementById("btnLogOut");
    btnEmail.style.visibility = "visible";
    btnLogOut.style.visibility = "visible";
}

function showToastr(type, message) {
    switch (type) {
        case 'info':
            toastr.info(message);
            break;
        case 'warning':
            toastr.warning(message);
            break;
        case 'success':
            toastr.success(message);
            break;
        default:
            break;
    }
}

function hideEditButtonsGridAndRepeater() {
    var buttons = document.querySelectorAll('input[type="button"]');
    Array.from(buttons).forEach(b => b.style.visibility = "hidden");
    var repeaterButtons = document.querySelectorAll('[id^="mainContent_myRepeater_lbtnEdit"]');
    Array.from(repeaterButtons).forEach(b => b.style.visibility = "hidden");
}