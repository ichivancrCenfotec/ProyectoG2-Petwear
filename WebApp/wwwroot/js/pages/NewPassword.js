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
            vc.NewPassword();
        })

    }

    this.NewPassword = function () {


        //Crear un DTO de USER

        var users = {};
        user.email = $("#txtEmail").val();
        users.password = $("#txtNewPass").val();


        //Llamado al API
        var ctrlActions = new ControlActions();
        var serviceRoute = this.ApiService + "/NewPassword";

        ctrlActions.PutToAPI(serviceRoute, users, function () {
            console.log("User Password Reseted ---> " + JSON.stringify(users))
        });
    }


}


//Instanciamiento de la clase
$(document).ready(function () {
    var viewCont = new UsersController();
    viewCont.InitView();
})
