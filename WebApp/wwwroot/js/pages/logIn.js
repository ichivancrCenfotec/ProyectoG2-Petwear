//Clase JS que es el controlador de la vista.
//Cities.cshtml

//Definicion de la clase
function UsersController() {

    this.ViewName = "Users";
    this.ApiService = "UserCRUD";

    this.InitView = function () {

        console.log("User view init!!!");

        //Binding del evento del clic al metodo de create del controlador
        $("#btnLogIn").click(function () {
            var vc = new UsersController();
            vc.LogIn();
        })




    }

    this.LogIn = function () {


        //Crear un DTO de USER

        var users = {};
        users.email = $("#txtEmail").val();
        users.password = $("#txtPassword").val();
      
        //Llamado al API
        var ctrlActions = new ControlActions();
        var serviceRoute = this.ApiService + "/LogIn";
        var serviceRoute2 = this.ApiService + "/RetrieveByEmail";


        ctrlActions.PostToAPI(serviceRoute, users, function () {
            console.log("User logged in ---> " + JSON.stringify(users))

            fetch(serviceRoute2)
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Network response was not ok');
                    }
                    var aux = $.parseJSON(response.json());
                    console.log(aux)
                    sessionStorage.setItem('role', aux.Role);
                    sessionStorage.setItem('photo', aux.Photo);

                })

            
            //Redireccionar a la pagina de inicio
            window.location.href = "https://localhost:7298/Index"; 

            //window.location.href = "https://localhost:7298/UserDashboard"; ESTO LO COMENTÉ XQ NO EXISTE LA PAG AÚN!

        });

        

        console.log(JSON.stringify(users));

    }


}

//Instanciamiento de la clase
$(document).ready(function () {
    var viewCont = new UsersController();
    viewCont.InitView();
})
