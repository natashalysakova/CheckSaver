/*!
 * Start Bootstrap - Agnecy Bootstrap Theme (http://startbootstrap.com)
 * Code licensed under the Apache License v2.0.
 * For details, see http://www.apache.org/licenses/LICENSE-2.0.
 */

// jQuery for page scrolling feature - requires jQuery Easing plugin
$(function () {
    //$('a.page-scroll').bind('click', function(event) {
    //    var $anchor = $(this);
    //    $('html, body').stop().animate({
    //        scrollTop: $($anchor.attr('href')).offset().top
    //    }, 1500, 'easeInOutExpo');
    //    event.preventDefault();
    //});
    setTimeout(AddPageScroll, 500);

});

function AddPageScroll() {
    var pagescrols = $('a.page-scroll');
    if (pagescrols.length > 0) {
        pagescrols.bind('click', function (event) {
            var $anchor = $(this);
            $('html, body').stop().animate({
                scrollTop: $($anchor.attr('href')).offset().top
            }, 1500, 'easeInOutExpo');
            event.preventDefault();
        });

    }
}


// Highlight the top nav as scrolling occurs
$('body').scrollspy({
    target: '.navbar-fixed-top'
})

// Closes the Responsive Menu on Menu Item Click
$('.navbar-collapse ul li a').click(function() {
    $('.navbar-toggle:visible').click();
});


function ShowOverlay(videoUrl) {
    $('.overlay').show();
    $('.embed-responsive-item')[0].src = videoUrl + '?rel=0&amp;showinfo=0';
}

function closeOverlay() {
    $('.overlay').hide();
    $('.embed-responsive-item')[0].src = '';
}