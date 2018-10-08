var jClss = "";
var jSearchStr = "";

$(function () {
    $(document).ready(function () {
        //alert("vbhjmk");
    });
});

  function btnClick() {
        document.getElementById('SearchStd').submit();
    }

function OnChangeSearchEvent(sender) {
        jSearchStr = sender.itemData.value;
        UpdateGrid(jClss, jSearchStr);
}

function changeClsses(sender) {
    jClss = sender.itemData.value;
    UpdateGrid(jClss, jSearchStr);
}

    function clkEdit(e) {
        var grid = document.querySelector('#Stdnts').ej2_instances[0];
        window.location.href = 'Students/Edit/?RegNumber=' + grid.model.selectedRecords[0].RegNumber;
        //alert(grid.model.selectedRecords[0].RegNumber + "," + grid.model.selectedRecords[0].StdName)
        //        $.ajax({
        //    type: "GET",
        //    url: '/Students/Edit/?RegNumber=' + grid.model.selectedRecords[0].RegNumber,
        //    contentType: "application/json; charset=utf-8",
        //    dataType: "json"
        //});
    }
    function clkDetails(e) {
        var grid = document.querySelector('#Stdnts').ej2_instances[0];
        window.location.href = 'Students/Details/?RegNumber=' + grid.model.selectedRecords[0].RegNumber;
        //alert(grid.model.selectedRecords[0].RegNumber + "," + grid.model.selectedRecords[0].StdName)
        //$.ajax({
        //    type: "GET",
        //    url: '/Students/Details/?RegNumber=' + grid.model.selectedRecords[0].RegNumber,
        //    contentType: "application/json; charset=utf-8",
        //    dataType: "json"
        //});
    }

    function UpdateGrid(SClss, strSearch) {
        var urlAdaptor = new ejs.data.UrlAdaptor();
        var grid = document.querySelector('#Stdnts').ej2_instances[0];
        if (SClss !== "") {
            grid.dataSource = new ej.data.DataManager({
                url: "/SearchStd/DataSource?Clss=" + SClss + "&strSearch=" + strSearch,
                updateUrl: "/SearchStd/Update",
                adaptor: urlAdaptor
            });
        }
    }
