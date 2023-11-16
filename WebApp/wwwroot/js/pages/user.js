//Clase JS que es el controlador de la vista.
//Cities.cshtml

//Definicion de la clase
function CitiesController() {

    this.ViewName = "Cities";
    this.ApiService = "CitiesCrud";

    this.InitView = function () {

        console.log("User view init!!!");

        //Binding del evento del clic al metodo de create del controlador
        $("#btnCreate").click(function () {
            var vc = new CitiesController();
            vc.Create();
        })

        //
        $("#btnUpdate").click(function () {
            var vc = new CitiesController();
            vc.Update();
        })

        $("#btnDelete").click(function () {
            var vc = new CitiesController();
            vc.Delete();
        })

        //Inicializacion de la tabla
        this.LoadTable();



    }

    this.Create = function () {

        /*

        EndPoint: https://localhost:7187/api/UserCRUD/Create

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

        var cities = {};
        cities.country = $("#txtCountry").val();
        cities.name = $("#txtName").val();
        cities.latitude = $("#txtLatitude").val();
        cities.longitude = $("#txtLongitude").val();



        //Llamado al API
        var ctrlActions = new ControlActions();
        var serviceRoute = this.ApiService + "/Create";

        ctrlActions.PostToAPI(serviceRoute, cities, function () {
            console.log("Citie created ---> " + JSON.stringify(cities))
        });

        console.log(JSON.stringify(cities));
    }

    this.Update = function () {

        var cities = {};
        cities.city_id = $("#txtCityId").val();
        cities.country = $("#txtCountry").val();
        cities.name = $("#txtName").val();
        cities.latitude = $("#txtLatitude").val();
        cities.longitude = $("#txtLongitude").val();


        //Llamado al API
        var ctrlActions = new ControlActions();
        var serviceRoute = this.ApiService + "/Update";

        ctrlActions.PutToAPI(serviceRoute, cities, function () {
            console.log("City updated ---> " + JSON.stringify(cities))

        });
    }

    this.Delete = function () {
        //Crear un DTO de USER
        var cities = {};
        cities.city_id = $("#txtCityId").val();

        //Llamado al API
        var ctrlActions = new ControlActions();
        var serviceRoute = this.ApiService + "/Delete";

        ctrlActions.DeleteToAPI(serviceRoute, cities, function () {
            console.log("User deleted ---> " + JSON.stringify(cities))
        });

    }

    this.LoadTable = function () {




        var ctrlActions = new ControlActions();

        //Ruta del API para concluir el servicio
        var urlService = ctrlActions.GetUrlApiService(this.ApiService + "/RetriveAll");

        /*
          {
    "name": "string                                            ",
    "email": "string                                            ",
    "password": null,
    "createdDate": "2023-10-07T17:29:34.043",
    "status": 0,
    "fechaNacimiento": "2000-10-07T17:29:24.637",
    "id": 1
  },
        */
        //Definir columnas de la tabla
        var columns = [];
        columns[0] = { "data": "city_Id" };
        columns[1] = { "data": "name" };
        columns[2] = { "data": "country" };
        columns[3] = { "data": "latitude" };
        columns[4] = { "data": "longitude" };


        //Inicializamos la tabla como un datatable Y CARGAR A PARTIR DEL API
        $("#tblListCities").dataTable({
            "ajax": {
                "url": urlService,
                "dataSrc": ""
            },
            "columns": columns

        });

        //hacer un binding de los eventos de la tabla

        $('#tblListCities tbody').on('click', 'tr', function () {

            //Buscamos la fila que se le dio clic
            var row = $(this).closest('tr');

            //Extraemos la data de la fila

            var userData = $('#tblListCities').DataTable().row(row).data();

            //Binding de valores de la data sobre el formulario


            $("#txtCityId").val(userData.city_id);
            $("#txtCountry").val(userData.country);
            $("#txtName").val(userData.name);
            $("#txtLatitude").val(userData.latitude);
            $("#txtLongitude").val(userData.longitude);

        });


    }


}

//Instanciamiento de la clase
$(document).ready(function () {
    var viewCont = new CitiesController();
    viewCont.InitView();
})
