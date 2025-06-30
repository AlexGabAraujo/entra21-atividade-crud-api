﻿namespace API_HealthGo.Entity
{
    public enum Frequencia
    {
        Nenhum,
        Diario,
        Semanal,
        Mensal
    }

    public class LembreteEntity
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public int Pessoa_id { get; set; }
    }
}
