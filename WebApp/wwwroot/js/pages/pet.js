//Clase JS que es el controlador de la vista.
//Cities.cshtml

//Definicion de la clase
function PetsController() {

    this.ViewName = "Pets";
    this.ApiService = "PetCRUD";

    this.InitView = function () {

        console.log("User view init!!!");


        //Binding del evento del clic al metodo de create del controlador
        $("#btnCreate").click(function () {
            var vc = new PetsController();
            vc.Create();
        })

        //
        $("#btnUpdate").click(function () {
            var vc = new PetsController();
            vc.Update();
        })

        $("#btnDelete").click(function () {
            var vc = new PetsController();
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
  "idPet": 0,
  "namePet": "string",
  "age": 0,
  "breed": "string",
  "weight": 0,
  "description": "string",
  "levelAggressiveness": 0,
  "fotoUno": "string",
  "fotoDos": "string"
}

        
        */

        //Crear un DTO de PETS

        var pets = {};
        pets.namepet = $("#txtNamePet").val();
        pets.age = $("#txtAge").val();
        pets.breed = $("#txtBreed").val();
        pets.weight = $("#txtWeight").val();    
        pets.description = $("#txtDescription").val();
        pets.levelAggressiveness = $("#LevelAggressiveness").val();
        pets.fotoUno = localStorage.getItem('photouser1');
        pets.fotoDos = localStorage.getItem('photouser2');

  

        //Llamado al API
        var ctrlActions = new ControlActions();
        var serviceRoute = this.ApiService + "/Create";

        ctrlActions.PostToAPI(serviceRoute, pets, function () {
            console.log("Pet created ---> " + JSON.stringify(pets))

        });

        console.log(JSON.stringify(pets));
    }

    this.Update = function () {

        var pets = {};
        pets.idPet = $("#txtPetId").val();
        pets.namePet = $("#txtNamePet").val();
        pets.age = $("#txtAge").val();
        pets.breed = $("#txtBreed").val();
        pets.weight = $("#txtWeight").val();
        pets.description = $("#txtDescription").val();
        pets.levelAggressiveness = $("#txtLevelAggressiveness").val();
        pets.fotoUno = localStorage.getItem('photouser1');
        pets.fotoDos = localStorage.getItem('photouser2');


        //Llamado al API
        var ctrlActions = new ControlActions();
        var serviceRoute = this.ApiService + "/Update";

        ctrlActions.PutToAPI(serviceRoute, users, function () {
            console.log("Pet updated ---> " + JSON.stringify(pets))

        });
    }

    this.Delete = function () {
        //Crear un DTO de USER
        var pets = {};
        pets.idPet = $("#txtIdPet").val();

        //Llamado al API
        var ctrlActions = new ControlActions();
        var serviceRoute = this.ApiService + "/Delete";

        ctrlActions.DeleteToAPI(serviceRoute, users, function () {
            console.log("Pet deleted ---> " + JSON.stringify(pets))
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
    var viewCont = new PetsController();
    viewCont.InitView();
})
