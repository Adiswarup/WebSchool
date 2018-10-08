$(function () {
    $(document).ready(function () {
        //alert("Ready");
        UpdateGrid();
    });
});

// Updating the grid and chart contents
function UpdateGrid() {
    var urlAdaptor = new ej.data.UrlAdaptor();
    var grid = document.querySelector('#AcaSessGrid').ej2_instances[0];
    grid.dataSource = new ej.data.DataManager({
        url: "/AcaSessions/DataSource",
        updateUrl: "/AcaSessions/Update",
        adaptor: urlAdaptor
    });
}
