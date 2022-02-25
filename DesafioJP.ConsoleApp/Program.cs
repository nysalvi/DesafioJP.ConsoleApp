using System;

namespace DesafioJP.ConsoleApp
{
    internal class Program
    {
        // equipamento = nome 0 | preço 1 | nº série 2 | data fabricação 3 | fabricante 4;
        // manutenção = titulo 0 | descrição 1 | equipamento 2 | data 3
        static int menuEquipamento()
        {
            Console.WriteLine("Digite 1 para registrar um equipamento\nDigite 2 para visualizar um" +
            " equipamento\nDigite 3 para editar um equipamento\nDigite 4 para excluir um equipamento ");            
            int.TryParse(Console.ReadLine(), out int comando);
            
            if (comando == 1 || comando == 2 || comando == 3 || comando == 4)
            {
                return comando;
            }
            return -1;
        }
        static int menuManutencao()
        {
            Console.WriteLine("Digite 1 para registrar um chamado\nDigite 2 para visualizar um" +
            " chamado\nDigite 3 para editar um chamado\nDigite 4 para excluir um chamado ");
            int.TryParse(Console.ReadLine(), out int comando);

            if (comando == 1 || comando == 2 || comando == 3 || comando == 4)
            {
                return comando;
            }
            return -1;
        }

        #region equipamento
        static bool registrarEquipamento(ref string[][] equipamento, ref int registrados)
        {   if (registrados < 1000)
            {
                string nome;

                while (true)
                {
                    Console.WriteLine("Digite o nome do equipamento | OBS : Têm que ter 6 caracteres...");
                    nome = Console.ReadLine();
                    if (nome.Length < 6)
                    {
                        Console.WriteLine("6 caracteres são necessários !!");
                        continue;
                    }
                    break;
                }
                equipamento[registrados][0] = nome;
                Console.WriteLine("Digite o preço do equipamento : ");
                equipamento[registrados][1] = Console.ReadLine();
                Console.WriteLine("Digite o número de série : ");
                equipamento[registrados][2] = Console.ReadLine();
                Console.WriteLine("Digite a data de fabricação : ");
                equipamento[registrados][3] = Console.ReadLine();
                Console.WriteLine("Digite o nome da fabricante : ");
                equipamento[registrados][4] = Console.ReadLine();
                registrados++;
                Console.WriteLine("Item registrado com Sucesso!!\n");
                return true;
            }
            Console.WriteLine("ERRO!!!\tO array atingiu o tamanho máximo!\n");
            return false;
        }
        static void visualizarEquipamento(ref string[][] equipamento, ref int registrados)
        {
            for (int i = 0; i < registrados; i++)
            {
                Console.WriteLine("Equipamento {0} : {1} nºsérie {2} fabricante {3}", i + 1,
                equipamento[i][0], equipamento[i][2], equipamento[i][4]);
            }
            Console.WriteLine();
        }        
        static bool editarEquipamento(ref string[][] equipamento, ref int registrados)
        {
            Console.WriteLine("Digite o número de série do item que deseja modificar : ");
            string numItem = Console.ReadLine();
            for (int i = 0; i < registrados; i++)
            {
                if (equipamento[i][2] == numItem)
                {
                    Console.WriteLine("Digite um novo nome para o equipamento : (OBS) : 0 para pular");
                    string nome = Console.ReadLine();
                    Console.WriteLine("Digite um novo preço para o equipamento : (OBS) : 0 para pular");
                    string preço = Console.ReadLine();
                    Console.WriteLine("Digite um novo nº série para o equipamento : (OBS) : 0 para pular");
                    string numSerie = Console.ReadLine();
                    Console.WriteLine("Digite uma nova data para o equipamento : (OBS) : 0 para pular");
                    string data = Console.ReadLine();
                    Console.WriteLine("Digite um novo fabricante para o equipamento : (OBS) : 0 para pular");
                    string fabricante = Console.ReadLine();
                    if (nome != "0")
                        equipamento[i][0] = nome;
                    if (preço != "0")
                        equipamento[i][1] = preço;
                    if (numSerie != "0")
                        equipamento[i][2] = numSerie;
                    if (data != "0")
                        equipamento[i][3] = data;
                    if (fabricante != "0")
                        equipamento[i][4] = fabricante;
                    Console.WriteLine("Status atual do Equipamento : ");
                    Console.WriteLine("\tEquipamento {0} : {1} preço {2} nºsérie {3}  data {4} " +
                    "fabricante {5}", 
                    i, equipamento[i][0], equipamento[i][1], equipamento[i][2], equipamento[i][3], 
                    equipamento[i][4]);
                    return true;
                }
            }
            Console.WriteLine("Impossível editar!!\tO item não está na lista\n");
            return false;
        }
        static bool excluirEquipamento(ref string[][] equipamento, ref string[][] manutencao, 
            ref int registrados)
        {
            Console.WriteLine("Digite o número de série do item que deseja deletar : ");
            string numItem = Console.ReadLine();
            string[][] copia = new string[1000][];
            for (int i = 0; i < 1000; i++)
                copia[i] = new string[5];
            string nomeEquipamento = "";
            int posicaoEquipamento = -1;
            for (int i = 0; i < registrados; i++)
            {
                if (equipamento[i][2] != numItem)                
                    copia[i] = equipamento[i];
                else
                {
                    nomeEquipamento = equipamento[i][0];
                    posicaoEquipamento = i;
                }
                if (nomeEquipamento == manutencao[i][2])
                {
                    Console.WriteLine("ERRO!! o item está atribuido a um item na lista de Manutenção\n");
                    return false;
                }
            }
            if (posicaoEquipamento == -1)
            {
                Console.WriteLine("Impossível excluir!!\tO item não está na lista\n");
                return false;
            }
            for (int i = 0; i < posicaoEquipamento; i++)
            {
                if (nomeEquipamento == manutencao[i][2])
                {
                    Console.WriteLine("ERRO!! o item está atribuido a um item na lista de Manutenção\n");
                    return false;
                }
            }
            equipamento = copia;
            Console.WriteLine("Item excluído com Sucesso!!\n");
            registrados--;
            return true;
        }
        #endregion

        #region manutencao
        static bool registrarManutencao(ref string[][] manutencao, ref int registrados)
        {
            if (registrados < 1000)
            {
                Console.WriteLine("Digite o título do chamado");
                manutencao[registrados][0] = Console.ReadLine();
                Console.WriteLine("Digite a descrição do chamado : ");
                manutencao[registrados][1] = Console.ReadLine();
                Console.WriteLine("Digite o equipamento associado a ele : ");
                manutencao[registrados][2] = Console.ReadLine();
                Console.WriteLine("Digite a data de abertura do chamado: ");
                manutencao[registrados][3] = Console.ReadLine();
                registrados++;
                return true;
            }
            return false;
        }
        static void visualizarManutencao(ref string[][] manutencao, ref int registrados)
        {
            int totaldias;
            for (int i = 0; i < registrados; i++)
            {
            int diahoje = int.Parse(DateTime.Now.ToString().Substring(0, 2));
            int meshoje = int.Parse(DateTime.Now.ToString().Substring(3, 2));
            int anohoje = int.Parse(DateTime.Now.ToString().Substring(6, 4));

            int diaDataAbertura = int.Parse(manutencao[i][3].Substring(0, 2));
            int mesDataAbertura = int.Parse(manutencao[i][3].Substring(3, 2));
            int anoDataAbertura = int.Parse(manutencao[i][3].Substring(6, 4));
            totaldias = diahoje - diaDataAbertura + (meshoje - mesDataAbertura) * 30 +
                (anohoje - anoDataAbertura) * 365;
                Console.WriteLine("Chamado {0} : {1} equipamento {2} data de abertura {3}" +
                " nº dias {4}", i + 1, manutencao[i][0], manutencao[i][1], manutencao[i][3], totaldias);
            }
            Console.WriteLine();
        }
        static bool editarManutencao(ref string[][] manutencao, ref int registrados)
        {
            Console.WriteLine("Digite o nome do equipamento do chamado que deseja modificar : ");
            string numItem = Console.ReadLine();
            for (int i = 0; i < registrados; i++)
            {
                if (manutencao[i][2] == numItem)
                {
                    Console.WriteLine("Digite um novo título para o chamado : (OBS) : 0 para pular");
                    string titulo = Console.ReadLine();
                    Console.WriteLine("Digite uma nova descrição para o chamado : (OBS) : 0 para pular");
                    string descricao = Console.ReadLine();
                    Console.WriteLine("Digite um novo equipamento para o chamado: (OBS) : 0 para pular");
                    string equipamento = Console.ReadLine();
                    Console.WriteLine("Digite uma nova data de abertura para o chamado: (OBS) : 0 para pular");
                    string data = Console.ReadLine();
                    if (titulo != "0")
                        manutencao[i][0] = titulo;
                    if (descricao != "0")
                        manutencao[i][1] = descricao;
                    if (equipamento != "0")
                        manutencao[i][2] = equipamento;
                    if (data != "0")
                        manutencao[i][3] = equipamento;
                    Console.WriteLine("Status atual do Chamado : ");
                    Console.WriteLine("\tChamado {0} : {1} descrição {2} equipamento {3}  data {4} ",
                    i + 1, manutencao[i][0], manutencao[i][1], manutencao[i][2], manutencao[i][3],
                    manutencao[i][4]);
                    return true;
                }
            }
            Console.WriteLine("Impossível editar!!\tO item não está na lista\n");
            return false;

        }
        static bool excluirManutencao(ref string[][] manutencao, ref int registrados)
        {
            Console.WriteLine("Digite o nome do equipamento do chamado que deseja deletar : ");
            string equipamento = Console.ReadLine();
            string[][] copia = new string[1000][];
            for (int i = 0; i < 1000; i++)
                copia[i] = new string[4]; 
            int posicaoEquipamento = -1;
            for (int i = 0; i < registrados; i++)
            {
                if (manutencao[i][2] != equipamento)
                    copia[i] = manutencao[i];
                else
                    posicaoEquipamento = i;
            }
            if (posicaoEquipamento == -1)
            {
                Console.WriteLine("Impossível excluir!!\tO item não está na lista\n");
                return false;
            }
            manutencao = copia;
            Console.WriteLine("Item excluído com Sucesso!!\n");
            registrados--;
            return true;
        }
        #endregion
        static void Main(string[] args)
        {
            // equipamento = nome 0 | preço 1 | nº série 2 | data fabricação 3 | fabricante 4;
            // manutenção = titulo 0 | descrição 1 | equipamento 2 | data 3
            string[][] equipamento = new string[1000][];
            string[][] manutencao = new string [1000][];
            for (int i = 0; i < 1000; i++)
            { equipamento[i] = new string[5]; manutencao[i] = new string[5];}
            int equipamentoRegistrado = 0, manutencaoRegistrado = 0;
            string menu;
            int opcao, opcaoEquipamento, opcaoManutencao;
            while (true)
            {
                Console.WriteLine("Digite 1 para entrar no Menu De Equipamentos\nDigite 2 para entrar no" +
                    " Menu de Manutenção\nDigite 3 para limpar o Console\nDigite s para Sair");
                menu = Console.ReadLine();
                if (menu.ToLower().Equals("s"))
                    break;
                int.TryParse(menu, out opcao);
                if (opcao == 1)
                {
                    opcaoEquipamento = menuEquipamento();
                    if (opcaoEquipamento == 1)
                        registrarEquipamento(ref equipamento, ref equipamentoRegistrado);
                    else if (opcaoEquipamento == 2)
                        visualizarEquipamento(ref equipamento, ref equipamentoRegistrado);
                    else if (opcaoEquipamento == 3)
                        editarEquipamento(ref equipamento, ref equipamentoRegistrado);
                    else if (opcaoEquipamento == 4)
                        excluirEquipamento(ref equipamento, ref manutencao, ref equipamentoRegistrado);
                }
                else if (opcao == 2)
                {
                    opcaoManutencao = menuManutencao();
                    if (opcaoManutencao == 1)
                        registrarManutencao(ref manutencao, ref manutencaoRegistrado);
                    else if (opcaoManutencao == 2)
                        visualizarManutencao(ref manutencao, ref manutencaoRegistrado);
                    else if (opcaoManutencao == 3)
                        editarManutencao(ref manutencao, ref manutencaoRegistrado);
                    else if (opcaoManutencao == 4)
                        excluirManutencao(ref manutencao, ref manutencaoRegistrado);
                }
                else if (opcao == 3)
                    Console.Clear();
                opcao = 0;
            }
        }
   
    }
}
