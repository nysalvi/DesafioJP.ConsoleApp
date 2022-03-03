using System;
using System.Globalization;
namespace DesafioJP.ConsoleApp
{
    internal class Program
    {
        static uint idEquipamento = 1, idManutencao = 1;
        // equipamento = nome 1 | preço 2 | nº série 3 | data fabricação 4 | fabricante 5;
        // manutenção = titulo 1 | descrição 2 | equipamento 3 | data 4
        static int menuEquipamento()
        {
            Console.Clear();
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
            Console.Clear();
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
        static bool registrarEquipamento(ref string[][] equipamento, ref uint registrados)
        {   Console.Clear();
            if (registrados < 1000)
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
                equipamento[registrados][0] = Convert.ToString(idEquipamento);
                idEquipamento++;
                equipamento[registrados][1] = nome;
                Console.WriteLine("Digite o preço do equipamento : ");
                equipamento[registrados][2] = Console.ReadLine();
                Console.WriteLine("Digite o número de série : ");
                equipamento[registrados][3] = Console.ReadLine();
                while (true)
                {
                    Console.WriteLine("Digite a data de fabricação : ");
                    equipamento[registrados][4] = Console.ReadLine();                    
                    if (DateTime.TryParse(equipamento[registrados][4], out DateTime c))
                        break;
                }
                Console.WriteLine("Digite o nome da fabricante : ");
                equipamento[registrados][5] = Console.ReadLine();
                registrados++;
                Console.WriteLine("Item registrado com Sucesso!!\n");
                return true;
            }
            Console.WriteLine("ERRO!!!\tO array atingiu o tamanho máximo!\n");
            return false;
        }
        static void visualizarEquipamento(ref string[][] equipamento, ref uint registrados)
        {
            Console.Clear();
            for (int i = 0; i < registrados; i++)
            {
                Console.WriteLine("ID {0} - {1} :\tnºsérie {2}\tfabricante {3}", 
                    equipamento[i][0], equipamento[i][1], equipamento[i][3], equipamento[i][5]);
            }
            Console.WriteLine();
        }        
        static bool editarEquipamento(ref string[][] equipamento, ref uint registrados)
        {
            Console.Clear();
            Console.WriteLine("Digite a ID do item que deseja modificar : ");
            string id = Console.ReadLine();
            for (int i = 0; i < registrados; i++)
            {
                if (equipamento[i][0] == id)
                {
                    Console.WriteLine("Digite um novo nome para o equipamento : (OBS) : 0 para pular");
                    string nome = Console.ReadLine();
                    Console.WriteLine("Digite um novo preço para o equipamento : (OBS) : 0 para pular");
                    string preço = Console.ReadLine();
                    Console.WriteLine("Digite um novo nº série para o equipamento : (OBS) : 0 para pular");
                    string numSerie = Console.ReadLine();
                    string data;
                    while (true)
                    {
                        Console.WriteLine("Digite uma nova data para o equipamento : (OBS) : 0 para pular");
                        data = Console.ReadLine();
                        if (data == "0" || DateTime.TryParse(data, out DateTime c))
                            break;
                    }
                    Console.WriteLine("Digite um novo fabricante para o equipamento : (OBS) : 0 para pular");
                    string fabricante = Console.ReadLine();
                    if (nome != "0")
                        equipamento[i][1] = nome;
                    if (preço != "0")
                        equipamento[i][2] = preço;
                    if (numSerie != "0")
                        equipamento[i][3] = numSerie;
                    if (data != "0")
                        equipamento[i][4] = data;
                    if (fabricante != "0")
                        equipamento[i][5] = fabricante;
                    Console.WriteLine("\tStatus atual do Equipamento : ");
                    Console.WriteLine("ID {0} - {1} :\n\tpreço {2} \n\tnºsérie {3} \n\tdata {4} " +
                    "\n\tfabricante {5}", 
                    equipamento[i][0], equipamento[i][1], equipamento[i][2], equipamento[i][3], equipamento[i][4], 
                    equipamento[i][5]);
                    return true;
                }
            }
            Console.WriteLine("Impossível editar!!\tO item não está na lista\n");
            return false;
        }
        static bool excluirEquipamento(ref string[][] equipamento, ref string[][] manutencao, 
            ref uint registrados)
        {
            Console.Clear();
            Console.WriteLine("Digite a ID do item que deseja deletar : ");
            string id = Console.ReadLine();
            string[][] copia = new string[1000][];
            int encontrou = -1;
            
            for (int i = 0; i < 1000; i++)
                copia[i] = new string[6];
            for (int i = 0; i < registrados; i++)
            {
                if (equipamento[i][0] != id)
                    copia[i] = equipamento[i];
                else
                    encontrou = i;
                if (id == manutencao[i][5])
                {
                    Console.WriteLine("ERRO!! o item está atribuido a um item na lista de Manutenção\n");
                    return false;
                }
            }
            if (encontrou == -1)
            {
                Console.WriteLine("Impossível excluir!!\tO item não está na lista\n");
                return false;
            }
            equipamento = copia;
            Console.WriteLine("Item excluído com Sucesso!!\n");
            registrados--;
            return true;
        }
        #endregion

        #region manutencao
        static bool registrarManutencao(ref string[][] manutencao, ref uint registrados)
        {
            Console.Clear();
            if (registrados < 1000)
            {
                manutencao[registrados][0] = Convert.ToString(idManutencao);
                idManutencao++;
                Console.WriteLine("Digite o título do chamado");
                manutencao[registrados][1] = Console.ReadLine();
                Console.WriteLine("Digite a descrição do chamado : ");
                manutencao[registrados][2] = Console.ReadLine();
                Console.WriteLine("Digite o equipamento associado a ele : ");
                manutencao[registrados][3] = Console.ReadLine();
                while (true)
                {
                    Console.WriteLine("Digite a data de abertura do chamado : ");
                    manutencao[registrados][4] = Console.ReadLine();
                    if (DateTime.TryParse(manutencao[registrados][4], out DateTime c))
                        break;
                }
                Console.WriteLine("Digite a ID do equipamento selecionado : ");
                manutencao[registrados][5] = Console.ReadLine();

                registrados++;
                return true;
            }
            return false;
        }
        static void visualizarManutencao(ref string[][] manutencao, ref uint registrados)
        {
            int dias;
            Console.Clear();
            for (int i = 0; i < registrados; i++)
            {            
                dias = (DateTime.Now - DateTime.Parse(manutencao[i][4], CultureInfo.CurrentCulture)).Days;
                Console.WriteLine("ID {0} - {1}: \n\tequipamento {2} \n\tdata de abertura {3}" +
                " \n\tnº dias {4}", manutencao[i][0], manutencao[i][1], manutencao[i][3],
                manutencao[i][4], dias);
            }
            Console.WriteLine();
        }
        static bool editarManutencao(ref string[][] manutencao, ref uint registrados)
        {
            Console.Clear();
            Console.WriteLine("Digite a ID do chamado que deseja modificar : ");
            string id = Console.ReadLine();
            for (int i = 0; i < registrados; i++)
            {
                if (manutencao[i][0] == id)
                {
                    Console.WriteLine("Digite um novo título para o chamado : (OBS) : 0 para pular");
                    string titulo = Console.ReadLine();
                    Console.WriteLine("Digite uma nova descrição para o chamado : (OBS) : 0 para pular");
                    string descricao = Console.ReadLine();
                    Console.WriteLine("Digite um novo equipamento para o chamado: (OBS) : 0 para pular");
                    string equipamento = Console.ReadLine();
                    string data;
                    while (true)
                    {
                        Console.WriteLine("Digite uma nova data de abertura para o chamado: (OBS) : 0 para pular");
                        data = Console.ReadLine();
                        if (data == "0" || DateTime.TryParse(data, out DateTime c))
                            break;
                    }
                    if (titulo != "0")
                        manutencao[i][1] = titulo;
                    if (descricao != "0")
                        manutencao[i][2] = descricao;
                    if (equipamento != "0")
                        manutencao[i][3] = equipamento;
                    if (data != "0")
                        manutencao[i][4] = data;
                    Console.WriteLine("Status atual do Chamado : ");
                    Console.WriteLine("\tID {0} : {1}\tdescrição {2}\tequipamento {3}\tdata {4} ",
                    manutencao[i][0], manutencao[i][1], manutencao[i][2], manutencao[i][3],
                    manutencao[i][4]);
                    return true;
                }
            }
            Console.WriteLine("Impossível editar!!\tO item não está na lista\n");
            return false;

        }
        static bool excluirManutencao(ref string[][] manutencao, ref uint registrados)
        {
            Console.Clear();
            Console.WriteLine("Digite a ID do chamado que deseja deletar : ");
            string id = Console.ReadLine();
            string[][] copia = new string[1000][];
            bool encontrou = false;
            for (int i = 0; i < 1000; i++)
            {
                copia[i] = new string[5];
                if (i < registrados)
                    if (manutencao[i][0] != id)
                        copia[i] = manutencao[i];
                    else
                        encontrou = true;
            }
            if (!encontrou)
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
            // equipamento = nome 1 | preço 2 | nº série 3 | data fabricação 4 | fabricante 5;
            // manutenção = titulo 1 | descrição 2 | equipamento 3 | data 4
            string[][] equipamento = new string[1000][];
            string[][] manutencao = new string [1000][];
            for (int i = 0; i < 1000; i++)
            { equipamento[i] = new string[6]; manutencao[i] = new string[6];}
            uint equipamentoRegistrado = 0, manutencaoRegistrado = 0;
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
