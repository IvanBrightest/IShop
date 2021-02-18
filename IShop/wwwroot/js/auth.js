const authUrl = "/Account/Login"

document.getElementById('auth').addEventListener("click", Auth, false);

function Auth(event) {
    event.preventDefault();
    const data = {
        login: document.getElementById("login").value,
        password: document.getElementById("pass").value
    }
    
    return new Promise((resolve, reject) => {
        const xhr = new XMLHttpRequest();

        xhr.open("POST", authUrl);
        xhr.setRequestHeader("Content-Type", "application/json");

        xhr.onload = () => {
            if (xhr.status >= 400) {
                reject(xhr.response)
            }
            else {
                if (xhr.response === "Success") {
                    document.location = "/";
                }
                else {
                    resolve(document.getElementsByClassName("error").innerHTML = xhr.response);
                }
            }
        }

        xhr.onerror = () => {
            reject(xhr.response)
        }
        
        xhr.send(JSON.stringify(data));

    });

}


    //$("#auth").click(function (e) {
    //    e.preventDefault();
    //    var login = $("#login").val();
    //    var pass = $("#pass").val();
    //    var auth = $("#auth").val();
    //    $.ajax({
    //        url: './',
    //        type: 'POST',
    //        data: { auth: auth, login: login, pass: pass },
    //        success: function (res) {
    //            if (res != 'Поля логин/пароль должны быть заполнены!' && res != 'Логин/пароль введены неверно!') {
    //                // если пользователь успешно авторизован
    //                $(".authform").hide().fadeIn(500).html(res + '<a href="?do=logout">Выход</a>');
    //                // удаляем лишние поля заказа
    //                $(".notauth").fadeOut(500);
    //                setTimeout(function () {
    //                    $(".notauth").remove();
    //                }, 500);
    //            } else {
    //                // если авторизация неудачна
    //                $(".error").remove();
    //                $(".authform").append('<div class="error"></div>');
    //                $(".error").hide().fadeIn(500).html(res);
    //            }
    //        },
    //        error: function () {
    //            alert("Error!");
    //        }
    //    });
    //});