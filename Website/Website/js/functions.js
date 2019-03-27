jQuery(document).ready(function ($) {

    window.onscroll = function () { myFunction(); change(); change1(); };

    function myFunction() {
        var winScroll = document.body.scrollTop || document.documentElement.scrollTop;
        var height = document.documentElement.scrollHeight - document.documentElement.clientHeight;
        var scrolled = (winScroll / height) * 100;
        document.getElementById("myBar").style.width = scrolled + "%";
    }

    $(".open").click(function (e) {
        $(this).parents(".menuItems").find(".info").slideToggle();
        if ($(this).find(".faqPlus").hasClass('rotate')) {
            $(this).find('.faqPlus').removeClass('rotate');
            $(this).find('.faqPlus').addClass('rotate1');
        } else {
            $(this).find('.faqPlus').addClass('rotate');
            $(this).find('.faqPlus').removeClass('rotate1');
        }
    });

});