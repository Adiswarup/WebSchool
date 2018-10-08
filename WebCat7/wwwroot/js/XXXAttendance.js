var jClss = "";
var jAtType = "Class";
var jAtDate = Date.now();

function changeClsses(sender) {
    jClss = sender.itemData.value;
    //jAtDate = $("#selectDate")[0].value;
    UpdateGrid();
}

function changeType(sender) {
    jAtType = sender.itemData.value;
    //jAtDate = $("#selectDate")[0].value;
    UpdateGrid();
}

function changeDate(sender) {
    jAtDate = sender.value; 
    UpdateGrid();
}

$(function () {
    $(document).ready(function () {
        $("#selectDate").ejDatePicker({ dateFormat: "dd/MM/yyyy" });
        $("#selectDate").ejDatePicker({ maxDate: new Date("01/04/2020") });
        $("#selectDate").ejDatePicker({ value: Date.now });
    });
});

function UpdateGrid() {
    var dataManager = ej.DataManager({
        url: "/Attendances/DataSource?clss=" + jClss + "&atType=" + jAtType + "&AtDate=" + jAtDate,
        updateUrl: "/Attendances/Update?clss=" + jClss + "&atType=" + jAtType + "&AtDate=" + jAtDate,
        //BatchURL: "/Attendances/BatchUpdate?clss=" + jClss + "&atType=" + jAtType + "&AtDate=" + jAtDate,
        //?clss = " + clss + " & atType=" + AtType + " & AtDate=" + AtDate,
        adaptor: new ej.UrlAdaptor()
        //offline: true,
        //requiresFormat: false,
        //crossDomain: true
    });


    $("#attsGrid").ejGrid({
        dataSource: dataManager,
        updateUrl: UpdateGrid
        //BatchURL: UpdateGrid
        //allowPaging: true,
    });
}

