function UserReportController() {

    this.ViewName = "UserReport";
    this.ApiService = "UserCRUD";

    this.InitView = function () {

        console.log("User Report view init!!!");

        $("#btnAssign").click(function () {
            var vc = new UserReportController();
            vc.Update();
        })


        //Inicializacion y carga de la tabla

        this.LoadTable();

    }


    this.Update = function () {

        var users = {};
        users.id = $("#txtId").val();
        users.role = $("#txtRole").val();
     



        //Llamado al API
        var ctrlActions = new ControlActions();
        var serviceRoute = this.ApiService + "/UpdateRole";

        ctrlActions.PutToAPI(serviceRoute, users, function () {
            console.log("User Role Assigned ---> " + JSON.stringify(users))

        });
    }

    this.LoadTable = function () {

        var ctrlActions = new ControlActions();//ControlActions nos permie interactuar con el api

        //RUTA DEL API PARA CONSUMIR EL SERVICIO

        var urlService = ctrlActions.GetUrlApiService(this.ApiService + "/RetriveAll")



        /*
         {
    "name": "San Miguel",
    "country": "Costa Rica",
    "latitude": 40,
    "longitude": 77,
    "id": 3
  },
        */

        //Definir las columnas que vamos a extraer del json de respuesta del API
        var columns = [];
        columns[0] = { 'data': 'id' };
        columns[1] = { 'data': 'name' };
        columns[2] = { 'data': 'lastName' };
       // columns[3] = { 'data': 'password' };
        columns[3] = { 'data': 'email' };
        columns[4] = { 'data': 'address' };
        columns[5] = { 'data': 'role' };
        columns[6] = { 'data': 'photo' };
        columns[7] = { 'data': 'phoneNumber' };
       // columns[9] = { 'data': 'validationOTP' };
        //columns[10] = { 'data': 'resetOTP' };
        columns[8] = { 'data': 'status' };



        //Inicializamos la tabla como un data table
        //Cargar a partir del API
        $("#tbListUsers").dataTable({

            "ajax": {
                "url": urlService,
                "dataSrc": ""//Este servcio nos devuelve la data y recorremos a partir de la raiz
            },
            "columns": columns
        });

        
    }
}
$(document).ready(function () {
    var viewController = new UserReportController();
    viewController.InitView();
})