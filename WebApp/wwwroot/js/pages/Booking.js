


//Definicion de la clase
function BookingController() {

    this.ViewName = "Booking";
    this.ApiService = "BookingCRUD";

    this.InitView = function () {

        console.log("Booking view init!!!");

        //Binding del evento del clic al metodo de create del controlador
        $("#btnCreate").click(function () {
            var vc = new BookingController();
            vc.Create();
        })


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
        booking.checkInDate = $("#txtCheckInDate").val();
        booking.checkOutDate = $("#txtCheckOutDate").val();
        booking.considerations = $("#txtConsiderations").val();
        booking.status = $("#txtStatus").val();
        booking.iduser = $("#txtIdUser").val();
        booking.idpet = $("#txtIdPet").val();
        booking.idPackage = $("#txtIdPackage").val();
        booking.totalPrice = $("#txtTotalPrice").val();



        //Llamado al API
        var ctrlActions = new ControlActions();
        var serviceRoute = this.ApiService + "/Create";

        ctrlActions.PostToAPI(serviceRoute, booking, function () {
            console.log("Booking created ---> " + JSON.stringify(booking))

            window.location.href = "https://localhost:7298/Checkout";
        }, function (error) {
            console.error("Error al crear la reserva:", error);
        })
    }
}
$(document).ready(function () {
    var viewController = new BookingController();
    viewController.InitView();
})