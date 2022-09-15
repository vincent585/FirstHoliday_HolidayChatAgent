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
        $('#chatHistory').append(`<p><strong>Chattington:</strong> ${$('#tempLabel').text()}</p>`);
        $('#chatHistory').append(`<p><strong>You:</strong> ${tempRating.value}</p>`);
        $('#chatHistory').append('<p><strong>Chattington:</strong> That\'s great! Next question...</p>');
        $('#tempSelect').hide();
        $('#categorySelect').removeAttr('hidden');
    } else {
        $('#chatHistory').append(`<p><strong>You:</strong> ${tempRating.value}</p>`);
        $('#chatHistory').append("<p><strong>Chattington:</strong> Sorry, I don't know of a place like that...</p>");
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
        $('#chatHistory').append(`<p><strong>Chattington:</strong> ${$('#categoryLabel').text()}</p>`);
        $('#chatHistory').append(`<p><strong>You:</strong> ${category.value}</p>`);
        $('#chatHistory').append('<p><strong>Chattington:</strong> Excellent, I can work with that.</p>');
        $('#categorySelect').hide();
        $('#priceSelect').removeAttr('hidden');
    } else {
        $('#chatHistory').append(`<p><strong>You:</strong> ${category.value}</p>`);
        $('#chatHistory').append("<p><strong>Chattington:</strong> Sorry, I don't know of a place like that...</p>");
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
        $('#chatHistory').append(`<p><strong>Chattington:</strong> ${$('#priceLabel').text()}</p>`);
        $('#chatHistory').append(`<p><strong>You:</strong> ${pricePerNight.value}</p>`);
        $('#chatHistory').append('<p><strong>Chattington:</strong> Excellent, I can work with that.</p>');
        $('#priceSelect').hide();
        $('#chatHistory').append("<p><strong>Chattington:</strong> I think I've got something for you...click the button below to see what I found!</p>");
        $('#submitBtn').removeAttr('disabled');

    } else {
        $('#chatHistory').append(`<p><strong>You:</strong> ${category.value}</p>`);
        $('#chatHistory').append("<p><strong>Chattington:</strong> Sorry, I don't think they will accept that as payment.</p>");
    }
}

function isValidPrice() {
    if (Number(pricePerNight.value)) {
        return true;

    } else {
        return false;
    }
}




