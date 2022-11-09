$(function () {

    $('#btnFileUpload').fileupload({
        url: '/Application/FileUploaderHandler.ashx?upload=start',
        add: function (e, data) {
            console.log('add', data);
            $('#progressbar').show();
            data.submit();
        },
        progress: function (e, data) {
            var progress = parseInt(data.loaded / data.total * 100, 10);
            $('#progressbar div').css('width', progress + '%');
        },
        success: function (response, status) {
            //$('#progressbar').hide();
            $('#progressbar div').css('width', '0%');
            $('#progressbar_message').attr('class', 'alert alert-success');
            $('#progressbar_message').text("Uploaded successfully");
          
           // var sfilepath = status.split("|");
            $("#uploaded_file").val(response);
            var hiddencontrol = $("#<%=uploaded_file_path.ClientID%>"); 
            $(hiddencontrol).val(response);
          //  console.log('file path:', response);
            console.log('success', response);
        },
        error: function (error) {
            $('#progressbar').hide();
            $('#progressbar div').css('width', '0%');

            $('#progressbar_message').attr('class', 'alert alert-danger');
            $('#progressbar_message').text("Could not upload the file.");

            console.log('error', error);
        }
    });
});