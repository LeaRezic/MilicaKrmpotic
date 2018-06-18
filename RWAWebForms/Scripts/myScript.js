
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