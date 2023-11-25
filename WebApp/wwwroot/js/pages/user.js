//Clase JS que es el controlador de la vista.
//Cities.cshtml

//Definicion de la clase
function UsersController() {

    this.ViewName = "Users";
    this.ApiService = "UserCRUD";

    this.InitView = function () {

        console.log("User view init!!!");


        //Binding del evento del clic al metodo de create del controlador
        $("#btnCreate").click(function () {
            var vc = new UsersController();
            vc.Create();
        })

        //
        $("#btnUpdate").click(function () {
            var vc = new UsersController();
            vc.Update();
        })

        $("#btnDelete").click(function () {
            var vc = new UsersController();
            vc.Delete();
        })

        //Inicializacion de la tabla
       // this.LoadTable();



    }

    this.Create = function () {

        /*

        EndPoint: https://localhost:7246/api/UserCRUD/Create

        {
  "id": 0,
  "name": "string",
  "email": "string",
  "password": "string",
  "createdDate": "2023-10-21T14:34:13.507Z",
  "status": 0,
  "fechaNacimiento": "2023-10-21T14:34:13.507Z"
}

        
        */

        //Crear un DTO de USER

        var users = {};
        users.name = $("#txtName").val();
        users.lastname = $("#txtLastName").val();
        users.email = $("#txtEmail").val();
        users.password = $("#txtPassword").val();
        users.address = $("#txtAddress").val();
        users.phone = $("#txtNumber").val();
        users.role = $("#txtRole").val();
        users.photo = $("#uploadedimage").getAttribute('src');

  

        //Llamado al API
        var ctrlActions = new ControlActions();
        var serviceRoute = this.ApiService + "/Create";

        ctrlActions.PostToAPI(serviceRoute, users, function () {
            console.log("User created ---> " + JSON.stringify(users))

            window.location.href = "https://localhost:7298/RegisterValidation";
        });

        console.log(JSON.stringify(users));
    }

    this.Update = function () {

        var users = {};
        users.id = $("#txtId").val();
        users.name = $("#txtName").val();
        users.lastname = $("#txtLastName").val();
        users.email = $("#txtEmail").val();
        users.password = $("#txtPassword").val();
        users.address = $("#txtAddress").val();
        users.phone = $("#txtNumber").val();
        users.role = $("#txtRole").val();



        //Llamado al API
        var ctrlActions = new ControlActions();
        var serviceRoute = this.ApiService + "/Update";

        ctrlActions.PutToAPI(serviceRoute, users, function () {
            console.log("User updated ---> " + JSON.stringify(users))

        });
    }

    this.Delete = function () {
        //Crear un DTO de USER
        var users = {};
        users.id = $("#txtId").val();

        //Llamado al API
        var ctrlActions = new ControlActions();
        var serviceRoute = this.ApiService + "/Delete";

        ctrlActions.DeleteToAPI(serviceRoute, users, function () {
            console.log("User deleted ---> " + JSON.stringify(users))
        });

    }

    /*
     this.LoadTable = function () {




        var ctrlActions = new ControlActions();

        //Ruta del API para concluir el servicio
        var urlService = ctrlActions.GetUrlApiService(this.ApiService + "/RetriveAll");


        //Definir columnas de la tabla
        var columns = [];
        columns[0] = { "data": "city_Id" };
        columns[1] = { "data": "name" };
        columns[2] = { "data": "country" };
        columns[3] = { "data": "latitude" };
        columns[4] = { "data": "longitude" };


        //Inicializamos la tabla como un datatable Y CARGAR A PARTIR DEL API
        $("#tblListUsers").dataTable({
            "ajax": {
                "url": urlService,
                "dataSrc": ""
            },
            "columns": columns

        });

        //hacer un binding de los eventos de la tabla

        $('#tblListUserss tbody').on('click', 'tr', function () {

            //Buscamos la fila que se le dio clic
            var row = $(this).closest('tr');

            //Extraemos la data de la fila

            var userData = $('#tblListUsers').DataTable().row(row).data();

            //Binding de valores de la data sobre el formulario


            $("#txtCityId").val(userData.city_id);
            $("#txtCountry").val(userData.country);
            $("#txtName").val(userData.name);
            $("#txtLatitude").val(userData.latitude);
            $("#txtLongitude").val(userData.longitude);

        });


    }
    

    */


   


}

//Instanciamiento de la clase
$(document).ready(function () {
    var viewCont = new UsersController();
    viewCont.InitView();
})
