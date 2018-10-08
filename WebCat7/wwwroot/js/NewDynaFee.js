$(function () {
    $(document).ready(function () {
        UpdateGrid();
        alert("Ready");
    });
});

function UpdateGrid() {
    var dataManager = ej.DataManager({
        url: "/DynaFees/DataSource?clss=" + jClss + "&tSess=" + jSession + "&StdFeeCat=" + jStdFeeCat + "&FeeCap=" + jFeeCap,
        updateUrl: "/DynaFees/Update?clss=" + jClss + "&tSess=" + jSession + "&StdFeeCat=" + jStdFeeCat + "&FeeCap=" + jFeeCap,
        adaptor: new ej.UrlAdaptor()
    });
    $("#dynaGrid").ejGrid({
        dataSource: dataManager,
        allowPaging: true,
        updateUrl: UpdateGrid
    });
}

function click(args) {
    if (this.model.editSettings.editMode === "normal") {
        this.startEdit(args.row);  //trigger to edit the row 
    }
} 