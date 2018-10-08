$(function () {
    $(document).ready(function () {
        //alert("Ready");
        UpdateGrid();
    });
});

// Updating the grid and chart contents
function UpdateGrid() {
    var urlAdaptor = new ej.data.UrlAdaptor();
    var grid = document.querySelector('#FlatGrid').ej2_instances[0];
    grid.dataSource = new ej.data.DataManager({
        url: "/StdHouses/DataSource",
        updateUrl: "/StdHouses/Update",
        adaptor: urlAdaptor
    });
}
