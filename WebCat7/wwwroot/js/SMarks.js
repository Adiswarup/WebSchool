$(function () {
    $(document).ready(function () 
    {
        alert("Ready");
      UpdateGrid(jClss, jExamName, jsubName);
    });
});

function UpdateGrid(uclss,  uExamName, uSubName) {
    var urlAdaptor = new ej.data.UrlAdaptor();
    var grid = document.querySelector('#MarksGrid').ej2_instances[0];
    grid.dataSource = new ej.data.DataManager({
        url: "/Marks/DataSource?clss=" + uclss + "&ExamName=" + uExamName + "&SubName=" + uSubName,
        updateUrl: "/Marks/Update",
        adaptor: urlAdaptor
    });
 }