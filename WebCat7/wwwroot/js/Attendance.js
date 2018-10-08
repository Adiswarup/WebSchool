var jClss = "";
var jAtType = "";

function changeClsses(sender) {
    jClss = sender.itemData.value;
    UpdateGrid();
}

function changeType(sender) {
    jAtType = sender.itemData.value;
    UpdateGrid();
}

function changeDate(sender) {
    UpdateGrid();
}

//$(function () {
//    $(document).ready(function () {
//        $("#selectDate").ejDatePicker({ dateFormat: "dd/MM/yyyy" });
//        $("#selectDate").ejDatePicker({ maxDate: new Date("01/04/2019") });
//        $("#selectDate").ejDatePicker({ value: Date.now });
//    });
//});

function UpdateGrid() {
    if (jClss !== "" & jAtType !== "") {
        var atDate = document.getElementById("selectDate").value();
        //alert("Adi")
        //alert(jclss + "  " + jAtType + "  " + jAtDate)
        var urlAdaptor = new ej.data.UrlAdaptor();
        var grid = document.querySelector('#attsGrid').ej2_instances[0];
        grid.dataSource = new ej.data.DataManager({
            url: "/Attendances/DataSource?clss=" + jClss + "&atType=" + jAtType + "&atDate=" + atDate,
            updateUrl: "/Attendances/Update?clss=" + jClss + "&atType=" + jAtType + "&AtDate=" + atDate,
            adaptor: urlAdaptor
        });
    }
}

function click(args) {
    if (this.model.editSettings.editMode === "normal") {
        this.startEdit(args.row);  //trigger to edit the row 
    }
} 