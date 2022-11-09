function InitializeValidation() {
    var validator = $("#MasterPageForm1").bind("invalid-form.validate", function () { }).validate({
        errorElement: "em",
        errorPlacement: function (error, element) {
            error.appendTo(element.parent("td").next("td"));
        },
        success: function (label) {
            label.text("ok!").addClass("success");
        }
    });
}
