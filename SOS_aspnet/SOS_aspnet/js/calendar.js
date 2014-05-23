"use strict";

$(function () {


	// Date.now().getYear + "/" + Date.now().getMonth + "/" + Date.now().getDay    $datepicker.data('date')
	$('.date-picker').each(function () {
		
		//$(".value", Date.now().getYear + "/" + Date.now().getMonth + "/" + Date.now().getDay);
			var $datepicker = $(this),
				curDate = ($datepicker.data('date') ? moment($datepicker.data('date'), "YYYY/MM/DD") : moment()),
				format = {
					"weekday": ($datepicker.find('.weekday').data('format') ? $datepicker.find('.weekday').data('format') : "dddd"),
					"date": ($datepicker.find('.date').data('format') ? $datepicker.find('.date').data('format') : "MMMM Do"),
					"year": ($datepicker.find('.year').data('year') ? $datepicker.find('.weekday').data('format') : "YYYY")
				};
		

		function updateDisplay(curDate) {
			$datepicker.find('.date-container > .weekday').text(curDate.format(format.weekday));
			$datepicker.find('.date-container > .date').text(curDate.format(format.date));
			$datepicker.find('.date-container > .year').text(curDate.format(format.year));
			$datepicker.data('date', curDate.format('YYYY/MM/DD'));
			$datepicker.find('.value').text(curDate.format('YYYY/MM/DD'));
			$datepicker.data('.value', curDate.format('YYYY/MM/DD'));
			$datepicker.find('.input-datepicker').removeClass('show-input');
		}

		updateDisplay(curDate);

		$datepicker.on('click', '[data-toggle="calendar"]', function (event) {
			event.preventDefault();
			$datepicker.find('.input-datepicker').toggleClass('show-input');
		});

		$datepicker.on('click', '.input-datepicker > .input-group-btn > button', function (event) {
			event.preventDefault();
			var $input = $(this).closest('.input-datepicker').find('input'),
				dateFormat = ($input.data('format') ? $input.data('format') : "YYYY/MM/DD");
			if (moment($input.val(), dateFormat).isValid()) {
				updateDisplay(moment($input.val(), dateFormat));
			} else {
				alert('Invalid Date');
			}
		});

		$datepicker.on('click', '[data-toggle="datepicker"]', function (event) {
			event.preventDefault();

			var curDate = moment($(this).closest('.date-picker').data('date'), "YYYY/MM/DD"),
				dateType = ($datepicker.data('type') ? $datepicker.data('type') : "days"),
				type = ($(this).data('type') ? $(this).data('type') : "add"),
				amt = ($(this).data('amt') ? $(this).data('amt') : 1);

			if (type == "add") {
				curDate = curDate.add(dateType, amt);
			} else if (type == "subtract") {
				curDate = curDate.subtract(dateType, amt);
			}

			updateDisplay(curDate);
		});

		//if ($datepicker.data('keyboard') == true) {
		//	$(window).on('keydown', function (event) {
		//		if (event.which == 37) {
		//			$datepicker.find('span:eq(0)').trigger('click');
		//		} else if (event.which == 39) {
		//			$datepicker.find('span:eq(1)').trigger('click');
		//		}
		//	});
		//}
	});
});

$(function () {
    $('.list-group.checked-list-box .list-group-item').each(function () {
        
        // Settings
        var $widget = $(this),
            $checkbox = $('<input type="checkbox" class="hidden" />'),
            color = ($widget.data('color') ? $widget.data('color') : "primary"),
            style = ($widget.data('style') == "button" ? "btn-" : "list-group-item-"),
            settings = {
                on: {
                    icon: 'glyphicon glyphicon-check'
                },
                off: {
                    icon: 'glyphicon glyphicon-unchecked'
                }
            };
            
        $widget.css('cursor', 'pointer')
        $widget.append($checkbox);

        // Event Handlers
        $widget.on('click', function () {
            $checkbox.prop('checked', !$checkbox.is(':checked'));
            $checkbox.triggerHandler('change');
            updateDisplay();
        });
        $checkbox.on('change', function () {
            updateDisplay();
        });
          

        // Actions
        function updateDisplay() {
            var isChecked = $checkbox.is(':checked');

            // Set the button's state
            $widget.data('state', (isChecked) ? "on" : "off");

            // Set the button's icon
            $widget.find('.state-icon')
                .removeClass()
                .addClass('state-icon ' + settings[$widget.data('state')].icon);

            // Update the button's color
            if (isChecked) {
                $widget.addClass(style + color + ' active');
            } else {
                $widget.removeClass(style + color + ' active');
            }
        }

        // Initialization
        function init() {
            
            if ($widget.data('checked') == true) {
                $checkbox.prop('checked', !$checkbox.is(':checked'));
            }
            
            updateDisplay();

            // Inject the icon if applicable
            if ($widget.find('.state-icon').length == 0) {
                $widget.prepend('<span class="state-icon ' + settings[$widget.data('state')].icon + '"></span>');
            }
        }
        init();
    });
    
    $('#get-checked-data').on('click', function(event) {
        event.preventDefault(); 
        var checkedItems = {}, counter = 0;
        $("#check-list-box li.active").each(function(idx, li) {
            checkedItems[counter] = $(li).text();
            counter++;
        });
        $('#display-json').html(JSON.stringify(checkedItems, null, '\t'));
    });
});