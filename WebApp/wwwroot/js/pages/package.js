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
        // this.LoadTable();



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



}

//Instanciamiento de la clase
$(document).ready(function () {
    var viewCont = new PackagesController();
    viewCont.InitView();
})
