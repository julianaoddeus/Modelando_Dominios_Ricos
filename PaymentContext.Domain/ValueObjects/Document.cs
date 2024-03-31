using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;
using System.Text.RegularExpressions;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, DocumentTypeEnum type)
        {
            Number = number;
            Type = type;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsTrue(Validate(), "Document.Number", "Documento inválido")
            );
        }
        public string Number { get; private set; }
        public DocumentTypeEnum Type { get; private set; }

        private bool Validate()
        {
            if (Type == DocumentTypeEnum.CNPJ)
            {
                var cnpj = Number.Replace(".", "").Replace("-", "").Replace("/", "");
                // Remover caracteres não numéricos

                // Verificar se o CNPJ tem 14 dígitos
                if (cnpj.Length != 14)
                {
                    return false;
                }

                // Calcular o primeiro dígito verificador
                int[] multiplicadores1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int soma = 0;
                for (int i = 0; i < 12; i++)
                {
                    soma += int.Parse(cnpj[i].ToString()) * multiplicadores1[i];
                }
                int resto = soma % 11;
                int digito1 = resto < 2 ? 0 : 11 - resto;

                // Calcular o segundo dígito verificador
                int[] multiplicadores2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                soma = 0;
                for (int i = 0; i < 13; i++)
                {
                    soma += int.Parse(cnpj[i].ToString()) * multiplicadores2[i];
                }
                resto = soma % 11;
                int digito2 = resto < 2 ? 0 : 11 - resto;

                // Verificar se os dígitos calculados correspondem aos dígitos informados
                return int.Parse(cnpj[12].ToString()) == digito1 && int.Parse(cnpj[13].ToString()) == digito2;
            }


            if (Type == DocumentTypeEnum.CPF)
            {
                var cpf =  Regex.Replace(Number, "[^0-9]", "");

                // Verifica se o CPF tem 11 dígitos
                if (cpf.Length != 11)
                    return false;

                // Verifica se todos os dígitos são iguais
                if (new string(cpf[0], 11) == cpf)
                    return false;

                // Calcula o primeiro dígito verificador
                int soma = 0;
                for (int i = 0; i < 9; i++)
                    soma += int.Parse(cpf[i].ToString()) * (10 - i);
                int resto = soma % 11;
                int digitoVerificador1 = resto < 2 ? 0 : 11 - resto;

                // Verifica o primeiro dígito verificador
                if (int.Parse(cpf[9].ToString()) != digitoVerificador1)
                    return false;

                // Calcula o segundo dígito verificador
                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += int.Parse(cpf[i].ToString()) * (11 - i);
                resto = soma % 11;
                int digitoVerificador2 = resto < 2 ? 0 : 11 - resto;

                // Verifica o segundo dígito verificador
                if (int.Parse(cpf[10].ToString()) != digitoVerificador2)
                    return false;

                return true;
            }

            return false;
        }

    }

}