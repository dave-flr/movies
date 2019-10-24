// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('.carousel-cards').slick({
        // dots: false,
        infinite: true,
        speed: 500,
        // slidesToShow: 5,
        // slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 2000,
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
                breakpoint: 768,
                settings: {
                    slidesToShow: 4,
                    slidesToScroll: 1
                }
            },
            {
                breakpoint: 640,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 1
                }
            },
            {
                breakpoint: 380,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1
                }
            },
            {
                breakpoint: 320,
                settings: {
                    slidesToShow: 1,
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
        .rating();
    //Search input
    $('.ui.search')
        .search({
            apiSettings: {
                url: '/Home/SearchMovie/?query={query}'
            },
            fields: {
                title: 'title',
                description: 'year'
                // url: 'id'
            },
            minCharacters: 3,
            maxResults: 6,
            cache: true,
            ignoreDiacritics: true
        })
    ;
});