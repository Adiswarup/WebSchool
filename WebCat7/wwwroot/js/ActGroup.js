$(function () {
    $(document).ready(function () {
        UpdateGrid();
    });
 });

function UpdateGrid() {
    var urlAdaptor = new ej.data.UrlAdaptor();
    var grid = document.querySelector('#ActGrpGrid').ej2_instances[0];
    grid.dataSource = new ej.data.DataManager({
        url: "/ActivityGroups/DataSource/",
        updateUrl: "/ActivityGroups/Update",
        adaptor: urlAdaptor
    });
}