$(function () {
    $(document).ready(function () {
         //alert("Ready");
       UpdateGrid();
    });
});

function UpdateGrid() {
    var urlAdaptor = new ej.data.UrlAdaptor();
    var grid = document.querySelector('#dynaGrid').ej2_instances[0];
    grid.dataSource = new ej.data.DataManager({
        url: "/DynaFees/DataSource?clss=" + jClss + "&tSess=" + jSession + "&StdFeeCat=" + jStdFeeCat + "&FeeCap=" + jFeeCap + "&Mode=1",
        updateUrl: "/DynaFees/Update?clss=" + jClss + "&tSess=" + jSession + "&StdFeeCat=" + jStdFeeCat + "&FeeCap=" + jFeeCap + "&FeeDate=" + jFeeDate,
        adaptor: urlAdaptor
    });
}


function click(args) {
    if (this.model.editSettings.editMode === "normal") {
        this.startEdit(args.row);  //trigger to edit the row 
    }
} 