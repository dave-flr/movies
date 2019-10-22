// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('.cards').slick({
        lazyLoad: 'ondemand',
        // dots: false,
        infinite: true,
        speed: 500,
        // slidesToShow: 5,
        // slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 1500,
        mobileFirst: true,
        responsive: [{
                breakpoint: 1024,
                settings: {
                    slidesToShow: 6,
                    slidesToScroll: 1,
                    infinite: true,
                    dots: false
                }
            },
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1
                }
            }
            // You can unslick at a given breakpoint now by adding:
            // settings: "unslick"
            // instead of a settings object
        ]
    });

    // Show dropdown when clicked
    $('#header-btn').on('click', function (e) {
        $('#principal-header').toggleClass('active');
        $('.nav-btn').toggleClass('active');
    });

    // Hide menu after clicking menu item
    $('.dropdown-menu li').on('click', function (e) {
        $('#principal-header').removeClass('active');
        $('.nav-btn').removeClass('active');
    });
    //Rating
    $('.ui.rating')
        .rating('disable');
});