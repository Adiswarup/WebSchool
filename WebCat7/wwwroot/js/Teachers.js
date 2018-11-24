$(function () {
    $(document).ready(function () {
        UpdateGrid();
    });
});

// Updating the grid and chart contents
function UpdateGrid() {
    var urlAdaptor = new ej.data.UrlAdaptor();
    var grid = document.querySelector('#TeachGrid').ej2_instances[0];
    grid.dataSource = new ej.data.DataManager({
        url: "/Teachers/DataSource",
        updateUrl: "/Teachers/Update",
        adaptor: urlAdaptor
    });
}
