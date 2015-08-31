$(document).ready(function () {

    $("#report").on("click", function (e) {
        e.preventDefault();
        $("#reportConfirm").fadeIn("fast");
        $.post('/Pins/AddFlag/' + e.target.dataset['id']);
    });

    //$(".deleteComment").on("click", function (e) {
    //    e.preventDefault();
    //    $("#commentTableData").each(function () {
    //        $(this).fadeOut("fast");
    //        $.post('/Comments/DeleteReally/' + e.target.dataset['id']);
    //    })
    //});
});
