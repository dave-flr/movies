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
                onResponse: function (data) {
                    var response = {results: []};
                    $.each(data, function (index, item) {
                        var id = item.id || 'Unknown';
                        item['url'] = "http://localhost:5000/Movie/Id/" + id;
                        response.results.push(item);
                    });
                    return response;
                },
                url: '/Home/SearchMovie/?query={query}'
            },
            fields: {
                title: 'title',
                description: 'year',
                url: 'url'
            },
            minCharacters: 3,
            maxResults: 6,
            cache: true,
            ignoreDiacritics: true,
            debug: false,
            selectFirstResult: true
        })
    ;
    $('.ui.reply.form').hide();
    $('#comment').on('click', function (e) {
        $('.ui.reply.form').show();
    });
    $('.ui.form').form({
        fields: {
            description: {
                identifier: 'Description',
                rules: [{
                    type: 'empty',
                    prompt: 'Por favor ingresa una opinión'
                }]
            },
            rating: {
                identifier: 'Rating',
                rules: [{
                    type: 'integer[1..5]',
                    prompt: 'Por favor agrega una valoración a la Película'
                }]
            }
        }
    });
    $('#RatingInput').rating({
        onRate: function (v) {
            $('#Rating').val(v);
        }
    });
    $('#userDropdown')
        .dropdown()
        .transition('horizontal flip in')
    ;
    $('#logoutItem').on('click', function () {
       $('#logoutForm').submit()
    }); 
    $('#account')
        .form({
            fields: {
                email: {
                    identifier: 'Input_Email',
                    rules: [
                        {
                            type: 'empty',
                            prompt: 'Please enter your e-mail'
                        },
                        {
                            type: 'email',
                            prompt: 'Please enter a valid e-mail'
                        }
                    ]
                },
                password: {
                    identifier: 'Input_Password',
                    rules: [
                        {
                            type: 'empty',
                            prompt: 'Please enter your password'
                        },
                        {
                            type: 'length[6]',
                            prompt: 'Your password must be at least 6 characters'
                        }
                    ]
                }
            }
        })
    ;
    $('#registerForm')
        .form({
            fields: {
                email: {
                    identifier: 'Input_Email',
                    rules: [
                        {
                            type: 'empty',
                            prompt: 'Please enter your e-mail'
                        },
                        {
                            type: 'email',
                            prompt: 'Please enter a valid e-mail'
                        }
                    ]
                },
                confirm_password: {
                    identifier: 'Input_Password',
                    rules: [
                        {
                            type: 'empty',
                            prompt: 'Please enter your password'
                        },
                        {
                            type: 'length[6]',
                            prompt: 'Your password must be at least 6 characters'
                        }
                    ]
                },
                password: {
                    identifier: 'Input_ConfirmPassword',
                    rules: [
                        {
                            type: 'empty',
                            prompt: 'Please enter your password'
                        },
                        {
                            type: 'length[6]',
                            prompt: 'Your password must be at least 6 characters'
                        }
                    ]
                }
            }
        })
    ;
});