//Clase JS que es el controlador de la vista.
//Cities.cshtml

//Definicion de la clase
function PackagesController() {

    this.ViewName = "Packages";
    this.ApiService = "PackageCRUD";

    this.InitView = function () {

        console.log("User view init!!!");


        //Binding del evento del clic al metodo de create del controlador
        $("#btnCreate").click(function () {
            var vc = new PackagesController();
            vc.Create();
        })

        //
        $("#btnUpdate").click(function () {
            var vc = new PackagetsController();
            vc.Update();
        })

        $("#btnDelete").click(function () {
            var vc = new PackagesController();
            vc.Delete();
        })

        //Inicializacion de la tabla
         this.LoadTable();



    }

    this.Create = function () {

        /*

        EndPoint: https://localhost:7246/api/PetCRUD/Create

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

        var packages = {};
        packages.packageId = $("#txtPackageId").val();
        packages.cost = $("#txtCost").val();
        packages.desiption = $("#txtdescription").val();
       



        //Llamado al API
        var ctrlActions = new ControlActions();
        var serviceRoute = this.ApiService + "/Create";

        ctrlActions.PostToAPI(serviceRoute, packages, function () {
            console.log("Package created ---> " + JSON.stringify(packages))

        });

        console.log(JSON.stringify(packages));
    }

    this.Update = function () {

        var packages = {};
        packages.packageId = $("#txtPackageId").val();
        packages.cost = $("#txtCost").val();
        packages.desiption = $("#txtdescription").val();



        //Llamado al API
        var ctrlActions = new ControlActions();
        var serviceRoute = this.ApiService + "/Update";

        ctrlActions.PutToAPI(serviceRoute, users, function () {
            console.log("Package updated ---> " + JSON.stringify(packages))

        });
    }

    this.Delete = function () {
        //Crear un DTO de USER
        var packages = {};
        packages.packageId = $("#txtPackageId").val();

        //Llamado al API
        var ctrlActions = new ControlActions();
        var serviceRoute = this.ApiService + "/Delete";

        ctrlActions.DeleteToAPI(serviceRoute, users, function () {
            console.log("Pet deleted ---> " + JSON.stringify(packages))
        });

    }

    this.LoadTable = function () {




        var ctrlActions = new ControlActions();

        //Ruta del API para concluir el servicio
        var urlService = ctrlActions.GetUrlApiService(this.ApiService + "/RetriveAllServices");

        /*
    {
    "idService": 2,
    "cost": 0,
    "serviceName": "string",
    "description": "string",
    "availability": 0,
    "id": 0
  },
        */
        //Definir columnas de la tabla
        var columns = [];
        columns[0] = { "data": "idService" };
        columns[1] = { "data": "cost" };
        columns[2] = { "data": "serviceName" };
        columns[3] = { "data": "description" };
        columns[4] = { "data": "availability" };


        //Inicializamos la tabla como un datatable Y CARGAR A PARTIR DEL API
        $("#tblServices").dataTable({
            "ajax": {
                "url": urlService,
                "dataSrc": ""
            },
            "columns": columns

        });

        //hacer un binding de los eventos de la tabla

        $('#tblServices tbody').on('click', 'tr', function () {

            //Buscamos la fila que se le dio clic
            var row = $(this).closest('tr');

            //Extraemos la data de la fila

            var serviceData = $('#tblServices').DataTable().row(row).data();

            //Binding de valores de la data sobre el formulario


            $("txtServiceId").val(serviceData.ID_SERVICE);
          

        });


    }


}

//Instanciamiento de la clase
$(document).ready(function () {
    var viewCont = new PackagesController();
    viewCont.InitView();
})
