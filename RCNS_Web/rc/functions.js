// JavaScript Document
var main = function () {
    "use strict";

    $('.btnGetStarted').hover(function () {

        $('.lblGetStarted').css("color", "white");

    }, function () {

        $('.lblGetStarted').css("color", "#3F3F3F");

    });

    $('.btnGo').click(function () {
        document.getElementById('Clicked').innerHTML = "Clicked";

        $('.btnGo').css("background-image", "url(load.gif)");
    });

    $('.btnGoX').click(function () {
        document.getElementById('Clicked').innerHTML = "Clicked";

        $('.btnGoX').css("background-image", "url(load.gif)");
    });

    $('.btnGoX').click(function () {
        if (counter % 2 === 0) {
            document.getElementById('Clicked').innerHTML = "Clicked";
            counter = 1;
            if (counter % 2 === 0) {
                $('.Checkbox').addClass('isChecked');
            }
            else {
                $('.Checkbox').removeClass('isChecked');
            }
        }
    });

    var counter = 1;
    $('.Checkbox').click(function () {
        counter++;

        if (counter % 2 === 0) {
            $('.Checkbox').addClass('isChecked');
        }
        else {
            $('.Checkbox').removeClass('isChecked');
        }
    });

};


$(document).ready(main);




