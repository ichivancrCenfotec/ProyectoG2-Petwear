function PetReportController() {

    this.ViewName = "PetReport";
    this.ApiService = "PetCRUD";

    this.InitView = function () {

        console.log("Pet Report view init!!!");

        //Inicializacion y carga de la tabla

        this.LoadTable();

    }

    this.LoadTable = function () {

        var ctrlActions = new ControlActions();//ControlActions nos permie interactuar con el api

        //RUTA DEL API PARA CONSUMIR EL SERVICIO

        var urlService = ctrlActions.GetUrlApiService(this.ApiService + "/RetrieveAll")


        //Definir las columnas que vamos a extraer del json de respuesta del API
        var columns = [];
        columns[0] = { 'data': 'id' };
        columns[1] = { 'data': 'namePet' };
        columns[2] = { 'data': 'age' };
        columns[3] = { 'data': 'breed' };
        columns[4] = { 'data': 'weight' };
        columns[5] = { 'data': 'description' };
        columns[6] = { 'data': 'levelAggressiveness' };
       



        //Inicializamos la tabla como un data table
        //Cargar a partir del API
        $("#tbListPet").dataTable({

            "ajax": {
                "url": urlService,
                "dataSrc": ""//Este servcio nos devuelve la data y recorremos a partir de la raiz
            },
            "columns": columns
        });


    }
}
$(document).ready(function () {
    var viewController = new PetReportController();
    viewController.InitView();
})