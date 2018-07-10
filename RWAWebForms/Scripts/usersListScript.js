
function hideEditButtons() {
    var buttons = document.querySelectorAll('input[type="button"]');
    Array.from(buttons).forEach(b => b.style.visibility = "hidden");
    var repeaterButtons = document.querySelectorAll('[id^="mainContent_myRepeater_lbtnEdit"]');
    Array.from(repeaterButtons).forEach(b => b.style.visibility = "hidden");
}