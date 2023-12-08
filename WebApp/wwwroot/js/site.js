// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Check if the user has admin rights in sessionStorage
var session = JSON.parse(sessionStorage.getItem("SESSION_USER"));
session.id
console.log(session);
console.log(session);
const isAdmin = session.role;
console.log(isAdmin);
// Get all elements with a specific class
const menuItemslogout = document.getElementsByClassName('vis-log-out');

// Hide all menu items with the specified class if the user is not an admin
if (isAdmin != null) {
    for (let i = 0; i < menuItemslogout.length; i++) {
        menuItemslogout[i].style.display = 'none';
        document.getElementById('pfp').setAttribute("src", session.photo );
    }
}