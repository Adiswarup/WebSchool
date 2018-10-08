
$(function () {
    $(document).ready(function () {
         //alert("Ready");
         UpdateGrid();
    });
 });
// Updating the grid and chart contents
function UpdateGrid() {
    var urlAdaptor = new ej.data.UrlAdaptor();
    var grid = document.querySelector('#CatGrid').ej2_instances[0];
    grid.dataSource = new ej.data.DataManager({
        url: "/stdCats/DataSource",
        updateUrl: "/stdCats/Update",
        adaptor: urlAdaptor
    });
 }

function click(args) {
    if (this.model.editSettings.editMode === "normal") {
        this.startEdit(args.row);  //trigger to edit the row 
    }
} 