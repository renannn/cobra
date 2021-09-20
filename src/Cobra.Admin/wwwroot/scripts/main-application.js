
function dataAjaxBegin() {
	alert('dataAjaxBegin')
	return true;
}

function dataAjaxSuccess() {
	alert('dataAjaxSuccess')
}

function dataAjaxFailure(n) {
	alert('dataAjaxFailure')
}

$(function () {
	var placeholderElement = $('#modal-placeholder');

	$('a[data-toggle="ajax-modal"]').on('click', function (e) {
		var url = $(this).attr('href');
		e.preventDefault(); 
		$.get(url).done(function (data) {
			placeholderElement.html(data);
			placeholderElement.find('.modal').modal('show');
		});
	});

	placeholderElement.on('click', '[data-save="modal"]', function (event) {
		event.preventDefault();

		var form = $(this).parents('.modal').find('form');
		var actionUrl = form.attr('action');
		var dataToSend = form.serialize();

		$.post(actionUrl, dataToSend).done(function (data) {
			placeholderElement.find('.modal').modal('hide');
		});
	});
});
