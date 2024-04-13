using System;
using System.Collections;
using System.Collections.Generic;


namespace FilaDeBanco
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int senha = 1;

            Queue<int> filaClientes = new Queue<int>();           
            
            Queue<int> proximaSenhaComum = new Queue<int>();

            Queue<int> proximaSenhaPrioritario = new Queue<int>();
   



            const int COMUM = 1;
            const int PRIORITARIO = 2;
            const int CHAMAR = 3;
            const int ENCERRAR = 4;
            const int VISUALIZARFILA = 5;
            const int OPCAOINVALIDA = int.MinValue;



            int opcaoEscolhida;

            Console.WriteLine("--Fila de Banco--");
            do
            {

                Console.WriteLine($"{COMUM} - Gerar senha para atendimento comum");
                Console.WriteLine($"{PRIORITARIO} - Gerar senha para atendimento prioritário");
                Console.WriteLine($"{CHAMAR} - Chamada da senha para atendimento");
                Console.WriteLine($"{ENCERRAR} - Encerramento do atendimento");
                Console.WriteLine($"{VISUALIZARFILA} - Visualizar fila de atendimento");

                Console.Write("Digite a opção desejada: ");
                opcaoEscolhida = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opcaoEscolhida)
                {
                    case COMUM:
                        Console.WriteLine($"Sua senha para atendimento comum é: {senha}");
                        proximaSenhaComum.Enqueue(senha) ;
                        filaClientes.Enqueue(senha++);                        
                        break;

                    case PRIORITARIO:
                        Console.WriteLine($"Sua senha para atendimento Prioritário é: {senha}");
                        proximaSenhaPrioritario.Enqueue(senha);
                        filaClientes.Enqueue(senha++);                    
                        break;

                    case CHAMAR:
                        if (filaClientes.Count > 0)
                        {                            
                            if (proximaSenhaPrioritario.Count > 0) 
                            {
                                int senhaChamada = proximaSenhaPrioritario.Dequeue();
                                Console.WriteLine($"A proxima senha do atendimento Prioritário é: {senhaChamada}");
                                
                            }
                            else if (proximaSenhaComum.Count > 0)
                            {
                                int senhaChamada = proximaSenhaComum.Dequeue();
                                Console.WriteLine($"A proxima senha do atendimento Comum é: {senhaChamada}");
                            }
                            filaClientes.Dequeue();
                        }
                        else
                            Console.WriteLine("Não existem mais senhas na fila de atendimento.");
                        break;

                    case VISUALIZARFILA:
                        if (filaClientes.Count > 0)
                        {                          
                            Console.Write("A sua fila de atendimento prioritário é: ");
                            foreach ( var item in proximaSenhaPrioritario)
                            {
                                Console.Write(item + " ");                               
                            }
                            Console.WriteLine("");

                            Console.Write("A sua fila de atendimento comum é: ");
                            foreach ( var item in proximaSenhaComum)
                            {
                                Console.Write(item + " ");                             
                            }                           
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("Sem fila para atendimento.");
                        }

                        break;

                    case ENCERRAR:
                        if (filaClientes.Count == 0)
                            Console.WriteLine("Saindo do programa.");

                        else
                        {
                            Console.WriteLine("Programa não pode sair, pois existem clientes na fila");
                            opcaoEscolhida = OPCAOINVALIDA;
                        }
                        break;

                    default:
                        Console.WriteLine("Opção Invalida");
                        break;                   
                }

                Console.WriteLine("Pressione ENTER para continuar");
                Console.ReadLine();
                Console.Clear();

            } while (opcaoEscolhida != ENCERRAR);

            Console.WriteLine("Banco Fechou... Pressione ENTER para encerrar");
            Console.ReadLine();

        }
    }
}
