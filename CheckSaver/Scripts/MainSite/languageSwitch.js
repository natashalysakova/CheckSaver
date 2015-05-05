/**
 * Created by hatassska on 01.04.2015.
 */

function switchLanguage(locale)
{
    var locId = localStorage.getItem('languageId');

    switch (locale)
    {
        case 'ru': locId = 0;
            break;
        case 'ua': locId = 1;
            break;
        case 'en': locId = 2;
            break;
        default : locId = 0;
    }
    console.log("switched");
    localStorage.setItem('languageId',locId);
    location.reload();
}

function loadPage(){
    var locId = localStorage.getItem('languageId');
    if(locId == null)
    {
        localStorage.setItem('languageId',0);
        locId = 0;
    }
    var path;

    switch (locId)
    {
        case "0": path = 'ru/';
            break;
        case "1": path = 'ua/';
            break;
        case "2": path = 'en/';
            break;
        default: path = 'ru/';
            break;
    }

    CheckIfExist(path, "navbar");
    CheckIfExist(path, "resume");
    CheckIfExist(path, "biography");
    CheckIfExist(path, "referat");
    CheckIfExist(path, "library");
    CheckIfExist(path, "links");
    CheckIfExist(path, "report");
    CheckIfExist(path, "individual");
    CheckIfExist(path, "application");
    CheckIfExist(path, "footer");

}

function CheckIfExist(pathOne, pathTwo)
{
    var fullPath = pathOne + pathTwo;

    $.ajax({
        url: '/MainSite/GetBlock?name=' + fullPath,
        type:'POST', 
        error: function()
        {
            $( "#" + pathTwo).hide();
        },
        success: function (data) {
            if (data != "") {
                var obj = $("#" + pathTwo);
                obj[0].innerHTML = data;
            } else {
                $("#" + pathTwo).hide();
                console.log(pathTwo + " not exist");
            }
        }
    });
}