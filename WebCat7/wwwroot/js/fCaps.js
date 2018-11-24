$(function() {
    $(document).ready(function() {
         UpdateGrid();
    });
 });

// Updating the grid and chart contents
function UpdateGrid() {
    var urlAdaptor = new ej.data.UrlAdaptor();
    var grid = document.querySelector('#fCapGrid').ej2_instances[0];
    grid.dataSource = new ej.data.DataManager({
        url: "/fcaptions/DataSource",
        updateUrl: "/fcaptions/Update",
        adaptor: urlAdaptor
    });
}

function click(args) {
    if (this.model.editSettings.editMode === "normal") {
        this.startEdit(args.row);  //trigger to edit the row 
    }
} 