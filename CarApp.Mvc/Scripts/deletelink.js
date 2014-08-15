$(function () {
    $(".DeleteLink").click(function (e) {
        e.preventDefault();

        var self = $(this);
        var url = self.attr('href');
        $.post(url, null, function (data) {
            if (data.success) {
                self.parent().parent().remove();
            }
            else {
                alert("Hiba!");
            }
        }).fail(function () {
            alert("Hiba!");
        })
    })
});
