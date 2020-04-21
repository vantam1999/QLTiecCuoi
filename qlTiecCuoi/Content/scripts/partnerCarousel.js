$(document).ready(() => {
    // ==== carousel partner ==== //
    $('.partner__carousel').owlCarousel({
        loop: true,
        margin: 10,      
        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 3
            },
            960: {
                items: 5
            },
            1200: {
                items: 7
            }
        }
    });
    // ==== carousel homepage section giới thiệu ==== //
    $('.section__about--carousel').owlCarousel({
        loop: true,
        margin: 10,
        items: 1
    });
});


