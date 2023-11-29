/Clase JS que es el controlador de la vista.
//Cities.cshtml

//Definicion de la clase
function BookingController() {

    this.ViewName = "Booking";
    this.ApiService = "BookingCRUD";

    this.InitView = function () {

        console.log("User view init!!!");


        //Binding del evento del clic al metodo de create del controlador
        $("#btnCreate").click(function () {
            var vc = new BookingController();
            vc.Create();
        })

        //
        $("#btnUpdate").click(function () {
            var vc = new BookingController();
            vc.Update();
        })

        $("#btnDelete").click(function () {
            var vc = new BookingController();
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

        var booking = {};
        booking.idpet = $("#txtNamePet").val();
        booking.iduser = $("#txtAge").val();
        booking.checkInDate = $("#txtBreed").val();
        booking.checkOutDate = $("#txtWeight").val();
        booking.considerations = $("#txtBreed").val();
        booking.status = $("#txtWeight").val();



        //Llamado al API
        var ctrlActions = new ControlActions();
        var serviceRoute = this.ApiService + "/Create";

        ctrlActions.PostToAPI(serviceRoute, pets, function () {
            console.log("Pet created ---> " + JSON.stringify(pets))

        });

        console.log(JSON.stringify(pets));
    }