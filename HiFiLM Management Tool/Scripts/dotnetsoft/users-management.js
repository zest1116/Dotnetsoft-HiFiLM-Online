function loadUserEntry(obj) {
    var url = $(obj).data("url");
    $.ajax({
        type: "GET",
        url: url,
        error: function (error) {
            alert(error);
        },
        success: function (data) {
            $("#divUserEntry").html(data);
            $("#modalUserEntry").modal("show");
        }
    });
}