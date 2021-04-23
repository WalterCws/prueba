$(function () {
    var serviceUrl = "?handler=";

    $("#dataGridContainer").dxDataGrid({
        dataSource: DevExpress.data.AspNet.createStore({
            //key: "Id",
            loadUrl: serviceUrl + "ListarVuelos",
            //insertUrl: serviceUrl + "/InsertAction",
            //updateUrl: serviceUrl + "/UpdateAction",
            //deleteUrl: serviceUrl + "/DeleteAction"
        }),
        //remoteOperations: { groupPaging: true },
        noDataText: "No hay vuelos registrados.",
        showBorders: true,
        columns: [
            {
                dataField: "numeroVuelo",              
                dataType: "number"
            },
            {
                dataField: "ciudadOrigen.nombre",
                caption: "Ciudad de origen", 
                editorType : "dxSelectBox",
                alignment: "right",
                displayExpr: "nombre",
                acceptCustomValue: true
            },
            {
                dataField: "ciudadDestino.nombre",
                caption: "Ciudad de destino",
                alignment: "right",
                editorType: "dxSelectBox",
                displayExpr: "nombre",                
                acceptCustomValue: true,
            },
            {
                dataField: "fechaSalida",
                dataType: "date"
            },
            {
                dataField: "fechaLlegada",
                dataType: "date"
            },            
            {
                dataField: "estadoVuelo",
                dataType: "string",
            }
        ]
    });
});