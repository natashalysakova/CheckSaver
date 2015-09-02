$(function () {
    var card = $('.card-big');
    if (card.length > 0) {
        var cardwidth = card.width();
        var img = card.find('.card-image');
        if (img.length > 0) {
            var width = cardwidth / 16 * 9;
            img[0].style.height = width + 'px';

        }
    }
}
);