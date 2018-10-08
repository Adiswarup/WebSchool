var jClss = "";
var jAtDate = new Date();

function changeClsses(sender) {
    jClss = sender.itemData.value;
    UpdateGrid(jClss, jAtDate.toLocaleDateString());
}

//function changeType(sender) {
//    jAtType = sender.itemData.value;
//    UpdateGrid(jClss, jAtType, jAtDate);
//}

function changeDate(sender) {
    jAtDate = sender.value;
    UpdateGrid(jClss, jAtDate.toLocaleDateString());
}

$(function () {
    $(document).ready(function () {
        jAtDate.setDate = Date.now();
        var dtp = document.querySelector('#selectDate').ej2_instances[0];
        dtp.setDate=  Date.now();
        //$("#selectDate").ejDatePicker({ dateFormat: "dd/MM/yyyy" });
        //$("#selectDate").ejDatePicker({ maxDate: new Date("01/04/2019") });
        //$("#selectDate").ejDatePicker({ value: Date.now });
    });
});

function UpdateGrid(clss, stDate) {
    var urlAdaptor = new ej.data.UrlAdaptor();
    var grid = document.querySelector('#convGrid').ej2_instances[0];
    if (clss !== "") {
        grid.dataSource = new ej.data.DataManager({
            url: "/Conveyances/DataSource?clss=" + clss + "&stDate=" + stDate,
            updateUrl: "/Conveyances/Update/?clss=" + clss + "&stDate=" + stDate,
            adaptor: urlAdaptor
        });
    }
}

//function click(args) {
//    if (this.model.editSettings.editMode == "normal") {
//        this.startEdit(args.row);  //trigger to edit the row 
//    }
//} 