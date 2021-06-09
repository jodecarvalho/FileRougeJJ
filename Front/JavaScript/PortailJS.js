function authentification(){
    var username = document.getElementById("uname").value;
    var password = document.getElementById("upass").value;
    if (username == "Jerôme" || username == "Joaquim"){
        document.getElementById("funame").innerHTML = "";
        if(password == "non"){
            window.location.href="MenuPrincipal.html";
            document.getElementById("fupass").innerHTML = "";
        }
        else{
            document.getElementById("fupass").innerHTML = "Mot de passe incorrect";
            document.getElementById("fupass").style.color = "red";
        }
    }
    else{
        document.getElementById("funame").innerHTML = "Cet utilisateur n'est pas reconnu";
        document.getElementById("funame").style.color = "red";
    }
}
