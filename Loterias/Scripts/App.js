$(function () {
    $('#surpresinha').change(function () {
        if ($(this).attr('checked')) {
            $("input[name='numero']").toggleClass('disabled');
        } else {
            $("input[name='numero']").toggleClass('disabled');
        }
    });
});