// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("#btnCreate").click(function () {
    $.ajax(
        {
            type: 'GET',
            url: '/Calendar/CreateAppointment',
            contentType: 'application/json; charset=utf=8',
            success: function (result) {
                $('#appointmentModal-content').html(result);
                $('#appointmentModal').modal('show');
            },
            error: function (er) {
                alert(er);
            }
        });
});

$('body').on('click', '#btnEdit', function () {
    var id = $(this).data('id');
    $.ajax(
        {
            type: 'GET',
            url: '/Calendar/EditAppointment/' + id,
            contentType: 'application/json; charset=utf=8',
            success: function (result) {
                $('#appointmentModal-content').html(result);
                $('#appointmentModal').modal('show');
            },
            error: function (er) {
                alert(er);
            }
        });
});

$(".btnMonth").click(function () {
    $(".btnMonth").removeClass('active');
    $(this).addClass('active');
    var month = $(this).data('id');
    $.ajax({
        type: "GET",
        contentType: 'application/html; charset=utf-8',
        url: "/appointments/" + month,
        success: function (result) {
            $('#appointments').html(result);
        },
        error: function (error) {
            console.log(error);
        },
    });
});

$('body').on('click', 'a.list-group-item', function () {
    $(".list-group-item").removeClass('active');
    $(this).addClass('active');
    var id = $(this).data('id');
    $.ajax({
        type: "GET",
        contentType: 'application/html; charset=utf-8',
        url: "/appointmentdetail/" + id,
        success: function (result) {
            $('#nav-tabContent').html(result);
        },
        error: function (error) {
            console.log(error);
        },
    });
});