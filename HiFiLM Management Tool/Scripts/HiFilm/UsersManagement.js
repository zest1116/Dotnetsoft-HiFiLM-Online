$(function () {
    $(".card-body").css('height', $(document).height());

    $(".card-tools input").keypress(function (e) {
        if (e.keyCode == 13) {
            var url = $(this).data('request-url');
            var keyword = $(this)[0].value;
            $.ajax({
                type: "POST",
                url: url,
                dataType: "json",
                data: { keyword: keyword },
                error: function (error) {
                    alert(error);
                },
                success: function (data) {
                    alert(data);
                }
            });
        }
    });
});