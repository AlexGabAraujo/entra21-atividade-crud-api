﻿using System.Threading.Tasks;
using Dapper;
using MyFirstCRUD.Contracts.Repository;
using MyFirstCRUD.DTO;
using MyFirstCRUD.entity;
using MyFirstCRUD.infrastructure;
using MyFirstCRUD.Repository;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using ZstdSharp.Unsafe;
namespace MyFirstCRUD
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            char op = '0';

            do
            {
                Console.WriteLine("1-Nação 2-Especialidade 3-Estado 4-Cidade:");
                int resposta = int.Parse(Console.ReadLine());
                // Fazer um switch aqui
                if (resposta == 1)
                {
                    Console.WriteLine("-- Cadastro de país --");
                    Console.WriteLine("C-CREATE");
                    Console.WriteLine("R-READ");
                    Console.WriteLine("U-UPDATE");
                    Console.WriteLine("D-DELETE\n");
                    Console.WriteLine("S-SAIR");
                    op = Console.ReadLine().ToUpper()[0];
                    switch (op)
                    {
                        case 'C':
                            await CreateNacao();
                            break;
                        case 'R':
                            await ReadNacao();
                            break;
                        case 'U':
                            await UpdateNacao();
                            break;
                        case 'D':
                            await DeleteNacao();
                            break;
                    }
                }
                else if (resposta == 2)
                {
                    Console.WriteLine("-- Cadastro de Especialidade --");
                    Console.WriteLine("C - CREATE");
                    Console.WriteLine("R - READ");
                    Console.WriteLine("U - UPDATE");
                    Console.WriteLine("D - DELETE\n");
                    Console.WriteLine("S - SAIR");

                    op = Console.ReadLine().ToUpper()[0];

                    switch (op)
                    {
                        case 'C':
                            await CreateEspecialidade();
                            break;
                        case 'R':
                            await ReadEspecialidade();
                            break;
                        case 'U':
                            await UpdateEspecialidade();
                            break;
                        case 'D':
                            await DeleteEspecialidade();
                            break;
                    }
                }
                else if (resposta == 3)
                {
                    Console.WriteLine("-- Cadastro de Estado --");
                    Console.WriteLine("C - CREATE");
                    Console.WriteLine("R - READ");
                    Console.WriteLine("U - UPDATE");
                    Console.WriteLine("D - DELETE\n");
                    Console.WriteLine("S - SAIR");

                    op = Console.ReadLine().ToUpper()[0];

                    switch (op)
                    {
                        case 'C':
                            await CreateEstado();
                            break;
                        case 'R':
                            await ReadEstado();
                            break;
                        case 'U':
                            await UpdateEstado();
                            break;
                        case 'D':
                            await DeleteEstado();
                            break;
                    }
                }
                else if (resposta == 4)
                {
                    Console.WriteLine("-- Cadastro de Cidade --");
                    Console.WriteLine("C - CREATE");
                    Console.WriteLine("R - READ");
                    Console.WriteLine("U - UPDATE");
                    Console.WriteLine("D - DELETE\n");
                    Console.WriteLine("S - SAIR");

                    op = Console.ReadLine().ToUpper()[0];

                    switch (op)
                    {
                        case 'C':
                            await CreateCidade();
                            break;
                        case 'R':
                            await ReadCidade();
                            break;
                        case 'U':
                            await UpdateCidade();
                            break;
                        case 'D':
                            await DeleteCidade();
                            break;
                    }
                }
                if (op != 'S')
                {
                    Console.WriteLine("Pressione 'Enter' para continuar.");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (op != 'S');
            Console.WriteLine("Tchau!");
        }
        //ESPECIALIDADE
        static async Task ReadEspecialidade()
        {
            IEspecialidadeRepository especialidadeRepository = new EspecialidadeRepository();
            IEnumerable<EspecialidadeEntity> especialidadeList = await especialidadeRepository.GetAll();
            foreach (EspecialidadeEntity especialidade in especialidadeList)
            {
                Console.WriteLine($"Id: {especialidade.id}");
                Console.WriteLine($"Nome: {especialidade.Nome}\n");
            }

        }

        static async Task CreateEspecialidade()
        {
            EspecialidadeInsertDTO especialidade = new EspecialidadeInsertDTO();

            Console.WriteLine("Digite o nome da Especialidade: ");
            especialidade.Nome = Console.ReadLine();

            IEspecialidadeRepository especialidadeRepository = new EspecialidadeRepository();
            await especialidadeRepository.Insert(especialidade);
            Console.WriteLine("Especialidade cadastrada com sucesso.");
        }

        static async Task DeleteEspecialidade()
        {
            await ReadEspecialidade();
            Console.WriteLine("Digite o Id que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            IEspecialidadeRepository especialidadeRepository = new EspecialidadeRepository();
            await especialidadeRepository.Delete(id);

            Console.WriteLine("Especialidade deletada com sucesso.");
        }

        static async Task UpdateEspecialidade()
        {
            await ReadEspecialidade();
            Console.WriteLine("Digite o Id que deseja alterar: ");
            int id = int.Parse(Console.ReadLine());

            IEspecialidadeRepository especialidadeRepository = new EspecialidadeRepository();
            EspecialidadeEntity especialidade = await especialidadeRepository.GetById(id);
            Console.WriteLine($"Digite um novo nome para {especialidade.Nome} ou aperte 'Enter' para manter: ");

            string newName = Console.ReadLine();
            if (newName != string.Empty)
            {
                especialidade.Nome = newName;
                await especialidadeRepository.Update(especialidade);
                Console.WriteLine("Nome alterado com sucesso.");
            }
        }
        //NACAO
        static async Task ReadNacao()
        {
            INacaoRepository nacaoRepository = new NacaoRepository();
            IEnumerable<NacaoEntity> nacaoList = await nacaoRepository.GetAll();
            foreach (var nation in nacaoList)
            {
                Console.WriteLine($"Id: {nation.id}");
                Console.WriteLine($"Nome: {nation.Nome}");
            }
        }

        static async Task CreateNacao()
        {
            NacaoInsertDTO nacao = new NacaoInsertDTO();

            Console.WriteLine("Digite o nome:");
            nacao.Nome = Console.ReadLine();
            INacaoRepository nacaoRepository = new NacaoRepository();
            await nacaoRepository.Insert(nacao);
            Console.WriteLine("Nação cadastrada com sucesso!");
        }

        static async Task DeleteNacao()
        {
            await ReadNacao();
            Console.WriteLine("Digite o Id que quer deletar");
            int id = int.Parse(Console.ReadLine());
            INacaoRepository nacaoRepository = new NacaoRepository();
            await nacaoRepository.Delete(id);
            Console.WriteLine("Nação deletada com sucesso");
        }
        static async Task UpdateNacao()
        {
            await ReadNacao();
            Console.WriteLine("Digite o Id que quer alterar");
            int id = int.Parse(Console.ReadLine());
            INacaoRepository nacaoRepository = new NacaoRepository();
            NacaoEntity nacao = await nacaoRepository.GetById(id);
            Console.WriteLine($"Digite um novo nome para {nacao.Nome} ou aperte enter para deixar assim");
            string newName = Console.ReadLine();
            if (newName != string.Empty)
            {
                nacao.Nome = newName;
                await nacaoRepository.Update(nacao);
                Console.WriteLine("Nação alterada com sucesso!");
            }
        }

        //ESTADO

        static async Task ReadEstado()
        {
            IEstadoRepository estadoRepository = new EstadoRepository();
            IEnumerable<EstadoEntity> estadoList = await estadoRepository.GetAll();
            foreach (var state in estadoList)
            {
                Console.WriteLine($"Id: {state.id}");
                Console.WriteLine($"Nome: {state.Nome}");
                Console.WriteLine($"Sigla: {state.Sigla}");
                Console.WriteLine($"Nação_id: {state.Nacao_id}\n");
            }
        }

        static async Task CreateEstado()
        {
            EstadoInsertDTO estado = new EstadoInsertDTO();

            Console.WriteLine("Digite o nome:");
            estado.Nome = Console.ReadLine();
            Console.WriteLine("Digite a sigla:");
            estado.Sigla = Console.ReadLine();
            Console.WriteLine("Digite o id da Nação:");
            estado.Nacao_id = int.Parse(Console.ReadLine());
            IEstadoRepository estadoRepository = new EstadoRepository();
            await estadoRepository.Insert(estado);
            Console.WriteLine("Estado cadastrado com sucesso!");
        }

        static async Task DeleteEstado()
        {
            await ReadEstado();
            Console.WriteLine("Digite o Id que quer deletar");
            int id = int.Parse(Console.ReadLine());
            IEstadoRepository estadoRepository = new EstadoRepository();
            await estadoRepository.Delete(id);
            Console.WriteLine("Estado deletado com sucesso");
        }
        static async Task UpdateEstado()
        {
            await ReadEstado();
            Console.WriteLine("Digite o Id que quer alterar");
            int id = int.Parse(Console.ReadLine());
            IEstadoRepository estadoRepository = new EstadoRepository();
            EstadoEntity estado = await estadoRepository.GetById(id);
            Console.WriteLine($"Digite um novo nome para {estado.Nome} ou aperte enter para deixar assim");
            string newName = Console.ReadLine();
            Console.WriteLine($"Digite uma nova sigla para {estado.Nome} ou aperte enter para deixar");
            string newSigla = Console.ReadLine();
            Console.WriteLine($"Digite o id da nova nação para {estado.Nome} ou aperto enter para deixar");
            int newNation = int.Parse(Console.ReadLine());
            if (newName != string.Empty)
            {
                estado.Nome = newName;
            }
            if (newSigla != string.Empty)
            {
                estado.Sigla = newSigla;
            }
            if (newNation != null)
            {
                estado.Nacao_id = newNation;
            }
            await estadoRepository.Update(estado);
            Console.WriteLine("Alterações feitas com sucesso!");
        }

        // CIDADE

        static async Task ReadCidade()
        {
            ICidadeRepository cidadeRepository = new CidadeRepository();
            IEnumerable<CidadeEntity> cidadeList = await cidadeRepository.GetAll();
            foreach (var cidade in cidadeList)
            {
                Console.WriteLine($"Id: {cidade.id}");
                Console.WriteLine($"Nome: {cidade.Nome}");
                Console.WriteLine($"Estado_id: {cidade.Estado_id}\n");
            }
        }

        static async Task CreateCidade()
        {
            CidadeInsertDTO cidade = new CidadeInsertDTO();

            Console.WriteLine("Digite o nome:");
            cidade.Nome = Console.ReadLine();
            Console.WriteLine("Digite o id do estado:");
            cidade.Estado_id = int.Parse(Console.ReadLine());
            ICidadeRepository cidadeRepository = new CidadeRepository();
            await cidadeRepository.Insert(cidade);
            Console.WriteLine("Cidade cadastrada com sucesso!");
        }

        static async Task DeleteCidade()
        {
            await ReadCidade();
            Console.WriteLine("Digite o Id que quer deletar");
            int id = int.Parse(Console.ReadLine());
            ICidadeRepository cidadeRepository = new CidadeRepository();
            await cidadeRepository.Delete(id);
            Console.WriteLine("Cidade deletado com sucesso");
        }
        static async Task UpdateCidade()
        {
            await ReadCidade();
            Console.WriteLine("Digite o Id que quer alterar");
            int id = int.Parse(Console.ReadLine());
            ICidadeRepository cidadeRepository = new CidadeRepository();
            CidadeEntity cidade = await cidadeRepository.GetById(id);
            Console.WriteLine($"Digite um novo nome para {cidade.Nome} ou aperte enter para deixar assim");
            string newName = Console.ReadLine();
            Console.WriteLine($"Digite o id do novo estado para {cidade.Nome} ou aperto enter para deixar");
            int newCity = int.Parse(Console.ReadLine());
            if (newName != string.Empty)
            {
                cidade.Nome = newName;
            }
            if (newCity != null)
            {
                cidade.Estado_id = newCity;
            }
            await cidadeRepository.Update(cidade);
            Console.WriteLine("Alterações feitas com sucesso!");
        }
    }
}