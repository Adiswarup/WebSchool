var jClss = "";
var jActGrps = "";


//$(function () {
    //$(document).show(function () {
    //    var grid = document.getElementById("Grid").ej2_instances[0];
    //    var column = grid.getColumnByField("ActName");
    //    column.headerText = "aef";
    //    var column1 = grid.getColumnByField("ActName1");
    //    column1.visible = false;
    //    // $("#ClssGrid").ejGrid({
    //    document.
    //        alert("Ready");



    //});
    $(document).ready(function () {
        jClss = $('#selectClsses').data("ejDropDownList").selectItemByIndex(0);
        jActGrps = $('#selectActGrps').data("ejDropDownList").selectItemByIndex(0);

        //     dataSource: dataManger
        //});
        var grid = document.getElementById("Grid").ej2_instances[0];
        var column = grid.getColumnByField("ActName");
        column.headerText = "aef";
        var column1 = grid.getColumnByField("ActName1");
        column1.visible = false;
        // $("#ClssGrid").ejGrid({
        document.
            alert("Ready");
  });


function changeClsses(sender) {
    jClss = sender.itemData.value;
    UpdateGrid(jClss, jActGrps);
}

function changeActGrps(sender) {
    jActGrps = sender.itemData.value;
    UpdateGrid(jClss, jActGrps);
}

// Updating the grid and chart contents
function UpdateGrid(clss, actGrps) {
    var urlAdaptor = new ej.data.UrlAdaptor();
    var grid = document.querySelector('#ActiLogGrid').ej2_instances[0];
    grid.dataSource = new ej.data.DataManager({
        url: "/ActiLogs/DataSource/?clss=" + clss + "&actGrps=" + actGrps,
        updateUrl: "/ActiLogs/Update",
        adaptor: urlAdaptor
    });
}

function dataBound(args) {
    for (var i = cCnt; i < cCnt + 5; i++) {
        var column = args.model.columns[i];
        column.isPrimaryKey = true;
        column.headerText = "i" + i;
        this.columns(column, "update");
    }

}
