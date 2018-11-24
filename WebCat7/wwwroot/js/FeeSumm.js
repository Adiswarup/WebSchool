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
    });
});


// Updating the grid and chart contents
function UpdateGrid(RegNo) {
    var urlAdaptor = new ejs.data.UrlAdaptor();
    var grid = document.querySelector('#feeSummGrid').ej2_instances[0];
    grid.dataSource = new ejs.data.DataManager({
        url: "/FeeSumm/DataSource/?RegNo=" + RegNo,
        updateUrl: "/FeeSumm/Update",
        adaptor: urlAdaptor
    });
}

function clkPaid(e) {
    var obj = document.querySelector('#feeSummGrid').ej2_instances[0];
 //var obj = $("#feeSummGrid").data("ejGrid");
    alert(obj.model.selectedRecords[0].forMonth + "," + fRegNo);
}
function clkPay(e) {
    //var gridobj = document.getElementById('feeSummGrid').ej2_instances[0];
    var feeNo = document.getElementById('feeSummGrid').ej2_instances[0].getSelectedRows()[0].cells[8].textContent;
    var feeCapt = document.getElementById('feeSummGrid').ej2_instances[0].getSelectedRows()[0].cells[5].textContent;
    window.location.href = '/Receipts/Edit/?fRegNo=' + fRegNo + '&feeNo=' + feeNo + '&feeCaption=' + feeCapt;
}




