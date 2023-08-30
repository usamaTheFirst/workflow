window.BlazorHelpers = {
    RedirectTo: function (url) {
        window.location.href = url;
    },
    focus: function setFocus(element) {
        element.focus();
    }


};
function printt() {
    window.print();
}


window.sample = {
    //selector: 'myTextEditor',
    //myTextEditor
    editor_selector: "myTextEditor",
    height: 300,
    plugins: 'ai tinycomments mentions anchor autolink charmap codesample emoticons image link lists media searchreplace table visualblocks wordcount checklist mediaembed casechange export formatpainter pageembed permanentpen footnotes advtemplate advtable advcode editimage tableofcontents mergetags powerpaste tinymcespellchecker autocorrect a11ychecker typography inlinecss',
    toolbar: 'undo redo | blocks fontfamily fontsize | bold italic underline strikethrough | link image media table mergetags | align lineheight | tinycomments | checklist numlist bullist indent outdent | emoticons charmap | removeformat',
    tinycomments_mode: 'embedded',
    table_sizing_mode: 'responsive',
    tinycomments_author: 'Author name',
    branding: false,
    toolbar_sticky: false,
    mergetags_list: [
        { value: 'First.Name', title: 'First Name' },
        { value: 'Email', title: 'Email' },
    ],
    ai_request: (request, respondWith) => respondWith.string(() => Promise.reject("See docs to implement AI Assistant"))
}


function Print() {

    var divcontent = document.getElementById("printdiv").innerHTML;
    var a = window.open('', '', 'height=600', 'width=600');
    a.document.write('<html>');
    a.document.write('<body><br/>');
    a.document.write(divcontent);
    a.document.write('</body></html>');
    a.document.close();
    a.print();

}
function renderjQueryComponents() {
    $(document).ready(function () {
        $("select").selectize({ sortFields: "text", options: option, placeholder: "example@ffbl.com" });
        var selectizeControl = $select[0].selectize
        selectizeControl.on('change', function () {
            var test = selectize.getValue();
            alert(test);
        });


    });



}




