
$(document).ready(function () {
    $('.ajax-ucitaj-nalaz').click(function () {
        event.preventDefault();

        $(this).addClass('disabled');
        var url = $(this).attr('href');
        var row = $(this).closest("tr");
        $.get(url, function (data) {
            $("<tr>\
                    <td colspan='5'>" + data + "</td>\
                    </tr>").insertAfter(row);
        })
    })
})