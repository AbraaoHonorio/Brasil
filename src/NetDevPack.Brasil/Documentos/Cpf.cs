﻿using System;
using NetDevPack.Domain;
using NetDevPack.Utilities;
using NetDevPack.Brasil.Documentos.Validacao;

namespace NetDevPack.Brasil.Documentos
{
    public class Cpf
    {
        public string Numero { get; }

        public Cpf(string numero)
        {
            Numero = numero.OnlyNumbers(numero);
            if (!EstaValido()) throw new DomainException("CPF Inválido");
        }

        public override string ToString() => SemMascara();

        public string ComMascara()
        {
            if (string.IsNullOrEmpty(Numero))
            {
                return string.Empty;
            }

            const string pattern = @"{0:000\.000\.000\-00}";
            return string.Format(pattern, Convert.ToUInt64(Numero));
        }

        private bool EstaValido() => new CpfValidador(Numero).EstaValido();
        public string SemMascara() => Numero;
        public bool Equals(Cpf cpf) => Numero == cpf.SemMascara();
    }
}