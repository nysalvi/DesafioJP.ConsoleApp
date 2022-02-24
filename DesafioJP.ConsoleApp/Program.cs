using System;

namespace DesafioJP.ConsoleApp
{
    internal class Program
    { 
        // 0 nome 1 preço 2 nº série 3 data fabricação 4 fabricante;
        static string[][] equipamento = new string[5][]{ new string[1000], new string[1000], 
            new string[1000], new string[1000], new string[1000]};

        static string[][] registro = new string[4][]{ new string[1000], new string[1000], 
            new string[1000], new string[1000]};
        static int registrados = 0;
        static int menuEquipamento()
        {
            Console.WriteLine("Digite 1 para registrar um equipamento\nDigite 2 para visualizar um" +
            "equipamento\nDigite 3 para editar um equipamento\nDigite 4 para excluir um equipamento ");            
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
            "chamado\nDigite 3 para editar um chamado\nDigite 4 para excluir um chamado ");
            int.TryParse(Console.ReadLine(), out int comando);

            if (comando == 1 || comando == 2 || comando == 3 || comando == 4)
            {
                return comando;
            }
            return -1;
        }
        static bool registrarEquipamento(ref string[][] equipamento, ref int contador)
        {   if (contador < 1000)
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
                equipamento[contador][0] = nome;
                Console.WriteLine("Digite o preço do equipamento : ");
                equipamento[contador][1] = Console.ReadLine();
                Console.WriteLine("Digite o número de série : ");
                equipamento[contador][2] = Console.ReadLine();
                Console.WriteLine("Digite a data de fabricação : ");
                equipamento[contador][3] = Console.ReadLine();
                Console.WriteLine("Digite o nome da fabricante : ");
                equipamento[contador][4] = Console.ReadLine();
                contador++;
                return true;
            }
            return false;
        }
        static void visualizarEquipamento(ref string[][] equipamento, ref int registrados)
        {
            for (int i = 0; i < registrados; i++)
            {
                Console.WriteLine("Equipamento {0} : {1} nºsérie {2} fabricante {3}", i + 1,
                equipamento[i][0], equipamento[i][2], equipamento[i][4]);
            }
        }        
        static void editarEquipamento(ref string[][] equipamento)
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
                        equipamento[i][3] = numSerie;
                    if (fabricante != "0")
                        equipamento[i][4] = numSerie;
                    Console.WriteLine("Status atual do Equipamento : ");
                    Console.WriteLine("\tEquipamento {0} : {1} preço {2} nºsérie {3}  data {4} " +
                    "fabricante {5}", 
                    i, equipamento[i][0], equipamento[i][1], equipamento[i][2], equipamento[i][3], 
                    equipamento[i][4]);
                    return;
                }
            }

        }
        static string[][] excluirEquipamento(ref string[][] equipamento, ref int registrados)
        {
            Console.WriteLine("Digite o número de série do item que deseja deletar : ");
            string numItem = Console.ReadLine();
            string[][] copia = new string[5][]{ new string[1000], new string[1000],
            new string[1000], new string[1000], new string[1000]};

            for (int i = 0; i < registrados; i++)
            {
                if (equipamento[i][2] != numItem)
                    copia[i] = equipamento[i];
            }
            return copia;
        }
        static void Main(string[] args)
        {
            // nome 0 preço 1 nº série 2 data fabricação 3 fabricante 4;
            string menu;
            int opcao, opcaoEquipamento, manutencao;
            while (true)
            {
                Console.WriteLine("Digite 1 para entrar no Menu De Equipamentos\nDigite 2 para entrar no" +
                    " Menu de Manutenção\nDigite s para Sair");
                menu = Console.ReadLine();
                if (menu.ToLower().Equals("s"))
                    break;
                int.TryParse(menu, out opcao);
                if (opcao == 1)
                {
                    opcaoEquipamento = menuEquipamento();
                    if (opcaoEquipamento == 1)
                        registrarEquipamento(ref equipamento, ref registrados);
                    else if (opcaoEquipamento == 2)
                        visualizarEquipamento(ref equipamento, ref registrados);
                    else if (opcaoEquipamento == 3)
                        editarEquipamento(ref equipamento);
                    else if (opcaoEquipamento == 4)
                        equipamento = excluirEquipamento(ref equipamento, ref registrados);
                }
                else if (opcao == 2)
                {
                    manutencao = menuManutencao();
                }
                opcao = 0;
            }
        }
   
    }
}
