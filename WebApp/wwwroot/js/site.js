// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Check if the user has admin rights in sessionStorage
var session = JSON.parse(sessionStorage.getItem("SESSION_USER"));
console.log(session);

document.getElementById('logout').onclick = function (e) {
    sessionStorage.removeItem("SESSION_USER")
}


// Get all elements with a specific class
const menuItemslogout = document.getElementsByClassName('vis-log-out');
const menuItemslogin = document.getElementsByClassName('vis-log-in');
const menuItemsadmin = document.getElementsByClassName('admin-only');
// Hide all menu items with the specified class if the user is not an admin
for (let i = 0; i < menuItemsadmin.length; i++) {
    menuItemsadmin[i].style.display = 'none';
    console.log(menuItemsadmin[i].innerHTML);
}
for (let i = 0; i < menuItemslogin.length; i++) {
    menuItemslogin[i].style.display = 'none';
}

if (session != null) {
    const isAdmin = session.role;
    if (isAdmin == "Administrador") {
        for (let i = 0; i < menuItemsadmin.length; i++) {
            menuItemsadmin[i].style.display = 'block';
        }
}
    for (let i = 0; i < menuItemslogout.length; i++) {
        menuItemslogout[i].style.display = 'none';
        
    }
    for (let i = 0; i < menuItemslogin.length; i++) {
        menuItemslogin[i].style.display = 'block';
    }

}