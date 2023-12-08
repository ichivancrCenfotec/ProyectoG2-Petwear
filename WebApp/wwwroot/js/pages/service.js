//Clase JS que es el controlador de la vista.


//Definicion de la clase
function ServicesController() {

    this.ViewName = "Services";
    this.ApiService = "ServiceCRUD";

    this.InitView = function () {

        console.log("Service view init!!!");

        //Binding del evento del clic al metodo de create del controlador
        $("#btnCreate").click(function () {
            var vc = new ServicesController();
            vc.Create();
        })

        //
        $("#btnUpdate").click(function () {
            var vc = new ServicesController();
            vc.Update();
        })

        $("#btnDelete").click(function () {
            var vc = new ServicesController();
            vc.Delete();
        })

        //Inicializacion de la tabla
       // this.LoadTable();



    }

    this.Create = function () {

        /*

        EndPoint: https://localhost:7246/api/UserCRUD/Create

         {
            public int IdPackage { get; set; }

            public float Cost { get; set; }

            public string ServiceName { get; set; }

            public string Description { get; set; }
      
            public bool Availability { get; set; }

        }

        
        */

        //Crear un DTO 

        var services = {};
        services.idpackage = $("#txtId").val();
        services.cost = $("#txtCost").val();
        services.servicename = $("#txtServiceName").val();
        services.description = $("#txtDescription").val();
        services.availability = $("#cbAvailability").val();

  

        //Llamado al API
        var ctrlActions = new ControlActions();
        var serviceRoute = this.ApiService + "/Create";

        ctrlActions.PostToAPI(serviceRoute, services, function () {
            console.log("Service created ---> " + JSON.stringify(services))
            window.location.href = "https://localhost:7298/Payment";
        });

        console.log(JSON.stringify(services));
    }

    this.Update = function () {

        var services = {};
        services.idpackage = $("#txtId").val();
        services.cost = $("#txtCost").val();
        services.name = $("#txtServiceName").val();
        services.description = $("#txtDescription").val();
        services.availability = $("#cbAvailability").val();



        //Llamado al API
        var ctrlActions = new ControlActions();
        var serviceRoute = this.ApiService + "/Update";

        ctrlActions.PutToAPI(serviceRoute, services, function () {
            console.log("Service updated ---> " + JSON.stringify(services))

        });
    }

    this.Delete = function () {
        //Crear un DTO
        var services = {};
        services.id = $("#txtId").val();

        //Llamado al API
        var ctrlActions = new ControlActions();
        var serviceRoute = this.ApiService + "/Delete";

        ctrlActions.DeleteToAPI(serviceRoute, services, function () {
            console.log("Service deleted ---> " + JSON.stringify(services))
        });

    }
}

//Instanciamiento de la clase
$(document).ready(function () {
    var viewCont = new ServicesController();

    viewCont.InitView();
})
