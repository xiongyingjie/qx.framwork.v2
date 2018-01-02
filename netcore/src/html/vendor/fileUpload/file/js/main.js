/*
 * jQuery File Upload Plugin JS Example
 * https://github.com/blueimp/jQuery-File-Upload
 *
 * Copyright 2010, Sebastian Tschan
 * https://blueimp.net
 *
 * Licensed under the MIT license:
 * https://opensource.org/licenses/MIT
 */

/* global $, window */

function initFile() {
    'use strict';

    $('#fileupload').fileupload({
        url: '/home/file'
    });


    $('#fileupload').fileupload(
        'option', {
            url: '/home/file'
        },
        'redirect',
        window.location.href.replace(
            /\/[^\/]*$/,
            '/cors/result.html?%s'
        )
    );

        $('#fileupload').addClass('fileupload-processing');

        $.ajax({
            // Uncomment the following to send cross-domain cookies:
            //xhrFields: {withCredentials: true},
            url: $('#fileupload').fileupload('option', 'url'),
            dataType: 'json',
            context: $('#fileupload')[0]
        }).always(function () {
            $(this).removeClass('fileupload-processing');

        }).done(function (result) {
            $(this).fileupload('option', 'done')
                .call(this, $.Event('done'), { result: result });
            
        });

        $("#tagButton").click(function () {
            $("#mainBox").slideUp();
            setTimeout(function () {
                $("#closeBox").removeClass('hide');
            }, 500);

        });
        $("#showButton").click(function () {
            $("#mainBox").slideDown();
            setTimeout(function () {
                $("#closeBox").addClass('hide');
            }, 500);

        });

};
