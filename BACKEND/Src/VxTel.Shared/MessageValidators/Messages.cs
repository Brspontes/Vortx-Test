using System;
using System.Collections.Generic;
using System.Text;

namespace VxTel.Shared.MessageValidators
{
    public static class Messages
    {
        public const string TAMANHO_DDD_ORIGEM = "Tamanho do DDD origem deve ser composto por três numeros";
        public const string NAO_NULO_ORIGEM = "Tamnho do DDD origem deve ser composto por três numeros";
        public const string TAMANHO_DDD_DESTINO = "Tamnho do DDD destino deve ser composto por três numeros";
        public const string NAO_NULO_DESTINO = "O campo destino deve ser preenchido";
        public const string CUSTO_MAIOR_QUE_ZERO = "O custo por minuto deve ser superior a Zero";
        public const string DDD_ORIGEM_DESTINO_IGUAIS = "Não são cobrados minutos para o mesmo DDD";
        public const string MINUTOS_MAIOR_QUE_PLANO = "Os minutos desejados devem ser maior que oferecido pelo plano";
        public const string TAMANHO_MINIMO_NOME_PLANO = "O nome do plano deve conter ao menos 1 caractere";
        public const string TAMANHO_MAXIMO_NOME_PLANO = "O nome do plano não pode ultrapassar 50 caracteres";
        public const string NAO_NULO_NOME_PLANO = "O nome do plano deve ser preenchido";
        public const string MINUTOS_MAIOR_QUE_ZERO = "Os minutos do plano devem ser maior que zero";
        public const string LOGIN_OU_SENHA_INCORRETOS = "Login ou Senha incorretos";
        public const string NAO_FORAM_ENCONTRADOS_PLANOS = "Não foram encontrados planos para os DDDs selecionados";
        public const string NOME_PLANO_INCORRETO = "O nome do plano não é válido";
        public const string QUANTIDADE_MINUTOS_PLANO = "A quantidade de minutos para o plano deve ser maior que zero";
        public const string ERRO_REGISTRAR_PLANO = "Não foi possível realizar o cadastro do plano, tente novamente ou mais tarde";
        public const string REGISTRO_NAO_ECONTRADO = "Registro não encontrado";
        public const string OPERACAO_REALIZADA_COM_SUCESSO = "Registro removido com sucesso";

    }
}
