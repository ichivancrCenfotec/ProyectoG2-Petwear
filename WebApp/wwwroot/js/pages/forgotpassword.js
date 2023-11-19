//Clase JS que es el controlador de la vista.
//Cities.cshtml

//Definicion de la clase
function UsersController() {

    this.ViewName = "Users";
    this.ApiService = "UserCRUD";

    this.InitView = function () {

        console.log("User view init!!!");

        //Binding del evento del clic al metodo de create del controlador
        $("#btnResetPassword").click(function () {
            var vc = new UsersController();
            vc.ResetPassword();
        })

    }

    this.ResetPassword = function () {


        //Crear un DTO de USER

        var users = {};
        users.email = $("#txtEmail").val();
  

        //Llamado al API
        var ctrlActions = new ControlActions();
        var serviceRoute = this.ApiService + "/ResetPassword";

        ctrlActions.PutToAPI(serviceRoute, users, function () {
            console.log("User logged in ---> " + JSON.stringify(users))

            //Redireccionar a la pagina de inicio
            window.location.href = "https://localhost:7298/OTPReset";

        });
    }


}

 



//Instanciamiento de la clase
$(document).ready(function () {
    var viewCont = new UsersController();
    viewCont.InitView();
})
