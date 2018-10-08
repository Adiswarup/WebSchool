//function fetch_StdData() {
//alert(document.getElementById('txt_UniReg').value)
//$(".add-filter-panel").ejWaitingPopup();
//$(".add-filter-panel").ejWaitingPopup("show");
//UpdateGrid(document.getElementById('txt_UniReg').value);
//getStudent(document.getElementById('txt_UniReg').value)
//}


$(function () {
    $(document).ready(function () {
        UpdateGrid(fRegNo);
        // $("#ClssGrid").ejGrid({
        //     dataSource: dataManger
        //});
        //$('#selectSession').data("ejDropDownList").selectItemByText("All");
    });
});

//function getStudent(uniReg) {
//var url = '@Url.Action("Index", "FeeForms")';

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

// Updating the grid and chart contents
function UpdateGrid(RegNo) {
    var urlAdaptor = new ej.data.UrlAdaptor();
    var grid = document.querySelector('#feeSummGrid').ej2_instances[0];
    grid.dataSource = new ej.data.DataManager({
        url: "/FeeSumm/DataSource/?RegNo=" + RegNo,
        updateUrl: "/FeeSumm/Update",
        adaptor: urlAdaptor
    });
}

function clkPaid(e) {
    var obj = $("#feeSummGrid").data("ejGrid");
    alert(obj.model.selectedRecords[0].forMonth + "," + fRegNo);
}
function clkPay(e) {
    var obj = $("#feeSummGrid").data("ejGrid");
    window.location.href = '/Receipts/Edit/?fRegNo=' + fRegNo + '&feeNo=' + obj.model.selectedRecords[0].forMonth + '&feeCaption=' + obj.model.selectedRecords[0].feeCaption ;

    //$.ajax({
    //    type: "GET",
    //    url: '/Receipts/Edit/?fRegNo=' +  fRegNo+ '&feeNo=' + obj.model.selectedRecords[0].forMonth ,
    //    contentType: "application/json; charset=utf-8",
    //    data: { fRegNo: fRegNo, feeNo: obj.model.selectedRecords[0].forMonth},
    //    dataType: "json",
    //    success: function (result) {
    //        alert(result);
    //        window.locationre = result.url;
    //    }
    //});

    //var url = '@Url.Action("Details", "Receipts")';
    //$.post(url, {
    //    fRegNo: fRegNo,
    //    feeNo: obj.model.selectedRecords[0].forMonth
    //}, function (data) {
    //    alert(obj.model.selectedRecords[0].forMonth + "," + fRegNo)
    //});

}




