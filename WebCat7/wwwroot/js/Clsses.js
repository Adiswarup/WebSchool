
function changeSession(sender) {
    UpdateGrid(sender.itemData.value);
}

function UpdateGrid(session) {
    var urlAdaptor = new ej.data.UrlAdaptor();
    var grid = document.querySelector('#clssGrid').ej2_instances[0];
    grid.dataSource = new ej.data.DataManager({
        url: "/Clsses/DataSource/?sess=" + session,
        updateUrl: "/Clsses/Update",
        adaptor: urlAdaptor
    });
}
function click(args) {
    if (this.model.editSettings.editMode === "normal") {
        this.startEdit(args.row);  //trigger to edit the row 
    }
} 
