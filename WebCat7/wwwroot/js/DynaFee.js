var jClss = "";
var jSession = "";
var jStdFeeCat = "";

function changeClsses(sender) {
    jClss = sender.itemData.value;
    jStdFeeName = "";
    $("#DynaF").submit();
}

function changeSession(sender) {
    jSession = sender.itemData.value;
    jStdFeeName = "";
    $("#DynaF").submit();
}

function changeStdFeeCat(sender) {
    jStdFeeCat = sender.value;
    jStdFeeName = "";
    $("#DynaF").submit();
}
//Use Less
function UpdateGrid() {
    
    if (jClss !== "") {
        if (jSession !== "") {
            if (jStdFeeCat !== "") {
                if (jStdFeeName !== "") {
                    //alert(jClss + "  " + jSession + "  " + jStdFeeCat)
                    var urlAdaptor = new ej.data.UrlAdaptor();
                    var grid = document.querySelector('#dynaGrid').ej2_instances[0];
                    grid.dataSource = new ej.data.DataManager({
                        url: "/DynaFees/DataSource?clss=" + jClss + "&tSess=" + jSession + "&StdFeeCat=" + jStdFeeCat,
                        updateUrl: "/DynaFees/Update?clss=" + jClss + "&tSess=" + jSession + "&StdFeeCat=" + jStdFeeCat,
                        adaptor: urlAdaptor
                    });
                }
            }
        }
    }
}

function click(args) {
    if (this.model.editSettings.editMode === "normal") {
        this.startEdit(args.row);  //trigger to edit the row 
    }
} 