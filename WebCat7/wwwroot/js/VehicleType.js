$(function () {
    $(document).ready(function () {
        UpdateGrid();
    });
});

// Updating the grid and chart contents
function UpdateGrid() {
    var urlAdaptor = new ej.data.UrlAdaptor();
    var grid = document.querySelector('#VehicleType').ej2_instances[0];
    grid.dataSource = new ej.data.DataManager({
        url: "/VehicleTypes/DataSource",
        updateUrl: "/VehicleTypes/Update",
        adaptor: urlAdaptor
    });
}