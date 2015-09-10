function autocompleteFirst() {

    var first = $("#Purchases_0__Product_Name");
    AddAutoComplete(first, 1);

    return "Done";
}

function SetNewProductSource(storeId) {

    $(".name").each(function () {
        var $el = $(this);

        AddAutoComplete($el, storeId);
    });
}

function AddNewEditFields() {
    var max_fields = 100; //maximum input boxes allowed
    var wrapper = $(".input_fields_wrap"); //Fields wrapper
    var add_button = $(".add_field_button"); //Add button ID

    var x = 0; //initlal text box count
    $(add_button).click(function (e) { //on add input button click
        e.preventDefault();
        if (x < max_fields - 1) { //max input box allowed
            x++; //text box increment

            var url = "/Checks/EditProductBox?index=" + x;

            $.ajax({
                url: url,
                cache: false,
                type: "POST",
                success: function (data) {

                    var newItem = $(data);
                    wrapper.fadeIn('fast');
                    wrapper.append(newItem);
                    var input = newItem.find('input#Products_Title');
                    var storeId = $("#StoreId").val();
                    AddAutoComplete(input, storeId);


                },
                error: function (reponse) {
                    alert("error : " + reponse);
                }
            });


        }
    });

    $(wrapper).on("click", ".remove_field", function (e) { //user click on remove text
        e.preventDefault();
        $(this).parent('div').remove();
        x--;
    });
}


function AddNewFields() {
    var max_fields = 100; //maximum input boxes allowed
    var wrapper = $(".input_fields_wrap"); //Fields wrapper
    var add_button = $(".add_field_button"); //Add button ID

    var x = 0; //initlal text box count
    $(add_button).click(function (e) { //on add input button click
        e.preventDefault();
        if (x < max_fields - 1) { //max input box allowed
            x++; //text box increment

            var url = "/Checks/ProductBox?index=" + x;

            $.ajax({
                url: url,
                cache: false,
                type: "POST",
                success: function (data) {

                    var newItem = $(data);
                    wrapper.fadeIn('fast');
                    wrapper.append(newItem);
                    var input = newItem.find('input#Purchases_' + x + '__Product_Name');
                    var storeId = $("#StoreId").val();
                    AddAutoComplete(input, storeId);


                },
                error: function (reponse) {
                    alert("error : " + reponse);
                }
            });


        }
    });

    $(wrapper).on("click", ".remove_field", function (e) { //user click on remove text
        e.preventDefault();
        $(this).parent('div').remove();
        x--;
    });
}

function AddAutoComplete(input, storeId) {

    var aurl = '/Checks/FindProducts?storeId=' + storeId + '&fieldId=' + input.attr('index');

    input.autocomplete({
        source: aurl,
        minLength: 2,
        select: function (event, ui) {
            $("#Purchases_" + ui.item.field + "__Product_Price").val(ui.item.price);
            $("#Purchases_" + ui.item.field + "__Count").val("1");
        }
    });
}


function showOverlay() {
    $('#overlay')[0].style.display = 'block';
}

$(function () {
    var height = $(window).height();
    $('body')[0].style.minHeight = height + 'px';

    var rm = $('.right-menu');
    if (rm.length > 0) {
        rm[0].style.height = height + 'px';
    }

    //var card = $('.card-big');
    //if (card.length > 0) {
    //    var cardwidth = card.width();
    //    var img = card.find('.card-image');
    //    if (img.length > 0) {
    //        var width = cardwidth / 16 * 9;
    //        img[0].style.height = width + 'px';

    //    }
    //}
});

$(window).on('resize orientationChanged', function () {
    var height = $(window).height();
    $('body')[0].style.minHeight = height + 'px';

    var rm = $('.right-menu');
    if (rm.length > 0) {
        rm[0].style.height = height + 'px';
    }
});


function setBackground(month) {
    var body = $('body');
    body[0].id = '_' + month;
}

function setRandomBackground() {
    var int = getRandomInt(1, 12);
    setBackground(int);
}

function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

function DetailedInfo(id, request) {


    $('.card-collapsed').each(function () {
        var idc = $(this).attr('id');
        if (idc != id) {
            CloseCard($(this));
        }
    });

    $('#progress-' + id).show();
    var div = $('#' + id);
    if (div.length > 0) {
        getimage(0, encodeURIComponent(request), id, div);
    }
}

function OpenCard(div) {
    var col = 0;
    var colp = "";
    var off = 0;
    var newcol = 0;
    var newoff = 0;

    var width = $(window).width();

    if (width < 768) {
        col = 12;
        newcol = 12;
        colp = 'xs';
    }
    else if (width >= 768 && width < 992) {
        col = 12;
        newcol = 12;
        colp = 'xs';
    }
    else if (width >= 992 && width < 1200) {
        col = 10;
        off = 1;
        newcol = 12;
        colp = 'md';

    } else {
        col = 8;
        off = 2;
        newcol = 10;
        newoff = 1;
        colp = 'lg';
    }

    var oldclass = 'col-' + colp + '-' + col;
    var oldoffset = 'col-' + colp + '-offset-' + off;

    var newclass = 'col-' + colp + '-' + newcol;
    var newoffset = 'col-' + colp + '-offset-' + newoff;

    if (div.hasClass("detailed-info-card")) {
        div.removeClass(newclass);
        div.removeClass(newoffset);
        div.removeClass("detailed-info-card");
        div.addClass(oldoffset);
        div.addClass(oldclass);
    } else {
        div.removeClass(oldoffset);
        div.removeClass(oldclass);
        div.addClass(newclass);
        div.addClass(newoffset);
        div.addClass('detailed-info-card');
    }
}

function CloseCard(div) {
    if (div.hasClass("detailed-info-card")) {

        var col = 0;
        var colp = "";
        var off = 0;
        var newcol = 0;
        var newoff = 0;

        var width = $(window).width();

        if (width < 768) {
            col = 12;
            newcol = 12;
            colp = 'xs';
        }
        else if (width >= 768 && width < 992) {
            col = 12;
            newcol = 12;
            colp = 'xs';
        }
        else if (width >= 992 && width < 1200) {
            col = 10;
            off = 1;
            newcol = 12;
            colp = 'md';

        } else {
            col = 8;
            off = 2;
            newcol = 10;
            newoff = 1;
            colp = 'lg';
        }

        var oldclass = 'col-' + colp + '-' + col;
        var oldoffset = 'col-' + colp + '-offset-' + off;

        var newclass = 'col-' + colp + '-' + newcol;
        var newoffset = 'col-' + colp + '-offset-' + newoff;

        div.removeClass(newclass);
        div.removeClass(newoffset);
        div.removeClass("detailed-info-card");
        div.addClass(oldoffset);
        div.addClass(oldclass);
    }

}

function getimage(id, image_key, imgid, div) {

    $['getJSON']('http://ajax.googleapis.com/ajax/services/search/images?v=1.0&q=' + image_key + '&callback=?', function (json) {
        var img = new Image();
        img.src = (json['responseData']['results'][id]['url']);
        img.onload = function () {
            setTimeout
(
    function () {
        if (!img.complete) {
            getimage(id, json['responseData']['results'][++id], imgid, div);
        }
    },
    3000
);
            $('#img-' + imgid)['attr']('src', img.src);

            var imgdiv = div.find('.detailed-card-img');
            imgdiv.height = imgdiv.width();


            $('#progress-' + imgid).hide();
            OpenCard(div);

        };
        img.onerror = function () {
            getimage(id, json['responseData']['results'][++id], imgid, div);
        };

        //$('#' + imgid)['attr']('src', );
        //$('#' + imgid)['error'](function () {
        //    if (json['responseData']['results'][++id])
        //        getimage(id, image_key); //проверка, чтоб небыло бесконечного цикла
        //});
    });
};

function clearImage(imgId) {
    $('#' + imgId).attr('src', String.empty);

}

function StateStoreImage(textbox) {  
    var img = new Image()
    $('#storePhoto').attr('src', textbox.value);
}

function StateNeighbourImage(textbox) {
    var img = new Image()
    $('#neighbourPhoto').attr('src', textbox.value);
}