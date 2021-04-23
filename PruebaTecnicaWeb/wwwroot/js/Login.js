$(function () {
    var formLogueo = $("#form-logueo").dxForm({
        formData: {},
        readOnly: false,
        showColonAfterLabel: true,
        showValidationSummary: false,
        validationGroup: "customerData",
        items: [{
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
            itemType: "button",
            horizontalAlignment: "center",
            buttonOptions: {
                text: "Ingresar",
                type: "success",
                useSubmitBehavior: true,
                onClick: async function (data) {
                    await EnviarForm(data);
                }
            },

        }]
    }).dxForm("instance");

    async function EnviarForm() {
        let inicioOk = await $.post("/Home/IniciarSesion", { model: formLogueo.option("formData") });
        if (inicioOk) {
            DevExpress.ui.notify({
                message: "Ha iniciado sesión.",
                position: {
                    my: "center top",
                    at: "center top"
                }
            }, "success", 2000);

            setTimeout(function () { window.location = "/Vuelos/Index"; }, 2000);
            

        }
    }
})