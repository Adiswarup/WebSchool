function changeActGrp(sender) {
    UpdateGrid(sender.itemData.value);
}
function UpdateGrid(ActGrp) {
    var urlAdaptor = new ej.data.UrlAdaptor();
    var grid = document.querySelector('#ActGrid').ej2_instances[0];
    grid.dataSource = new ej.data.DataManager({
        url: "/Activities/DataSource/?ActGrp=" + ActGrp,
        updateUrl: "/Activities/Update",
        adaptor: urlAdaptor
    });
}