function hideMasterLoginButtons() {
    var btnEmail = document.getElementById("btnEmailAdmin");
    var btnLogOut = document.getElementById("btnLogOut");
    btnEmail.style.visibility = "visible";
    btnLogOut.style.visibility = "visible";
    console.log("patka");
}
window.onload = hideMasterLoginButtons;