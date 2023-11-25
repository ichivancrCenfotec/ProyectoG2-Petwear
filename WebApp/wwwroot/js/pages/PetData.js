function IDEAController() {

    this.ViewName = "PetData";
    this.ApiService = "IDEA";
    this.InitView = function () {
        console.log("Pet Data view init!!!");
        this.LoadTable();
    }

    this.LoadTable = function () {

        var ctrlActions = new ControlActions();//ControlActions nos permie interactuar con el api

        //RUTA DEL API PARA CONSUMIR EL SERVICIO

        var urlService = ctrlActions.GetUrlApiService(this.ApiService + "/RetrieveAll/RetrieveAll")

        //Definir las columnas que vamos a extraer del json de respuesta del API
        var columns = [];
        columns[0] = { 'data': 'id' }
        columns[1] = { 'data': 'idPet' }
        columns[2] = { 'data': 'temperature' }
        columns[3] = { 'data': 'humidity' }
        columns[4] = { 'data': 'ultraViolet' }
        columns[5] = { 'data': 'created' }




        //Inicializamos la tabla como un data table
        //Cargar a partir del API
        $("#tbListPetData").dataTable({
            "ajax": {
                "url": urlService,
                "dataSrc": ""
            },
            "columns":columns
           });
     }
 }
        $(document).ready(function () {
            var viewController = new IDEAController();
            viewController.InitView();
        })








