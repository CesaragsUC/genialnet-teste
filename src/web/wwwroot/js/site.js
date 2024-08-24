
function FindCep() {

    $(document).ready(function () {

        function clear_form_cep() {
            $("#Address_Street").val("");
            $("#Address_Neighborhood").val("");
            $("#Address_City").val("");
            $("#Address_State").val("");
        }

        $("#Address_PostalCode").blur(function () {

            var cep = $(this).val().replace(/\D/g, '');

            if (cep != "") {

                var validacep = /^[0-9]{8}$/;

                if (validacep.test(cep)) {

                    //Preenche os campos com "..." enquanto consulta webservice.
                    $("#Address_Street").val("...");
                    $("#Address_Neighborhood").val("...");
                    $("#Address_City").val("...");
                    $("#Address_State").val("...");

                    //Consulta o webservice viacep.com.br/
                    $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?",
                        function (dados) {

                            if (!("erro" in dados)) {
                                //Atualiza os campos com os valores da consulta.
                                $("#Address_Street").val(dados.logradouro);
                                $("#Address_Neighborhood").val(dados.bairro);
                                $("#Address_City").val(dados.localidade);
                                $("#Address_State").val(dados.uf);
                            } 
                            else {
                                clear_form_cep();
                                alert("CEP não encontrado.");
                            }
                        });
                } 
                else {
                    clear_form_cep();
                    alert("Formato de CEP inválido.");
                }
            }
            else {
                clear_form_cep();
            }
        });
    });
}

$(document).ready(function () {
    $("#msg_box").fadeOut(2500);
});