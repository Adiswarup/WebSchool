
$(function () {
    $(document).ready(function () {
         UpdateGrid();
    });
 });



// Updating the grid and chart contents
function UpdateGrid() {
    var urlAdaptor = new ej.data.UrlAdaptor();
    var grid = document.querySelector('#vdGrid').ej2_instances[0];
    grid.dataSource = new ej.data.DataManager({
        url: "/VehicleDescriptions/DataSource",
        updateUrl: "/VehicleDescriptions/Update",
        adaptor: urlAdaptor
    });
}