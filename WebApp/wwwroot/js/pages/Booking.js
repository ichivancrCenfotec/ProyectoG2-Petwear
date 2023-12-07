
//Cities.cshtml

//Definicion de la clase
function BookingController() {

    this.ViewName = "Booking";
    this.ApiService = "BookingCRUD";

    this.InitView = function () {

        console.log("Booking view init!!!");

        $("#txtIdPackage").change(function () {
            // Cuando el usuario selecciona un nuevo paquete, actualizar el Total Price
            var packageId = $(this).val();
            console.log("Package ID selected:", packageId);
            // Llamado al API para obtener el precio del paquete
            var packageCtrlActions = new ControlActions();
            var packageServiceRoute = "PackageCRUD/RetrieveById?id=" + packageId;

            packageCtrlActions.GetToApi(packageServiceRoute, function (package) {
                // Actualizar el campo Total Price con el precio del paquete
                if (package && package.Cost !== undefined) {
                    // Actualizar el campo Total Price con el costo del paquete
                    console.log("Package Cost retrieved:", package.Cost);
                    $("#txtTotalPrice").val(package.Cost);
                } else {
                    console.error("Error: No se pudo obtener el costo del paquete.");
                }
            }, function (error) {
                console.error("Error al llamar al API para obtener el costo del paquete:", error);
            
            });
        });

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