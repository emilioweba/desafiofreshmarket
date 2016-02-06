/**
 * jTinder initialization
 */
$("#tinderslide").jTinder({

    onDislike: function (item) {
        var productId = $(item).children('#productId').val();
        var observations = $(item).children('#observations').val();

        $.post('/Home/SetOnDislike', { id: productId, obs: observations });
    },

    onLike: function (item) {
        var productId = $(item).children('#productId').val();
        var observations = $(item).children('#observations').val();

        $.post('/Home/SetOnLike', { id: productId, obs: observations });
    },
    animationRevertSpeed: 200,
    animationSpeed: 400,
    threshold: 1,
    likeSelector: '.like',
    dislikeSelector: '.dislike'
});

/**
 * Set button action to trigger jTinder like & dislike.
 */
$('.actions .like, .actions .dislike').click(function (e) {
    e.preventDefault();
    $("#tinderslide").jTinder($(this).attr('class'));
});

$(function () {
    $('.ui-link').removeClass('ui-link');
});

/**
 * Call method in controller to Reset the product status to 'Waiting_for_Pickup'
 */
$('#resetWaitingForPickup').click(function () {

    $.ajax({
        type: "POST",
        url: '/Home/ResetWaitingPickup',
        success: function (data) {
            window.location.href = '/Home/Index/';
        },
        error: function (request, status, error) {
            alert(request.responseText);
        }
    });
});

$('#hrefHome').click(function () {
    window.location.href = '/';
});

$('#hrefPicked').click(function () {
    window.location.href = '../Home/ConfirmItems/Picked';
});

$('#hrefNotFound').click(function () {
    window.location.href = '../Home/ConfirmItems/NotFound';
});

