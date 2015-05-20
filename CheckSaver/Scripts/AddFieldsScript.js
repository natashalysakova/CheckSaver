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