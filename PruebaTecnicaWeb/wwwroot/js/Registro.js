$(function () {

    var verificarEmail = function (value) {
        return $.get("/Home/VerificarCorreo", { correo: value });
    }

    var formWidget = $("#form-registro").dxForm({
        formData: {},
        readOnly: false,
        showColonAfterLabel: true,
        showValidationSummary: false,
        validationGroup: "customerData",
        items: [
            {
                label: {
                    text: "Correo electrónico"
                },
                dataField: "Email",
                validationRules: [{
                    type: "required",
                    message: "Campo obligatorio"
                }, {
                    type: "email",
                    message: "Correo invalido"
                }, {
                    type: "async",
                    message: "Email is already registered",
                    validationCallback: async function (params) {
                        return  await verificarEmail(params.value);
                    }
                }]
            }
            ,
            {
            label: {
                text: "Nombre de usuario"
            },
            dataField: "UserName",
            validationRules: [{
                type: "required",
                message: "Campo obligatorio"
            }]
        }
            ,
        {
            label: {
                text: "Contraseña"
            },
            dataField: "Password",
            editorOptions: {
                mode: "password"
            },
            validationRules: [{
                type: "required",
                message: "Campo obligatorio"
            }]
        }
            ,
        {
            label: {
                text: "Confime contraseña"
            },
            editorType: "dxTextBox",
            editorOptions: {
                mode: "password"
            },
            validationRules: [{
                type: "required",
                message: "Campo obligatorio"
            },
            {
                type: "compare",
                message: "Las contraseñas no coinciden",
                comparisonTarget: function () {
                    return formWidget.option("formData").Password;
                }
            }]            
        }            
            ,
        {
            itemType: "button",
            horizontalAlignment: "center",
            buttonOptions: {
                text: "Register",
                type: "success",
                useSubmitBehavior: true,
                onClick: async function (data) {
                    await EnviarForm(data);
                }
            },
            
        } ]
    }).dxForm("instance");

    async function EnviarForm() {
        let guardado = await $.post("/Home/RegistrarUsuario", { model: formWidget.option("formData") });
        if (guardado) {
            DevExpress.ui.notify({
            message: "Registro éxitoso",
            position: {
                my: "center top",
                at: "center top"
                }
            }, "success", 3000);

            setTimeout(function () {
                window.location = "/Home/Logueo";
             }, 2000);

        }
    }

    
});

