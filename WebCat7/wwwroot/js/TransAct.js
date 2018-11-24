$(function () {
    $(document).ready(function () {
        UpdateGridTransAct();
    });
});

function changeClsses() {
    UpdateGridTransAct();
}
function changeActDate() {
    UpdateGridTransAct();
}

    function GetFormattedDate(aDate) {
        try {
            var atDate = new Date(aDate);
            var month = atDate.getMonth() + 1;
            var day = atDate.getDate();
            var year = atDate.getFullYear();
            //if (isNumber(year) || isNumber(month) || isNumber(day))
            //{
            //month = Date.now().getMonth() + 1;
            //day = Date.now().getDate();
            //year = Date.now().getFullYear();
            //}
            return day + "/" + month + "/" + year;
        }
        catch (err) {
            return date.now.getDate() + "/" + date.now.getMonth() + 1 + "/" + date.now.getFullYear();
        }

    }
function UpdateGridTransAct() {
    try {
        var jActDate = document.getElementById("TransActDate").value;
        var jClss = document.getElementById("Schclsses").value;
        var  jActGrps = document.getElementById("TransActGroup").value;
        if (jClss !== "" & jActGrps !== "") {
        var urlAdaptor = new ejs.data.UrlAdaptor();
        var grid = document.querySelector('#TransActGrid').ej2_instances[0];
        grid.dataSource = new ejs.data.DataManager({
            url: "/EnmTransAcitivities/DataSource/?clss=" + jClss + "&actGrps=" + jActGrps + "&actDate=" + jActDate,
            updateUrl: "/EnmTransAcitivities/Update/?clss=" + jClss + "&actGrps=" + jActGrps + "&actDate=" + jActDate,
            adaptor: urlAdaptor
        });
      }
    } catch (err) {
        alert(jActDate);
    }
}

//function dataBound(args) {
//    for (var i = cCnt; i < cCnt + 5; i++) {
//        var column = args.model.columns[i];
//        column.isPrimaryKey = true;
//        column.headerText = "i" + i;
//        this.columns(column, "update");
//    }
//}
