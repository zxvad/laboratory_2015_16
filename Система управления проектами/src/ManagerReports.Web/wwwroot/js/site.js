$(document).ready(function () {

    $('#timeRecords').on('change', '.time-record--dropdown', updateResource);

    $('.add-template').on('click', addTemplate);

    $('#payments').on('click', '.add-button', addPayment);
    $('#payments').on('click', '.remove-button', removePayment);
});

function updateResource() {
    $.post("/employees/update-timerecordresource",
        { id: this.value, resourceValue: this.options[this.selectedIndex].text },
        function(result) {
            if (result.success) {
                location.reload();
            } else {
                console.error(result.message);
            }
        },
        'json'
    );
}

function addTemplate() {
    var projectId = $('#projectId').val();

    $.post("/payments/payment-template",
        { projectId: projectId },
        function(result) {
            if (result.success) {
                $('#payments').append(paymentTemplate(JSON.parse(result.versions), result.date, result.paymentId));
            } else {
                console.error(result.message);
            }
        },
        'json'
    ).fail(function(result) {
        console.error(result.message);
    });
}

function addPayment() {
    var $this = $(this);

    var paymentId = $this.parent().parent().attr('id');
    var amount = $this.parent().parent().find('input[type="number"]').val();
    var projectVersionId = $('#' + paymentId).find('#versions').val();
    var date = $this.parent().parent().find('input[type="text"]').val();

    $.post("/payments/add-payment",
            { paymentId: paymentId, amount: amount, projectVersionId: projectVersionId, date: date },
            function(result) {
                if (result.success) {
                    location.reload();
                } else {
                    console.error(result.message);
                }
            },
            'json')
        .fail(function(result) {
            console.error(result.message);
        });
}

function removePayment() {
    var $this = $(this);

    $.post("/payments/remove-payment",
            { paymentId: $this.parent().parent().attr('id') },
            function(result) {
                if (result.success) {
                    $this.parent().parent().remove();
                    location.reload();
                } else {
                    console.error(result.message);
                }
            },
            'json')
        .fail(function(result) {
            console.error(result.message);
        });
}

function paymentTemplate(versions, date, paymentId) {
    var template = '<tr id=' + paymentId + '>' +
        '<td><input type="text" value="' + date + '"/></td>' +
        '<td><input type="number" value="0"/></td>' +
        '<td colspan="2"><select id="versions"><option>Без привязки к версии</option>';

    for (var i = 0; i < versions.length; ++i) {
        template += '<option value="' + versions[i].id + '">' + versions[i].name + '</option>';
    }

    return template + '</select></td>' +
        '<td><button class="add-button">' +
        'Добавить' +
        '</button>' +
        '</td>' +
        '</tr>';
}

function saveDatepickerDates(url) {

    var beginDate = $("input[name = 'beginDateText']");
    var endDate = $("input[name = 'endDateText']");

    $.post("/reports/save-datepicker-dates",
            { beginDate: beginDate.val(), endDate: endDate.val() },
            function(response) {
                if (response.success !== true) {
                }
            },
            'json')
        .fail(function(result) {
            console.error(result.message);
        });
}