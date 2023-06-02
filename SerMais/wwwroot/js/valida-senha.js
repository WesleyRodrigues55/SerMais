function validarSenha(senha) {
    if (senha.length < 8) {
        return false;
    }

    if (!/[0-9]/.test(senha)) {
        return false;
    }

    if (!/[A-Z]/.test(senha)) {
        return false;
    }

    if (!/[^a-zA-Z0-9]/.test(senha)) {
        return false;
    }

    return true;
}

$(document).ready(function () {
    $("#senha").on("blur", function () {
        var senha = $(this).val();
        var senhaValida = validarSenha(senha);
        var botao = $("#botao");

        if (senhaValida) {
            $("#senha-erro").text("Senha válida").removeClass("erro").addClass("sucesso");
            botao.prop("disabled", false); // Habilita o botão
        } else {
            $("#senha-erro").text("Senha inválida").removeClass("sucesso").addClass("erro");
            botao.prop("disabled", true); // Desabilita o botão
        }
    });
});