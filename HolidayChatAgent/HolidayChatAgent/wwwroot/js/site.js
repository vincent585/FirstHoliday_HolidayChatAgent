﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

window.onload = function () {
    const toastChat = document.getElementById("chatToast");
    const toast = new bootstrap.Toast(toastChat);

    toast.show();
}
