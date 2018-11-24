$(function () {
    $(document).ready(function () {
         alert("Ready");
       UpdateGrid();
    });
});

function UpdateGrid() {
         var urlAdaptor = new ejs.data.UrlAdaptor();
        var grid = document.querySelector('#dynaGrid').ej2_instances[0];
        grid.dataSource = new ejs.data.DataManager({
        url: "/DynaFees/DataSource?clss=" + jClss + "&tSess=" + jSession + "&StdFeeCat=" + jStdFeeCat + "&FeeCap=" + jFeeCap,
        updateUrl: "/DynaFees/Update?clss=" + jClss + "&tSess=" + jSession + "&StdFeeCat=" + jStdFeeCat + "&FeeCap=" + jFeeCap,
        adaptor: urlAdaptor()
    }
}

function click(args) {
    if (this.model.editSettings.editMode === "normal") {
        this.startEdit(args.row);  //trigger to edit the row 
    }
} 