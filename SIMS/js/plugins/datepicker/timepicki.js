/* 
 * Author: @senthil2rajan
 * plugin: timepicker
 * website: senthilraj.github.io/Timepicki
 */
(function ($) {

    $.fn.timepicki = function (options) {

        var defaults = {
            format_output: function (tim, mini, meri) {
                if (settings.show_meridian) {
                    return tim + ":" + mini + " " + meri;
                } else {
                    return tim + ":" + mini;
                }
            },
            increase_direction: 'down',
            custom_classes: '',
            min_hour_value: 1,
            max_hour_value: 12,
            show_meridian: true,
            step_size_hours: '1',
            step_size_minutes: '1',
            overflow_minutes: false,
            disable_keyboard_mobile: false,
            reset: true
        };

        var settings = $.extend({}, defaults, options);
        
        return this.each(function () {

            var ele = $(this);
            var ele_hei = ele.outerHeight();

            ele_hei = ele_hei * 2;
            ele_hei += 10;
            $(ele).wrap("<div class='time_pick'>");
            var ele_par = $(this).parents(".time_pick");

            // developer can specify which arrow makes the numbers go up or down
            var top_arrow_button = (settings.increase_direction === 'down') ?
				"<div class='prev action-prev'></div>" :
				"<div class='prev action-next'></div>";
            var bottom_arrow_button = (settings.increase_direction === 'down') ?
				"<div class='next action-next'></div>" :
				"<div class='next action-prev'></div>";

            var new_ele = $(
				"<div class='timepicker_wrap " + settings.custom_classes + "'>" +
					"<div class='arrow_top'></div>" +
					"<div class='time'>" +
						top_arrow_button +
						"<div class='ti_tx'><input type='text' class='timepicki-input'" + (settings.disable_keyboard_mobile ? "readonly" : "") + "></div>" +
						bottom_arrow_button +
					"</div>" +
					"<div class='mins'>" +
						top_arrow_button +
						"<div class='mi_tx'><input type='text' class='timepicki-input'" + (settings.disable_keyboard_mobile ? "readonly" : "") + "></div>" +
						bottom_arrow_button +
					"</div>");
            if (settings.show_meridian) {
                new_ele.append(
					"<div class='meridian'>" +
						top_arrow_button +
						"<div class='mer_tx'><input type='text' class='timepicki-input' readonly></div>" +
						bottom_arrow_button +
					"</div>");
            }
            if (settings.reset) {
                new_ele.append(
					"<div  style='text-align: center;margin-left: 34%;'><a href='#' style='margin-top:10px;text-decoration:none;' class='reset_time btn-green-small'>OK</a></div>");
            }
            ele_par.append(new_ele);
            var ele_next = $(this).next(".timepicker_wrap");
            var ele_next_all_child = ele_next.find("div");
            var inputs = ele_par.find('input');

            $('.reset_time').on("click", function (event) {
                //ele.val("");

                var time = ele_next.find(".ti_tx input").val();
                var mini = ele_next.find(".mi_tx input").val();
                if (time.length == 1) {
                    if (time < 10) {
                        time = 0 + time;
                        ele_next.find(".ti_tx input").val(time);
                    }
                }

                if (mini.length == 1) {
                    if (mini < 10) {
                        mini = 0 + mini;
                        ele_next.find(".mi_tx input").val(mini);
                    }
                }


                close_timepicki();
            });

            $(".timepicki-input").keypress(function (keyevent) {

                var classname = $(this).parent().parent().attr('class');

                if (classname == 'time') {
                    //var time = ele_next.find(".ti_tx input").val();
                    var time = $(this).val();
                    time = time + (keyevent.key || String.fromCharCode(keyevent.keyCode));
                    if (time > 12) {

                        if (this.selectionStart > 0)
                            keyevent.preventDefault();
                    }
                }

                if (classname == 'mins') {
                    //var min = ele_next.find(".mi_tx input").val();
                    var min = $(this).val();
                    min = min + (keyevent.key || String.fromCharCode(keyevent.keyCode));
                    if (min > 59) {

                        if (this.selectionStart > 0)
                            keyevent.preventDefault();
                    }
                }

            });

            $(".timepicki-input").keydown(function (keyevent) {

                var len = $(this).val().length;

                // Allow: backspace, delete, tab, escape, enter and .
                if ($.inArray(keyevent.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
                    // Allow: Ctrl+A
                    (keyevent.keyCode == 65 && keyevent.ctrlKey === true) ||
                    // Allow: home, end, left, right
                    (keyevent.keyCode >= 35 && keyevent.keyCode <= 39)) {
                    // let it happen, don't do anything

                    return;
                }

                // Ensure that it is a number and stop the keypress
                if ((keyevent.shiftKey || (keyevent.keyCode < 48 || keyevent.keyCode > 57)) &&
                (keyevent.keyCode < 96 || keyevent.keyCode > 105) || len == 2) {
                    if (this.selectionStart > 0)
                        keyevent.preventDefault();
                }
                //if (len == 2) {
                //    var classname = $(this).parent().parent().attr('class');
                //    if (classname != 'meridian')
                //        $(this).val('');
                //}
            });

            //$(".timepicki-input").keyup(function (keyevent) {

            //    var time = ele_next.find(".ti_tx input").val();
            //    var min = ele_next.find(".mi_tx input").val();
            //    if (time > 12) {
            //        time = time.substring(0, time.length - 1);
            //        ele_next.find(".ti_tx input").val(time);
            //    }
            //    if (min > 59) {
            //        min = min.substring(0, min.length - 1);
            //        ele_next.find(".mi_tx input").val(min);
            //    }

            //});

            // open or close time picker when clicking
            $(document).on("click", function (event) {


                if (!$(event.target).is(ele_next) && ele_next.css("display") == "block" || !$(event.target).is($('.reset_time'))) {
                    if (!$(event.target).is(ele)) {
                        set_value(event, !is_element_in_timepicki($(event.target)));
                    } else {
                        //var ele_lef =  0;
                        ele_next.css({
                            "top": ele_hei + "px",
                            "left": "0px"
                        });
                        open_timepicki();
                    }
                }
            });

            // open the modal when the user focuses on the input
            ele.on('focus', open_timepicki);

            // select all text in input when user focuses on it
            inputs.on('focus', function () {
                var input = $(this);
                if (!input.is(ele)) {
                    input.select();
                }
            });

            // allow user to increase and decrease numbers using arrow keys
            inputs.on('keydown', function (e) {
                var direction, input = $(this);

                // UP
                if (e.which === 38) {
                    if (settings.increase_direction === 'down') {
                        direction = 'prev';
                    } else {
                        direction = 'next';
                    }
                    // DOWN
                } else if (e.which === 40) {
                    if (settings.increase_direction === 'down') {
                        direction = 'next';
                    } else {
                        direction = 'prev';
                    }
                }

                if (input.closest('.timepicker_wrap .time').length) {
                    change_time(null, direction);
                } else if (input.closest('.timepicker_wrap .mins').length) {
                    change_mins(null, direction);
                } else if (input.closest('.timepicker_wrap .meridian').length && settings.show_meridian) {
                    change_meri(null, direction);
                }
            });

            // close the modal when the time picker loses keyboard focus
            inputs.on('blur', function () {
                setTimeout(function () {
                    var focused_element = $(document.activeElement);
                    if (focused_element.is(':input') && !is_element_in_timepicki(focused_element)) {
                        set_value();
                        close_timepicki();
                    }
                }, 0);
            });

            //inputs.on('dblclick', function () {
            //     $(this).val('');
            //});

            function is_element_in_timepicki(jquery_element) {
                return $.contains(ele_par[0], jquery_element[0]) || ele_par.is(jquery_element);
            }

            function set_value(event, close) {
                // use input values to set the time
                var tim = ele_next.find(".ti_tx input").val();
                var mini = ele_next.find(".mi_tx input").val();
                var meri = "";
                if (settings.show_meridian) {
                    meri = ele_next.find(".mer_tx input").val();
                }

                if (tim.length !== 0 && mini.length !== 0 && (!settings.show_meridian || meri.length !== 0)) {
                    // store the value so we can set the initial value
                    // next time the picker is opened
                    ele.attr('data-timepicki-tim', tim);
                    ele.attr('data-timepicki-mini', mini);

                    if (settings.show_meridian) {
                        ele.attr('data-timepicki-meri', meri);
                        // set the formatted value
                        ele.val(settings.format_output(tim, mini, meri));
                    } else {
                        ele.val(settings.format_output(tim, mini));
                    }
                }

                if (close) {
                    close_timepicki();
                }
            }

            function open_timepicki() {

                var time = ele_next.find(".ti_tx input").val();
                var mini = ele_next.find(".mi_tx input").val();
                if (time.length == 1) {
                    if (time < 10) {
                        time = 0 + time;
                        ele_next.find(".ti_tx input").val(time);
                    }
                }

                if (mini.length == 1) {
                    if (mini < 10) {
                        mini = 0 + mini;
                        ele_next.find(".mi_tx input").val(mini);
                    }
                }

                ele_next.css({
                    "top": ele_hei + "px",
                    "left": "0px"
                });
                if (ele_next.find(".ti_tx input").val() == "")
                    set_date(settings.start_time);
                ele_next.fadeIn();
                // focus on the first input and select its contents
                var first_input = ele_next.find('input:visible').first();
                first_input.focus();
                // if the user presses shift+tab while on the first input,
                // they mean to exit the time picker and go to the previous field
                var first_input_exit_handler = function (e) {
                    if (e.which === 9 && e.shiftKey) {
                        first_input.off('keydown', first_input_exit_handler);
                        var all_form_elements = $(':input:visible:not(.timepicki-input)');
                        var index_of_timepicki_input = all_form_elements.index(ele);
                        var previous_form_element = all_form_elements.get(index_of_timepicki_input - 1);
                        previous_form_element.focus();
                    }
                };
                first_input.on('keydown', first_input_exit_handler);
            }

            function close_timepicki() {
                var time = ele_next.find(".ti_tx input").val();
                var mini = ele_next.find(".mi_tx input").val();
                var validation = 0;
                if (time != null && time != "") {
                    if (time.length == 1) {
                        if (time < 10) {
                            time = 0 + time;
                            ele_next.find(".ti_tx input").val(time);
                        }
                    }

                    if (mini.length == 1) {
                        if (mini < 10) {
                            mini = 0 + mini;
                            ele_next.find(".mi_tx input").val(mini);
                        }
                    }

                    //console.log(time + ':' + mini);
                    if (time > 12 || mini > 59)
                        validation = 1;
                    else {
                        ele.attr('data-timepicki-tim', time);
                        ele.attr('data-timepicki-mini', mini);
                        var meri = "";
                        if (settings.show_meridian) {
                            meri = ele_next.find(".mer_tx input").val();
                        }


                        if (settings.show_meridian) {
                            ele.attr('data-timepicki-meri', meri);
                            // set the formatted value
                            ele.val(settings.format_output(time, mini, meri));
                        } else {
                            ele.val(settings.format_output(time, mini));
                        }
                    }
                }

                if (typeof (OnchangeOfToTime) == "function"){
                    OnchangeOfToTime();
                }
                if (validation == 0)
                    ele_next.fadeOut();
                else
                    SmallNotification('Please enter valid time.', -1);
            }

            function set_date(start_time) {
                var d, ti, mi, mer;

                // if a value was already picked we will remember that value
                if (ele.is('[data-timepicki-tim]')) {
                    ti = Number(ele.attr('data-timepicki-tim'));
                    mi = Number(ele.attr('data-timepicki-mini'));
                    if (settings.show_meridian) {
                        mer = ele.attr('data-timepicki-meri');
                    }
                    // developer can specify a custom starting value
                } else if (typeof start_time === 'object') {
                    ti = Number(start_time[0]);
                    mi = Number(start_time[1]);
                    if (settings.show_meridian) {
                        mer = start_time[2];
                    }
                    // default is we will use the current time
                } else {
                    d = new Date();
                    ti = d.getHours();
                    mi = d.getMinutes();
                    mer = "AM";
                    if (12 < ti && settings.show_meridian) {
                        ti -= 12;
                        mer = "PM";
                    }
                }

                if (ti < 10) {
                    ele_next.find(".ti_tx input").val("0" + ti);
                } else {
                    ele_next.find(".ti_tx input").val(ti);
                }
                if (mi < 10) {
                    ele_next.find(".mi_tx input").val("0" + mi);
                } else {
                    ele_next.find(".mi_tx input").val(mi);
                }
                if (settings.show_meridian) {
                    if (mer < 10) {
                        ele_next.find(".mer_tx input").val("0" + mer);
                    } else {
                        ele_next.find(".mer_tx input").val(mer);
                    }
                }
            }

            function change_time(cur_ele, direction) {
                var cur_cli = "time";
                var cur_time = Number(ele_next.find("." + cur_cli + " .ti_tx input").val());
                var ele_st = Number(settings.min_hour_value);
                var ele_en = Number(settings.max_hour_value);
                var step_size = Number(settings.step_size_hours);
                if ((cur_ele && cur_ele.hasClass('action-next')) || direction === 'next') {
                    if (cur_time + step_size > ele_en) {
                        var min_value = ele_st;
                        if (min_value < 10) {
                            min_value = '0' + min_value;
                        } else {
                            min_value = String(min_value);
                        }
                        ele_next.find("." + cur_cli + " .ti_tx input").val(min_value);
                    } else {
                        cur_time = cur_time + step_size;
                        if (cur_time < 10) {
                            cur_time = "0" + cur_time;
                        }
                        ele_next.find("." + cur_cli + " .ti_tx input").val(cur_time);
                    }
                } else if ((cur_ele && cur_ele.hasClass('action-prev')) || direction === 'prev') {
                    if (cur_time - step_size <= ele_st) {
                        var max_value = ele_en;
                        if (max_value < 10) {
                            max_value = '0' + max_value;
                        } else {
                            max_value = String(max_value);
                        }
                        ele_next.find("." + cur_cli + " .ti_tx input").val(max_value);
                    } else {
                        cur_time = cur_time - step_size;
                        if (cur_time < 10) {
                            cur_time = "0" + cur_time;
                        }
                        ele_next.find("." + cur_cli + " .ti_tx input").val(cur_time);
                    }
                }
            }

            function change_mins(cur_ele, direction) {
                var cur_cli = "mins";
                var cur_mins = Number(ele_next.find("." + cur_cli + " .mi_tx input").val());
                var ele_st = 0;
                var ele_en = 59;
                var step_size = Number(settings.step_size_minutes);
                if ((cur_ele && cur_ele.hasClass('action-next')) || direction === 'next') {
                    if (cur_mins + step_size > ele_en) {
                        ele_next.find("." + cur_cli + " .mi_tx input").val("00");
                        if (settings.overflow_minutes) {
                            change_time(null, 'next');
                        }
                    } else {
                        cur_mins = cur_mins + step_size;
                        if (cur_mins < 10) {
                            ele_next.find("." + cur_cli + " .mi_tx input").val("0" + cur_mins);
                        } else {
                            ele_next.find("." + cur_cli + " .mi_tx input").val(cur_mins);
                        }
                    }
                } else if ((cur_ele && cur_ele.hasClass('action-prev')) || direction === 'prev') {
                    if (cur_mins - step_size <= ele_st) {
                        ele_next.find("." + cur_cli + " .mi_tx input").val(ele_en + 1 - step_size);
                        if (settings.overflow_minutes) {
                            change_time(null, 'prev');
                        }
                    } else {
                        cur_mins = cur_mins - step_size;
                        if (cur_mins < 10) {
                            ele_next.find("." + cur_cli + " .mi_tx input").val("0" + cur_mins);
                        } else {
                            ele_next.find("." + cur_cli + " .mi_tx input").val(cur_mins);
                        }
                    }
                }
            }

            function change_meri(cur_ele, direction) {
                var cur_cli = "meridian";
                var ele_st = 0;
                var ele_en = 1;
                var cur_mer = null;
                cur_mer = ele_next.find("." + cur_cli + " .mer_tx input").val();
                if ((cur_ele && cur_ele.hasClass('action-next')) || direction === 'next') {
                    if (cur_mer == "AM") {
                        ele_next.find("." + cur_cli + " .mer_tx input").val("PM");
                    } else {
                        ele_next.find("." + cur_cli + " .mer_tx input").val("AM");
                    }
                } else if ((cur_ele && cur_ele.hasClass('action-prev')) || direction === 'prev') {
                    if (cur_mer == "AM") {
                        ele_next.find("." + cur_cli + " .mer_tx input").val("PM");
                    } else {
                        ele_next.find("." + cur_cli + " .mer_tx input").val("AM");
                    }
                }
            }

            // handle clicking on the arrow icons
            var cur_next = ele_next.find(".action-next");
            var cur_prev = ele_next.find(".action-prev");
            $(cur_prev).add(cur_next).on("click", function () {
                var cur_ele = $(this);
                if (cur_ele.parent().attr("class") == "time") {
                    change_time(cur_ele);
                } else if (cur_ele.parent().attr("class") == "mins") {
                    change_mins(cur_ele);
                } else {
                    if (settings.show_meridian) {
                        change_meri(cur_ele);
                    }
                }
            });

        });
    };

}(jQuery));
