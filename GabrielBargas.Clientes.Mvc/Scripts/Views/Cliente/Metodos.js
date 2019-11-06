$('#btnInativar').click(function () {
    var url = "/Cliente/InativarCliente";
    var id = $("#ID_CLIENTE").val();
    $.post(url, { id: id }, function (data) {
    });
});