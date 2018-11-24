$(function () {
    $(document).ready(function () {
        alert("Ready");
        UpdateGrid();
    });
});

// Updating the grid and chart contents
function UpdateGrid() {
    var urlAdaptor = new ej.data.UrlAdaptor();
    var grid = document.querySelector('#feeSummGrid').ej2_instances[0];
    grid.dataSource = new ej.data.DataManager({
        url: "/FeeSumm/DataSource",
        updateUrl: "/FeeSumm/Update",
        adaptor: urlAdaptor
    });
}
//$(function () {
//    $(document).ready(function () {
//        //alert("Ready");
//        // $("#ClssGrid").ejGrid({
//        //     dataSource: dataManger
//        //});
//        //$('#selectSession').data("ejDropDownList").selectItemByText("All");
//    });
//});

//function getStudent(uniReg) {
//    //var url = '@Url.Action("Index", "FeeForms")';

//    $.ajax({
//        //url: '@Url.Action("Index", "FeeForms")',
//        url: '/FeeForms/Details',
//        type: 'GET',
//        dataType: 'json',
//        // we set cache: false because GET requests are often cached by browsers
//        // IE is particularly aggressive in that respect
//        cache: false,
//        data: { uniReg: uniReg },
//        success: function () {
//            //$('#FirstName').val(person.FirstName);
//            //$('#LastName').val(person.LastName);
//        }
//    });
//}
