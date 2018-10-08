var jClss = "";
var jActGrps = "";


    //$(document).ready(function () {
        //jClss = $('#selectClsses').data("ejDropDownList").selectItemByIndex(0);
        //jActGrps = $('#selectActGrps').data("ejDropDownList").selectItemByIndex(0);
  //});

function changeClsses(sender) {
    jClss = sender.itemData.value;
    UpdateGrid(jClss, jActGrps);
}

function changeActGrps(sender) {
    jActGrps = sender.itemData.value;
    UpdateGrid(jClss, jActGrps);
}
function changeActDate(sender) {
    jActDate = sender.value;
    UpdateGrid(jClss, jActGrps);
}

function UpdateGrid(clss, actGrps) {
    if ((clss !== "") & (actGrps !== "")) {
       var actDate = document.getElementById("selectActDate").value
        //document.getElementById("#selectActDate").value();
        //actDate = $('#selectActDate').data("ej-date-picker").value();
        var dataManager = ej.DataManager({
            url: "/TransActivities/DataSource/?clss=" + clss + "&actGrps=" + actGrps + "&actDate=" + actDate,
            updateUrl: "/TransActivities/Update/?actDate=" + actDate,
            adaptor: new ej.UrlAdaptor()
        });
    };

    $("#TransActGrid").ejGrid({
        dataSource: dataManager,
        allowPaging: true
    });
}

function dataBound(args) {
    for (var i = cCnt; i < cCnt + 5; i++) {
        var column = args.model.columns[i];
        column.isPrimaryKey = true;
        column.headerText = "i" + i;
        this.columns(column, "update");
    }
}
