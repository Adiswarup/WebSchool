
$(function () {
    $(document).ready(function () {
         UpdateGrid();
    });
 });

// Updating the grid and chart contents
function UpdateGrid() {
    var urlAdaptor = new ej.data.UrlAdaptor();
    var grid = document.querySelector('#stopsGrid').ej2_instances[0];
    grid.dataSource = new ej.data.DataManager({
        url: "/stops/DataSource",
        updateUrl: "/stops/Update",
        adaptor: urlAdaptor
    });
}

function cellClick(args) {
    if (this.model.editSettings.editMode === "normal") {
        this.startEdit(args.row);  //trigger to edit the row 
    }
} 