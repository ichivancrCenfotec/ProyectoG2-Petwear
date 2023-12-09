
function BookingSettingsController() {

    this.ViewName = "BookingSettings";
    this.ApiService = "BookingCRUD";

    this.InitView = function () {

        console.log("Booking view init!!!");

        //Binding del evento del clic al metodo de create del controlador
        $("#btnUpdate").click(function () {
            var vc = new BookingSettingsController();
            vc.Update();
        })

        $("#btnDelete").click(function () {
            var vc = new BookingSettingsController();
            vc.Delete();
        })


        this.LoadTable();
    }
    

    this.Update = function () {

       

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
        var serviceRoute = this.ApiService + "/Update";

        ctrlActions.PutToAPI(serviceRoute, booking, function () {
            console.log("Booking created ---> " + JSON.stringify(booking))
       
        })
    }
    this.Delete = function () {
        var booking = {}
        booking.id = $("#txtID").val();


        // Llamado al API para eliminar el usuario
        var ctrlActions = new ControlActions();
        var serviceRoute = this.ApiService + "/Delete"; // Suponiendo que la API utiliza una ruta DELETE que toma el ID del usuario

        ctrlActions.DeleteToAPI(serviceRoute, booking, function () {
            console.log("Booking deleted -->" + JSON.stringify(booking));
            // Muestra un Sweet Alert para informar que el usuario se ha eliminado correctamente

        });

    }
    this.LoadTable = function () {

        var ctrlActions = new ControlActions();//ControlActions nos permie interactuar con el api

        //RUTA DEL API PARA CONSUMIR EL SERVICIO

        var urlService = ctrlActions.GetUrlApiService(this.ApiService + "/RetrieveAll")


        //Definir las columnas que vamos a extraer del json de respuesta del API
        var columns = [];
        columns[0] = { 'data': 'id' };
        columns[1] = { 'data': 'checkInDate' };
        columns[2] = { 'data': 'checkOutDate' };
        columns[3] = { 'data': 'considerations' };
        columns[4] = { 'data': 'status' };
        columns[5] = { 'data': 'idUser' };
        columns[6] = { 'data': 'idPet' };
        columns[7] = { 'data': 'idPackage' };
        columns[8] = { 'data': 'totalPrice' };
        
       
        



        //Inicializamos la tabla como un data table
        //Cargar a partir del API
        $("#tbListBooking").dataTable({

            "ajax": {
                "url": urlService,
                "dataSrc": ""//Este servcio nos devuelve la data y recorremos a partir de la raiz
            },
            "columns": columns
        });
        //Hacer binding del evento del click de la fila de la tabla

        $('#tbListBooking tbody').on('click', 'tr', function () {

            //buscamos la fila que se le dio click

            var row = $(this).closest('tr');//toma el tr que selecciono

            //extraer data de la fila

            var BookingData = $('#tbListBooking').DataTable().row(row).data();//Nos permite extraer
            //la data que tiene la fila seleccionada

            //binding de valores de la data sobre el form
            $("#txtID").val(BookingData.id);
            $("#txtCheckInDate").val(BookingData.checkInDate);
            $("#txtCheckOutDate").val(BookingData.checkOutDate);
            $("#txtConsiderations").val(BookingData.considerations);
            $("#txtStatus").val(BookingData.status);
            $("#txtIdUser").val(BookingData.iduser);
            $("#txtIdPet").val(BookingData.idpet);
            $("#txtIdPackage").val(BookingData.idPackage);
            $("#txtTotalPrice").val(BookingData.totalPrice);

        })

    }
}
$(document).ready(function () {
    var viewController = new BookingSettingsController();
    viewController.InitView();
})