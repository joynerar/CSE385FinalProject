$(document).ready(function () {
				var ulList = $('#ulList');
				var count = $('#txtCount');
				var filter = $('#txtFilter');

				//===================================================================================================
				// Get a list of random cars from an API
				//===================================================================================================
				$('#retAll').click(function () {
				    ajax("spTest2API", {}, function (data) {
						ulList.empty();
						$.each(data, function (index, val) {
							ulList.append('<li class="list-group-item">' + val.StudentName + '</li>');
						});
					});
				});

				//===================================================================================================
				// Get a list of customers from the database using an API
				//===================================================================================================
				$('#btnGetCustomers').click(function () {
					ajax("getCustomersByFilter", { "count": count.val(), "filter": filter.val() }, function (data) {
						ulList.empty();
						$.each(data, function (index, val) {
							ulList.append('<li class="list-group-item"><img src="https://robohash.org/' + val.EmailAddress + '.png" width="50" height="50" />' + (val.EmailAddress + ': ' + val.FirstName + ' ' + val.LastName).replace(filter.val(),'<span style="background-color:yellow;">' + filter.val() + '</span>') + '</li>')
						});
					});
				});

				//===================================================================================================
				// Button to clear the fields
				//===================================================================================================
				$('#btnClear').click(function () {
					ulList.empty();
					count.val('0');
					filter.val('');
				});


				//===================================================================================================
				// Generic method for AJAX calls
				//===================================================================================================
				function ajax(method, data, fn) {
					$.ajax({
						type: 'POST',
						url: 'armstrongAPI.asmx/' + method,
						dataType: 'json',
						data: data,
						success: fn
					});
				}
			});