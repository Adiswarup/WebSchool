function changeClsses() {
    UpdateGrid();
}

function changeAttType() {
    UpdateGrid();
}

function changeAttDate() {
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
        var jActDate = document.getElementById("AttDate").value;
        jClss = document.getElementById("Schclsses").value;
        jAtType = document.getElementById("AttType").value;
        if (jClss !== "" & jAtType !== "") {
        //var atDateObj = document.getElementById ('selectDate').ej2_instances[0];
        //var atDate = atDateObj.value;
       //alert(jclss + "  " + jAtType + "  " + jAtDate);
        //var datepickerObject = document.getElementById("selectDate").ej2_instances[0];
        //atDate = datepickerObject.currentDate;

        var urlAdaptor = new ejs.data.UrlAdaptor();
        var grid = document.querySelector('#attsGrid').ej2_instances[0];
        grid.dataSource = new ejs.data.DataManager({
            url: "/Attendances/DataSource?clss=" + jClss + "&atType=" + jAtType + "&atDate=" + jActDate,
            updateUrl: "/Attendances/Update?clss=" + jClss + "&atType=" + jAtType + "&AtDate=" + jActDate,
            adaptor: urlAdaptor
        });
    } 
}

function click(args) {
    if (this.model.editSettings.editMode === "normal") {
        this.startEdit(args.row);  //trigger to edit the row 
    }
} 