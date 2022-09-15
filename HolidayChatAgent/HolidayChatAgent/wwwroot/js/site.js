// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

window.onload = function () {
    const toastChat = document.getElementById("chatToast");
    const toast = new bootstrap.Toast(toastChat);

    toast.show();
}

const chatHistory = document.getElementById("chatHistory");
const tempRating = document.getElementById("TempRating");
const category = document.getElementById("category");
const pricePerNight = document.getElementById("pricepernight");

document.getElementById("preferencesForm").onkeypress = function(e) {
    const key = e.charCode || e.keyCode || 0;
    if (key === 13) {
        e.preventDefault();
    }
}

tempRating.addEventListener("keydown",
    function(e) {
        if (e.code === "Enter") {
            handleTempRatingInput();
        };
    });

category.addEventListener("keydown",
    function (e) {
        if (e.code === "Enter") {
            handleCategoryInput();
        };
    });

pricePerNight.addEventListener("keydown",
    function (e) {
        if (e.code === "Enter") {
            handlePriceInput();
        };
    });

function handleTempRatingInput() {
    if (isValidTempRating()) {
        $('#chatHistory').append(`<p><em>${$('#tempLabel').text()}</em></p>`);
        $('#chatHistory').append(`<p><strong>${tempRating.value}</strong></p>`);
        $('#chatHistory').append('<em>That\'s great! Next question...</em>');
        $('#tempSelect').hide();
        $('#categorySelect').removeAttr('hidden');
    } else {
        $('#chatHistory').append(`<p><strong>${tempRating.value}</strong></p>`);
        $('#chatHistory').append("<p><em>Sorry, I don't know of a place like that...</em></p>");
    }
}

function isValidTempRating() {
    if (tempRating.value.toLowerCase() === "cold" ||
        tempRating.value.toLowerCase() === "mild" ||
        tempRating.value.toLowerCase() === "hot") {
        return true;
        
    } else {
        return false;
    }
}

function handleCategoryInput() {
    if (isValidTempRating()) {
        $('#chatHistory').append(`<p><em>${$('#categoryLabel').text()}</em></p>`);
        $('#chatHistory').append(`<p><strong>${category.value}</strong></p>`);
        $('#chatHistory').append('<em>Excellent, I can work with that.</em>');
        $('#categorySelect').hide();
        $('#priceSelect').removeAttr('hidden');
    } else {
        $('#chatHistory').append(`<p><strong>${category.value}</strong></p>`);
        $('#chatHistory').append("<p><em>Sorry, I don't know of a place like that...</em></p>");
    }
}

function isValidCategory() {
    if (tempRating.value.toLowerCase() === "active" ||
        tempRating.value.toLowerCase() === "lazy") {
        return true;

    } else {
        return false;
    }
}

function handlePriceInput() {
    if (isValidPrice()) {
        $('#chatHistory').append(`<p><em>${$('#priceLabel').text()}</em></p>`);
        $('#chatHistory').append(`<p><strong>${pricePerNight.value}</strong></p>`);
        $('#chatHistory').append('<em>Excellent, I can work with that.</em>');
        $('#priceSelect').hide();
        $('#chatHistory').append("<p>I think I've got something for you...click the button below to see what I found!</p>");
        $('#submitBtn').removeAttr('disabled');

    } else {
        $('#chatHistory').append(`<p><strong>${category.value}</strong></p>`);
        $('#chatHistory').append("<p><em>Sorry, I don't think they will accept that as payment.</em></p>");
    }
}

function isValidPrice() {
    if (Number(pricePerNight.value)) {
        return true;

    } else {
        return false;
    }
}




