/**
 * Document is ready function
 */
$().ready(function () {

    //According to the status, the buttons and messages displayed change
    if ($('#status').val() == "NotFound") {
        $('#confirmNotFound').text('Confirmar Not_Found');
        $('#confirmPicked').text('Corrigir para Picked');

        $('#divNotFound').insertAfter('#divPicked');
        $('#confirmNotFound').css('color', 'green');
        $('#confirmPicked').css('color', 'red');

    } else if ($('#status').val() == "Picked") {
        $('#confirmNotFound').text('Corrigir para Not_Found');
        $('#confirmPicked').text('Confirmar Picked');

        $('#divPicked').insertAfter('#divNotFound');
        $('#confirmPicked').css('color', 'green');
        $('#confirmNotFound').css('color', 'red');
    }

    $('#message').text('');
});

/**
 * Add the loading effect
 */
$(document).ajaxStart(function () {
    $('#contentWrapper').addClass("loading");
})

/**
 * Check or uncheck all checkboxes.
 */
$('#checkboxToogleAll').click(function () {

    if ($(this).is(':checked')) {
        $('[id^=checkboxItem]').each(function () {
            $(this).prop('checked', true).checkboxradio('refresh');
        });
    } else {
        $('[id^=checkboxItem]').each(function () {
            $(this).prop('checked', false).checkboxradio('refresh');
        });
    }

});

$('#hrefHome').click(function () {
    window.location.href = '/';
});

$('#hrefPicked').click(function () {
    window.location.href = '../ConfirmItems/Picked';
});

$('#hrefNotFound').click(function () {
    window.location.href = '../ConfirmItems/NotFound';
});

/**
 * Call method in controller to change the status to 'Picked'
 */
$('#confirmPicked').click(function () {

    var arrayProductOrder = new Array();
    var isMarked = false;

    $(this).parents().siblings('#controlGroup').children().find('.checkBoxWrap').each(function () {

        if ($(this).children().find('[id^=checkboxItem]').is(':checked')) {
            arrayProductOrder.push(new ProductOrder($(this).children().find('#productId').val(),
            $(this).children().find('#obs').val(),
            'Picked'));

            isMarked = true;
        }
    });

    if (isMarked) {
        $('#message').text('');

        $.ajax({
            type: "POST",
            url: '/Home/ConfirmStatus',
            data: JSON.stringify(arrayProductOrder),
            contentType: 'application/json',
            success: function (data) {
                window.location.href = '/';
            },
            error: function (request, status, error) {
                alert(request.responseText);
            }
        });
    } else {
        $('#message').text('Nenhum item selecionado');
    }
});

/**
 * Call method in controller to change the status to 'Not_Found'
 */
$('#confirmNotFound').click(function () {

    var arrayProductOrder = new Array();
    var isMarked = false;

    $(this).parents().siblings('#controlGroup').children().find('.checkBoxWrap').each(function () {

        if ($(this).children().find('[id^=checkboxItem]').is(':checked')) {
            arrayProductOrder.push(new ProductOrder($(this).children().find('#productId').val(),
            $(this).children().find('#obs').val(),
            'Not_Found'));

            isMarked = true;
        }
    });

    if (isMarked) {
        $('#message').text('');
        $.ajax({
            type: "POST",
            url: '/Home/ConfirmStatus',
            data: JSON.stringify(arrayProductOrder),
            contentType: 'application/json',
            success: function (data) {
                window.location.href = '/';
            },
            error: function (request, status, error) {
                alert(request.responseText);
            }
        });
    } else {
        $('#message').text('Nenhum item selecionado');
    }
});

function ProductOrder(productId, obs, status) {
    var self = this;

    self.ProductId = productId;
    self.Observations = obs;
    self.Status = status;
}