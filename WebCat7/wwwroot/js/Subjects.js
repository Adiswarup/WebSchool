function changeClsses(sender) {
    UpdateGrid(sender.itemData.value);
}
//$(function () {
//    $(document).ready(function () {
//        $('#selectClsses').data("ejDropDownList").selectItemByText("All");
//    });
//});

function UpdateGrid(clss) {
    var urlAdaptor = new ej.data.UrlAdaptor();
    var grid = document.querySelector('#subsGrid').ej2_instances[0];
    grid.dataSource = new ej.data.DataManager({
        url: "/Subjects/DataSource?clss=" + clss,
        updateUrl: "/Subjects/Update",
        adaptor: urlAdaptor
    });
}